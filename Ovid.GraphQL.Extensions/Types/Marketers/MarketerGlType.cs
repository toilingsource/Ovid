using HotChocolate.Types;
using Ovid.Data.Models.Marketers;
using Ovid.GraphQL.Extensions.Resolvers.Marketers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ovid.GraphQL.Extensions.Types.Marketers
{
    public class MarketerGlType : ObjectType<Marketer>
    {
        protected override void Configure(IObjectTypeDescriptor<Marketer> descriptor)
        {
            base.Configure(descriptor);
            descriptor.Field(m => m.MarketerId).Type<IdType>();
            descriptor.Field(m => m.ContactEmail).Type<StringType>();
            descriptor.Field(m => m.Created).Type<DateTimeType>();
            descriptor.Field(m => m.CreatedBy).Type<StringType>();
            descriptor.Field(m => m.Description).Type<StringType>();
            descriptor.Field(m => m.Logo).Type<StringType>();
            descriptor.Field(m => m.Name).Type<StringType>();
            descriptor.Field(m => m.SupportPhone).Type<StringType>();
            descriptor.Field(m => m.SupportUrl).Type<StringType>();
            descriptor.Field(m => m.Updated).Type<DateTimeType>();
            descriptor.Field(m => m.UpdatedBy).Type<StringType>();
            descriptor.Field(m => m.UserId).Type<StringType>();
            descriptor.Field(m => m.WebSite).Type<StringType>();
            descriptor.Field<MarketerResolver>(t => t.GetAdvertisments(default, default));
            descriptor.Field<MarketerResolver>(t => t.GetSponsoredProducts(default, default));
            descriptor.Field<MarketerResolver>(t => t.GetUserAccount(default, default));
        }
    }
}
