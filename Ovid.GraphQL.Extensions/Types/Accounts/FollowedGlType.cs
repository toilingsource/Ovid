using HotChocolate.Types;
using Ovid.Data;
using Ovid.Data.Models.Accounts;
using Ovid.GraphQL.Extensions.Resolvers.Accounts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ovid.GraphQL.Extensions.Types.Accounts
{
    public class FollowedGlType : ObjectType<Followed>
    {

        protected override void Configure(IObjectTypeDescriptor<Followed> descriptor)
        {
            base.Configure(descriptor);
            descriptor.Field(m => m.FollowId).Type<IdType>();
            descriptor.Field(m => m.FollowedId).Type<StringType>();
            descriptor.Field(m => m.FollowerId).Type<StringType>();
            descriptor.Field(m => m.SendNotifications).Type<BooleanType>();
            descriptor.Field<FollowedResolver>(t=>t.GetFollowed(default,default));
            descriptor.Field<FollowedResolver>(t=>t.GetFollower(default,default));
        }




    }
}
