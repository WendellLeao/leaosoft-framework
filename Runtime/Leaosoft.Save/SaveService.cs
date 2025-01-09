using Leaosoft.Services;
using UnityEngine;
using System.IO;

namespace Leaosoft.Save
{
	/// <summary>
	/// The SaveService provides the abstraction <see cref="ISaveService"/> to serialize or deserialize the save game data.
	/// <seealso cref="ServiceLocator"/>
	/// </summary>
	public class SaveService : GameService, ISaveService
	{
		private const string FileName = "SaveData.json";

		private LocalGameData _localGameData = new();
		private bool _wasCreated;

		public LocalGameData LocalGameData => _localGameData;

		public void SaveData()
		{
			string json = JsonUtility.ToJson(_localGameData, true);

			File.WriteAllText(GetFilePath(), json);
		}

		public void LoadData()
		{
			if (!SaveFileExists() && !_wasCreated)
			{
				_wasCreated = true;

				Debug.Log("No save file found. Creating a new one...");

				SaveData();

				return;
			}

			string json = File.ReadAllText(GetFilePath());

			_localGameData = JsonUtility.FromJson<LocalGameData>(json);

			_wasCreated = false;
		}

		protected override void RegisterService()
		{
			ServiceLocator.RegisterService<ISaveService>(this);
		}

		protected override void UnregisterService()
		{
			ServiceLocator.UnregisterService<ISaveService>();
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
