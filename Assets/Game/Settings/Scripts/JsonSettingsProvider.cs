using Cysharp.Threading.Tasks;
using Game.Settings;

namespace Game.Boot
{
    public class JsonSettingsProvider : ISettingsProvider
    {
        public ApplicationSettings SettingsApplication => throw new System.NotImplementedException();

        public GameSettings SettingsGame => throw new System.NotImplementedException();

        public UniTask<GameSettings> LoadGameSettings()
        {
            throw new System.NotImplementedException();
        }
    }
}