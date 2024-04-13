using Content.Views;
using Prism.Ioc;
using Prism.Modularity;
using Prism.Regions;

namespace Content
{
    public class ContentModule : IModule
    {
        private readonly IRegionManager _regionManager;

        public ContentModule(IRegionManager regionManager)
        {
            _regionManager = regionManager;
        }

        public void OnInitialized(IContainerProvider containerProvider)
        {
            IRegion leftSideRegion = _regionManager.Regions["left_side"];
            IRegion rightSideRegion = _regionManager.Regions["right_side"];

            var leftSideView = containerProvider.Resolve<LeftSideView>();
            var rightSideView = containerProvider.Resolve<RightSideView>();

            leftSideRegion.Add(leftSideView);
            rightSideRegion.Add(rightSideView);
        }

        public void RegisterTypes(IContainerRegistry containerRegistry)
        {

        }
    }
}