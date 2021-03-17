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
    public class UserCampaignClickResolver
    {
        private readonly OvidDbContext _ovidDb;

        public UserCampaignClickResolver(OvidDbContext ovidDb)
        {
            _ovidDb = ovidDb;
        }


        public UserAccount GetUser([Parent] UserCampaignClick click, IResolverContext ctx )
        {
            return _ovidDb.UserAccounts.Where(m => m.AccountId == click.AccountId).SingleOrDefault();
        }

        public Campaign GetCampaign([Parent] UserCampaignClick click, IResolverContext ctx)
        {
            return _ovidDb.Campaigns.Where(m => m.CampaignId == click.CampaignId).SingleOrDefault();
        }
    }
}
