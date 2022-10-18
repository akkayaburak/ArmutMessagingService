using Core.Interface;

namespace Contracts.Interface
{
    public interface IBaseService
    {
        void SetDBManager(IDBManager dBManager);
    }
}