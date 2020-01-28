namespace NorthWindWebApis.Services
{
    using NorthWindWebApis.DataLayer;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Linq;

    public class BuildModelsService : DbContext, IBuildModelsService
    {
        private DbContext _context;

        //public BuildModelsService()
        //{ }

        //public BuildModelsService(DbContext context)
        //{
        //    _context = context;
        //}

        public List<Product> GetListOfProducts(string productSearch)
        {
            using (var _context = new NORTHWNDEntities())
            {
                return _context.Products
                                   .Where(s => s.ProductName.StartsWith(productSearch))
                                   .ToList();
            }
        }

        public Product GetProduct(int Id)
        {
            using (var _context = new NORTHWNDEntities())
            {
                return _context.Products
                                   .Where(s => s.ProductID == Id)
                                   .FirstOrDefault<Product>();
            }
        }
    }
}