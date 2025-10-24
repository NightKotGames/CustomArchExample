
using UnityEngine;

namespace Game.Settings
{
    [CreateAssetMenu(fileName = "ApplicationSettings", menuName = "ApplicationSettings/NewApplicationSettings")]

    public class ApplicationSettings : ScriptableObject
    {
        public int MisicVolume;
        public int SFXVolume;
        public string Difficulty;
    }
}