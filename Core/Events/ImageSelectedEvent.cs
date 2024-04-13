using Prism.Events;
using System.Windows;

namespace Core.Events
{
    public class ImageSelectedEvent : PubSubEvent<(string ImagePath, Visibility Visibility)>
    {
    }
}
