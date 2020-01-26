namespace NorthWindWebApis.Service
{
    using System;
    using System.Data.Entity;
    using NorthWindWebApis.Service.Models;
    using NorthWindWebApis.DataLayer;

    public class BuildModel : IBuildModels
    {
        public ProductsModel GetListOfProducts()
        {
            throw new NotImplementedException();
        }

        public ProductModel GetProduct(int Id)
        {

            using (var context = new Prod())
            {
                var query = context.Students
                                   .where(s => s.StudentName == "Bill")
                                   .FirstOrDefault<Student>();
            }

        }
    }
}
