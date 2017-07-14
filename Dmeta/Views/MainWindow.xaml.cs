using System;
using System.Diagnostics;
using System.IO;
using System.Windows;
using System.Windows.Forms;

namespace Dmeta.Views
{
    /// <summary>
    /// Logica di interazione per MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private static string filename = "meta.json";

        public MainWindow()
        {
            InitializeComponent();


        }

        private void BtnOpenMetaJson_Click(object sender, RoutedEventArgs e)
        {
            if (File.Exists(System.IO.Path.Combine(Directory.GetCurrentDirectory(), filename)))
            {
                if(Directory.Exists(@"C:\Program Files (x86)\Notepad++"))
                    Process.Start(@"C:\Program Files (x86)\Notepad++\notepad++.exe", System.IO.Path.Combine(Directory.GetCurrentDirectory(), filename));
                else
                    Process.Start("notepad.exe",System.IO.Path.Combine(Directory.GetCurrentDirectory(), filename));
            }
        }

        private void BtnBrowseFolder_Click(object sender, RoutedEventArgs e)
        {
            using (var dialog = new FolderBrowserDialog())
            {
                dialog.RootFolder = Environment.SpecialFolder.Desktop;
                if (dialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                    TextBoxPath.Text = dialog.SelectedPath;
                }
            }
        }

        private void BtnBrowseFile_Click(object sender, RoutedEventArgs e)
        {
            using(var dialog = new OpenFileDialog())
            {
                dialog.InitialDirectory = Environment.SpecialFolder.Desktop.ToString();
                Console.WriteLine("Root Folder: " + dialog.InitialDirectory);
                if (dialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                    TextBoxCsv.Text = dialog.FileName;
                }
            }
        }
    }    
}
