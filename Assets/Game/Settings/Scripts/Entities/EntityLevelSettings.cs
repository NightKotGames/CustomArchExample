
using UnityEngine;

namespace Game.Settings.Entities
{
    [CreateAssetMenu(fileName = "EntityLevelSettings", menuName = "GameSettings/Entities/NewEntityLevelSettings")]

    public class EntityLevelSettings : ScriptableObject
    {
        [field: SerializeField] public int Level { get; private set; }
        [field: SerializeField] public string PrefabSkinPath { get; private set; }
    }
}