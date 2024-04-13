using Prism.Commands;
using Prism.Mvvm;
using Prism.Services.Dialogs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WPFPrismApp.Dialogs
{
    public class ContactsDialogViewModel : BindableBase, IDialogAware
    {
        public string Title => "Névjegy";
        public string Message => "Hello World!";

        public event Action<IDialogResult> RequestClose;

        public DelegateCommand CloseDialogCommand { get; }

        public ContactsDialogViewModel()
        {
            CloseDialogCommand = new DelegateCommand(CloseDialog);
        }

        public bool CanCloseDialog()
        {
            return true;
        }

        private void CloseDialog()
        {
            var buttonResult = ButtonResult.OK;

            RequestClose?.Invoke(new DialogResult(buttonResult));
        }

        public void OnDialogClosed()
        {

        }

        public void OnDialogOpened(IDialogParameters parameters)
        {

        }
    }
}
