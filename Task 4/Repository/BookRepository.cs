using Task_4.Data;
using Task_4.Models;
using Task_4.Repository.IRepository;

namespace Task_4.Repository
{
    public class BookRepository : Repository<Book>, IBookRepository
    {
        private ApplicationDbContext _db;
        public BookRepository(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }
    }
}
