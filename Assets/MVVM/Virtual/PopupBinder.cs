
using UniRx;
using UnityEngine;
using UnityEngine.UI;

namespace MVVM
{
    public class PopupBinder<T> : WindowBinder<T> where T : WindowViewModel
    {
        [SerializeField] private Button _closeButton;
        [SerializeField] private Button _closeAltButton;

        private readonly CompositeDisposable _disposables = new();

        protected virtual void Start()
        {
            _closeButton?
                .OnClickAsObservable()
                .Subscribe(_ => ViewModel.RequestClose())
                .AddTo(_disposables);

            _closeAltButton?
                .OnClickAsObservable()
                .Subscribe(_ => ViewModel.RequestClose())
                .AddTo(_disposables);
        }

        protected virtual void OnDestroy()
        {
            _disposables.Dispose();
        }
    }
}
