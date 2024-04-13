using Core.Events;
using Prism.Events;
using Prism.Mvvm;
using System;
using System.Windows;

namespace Content.ViewModels
{
    public class LeftSideViewModel : BindableBase
    {
        private readonly IEventAggregator _eventAggregator;

        private string _timeStampAtStart;
        private Visibility _smileyVisibility;

        public string TimeStampAtStart
        {
            get { return _timeStampAtStart; }
            set { SetProperty(ref _timeStampAtStart, value); }
        }
        public Visibility SmileyVisibility
        {
            get { return _smileyVisibility; }
            set { SetProperty(ref _smileyVisibility, value); }
        }

        public LeftSideViewModel(IEventAggregator eventAggregator)
        {
            _eventAggregator = eventAggregator;
            _eventAggregator.GetEvent<ImageSelectedEvent>().Subscribe(HandleImageSelected);

            TimeStampAtStart = DateTime.Now.ToString();
            SmileyVisibility = Visibility.Hidden;
        }

        private void HandleImageSelected((string ImagePath, Visibility Visibility) eventData)
        {
            SmileyVisibility = eventData.Visibility;
        }
    }
}
