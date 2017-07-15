using Dmeta.Helpers;
using Dmeta.Models;
using Dmeta.Views;
using MaterialDesignThemes.Wpf;
using Newtonsoft.Json;
using System;
using System.ComponentModel;
using System.IO;
using System.Windows.Controls.Primitives;

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

            Metadata m = LoadBaseInfo(); // Carica le informazioni di base

            
        }
       
        private Metadata LoadBaseInfo()
        {
            return Metadata.LoadModel(Path.Combine(System.AppDomain.CurrentDomain.BaseDirectory, "meta.json"));
        }

        private void DoWork(object sender, DoWorkEventArgs e)
        {
            // do time-consuming work here, calling ReportProgress as and when you can
            int x = 25 - 1;
            MaxProgress = x;

            for (int i=0; i < x; i++)
            {
                System.Threading.Thread.Sleep(200);
                worker.ReportProgress(i);
            }
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
        }

    }
}
