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
    public class IntrestListResolver
    {
        private readonly OvidDbContext _ovidDb;

        public IntrestListResolver(OvidDbContext ovidDb)
        {
            _ovidDb = ovidDb;
        }


        public IEnumerable<UserIntrest> GetUserIntrests([Parent] IntrestList list, IResolverContext ctx)
        {
            return _ovidDb.UserIntrests.Where(m => m.IntrestId == list.IntrestId).ToList();
        }
    }
}
