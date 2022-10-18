using Contracts.Interface;
using Core.Interface;

namespace Business
{
    public class BaseService : IBaseService
    {
        protected IDBManager dBManager;
        public void SetDBManager(IDBManager dBManager)
        {
            this.dBManager = dBManager;
        }
    }
}