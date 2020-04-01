namespace TheFileSplitter
{
    partial class frmMain
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
            this.lblStatus = new System.Windows.Forms.Label();
            this.rdbTwo = new System.Windows.Forms.RadioButton();
            this.btnGo = new System.Windows.Forms.Button();
            this.txtFolderPath = new System.Windows.Forms.TextBox();
            this.lblFolder = new System.Windows.Forms.Label();
            this.btnSaveTo = new System.Windows.Forms.Button();
            this.prgbProgress = new System.Windows.Forms.ProgressBar();
            this.pnlActions = new System.Windows.Forms.Panel();
            this.rdbMerge = new System.Windows.Forms.RadioButton();
            this.rdbSplit = new System.Windows.Forms.RadioButton();
            this.btnBrowse = new System.Windows.Forms.Button();
            this.txtFileName = new System.Windows.Forms.TextBox();
            this.rdbOne = new System.Windows.Forms.RadioButton();
            this.grpbxMain = new System.Windows.Forms.GroupBox();
            this.pnlSizers = new System.Windows.Forms.Panel();
            this.rdbKiloBytes = new System.Windows.Forms.RadioButton();
            this.rdbBytes = new System.Windows.Forms.RadioButton();
            this.rdbMegaBytes = new System.Windows.Forms.RadioButton();
            this.txtSize = new System.Windows.Forms.TextBox();
            this.rdbFree = new System.Windows.Forms.RadioButton();
            this.rdbCD = new System.Windows.Forms.RadioButton();
            this.rdbFDD = new System.Windows.Forms.RadioButton();
            this.grpCache = new System.Windows.Forms.GroupBox();
            this.rdbDefault = new System.Windows.Forms.RadioButton();
            this.rdbSeven = new System.Windows.Forms.RadioButton();
            this.lblFileName = new System.Windows.Forms.Label();
            this.dlgOpen = new System.Windows.Forms.OpenFileDialog();
            this.dlgSaveTo = new System.Windows.Forms.FolderBrowserDialog();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.pnlActions.SuspendLayout();
            this.grpbxMain.SuspendLayout();
            this.pnlSizers.SuspendLayout();
            this.grpCache.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblStatus
            // 
            this.lblStatus.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblStatus.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblStatus.Location = new System.Drawing.Point(20, 226);
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new System.Drawing.Size(378, 24);
            this.lblStatus.TabIndex = 27;
            this.lblStatus.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // rdbTwo
            // 
            this.rdbTwo.Location = new System.Drawing.Point(7, 47);
            this.rdbTwo.Name = "rdbTwo";
            this.rdbTwo.Size = new System.Drawing.Size(60, 24);
            this.rdbTwo.TabIndex = 20;
            this.rdbTwo.Text = "2 Mb";
            this.rdbTwo.CheckedChanged += new System.EventHandler(this.setCacheSize);
            // 
            // btnGo
            // 
            this.btnGo.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnGo.Location = new System.Drawing.Point(404, 227);
            this.btnGo.Name = "btnGo";
            this.btnGo.Size = new System.Drawing.Size(56, 23);
            this.btnGo.TabIndex = 25;
            this.btnGo.Text = "Split";
            this.btnGo.Click += new System.EventHandler(this.btnGo_Click);
            // 
            // txtFolderPath
            // 
            this.txtFolderPath.Location = new System.Drawing.Point(92, 58);
            this.txtFolderPath.Name = "txtFolderPath";
            this.txtFolderPath.Size = new System.Drawing.Size(224, 20);
            this.txtFolderPath.TabIndex = 20;
            this.toolTip1.SetToolTip(this.txtFolderPath, "Set the destination directory without \\ at the end");
            // 
            // lblFolder
            // 
            this.lblFolder.Location = new System.Drawing.Point(20, 58);
            this.lblFolder.Name = "lblFolder";
            this.lblFolder.Size = new System.Drawing.Size(64, 23);
            this.lblFolder.TabIndex = 24;
            this.lblFolder.Text = "Destination";
            this.lblFolder.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // btnSaveTo
            // 
            this.btnSaveTo.Location = new System.Drawing.Point(324, 58);
            this.btnSaveTo.Name = "btnSaveTo";
            this.btnSaveTo.Size = new System.Drawing.Size(56, 20);
            this.btnSaveTo.TabIndex = 21;
            this.btnSaveTo.Text = "Save As";
            this.btnSaveTo.Click += new System.EventHandler(this.btnSaveTo_Click);
            // 
            // prgbProgress
            // 
            this.prgbProgress.Enabled = false;
            this.prgbProgress.Location = new System.Drawing.Point(20, 194);
            this.prgbProgress.Name = "prgbProgress";
            this.prgbProgress.Size = new System.Drawing.Size(360, 24);
            this.prgbProgress.TabIndex = 23;
            this.prgbProgress.Visible = false;
            // 
            // pnlActions
            // 
            this.pnlActions.Controls.Add(this.rdbMerge);
            this.pnlActions.Controls.Add(this.rdbSplit);
            this.pnlActions.Location = new System.Drawing.Point(404, 154);
            this.pnlActions.Name = "pnlActions";
            this.pnlActions.Size = new System.Drawing.Size(80, 64);
            this.pnlActions.TabIndex = 28;
            // 
            // rdbMerge
            // 
            this.rdbMerge.Location = new System.Drawing.Point(12, 32);
            this.rdbMerge.Name = "rdbMerge";
            this.rdbMerge.Size = new System.Drawing.Size(60, 24);
            this.rdbMerge.TabIndex = 18;
            this.rdbMerge.Text = "Merge";
            this.toolTip1.SetToolTip(this.rdbMerge, "Otherwise do: copy /b *.part fusion.dat");
            this.rdbMerge.CheckedChanged += new System.EventHandler(this.rdbMerge_CheckedChanged);
            // 
            // rdbSplit
            // 
            this.rdbSplit.Checked = true;
            this.rdbSplit.Location = new System.Drawing.Point(12, 8);
            this.rdbSplit.Name = "rdbSplit";
            this.rdbSplit.Size = new System.Drawing.Size(60, 24);
            this.rdbSplit.TabIndex = 17;
            this.rdbSplit.TabStop = true;
            this.rdbSplit.Text = "Split";
            this.rdbSplit.CheckedChanged += new System.EventHandler(this.rdbSplit_CheckedChanged);
            // 
            // btnBrowse
            // 
            this.btnBrowse.Location = new System.Drawing.Point(324, 18);
            this.btnBrowse.Name = "btnBrowse";
            this.btnBrowse.Size = new System.Drawing.Size(56, 20);
            this.btnBrowse.TabIndex = 19;
            this.btnBrowse.Text = "Browse";
            this.btnBrowse.Click += new System.EventHandler(this.btnBrowse_Click);
            // 
            // txtFileName
            // 
            this.txtFileName.Location = new System.Drawing.Point(92, 18);
            this.txtFileName.Name = "txtFileName";
            this.txtFileName.Size = new System.Drawing.Size(224, 20);
            this.txtFileName.TabIndex = 18;
            this.txtFileName.TextChanged += new System.EventHandler(this.txtFileName_TextChanged);
            // 
            // rdbOne
            // 
            this.rdbOne.Checked = true;
            this.rdbOne.Location = new System.Drawing.Point(7, 23);
            this.rdbOne.Name = "rdbOne";
            this.rdbOne.Size = new System.Drawing.Size(60, 24);
            this.rdbOne.TabIndex = 19;
            this.rdbOne.TabStop = true;
            this.rdbOne.Text = "1 Mb";
            this.rdbOne.CheckedChanged += new System.EventHandler(this.setCacheSize);
            // 
            // grpbxMain
            // 
            this.grpbxMain.Controls.Add(this.pnlSizers);
            this.grpbxMain.Controls.Add(this.txtSize);
            this.grpbxMain.Controls.Add(this.rdbFree);
            this.grpbxMain.Controls.Add(this.rdbCD);
            this.grpbxMain.Controls.Add(this.rdbFDD);
            this.grpbxMain.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.grpbxMain.Location = new System.Drawing.Point(20, 90);
            this.grpbxMain.Name = "grpbxMain";
            this.grpbxMain.Size = new System.Drawing.Size(360, 80);
            this.grpbxMain.TabIndex = 22;
            this.grpbxMain.TabStop = false;
            this.grpbxMain.Text = "Size where to split";
            // 
            // pnlSizers
            // 
            this.pnlSizers.Controls.Add(this.rdbKiloBytes);
            this.pnlSizers.Controls.Add(this.rdbBytes);
            this.pnlSizers.Controls.Add(this.rdbMegaBytes);
            this.pnlSizers.Location = new System.Drawing.Point(144, 40);
            this.pnlSizers.Name = "pnlSizers";
            this.pnlSizers.Size = new System.Drawing.Size(208, 34);
            this.pnlSizers.TabIndex = 9;
            this.pnlSizers.Visible = false;
            // 
            // rdbKiloBytes
            // 
            this.rdbKiloBytes.Location = new System.Drawing.Point(52, 8);
            this.rdbKiloBytes.Name = "rdbKiloBytes";
            this.rdbKiloBytes.Size = new System.Drawing.Size(72, 24);
            this.rdbKiloBytes.TabIndex = 1;
            this.rdbKiloBytes.Text = "KiloBytes";
            this.rdbKiloBytes.CheckedChanged += new System.EventHandler(this.setMaxSize);
            // 
            // rdbBytes
            // 
            this.rdbBytes.Checked = true;
            this.rdbBytes.Location = new System.Drawing.Point(4, 8);
            this.rdbBytes.Name = "rdbBytes";
            this.rdbBytes.Size = new System.Drawing.Size(52, 24);
            this.rdbBytes.TabIndex = 0;
            this.rdbBytes.TabStop = true;
            this.rdbBytes.Text = "Bytes";
            this.rdbBytes.CheckedChanged += new System.EventHandler(this.setMaxSize);
            // 
            // rdbMegaBytes
            // 
            this.rdbMegaBytes.Location = new System.Drawing.Point(124, 8);
            this.rdbMegaBytes.Name = "rdbMegaBytes";
            this.rdbMegaBytes.Size = new System.Drawing.Size(80, 24);
            this.rdbMegaBytes.TabIndex = 2;
            this.rdbMegaBytes.Text = "MegaBytes";
            this.rdbMegaBytes.CheckedChanged += new System.EventHandler(this.setMaxSize);
            // 
            // txtSize
            // 
            this.txtSize.Location = new System.Drawing.Point(72, 48);
            this.txtSize.Name = "txtSize";
            this.txtSize.Size = new System.Drawing.Size(72, 20);
            this.txtSize.TabIndex = 8;
            this.toolTip1.SetToolTip(this.txtSize, "Note: Notepad++ file size limit is 320 Mb");
            this.txtSize.Visible = false;
            this.txtSize.TextChanged += new System.EventHandler(this.setMaxSize);
            // 
            // rdbFree
            // 
            this.rdbFree.Location = new System.Drawing.Point(8, 48);
            this.rdbFree.Name = "rdbFree";
            this.rdbFree.Size = new System.Drawing.Size(72, 16);
            this.rdbFree.TabIndex = 7;
            this.rdbFree.Text = "Free Size";
            this.rdbFree.CheckedChanged += new System.EventHandler(this.setMaxSize);
            // 
            // rdbCD
            // 
            this.rdbCD.Location = new System.Drawing.Point(8, 32);
            this.rdbCD.Name = "rdbCD";
            this.rdbCD.Size = new System.Drawing.Size(56, 16);
            this.rdbCD.TabIndex = 6;
            this.rdbCD.Text = "CD-R";
            this.rdbCD.CheckedChanged += new System.EventHandler(this.setMaxSize);
            // 
            // rdbFDD
            // 
            this.rdbFDD.Checked = true;
            this.rdbFDD.Location = new System.Drawing.Point(8, 16);
            this.rdbFDD.Name = "rdbFDD";
            this.rdbFDD.Size = new System.Drawing.Size(104, 16);
            this.rdbFDD.TabIndex = 5;
            this.rdbFDD.TabStop = true;
            this.rdbFDD.Text = "Floppy Disk 3½";
            this.rdbFDD.CheckedChanged += new System.EventHandler(this.setMaxSize);
            // 
            // grpCache
            // 
            this.grpCache.Controls.Add(this.rdbDefault);
            this.grpCache.Controls.Add(this.rdbSeven);
            this.grpCache.Controls.Add(this.rdbTwo);
            this.grpCache.Controls.Add(this.rdbOne);
            this.grpCache.Location = new System.Drawing.Point(404, 10);
            this.grpCache.Name = "grpCache";
            this.grpCache.Size = new System.Drawing.Size(104, 128);
            this.grpCache.TabIndex = 29;
            this.grpCache.TabStop = false;
            this.grpCache.Text = "UsedCache";
            // 
            // rdbDefault
            // 
            this.rdbDefault.Location = new System.Drawing.Point(7, 93);
            this.rdbDefault.Name = "rdbDefault";
            this.rdbDefault.Size = new System.Drawing.Size(91, 33);
            this.rdbDefault.TabIndex = 22;
            this.rdbDefault.Text = "Default Size (4Mb)";
            // 
            // rdbSeven
            // 
            this.rdbSeven.Location = new System.Drawing.Point(7, 71);
            this.rdbSeven.Name = "rdbSeven";
            this.rdbSeven.Size = new System.Drawing.Size(60, 24);
            this.rdbSeven.TabIndex = 21;
            this.rdbSeven.Text = "7 Mb";
            this.rdbSeven.CheckedChanged += new System.EventHandler(this.setCacheSize);
            // 
            // lblFileName
            // 
            this.lblFileName.Location = new System.Drawing.Point(20, 18);
            this.lblFileName.Name = "lblFileName";
            this.lblFileName.Size = new System.Drawing.Size(64, 23);
            this.lblFileName.TabIndex = 17;
            this.lblFileName.Text = "Source File";
            this.lblFileName.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // dlgOpen
            // 
            this.dlgOpen.Filter = "Tous les fichiers|*.*";
            this.dlgOpen.InitialDirectory = "%Documents%";
            this.dlgOpen.Title = "Selectionner le fichier à fractionner";
            // 
            // dlgSaveTo
            // 
            this.dlgSaveTo.Description = "Selectionner le Dossier de destination";
            // 
            // frmMain
            // 
            this.AcceptButton = this.btnGo;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(520, 261);
            this.Controls.Add(this.lblStatus);
            this.Controls.Add(this.btnGo);
            this.Controls.Add(this.txtFolderPath);
            this.Controls.Add(this.lblFolder);
            this.Controls.Add(this.btnSaveTo);
            this.Controls.Add(this.prgbProgress);
            this.Controls.Add(this.pnlActions);
            this.Controls.Add(this.btnBrowse);
            this.Controls.Add(this.txtFileName);
            this.Controls.Add(this.grpbxMain);
            this.Controls.Add(this.grpCache);
            this.Controls.Add(this.lblFileName);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.Name = "frmMain";
            this.Text = "The File Splitter";
            this.Load += new System.EventHandler(this.frmSplitter_Load);
            this.pnlActions.ResumeLayout(false);
            this.grpbxMain.ResumeLayout(false);
            this.grpbxMain.PerformLayout();
            this.pnlSizers.ResumeLayout(false);
            this.grpCache.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblStatus;
        private System.Windows.Forms.RadioButton rdbTwo;
        private System.Windows.Forms.Button btnGo;
        private System.Windows.Forms.TextBox txtFolderPath;
        private System.Windows.Forms.Label lblFolder;
        private System.Windows.Forms.Button btnSaveTo;
        private System.Windows.Forms.ProgressBar prgbProgress;
        private System.Windows.Forms.Panel pnlActions;
        private System.Windows.Forms.RadioButton rdbMerge;
        private System.Windows.Forms.RadioButton rdbSplit;
        private System.Windows.Forms.Button btnBrowse;
        private System.Windows.Forms.TextBox txtFileName;
        private System.Windows.Forms.RadioButton rdbOne;
        private System.Windows.Forms.GroupBox grpbxMain;
        private System.Windows.Forms.Panel pnlSizers;
        private System.Windows.Forms.RadioButton rdbKiloBytes;
        private System.Windows.Forms.RadioButton rdbBytes;
        private System.Windows.Forms.RadioButton rdbMegaBytes;
        private System.Windows.Forms.TextBox txtSize;
        private System.Windows.Forms.RadioButton rdbFree;
        private System.Windows.Forms.RadioButton rdbCD;
        private System.Windows.Forms.RadioButton rdbFDD;
        private System.Windows.Forms.GroupBox grpCache;
        private System.Windows.Forms.Label lblFileName;
        private System.Windows.Forms.OpenFileDialog dlgOpen;
        private System.Windows.Forms.FolderBrowserDialog dlgSaveTo;
        private System.Windows.Forms.RadioButton rdbSeven;
        private System.Windows.Forms.RadioButton rdbDefault;
        private System.Windows.Forms.ToolTip toolTip1;

    }
}

