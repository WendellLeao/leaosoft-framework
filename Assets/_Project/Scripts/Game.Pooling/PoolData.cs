using UnityEngine;

namespace Game.Pooling
{
	[CreateAssetMenu(menuName = "PoolerService/PoolData", fileName = "NewPoolData")]
	public sealed class PoolData : ScriptableObject
	{
		public PoolType PoolType;
	
		public GameObject ObjectToPool;
	
		public int StartAmount;
	}
}
