using HotChocolate.Types;
using Ovid.Data.Models.Campaigns;
using Ovid.GraphQL.Extensions.Resolvers.Campaigns;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ovid.GraphQL.Extensions.Types.Campaigns
{
    public class UserCampaignClickGlType : ObjectType<UserCampaignClick>
    {
        protected override void Configure(IObjectTypeDescriptor<UserCampaignClick> descriptor)
        {
            base.Configure(descriptor);
            descriptor.Field(m => m.ClickId).Type<IdType>();
            descriptor.Field(m => m.AccountId).Type<StringType>();
            descriptor.Field(m => m.CampaignId).Type<StringType>();
            descriptor.Field(m => m.ClickDate).Type<DateTimeType>();
            descriptor.Field<UserCampaignClickResolver>(t=>t.GetCampaign(default,default));
            descriptor.Field<UserCampaignClickResolver>(t => t.GetUser(default, default));
        }
    }
}
