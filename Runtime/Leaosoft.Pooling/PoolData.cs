using UnityEngine;

namespace Leaosoft.Pooling
{
	[CreateAssetMenu(menuName = "Leaosoft/PoolingService/PoolData", fileName = "NewPoolData")]
	public sealed class PoolData : ScriptableObject
	{
		public PoolType PoolType;
	
		public GameObject ObjectToPool;
	
		public int StartAmount;
	}
}
