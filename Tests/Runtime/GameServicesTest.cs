using NUnit.Framework;
using Game.Services;
using Game.Pooling;
using Game.Events;
using Game.Audio;
using Game.Input;
using Game.Save;
using Game.UI;

namespace Runtime.Tests.Game.Master
{
    public class GameServicesTest
    {
        [Test]
        public void GameServicesAreNotNull()
        {
            IEventService eventService = ServiceLocator.GetService<IEventService>();
        
            Assert.IsNotNull(eventService);

            IAudioService audioService = ServiceLocator.GetService<IAudioService>();
        
            Assert.IsNotNull(audioService);

            IInputService inputService = ServiceLocator.GetService<IInputService>();
        
            Assert.IsNotNull(inputService);

            IPoolingService poolingService = ServiceLocator.GetService<IPoolingService>();
        
            Assert.IsNotNull(poolingService);

            ISaveService saveService = ServiceLocator.GetService<ISaveService>();
        
            Assert.IsNotNull(saveService);

            IScreenService screenService = ServiceLocator.GetService<IScreenService>();
        
            Assert.IsNotNull(screenService);
        }
    }
}
