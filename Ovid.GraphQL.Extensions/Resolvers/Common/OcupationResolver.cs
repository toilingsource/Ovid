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
    public class OcupationResolver
    {


        private readonly OvidDbContext _ovidDb;

        public OcupationResolver(OvidDbContext ovidDb)
        {
            _ovidDb = ovidDb;
        }


        public IEnumerable<UserAccount> GetUserAccounts([Parent] Ocupation ocupation, IResolverContext ctx)
        {
            return _ovidDb.UserAccounts.Where(m => m.OcupationId == ocupation.OcupationId).ToList();
        } 
    }
}
