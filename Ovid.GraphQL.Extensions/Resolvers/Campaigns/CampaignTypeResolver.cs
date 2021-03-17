using HotChocolate;
using HotChocolate.Resolvers;
using Ovid.Data;
using Ovid.Data.Models.Campaigns;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ovid.GraphQL.Extensions.Resolvers.Campaigns
{
    public class CampaignTypeResolver
    {
        private readonly OvidDbContext _ovidDb;

        public CampaignTypeResolver(OvidDbContext ovidDb)
        {
            _ovidDb = ovidDb;
        }


        public IEnumerable<Campaign> GetCampaigns([Parent] CampaignType type, IResolverContext ctx)
        {
            return _ovidDb.Campaigns.Where(m => m.TypeId == type.TypeId).ToList();
        }
    }
}
