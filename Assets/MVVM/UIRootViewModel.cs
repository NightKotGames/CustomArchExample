
using UniRx;
using System;
using System.Linq;
using System.Collections.Generic;

namespace MVVM
{
    public class UIRootViewModel : IDisposable
    {
        public ReactiveProperty<WindowViewModel> OpenedScreen => _openedScreen;
        public ReactiveCollection<WindowViewModel> OpenedPopUps => _openedPopUps;

        private readonly ReactiveProperty<WindowViewModel> _openedScreen = new ReactiveProperty<WindowViewModel>();
        private readonly ReactiveCollection<WindowViewModel> _openedPopUps = new ReactiveCollection<WindowViewModel>();
        private readonly Dictionary<WindowViewModel, IDisposable> _popUpSubscriptions = new();

        public void OpenScreen(WindowViewModel screenViewModel)
        {
            _openedScreen.Value?.Dispose();
            _openedScreen.Value = screenViewModel;
        }

        public void OpenPopUp(WindowViewModel popUpViewModel)
        {
            if (_openedPopUps.Contains(popUpViewModel))
                return;

            var subscription = popUpViewModel.CloseRequested.Subscribe(ClosePopUp);
            _popUpSubscriptions.Add(popUpViewModel, subscription);

            _openedPopUps.Add(popUpViewModel);
        }

        public void ClosePopUp(WindowViewModel popUpViewModel)
        {
            if (_openedPopUps.Contains(popUpViewModel))
            {
                popUpViewModel.Dispose();
                _openedPopUps.Remove(popUpViewModel);

                _popUpSubscriptions[popUpViewModel]?.Dispose();
                _popUpSubscriptions.Remove(popUpViewModel);
            }
        }

        public void ClosePopUp(string popUpId)
        {
            var openedPopUpViewModel = _openedPopUps.FirstOrDefault(p => p.Id == popUpId);
            if (openedPopUpViewModel != null)
                ClosePopUp(openedPopUpViewModel);
        }

        public void CloseAllPopUp()
        {
            foreach (var openedPopUp in _openedPopUps.ToList())
                ClosePopUp(openedPopUp);
        }

        public void Dispose()
        {
            CloseAllPopUp();
            _openedScreen.Value?.Dispose();
            _openedScreen.Dispose();
            _openedPopUps.Dispose();
        }
    }
}
