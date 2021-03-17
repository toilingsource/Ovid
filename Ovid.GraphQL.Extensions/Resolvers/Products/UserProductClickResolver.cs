using HotChocolate;
using HotChocolate.Resolvers;
using Ovid.Data;
using Ovid.Data.Models.Accounts;
using Ovid.Data.Models.Products;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ovid.GraphQL.Extensions.Resolvers.Products
{
    public class UserProductClickResolver
    {
        private readonly OvidDbContext _ovidDb;

        public UserProductClickResolver(OvidDbContext ovidDb)
        {
            _ovidDb = ovidDb;
        }

        public SponsoredProduct GetProduct([Parent] UserProductClick click, IResolverContext ctx)
        {
            return _ovidDb.SponsoredProducts.Where(m => m.ProductId == click.ProductId).SingleOrDefault();
        }

        public UserAccount GetUserAccount([Parent] UserProductClick click, IResolverContext ctx)
        {
            return _ovidDb.UserAccounts.Where(m => m.AccountId == click.AccountId).SingleOrDefault();
        }

    }
}
