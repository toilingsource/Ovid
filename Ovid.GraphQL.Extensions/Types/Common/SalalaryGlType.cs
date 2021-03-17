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
    public class SalalaryGlType : ObjectType<Salalary>
    {
        protected override void Configure(IObjectTypeDescriptor<Salalary> descriptor)
        {
            base.Configure(descriptor);
            descriptor.Field(m => m.SalaryId).Type<IdType>();
            descriptor.Field(m => m.EndRange).Type<DecimalType>();
            descriptor.Field(m => m.StartRange).Type<DecimalType>();
            descriptor.Field<SalalaryResolver>(t=>t.GetUserAccounts(default,default));
        }
    }
}
