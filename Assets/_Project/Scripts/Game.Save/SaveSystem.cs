using UnityEngine;
using System.IO;

namespace Game.SaveSystem
{
	public static class SaveSystem
	{
		private static string _fileName = "gameData.json";

		private static LocalGameData _localGameData = new LocalGameData();

		private static bool _wasCreated, _wasLoaded;

		public static void SaveGameData()
		{
			string json = JsonUtility.ToJson(_localGameData, true);

			File.WriteAllText(GetFilePath(), json);
		}

		public static void LoadGameData()
		{
			string path = GetFilePath();

			if(!SaveFileExists() && !_wasCreated)
			{
				_wasCreated = true;

				SaveGameData(); //Create a new save file

				Debug.Log("No save file found. Creating a new one...");
			}
			else
			{
				string json = File.ReadAllText(GetFilePath());

				_localGameData = JsonUtility.FromJson<LocalGameData>(json);
				
				_wasLoaded = true;

				_wasCreated = false;
			}
		}
	
		public static LocalGameData GetLocalGameData()
		{
			return _localGameData;
		}

		public static bool GetWasCreated()
		{
			return _wasCreated;
		}

		public static bool GetWasLoaded()
		{
			return _wasLoaded;
		}

		private static bool SaveFileExists()
		{
			return File.Exists(GetFilePath());
		}
	
		private static string GetFilePath()
		{
			return Path.Combine(Application.persistentDataPath, _fileName);
		}
	}
}
