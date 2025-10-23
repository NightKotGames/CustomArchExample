
using Cysharp.Threading.Tasks;

namespace Game.LoaderScene
{
    public interface ISceneLoader
    {
        UniTask LoadSceneAsync(string sceneName);
    }
}