using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Text;

namespace InstallerViewer
{
    public abstract class BinaryProperty
    {
        public string fileName
        {
            get;
            protected set;
        }

        public string path
        {
            get;
            protected set;
        }

        public Icon icon
        {
            get;
            protected set;
        }

        public List<KeyValuePair<string, string>> property
        {
            get;
            protected set;
        }

        public BinaryProperty(string path)
        {
            this.path = path;
            fileName = new FileInfo(path).Name;
            icon = Icon.ExtractAssociatedIcon(path);
            property = new List<KeyValuePair<string, string>>();
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"檔案名稱 : {fileName}");
            sb.AppendLine($"檔案路徑 : {path}");
            foreach (KeyValuePair<string, string> pair in property)
            {
                sb.AppendLine($"{pair.Key} : {pair.Value}");
            }
            return sb.ToString();
        }
    }

    public class MSIProperty : BinaryProperty
    {
        public string packageName
        {
            get;
            protected set;
        }

        public MSIProperty(string path) : base(path)
        {
        }

        public void addPair(string key, string value)
        {
            property.Add(new KeyValuePair<string, string>(key, value));
            if (key == "ProductName")
            {
                packageName = value;
            }
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"名稱 : {packageName}");
            sb.AppendLine($"檔案名稱 : {fileName}");
            sb.AppendLine($"檔案路徑 : {path}");
            foreach (KeyValuePair<string, string> pair in property)
            {
                sb.AppendLine($"{pair.Key} : {pair.Value}");
            }
            return sb.ToString();
        }
    }

    public class EXEProperty : BinaryProperty
    {
        public EXEProperty(string path) : base(path)
        {
        }
    }

    public class RegistryProperty
    {
        public bool noName
        {
            get
            {
                return name == null;
            }
        }

        public bool noIcon
        {
            get
            {
                return icon == null;
            }
        }

        public string key
        {
            get;
            private set;
        }

        public string name
        {
            get;
            private set;
        }

        public InstallUser user
        {
            get;
            private set;
        }

        public Icon icon
        {
            get;
            private set;
        }

        public IList<KeyValuePair<string, string>> property
        {
            get;
            private set;
        }

        public RegistryProperty(InstallUser user, string key)
        {
            this.user = user;
            this.key = key;
            property = new List<KeyValuePair<string, string>>();
        }

        public void addPair(string key, string value)
        {
            property.Add(new KeyValuePair<string, string>(key, value));

            const string MSI_EXEC = "msiexec.exe";
            switch (key)
            {
                case "DisplayName":
                    {
                        name = value;
                        break;
                    }
                case "DisplayIcon":
                    {
                        try
                        {
                            switch (value)
                            {
                                case MSI_EXEC:
                                    {
                                        value = getMSIExecPath();
                                        break;
                                    }
                                default:
                                    {
                                        value = value.Replace("\"", string.Empty).Split(',')[0];
                                        break;
                                    }
                            }
                            icon = Icon.ExtractAssociatedIcon(value);
                        }
                        catch (Exception ex)
                        {
                            Console.Error.WriteLine($"讀取圖標時發生例外狀況 : {ex.Message}");
                        }
                        break;
                    }
                case "UninstallString":
                    {
                        if (noIcon)
                        {
                            if (value.ToLower().Contains(MSI_EXEC))
                            {
                                value = getMSIExecPath();
                            }
                            else
                            {
                                value = value.Split(new string[] {
                                    "\""
                                }, StringSplitOptions.RemoveEmptyEntries)[0];
                            }

                            try
                            {
                                icon = Icon.ExtractAssociatedIcon(value);
                            }
                            catch
                            {
                                try
                                {
                                    value = value.Split(' ')[0];
                                    icon = Icon.ExtractAssociatedIcon(value);
                                }
                                catch (Exception ex)
                                {
                                    Console.Error.WriteLine($"讀取圖標時發生例外狀況 : {ex.Message}");
                                }
                            }
                        }
                        break;
                    }
            }

            string getMSIExecPath()
            {
                return Path.Combine(Environment.SystemDirectory, MSI_EXEC);
            }
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"安裝使用者 : {user}");
            sb.AppendLine($"名稱 : {name}");
            sb.AppendLine($"機碼 : {key}");
            foreach (KeyValuePair<string, string> pair in property)
            {
                sb.AppendLine($"{pair.Key} : {pair.Value}");
            }
            return sb.ToString();
        }
    }
}