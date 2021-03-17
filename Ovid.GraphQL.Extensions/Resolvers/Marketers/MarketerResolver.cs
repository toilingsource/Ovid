using HotChocolate;
using HotChocolate.Resolvers;
using Ovid.Data;
using Ovid.Data.Models.Accounts;
using Ovid.Data.Models.Advertising;
using Ovid.Data.Models.Marketers;
using Ovid.Data.Models.Products;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ovid.GraphQL.Extensions.Resolvers.Marketers
{
    public class MarketerResolver
    {
        private readonly OvidDbContext _ovidDb;

        public MarketerResolver(OvidDbContext ovidDb)
        {
            _ovidDb = ovidDb;
        }



        public UserAccount GetUserAccount([Parent] Marketer marketer, IResolverContext ctx)
        {
            return _ovidDb.UserAccounts.Where(m => m.AccountId == marketer.UserId).SingleOrDefault();
        }

        public IEnumerable<SponsoredProduct> GetSponsoredProducts([Parent] Marketer marketer, IResolverContext ctx)
        {
            return _ovidDb.SponsoredProducts.Where(m => m.MarkerterId == marketer.MarketerId).ToList();
        }

        public IEnumerable<Advertisment> GetAdvertisments([Parent] Marketer marketer, IResolverContext ctx)
        {
            return _ovidDb.Advertisments.Where(m => m.MarketerId == marketer.MarketerId).ToList();
        }

    }
}
