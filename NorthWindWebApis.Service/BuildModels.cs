namespace NorthWindWebApis.Service
{
    using System.Data.Entity;
    using System.Linq;
    using System.Collections.Generic;
    using NorthWindWebApis.DataLayer;


    public class BuildModels : DbContext,IBuildModels
    {
        DbContext _context;
        public BuildModels()
        { }

        public BuildModels(DbContext context)
        {
            _context = context;
        }

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
