
using UnityEngine;
using Game.Settings.Entities;

namespace Game.Settings.Mobs
{
    [CreateAssetMenu(fileName = "NewMobSettings", menuName = "GameSettings/Mobs/NewMobSettings")]

    public class MobSettings : EntitySettings<MobLevelSettings>
    {
    }
}