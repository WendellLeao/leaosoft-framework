using Leaosoft.Services;
using UnityEngine;

namespace Leaosoft.Audio
{
    public interface IAudioService : IGameService
    {
        /// <summary>
        /// Plays a sound in some position in the world.
        /// </summary>
        /// <param name="audioId">the id of the audio you want to play.</param>
        /// <param name="position">the position in the world you want to play the sound.</param>
        public void PlaySound(string audioId, Vector3 position);
    }
}
