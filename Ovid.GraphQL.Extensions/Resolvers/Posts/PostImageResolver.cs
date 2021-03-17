using HotChocolate;
using HotChocolate.Resolvers;
using Ovid.Data;
using Ovid.Data.Models.Accounts;
using Ovid.Data.Models.Posts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ovid.GraphQL.Extensions.Resolvers.Posts
{
    public class PostImageResolver 
    {

        private readonly OvidDbContext _ovidDb;

        public PostImageResolver(OvidDbContext ovidDb)
        {
            _ovidDb = ovidDb;
        }


        public UserAccount GetUserAccount([Parent] PostImage post, IResolverContext ctx)
        {
            return _ovidDb.UserAccounts.Where(m => m.AccountId == post.AccountId).SingleOrDefault();
        }

        public UserPost GetUserPost([Parent] PostImage post, IResolverContext ctx)
        {
            return _ovidDb.UserPosts.Where(m=>m.PostId == post.PostId).SingleOrDefault();
        }
    }
}
