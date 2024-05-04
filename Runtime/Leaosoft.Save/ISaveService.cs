using Leaosoft.Services;

namespace Leaosoft.Save
{
    public interface ISaveService : IGameService
    {
        /// <summary>
        /// Returns the deserialize game data.
        /// </summary>
        public LocalGameData LocalGameData { get; }
        
        /// <summary>
        /// Serializes the game data.
        /// </summary>
        public void SaveData();
        
        /// <summary>
        /// Deserializes the game data.
        /// </summary>
        public void LoadData();
    }
}
