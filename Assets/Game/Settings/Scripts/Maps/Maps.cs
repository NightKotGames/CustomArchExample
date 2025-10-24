
using UnityEngine;
using System.Collections.Generic;

namespace Game.Settings.Maps
{
    [CreateAssetMenu(fileName = "MapsSettings", menuName = "GameSettings/Maps/NewMapsSettings")]

    public class MapsSettings : ScriptableObject
    {
        public List<MapSettings> Maps;
    }
}
