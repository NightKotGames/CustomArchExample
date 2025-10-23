
using UniRx;
using UnityEngine;

namespace MVVM
{
    public class UIRootBinder : MonoBehaviour
    {
        [SerializeField] private WindowsContainer _windowsContainer;
        private readonly CompositeDisposable _subscriptions = new();

        public void Bind(UIRootViewModel viewModel)
        {
            viewModel.OpenedScreen
                .Subscribe(newScreenViewModel => _windowsContainer.OpenScreen(newScreenViewModel))
                .AddTo(_subscriptions);

            foreach (var openedPopUp in viewModel.OpenedPopUps)
                _windowsContainer.OpenPopup(openedPopUp);

            viewModel.OpenedPopUps.ObserveAdd()
                .Subscribe(e => _windowsContainer.OpenPopup(e.Value))
                .AddTo(_subscriptions);

            viewModel.OpenedPopUps.ObserveRemove()
                .Subscribe(e => _windowsContainer.ClosePopup(e.Value))
                .AddTo(_subscriptions);

            OnBind(viewModel);
        }

        protected virtual void OnBind(UIRootViewModel viewModel) { }

        private void OnDestroy() => _subscriptions.Dispose();
    }
}
