using AutoMapper;
using NorthWindWebApis.Models;
using NorthWindWebApis.DataLayer;
using System.Diagnostics.CodeAnalysis;

namespace NorthWindWebApis.App_Start
{
    [ExcludeFromCodeCoverage]

    public class AutoMapperConfig : Profile
    {
        /// <summary>
        /// Creates the mappings.
        /// </summary>
        public static void CreateMappings()
        {
            Mapper.Reset();
            Mapper.Initialize(cfg =>
            {
                cfg.CreateMap<Product, ProductViewModel>();
            });
        }
    }
}