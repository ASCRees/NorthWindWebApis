using NorthWindWebApis.DataLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NorthWindWebApis.Service
{
    public interface IBuildModels
    {
        List<Product> GetListOfProducts(string productSearch);

        Product GetProduct(Int32 Id);
    }
}
