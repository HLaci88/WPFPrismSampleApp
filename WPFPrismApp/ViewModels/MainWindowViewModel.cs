using Core.Events;
using Microsoft.Win32;
using Prism.Commands;
using Prism.Events;
using Prism.Mvvm;
using Prism.Services.Dialogs;
using System.Windows;

namespace WPFPrismApp.ViewModels
{
    public class MainWindowViewModel : BindableBase
    {
        private readonly IDialogService _dialogService;
        private readonly IEventAggregator _eventAggregator;

        private string _title = "WPF teszt feladat";
        private string _filePath = string.Empty;

        public string Title
        {
            get { return _title; }
            set { SetProperty(ref _title, value); }
        }

        public string FilePath
        {
            get { return _filePath; }
            set { SetProperty(ref _filePath, value); }
        }

        public DelegateCommand ContactsClicked { get; private set; }
        public DelegateCommand OpenPictureClicked { get; private set; }

        public MainWindowViewModel(IDialogService dialogService, IEventAggregator eventAggregator)
        {
            _dialogService = dialogService;
            _eventAggregator = eventAggregator;

            ContactsClicked = new DelegateCommand(ShowContactsDialog);
            OpenPictureClicked = new DelegateCommand(OpenPictureDialog);
        }

        private void ShowContactsDialog()
        {
            _dialogService.ShowDialog("ContactsDialog");
        }

        private void OpenPictureDialog()
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.InitialDirectory = "c:\\";
            openFileDialog.Filter = "Image files (*.jpg, *.bmp, *.png)|*.jpg;*.bmp;*.png|All Files (*.*)|*.*";
            openFileDialog.RestoreDirectory = true;

            if (openFileDialog.ShowDialog() is true)
            {
                string selectedFileName = openFileDialog.FileName;
                FilePath = selectedFileName;

                _eventAggregator.GetEvent<ImageSelectedEvent>().Publish((FilePath, Visibility.Visible));
            }
        }
    }
}
