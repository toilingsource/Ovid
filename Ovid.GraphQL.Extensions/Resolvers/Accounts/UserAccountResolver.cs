using HotChocolate;
using HotChocolate.Resolvers;
using Ovid.Data;
using Ovid.Data.Models.Accounts;
using Ovid.Data.Models.Advertising;
using Ovid.Data.Models.Campaigns;
using Ovid.Data.Models.Common;
using Ovid.Data.Models.Marketers;
using Ovid.Data.Models.Posts;
using Ovid.Data.Models.Products;
using Ovid.Data.Models.Ratings;
using Ovid.Data.Models.SocialMedia;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ovid.GraphQL.Extensions.Resolvers.Accounts
{
    public class UserAccountResolver
    {

        private readonly OvidDbContext _ovidDb;

        public UserAccountResolver(OvidDbContext ovidDb)
        {
            _ovidDb = ovidDb;
        }


        public AccountType GetAccountType([Parent]UserAccount user, IResolverContext ctx)
        {
            return _ovidDb.AccountTypes.Where(m => m.AccontTypeId == user.TypeId).SingleOrDefault();
        }

        public Ocupation GetOcupation([Parent] UserAccount user, IResolverContext ctx)
        {
            return _ovidDb.Ocupations.Where(m => m.OcupationId == user.OcupationId).SingleOrDefault();
        }

        public Salalary GetSalalary([Parent] UserAccount user, IResolverContext ctx)
        {
            return _ovidDb.Salalaries.Where(m => m.SalaryId == user.SalaryId).SingleOrDefault();
        }


        public IEnumerable<UserPost> GetUserPosts([Parent] UserAccount user, IResolverContext ctx)
        {
            return _ovidDb.UserPosts.Where(m => m.AccountId == user.AccountId).ToList();
        }


        public IEnumerable<PostImage> GetPostImages([Parent] UserAccount user, IResolverContext ctx)
        {
            return _ovidDb.PostImages.Where(m => m.AccountId == user.AccountId).ToList();
        }


        public IEnumerable<AccountRating> GetAccountRatings([Parent] UserAccount user, IResolverContext ctx)
        {
            return _ovidDb.AccountRatings.Where(m => m.AccountId == user.AccountId).ToList();
        }

        public IEnumerable<SocialFeed> GetSocialFeeds([Parent] UserAccount user, IResolverContext ctx)
        {
            return _ovidDb.SocialFeeds.Where(m => m.AccountId == user.AccountId).ToList();
        }

        public IEnumerable<Advertisment> GetAdvertisments([Parent] UserAccount user, IResolverContext ctx)
        {
            return _ovidDb.Advertisments.Where(m => m.AccountId == user.AccountId).ToList();
        }


        public IEnumerable<UserIntrest> GetUserIntrests([Parent] UserAccount user, IResolverContext ctx)
        {
            return _ovidDb.UserIntrests.Where(m => m.AccountId == user.AccountId).ToList();
        }

        public IEnumerable<Followed> GetFollowed([Parent] UserAccount user, IResolverContext ctx)
        {
            return _ovidDb.Followeds.Where(m => m.FollowedId == user.AccountId).ToList();
        }

        public IEnumerable<Followed> GetFollowers([Parent] UserAccount user, IResolverContext ctx)
        {
            return _ovidDb.Followeds.Where(m => m.FollowerId == user.AccountId).ToList();
        }


        public IEnumerable<Campaign> GetCampaigns([Parent] UserAccount user, IResolverContext ctx)
        {
            return _ovidDb.Campaigns.Where(m => m.AccountId == user.AccountId).ToList();
        }

        public IEnumerable<Marketer> GetMarketers([Parent] UserAccount user, IResolverContext ctx)
        {
            return _ovidDb.Marketers.Where(m => m.UserId == user.AccountId).ToList();
        }

        public IEnumerable<UserAddClick> GetUserAddClicks([Parent] UserAccount user, IResolverContext ctx)
        {
            return _ovidDb.UserAddClicks.Where(m => m.AccountId == user.AccountId).ToList();
        }

        public IEnumerable<UserCampaignClick> GetUserCampaignClicks([Parent] UserAccount user, IResolverContext ctx)
        {
            return _ovidDb.UserCampaignClicks.Where(m => m.AccountId == user.AccountId).ToList();
        }

        public IEnumerable<UserCampaignItemClick> GetUserCampaignItemClicks([Parent] UserAccount user, IResolverContext ctx)
        {
            return _ovidDb.UserCampaignItemClicks.Where(m => m.AccountId == user.AccountId).ToList();
        }

        public IEnumerable<UserProductClick> GetUserProductClicks([Parent] UserAccount user, IResolverContext ctx)
        {
            return _ovidDb.UserProductClicks.Where(m => m.AccountId == user.AccountId).ToList();
        }


    }
}
