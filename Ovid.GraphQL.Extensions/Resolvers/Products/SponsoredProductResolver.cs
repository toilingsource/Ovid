using HotChocolate;
using HotChocolate.Resolvers;
using Ovid.Data;
using Ovid.Data.Models.Marketers;
using Ovid.Data.Models.Products;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ovid.GraphQL.Extensions.Resolvers.Products
{
    public class SponsoredProductResolver
    {
        private readonly OvidDbContext _ovidDb;

        public SponsoredProductResolver(OvidDbContext ovidDb)
        {
            _ovidDb = ovidDb;
        }

        public Marketer GetMarketer([Parent] SponsoredProduct product, IResolverContext ctx)
        {
            return _ovidDb.Marketers.Where(m => m.MarketerId == product.MarkerterId).SingleOrDefault();
        }

        public ProductCategory GetProductCategory([Parent] SponsoredProduct product, IResolverContext ctx)
        {
            return _ovidDb.ProductCategories.Where(m => m.CategoryId == product.CategoryId).SingleOrDefault();
        }

        public IEnumerable<ProductImage> GetProductImages([Parent] SponsoredProduct product, IResolverContext ctx)
        {
            return _ovidDb.ProductImages.Where(m => m.ProductId == product.ProductId).ToList();
        }

        public IEnumerable<UserProductClick> GetUserProductClicks([Parent] SponsoredProduct product, IResolverContext ctx)
        {
            return _ovidDb.UserProductClicks.Where(m => m.ProductId == product.ProductId).ToList();
        }

    }
}
