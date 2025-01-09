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
		private GameObject objectToPool;
		[SerializeField]
		private int startAmount;

		public string Id => id;
		public GameObject ObjectToPool => objectToPool;
		public int StartAmount => startAmount;
	}
}
