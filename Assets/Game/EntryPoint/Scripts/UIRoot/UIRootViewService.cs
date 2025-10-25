
using UnityEngine;
using Game.Services;
using UnityEngine.UI;
using Game.EntryPoint.UIRoot;

[Service(SourceServiceType.Prefab, "UIRoot/UIRootView")]

public class UIRootViewService : MonoBehaviour, IIURootViewService, IService<IIURootViewService>
{
    [SerializeField] private Image _rootScreen;
    [SerializeField] private Transform _uiSceneContainer;

    public UIRootViewService(GameObject uiRootPrefab)
    {
        var root = Object.Instantiate(uiRootPrefab);
        SetActiveRootScreen(false);
    }

    public void LoadingRootScreen(Sprite rootSprite) => _rootScreen.sprite = rootSprite;
    public void SetActiveRootScreen(bool enable) => _rootScreen.enabled = enable;

    public void AttachSceneUI(GameObject ui)
    {
        ClearSceneUI();
        ui.transform.SetParent(_uiSceneContainer, false);
    }

    public void ClearSceneUI()
    {
        while (_uiSceneContainer.childCount > 0)
            Object.DestroyImmediate(_uiSceneContainer.GetChild(0).gameObject);
    }

}