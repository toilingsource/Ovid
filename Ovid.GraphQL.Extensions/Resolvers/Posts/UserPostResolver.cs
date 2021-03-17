using HotChocolate;
using HotChocolate.Resolvers;
using Ovid.Data;
using Ovid.Data.Models.Accounts;
using Ovid.Data.Models.Posts;
using Ovid.Data.Models.Products;
using Ovid.Data.Models.Ratings;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ovid.GraphQL.Extensions.Resolvers.Posts
{
    public class UserPostResolver
    {
        private readonly OvidDbContext _ovidDb;

        public UserPostResolver(OvidDbContext ovidDb)
        {
            _ovidDb = ovidDb;
        }



        public UserAccount GetUserAccount([Parent] UserPost post, IResolverContext ctx)
        {
            return _ovidDb.UserAccounts.Where(m => m.AccountId == post.AccountId).SingleOrDefault();
        }

        public SponsoredProduct GetProduct([Parent] UserPost post, IResolverContext ctx)
        {
            return _ovidDb.SponsoredProducts.Where(m => m.ProductId == post.ProductId).SingleOrDefault();
        }


        public IEnumerable<AccountRating> GetAccountRatings([Parent] UserPost post, IResolverContext ctx)
        {
            return _ovidDb.AccountRatings.Where(m => m.PostId == post.PostId).ToList();
        }

        public IEnumerable<PostImage> GetPostImages([Parent] UserPost post, IResolverContext ctx)
        {
            return _ovidDb.PostImages.Where(m => m.PostId == post.PostId).ToList();
        }


    }
}
