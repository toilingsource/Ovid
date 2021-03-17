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
    public class IntrestListGlType : ObjectType<IntrestList>
    {
        protected override void Configure(IObjectTypeDescriptor<IntrestList> descriptor)
        {
            base.Configure(descriptor);
            descriptor.Field(m => m.IntrestId).Type<IdType>();
            descriptor.Field(m => m.Intrest).Type<StringType>();
            descriptor.Field<IntrestListResolver>(t => t.GetUserIntrests(default, default));
        }
    }
}
