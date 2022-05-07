using Game.Gameplay.Playing;
using UnityEngine;

namespace Game.Gameplay
{
    public sealed class GameplaySystem : MonoBehaviour
    {
        [SerializeField] private PlayerManager _playerManager;

        private void Awake()
        {
            _playerManager.Initialize();
        }

        private void OnDestroy()
        {
            _playerManager.Dispose();
        }

        private void Update()
        {
            _playerManager.Tick(Time.deltaTime);
        }
    }
}
