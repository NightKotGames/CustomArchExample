
using UnityEngine;
using Game.Services;

namespace Game.EntryPoint.UIRoot
{
    public class UIRootService : IUIRootService, IService<IUIRootService>
    {
        private readonly UIRootView _view;

        public UIRootService(UIRootView view) => _view = view;

        public void LoadingRootScreen(GameObject rootScreen) => _view.LoadingRootScreen(rootScreen);
        public void SetRootScreen(bool enable) => _view.SetRootScreen(enable);
       
        public void AttachSceneUI(GameObject ui)
        {
            ClearSceneUI();
            _view.UiSceneContainer.transform.SetParent(ui.transform, false);
        }

        public void ClearSceneUI()
        {
            var container = _view.UiSceneContainer;
            while (container.childCount > 0)
                Object.DestroyImmediate(container.GetChild(0).gameObject);
        }
    }
}