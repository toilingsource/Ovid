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
    public class UserCampaignItemClickResolver
    {
        private readonly OvidDbContext _ovidDb;

        public UserCampaignItemClickResolver(OvidDbContext ovidDb)
        {
            _ovidDb = ovidDb;
        }

        public UserAccount GetUser([Parent] UserCampaignItemClick itemClick, IResolverContext ctx)
        {
            return _ovidDb.UserAccounts.Where(m => m.AccountId == itemClick.AccountId).SingleOrDefault();
        }


        public CampaignItem GetCampaignItem([Parent] UserCampaignItemClick itemClick, IResolverContext ctx)
        {
            return _ovidDb.CampaignItems.Where(m => m.CampItemId == itemClick.CampItemId).SingleOrDefault();
        }

    }
}
