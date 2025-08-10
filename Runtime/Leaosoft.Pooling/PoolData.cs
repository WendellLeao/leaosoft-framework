using Leaosoft.Utilities;
using UnityEngine;

namespace Leaosoft.Pooling
{
	[CreateAssetMenu(menuName = PathUtility.PoolingAssetsPath + "/PoolData", fileName = "NewPoolData")]
	public sealed class PoolData : ScriptableObject
	{
		[SerializeField]
		private string id;
		[SerializeField]
		private GameObject prefab;
		[SerializeField]
		private bool collectionCheck;
		[SerializeField]
		private int defaultCapacity = 10;
		[SerializeField]
		private int maxSize = 10000;

		public string Id => id;
		public GameObject Prefab => prefab;
		public bool CollectionCheck => collectionCheck;
		public int DefaultCapacity => defaultCapacity;
		public int MaxSize => maxSize;
	}
}
