using HotChocolate;
using HotChocolate.Resolvers;
using Ovid.Data;
using Ovid.Data.Models.Accounts;
using Ovid.Data.Models.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ovid.GraphQL.Extensions.Resolvers.Accounts
{
    public class UserIntrestResolver
    {
        private readonly OvidDbContext _ovidDb;


        public UserIntrestResolver(OvidDbContext ovidDb)
        {
            _ovidDb = ovidDb;
        }


        public UserAccount GetUser([Parent]UserIntrest intrest, IResolverContext ctx)
        {
            return _ovidDb.UserAccounts.Where(m => m.AccountId == intrest.AccountId).SingleOrDefault();
        }

        public IntrestList GetIntrest([Parent] UserIntrest intrest, IResolverContext ctx)
        {
            return _ovidDb.IntrestLists.Where(m => m.IntrestId == intrest.IntrestId).SingleOrDefault();
        }

    }
}
