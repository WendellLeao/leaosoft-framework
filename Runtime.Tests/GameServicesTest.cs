using NUnit.Framework;
using Leaosoft.Audio;
using Leaosoft.Pooling;
using Leaosoft.Save;
using Leaosoft.Services;
using Leaosoft.Events;
using Leaosoft.Input;
using Leaosoft.UI;

namespace Leaosoft.Tests.Runtime
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
