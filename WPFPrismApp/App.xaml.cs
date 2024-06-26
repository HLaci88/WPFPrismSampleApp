﻿using Content;
using Prism.Ioc;
using Prism.Modularity;
using System.Windows;
using WPFPrismApp.Dialogs;
using WPFPrismApp.Views;

namespace WPFPrismApp
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App
    {
        protected override Window CreateShell()
        {
            return Container.Resolve<MainWindow>();
        }

        protected override void RegisterTypes(IContainerRegistry containerRegistry)
        {
            containerRegistry.RegisterDialog<ContactsDialog, ContactsDialogViewModel>();
        }

        protected override void ConfigureModuleCatalog(IModuleCatalog moduleCatalog)
        {
            moduleCatalog.AddModule<ContentModule>();
        }
    }
}
