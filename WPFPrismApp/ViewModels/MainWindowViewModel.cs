﻿using Prism.Mvvm;

namespace WPFPrismApp.ViewModels
{
    public class MainWindowViewModel : BindableBase
    {
        private string _title = "WPF teszt feladat";
        public string Title
        {
            get { return _title; }
            set { SetProperty(ref _title, value); }
        }

        public MainWindowViewModel()
        {

        }
    }
}
