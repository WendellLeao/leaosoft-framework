using Leaosoft.Utilities;
using UnityEngine.Audio;
using UnityEngine;

namespace Leaosoft.Audio
{
    [CreateAssetMenu(menuName = PathUtility.AudioAssetsPath + "/AudioData", fileName = "NewAudioData")]
    public sealed class AudioData : ScriptableObject
    {
        [SerializeField]
        private string id;
        [SerializeField]
        [Space(height: 10)]
        private AudioClip[] audioClips;
        [SerializeField]
        [Space(height: 10)]
        private AudioMixerGroup audioMixerGroup;
        [SerializeField]
        [Space(height: 10)]
        [Range(0f, 1f)]
        private float volume = 0.5f;
        [SerializeField]
        [Range(0f, 3f)]
        private float pitch = 1f;
        [SerializeField]
        [Range(0f, 1f)]
        private float spatialBlend = 0.5f;
        [SerializeField]
        [Space(height: 10)]
        private bool loop;
        [SerializeField]
        private bool persistentSound;

        private bool _isPlaying;

        public string Id => id;
        public AudioClip[] AudioClips => audioClips;
        public AudioMixerGroup AudioMixerGroup => audioMixerGroup;
        public float Volume => volume;
        public float Pitch => pitch;
        public float SpatialBlend => spatialBlend;
        public bool Loop => loop;
        public bool PersistentSound => persistentSound;
        public bool IsPlaying => _isPlaying;

        public void SetIsPlaying(bool isPlaying)
        {
            _isPlaying = isPlaying;
        }
    }
}
