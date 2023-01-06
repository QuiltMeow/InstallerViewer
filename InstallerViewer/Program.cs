using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;

namespace InstallerViewer
{
    public static class Program
    {
        private const int FAIL = 1;
        private static readonly IDictionary<InstallerLocation, IList<BinaryProperty>> property = new Dictionary<InstallerLocation, IList<BinaryProperty>>();

        public static IList<RegistryProperty> registry
        {
            get;
            private set;
        }

        [STAThread]
        public static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            registry = new List<RegistryProperty>();
            property.Add(InstallerLocation.WINDOWS_INSTALLER_MSI, new List<BinaryProperty>());
            property.Add(InstallerLocation.WINDOWS_INSTALLER_EXE, new List<BinaryProperty>());
            property.Add(InstallerLocation.PACKAGE_CACHE_MSI, new List<BinaryProperty>());
            property.Add(InstallerLocation.PACKAGE_CACHE_EXE, new List<BinaryProperty>());
            loadAll();
            Application.Run(new MainForm());
        }

        public static IList<BinaryProperty> getByLocation(InstallerLocation location)
        {
            return property[location];
        }

        private static void clearAll()
        {
            foreach (KeyValuePair<InstallerLocation, IList<BinaryProperty>> pair in property)
            {
                pair.Value.Clear();
            }
            registry.Clear();
        }

        public static string[] getMSIFile(string path)
        {
            return Directory.GetFiles(path, "*.msi", SearchOption.AllDirectories);
        }

        public static string[] getEXEFile(string path)
        {
            return Directory.GetFiles(path, "*.exe", SearchOption.AllDirectories);
        }

        public static void loadAll()
        {
            clearAll();
            try
            {
                string installerPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Windows), "Installer");
                loadMSI(InstallerLocation.WINDOWS_INSTALLER_MSI, getMSIFile(installerPath));
                loadEXE(InstallerLocation.WINDOWS_INSTALLER_EXE, getEXEFile(installerPath));

                string packageCachePath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.CommonApplicationData), "Package Cache");
                loadMSI(InstallerLocation.PACKAGE_CACHE_MSI, getMSIFile(packageCachePath));
                loadEXE(InstallerLocation.PACKAGE_CACHE_EXE, getEXEFile(packageCachePath));

                loadRegistry(InstallUser.CURRENT_USER);
                loadRegistry(InstallUser.LOCAL_MACHINE);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"讀取安裝檔案資訊時發生例外狀況 : {ex.Message}", "錯誤", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Environment.Exit(FAIL);
            }
        }

        private static void loadMSI(InstallerLocation location, string[] file)
        {
            IList<BinaryProperty> list = getByLocation(location);
            foreach (string msi in file)
            {
                try
                {
                    list.Add(Util.getMSIProperty(msi));
                }
                catch (Exception ex)
                {
                    Console.Error.WriteLine($"讀取 MSI 檔案時發生例外狀況 : {ex.Message}");
                }
            }
        }

        private static void loadEXE(InstallerLocation location, string[] file)
        {
            IList<BinaryProperty> list = getByLocation(location);
            foreach (string exe in file)
            {
                try
                {
                    list.Add(Util.getEXEProperty(exe));
                }
                catch (Exception ex)
                {
                    Console.Error.WriteLine($"讀取 EXE 檔案時發生例外狀況 : {ex.Message}");
                }
            }
        }

        private static void loadRegistry(InstallUser user)
        {
            const string registryKey = @"SOFTWARE\Microsoft\Windows\CurrentVersion\Uninstall";
            RegistryKey root = user == InstallUser.LOCAL_MACHINE ? Registry.LocalMachine : Registry.CurrentUser;
            using (RegistryKey parent = root.OpenSubKey(registryKey))
            {
                foreach (string key in parent.GetSubKeyNames())
                {
                    RegistryProperty property = new RegistryProperty(user, key);
                    using (RegistryKey subKey = parent.OpenSubKey(key))
                    {
                        foreach (string name in subKey.GetValueNames())
                        {
                            property.addPair(name, subKey.GetValue(name).ToString());
                        }
                    }
                    registry.Add(property);
                }
            }
        }
    }
}