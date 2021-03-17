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
    public class CampaignTypeGlType : ObjectType<CampaignType>
    {
        protected override void Configure(IObjectTypeDescriptor<CampaignType> descriptor)
        {
            base.Configure(descriptor);
            descriptor.Field(m => m.TypeId).Type<IdType>();
            descriptor.Field(m => m.Description).Type<StringType>();
            descriptor.Field(m => m.Name).Type<StringType>();
            descriptor.Field<CampaignTypeResolver>(t => t.GetCampaigns(default, default));
        }
    }
}
