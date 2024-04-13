using Core.Events;
using Prism.Events;
using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Content.ViewModels
{
    public class RightSideViewModel : BindableBase
    {
        private readonly IEventAggregator _eventAggregator;
        private string _selectedImage;

        public string SelectedImage
        {
            get { return _selectedImage; }
            set { SetProperty(ref _selectedImage, value); }
        }

        public RightSideViewModel(IEventAggregator eventAggregator)
        {
            SelectedImage = "../Images/noPic.jpg";
            _eventAggregator = eventAggregator;
            _eventAggregator.GetEvent<ImageSelectedEvent>().Subscribe(HandleImageSelected);
        }

        private void HandleImageSelected((string ImagePath, Visibility Visibility) eventData)
        {
            SelectedImage = eventData.ImagePath;
        }
    }
}
