namespace Game.SaveSystem
{
    public sealed class LocalGameData
    {
        //Game Settings
        public int GameDuration;
    
        public int TimeToStartGame;
    
        public int MaximumEnemiesInScene;

        public float EnemiesSpawnRate;

        //Video Settings
        public int QualitySettingsIndex;

        public int CurrentDropdownResolutionIndex;

        public int DefaultResolutionWidht, DefaultResolutionHeight;
    
        public int CurrentResolutionWidth, CurrentResolutionHeight;

        public bool IsFullscreen;
    
        //Audio Settings
        public float GameThemeVolume;

        public float SoundEffectsVolume;

        //Highscore
        public int Highscore;
    }
}
