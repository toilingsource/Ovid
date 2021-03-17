using Ovid.Data;
using Ovid.Data.Models.Accounts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ovid.GraphQL.Extensions
{
    public class OvidQuery
    {
        private readonly OvidDbContext _ovidDb;

        public OvidQuery(OvidDbContext ovidDb)
        {
            _ovidDb = ovidDb;
        }


        #region Accounts

        /// <summary>
        /// Get Account Types
        /// </summary>
        /// <returns></returns>
        public IEnumerable<AccountType> GetAccountTypes()
        {
            return _ovidDb.AccountTypes.OrderBy(m => m.Name).ToList();
        }

        /// <summary>
        /// Get Followers for user
        /// </summary>
        /// <param name="userId">user ID</param>
        /// <returns></returns>
        public IEnumerable<Followed> GetFollowers(string userId)
        {
            return _ovidDb.Followeds.Where(m => m.FollowedId == userId).ToList();
        }

        /// <summary>
        /// Get Followed Accounts for user
        /// </summary>
        /// <param name="userId">user id</param>
        /// <returns></returns>
        public IEnumerable<Followed> GetFollowed(string userId)
        {
            return _ovidDb.Followeds.Where(m => m.FollowerId == userId).ToList();
        }


        #endregion Accounts

        #region Advertising
        #endregion Advertising

        #region Campaigns
        #endregion Campaigns

        #region Common
        #endregion Common

        #region Marketers
        #endregion Marketers

        #region Posts
        #endregion Posts

        #region Products
        #endregion Products

        #region Ratings
        #endregion Ratings

        #region SocialMedia
        #endregion SocialMedia
    }
}
