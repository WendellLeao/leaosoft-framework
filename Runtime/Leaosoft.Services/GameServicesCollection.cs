using UnityEngine;

namespace Leaosoft.Services
{
    public sealed class GameServicesCollection : ScriptableObject
    {
        [SerializeField]
        private GameService[] _gameServices;

        public GameService[] GameServices => _gameServices;
    }
}