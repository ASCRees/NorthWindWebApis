using NorthWindWebApis.DataLayer;
using System;
using System.Collections.Generic;

namespace NorthWindWebApis.Service
{
    public interface IBuildModels
    {
        List<Product> GetListOfProducts(string productSearch);

        Product GetProduct(Int32 Id);
    }
}