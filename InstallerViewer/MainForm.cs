using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace InstallerViewer
{
    public partial class MainForm : Form
    {
        private IList<MSIProperty> msiList;

        public MainForm()
        {
            InitializeComponent();
            cbLocation.SelectedIndex = 0;
        }

        private void btnExportSelect_Click(object sender, EventArgs e)
        {
            if (!lvFile.isSelect(true))
            {
                return;
            }
            MSIProperty msi = findSelect(lvFile.SelectedItems[0]);
            msi.exportFileDialog();
        }

        private void btnExportAll_Click(object sender, EventArgs e)
        {
            msiList.exportFileDialog();
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            initListView(txtSearch.Text);
        }

        private void lvFile_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!lvFile.isSelect())
            {
                return;
            }
            MSIProperty msi = findSelect(lvFile.SelectedItems[0]);

            lvDetail.BeginUpdate();
            lvDetail.Items.Clear();
            foreach (KeyValuePair<string, string> pair in msi.property)
            {
                lvDetail.Items.Add(new ListViewItem(new string[]
                {
                    pair.Key,
                    pair.Value
                }));
            }
            lvDetail.EndUpdate();
        }

        private MSIProperty findSelect(ListViewItem item)
        {
            int lastIndex = item.SubItems.Count - 1;
            string path = item.SubItems[lastIndex].Text;
            foreach (MSIProperty msi in msiList)
            {
                if (path == msi.path)
                {
                    return msi;
                }
            }
            throw new KeyNotFoundException("找不到指定 MSI 資訊");
        }

        private void addFileItem(MSIProperty msi)
        {
            lvFile.Items.Add(new ListViewItem(new string[] {
                msi.packageName,
                msi.fileName,
                msi.path
            }));
        }

        private void initListView(string search = null)
        {
            lvFile.BeginUpdate();
            lvDetail.BeginUpdate();

            lvFile.Items.Clear();
            lvDetail.Items.Clear();

            if (string.IsNullOrWhiteSpace(search))
            {
                foreach (MSIProperty msi in msiList)
                {
                    addFileItem(msi);
                }
            }
            else
            {
                search = search.ToLower();
                foreach (MSIProperty msi in msiList)
                {
                    if (msi.packageName.ToLower().Contains(search) || msi.fileName.ToLower().Contains(search))
                    {
                        addFileItem(msi);
                    }
                }
            }

            if (lvFile.Items.Count > 0)
            {
                lvFile.Items[0].Selected = true;
            }

            lvFile.EndUpdate();
            lvDetail.EndUpdate();
        }

        private void btnViewEXE_Click(object sender, EventArgs e)
        {
            using (Form form = new EXEForm())
            {
                form.ShowDialog();
            }
        }

        private void btnOpenMSI_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog dialog = new OpenFileDialog()
            {
                Filter = "安裝程式檔案|*.msi;*.exe|MSI 安裝檔案 (*.msi)|*.msi|EXE 程式檔案 (*.exe)|*.exe",
                Title = "請選擇檔案"
            })
            {
                if (dialog.ShowDialog() == DialogResult.OK)
                {
                    string file = dialog.FileName;
                    string extension = Path.GetExtension(file).ToLower();
                    using (Form form = new FileForm(extension == ".msi" ? OpenFileType.MSI : OpenFileType.EXE, file))
                    {
                        form.ShowDialog();
                    }
                }
            }
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("確定重整所有資訊 ?", "詢問", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                Program.loadAll();
                cbLocation.SelectedIndex = 0;
                MessageBox.Show("重新整理完成", "資訊", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void btnCopySelect_Click(object sender, EventArgs e)
        {
            if (!lvFile.isSelect(true))
            {
                return;
            }
            MSIProperty msi = findSelect(lvFile.SelectedItems[0]);
            msi.copyToClipBoard();
        }

        private void cbLocation_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (cbLocation.SelectedIndex)
            {
                case 0:
                    {
                        msiList = Program.getByLocation(InstallerLocation.WINDOWS_INSTALLER_MSI).Cast<MSIProperty>().ToList();
                        break;
                    }
                case 1:
                    {
                        msiList = Program.getByLocation(InstallerLocation.PACKAGE_CACHE_MSI).Cast<MSIProperty>().ToList();
                        break;
                    }
                default:
                    {
                        throw new InvalidOperationException("無效的選項");
                    }
            }
            txtSearch.Text = string.Empty;
            initListView();
        }

        private void btnViewRegistry_Click(object sender, EventArgs e)
        {
            using (Form form = new RegistryForm())
            {
                form.ShowDialog();
            }
        }
    }
}