using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using System.IO;

namespace TheFileSplitter
{
    public partial class frmMain : Form
    {

        public const string appName = "The File Splitter";
        public const string appDate = "01/04/2020";
        public const string appVersion = "1.01";

#if DEBUG
        public static bool debug = true;
        public static bool release = false;
#else
        public static bool debug = false;
        public static bool release = true;
#endif

        private long SizeLimit;
        private int CacheSize;

        public frmMain()
        {
            InitializeComponent();
            if (debug) {
                rdbFree.Checked = true;
                txtSize.Text = "320";
                rdbMegaBytes.Checked = true;
                txtFileName.Text = "C:\\MyBigFile.dat";
                txtFolderPath.Text = "C:";
            }
        }
        
        private void frmSplitter_Load(object sender, EventArgs e)
        {
            string txt = Text + " - V" + appVersion + " (" + appDate + ")";
            if (debug) txt += " - Debug";
            this.Text = txt;
        }

        private void btnGo_Click(object sender, EventArgs e)
        {
            if (rdbSplit.Checked)
            {
                if ((txtFileName.Text.Length == 0)||(txtFolderPath.Text.Length == 0))
                    return;
                DisableControls(bdisable: true);
                
                prgbProgress.Value = 0;
                setCacheSize(sender, e);
                setMaxSize(sender, e);
                prgbProgress.Visible = true;
                dlgOpen.FileName = txtFileName.Text;
                dlgSaveTo.SelectedPath = txtFolderPath.Text;
                FileSplitter fs = new FileSplitter(dlgOpen.FileName, dlgSaveTo.SelectedPath, 
                    CacheSize, (long)SizeLimit); // 31/03/2020 int -> long
                fs.CopyDone += new EventHandler(fs_CopyDone);
                fs.partialCopyDone += new EventHandler(fs_partialCopyDone);
                fs.BeginSplit();
            }
            else
            {
                if (txtFolderPath.Text.Length == 0)
                    return;
                prgbProgress.Value = 0;
                setCacheSize(sender, e);
                prgbProgress.Visible = true;
                FileSplitter fs = new FileSplitter(dlgSaveTo.SelectedPath, CacheSize);
                fs.CopyDone += new EventHandler(fs_MergeDone);
                fs.partialCopyDone += new EventHandler(fs_partialMergeDone);
                fs.Error += new EventHandler(fs_Error);
                fs.BeginMerge();
            }
        }

        private void DisableControls(bool bdisable)
        {
            // 31/03/2020
            //foreach (Control ctrl in this.Controls)
            //    ctrl.Enabled = !bdisable;
            prgbProgress.Invoke(new MethodInvoker(delegate {
                foreach (Control ctrl in this.Controls) ctrl.Enabled = !bdisable;
            }));
        }
        
        private void fs_Error(object sender, EventArgs e)
        {
            MessageBox.Show(((FileSplitter)sender).ErrorMessage, 
                "Error !!!",MessageBoxButtons.OK,MessageBoxIcon.Stop);
            DisableControls(bdisable: false);
        }

        private void fs_partialMergeDone(object sender, EventArgs e)
        {
            prgbProgress.Value = ((FileSplitter)sender).Progress;
        }

        private void fs_MergeDone(object sender, EventArgs e)
        {
            DisableControls(bdisable: false);
            prgbProgress.Visible = false;
            MessageBox.Show(
                "Done Merging " + ((FileSplitter)sender).TotalDone); /* + 
                " bytes of data\n@The speed of " + 
                ((FileSplitter)sender).Speed.ToString() + 
                " Mb/s"); */
        }

        private void fs_partialCopyDone(object sender, EventArgs e)
        {
            // L'exception System.InvalidOperationException n'a pas été gérée
            // HResult=-2146233079
            // Message=Cross-thread operation not valid
            // Message=Opération inter-threads non valide : le contrôle 'prgbProgress'
            //  a fait l'objet d'un accès à partir d'un thread autre que celui sur lequel
            //  il a été créé.
            // prgbProgress.Value = ((FileSplitter)sender).Progress;
            // 31/03/2020 Solution: https://www.developpez.net/forums/d750162/dotnet/developpement-windows/windows-forms/operation-inter-threads-non-valide/
            prgbProgress.Invoke(new MethodInvoker(delegate {
                prgbProgress.Value = ((FileSplitter)sender).Progress; }));
        }

        private void fs_CopyDone(object sender, EventArgs e)
        {
            // 31/03/2020
            //prgbProgress.Visible = false;
            prgbProgress.Invoke(new MethodInvoker(delegate {
                prgbProgress.Visible = false; }));

            DisableControls(bdisable: false);
            MessageBox.Show(
                "Done Splitting " + 
                ((FileSplitter)sender).TotalDone); /* + 
                " bytes of data\n@The speed of " + 
                ((FileSplitter)sender).Speed.ToString() + 
                " Mb/s"); */
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            // ToDo
        }

        private void rdbSplit_CheckedChanged(object sender, EventArgs e)
        {
            lblFileName.Enabled = rdbSplit.Checked;
            txtFileName.Enabled = rdbSplit.Checked;
            btnBrowse.Enabled = rdbSplit.Checked;
            grpbxMain.Enabled = rdbSplit.Checked;
            btnGo.Text = "Split";
            if (rdbSplit.Checked) btnSaveTo.Text = "Save As";
            else btnSaveTo.Text = "Browse";
        }

        private void rdbMerge_CheckedChanged(object sender, EventArgs e)
        {
            lblFileName.Enabled = rdbSplit.Checked;
            txtFileName.Enabled = rdbSplit.Checked;
            btnBrowse.Enabled = rdbSplit.Checked;
            grpbxMain.Enabled = rdbSplit.Checked;
            grpCache.Enabled = rdbSplit.Checked;
            btnGo.Text = "Merge";
            if (rdbSplit.Checked)
                btnSaveTo.Text = "Save As";
            else
            {
                rdbDefault.Checked = true;
                btnSaveTo.Text = "Browse";
            }
        }

        private void rdbFree_CheckedChanged(object sender, EventArgs e)
        {
            txtSize.Visible = rdbFree.Checked;
            pnlSizers.Visible = rdbFree.Checked;
        }

        private void btnBrowse_Click(object sender, EventArgs e)
        {
            if (dlgOpen.ShowDialog() == DialogResult.OK)
            {
                txtFileName.Text = dlgOpen.FileName;
                this.Text = "The File Splitter - [" + FileName(dlgOpen.FileName) + "]";
                lblStatus.Text = "Size : " + GetSizes(dlgOpen.FileNames).ToString() + " Bytes";
                
                // 31/03/2020
                txtFolderPath.Text = System.IO.Path.GetDirectoryName(txtFileName.Text);
            }
        }

        private string FileName(string strString)
        {
            FileInfo fi = new FileInfo(strString);
            return fi.Name;
        }

        private long GetSizes(string[] strFileZ)
        {
            long intSizeToReturn = 0;
            foreach (string a in strFileZ)
            {
                FileStream tmpFS = new FileStream(a, FileMode.Open);
                intSizeToReturn += tmpFS.Length;
                tmpFS.Close();
            }
            return intSizeToReturn;
        }

        private void btnSaveTo_Click(object sender, EventArgs e)
        {
            if (dlgSaveTo.ShowDialog() == DialogResult.OK)
                txtFolderPath.Text = dlgSaveTo.SelectedPath;
        }

        private void txtFileName_TextChanged(object sender, EventArgs e)
        {
            if (txtFileName.Text.Length == 0)
            {
                this.Text = "The File Splitter";
                lblStatus.Text = string.Empty;
            }
        }

        private void setMaxSize(object sender, EventArgs e)
        {
            txtSize.Visible = rdbFree.Checked;
            pnlSizers.Visible = rdbFree.Checked;
            if (rdbCD.Checked)
                SizeLimit = 650 * 1024 * 1024;

            if (rdbFDD.Checked)
                SizeLimit = 1 * 1024 * 1024;

            if (rdbFree.Checked)
            {
                int nMulti = 1;
                if (rdbKiloBytes.Checked)
                    nMulti = 1024;

                if (rdbMegaBytes.Checked)
                    nMulti = 1024 * 1024;
                
                if (rdbBytes.Checked)
                    nMulti = 1;
                
                if (txtSize.Text.Length != 0)
                    // 31/03/2020 int -> long
                    SizeLimit = Int64.Parse(txtSize.Text) * nMulti;
                    //SizeLimit = Int32.Parse(txtSize.Text) * nMulti;
                else
                    SizeLimit = 1 * nMulti;
            }
        }

        private void setCacheSize(object sender, EventArgs e)
        {
            if (rdbOne.Checked)
                CacheSize = 1024 * 1024;
            if (rdbTwo.Checked)
                CacheSize = 2 * 1024 * 1024;
            if (rdbSeven.Checked)
                CacheSize = 7 * 1024 * 1024;
            if (rdbDefault.Checked)
                CacheSize = 4 * 1024 * 1024;
        }
    }
}