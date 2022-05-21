namespace Game.Save
{
    public interface ISaveService
    {
        LocalGameData LocalGameData { get; }
        void SaveData();
        void LoadData();
    }
}
