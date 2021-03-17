using HotChocolate;
using HotChocolate.Resolvers;
using Ovid.Data;
using Ovid.Data.Models.Accounts;
using Ovid.Data.Models.Campaigns;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ovid.GraphQL.Extensions.Resolvers.Campaigns
{
    public class CampaignResolver
    {
        private readonly OvidDbContext _ovidDb;

        public CampaignResolver(OvidDbContext ovidDb)
        {
            _ovidDb = ovidDb;
        }



        public CampaignType GetCampaignType([Parent] Campaign campaign, IResolverContext ctx)
        {
            return _ovidDb.CampaignTypes.Where(m => m.TypeId == campaign.TypeId).SingleOrDefault();
        }

        public UserAccount GetUser([Parent] Campaign campaign, IResolverContext ctx)
        {
            return _ovidDb.UserAccounts.Where(m => m.AccountId == campaign.AccountId).SingleOrDefault();
        }

        public IEnumerable<CampaignItem> GetCampaignItems([Parent] Campaign campaign, IResolverContext ctx)
        {
            return _ovidDb.CampaignItems.Where(m => m.CampaignId == campaign.CampaignId).ToList();
        }

        public IEnumerable<UserCampaignClick> GetUserCampaignClicks([Parent] Campaign campaign, IResolverContext ctx)
        {
            return _ovidDb.UserCampaignClicks.Where(m => m.CampaignId == campaign.CampaignId).ToList();
        }


    }
}
