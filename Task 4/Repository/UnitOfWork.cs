using Microsoft.AspNetCore.Identity;
using NuGet.Packaging.Core;
using Task_4.Data;
using Task_4.Repository.IRepository;

namespace Task_4.Repository
{
    public class UnitOfWork : IUnitOfWork
    {
        private ApplicationDbContext _db;
        public IAuthorRepository Author { get; private set; }
        public IBookRepository Book { get; private set; }
        public UnitOfWork(ApplicationDbContext db)
        {
            _db = db;
            Author = new AuthorRepository(_db);
            Book = new BookRepository(_db);
        }
        public void Save()
        {
            _db.SaveChanges();
        }
    }
}
