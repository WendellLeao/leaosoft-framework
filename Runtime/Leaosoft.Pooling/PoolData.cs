using UnityEngine;

namespace Leaosoft.Pooling
{
	[CreateAssetMenu(menuName = "Leaosoft/PoolingService/PoolData", fileName = "NewPoolData")]
	public sealed class PoolData : ScriptableObject
	{
		public string Id;
	
		public GameObject ObjectToPool;
	
		public int StartAmount;
	}
}
