using System;

namespace Game.Input
{
    public interface IInputService
    {
        event Action<PlayerInputsData> OnReadPlayerInputs;
    }
}
