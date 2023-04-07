namespace Task_4.Repository.IRepository
{
    public interface IUnitOfWork
    {
        IAuthorRepository Author { get; }
        IBookRepository Book { get; }
        void Save();
    }
}
