using HotChocolate.Types;
using Ovid.Data.Models.Advertising;
using Ovid.GraphQL.Extensions.Resolvers.Advertising;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ovid.GraphQL.Extensions.Types.Advertising
{
    public class AdvertismentGlType :ObjectType<Advertisment>
    {
        protected override void Configure(IObjectTypeDescriptor<Advertisment> descriptor)
        {
            base.Configure(descriptor);
            descriptor.Field(m => m.AccountId).Type<StringType>();
            descriptor.Field(m => m.AddData).Type<StringType>();
            descriptor.Field(m => m.AddId).Type<IdType>();
            descriptor.Field(m => m.AltText).Type<StringType>();
            descriptor.Field(m => m.Clicks).Type<IntType>();
            descriptor.Field(m => m.Created).Type<DateTimeType>();
            descriptor.Field(m => m.CreatedBy).Type<StringType>();
            descriptor.Field(m => m.EndDate).Type<DateTimeType>();
            descriptor.Field(m => m.Impressions).Type<IntType>();
            descriptor.Field(m => m.MarketerId).Type<StringType>();
            descriptor.Field(m => m.StartDate).Type<DateTimeType>();
            descriptor.Field(m => m.Updated).Type<DateTimeType>();
            descriptor.Field(m => m.UpdatedBy).Type<StringType>();
            descriptor.Field(m => m.Weight).Type<FloatType>();
            descriptor.Field<AdvertismentResolver>(t=>t.GetUserAddClicks(default, default));
            descriptor.Field<AdvertismentResolver>(t => t.GetUser(default, default));
            descriptor.Field<AdvertismentResolver>(t => t.GetMarketer(default, default));
        }
    }
}
