using Leaosoft.Utilities;
using UnityEngine.Audio;
using UnityEngine;

namespace Leaosoft.Audio
{
    [CreateAssetMenu(menuName = PathUtility.AudioAssetsPath + "/AudioData", fileName = "NewAudioData")]
    public sealed class AudioData : ScriptableObject
    {
        [SerializeField]
        private string _id;
        [SerializeField]
        [Space(10)] 
        private AudioClip[] _audioClips;
        [SerializeField]
        [Space(10)] 
        private AudioMixerGroup _audioMixerGroup;
        [SerializeField]
        [Space(10)]
        [Range(0f, 1f)]
        private float _volume = 0.5f;
        [SerializeField]
        [Range(0f, 3f)] 
        private float _pitch = 1f;
        [SerializeField]
        [Range(0f, 1f)] 
        private float _spatialBlend = 0.5f;
        [SerializeField]
        [Space(10)]
        private bool _loop;
        [SerializeField]
        private bool _persistentSound;

        private bool _isPlaying;

        public string Id => _id;
        public AudioClip[] AudioClips => _audioClips;
        public AudioMixerGroup AudioMixerGroup => _audioMixerGroup;
        public float Volume => _volume;
        public float Pitch => _pitch;
        public float SpatialBlend => _spatialBlend;
        public bool Loop => _loop;
        public bool PersistentSound => _persistentSound;
        public bool IsPlaying => _isPlaying;

        public void SetIsPlaying(bool isPlaying)
        {
            _isPlaying = isPlaying;
        }
    }
}
