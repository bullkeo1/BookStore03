using System;

namespace BulkyBook03.DataAccess.Repository.IRepository
{
    public interface IUnitOfWork : IDisposable
    {
        ICategoryRepository Category { get; }
        ICoverTypeRepository CoverType { get; }
        
        IOrderHeaderRepository OrderHeader { get; }
        IOrderDetailsRepository OrderDetails { get; }
        IShoppingCartRepository ShoppingCart { get; }
        IProductRepository Product { get; }
        
        ICompanyRepository Company { get; }
        
        IApplicationUserRepository ApplicationUser { get; }
        ISP_Call SP_Call { get; }
        
        void Save();
    }
}