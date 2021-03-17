using HotChocolate.Types;
using Ovid.Data.Models.Common;
using Ovid.GraphQL.Extensions.Resolvers.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ovid.GraphQL.Extensions.Types.Common
{
    public class OcupationGlType :ObjectType<Ocupation>
    {
        protected override void Configure(IObjectTypeDescriptor<Ocupation> descriptor)
        {
            base.Configure(descriptor);
            descriptor.Field(m => m.OcupationId).Type<IdType>();
            descriptor.Field(m => m.Name).Type<StringType>();
            descriptor.Field<OcupationResolver>(t=>t.GetUserAccounts(default,default));

        }
    }
}
