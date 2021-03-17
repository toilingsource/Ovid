using HotChocolate;
using HotChocolate.Resolvers;
using Ovid.Data;
using Ovid.Data.Models.Accounts;
using Ovid.Data.Models.Advertising;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ovid.GraphQL.Extensions.Resolvers.Advertising
{
    public class UserAddClickResolver

    {
        private readonly OvidDbContext _ovidDb;

        public UserAddClickResolver(OvidDbContext ovidDb)
        {
            _ovidDb = ovidDb;
        }


        public UserAccount GetUser([Parent] UserAddClick click, IResolverContext cxt)
        {
            return _ovidDb.UserAccounts.Where(m => m.AccountId == click.AccountId).SingleOrDefault();
        }


        public Advertisment GetAdvertisment([Parent] UserAddClick click, IResolverContext cxt)
        {
            return _ovidDb.Advertisments.Where(m => m.AddId == click.AddId).SingleOrDefault();
        }

    }
}
