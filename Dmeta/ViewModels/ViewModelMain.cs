using CsvHelper;
using Dmeta.Components;
using Dmeta.Helpers;
using Dmeta.Map;
using Dmeta.Models;
using Dmeta.Views;
using MaterialDesignThemes.Wpf;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Controls.Primitives;
using System.Windows.Media.Imaging;
using System.Xml;
using System.Xml.Serialization;

namespace Dmeta.ViewModels
{
    public class ViewModelMain : ViewModelBase
    {
        private readonly BackgroundWorker worker;
        
        private string _selectedPath;
        public string SelectedPath
        {
            get { return _selectedPath; }
            set { _selectedPath = value; RaisePropertyChanged("SelectedPath"); }
        }

        private string _selectedFileCsv;
        public string SelectedFileCsv
        {
            get { return _selectedFileCsv; }
            set { _selectedFileCsv = value; RaisePropertyChanged("SelectedFileCsv"); }
        }

        private int currentProgress;
        public int CurrentProgress
        {
            get { return this.currentProgress; }
            private set
            {
                if (this.currentProgress != value)
                {
                    this.currentProgress = value;
                    RaisePropertyChanged("CurrentProgress");
                }
            }
        }

        private string _statusMessage;
        public string StatusMessage
        {
            get { return _statusMessage; }
            set { _statusMessage = value; RaisePropertyChanged("StatusMessage"); }
        }

        private int _max;
        public int MaxProgress
        {
            get { return this._max; }
            private set
            {
                if (this._max != value)
                {
                    this._max = value;
                    RaisePropertyChanged("MaxProgress");
                }
            }
        }

        private RelayCommand _start;
        public RelayCommand StartCmd
        {
            get
            {
                if (_start == null)
                {
                    _start = new RelayCommand(param => this.Start(), param => this.CanStart);
                }
                return _start;
            }
        }

        private bool CanStart
        {
            get { 
                return (Directory.Exists(SelectedPath)) && (File.Exists(SelectedFileCsv)) && (!worker.IsBusy);
            }
        }

        private void Start()
        {
            if (!worker.IsBusy)
            {
                worker.RunWorkerAsync();
            }              
        }


        public ViewModelMain()
        {

            this.worker = new BackgroundWorker();
            this.worker.DoWork += this.DoWork;
            this.worker.ProgressChanged += this.ProgressChanged;
            this.worker.RunWorkerCompleted += this.DoWorkComplete;
            this.worker.WorkerReportsProgress = true;
            CurrentProgress = 0;
            MaxProgress = 100;
            StatusMessage = string.Empty;
        }

        // Background worker behaviour

        private void DoWork(object sender, DoWorkEventArgs e)
        {
            MaxProgress = CalcProgress("path_to_csv_file");
            //List<int> phases = Utility.DistributeInteger(MaxProgress, 2).ToList();
            string[] images = System.IO.Directory.GetFiles("output_dir", "*.tif", System.IO.SearchOption.AllDirectories);
            Processing proc = new Processing();
            
            StatusMessage = "Generazione file metadata.json ...";
            if (!proc.JsonGeneartion(worker, "path_to_csv_file", "output_dir", ref images))
            {
                Console.WriteLine("Generazione file metadata.json fallita");
                worker.CancelAsync();
            }

            StatusMessage = "Aggiunta metadati alle immagini...";
            proc.InjectMetadata("output_dir");

        }

        private void ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            this.CurrentProgress = e.ProgressPercentage;
        }

        private void DoWorkComplete(object sender, RunWorkerCompletedEventArgs e)
        {
            CurrentProgress = 0;
            var completeWin = new SummaryWindow();
            completeWin.ShowDialog();
            StatusMessage = string.Empty;
        }

        private int CalcProgress(string pathcsv)
        {
            return (File.Exists(pathcsv) && !string.IsNullOrEmpty(pathcsv)) ? File.ReadLines(pathcsv).Count() : 0;
        }
    }
}
