using Leaosoft.Services;
using Leaosoft.Pooling;
using UnityEngine;

namespace Leaosoft.Audio
{
    public interface IAudioService : IGameService
    {
        /// <summary>
        /// Populates all the audios data that will be used by the <see cref="AudioService"/>.
        /// </summary>
        /// <param name="audiosData">all the audios data.</param>
        void Initialize(AudioData[] audiosData, PoolData soundPlayerPool);
        
        /// <summary>
        /// Plays a sound in some position in the world.
        /// </summary>
        /// <param name="audioId">the id of the audio you want to play.</param>
        /// <param name="position">the position in the world you want to play the sound.</param>
        void PlaySound(string audioId, Vector3 position);
        
        /// <summary>
        /// Returns the SoundPlayer pool data
        /// </summary>
        PoolData SoundPlayerPool { get; }
    }
}
