using System;
using System.Collections.Generic;
using System.Windows.Forms;
using static System.Windows.Forms.ListView;

namespace InstallerViewer
{
    public partial class FileForm : Form
    {
        private readonly OpenFileType type;
        private readonly string path;
        private BinaryProperty property;

        public FileForm(OpenFileType type, string path)
        {
            InitializeComponent();
            this.type = type;
            this.path = path;
        }

        private MSIProperty openMSI()
        {
            MSIProperty msi = Util.getMSIProperty(path);
            ListViewItemCollection collection = lvDetail.Items;

            lvDetail.BeginUpdate();
            collection.Add(new ListViewItem(new string[]
            {
                "名稱",
                msi.packageName
            }));

            collection.Add(new ListViewItem(new string[]
            {
                "檔案名稱",
                msi.fileName
            }));

            collection.Add(new ListViewItem(new string[]
            {
                "檔案路徑",
                msi.path
            }));
            pbIcon.Image = msi.icon.ToBitmap();
            loadDetail(msi);
            lvDetail.EndUpdate();
            return msi;
        }

        private void loadDetail(BinaryProperty property)
        {
            foreach (KeyValuePair<string, string> pair in property.property)
            {
                lvDetail.Items.Add(new ListViewItem(new string[]
                {
                    pair.Key,
                    pair.Value
                }));
            }
        }

        private EXEProperty openEXE()
        {
            EXEProperty exe = Util.getEXEProperty(path);
            ListViewItemCollection collection = lvDetail.Items;

            lvDetail.BeginUpdate();
            collection.Add(new ListViewItem(new string[]
            {
                "檔案名稱",
                exe.fileName
            }));

            collection.Add(new ListViewItem(new string[]
            {
                "檔案路徑",
                exe.path
            }));
            pbIcon.Image = exe.icon.ToBitmap();
            loadDetail(exe);
            lvDetail.EndUpdate();
            return exe;
        }

        private void FileForm_Load(object sender, EventArgs e)
        {
            try
            {
                switch (type)
                {
                    case OpenFileType.MSI:
                        {
                            property = openMSI();
                            break;
                        }
                    case OpenFileType.EXE:
                        {
                            property = openEXE();
                            break;
                        }
                    default:
                        {
                            throw new KeyNotFoundException("錯誤的類型");
                        }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"讀取檔案時發生例外狀況 : {ex.Message}", "錯誤", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Close();
            }
        }

        private void btnCopy_Click(object sender, EventArgs e)
        {
            property.copyToClipBoard();
        }

        private void btnExport_Click(object sender, EventArgs e)
        {
            property.exportFileDialog();
        }
    }
}