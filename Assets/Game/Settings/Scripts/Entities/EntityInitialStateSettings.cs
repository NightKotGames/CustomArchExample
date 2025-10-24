
using UnityEngine;
using Game.State.Entity;

namespace Game.Settings.Entities
{
    [System.Serializable]

    public class EntityInitialStateSettings
    {
        [field: SerializeField] public EntityType TypeEntity { get; private set; }
        [field: SerializeField] public string ConfigId { get; private set; }
        [field: SerializeField] public int Level { get; private set; }
        [field: SerializeField] public Vector3 InitialPosition { get; private set; }
    }
}