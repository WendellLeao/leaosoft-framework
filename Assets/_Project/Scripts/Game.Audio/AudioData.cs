using UnityEngine;
using UnityEngine.Audio;

namespace Game.Audio
{
    [CreateAssetMenu(menuName = "AudioService/AudioData")]
    public sealed class AudioData : ScriptableObject
    {
        public Sound Sound;

        [Space(10)] public AudioClip[] AudioClips;

        [Space(10)] public AudioMixerGroup AudioMixerGroup;

        [Space(10)] [Range(0f, 1f)] public float Volume = 0.5f;

        [Range(0f, 3f)] public float Pitch = 1f;

        [Range(0f, 1f)] public float SpatialBlend = 0.5f;

        [Space(10)] public bool Loop;

        public bool PersistentSound;

        private bool _isPlaying;

        public bool IsPlaying
        {
            get => _isPlaying;
            set => _isPlaying = value;
        }
    }
}
