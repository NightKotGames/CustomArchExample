
using UnityEngine;
using Game.LoaderScene;
using Cysharp.Threading.Tasks;
using UnityEngine.SceneManagement;

namespace Game.EntryPoint
{
    public class GameEntryPoint
    {
        [RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.BeforeSceneLoad)]
        public static void AutoStartGame()
        {
            Application.targetFrameRate = 60;
            Application.runInBackground = true;

            Debug.Log("=== GameEntryPoint started ===");

            // ���������, ��� �������� ����� � Boot
            var activeScene = SceneManager.GetActiveScene();
            if (activeScene.name != Scenes.BOOT)
            {
                Debug.LogWarning($"Game started from scene '{activeScene.name}'. Switching to Boot...");
                var loader = new SceneLoader(); // ��� �������� ����� Zenject
                loader.LoadSceneAsync(Scenes.BOOT).Forget();
            }
        }
    }
}
