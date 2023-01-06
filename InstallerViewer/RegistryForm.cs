using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace InstallerViewer
{
    public partial class RegistryForm : Form
    {
        private readonly IList<RegistryProperty> registryList;

        public RegistryForm()
        {
            InitializeComponent();
            registryList = Program.registry;
        }

        private void addFileItem(RegistryProperty registry)
        {
            string key = registry.key;
            ListViewItem item = new ListViewItem(new string[] {
                registry.name,
                key,
                registry.user == InstallUser.LOCAL_MACHINE ? "所有" : "目前"
            });
            lvFile.Items.Add(item);

            if (!registry.noIcon)
            {
                ilIcon.Images.Add(key, registry.icon);
                item.ImageKey = key;
            }
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
                foreach (RegistryProperty registry in registryList)
                {
                    addFileItem(registry);
                }
            }
            else
            {
                search = search.ToLower();
                foreach (RegistryProperty registry in registryList)
                {
                    if ((!registry.noName && registry.name.ToLower().Contains(search)) || registry.key.ToLower().Contains(search))
                    {
                        addFileItem(registry);
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

        private RegistryProperty findSelect(ListViewItem item)
        {
            int keyIndex = item.SubItems.Count - 2;
            string key = item.SubItems[keyIndex].Text;
            foreach (RegistryProperty registry in registryList)
            {
                if (key == registry.key)
                {
                    return registry;
                }
            }
            throw new KeyNotFoundException("找不到指定登錄檔資訊");
        }

        private void lvFile_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!lvFile.isSelect())
            {
                return;
            }
            RegistryProperty registry = findSelect(lvFile.SelectedItems[0]);

            lvDetail.BeginUpdate();
            lvDetail.Items.Clear();
            foreach (KeyValuePair<string, string> pair in registry.property)
            {
                lvDetail.Items.Add(new ListViewItem(new string[]
                {
                    pair.Key,
                    pair.Value
                }));
            }
            lvDetail.EndUpdate();
        }

        private void RegistryForm_Load(object sender, EventArgs e)
        {
            initListView();
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            initListView(txtSearch.Text);
        }

        private void btnCopySelect_Click(object sender, EventArgs e)
        {
            if (!lvFile.isSelect(true))
            {
                return;
            }
            RegistryProperty registry = findSelect(lvFile.SelectedItems[0]);
            registry.copyToClipBoard();
        }

        private void btnExportSelect_Click(object sender, EventArgs e)
        {
            if (!lvFile.isSelect(true))
            {
                return;
            }
            RegistryProperty registry = findSelect(lvFile.SelectedItems[0]);
            registry.exportFileDialog();
        }

        private void btnExportAll_Click(object sender, EventArgs e)
        {
            registryList.exportFileDialog();
        }
    }
}