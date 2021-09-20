using System.Linq;
using BulkyBook03.DataAccess.Data;
using BulkyBook03.DataAccess.Repository.IRepository;
using BulkyBook03.Models;

namespace BulkyBook03.DataAccess.Repository
{
    public class CompanyRepository : Repository<Company>, ICompanyRepository
    {
        private readonly ApplicationDbContext _db;
        public CompanyRepository(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }

        public void Update(Company company)
        {
            _db.Update(company);
        }
    }
}