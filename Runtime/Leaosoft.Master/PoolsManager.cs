using Leaosoft.Services;
using Leaosoft.Pooling;
using UnityEngine;

namespace Leaosoft.Master
{
    public sealed class PoolsManager : Manager
    {
        [SerializeField] private PoolData[] _poolsData;

        protected override void OnInitialize()
        {
            base.OnInitialize();

            IPoolingService poolingService = ServiceLocator.GetService<IPoolingService>();

            poolingService.PopulatePoolsData(_poolsData);
        }
    }
}
