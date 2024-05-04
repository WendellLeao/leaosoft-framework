using UnityEngine;

namespace Leaosoft.Audio
{
    public sealed class AudiosDataCollection : ScriptableObject
    {
        [SerializeField]
        private AudioData[] _audiosData;

        public AudioData[] AudiosData => _audiosData;
    }
}
