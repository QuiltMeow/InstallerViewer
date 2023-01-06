using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace InstallerViewer
{
    public partial class EXEForm : Form
    {
        private IList<EXEProperty> exeList;

        public EXEForm()
        {
            InitializeComponent();
            cbLocation.SelectedIndex = 0;
        }

        private void addFileItem(EXEProperty exe)
        {
            string path = exe.path;
            ilIcon.Images.Add(path, exe.icon);
            lvFile.Items.Add(path, exe.fileName, path);
        }

        private void initListView(string search = null)
        {
            lvFile.BeginUpdate();
            lvDetail.BeginUpdate();

            lvFile.Items.Clear();
            ilIcon.Images.Clear();
            lvDetail.Items.Clear();

            if (string.IsNullOrWhiteSpace(search))
            {
                foreach (EXEProperty exe in exeList)
                {
                    addFileItem(exe);
                }
            }
            else
            {
                search = search.ToLower();
                foreach (EXEProperty exe in exeList)
                {
                    if (exe.fileName.ToLower().Contains(search))
                    {
                        addFileItem(exe);
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

        private EXEProperty findSelect(ListViewItem item)
        {
            string path = item.Name;
            foreach (EXEProperty exe in exeList)
            {
                if (path == exe.path)
                {
                    return exe;
                }
            }
            throw new KeyNotFoundException("找不到指定 EXE 資訊");
        }

        private void lvFile_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!lvFile.isSelect())
            {
                return;
            }
            EXEProperty exe = findSelect(lvFile.SelectedItems[0]);

            lvDetail.BeginUpdate();
            lvDetail.Items.Clear();
            foreach (KeyValuePair<string, string> pair in exe.property)
            {
                lvDetail.Items.Add(new ListViewItem(new string[]
                {
                    pair.Key,
                    pair.Value
                }));
            }
            lvDetail.EndUpdate();
        }

        private void btnExportSelect_Click(object sender, EventArgs e)
        {
            if (!lvFile.isSelect(true))
            {
                return;
            }
            EXEProperty exe = findSelect(lvFile.SelectedItems[0]);
            exe.exportFileDialog();
        }

        private void btnExportAll_Click(object sender, EventArgs e)
        {
            exeList.exportFileDialog();
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            initListView(txtSearch.Text);
        }

        private void cbLocation_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (cbLocation.SelectedIndex)
            {
                case 0:
                    {
                        exeList = Program.getByLocation(InstallerLocation.WINDOWS_INSTALLER_EXE).Cast<EXEProperty>().ToList();
                        break;
                    }
                case 1:
                    {
                        exeList = Program.getByLocation(InstallerLocation.PACKAGE_CACHE_EXE).Cast<EXEProperty>().ToList();
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

        private void btnCopySelect_Click(object sender, EventArgs e)
        {
            if (!lvFile.isSelect(true))
            {
                return;
            }
            EXEProperty exe = findSelect(lvFile.SelectedItems[0]);
            exe.copyToClipBoard();
        }
    }
}