
using UnityEngine;
using Game.Settings.Entities;

namespace Game.Settings.Mobs
{
    [CreateAssetMenu(fileName = "MobLevelSettings", menuName = "GameSettings/Entities/Mobs/NewMobLevelSettings")]

    public class MobLevelSettings : EntityLevelSettings
    {
        [field: SerializeField] public int BaseOption { get; private set; }
    }
}