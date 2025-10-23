
using Cysharp.Threading.Tasks;

namespace Game.Settings
{
    public interface ISettingsProvider
    {
        ApplicationSettings SettingsApplication { get; }
        GameSettings SettingsGame { get; }
        UniTask<GameSettings> LoadGameSettings();
    }
}