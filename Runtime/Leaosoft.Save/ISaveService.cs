using Leaosoft.Master;

namespace Leaosoft.Save
{
    public interface ISaveService : IGameService
    {
        /// <summary>
        /// Returns the deserialize game data.
        /// </summary>
        LocalGameData LocalGameData { get; }
        
        /// <summary>
        /// Serializes the game data.
        /// </summary>
        void SaveData();
        
        /// <summary>
        /// Deserializes the game data.
        /// </summary>
        void LoadData();
    }
}
