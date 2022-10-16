using Leaosoft.Services;
using Leaosoft.Audio;
using UnityEngine;

namespace Leaosoft.Master
{
    public sealed class AudiosManager : Manager
    {
        [SerializeField] private AudioData[] _audiosData;

        protected override void OnInitialize()
        {
            base.OnInitialize();

            IAudioService audioService = ServiceLocator.GetService<IAudioService>();

            audioService.PopulateAudiosData(_audiosData);
        }
    }
}
