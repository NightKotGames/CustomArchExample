
using UnityEngine;

namespace Game.EntryPoint.UIRoot
{
    public interface IUIRootService
    {
        void LoadingRootScreen(GameObject rootScreen);
        void SetRootScreen(bool enable);
        void AttachSceneUI(GameObject ui);
        void ClearSceneUI();
    }
}