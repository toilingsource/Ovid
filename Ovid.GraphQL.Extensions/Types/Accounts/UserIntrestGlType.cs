using HotChocolate.Types;
using Ovid.Data.Models.Accounts;
using Ovid.GraphQL.Extensions.Resolvers.Accounts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ovid.GraphQL.Extensions.Types.Accounts
{
    public class UserIntrestGlType : ObjectType<UserIntrest>
    {

        protected override void Configure(IObjectTypeDescriptor<UserIntrest> descriptor)
        {
            base.Configure(descriptor);
            descriptor.Field(m => m.IntrestId).Type<IdType>();
            descriptor.Field(m => m.AccountId).Type<StringType>();
            descriptor.Field(m => m.UserIntrestId).Type<IntType>();
            descriptor.Field<UserIntrestResolver>(t=>t.GetIntrest(default,default));
            descriptor.Field<UserIntrestResolver>(t => t.GetUser(default, default));
        }
    }
}
