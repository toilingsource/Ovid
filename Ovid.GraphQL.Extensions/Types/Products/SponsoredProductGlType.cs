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
    public class SponsoredProductGlType : ObjectType<SponsoredProduct>
    {
        protected override void Configure(IObjectTypeDescriptor<SponsoredProduct> descriptor)
        {
            base.Configure(descriptor);
            descriptor.Field(m => m.ProductId).Type<IdType>();
            descriptor.Field(m => m.CategoryId).Type<IntType>();
            descriptor.Field(m => m.Created).Type<DateTimeType>();
            descriptor.Field(m => m.CreatedBy).Type<StringType>();
            descriptor.Field(m => m.Description).Type<StringType>();
            descriptor.Field(m => m.Infromation).Type<StringType>();
            descriptor.Field(m => m.InfulencePrice).Type<DecimalType>();
            descriptor.Field(m => m.KeyWords).Type<StringType>();
            descriptor.Field(m => m.MarkerterId).Type<StringType>();
            descriptor.Field(m => m.Name).Type<StringType>();
            descriptor.Field(m => m.NumberSold).Type<IntType>();
            descriptor.Field(m => m.Price).Type<DecimalType>();
            descriptor.Field(m => m.ProductLink).Type<StringType>();
            descriptor.Field(m => m.Updated).Type<DateTimeType>();
            descriptor.Field(m => m.UpdatedBy).Type<StringType>();
            descriptor.Field<SponsoredProductResolver>(t => t.GetMarketer(default,default));
            descriptor.Field<SponsoredProductResolver>(t => t.GetProductCategory(default, default));
            descriptor.Field<SponsoredProductResolver>(t => t.GetProductImages(default, default));
            descriptor.Field<SponsoredProductResolver>(t => t.GetUserProductClicks(default, default));
        }
    }
}
