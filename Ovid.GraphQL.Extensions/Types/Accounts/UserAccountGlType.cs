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
    public class UserAccountGlType : ObjectType<UserAccount>
    {

        protected override void Configure(IObjectTypeDescriptor<UserAccount> descriptor)
        {
            base.Configure(descriptor);
            descriptor.Field(m => m.AccountId).Type<IdType>();
            descriptor.Field(m => m.Avatar).Type<StringType>();
            descriptor.Field(m => m.City).Type<StringType>();
            descriptor.Field(m => m.Country).Type<StringType>();
            descriptor.Field(m => m.Created).Type<DateTimeType>();
            descriptor.Field(m => m.CreatedBy).Type<StringType>();
            descriptor.Field(m => m.DateOfBirth).Type<DateTimeType>();
            descriptor.Field(m => m.DisplayName).Type<StringType>();
            descriptor.Field(m => m.LastLoginIp).Type<StringType>();
            descriptor.Field(m => m.OcupationId).Type<IntType>();
            descriptor.Field(m => m.PostalCode).Type<StringType>();
            descriptor.Field(m => m.Province).Type<StringType>();
            descriptor.Field(m => m.ReputationPoints).Type<IntType>();
            descriptor.Field(m => m.SalaryId).Type<IntType>();
            descriptor.Field(m => m.TypeId).Type<StringType>();
            descriptor.Field(m => m.Updated).Type<DateTimeType>();
            descriptor.Field(m => m.UpdatedBy).Type<StringType>();
            descriptor.Field(m => m.UserId).Type<StringType>();
            descriptor.Field<UserAccountResolver>(t=>t.GetAccountRatings(default, default));
            descriptor.Field<UserAccountResolver>(t => t.GetAccountType(default, default));
            descriptor.Field<UserAccountResolver>(t => t.GetAdvertisments(default, default));
            descriptor.Field<UserAccountResolver>(t => t.GetCampaigns(default, default));
            descriptor.Field<UserAccountResolver>(t => t.GetFollowed(default, default));
            descriptor.Field<UserAccountResolver>(t => t.GetFollowers(default, default));
            descriptor.Field<UserAccountResolver>(t => t.GetMarketers(default, default));
            descriptor.Field<UserAccountResolver>(t => t.GetOcupation(default, default));
            descriptor.Field<UserAccountResolver>(t => t.GetPostImages(default, default));
            descriptor.Field<UserAccountResolver>(t => t.GetSalalary(default, default));
            descriptor.Field<UserAccountResolver>(t => t.GetSocialFeeds(default, default));
            descriptor.Field<UserAccountResolver>(t => t.GetUserAddClicks(default, default));
            descriptor.Field<UserAccountResolver>(t => t.GetUserCampaignClicks(default, default));
            descriptor.Field<UserAccountResolver>(t => t.GetUserCampaignItemClicks(default, default));
            descriptor.Field<UserAccountResolver>(t => t.GetUserIntrests(default, default));
            descriptor.Field<UserAccountResolver>(t => t.GetUserPosts(default, default));
            descriptor.Field<UserAccountResolver>(t => t.GetUserProductClicks(default, default));
        }
    }
}
