using System.Linq;
using BulkyBook03.Models;
using BulkyBook03.DataAccess;
using BulkyBook03.DataAccess.Data;
using BulkyBook03.DataAccess.Repository.IRepository;

namespace BulkyBook03.DataAccess.Repository
{
    public class CategoryRepository : RepositoryAsync<Category>, ICategoryRepository
    {
        private readonly ApplicationDbContext _db;
        public CategoryRepository(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }

        public void Update(Category category)
        {
            var objFromDb = _db.Categories.FirstOrDefault(s=>s.Id==category.Id);
            if (objFromDb != null)
            {
                objFromDb.Name = category.Name;
                _db.SaveChanges();
            }
        }
    }
}