﻿
using UnityEngine;
using System.Collections.Generic;

namespace MVVM
{
    public class WindowsContainer : MonoBehaviour
    {
        [SerializeField] private Transform _screensContainer;
        [SerializeField] private Transform _popupsContainer;

        private readonly Dictionary<WindowViewModel, IWindowBinder> _openedPopupBinders = new();
        private IWindowBinder _openedScreenBinder;

        public void OpenPopup(WindowViewModel viewModel)
        {
            var prefabPath = GetPrefabPath(viewModel);
            var prefab = Resources.Load<GameObject>(prefabPath);
            var createdPopup = Instantiate(prefab, _popupsContainer);
            var binder = createdPopup.GetComponent<IWindowBinder>();

            binder.Bind(viewModel);
            _openedPopupBinders.Add(viewModel, binder);
        }

        public void ClosePopup(WindowViewModel popupViewModel)
        {
            if (_openedPopupBinders.TryGetValue(popupViewModel, out var binder))
            {
                binder?.Close();
                _openedPopupBinders.Remove(popupViewModel);
            }
        }

        public void OpenScreen(WindowViewModel viewModel)
        {
            if (viewModel == null)
                return;

            _openedScreenBinder?.Close();

            var prefabPath = GetPrefabPath(viewModel);
            var prefab = Resources.Load<GameObject>(prefabPath);
            var createdScreen = Instantiate(prefab, _screensContainer);
            var binder = createdScreen.GetComponent<IWindowBinder>();

            binder.Bind(viewModel);
            _openedScreenBinder = binder;
        }

        private static string GetPrefabPath(WindowViewModel viewModel) => $"Prefabs/UI/{viewModel.Id}";
    }
}
