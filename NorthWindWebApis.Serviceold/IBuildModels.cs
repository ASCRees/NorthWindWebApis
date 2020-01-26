using NorthWindWebApis.Service.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NorthWindWebApis.Service
{
    public interface IBuildModels
    {
        ProductsModel GetListOfProducts();

        ProductModel GetProduct(Int32 Id);
    }
}
