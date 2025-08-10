using System;
using System.Collections.Generic;
using Leaosoft.Domain.Pooling;
using Leaosoft.Services;
using UnityEngine;
using UnityEngine.Pool;

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

		private readonly Dictionary<string, IObjectPool<IPooledObject>> _poolsDictionary = new();
		
		public bool TryGetObjectFromPool<T>(string poolId, out T result) where T : IPooledObject
		{
			IObjectPool<IPooledObject> pool = GetOrCreatePool(poolId);
			
			IPooledObject pooledObject = pool.Get();
			
			if (pooledObject is T typed)
			{
				result = typed;
				return true;
			}

			Debug.LogError($"Pool '{poolId}' returned '{pooledObject.GetType().Name}', which does not implement '{typeof(T).Name}'");
			
			pool.Release(pooledObject);
			
			result = default;
			return false;
		}
		
		public void ReleaseObjectToPool(IPooledObject pooledObject)
		{
			if (!TryGetObjectPool(pooledObject, out IObjectPool<IPooledObject> pool))
			{
				return;
			}
			
			pool.Release(pooledObject);
		}
		
		protected override void RegisterService()
		{
			ServiceLocator.RegisterService<IPoolingService>(this);
		}

		protected override void UnregisterService()
		{
			ServiceLocator.UnregisterService<IPoolingService>();
		}

		protected override void OnDispose()
		{
			base.OnDispose();

			ClearAllPools();
		}

		private IPooledObject CreateObject(GameObject prefab, string poolId)
		{
			GameObject newGameObject = Instantiate(prefab);

			IPooledObject pooledObject = newGameObject.GetComponent<IPooledObject>();

			pooledObject.PoolId = poolId;
			
			return pooledObject;
		}

		private void OnGetFromPool(IPooledObject pooledObject)
		{
			pooledObject.GameObject.SetActive(true);
		}

		private void OnReleaseToPool(IPooledObject pooledObject)
		{
			pooledObject.GameObject.SetActive(false);
		}

		private void OnDestroyPooledObject(IPooledObject pooledObject)
		{
			if (!pooledObject.GameObject)
			{
				return;
			}
			
			Destroy(pooledObject.GameObject);
		}
		
		private void ClearAllPools()
		{
			foreach (KeyValuePair<string, IObjectPool<IPooledObject>> keyValuePair in _poolsDictionary)
			{
				IObjectPool<IPooledObject> value = keyValuePair.Value;
				
				value.Clear();
			}

			_poolsDictionary.Clear();
		}
		
		private IObjectPool<IPooledObject> GetOrCreatePool(string poolId)
		{
			if (string.IsNullOrEmpty(poolId))
			{
				throw new InvalidOperationException("Wasn't possible to get a pooled object because the pool id is null or empty!");
			}

			if (_poolsDictionary.TryGetValue(poolId, out IObjectPool<IPooledObject> existingPool))
			{
				return existingPool;
			}

			if (!poolDataCollection.TryGetDataById(poolId, out PoolData poolData) || !poolData.Prefab)
			{
				throw new InvalidOperationException($"Wasn't possible to create pool '{poolId}' because the prefab is null or missing!");
			}

			GameObject prefab = poolData.Prefab;

			if (!prefab.TryGetComponent(out IPooledObject _))
			{
				throw new InvalidOperationException($"Wasn't possible to create pool '{poolId}' because the prefab '{prefab.name}'" +
				                                    $"does not implement {nameof(IPooledObject)}!");
			}
			
			IObjectPool<IPooledObject> pool = new ObjectPool<IPooledObject>(
				createFunc: () => CreateObject(prefab, poolId),
				actionOnGet: OnGetFromPool,
				actionOnRelease: OnReleaseToPool,
				actionOnDestroy: OnDestroyPooledObject,
				collectionCheck: poolData.CollectionCheck,
				defaultCapacity: poolData.DefaultCapacity,
				maxSize: poolData.MaxSize
			);

			_poolsDictionary.Add(poolId, pool);
			
			return pool;
		}

		private bool TryGetObjectPool(IPooledObject pooledObject, out IObjectPool<IPooledObject> result)
		{
			if (!pooledObject.GameObject)
			{
				throw new InvalidOperationException("Wasn't possible to release the object because it is null or destroyed!");
			}

			if (string.IsNullOrEmpty(pooledObject.PoolId))
			{
				throw new InvalidOperationException("Wasn't possible to release the object because it has no PoolId set!");
			}
			
			if (!_poolsDictionary.TryGetValue(pooledObject.PoolId, out result))
			{
				throw new InvalidOperationException($"Wasn't possible to release the object because pool '{pooledObject.PoolId}' is not registered!");
			}

			return true;
		}
	}
}
