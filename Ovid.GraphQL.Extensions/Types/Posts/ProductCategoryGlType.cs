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
    public class ProductCategoryGlType : ObjectType<ProductCategory>
    {
        protected override void Configure(IObjectTypeDescriptor<ProductCategory> descriptor)
        {
            base.Configure(descriptor);
            descriptor.Field(m => m.CategoryId).Type<IdType>();
            descriptor.Field(m => m.Name).Type<StringType>();
            descriptor.Field(m => m.Icon).Type<StringType>();
            descriptor.Field<ProductCategoryResolver>(t => t.GetProducts(default,default));

        }
    }
}
