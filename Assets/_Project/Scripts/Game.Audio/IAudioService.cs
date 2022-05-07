using UnityEngine;

namespace Game.Audio
{
    public interface IAudioService
    {
        void PlaySound(Sound sound, Vector3 position);
    }
}
