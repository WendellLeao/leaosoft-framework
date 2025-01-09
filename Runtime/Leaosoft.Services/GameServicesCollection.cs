using UnityEngine;

namespace Leaosoft.Services
{
    public sealed class GameServicesCollection : ScriptableObject
    {
        [SerializeField]
        private GameService[] gameServices;

        public GameService[] GameServices => gameServices;
    }
}
