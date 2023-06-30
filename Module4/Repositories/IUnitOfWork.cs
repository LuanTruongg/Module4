namespace Module4.Repositories
{
    public interface IUnitOfWork
    {
        Task CompleteAsync();
    }
}
