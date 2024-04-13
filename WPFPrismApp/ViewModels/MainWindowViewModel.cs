using Prism.Commands;
using Prism.Mvvm;
using Prism.Services.Dialogs;

namespace WPFPrismApp.ViewModels
{
    public class MainWindowViewModel : BindableBase
    {
        private readonly IDialogService _dialogService;

        private string _title = "WPF teszt feladat";
        public string Title
        {
            get { return _title; }
            set { SetProperty(ref _title, value); }
        }

        public DelegateCommand ContactsClicked { get; private set; }


        public MainWindowViewModel(IDialogService dialogService)
        {
            _dialogService = dialogService;

            ContactsClicked = new DelegateCommand(ShowContactsDialog);
        }

        private void ShowContactsDialog()
        {
            _dialogService.ShowDialog("ContactsDialog");
        }
    }
}
