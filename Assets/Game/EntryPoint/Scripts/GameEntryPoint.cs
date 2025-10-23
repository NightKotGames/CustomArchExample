
using UnityEngine;
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
                Debug.LogWarning($"Game started from scene '{activeScene.name}'. ������������� �� Boot...");
                SceneManager.LoadScene("Boot");
            }
        }
    }
}
