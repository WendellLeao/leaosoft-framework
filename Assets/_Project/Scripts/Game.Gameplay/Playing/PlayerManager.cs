using UnityEngine;

namespace Game.Gameplay.Playing
{
    public sealed class PlayerManager : MonoBehaviour
    {
        [SerializeField] private Player _player;

        public void Initialize()
        {
            _player.Begin();
        }

        public void Dispose()
        {
            _player.Stop();
        }

        public void Tick(float deltaTime)
        {
            _player.Tick(deltaTime);
        }
    }
}
