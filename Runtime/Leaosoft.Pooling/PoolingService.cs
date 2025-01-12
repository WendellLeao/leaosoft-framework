using System.Collections.Generic;
using Leaosoft.Services;
using UnityEngine;

namespace Leaosoft.Pooling
{
	/// <summary>
	/// The PoolingService provides the abstraction <see cref="IPoolingService"/> to get or return objects from any pool.
	/// <seealso cref="ServiceLocator"/>
	/// </summary>
	[DisallowMultipleComponent]
	public sealed class PoolingService: GameService, IPoolingService
	{
		[SerializeField]
		private PoolDataCollection poolDataCollection;

		private readonly Dictionary<string, Queue<GameObject>> _poolDictionary = new();

		public GameObject GetObjectFromPool(string poolId)
		{
			if (_poolDictionary.TryGetValue(poolId, out Queue<GameObject> objectList))
			{
				if (objectList.Count == 0)
				{
					return CreateBackupObject(poolId);
				}

				GameObject objectFromPool = objectList.Dequeue();

				objectFromPool.SetActive(true);

				return objectFromPool;
			}

			Debug.LogError($"Couldn't get any object with id '{poolId}' from the pool!");
			return null;
		}

		public void ReturnObjectToPool(string poolId, GameObject objectToReturn)
		{
			if (_poolDictionary.TryGetValue(poolId, out Queue<GameObject> objectList))
			{
				objectList.Enqueue(objectToReturn);
			}

			objectToReturn.SetActive(false);
		}

		protected override void RegisterService()
		{
			ServiceLocator.RegisterService<IPoolingService>(this);
		}

		protected override void UnregisterService()
		{
			ServiceLocator.UnregisterService<IPoolingService>();
		}

		protected override void OnInitialize()
		{
			base.OnInitialize();

			PopulateDictionary();
		}

		private void PopulateDictionary()
		{
			foreach (PoolData pool in poolDataCollection.PoolData)
			{
				Queue<GameObject> objectPool = new Queue<GameObject>();

				for (int i = 0; i < pool.StartAmount; i++)
				{
					GameObject newGameObject = CreateNewObject(pool.ObjectToPool);

					objectPool.Enqueue(newGameObject);

					newGameObject.transform.SetParent(transform);
				}

				_poolDictionary.Add(pool.Id, objectPool);
			}
		}

		private GameObject CreateNewObject(GameObject prefab)
		{
			GameObject newGameObject = Instantiate(prefab);

			newGameObject.SetActive(false);

			return newGameObject;
		}

		private GameObject CreateBackupObject(string poolId)
		{
			foreach (PoolData pool in poolDataCollection.PoolData)
			{
				if (pool.Id == poolId)
				{
					GameObject newBackupObject = Instantiate(pool.ObjectToPool);

					return newBackupObject;
				}
			}

			return null;
		}
	}
}
