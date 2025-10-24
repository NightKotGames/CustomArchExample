
using UnityEngine;
using Game.State.Entity;
using System.Collections.Generic;

namespace Game.Settings.Entities
{
    public abstract class EntitySettings<T> : ScriptableObject where T : EntityLevelSettings
    {
        [field: SerializeField] public EntityType EntityType { get; private set; }
        [field: SerializeField] public string ConfigId { get; private set; }
        [field: SerializeField] public string TitleLid { get; private set; }
        [field: SerializeField] public string DescriptionLid { get; private set; }
        [field: SerializeField] public string PrefabPath { get; private set; }
        [field: SerializeField] public List<T> Levels { get; private set; }
    }

    [CreateAssetMenu(fileName = "EntitySettings", menuName = "GameSettings/Entities/NewEntitySettings")]

    public class EntitySettings : EntitySettings<EntityLevelSettings>
    {

    }
}
