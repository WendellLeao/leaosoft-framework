using Leaosoft.Pooling;
using UnityEngine;

namespace Leaosoft.Master
{
    public sealed class PoolingServiceManager : Manager
    {
        [SerializeField] private PoolingService _poolingService;
        [SerializeField] private PoolData[] _poolsData;

        protected override void OnInitialize()
        {
            base.OnInitialize();

            InitializePoolingService();
        }

        private void InitializePoolingService()
        {
            PoolingService poolingServiceClone = Instantiate(_poolingService);
            
            poolingServiceClone.RegisterService();
            
            poolingServiceClone.Initialize(_poolsData);
        }
    }
}
