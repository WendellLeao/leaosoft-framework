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
	public sealed class PoolingService: MonoBehaviour, IPoolingService
	{
		private Dictionary<string, Queue<GameObject>> _poolDictionary;
		private PoolData[] _poolsData;

		public void RegisterService()
		{
			ServiceLocator.RegisterService<IPoolingService>(this);
		}

		public void UnregisterService()
		{
			ServiceLocator.DeregisterService<IPoolingService>();
		}

		public void Initialize(PoolData[] poolsData)
		{
			_poolsData = poolsData;
			
			_poolDictionary = new Dictionary<string, Queue<GameObject>>();
			
			PopulateDictionary();
		}
		
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

		private void PopulateDictionary()
		{
			foreach (PoolData pool in _poolsData)
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
		
		private GameObject CreateNewObject(GameObject gameObject)
		{
			GameObject newGameObject = Instantiate(gameObject);

			newGameObject.SetActive(false);

			return newGameObject;
		}

		private GameObject CreateBackupObject(string poolId)
		{
			GameObject newBackupObject = null;

			foreach (PoolData pool in _poolsData)
			{
				if (pool.Id == poolId)
				{
					newBackupObject = Instantiate(pool.ObjectToPool);

					return newBackupObject;
				}
			}

			return null;
		}
	}
}
