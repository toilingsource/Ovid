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
    public class CampaignItemGlType : ObjectType<CampaignItem>
    {
        protected override void Configure(IObjectTypeDescriptor<CampaignItem> descriptor)
        {
            base.Configure(descriptor);
            descriptor.Field(m => m.CampItemId).Type<IdType>();
            descriptor.Field(m => m.CampaignId).Type<StringType>();
            descriptor.Field(m => m.CampaignLink).Type<StringType>();
            descriptor.Field(m => m.Clicks).Type<StringType>();
            descriptor.Field(m => m.ProductId).Type<StringType>();
            descriptor.Field(m => m.RegularPrice).Type<StringType>();
            descriptor.Field(m => m.SalePrice).Type<StringType>();
            descriptor.Field(m => m.SalesText).Type<StringType>();
            descriptor.Field<CampaignItemResolver>(t => t.GetCampaign(default, default));
            descriptor.Field<CampaignItemResolver>(t => t.GetProduct(default, default));
            descriptor.Field<CampaignItemResolver>(t => t.GetUserCampaignItemClicks(default, default));
        }
    }
}
