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
    /// <summary>
    /// Account Type
    /// </summary>
    public class AccountTypeGlType : ObjectType<AccountType>
    {

        protected override void Configure(IObjectTypeDescriptor<AccountType> descriptor)
        {
            base.Configure(descriptor);
            descriptor.Field(m => m.AccontTypeId).Type<IdType>();
            descriptor.Field(m => m.Description).Type<StringType>();
            descriptor.Field<AccountTypeResolver>(m => m.GetUserAccounts(default, default));
        }

    }
}
