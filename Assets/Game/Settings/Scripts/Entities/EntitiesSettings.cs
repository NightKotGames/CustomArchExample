
using UnityEngine;
using Game.Settings.Mobs;
using System.Collections.Generic;

namespace Game.Settings.Entities
{
    [CreateAssetMenu(fileName = "EntitiesSettings", menuName = "GameSettings/Entities/NewEntitiesSettings")]

    public class EntitiesSettings : ScriptableObject
    {
        [field: SerializeField] public List<MobSettings> AllMobs { get; private set; } = new();
    }
}