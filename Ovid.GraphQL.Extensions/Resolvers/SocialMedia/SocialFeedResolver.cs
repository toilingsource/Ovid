using HotChocolate;
using HotChocolate.Resolvers;
using Ovid.Data;
using Ovid.Data.Models.Accounts;
using Ovid.Data.Models.SocialMedia;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ovid.GraphQL.Extensions.Resolvers.SocialMedia
{
    public class SocialFeedResolver 
    {
        private readonly OvidDbContext _ovidDb;

        public SocialFeedResolver(OvidDbContext ovidDb)
        {
            _ovidDb = ovidDb;
        }


        public UserAccount GetUser([Parent] SocialFeed feed, IResolverContext ctx)
        {
            return _ovidDb.UserAccounts.Where(m => m.AccountId == feed.AccountId).SingleOrDefault();
        }

    }
}
