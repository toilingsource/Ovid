using HotChocolate;
using HotChocolate.Resolvers;
using Ovid.Data;
using Ovid.Data.Models.Accounts;
using Ovid.Data.Models.Posts;
using Ovid.Data.Models.Ratings;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ovid.GraphQL.Extensions.Resolvers.Ratings
{
    public class AccountRatingResolver
    {
        private readonly OvidDbContext _ovidDb;

        public AccountRatingResolver(OvidDbContext ovidDb)
        {
            _ovidDb = ovidDb;
        }


        public UserAccount GetUserAccount([Parent] AccountRating rating, IResolverContext ctx)
        {
            return _ovidDb.UserAccounts.Where(m => m.AccountId == rating.AccountId).SingleOrDefault();
        }

        public UserPost GetUserPost([Parent] AccountRating rating, IResolverContext ctx)
        {
            return _ovidDb.UserPosts.Where(m => m.PostId == rating.PostId).SingleOrDefault();
        }
    }
}
