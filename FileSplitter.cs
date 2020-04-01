using System;
using System.IO;
using System.Threading;

namespace TheFileSplitter
{
    class FileSplitter
    {
        #region Private Propreties
        private int totalProgress = 0;
        private int nCache = 0;
        private long lWritten = 0;
        private long lFileSize = 1;
        private long lSizeLimit = 0;
        private DateTime dtStart;
        private TimeSpan tsAll;
        private string sFileName;
        private string sSourceFolder, sDestFolder;
        private string sError = string.Empty;
        #endregion


        #region Constructors
        /// <summary>
        /// A class that can cut and merge files more than 5 Go - Splitter 
        /// </summary>
        /// <param name="FileName">The File to split</param>
        /// <param name="DestinationFolder">Output Folder</param>
        /// <param name="CacheSize">Cache Size to use to process the File</param>
        /// <param name="SizeLimit">The size where to split the file</param>
        public FileSplitter(string FileName, string DestinationFolder, int CacheSize,
            long SizeLimit) // 31/03/2020 int -> long
        {
            sFileName = FileName;
            sDestFolder = DestinationFolder;
            nCache = CacheSize;
            lSizeLimit = SizeLimit;

            FileStream FSIn = new FileStream(sFileName, FileMode.Open);
            lFileSize = FSIn.Length;
            if (lFileSize < lSizeLimit)
                lSizeLimit = (int)lFileSize;
            FSIn.Close();
        }
      
        /// <summary>
        /// A class that can cut and merge files more than 5 Go - Splitter
        /// </summary>
        /// <param name="FileName">The File to split</param>
        /// <param name="DestinationFolder">Output Folder</param>
        /// <param name="CacheSize">Cache Size to use to process the File</param>
        public FileSplitter(string FileName, string DestinationFolder, int SizeLimit)
        {
            sFileName = FileName;
            sDestFolder = DestinationFolder;
            lSizeLimit = SizeLimit;
            nCache = 4 * 1024 * 1024;

            FileStream FSIn = new FileStream(sFileName, FileMode.Open);
            lFileSize = FSIn.Length;
            if (lFileSize < lSizeLimit)
                lSizeLimit = (int)lFileSize;
            FSIn.Close();
        }

        /// <summary>
        /// A class that can cut and merge files more than 5 Go - Merger
        /// </summary>
        /// <param name="SourceFolder">Source Folder</param>
        /// <param name="CacheSize">Cache Size to use to process the File</param>
        public FileSplitter(string SourceFolder, int CacheSize)
        {
            sSourceFolder = SourceFolder;
            nCache = CacheSize;
        }

        /// <summary>
        /// A class that can cut and merge files more than 5 Go - Merger (Default values are used)
        /// </summary>
        /// <param name="SourceFolder">Splitted file Source Folder</param>
        public FileSplitter(string SourceFolder)
        {
            sSourceFolder = SourceFolder;
            nCache = 4 * 1024 * 1024;
        }
        #endregion


        #region EventHandlers
        protected virtual void OnCopydone(EventArgs e)
        {
            tsAll = DateTime.Now.Subtract(dtStart);
            if (CopyDone != null)
                CopyDone(this, e);
        }

        protected virtual void OnPartialCopydone(EventArgs e)
        {
            if (partialCopyDone != null)
                partialCopyDone(this, e);
        }

        protected virtual void OnError(EventArgs e)
        {
            if (Error!= null)
                Error(this, e);
        }
        #endregion

      
        #region Public Properties
        public event EventHandler partialCopyDone;
        public event EventHandler CopyDone;
        public event EventHandler Error;

        /// <summary>
        /// last error message
        /// </summary>
        public string ErrorMessage
        {
            get
            {
                return sError;
            }
        }

        /// <summary>
        /// progression / 100
        /// </summary>
        public int Progress
        {
            get 
            {
                return totalProgress;
            }
        }

        /// <summary>
        /// Bytes written / 100
        /// </summary>
        public long TotalDone
        {
            get
            {
                return lWritten;
            }
        }

        /// <summary>
        /// Speed in Mb/s used during the processing
        /// </summary>
        public float Speed
        {
            get
            {
                return (float)(lFileSize / 1024 / 1024 / tsAll.TotalSeconds);
            }

        }

        #endregion


        #region Public Methods
        /// <summary>
        /// Launch the splitting thread
        /// </summary>
        public void BeginSplit()
        {
            Thread td = new Thread(new ThreadStart(Split));
            td.Priority = ThreadPriority.AboveNormal;
            td.Name = "Splitting";
            dtStart = DateTime.Now;
            td.Start();

        }

        /// <summary>
        /// Launch the merging thread
        /// </summary>
        public void BeginMerge()
        {
            Thread td = new Thread(new ThreadStart(Merge));
            td.Priority = ThreadPriority.AboveNormal;
            td.Name = "Splitting";
            dtStart = DateTime.Now;
            td.Start();
        }
        #endregion


        #region Workers
        private void Split()
        {
            if (nCache > lSizeLimit)
                nCache = (int)lSizeLimit;

            byte[] cBuffer = new byte[nCache];
            int nCounter = 0;
            
            FileStream fsIn = new FileStream(sFileName, FileMode.Open, FileAccess.Read);
            BinaryReader br = new BinaryReader(fsIn);

            FileStream fsOut;
            BinaryWriter bw; 
            //FileInfo fi = new FileInfo(sFileName);
            string sOutDir = sDestFolder + "\\"; // +fi.Name; // 31/03/2020 Not +fi.Name

            if (!System.IO.Directory.Exists(sDestFolder)) // 31/03/2020 if !Exists
                Directory.CreateDirectory(sOutDir);

            do
            {
                fsOut = new FileStream(sOutDir + "\\" + nCounter.ToString() + ".part", FileMode.Create);
                do
                {
                    if ((fsIn.Length - fsIn.Position) < cBuffer.Length)
                        cBuffer = new byte[fsIn.Length - fsIn.Position];
                    br.Read(cBuffer, 0, cBuffer.Length);
                    bw = new BinaryWriter(fsOut);
                    bw.Write(cBuffer);
                } while ((fsOut.Position < lSizeLimit) && (fsIn.Position < fsIn.Length));
                bw.BaseStream.Close();
                lWritten = fsIn.Position;
                nCounter++;
                totalProgress = (int)((float)lWritten * 100 / (float)lFileSize);
                OnPartialCopydone(EventArgs.Empty);
            } while ((fsIn.Position < fsIn.Length));
            br.BaseStream.Close();
            OnCopydone(EventArgs.Empty);
        }

        private void Merge()
        {
            DirectoryInfo df = new DirectoryInfo(sSourceFolder);
            FileInfo[] fiFileZ = df.GetFiles("*.part");

            lFileSize = 0;
            foreach (FileInfo fi in fiFileZ)
                lFileSize += fi.Length;
            FileStream FSIn;
            FileStream FSout = new FileStream(df.FullName + "\\" + df.Name, FileMode.Create);
            BinaryWriter wFSOut = new BinaryWriter(FSout);

            if (fiFileZ.Length == 0)
            {
                sError = "No Files Found!!!";
                OnError(EventArgs.Empty);
            }
            
            for (int i = 0; i < fiFileZ.Length; i++)
            {
                FSIn = new FileStream( df.FullName + "\\" + i.ToString()+".part", FileMode.Open,FileAccess.Read);
                BinaryReader rFSIn = new BinaryReader(FSIn);
                if (nCache > FSIn.Length - FSIn.Position)
                    nCache = (int)FSIn.Length - (int)FSIn.Position;
                byte[] buffer = new byte[nCache];
                while (FSIn.Position < FSIn.Length)
                {
                    rFSIn.Read(buffer, 0, nCache);
                    wFSOut.Write(buffer);
                    totalProgress = (int)((float)i / (float)fiFileZ.Length * 100);
                }
                OnPartialCopydone(EventArgs.Empty);
                rFSIn.Close();
                FSIn.Close();
            }
            wFSOut.Close();
            FSout.Close();
            lWritten = lFileSize;
            OnCopydone(EventArgs.Empty);
        }
        #endregion
    }

}
