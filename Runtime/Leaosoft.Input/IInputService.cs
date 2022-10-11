using Leaosoft.Services;
using System;

namespace Leaosoft.Input
{
    public interface IInputService : IGameService
    {
        /// <summary>
        /// Each frame this event will be invoked sending the player inputs.
        /// </summary>
        event Action<InputsData> OnReadInputs;
    }
}
