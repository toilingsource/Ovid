using HotChocolate;
using HotChocolate.Resolvers;
using Ovid.Data;
using Ovid.Data.Models.Accounts;
using Ovid.Data.Models.Advertising;
using Ovid.Data.Models.Marketers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ovid.GraphQL.Extensions.Resolvers.Advertising
{
    public class AdvertismentResolver
    {
        private readonly OvidDbContext _ovidDb;

        public AdvertismentResolver(OvidDbContext ovidDb)
        {
            _ovidDb = ovidDb;
        }



        public UserAccount GetUser([Parent] Advertisment add, IResolverContext ctx)
        {
            return _ovidDb.UserAccounts.Where(m => m.AccountId == add.AccountId).SingleOrDefault();
        }


        public Marketer GetMarketer([Parent] Advertisment add, IResolverContext ctx)
        {
            return _ovidDb.Marketers.Where(m => m.MarketerId == add.MarketerId).SingleOrDefault();
        }

        public IEnumerable<UserAddClick> GetUserAddClicks([Parent] Advertisment add, IResolverContext ctx)
        {
            return _ovidDb.UserAddClicks.Where(m => m.AddId == add.AddId).ToList();
        }



    }
}
