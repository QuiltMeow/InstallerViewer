namespace InstallerViewer
{
    partial class EXEForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(EXEForm));
            this.ilIcon = new System.Windows.Forms.ImageList(this.components);
            this.btnExportAll = new System.Windows.Forms.Button();
            this.btnExportSelect = new System.Windows.Forms.Button();
            this.btnSearch = new System.Windows.Forms.Button();
            this.txtSearch = new System.Windows.Forms.TextBox();
            this.lvDetail = new System.Windows.Forms.ListView();
            this.chProperty = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.chData = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.lvFile = new System.Windows.Forms.ListView();
            this.btnCopySelect = new System.Windows.Forms.Button();
            this.labelLocation = new System.Windows.Forms.Label();
            this.cbLocation = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // ilIcon
            // 
            this.ilIcon.ColorDepth = System.Windows.Forms.ColorDepth.Depth32Bit;
            this.ilIcon.ImageSize = new System.Drawing.Size(32, 32);
            this.ilIcon.TransparentColor = System.Drawing.Color.Transparent;
            // 
            // btnExportAll
            // 
            this.btnExportAll.Location = new System.Drawing.Point(990, 485);
            this.btnExportAll.Name = "btnExportAll";
            this.btnExportAll.Size = new System.Drawing.Size(110, 23);
            this.btnExportAll.TabIndex = 8;
            this.btnExportAll.Text = "導出全部";
            this.btnExportAll.Click += new System.EventHandler(this.btnExportAll_Click);
            // 
            // btnExportSelect
            // 
            this.btnExportSelect.Location = new System.Drawing.Point(770, 485);
            this.btnExportSelect.Name = "btnExportSelect";
            this.btnExportSelect.Size = new System.Drawing.Size(110, 23);
            this.btnExportSelect.TabIndex = 7;
            this.btnExportSelect.Text = "導出已選擇";
            this.btnExportSelect.Click += new System.EventHandler(this.btnExportSelect_Click);
            // 
            // btnSearch
            // 
            this.btnSearch.Location = new System.Drawing.Point(452, 53);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(75, 23);
            this.btnSearch.TabIndex = 3;
            this.btnSearch.Text = "搜尋";
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // txtSearch
            // 
            this.txtSearch.Location = new System.Drawing.Point(27, 55);
            this.txtSearch.Name = "txtSearch";
            this.txtSearch.Size = new System.Drawing.Size(390, 22);
            this.txtSearch.TabIndex = 2;
            // 
            // lvDetail
            // 
            this.lvDetail.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.chProperty,
            this.chData});
            this.lvDetail.HideSelection = false;
            this.lvDetail.Location = new System.Drawing.Point(550, 22);
            this.lvDetail.MultiSelect = false;
            this.lvDetail.Name = "lvDetail";
            this.lvDetail.Size = new System.Drawing.Size(550, 453);
            this.lvDetail.TabIndex = 5;
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
            this.chData.Width = 320;
            // 
            // lvFile
            // 
            this.lvFile.HideSelection = false;
            this.lvFile.LargeImageList = this.ilIcon;
            this.lvFile.Location = new System.Drawing.Point(27, 90);
            this.lvFile.MultiSelect = false;
            this.lvFile.Name = "lvFile";
            this.lvFile.Size = new System.Drawing.Size(500, 385);
            this.lvFile.Sorting = System.Windows.Forms.SortOrder.Ascending;
            this.lvFile.TabIndex = 4;
            this.lvFile.UseCompatibleStateImageBehavior = false;
            this.lvFile.SelectedIndexChanged += new System.EventHandler(this.lvFile_SelectedIndexChanged);
            // 
            // btnCopySelect
            // 
            this.btnCopySelect.Location = new System.Drawing.Point(550, 485);
            this.btnCopySelect.Name = "btnCopySelect";
            this.btnCopySelect.Size = new System.Drawing.Size(110, 23);
            this.btnCopySelect.TabIndex = 6;
            this.btnCopySelect.Text = "複製已選擇";
            this.btnCopySelect.Click += new System.EventHandler(this.btnCopySelect_Click);
            // 
            // labelLocation
            // 
            this.labelLocation.AutoSize = true;
            this.labelLocation.Location = new System.Drawing.Point(25, 25);
            this.labelLocation.Name = "labelLocation";
            this.labelLocation.Size = new System.Drawing.Size(29, 12);
            this.labelLocation.TabIndex = 0;
            this.labelLocation.Text = "位置";
            // 
            // cbLocation
            // 
            this.cbLocation.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbLocation.FormattingEnabled = true;
            this.cbLocation.Items.AddRange(new object[] {
            "Windows Installer 資料夾",
            "Package Cache 資料夾"});
            this.cbLocation.Location = new System.Drawing.Point(65, 22);
            this.cbLocation.Name = "cbLocation";
            this.cbLocation.Size = new System.Drawing.Size(462, 20);
            this.cbLocation.TabIndex = 1;
            this.cbLocation.SelectedIndexChanged += new System.EventHandler(this.cbLocation_SelectedIndexChanged);
            // 
            // EXEForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1119, 521);
            this.Controls.Add(this.cbLocation);
            this.Controls.Add(this.labelLocation);
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
            this.Name = "EXEForm";
            this.Text = "應用程式檢視";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.ImageList ilIcon;
        private System.Windows.Forms.Button btnExportAll;
        private System.Windows.Forms.Button btnExportSelect;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.TextBox txtSearch;
        private System.Windows.Forms.ListView lvDetail;
        private System.Windows.Forms.ColumnHeader chProperty;
        private System.Windows.Forms.ColumnHeader chData;
        private System.Windows.Forms.ListView lvFile;
        private System.Windows.Forms.Button btnCopySelect;
        private System.Windows.Forms.Label labelLocation;
        private System.Windows.Forms.ComboBox cbLocation;
    }
}