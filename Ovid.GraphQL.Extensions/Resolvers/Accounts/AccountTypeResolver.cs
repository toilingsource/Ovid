using HotChocolate;
using HotChocolate.Resolvers;
using Ovid.Data;
using Ovid.Data.Models.Accounts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ovid.GraphQL.Extensions.Resolvers.Accounts
{
    /// <summary>
    /// Account Type Reolver
    /// </summary>
    public class AccountTypeResolver
    {

        private readonly OvidDbContext _ovidDb;


        public AccountTypeResolver(OvidDbContext ovidDb)
        {
            _ovidDb = ovidDb;
        }


        public IEnumerable<UserAccount> GetUserAccounts([Parent] AccountType account, IResolverContext ctx)
        {
            return _ovidDb.UserAccounts.Where(m => m.TypeId == account.AccontTypeId).ToList();
        }


    }
}
