using HotChocolate.Types;
using Ovid.Data.Models.Products;
using Ovid.GraphQL.Extensions.Resolvers.Products;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ovid.GraphQL.Extensions.Types.Products
{
    public class UserProductClickGlType : ObjectType<UserProductClick>
    {
        protected override void Configure(IObjectTypeDescriptor<UserProductClick> descriptor)
        {
            base.Configure(descriptor);
            descriptor.Field(m => m.ClickId).Type<IdType>();
            descriptor.Field(m => m.AccountId).Type<StringType>();
            descriptor.Field(m => m.ClickDate).Type<StringType>();
            descriptor.Field(m => m.ProductId).Type<StringType>();
            descriptor.Field<UserProductClickResolver>(t => t.GetProduct(default,default));
            descriptor.Field<UserProductClickResolver>(t => t.GetUserAccount(default, default));
        }
    }
}
