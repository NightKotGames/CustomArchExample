
namespace MVVM
{
    public interface IWindowBinder
    {
        void Bind(WindowViewModel viewModel);
        void Close();
    }
}