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
    public class UserAddClickGlType : ObjectType<UserAddClick>
    {
        protected override void Configure(IObjectTypeDescriptor<UserAddClick> descriptor)
        {
            base.Configure(descriptor);
            descriptor.Field(m => m.ClickId).Type<IdType>();
            descriptor.Field(m => m.AccountId).Type<StringType>();
            descriptor.Field(m => m.AddId).Type<IntType>();
            descriptor.Field(m => m.ClickDate).Type<DateTimeType>();
            descriptor.Field<UserAddClickResolver>(t=>t.GetAdvertisment(default,default));
            descriptor.Field<UserAddClickResolver>(t => t.GetUser(default, default));
        }
    }
}
