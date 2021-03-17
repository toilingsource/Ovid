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
    public class PostImageGlType : ObjectType<PostImage>
    {
        protected override void Configure(IObjectTypeDescriptor<PostImage> descriptor)
        {
            base.Configure(descriptor);
            descriptor.Field(m => m.ImageId).Type<IdType>();
            descriptor.Field(m => m.AccountId).Type<StringType>();
            descriptor.Field(m => m.AltText).Type<StringType>();
            descriptor.Field(m => m.ImageData).Type<StringType>();
            descriptor.Field(m => m.PostId).Type<StringType>();
            descriptor.Field<PostImageResolver>(t => t.GetUserAccount(default,default));
            descriptor.Field<PostImageResolver>(t => t.GetUserPost(default, default));

        }
    }
}
