using HotChocolate.Types;
using Ovid.Data.Models.Products;
using Ovid.GraphQL.Extensions.Resolvers.Posts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ovid.GraphQL.Extensions.Types.Posts
{
    public class ProductImageGlType : ObjectType<ProductImage>
    {
        protected override void Configure(IObjectTypeDescriptor<ProductImage> descriptor)
        {
            base.Configure(descriptor);
            descriptor.Field(m => m.ImageId).Type<IdType>();
            descriptor.Field(m => m.AltText).Type<StringType>();
            descriptor.Field(m => m.Created).Type<StringType>();
            descriptor.Field(m => m.CreatedBy).Type<StringType>();
            descriptor.Field(m => m.ImageData).Type<StringType>();
            descriptor.Field(m => m.ImageId).Type<StringType>();
            descriptor.Field(m => m.ProductId).Type<StringType>();
            descriptor.Field(m => m.Updated).Type<StringType>();
            descriptor.Field(m => m.UpdatedBy).Type<StringType>();
            descriptor.Field<ProductImageResolver>(t=>t.GetProduct(default,default));

        }
    }
}
