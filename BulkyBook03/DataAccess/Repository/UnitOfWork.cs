using System;
using System.Collections.Generic;
using BulkyBook03.DataAccess;
using BulkyBook03.DataAccess.Data;
using BulkyBook03.DataAccess.Repository.IRepository;
using BulkyBook03.Models;
using Dapper;

namespace BulkyBook03.DataAccess.Repository
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ApplicationDbContext _db;

        public UnitOfWork(ApplicationDbContext db)
        {
            _db = db;
            Category = new CategoryRepository(_db);
            CoverType = new CoverTypeRepository(_db);
            Product = new ProductRepository(_db);
            Company = new CompanyRepository(_db);
            ApplicationUser = new ApplicationUserRepository(_db);
            OrderHeader = new OrderHeaderRepository(_db);
            OrderDetails = new OrderDetailsRepository(_db);
            ShoppingCart = new ShoppingCartRepository(_db);
            SP_Call = new SP_Call(_db);
        }

        public ICategoryRepository Category { get; private set; }
        public ICoverTypeRepository CoverType { get; private set; }
        public IOrderHeaderRepository OrderHeader { get; }
        public IOrderDetailsRepository OrderDetails { get; }
        public IShoppingCartRepository ShoppingCart { get; }
        public IProductRepository Product { get; }
        public ICompanyRepository Company { get; }
        
        public IApplicationUserRepository ApplicationUser { get; }
        public ISP_Call SP_Call { get; private set; }
        public void Dispose()
        {
            _db.Dispose();
        }

        public void Save()
        {
            _db.SaveChanges();
        }
    }
}