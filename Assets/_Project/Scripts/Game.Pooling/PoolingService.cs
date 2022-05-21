using System.Collections.Generic;
using Game.Services;
using UnityEngine;

namespace Game.Pooling
{
	public sealed class PoolingService: MonoBehaviour, IPoolingService
	{
		private const string PoolsDataPath = "GameServices/PoolingService/PoolsData";
		
		private Dictionary<PoolType, Queue<GameObject>> _poolDictionary;
		private PoolData[] _poolsData;

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

		public void ReturnObjectToPool(PoolType objectType, GameObject objectToReturn)
		{
			if (_poolDictionary.TryGetValue(objectType, out Queue<GameObject> objectList))
			{
				objectList.Enqueue(objectToReturn);
			}

			objectToReturn.SetActive(false);
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

		private void Awake()
		{
			ServiceLocator.RegisterService<IPoolingService>(this);
			
			_poolsData = Resources.LoadAll<PoolData>(PoolsDataPath);

			_poolDictionary = new Dictionary<PoolType, Queue<GameObject>>();
			
			PopulateDictionary();
			
			DontDestroyOnLoad(gameObject);
		}

		private void OnDestroy()
		{
			ServiceLocator.DeregisterService<IPoolingService>();
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
	}
}
