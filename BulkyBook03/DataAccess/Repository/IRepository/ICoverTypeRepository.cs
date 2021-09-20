using BulkyBook03.Models;

namespace BulkyBook03.DataAccess.Repository.IRepository
{
    public interface ICoverTypeRepository :IRepository<CoverType>
    {
        void Update(CoverType coverType);
    }
}