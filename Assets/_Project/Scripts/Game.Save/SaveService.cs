using UnityEngine;
using System.IO;

namespace Game.Save
{
	public class SaveService : ISaveService
	{
		private const string FileName = "SaveData.json";

		private LocalGameData _localGameData = new LocalGameData();
		private bool _wasCreated;

		public LocalGameData LocalGameData => _localGameData;

		public void SaveData()
		{
			string json = JsonUtility.ToJson(_localGameData, true);

			File.WriteAllText(GetFilePath(), json);
		}

		public void LoadData()
		{
			if(!SaveFileExists() && !_wasCreated)
			{
				_wasCreated = true;

				SaveData(); //Create a new save file

				Debug.Log("No save file found. Creating a new one...");
			}
			else
			{
				string json = File.ReadAllText(GetFilePath());

				_localGameData = JsonUtility.FromJson<LocalGameData>(json);
				
				_wasCreated = false;
			}
		}

		private bool SaveFileExists()
		{
			return File.Exists(GetFilePath());
		}
	
		private string GetFilePath()
		{
			return Path.Combine(Application.persistentDataPath, FileName);
		}
	}
}
