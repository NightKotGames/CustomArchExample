
using System;
using UnityEngine;
using System.Collections.Generic;
using Game.Settings.Entities;

namespace Game.Settings.Maps
{
    [Serializable]

    public class MapInitialStateSettings
    {
        /// <summary> Сущности и Свойства Игровой Карты </summary>
        [SerializeField] public List<EntityInitialStateSettings> Entities;


        /// etc...



    }
}