using UnityEngine;

namespace Leaosoft.Audio
{
    public sealed class AudioDataCollection : ScriptableObject
    {
        [SerializeField]
        private AudioData[] audioData;

        public AudioData[] AudioData => audioData;
    }
}
