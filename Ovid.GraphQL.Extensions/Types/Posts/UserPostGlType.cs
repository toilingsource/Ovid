using HotChocolate.Types;
using Ovid.Data.Models.Posts;
using Ovid.GraphQL.Extensions.Resolvers.Posts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ovid.GraphQL.Extensions.Types.Posts
{
    public class UserPostGlType : ObjectType<UserPost>
    {
        protected override void Configure(IObjectTypeDescriptor<UserPost> descriptor)
        {
            base.Configure(descriptor);
            descriptor.Field(m => m.PostId).Type<IdType>();
            descriptor.Field(m => m.AccountId).Type<StringType>();
            descriptor.Field(m => m.Created).Type<DateTimeType>();
            descriptor.Field(m => m.CreatedBy).Type<StringType>();
            descriptor.Field(m => m.ItemRating).Type<IntType>();
            descriptor.Field(m => m.ItemText).Type<StringType>();
            descriptor.Field(m => m.ParentPostId).Type<StringType>();
            descriptor.Field(m => m.ProductId).Type<StringType>();
            descriptor.Field(m => m.ReviewLink).Type<StringType>();
            descriptor.Field(m => m.ReviewText).Type<StringType>();
            descriptor.Field(m => m.Updated).Type<DateTimeType>();
            descriptor.Field(m => m.UpdatedBy).Type<StringType>();
            descriptor.Field<UserPostResolver>(t => t.GetAccountRatings(default,default));
            descriptor.Field<UserPostResolver>(t => t.GetPostImages(default, default));
            descriptor.Field<UserPostResolver>(t => t.GetProduct(default, default));
            descriptor.Field<UserPostResolver>(t => t.GetUserAccount(default, default));
        }
    }
}
