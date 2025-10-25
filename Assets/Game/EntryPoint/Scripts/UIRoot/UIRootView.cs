
using System;
using UnityEngine;

namespace Game.EntryPoint.UIRoot
{
    public class UIRootView : MonoBehaviour
    {
        [SerializeField] private Transform _uiSceneContainer;
        public Transform UiSceneContainer => _uiSceneContainer;
        [HideInInspector] public GameObject RootScreen { get; private set; }

        public void LoadingRootScreen(GameObject rootScreen) => RootScreen = rootScreen;
        public void SetRootScreen(bool enable) => RootScreen.SetActive(enable);        
    }
}