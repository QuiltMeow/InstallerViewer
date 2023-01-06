namespace InstallerViewer
{
    partial class MainForm
    {
        /// <summary>
        /// 設計工具所需的變數。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清除任何使用中的資源。
        /// </summary>
        /// <param name="disposing">如果應該處置受控資源則為 true，否則為 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form 設計工具產生的程式碼

        /// <summary>
        /// 此為設計工具支援所需的方法 - 請勿使用程式碼編輯器修改
        /// 這個方法的內容。
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.lvFile = new System.Windows.Forms.ListView();
            this.chPackageName = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.chFileName = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.chPath = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.lvDetail = new System.Windows.Forms.ListView();
            this.chProperty = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.chData = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.txtSearch = new System.Windows.Forms.TextBox();
            this.btnSearch = new System.Windows.Forms.Button();
            this.btnExportSelect = new System.Windows.Forms.Button();
            this.btnExportAll = new System.Windows.Forms.Button();
            this.btnViewEXE = new System.Windows.Forms.Button();
            this.btnCopySelect = new System.Windows.Forms.Button();
            this.btnOpenMSI = new System.Windows.Forms.Button();
            this.btnRefresh = new System.Windows.Forms.Button();
            this.cbLocation = new System.Windows.Forms.ComboBox();
            this.labelLocation = new System.Windows.Forms.Label();
            this.btnViewRegistry = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lvFile
            // 
            this.lvFile.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.chPackageName,
            this.chFileName,
            this.chPath});
            this.lvFile.HideSelection = false;
            this.lvFile.Location = new System.Drawing.Point(27, 90);
            this.lvFile.MultiSelect = false;
            this.lvFile.Name = "lvFile";
            this.lvFile.Size = new System.Drawing.Size(600, 385);
            this.lvFile.Sorting = System.Windows.Forms.SortOrder.Ascending;
            this.lvFile.TabIndex = 4;
            this.lvFile.UseCompatibleStateImageBehavior = false;
            this.lvFile.View = System.Windows.Forms.View.Details;
            this.lvFile.SelectedIndexChanged += new System.EventHandler(this.lvFile_SelectedIndexChanged);
            // 
            // chPackageName
            // 
            this.chPackageName.Text = "名稱";
            this.chPackageName.Width = 230;
            // 
            // chFileName
            // 
            this.chFileName.Text = "檔案名稱";
            this.chFileName.Width = 100;
            // 
            // chPath
            // 
            this.chPath.Text = "檔案路徑";
            this.chPath.Width = 240;
            // 
            // lvDetail
            // 
            this.lvDetail.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.chProperty,
            this.chData});
            this.lvDetail.HideSelection = false;
            this.lvDetail.Location = new System.Drawing.Point(650, 22);
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
            // txtSearch
            // 
            this.txtSearch.Location = new System.Drawing.Point(27, 55);
            this.txtSearch.Name = "txtSearch";
            this.txtSearch.Size = new System.Drawing.Size(485, 22);
            this.txtSearch.TabIndex = 2;
            // 
            // btnSearch
            // 
            this.btnSearch.Location = new System.Drawing.Point(552, 53);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(75, 23);
            this.btnSearch.TabIndex = 3;
            this.btnSearch.Text = "搜尋";
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // btnExportSelect
            // 
            this.btnExportSelect.Location = new System.Drawing.Point(945, 485);
            this.btnExportSelect.Name = "btnExportSelect";
            this.btnExportSelect.Size = new System.Drawing.Size(110, 23);
            this.btnExportSelect.TabIndex = 11;
            this.btnExportSelect.Text = "導出已選擇";
            this.btnExportSelect.Click += new System.EventHandler(this.btnExportSelect_Click);
            // 
            // btnExportAll
            // 
            this.btnExportAll.Location = new System.Drawing.Point(1090, 485);
            this.btnExportAll.Name = "btnExportAll";
            this.btnExportAll.Size = new System.Drawing.Size(110, 23);
            this.btnExportAll.TabIndex = 12;
            this.btnExportAll.Text = "導出全部";
            this.btnExportAll.Click += new System.EventHandler(this.btnExportAll_Click);
            // 
            // btnViewEXE
            // 
            this.btnViewEXE.Location = new System.Drawing.Point(27, 485);
            this.btnViewEXE.Name = "btnViewEXE";
            this.btnViewEXE.Size = new System.Drawing.Size(110, 23);
            this.btnViewEXE.TabIndex = 6;
            this.btnViewEXE.Text = "檢視應用程式";
            this.btnViewEXE.Click += new System.EventHandler(this.btnViewEXE_Click);
            // 
            // btnCopySelect
            // 
            this.btnCopySelect.Location = new System.Drawing.Point(795, 485);
            this.btnCopySelect.Name = "btnCopySelect";
            this.btnCopySelect.Size = new System.Drawing.Size(110, 23);
            this.btnCopySelect.TabIndex = 10;
            this.btnCopySelect.Text = "複製已選擇";
            this.btnCopySelect.Click += new System.EventHandler(this.btnCopySelect_Click);
            // 
            // btnOpenMSI
            // 
            this.btnOpenMSI.Location = new System.Drawing.Point(150, 485);
            this.btnOpenMSI.Name = "btnOpenMSI";
            this.btnOpenMSI.Size = new System.Drawing.Size(110, 23);
            this.btnOpenMSI.TabIndex = 7;
            this.btnOpenMSI.Text = "開啟檔案";
            this.btnOpenMSI.Click += new System.EventHandler(this.btnOpenMSI_Click);
            // 
            // btnRefresh
            // 
            this.btnRefresh.Location = new System.Drawing.Point(517, 485);
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new System.Drawing.Size(110, 23);
            this.btnRefresh.TabIndex = 8;
            this.btnRefresh.Text = "全部重新整理";
            this.btnRefresh.Click += new System.EventHandler(this.btnRefresh_Click);
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
            this.cbLocation.Size = new System.Drawing.Size(562, 20);
            this.cbLocation.TabIndex = 1;
            this.cbLocation.SelectedIndexChanged += new System.EventHandler(this.cbLocation_SelectedIndexChanged);
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
            // btnViewRegistry
            // 
            this.btnViewRegistry.Location = new System.Drawing.Point(650, 485);
            this.btnViewRegistry.Name = "btnViewRegistry";
            this.btnViewRegistry.Size = new System.Drawing.Size(110, 23);
            this.btnViewRegistry.TabIndex = 9;
            this.btnViewRegistry.Text = "檢視登錄檔";
            this.btnViewRegistry.Click += new System.EventHandler(this.btnViewRegistry_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1224, 526);
            this.Controls.Add(this.btnViewRegistry);
            this.Controls.Add(this.cbLocation);
            this.Controls.Add(this.labelLocation);
            this.Controls.Add(this.btnRefresh);
            this.Controls.Add(this.btnOpenMSI);
            this.Controls.Add(this.btnCopySelect);
            this.Controls.Add(this.btnViewEXE);
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
            this.Name = "MainForm";
            this.Text = "安裝程式檢視工具";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListView lvFile;
        private System.Windows.Forms.ListView lvDetail;
        private System.Windows.Forms.TextBox txtSearch;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.Button btnExportSelect;
        private System.Windows.Forms.Button btnExportAll;
        private System.Windows.Forms.ColumnHeader chPackageName;
        private System.Windows.Forms.ColumnHeader chPath;
        private System.Windows.Forms.ColumnHeader chProperty;
        private System.Windows.Forms.ColumnHeader chData;
        private System.Windows.Forms.Button btnViewEXE;
        private System.Windows.Forms.Button btnCopySelect;
        private System.Windows.Forms.Button btnOpenMSI;
        private System.Windows.Forms.Button btnRefresh;
        private System.Windows.Forms.ColumnHeader chFileName;
        private System.Windows.Forms.ComboBox cbLocation;
        private System.Windows.Forms.Label labelLocation;
        private System.Windows.Forms.Button btnViewRegistry;
    }
}

