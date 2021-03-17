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
    public class CampaignGlType : ObjectType<Campaign>
    {

        protected override void Configure(IObjectTypeDescriptor<Campaign> descriptor)
        {
            base.Configure(descriptor);
            descriptor.Field(m => m.CampaignId).Type<IdType>();
            descriptor.Field(m => m.AccountId).Type<StringType>();
            descriptor.Field(m => m.Clicks).Type<StringType>();
            descriptor.Field(m => m.Created).Type<StringType>();
            descriptor.Field(m => m.CreatedBy).Type<StringType>();
            descriptor.Field(m => m.EndDate).Type<StringType>();
            descriptor.Field(m => m.Graphic).Type<StringType>();
            descriptor.Field(m => m.Height).Type<StringType>();
            descriptor.Field(m => m.Impressions).Type<StringType>();
            descriptor.Field(m => m.StartDate).Type<StringType>();
            descriptor.Field(m => m.TypeId).Type<StringType>();
            descriptor.Field(m => m.Updated).Type<StringType>();
            descriptor.Field(m => m.UpdatedBy).Type<StringType>();
            descriptor.Field(m => m.Width).Type<StringType>();
            descriptor.Field<CampaignResolver>(t => t.GetCampaignItems(default,default));
            descriptor.Field<CampaignResolver>(t => t.GetCampaignType(default, default));
            descriptor.Field<CampaignResolver>(t => t.GetUser(default, default));
            descriptor.Field<CampaignResolver>(t => t.GetUserCampaignClicks(default, default));
        }

    }
}
