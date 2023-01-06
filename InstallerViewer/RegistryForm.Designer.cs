namespace InstallerViewer
{
    partial class RegistryForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(RegistryForm));
            this.lvDetail = new System.Windows.Forms.ListView();
            this.chProperty = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.chData = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.lvFile = new System.Windows.Forms.ListView();
            this.chName = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.chKey = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.chUser = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.btnSearch = new System.Windows.Forms.Button();
            this.txtSearch = new System.Windows.Forms.TextBox();
            this.btnCopySelect = new System.Windows.Forms.Button();
            this.btnExportAll = new System.Windows.Forms.Button();
            this.btnExportSelect = new System.Windows.Forms.Button();
            this.ilIcon = new System.Windows.Forms.ImageList(this.components);
            this.SuspendLayout();
            // 
            // lvDetail
            // 
            this.lvDetail.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.chProperty,
            this.chData});
            this.lvDetail.HideSelection = false;
            this.lvDetail.Location = new System.Drawing.Point(665, 25);
            this.lvDetail.MultiSelect = false;
            this.lvDetail.Name = "lvDetail";
            this.lvDetail.Size = new System.Drawing.Size(555, 425);
            this.lvDetail.TabIndex = 3;
            this.lvDetail.UseCompatibleStateImageBehavior = false;
            this.lvDetail.View = System.Windows.Forms.View.Details;
            // 
            // chProperty
            // 
            this.chProperty.Text = "屬性";
            this.chProperty.Width = 200;
            // 
            // chData
            // 
            this.chData.Text = "資料";
            this.chData.Width = 325;
            // 
            // lvFile
            // 
            this.lvFile.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.chName,
            this.chKey,
            this.chUser});
            this.lvFile.HideSelection = false;
            this.lvFile.Location = new System.Drawing.Point(25, 65);
            this.lvFile.MultiSelect = false;
            this.lvFile.Name = "lvFile";
            this.lvFile.Size = new System.Drawing.Size(615, 385);
            this.lvFile.SmallImageList = this.ilIcon;
            this.lvFile.Sorting = System.Windows.Forms.SortOrder.Ascending;
            this.lvFile.TabIndex = 2;
            this.lvFile.UseCompatibleStateImageBehavior = false;
            this.lvFile.View = System.Windows.Forms.View.Details;
            this.lvFile.SelectedIndexChanged += new System.EventHandler(this.lvFile_SelectedIndexChanged);
            // 
            // chName
            // 
            this.chName.Text = "名稱";
            this.chName.Width = 260;
            // 
            // chKey
            // 
            this.chKey.Text = "機碼";
            this.chKey.Width = 275;
            // 
            // chUser
            // 
            this.chUser.Text = "使用者";
            this.chUser.Width = 50;
            // 
            // btnSearch
            // 
            this.btnSearch.Location = new System.Drawing.Point(565, 23);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(75, 23);
            this.btnSearch.TabIndex = 1;
            this.btnSearch.Text = "搜尋";
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // txtSearch
            // 
            this.txtSearch.Location = new System.Drawing.Point(25, 25);
            this.txtSearch.Name = "txtSearch";
            this.txtSearch.Size = new System.Drawing.Size(515, 22);
            this.txtSearch.TabIndex = 0;
            // 
            // btnCopySelect
            // 
            this.btnCopySelect.Location = new System.Drawing.Point(665, 460);
            this.btnCopySelect.Name = "btnCopySelect";
            this.btnCopySelect.Size = new System.Drawing.Size(110, 23);
            this.btnCopySelect.TabIndex = 4;
            this.btnCopySelect.Text = "複製已選擇";
            this.btnCopySelect.Click += new System.EventHandler(this.btnCopySelect_Click);
            // 
            // btnExportAll
            // 
            this.btnExportAll.Location = new System.Drawing.Point(1110, 460);
            this.btnExportAll.Name = "btnExportAll";
            this.btnExportAll.Size = new System.Drawing.Size(110, 23);
            this.btnExportAll.TabIndex = 6;
            this.btnExportAll.Text = "導出全部";
            this.btnExportAll.Click += new System.EventHandler(this.btnExportAll_Click);
            // 
            // btnExportSelect
            // 
            this.btnExportSelect.Location = new System.Drawing.Point(895, 460);
            this.btnExportSelect.Name = "btnExportSelect";
            this.btnExportSelect.Size = new System.Drawing.Size(110, 23);
            this.btnExportSelect.TabIndex = 5;
            this.btnExportSelect.Text = "導出已選擇";
            this.btnExportSelect.Click += new System.EventHandler(this.btnExportSelect_Click);
            // 
            // ilIcon
            // 
            this.ilIcon.ColorDepth = System.Windows.Forms.ColorDepth.Depth32Bit;
            this.ilIcon.ImageSize = new System.Drawing.Size(16, 16);
            this.ilIcon.TransparentColor = System.Drawing.Color.Transparent;
            // 
            // RegistryForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1239, 496);
            this.Controls.Add(this.btnCopySelect);
            this.Controls.Add(this.btnExportAll);
            this.Controls.Add(this.btnExportSelect);
            this.Controls.Add(this.btnSearch);
            this.Controls.Add(this.txtSearch);
            this.Controls.Add(this.lvDetail);
            this.Controls.Add(this.lvFile);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.ImeMode = System.Windows.Forms.ImeMode.Off;
            this.MaximizeBox = false;
            this.Name = "RegistryForm";
            this.Text = "登錄檔檢視";
            this.Load += new System.EventHandler(this.RegistryForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListView lvDetail;
        private System.Windows.Forms.ColumnHeader chProperty;
        private System.Windows.Forms.ColumnHeader chData;
        private System.Windows.Forms.ListView lvFile;
        private System.Windows.Forms.ColumnHeader chName;
        private System.Windows.Forms.ColumnHeader chKey;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.TextBox txtSearch;
        private System.Windows.Forms.Button btnCopySelect;
        private System.Windows.Forms.Button btnExportAll;
        private System.Windows.Forms.Button btnExportSelect;
        private System.Windows.Forms.ColumnHeader chUser;
        private System.Windows.Forms.ImageList ilIcon;
    }
}