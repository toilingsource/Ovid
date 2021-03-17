using HotChocolate;
using HotChocolate.Resolvers;
using Ovid.Data;
using Ovid.Data.Models.Accounts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ovid.GraphQL.Extensions.Resolvers.Accounts
{
    public class FollowedResolver 
    {

        private readonly OvidDbContext _ovidDb;

        public FollowedResolver(OvidDbContext ovidDb)
        {
            _ovidDb = ovidDb;
        }



        public UserAccount GetFollower([Parent]Followed followed, IResolverContext ctx)
        {
            return _ovidDb.UserAccounts.Where(m => m.UserId == followed.FollowerId).SingleOrDefault();
        }


        public UserAccount GetFollowed([Parent] Followed followed, IResolverContext ctx)
        {
            return _ovidDb.UserAccounts.Where(m => m.UserId == followed.FollowedId).SingleOrDefault();
        }

    }
}
