using FilePropertyViewer.Models;
using FilePropertyViewer.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Input;

namespace FilePropertyViewer.ViewModels
{
    public class MainViewModel : ViewModelBase
    {
        private readonly FileService _fileService;
        private string _directoryPath;
        private ObservableCollection<FileModel> _files;

        public MainViewModel()
        {
            _fileService = new FileService();
            Files = new ObservableCollection<FileModel>();
            LoadCommand = new RelayCommand(LoadFiles);

            // default derectory
            //DirectoryPath = @"";
        }

        public string DirectoryPath
        {
            get => _directoryPath;
            set
            {
                _directoryPath = value;
                OnPropertyChanged();
            }
        }

        public ObservableCollection<FileModel> Files
        {
            get => _files;
            set
            {
                _files = value;
                OnPropertyChanged();
            }
        }

        public ICommand LoadCommand { get; }

        private void LoadFiles()
        {
            var dialog = new FolderBrowserDialog();
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                DirectoryPath = dialog.SelectedPath;
                var files = _fileService.GetFiles(DirectoryPath);
                if (files.Count < 10)
                {
                    System.Windows.MessageBox.Show("Please select a directory that contains at least 10 files ！");
                    return;
                }
                Files = new ObservableCollection<FileModel>(files);
            }
        }
    }
}
