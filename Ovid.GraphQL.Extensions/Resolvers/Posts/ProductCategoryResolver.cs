using HotChocolate;
using HotChocolate.Resolvers;
using Ovid.Data;
using Ovid.Data.Models.Products;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ovid.GraphQL.Extensions.Resolvers.Posts
{
    public class ProductCategoryResolver
    {
        private readonly OvidDbContext _ovidDb;

        public ProductCategoryResolver(OvidDbContext ovidDb)
        {
            _ovidDb = ovidDb;
        }

        public IEnumerable<SponsoredProduct> GetProducts([Parent] ProductCategory product, IResolverContext ctx)
        {
            return _ovidDb.SponsoredProducts.Where(m => m.CategoryId == product.CategoryId).ToList();
        } 

    }
}
