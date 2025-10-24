
using Zenject;
using UnityEngine;

namespace Game.EntryPoint
{
    public class UIRootView : MonoInstaller
    {
        [SerializeField] private GameObject _loadingScreen;
        [SerializeField] private Transform _uiSceneContainer;

        private void Awake() => HideLoadingScreen();
        public void ShowLoadingScreen() => _loadingScreen.SetActive(true);
        public void HideLoadingScreen() => _loadingScreen.SetActive(false);

        public void AttachSceneUI(GameObject sceneUI)
        {
            ClearSceneUI();
            sceneUI.transform.SetParent(_uiSceneContainer, false);
        }

        private void ClearSceneUI()
        {
            while (_uiSceneContainer.childCount > 0)
                DestroyImmediate(_uiSceneContainer.GetChild(0).gameObject);
        }
    }
}
