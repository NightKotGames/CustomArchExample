
using UnityEngine;

namespace Game.Settings.Maps
{
    [CreateAssetMenu(fileName = "MapSettings", menuName = "GameSettings/Maps/NewMapSettings")]

    public class MapSettings : ScriptableObject
    {
        public int MapID;
        public MapInitialStateSettings InitialStateSettings;
    }
}
