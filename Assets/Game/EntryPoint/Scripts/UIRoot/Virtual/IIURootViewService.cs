
using UnityEngine;

namespace Game.EntryPoint.UIRoot
{
    public interface IIURootViewService
    {
        void LoadingRootScreen(Sprite rootScreen);
        void SetActiveRootScreen(bool enable);
        void AttachSceneUI(GameObject ui);
        void ClearSceneUI();
    }
}