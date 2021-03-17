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
    public class ProductImageResolver
    {
        private readonly OvidDbContext _ovidDb;

        public ProductImageResolver(OvidDbContext ovidDb)
        {
            _ovidDb = ovidDb;
        }


        public SponsoredProduct GetProduct([Parent] ProductImage image, IResolverContext ctx)
        {
            return _ovidDb.SponsoredProducts.Where(m => m.ProductId == image.ProductId).SingleOrDefault();
        }
    }
}
