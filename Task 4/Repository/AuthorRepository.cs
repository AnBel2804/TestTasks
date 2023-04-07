using Task_4.Data;
using Task_4.Models;
using Task_4.Repository.IRepository;

namespace Task_4.Repository
{
    public class AuthorRepository : Repository<Author>, IAuthorRepository
    {
        private ApplicationDbContext _db;
        public AuthorRepository(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }
    }
}
