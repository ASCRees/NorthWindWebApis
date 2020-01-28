using NorthWindWebApis.DataLayer;
using System;
using System.Collections.Generic;

namespace NorthWindWebApis.Services
{
    public interface IBuildModelsService
    {
        NORTHWNDEntities Context { get; }
        List<Product> GetListOfProducts(string productSearch);

        Product GetProduct(Int32 Id);
        int UpdateProduct();
    }
}