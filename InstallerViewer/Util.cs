using Microsoft.Deployment.WindowsInstaller;
using Microsoft.Deployment.WindowsInstaller.Linq;
using Microsoft.Deployment.WindowsInstaller.Linq.Entities;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace InstallerViewer
{
    public static class Util
    {
        public static MSIProperty getMSIProperty(string file)
        {
            MSIProperty ret = new MSIProperty(file);
            using (QDatabase database = new QDatabase(file, DatabaseOpenMode.ReadOnly))
            {
                IQueryable<Property_> propertyQuery = from property in database.Properties select property;
                foreach (Property_ property in propertyQuery)
                {
                    ret.addPair(property.Property, property.Value);
                }
            }
            return ret;
        }

        public static EXEProperty getEXEProperty(string file)
        {
            EXEProperty ret = new EXEProperty(file);
            IList<KeyValuePair<string, string>> pair = ret.property;

            FileVersionInfo info = FileVersionInfo.GetVersionInfo(file);
            pair.Add(new KeyValuePair<string, string>("Comments", info.Comments));
            pair.Add(new KeyValuePair<string, string>("CompanyName", info.CompanyName));
            pair.Add(new KeyValuePair<string, string>("FileBuildPart", info.FileBuildPart.ToString()));
            pair.Add(new KeyValuePair<string, string>("FileDescription", info.FileDescription));
            pair.Add(new KeyValuePair<string, string>("FileMajorPart", info.FileMajorPart.ToString()));
            pair.Add(new KeyValuePair<string, string>("FileMinorPart", info.FileMinorPart.ToString()));
            pair.Add(new KeyValuePair<string, string>("FileName", info.FileName));
            pair.Add(new KeyValuePair<string, string>("FilePrivatePart", info.FilePrivatePart.ToString()));
            pair.Add(new KeyValuePair<string, string>("FileVersion", info.FileVersion));
            pair.Add(new KeyValuePair<string, string>("InternalName", info.InternalName));
            pair.Add(new KeyValuePair<string, string>("IsDebug", info.IsDebug.ToString()));
            pair.Add(new KeyValuePair<string, string>("IsPatched", info.IsPatched.ToString()));
            pair.Add(new KeyValuePair<string, string>("IsPrivateBuild", info.IsPrivateBuild.ToString()));
            pair.Add(new KeyValuePair<string, string>("IsPreRelease", info.IsPreRelease.ToString()));
            pair.Add(new KeyValuePair<string, string>("IsSpecialBuild", info.IsSpecialBuild.ToString()));
            pair.Add(new KeyValuePair<string, string>("Language", info.Language));
            pair.Add(new KeyValuePair<string, string>("LegalCopyright", info.LegalCopyright));
            pair.Add(new KeyValuePair<string, string>("LegalTrademarks", info.LegalTrademarks));
            pair.Add(new KeyValuePair<string, string>("OriginalFilename", info.OriginalFilename));
            pair.Add(new KeyValuePair<string, string>("PrivateBuild", info.PrivateBuild));
            pair.Add(new KeyValuePair<string, string>("ProductBuildPart", info.ProductBuildPart.ToString()));
            pair.Add(new KeyValuePair<string, string>("ProductMajorPart", info.ProductMajorPart.ToString()));
            pair.Add(new KeyValuePair<string, string>("ProductMinorPart", info.ProductMinorPart.ToString()));
            pair.Add(new KeyValuePair<string, string>("ProductName", info.ProductName));
            pair.Add(new KeyValuePair<string, string>("ProductPrivatePart", info.ProductPrivatePart.ToString()));
            pair.Add(new KeyValuePair<string, string>("ProductVersion", info.ProductVersion));
            pair.Add(new KeyValuePair<string, string>("SpecialBuild", info.SpecialBuild));
            return ret;
        }

        public static bool isSelect(this ListView listView, bool dialog = false)
        {
            bool ret = listView.SelectedIndices.Count > 0;
            if (!ret && dialog)
            {
                MessageBox.Show("尚未選擇任何項目", "提醒", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            return ret;
        }

        public static void copyToClipBoard(this object data, bool dialog = true)
        {
            Exception exception = null;
            try
            {
                Clipboard.SetText(data.ToString());
            }
            catch (Exception ex)
            {
                exception = ex;
            }

            if (dialog)
            {
                if (exception == null)
                {
                    MessageBox.Show("已複製資訊到剪貼簿", "資訊", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show($"複製資訊到剪貼簿時發生例外狀況 : {exception.Message}", "錯誤", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        public static void exportFile(this object data, string path)
        {
            using (FileStream fs = new FileStream(path, FileMode.Create, FileAccess.Write))
            {
                using (StreamWriter sw = new StreamWriter(fs))
                {
                    sw.Write(data);
                }
            }
        }

        public static void exportFileAll<T>(this IEnumerable<T> collection, string path)
        {
            using (FileStream fs = new FileStream(path, FileMode.Create, FileAccess.Write))
            {
                using (StreamWriter sw = new StreamWriter(fs))
                {
                    foreach (T data in collection)
                    {
                        sw.WriteLine(data);
                    }
                }
            }
        }

        public static void exportFileDialog(this object data)
        {
            using (SaveFileDialog save = new SaveFileDialog()
            {
                Filter = "文字檔案 (*.txt)|*.txt",
                Title = "請指定輸出檔案"
            })
            {
                if (save.ShowDialog() != DialogResult.OK)
                {
                    return;
                }

                string name = save.FileName;
                try
                {
                    if (data is IEnumerable)
                    {
                        ((IEnumerable<object>)data).exportFileAll(name);
                    }
                    else
                    {
                        data.exportFile(name);
                    }
                    MessageBox.Show("檔案導出完成", "資訊", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"檔案導出時發生例外狀況 : {ex.Message}", "錯誤", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
    }
}