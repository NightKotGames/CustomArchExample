
using UnityEngine;
using Game.Settings.Maps;
using Game.Settings.Entities;

namespace Game.Settings
{
    [CreateAssetMenu(fileName = "GameSettings", menuName = "GameSettings/NewGameSettings")]

    public class GameSettings : ScriptableObject
    {
        public EntitiesSettings SettingsMobs;
        public MapsSettings SettingsMaps;
    }
}