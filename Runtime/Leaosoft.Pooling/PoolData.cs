using Leaosoft.Utilities;
using UnityEngine;

namespace Leaosoft.Pooling
{
	[CreateAssetMenu(menuName = PathUtility.PoolingAssetsPath + "/PoolData", fileName = "NewPoolData")]
	public sealed class PoolData : ScriptableObject
	{
		[SerializeField]
		private string _id;
		[SerializeField]
		private GameObject _objectToPool;
		[SerializeField]
		private int _startAmount;
		
		public string Id => _id;
		public GameObject ObjectToPool => _objectToPool;
		public int StartAmount => _startAmount;
	}
}
