using System.Collections.Generic;
using UnityEngine.UI;
using System.Linq;
using UnityEngine;
using TMPro;

namespace Game.GameSettings
{
	public sealed class VideoSettingsHandler : SettingsHandler
	{
		[Header("UI")]
		[SerializeField] private TMP_Dropdown _resolutionDropdown;
		[SerializeField] private TMP_Dropdown _graphicsDropdown;

		[SerializeField] private Toggle _isFullscreenToggle;

		private Resolution[] _resolutions;

		protected override void AddEventListeners()
		{
			_resolutionDropdown.onValueChanged.AddListener(SetResolution);
			_graphicsDropdown.onValueChanged.AddListener(SetQualityLevel);

			_isFullscreenToggle.onValueChanged.AddListener(SetFullscreen);
		
			_resetToDefaultButton.onClick.AddListener(delegate
			{
				ResetToDefault();
		
				// SoundManager.PlaySound(Sound.UI_BUTTON_CLICK);
			});
		}

		protected override void RemoveEventListeners()
		{
			_resolutionDropdown.onValueChanged.RemoveAllListeners();
			_graphicsDropdown.onValueChanged.RemoveAllListeners();
		
			_isFullscreenToggle.onValueChanged.RemoveAllListeners();
		
			_resetToDefaultButton.onClick.AddListener(delegate
			{
				ResetToDefault();
		
				// SoundManager.PlaySound(Sound.UI_BUTTON_CLICK);
			});
		}

		protected override void Initialize()
		{
			base.Initialize();
		
			AddResolutionsToDropdown();
		
			LoadGraphicsSettings();
		}

		protected override void ResetToDefault()
		{
			_localGameData.QualitySettingsIndex = 0;
		
			_localGameData.DefaultResolutionWidht = Screen.currentResolution.width;
			_localGameData.DefaultResolutionHeight = Screen.currentResolution.height;
		
			_localGameData.CurrentResolutionWidth = _localGameData.DefaultResolutionWidht;
			_localGameData.CurrentResolutionHeight = _localGameData.DefaultResolutionHeight;
		
			_localGameData.IsFullscreen = true;
		
			LoadGraphicsSettings();
		}
	
		private void AddResolutionsToDropdown()
		{
			_resolutions = Screen.resolutions.Select(resolution => 
				new Resolution { width = resolution.width, height = resolution.height }).Distinct().ToArray();

			_resolutionDropdown.ClearOptions();

			List<string> options = new List<string>();
		
			for(int i = 0; i < _resolutions.Length; i++)
			{
				string option = _resolutions[i].width + "x" + _resolutions[i].height;
			
				options.Add(option);

				if(_resolutions[i].width == _localGameData.CurrentResolutionWidth && 
				   _resolutions[i].height == _localGameData.CurrentResolutionHeight)
				{
					_localGameData.CurrentDropdownResolutionIndex = i;
				}
			}

			_resolutionDropdown.AddOptions(options);
		
			_resolutionDropdown.value = _localGameData.CurrentDropdownResolutionIndex;
		
			_resolutionDropdown.RefreshShownValue();
		}

		//Load Settings
		private void LoadGraphicsSettings()
		{
			LoadResolution();
	
			LoadFullscreenToggle();
		
			LoadQualityLevel();
		}
	
		private void LoadResolution()
		{
			Screen.SetResolution(
				_localGameData.CurrentResolutionWidth, 
				_localGameData.CurrentResolutionHeight, 
				_localGameData.IsFullscreen);
		
			_resolutionDropdown.value = _localGameData.CurrentDropdownResolutionIndex;
		}

		private void LoadFullscreenToggle()
		{
			_isFullscreenToggle.isOn = _localGameData.IsFullscreen;
		
			Screen.fullScreen = _localGameData.IsFullscreen;
		}

		private void LoadQualityLevel()
		{
			QualitySettings.SetQualityLevel(_localGameData.QualitySettingsIndex);

			_graphicsDropdown.value = _localGameData.QualitySettingsIndex;
		}

		//Setting new settings
		private void SetResolution(int resolutionIndex)
		{
			Resolution resolution = _resolutions[resolutionIndex];

			Screen.SetResolution(resolution.width, resolution.height, _localGameData.IsFullscreen);

			_localGameData.CurrentResolutionWidth = resolution.width;
			_localGameData.CurrentResolutionHeight = resolution.height;

			SaveSystem.SaveSystem.SaveGameData();

			_localGameData = SaveSystem.SaveSystem.GetLocalGameData();
		}
	
		private void SetQualityLevel(int qualityIndex)
		{
			_localGameData.QualitySettingsIndex = qualityIndex;
		
			QualitySettings.SetQualityLevel(qualityIndex);

			SaveSystem.SaveSystem.SaveGameData();
		
			_localGameData = SaveSystem.SaveSystem.GetLocalGameData();
		}

		private void SetFullscreen(bool isFullscreen)
		{
			_localGameData.IsFullscreen = isFullscreen;
		
			Screen.fullScreen = isFullscreen;

			SaveSystem.SaveSystem.SaveGameData();
		
			_localGameData = SaveSystem.SaveSystem.GetLocalGameData();
		}
	}
}
