using HotChocolate.Types;
using Ovid.Data.Models.Campaigns;
using Ovid.GraphQL.Extensions.Resolvers.Advertising;
using Ovid.GraphQL.Extensions.Resolvers.Campaigns;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ovid.GraphQL.Extensions.Types.Campaigns
{
    public class UserCampaignItemClickGlType : ObjectType<UserCampaignItemClick>
    {
        protected override void Configure(IObjectTypeDescriptor<UserCampaignItemClick> descriptor)
        {
            base.Configure(descriptor);
            descriptor.Field(m => m.ClickId).Type<IdType>();
            descriptor.Field(m => m.AccountId).Type<StringType>();
            descriptor.Field(m => m.CampItemId).Type<IntType>();
            descriptor.Field(m => m.ClickDate).Type<StringType>();
            descriptor.Field<UserCampaignItemClickResolver>(t => t.GetCampaignItem(default, default));
            descriptor.Field<UserCampaignItemClickResolver>(t => t.GetUser(default, default));
        }
    }
}
