
using UniRx;
using System;

namespace MVVM
{
    public abstract class WindowViewModel : IDisposable
    {
        public IObservable<WindowViewModel> CloseRequested => _closeRequested;
        public abstract string Id { get; }

        private readonly Subject<WindowViewModel> _closeRequested = new();

        public void RequestClose() => _closeRequested.OnNext(this);

        public virtual void Dispose()
        {
            _closeRequested.OnCompleted();
            _closeRequested.Dispose();
        }
    }
}