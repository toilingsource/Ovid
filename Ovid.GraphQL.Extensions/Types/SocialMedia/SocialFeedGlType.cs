using HotChocolate.Types;
using Ovid.Data.Models.SocialMedia;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ovid.GraphQL.Extensions.Types.SocialMedia
{
    public class SocialFeedGlType : ObjectType<SocialFeed>
    {
        protected override void Configure(IObjectTypeDescriptor<SocialFeed> descriptor)
        {
            base.Configure(descriptor);
            descriptor.Field(m => m.FeedId).Type<IdType>();
            descriptor.Field(m => m.AccountId).Type<StringType>();
            descriptor.Field(m => m.Created).Type<DateTimeType>();
            descriptor.Field(m => m.CreatedBy).Type<StringType>();
            descriptor.Field(m => m.CrossPost).Type<BooleanType>();
            descriptor.Field(m => m.Followers).Type<IntType>();
            descriptor.Field(m => m.Link).Type<StringType>();
            descriptor.Field(m => m.Provider).Type<StringType>();
            descriptor.Field(m => m.PullFeeds).Type<BooleanType>();
            descriptor.Field(m => m.Updated).Type<DateTimeType>();
            descriptor.Field(m => m.UpdatedBy).Type<StringType>();

        }
    }
}
