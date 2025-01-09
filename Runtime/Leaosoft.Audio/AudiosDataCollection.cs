using UnityEngine;

namespace Leaosoft.Audio
{
    public sealed class AudiosDataCollection : ScriptableObject
    {
        [SerializeField]
        private AudioData[] audiosData;

        public AudioData[] AudiosData => audiosData;
    }
}
