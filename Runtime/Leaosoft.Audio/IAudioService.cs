using Leaosoft.Services;
using UnityEngine;

namespace Leaosoft.Audio
{
    public interface IAudioService : IGameService
    {
        /// <summary>
        /// Populates all the audios data that will be used by the <see cref="AudioService"/>.
        /// </summary>
        /// <param name="audiosData">all the audios data.</param>
        void PopulateAudiosData(AudioData[] audiosData);
        
        /// <summary>
        /// Plays a sound in some position in the world.
        /// </summary>
        /// <param name="sound">the sound you want to play.</param>
        /// <param name="position">the position in the world you want to play the sound.</param>
        void PlaySound(Sound sound, Vector3 position);
    }
}
