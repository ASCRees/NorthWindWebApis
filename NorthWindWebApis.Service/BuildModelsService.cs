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


        //public BuildModelsService()
        //{ }

        //public BuildModelsService(DbContext context)
        //{
        //    _context = context;
        //}

        public List<Product> GetListOfProducts(string productSearch)
        {
            //_context = new NORTHWNDEntities();
            //using (var _context = new NORTHWNDEntities())
            //{
            //    _context = new NORTHWNDEntities();
            return Context.Products
                                   .Where(s => s.ProductName.StartsWith(productSearch))
                                   .ToList();
            //}
        }

        public Product GetProduct(int Id)
        {
            //using (_context = new NORTHWNDEntities())
            //{
                return Context.Products
                                   .Where(s => s.ProductID == Id)
                                   .FirstOrDefault<Product>();
            //}
        }
    }
}