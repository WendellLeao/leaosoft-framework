using UnityEngine.UI;
using UnityEngine;
using TMPro;

namespace Game.GameSettings
{
	public sealed class GameSettingsHandler : SettingsHandler
	{
		[Header("Default Game Settings")]
		[Range(1, 10)]
		[SerializeField] private int _defaultGameDuration;
	
		[Range(0, 10)]
		[SerializeField] private int _defaultTimeToStart;
	
		[Range(1, 30)]
		[SerializeField] private int _defaultMaximumEnemies;
	
		[Range(0, 20)]
		[SerializeField] private int _defaultEnemiesSpawnRate;
	
		[Header("Sliders")]
		[SerializeField] private Slider _gameDurationSlider;
		[SerializeField] private Slider _timeToStartGameSlider;
		[SerializeField] private Slider _maximumEnemiesSlider;
		[SerializeField] private Slider _enemiesSpawnRateSlider;
	
		[Header("Sliders Label")]
		[SerializeField] private TMP_Text _gameDurationSliderLabel;
		[SerializeField] private TMP_Text _timeToStartGameSliderLabel;
		[SerializeField] private TMP_Text _maximumEnemiesSliderLabel;
		[SerializeField] private TMP_Text _enemiesSpawnRateSliderLabel;

		protected override void AddEventListeners()
		{
			_gameDurationSlider.onValueChanged.AddListener(SetGameDuration);
			_timeToStartGameSlider.onValueChanged.AddListener(SetTimeToStartGame);
			_maximumEnemiesSlider.onValueChanged.AddListener(SetMaximumEnemiesSlider);
			_enemiesSpawnRateSlider.onValueChanged.AddListener(SetEnemiesSpawnRate);
		
			_resetToDefaultButton.onClick.AddListener(delegate
			{
				ResetToDefault();
		
				// SoundManager.PlaySound(Sound.UI_BUTTON_CLICK);
			});
		}

		protected override void RemoveEventListeners()
		{
			_gameDurationSlider.onValueChanged.RemoveAllListeners();
			_timeToStartGameSlider.onValueChanged.RemoveAllListeners();
			_maximumEnemiesSlider.onValueChanged.RemoveAllListeners();
			_enemiesSpawnRateSlider.onValueChanged.RemoveAllListeners();
		
			_resetToDefaultButton.onClick.RemoveAllListeners();
		}

		protected override void Initialize()
		{
			base.Initialize();
		
			LoadSliderValues();
		}
	
		protected override void ResetToDefault()
		{
			int gameDurationInSeconds = _defaultGameDuration * 60;
		
			_localGameData.GameDuration = gameDurationInSeconds;

			_localGameData.TimeToStartGame = _defaultTimeToStart;
			_localGameData.MaximumEnemiesInScene = _defaultMaximumEnemies;
			_localGameData.EnemiesSpawnRate = _defaultEnemiesSpawnRate;

			LoadSliderValues();
		}

		private void LoadSliderValues()
		{
			LoadGameDuration();
		
			LoadTimeToStartGameSlider();
		
			LoadMaximumEnemiesSlider();
		
			LoadEnemiesSpawnRateSlider();
		}

		private void LoadGameDuration()
		{
			float gameDurationLoaded = _localGameData.GameDuration;
		
			float gameDurationInMinutes = gameDurationLoaded / 60f;
		
			_gameDurationSlider.value = gameDurationInMinutes;
		}
	
		private void LoadTimeToStartGameSlider()
		{
			float timeToStartLoaded = _localGameData.TimeToStartGame;

			_timeToStartGameSlider.value = timeToStartLoaded;
		}
	
		private void LoadMaximumEnemiesSlider()
		{
			int maximumEnemiesLoaded = _localGameData.MaximumEnemiesInScene;

			_maximumEnemiesSlider.value = maximumEnemiesLoaded;
		}
	
		private void LoadEnemiesSpawnRateSlider()
		{
			float enemiesSpawnRateLoaded = _localGameData.EnemiesSpawnRate;

			_enemiesSpawnRateSlider.value = enemiesSpawnRateLoaded;
		}

		private void SetGameDuration(float sliderValue)
		{
			_gameDurationSliderLabel.text = $"Game duration ({sliderValue} minutes)";
		
			float valueConvertedInSeconds = sliderValue * 60f;

			_localGameData.GameDuration = (int)valueConvertedInSeconds;
		
			SaveSystem.SaveSystem.SaveGameData();
		
			_localGameData = SaveSystem.SaveSystem.GetLocalGameData();
		}
	
		private void SetTimeToStartGame(float sliderValue)
		{
			_timeToStartGameSliderLabel.text = $"Time to start game ({sliderValue} seconds)";
		
			_localGameData.TimeToStartGame = (int)sliderValue;
		
			SaveSystem.SaveSystem.SaveGameData();
		
			_localGameData = SaveSystem.SaveSystem.GetLocalGameData();
		}

		private void SetMaximumEnemiesSlider(float sliderValue)
		{
			int sliderValueInteger = (int)sliderValue;
		
			_maximumEnemiesSliderLabel.text = $"Enemies in scene ({sliderValueInteger} enemies)";
		
			_localGameData.MaximumEnemiesInScene = sliderValueInteger;
		
			SaveSystem.SaveSystem.SaveGameData();
		
			_localGameData = SaveSystem.SaveSystem.GetLocalGameData();
		}

		private void SetEnemiesSpawnRate(float sliderValue)
		{
			_enemiesSpawnRateSliderLabel.text = $"Enemies spawn rate ({sliderValue} seconds)";
		
			_localGameData.EnemiesSpawnRate = sliderValue;
		
			SaveSystem.SaveSystem.SaveGameData();
		
			_localGameData = SaveSystem.SaveSystem.GetLocalGameData();
		}
	}
}
