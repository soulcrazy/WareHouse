namespace WareHouse.Core.Data
{
    public interface IUnitOfWork
    {
        int Commit();
    }
}