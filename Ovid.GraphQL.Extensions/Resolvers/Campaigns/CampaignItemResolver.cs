using HotChocolate;
using HotChocolate.Resolvers;
using Ovid.Data;
using Ovid.Data.Models.Campaigns;
using Ovid.Data.Models.Products;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ovid.GraphQL.Extensions.Resolvers.Campaigns
{
    public class CampaignItemResolver
    {
        private readonly OvidDbContext _ovidDb;

        public CampaignItemResolver(OvidDbContext ovidDb)
        {
            _ovidDb = ovidDb;
        }


        public Campaign GetCampaign([Parent] CampaignItem item, IResolverContext ctx)
        {
            return _ovidDb.Campaigns.Where(m => m.CampaignId == item.CampaignId).SingleOrDefault();
        }


        public SponsoredProduct GetProduct([Parent] CampaignItem item, IResolverContext ctx)
        {
            return _ovidDb.SponsoredProducts.Where(m => m.ProductId == item.ProductId).SingleOrDefault();
        }

        public IEnumerable<UserCampaignItemClick> GetUserCampaignItemClicks([Parent] CampaignItem item, IResolverContext ctx)
        {
            return _ovidDb.UserCampaignItemClicks.Where(m => m.CampItemId == item.CampItemId).ToList();
        }
    }
}
