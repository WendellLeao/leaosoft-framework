using UnityEngine.Audio;
using UnityEngine.UI;
using UnityEngine;

namespace Game.GameSettings
{
	public sealed class AudioSettingsHandler : SettingsHandler
	{
		[Header("Default Game Settings")]
		[Range(0.0001f, 1f)]
		[SerializeField] private float _defaultGameThemeVolume;
	
		[Range(0.0001f, 1f)]
		[SerializeField] private float _defaultSoundEffectsVolume;
	
		[Header("Audio Mixer")]
		[SerializeField] private AudioMixer _gameThemeMixer;
		[SerializeField] private AudioMixer _soundEffectsMixer;
	
		[Header("Slider")]
		[SerializeField] private Slider _gameThemeVolumeSlider;
		[SerializeField] private Slider _soundEffectsVolumeSlider;
	
		protected override void AddEventListeners()
		{
			_gameThemeVolumeSlider.onValueChanged.AddListener(SetGameThemeVolume);
		
			_soundEffectsVolumeSlider.onValueChanged.AddListener(SetSoundEffectsVolume);
		
			_resetToDefaultButton.onClick.AddListener(delegate
			{
				ResetToDefault();
		
				// SoundManager.PlaySound(Sound.UI_BUTTON_CLICK);
			});
		}
	
		protected override void RemoveEventListeners()
		{
			_gameThemeVolumeSlider.onValueChanged.RemoveAllListeners();
		
			_resetToDefaultButton.onClick.RemoveAllListeners();
		}
	
		protected override void Initialize()
		{
			base.Initialize();
		
			SetStartSlidersValue();
		
			SetGameThemeVolume(_localGameData.GameThemeVolume);
		}
	
		protected override void ResetToDefault()
		{
			_localGameData.GameThemeVolume = _defaultGameThemeVolume;
			_localGameData.SoundEffectsVolume = _defaultSoundEffectsVolume;

			SetStartSlidersValue();
		}

		private void SaveGameThemeVolume(float audioMixerValue)
		{
			_localGameData.GameThemeVolume = audioMixerValue;

			SaveSystem.SaveSystem.SaveGameData();
		
			_localGameData = SaveSystem.SaveSystem.GetLocalGameData();
		}
	
		private void SaveSoundEffectsVolume(float audioMixerValue)
		{
			_localGameData.SoundEffectsVolume = audioMixerValue;
		
			SaveSystem.SaveSystem.SaveGameData();

			_localGameData = SaveSystem.SaveSystem.GetLocalGameData();
		}

		private void SetStartSlidersValue()
		{
			_gameThemeVolumeSlider.value = _localGameData.GameThemeVolume;

			_soundEffectsVolumeSlider.value = _localGameData.SoundEffectsVolume;
		}
	
		private void SetGameThemeVolume(float sliderValue)
		{
			float newAudioMixerValue = Mathf.Log10(sliderValue) * 20f;
		
			_gameThemeMixer.SetFloat("volume", newAudioMixerValue);

			SaveGameThemeVolume(sliderValue);
		}
	
		private void SetSoundEffectsVolume(float sliderValue)
		{
			float newAudioMixerValue = Mathf.Log10(sliderValue) * 20f;
		
			_soundEffectsMixer.SetFloat("volume", newAudioMixerValue);

			SaveSoundEffectsVolume(sliderValue);
		}
	}
}
