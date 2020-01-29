namespace NorthWindWebApis.Services
{
    using NorthWindWebApis.DataLayer;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Linq;

    public class BuildModelsService : DbContext, IBuildModelsService
    {
        NORTHWNDEntities _context;

        public NORTHWNDEntities Context
        { 
            get {
                    if (_context == null)
                    {
                        _context = new NORTHWNDEntities();
                    }
                    return _context;
                }  
        }

        public Product CreateNewProduct(Product prodContext)
        {
            Context.Products.Add(prodContext);
            Context.SaveChanges();
            return prodContext;
        }


        //public BuildModelsService()
        //{ }

        //public BuildModelsService(DbContext context)
        //{
        //    _context = context;
        //}

        public List<Product> GetListOfProducts(string productSearch)
        {
            return Context.Products
                                   .Where(s => s.ProductName.StartsWith(productSearch))
                                   .ToList();
        }

        public Product GetProduct(int Id)
        {
                return Context.Products
                                   .Where(s => s.ProductID == Id)
                                   .FirstOrDefault<Product>();
        }

        public int UpdateProduct()
        {
            return Context.SaveChanges();
        }
    }
}