using Leaosoft.Services;
using Leaosoft.Events;
using Leaosoft.Save;
using UnityEngine;

namespace Leaosoft.Master
{
    public sealed class ServicesRegister : MonoBehaviour
    {
        [SerializeField] private GameService[] _servicesPrefab;
        
        public void Initialize()
        {
            RegisterEventService();

            RegisterSaveService();
            
            RegisterGeneralServices();
        }

        private void RegisterSaveService()
        {
            ISaveService newSaveService = new SaveService();

            newSaveService.RegisterService();
        }

        private void RegisterEventService()
        {
            IEventService newEventService = new EventService();

            newEventService.RegisterService();
        }
        
        private void RegisterGeneralServices()
        {
            foreach (GameService gameService in _servicesPrefab)
            {
                GameService serviceClone = Instantiate(gameService);
                
                IGameService service = serviceClone.GetComponent<IGameService>();
                
                service.RegisterService();
                service.Initialize();
            }
        }
    }
}
