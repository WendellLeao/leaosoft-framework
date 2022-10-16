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
		[SerializeField] private PoolData[] _poolsData;
		
		private Dictionary<PoolType, Queue<GameObject>> _poolDictionary;

		public void RegisterService()
		{
			ServiceLocator.RegisterService<IPoolingService>(this);
		}

		public void UnregisterService()
		{
			ServiceLocator.DeregisterService<IPoolingService>();
		}

		public void PopulatePoolsData(PoolData[] poolsData)
		{
			_poolsData = poolsData;
			
			_poolDictionary = new Dictionary<PoolType, Queue<GameObject>>();
			
			PopulateDictionary();
		}
		
		public GameObject GetObjectFromPool(PoolType poolType)
		{
			if (_poolDictionary.TryGetValue(poolType, out Queue<GameObject> objectList))
			{
				if (objectList.Count == 0)
				{
					return CreateBackupObject(poolType);
				}

				GameObject objectFromPool = objectList.Dequeue();

				objectFromPool.SetActive(true);

				return objectFromPool;
			}

			return null;
		}

		public void ReturnObjectToPool(PoolType poolType, GameObject objectToReturn)
		{
			if (_poolDictionary.TryGetValue(poolType, out Queue<GameObject> objectList))
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

				_poolDictionary.Add(pool.PoolType, objectPool);
			}
		}
		
		private GameObject CreateNewObject(GameObject gameObject)
		{
			GameObject newGameObject = Instantiate(gameObject);

			newGameObject.SetActive(false);

			return newGameObject;
		}

		private GameObject CreateBackupObject(PoolType poolType)
		{
			GameObject newBackupObject = null;

			foreach (PoolData pool in _poolsData)
			{
				if (pool.PoolType == poolType)
				{
					newBackupObject = Instantiate(pool.ObjectToPool);

					return newBackupObject;
				}
			}

			return null;
		}
	}
}
