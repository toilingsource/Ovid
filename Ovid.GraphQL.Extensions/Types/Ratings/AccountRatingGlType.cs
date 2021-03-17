using HotChocolate.Types;
using Ovid.Data.Models.Ratings;
using Ovid.GraphQL.Extensions.Resolvers.Ratings;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ovid.GraphQL.Extensions.Types.Ratings
{
    public class AccountRatingGlType : ObjectType<AccountRating>
    {

        protected override void Configure(IObjectTypeDescriptor<AccountRating> descriptor)
        {
            base.Configure(descriptor);
            descriptor.Field(m => m.RattingId).Type<IdType>();
            descriptor.Field(m => m.AccountId).Type<StringType>();
            descriptor.Field(m => m.Created).Type<DateTimeType>();
            descriptor.Field(m => m.CreatedBy).Type<StringType>();
            descriptor.Field(m => m.PostId).Type<StringType>();
            descriptor.Field(m => m.Rating).Type<IntType>();
            descriptor.Field(m => m.RatingText).Type<StringType>();
            descriptor.Field(m => m.Updated).Type<DateTimeType>();
            descriptor.Field(m => m.UpdatedBy).Type<StringType>();
            descriptor.Field<AccountRatingResolver>(t => t.GetUserAccount(default,default));
            descriptor.Field<AccountRatingResolver>(t => t.GetUserPost(default, default));
        }
    }
}
