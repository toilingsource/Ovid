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

namespace Ovid.GraphQL.Extensions.Resolvers.Common
{
    public class SalalaryResolver
    {
        private readonly OvidDbContext _ovidDb;

        public SalalaryResolver(OvidDbContext ovidDb)
        {
            _ovidDb = ovidDb;
        }



        public IEnumerable<UserAccount> GetUserAccounts([Parent] Salalary salalary, IResolverContext ctx)
        {
            return _ovidDb.UserAccounts.Where(m => m.SalaryId == salalary.SalaryId).ToList();
        }

    }
}
