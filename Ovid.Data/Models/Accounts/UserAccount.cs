using Newtonsoft.Json;
using Ovid.Data.Models.Advertising;
using Ovid.Data.Models.Campaigns;
using Ovid.Data.Models.Common;
using Ovid.Data.Models.Marketers;
using Ovid.Data.Models.Posts;
using Ovid.Data.Models.Products;
using Ovid.Data.Models.Ratings;
using Ovid.Data.Models.SocialMedia;
using Ovid.Tools;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Security.Cryptography;
using System.Text;

namespace Ovid.Data.Models.Accounts
{

    /// <summary>
    /// User Account Record
    /// </summary>
    [GitLabDoc(typeof(UserAccount))]
    public class UserAccount : AuditableBase<UserAccount>
    {
        /// <summary>
        /// Account Id
        /// </summary>
        [Key]
        [StringLength(150)]
        [GitLabDocProperty]
        public string AccountId { get; set; }
        /// <summary>
        ///Application User Id
        /// </summary>
        [Required]
        [StringLength(250)]
        [GitLabDocProperty]
        public string UserId { get; set; }
        /// <summary>
        /// Accout Type Id
        /// </summary>
        [Required]
        [StringLength(150)]
        [GitLabDocProperty]
        public string TypeId { get; set; }
        /// <summary>
        /// Account Type Nav
        /// </summary>
        [JsonIgnore]
        [GitLabDocProperty]
        public virtual AccountType AccountType { get; set; }
        /// <summary>
        /// Dispplay Name
        /// </summary>
        [Required]
        [StringLength(150)]
        [GitLabDocProperty]
        public string DisplayName { get; set; }
        /// <summary>
        /// Date Of Birth
        /// </summary>
        [GitLabDocProperty]
        public DateTime DateOfBirth { get; set; }
        /// <summary>
        /// Last Login Ip
        /// </summary>
        [StringLength(150)]
        [GitLabDocProperty]
        public string LastLoginIp { get; set; }
        /// <summary>
        /// Country
        /// </summary>
        [StringLength(150)]
        [GitLabDocProperty]
        public string Country { get; set; }
        /// <summary>
        /// Province / State
        /// </summary>
        [StringLength(150)]
        [GitLabDocProperty]
        public string Province { get; set; }
        /// <summary>
        /// City
        /// </summary>
        [StringLength(150)]
        [GitLabDocProperty]
        public string City { get; set; }
        /// <summary>
        /// Postal Code
        /// </summary>
        [StringLength(25)]
        [GitLabDocProperty]
        public string PostalCode { get; set; }
        /// <summary>
        /// Occupation Id
        /// </summary>
        [GitLabDocProperty]
        public long OcupationId { get; set; }
        /// <summary>
        /// /Ocupation Nav
        /// </summary>
        [GitLabDocProperty]
        [JsonIgnore]
        public virtual Ocupation Ocupation { get; set; }

        /// <summary>
        /// /Salary Id
        /// </summary>
        [GitLabDocProperty]
        public long SalaryId { get; set; }
        /// <summary>
        /// Salary Navigation
        /// </summary>
        [JsonIgnore]
        [GitLabDocProperty]
        public virtual Salalary Salalary { get; set; }
        /// <summary>
        /// Avatar
        /// </summary>
        [Required]
        [StringLength(255)]
        [GitLabDocProperty]
        public string Avatar { get; set; } = "default.png";

        /// <summary>
        /// Reputation Points
        /// </summary>
        [Required]
        [GitLabDocProperty]
        public long ReputationPoints { get; set; } = 0;

        /// <summary>
        /// Get Record Has
        /// </summary>
        /// <returns></returns>
        [GitLabDocMethod]
        public override string GetDataHash()
        {
            return base.GetHash(this);
        }

        /// <summary>
        /// User Post Nav
        /// </summary>
        [JsonIgnore]
        [GitLabDocProperty]
        public virtual ICollection<UserPost> UserPosts { get; set; }
        /// <summary>
        /// Post Images Nav
        /// </summary>
        [JsonIgnore]
        [GitLabDocProperty]
        public virtual ICollection<PostImage> PostImages { get; set; }
        /// <summary>
        /// Ratings Nav
        /// </summary>
        [JsonIgnore]
        [GitLabDocProperty]
        public virtual ICollection<AccountRating> Ratings { get; set; }
        /// <summary>
        /// Social Feeds Nav
        /// </summary>
        [JsonIgnore]
        [GitLabDocProperty]
        public virtual ICollection<SocialFeed> SocialFeeds { get; set; }
        /// <summary>
        /// Adds Nav
        /// </summary>
        [JsonIgnore]
        [GitLabDocProperty]
        public virtual ICollection<Advertisment> Advertisments { get; set; }
        /// <summary>
        /// Instrest Nav
        /// </summary>
        [JsonIgnore]
        [GitLabDocProperty]
        public virtual ICollection<UserIntrest> Intrests { get; set; }
        /// <summary>
        /// Followers Nav
        /// </summary>
        [JsonIgnore]
        [GitLabDocProperty]
        public virtual ICollection<Followed> Followers { get; set; }
        /// <summary>
        /// Followed Nav
        /// </summary>
        [JsonIgnore]
        [GitLabDocProperty]
        public virtual ICollection<Followed> Followed { get; set; }
        /// <summary>
        /// Campaigns Nav
        /// </summary>
        [JsonIgnore]
        [GitLabDocProperty]
        public virtual ICollection<Campaign> Campaigns { get; set; }
        /// <summary>
        /// Marketers Nav
        /// </summary>
        [JsonIgnore]
        [GitLabDocProperty]
        public virtual ICollection<Marketer> Marketers { get; set; }
        /// <summary>
        /// User Add Clicks Nav
        /// </summary>
        [JsonIgnore]
        [GitLabDocProperty]
        public virtual ICollection<UserAddClick> UserAddClicks { get; set; }
        /// <summary>
        /// Campaign Clicks Nav
        /// </summary>
        [JsonIgnore]
        [GitLabDocProperty]
        public virtual ICollection<UserCampaignClick> CampaignClicks { get; set; }
        /// <summary>
        /// Campaign Item Nav
        /// </summary>
        [JsonIgnore]
        [GitLabDocProperty]
        public virtual ICollection<UserCampaignItemClick> CampaignItemClicks { get; set; }
        /// <summary>
        /// Product Clicks Nav
        /// </summary>
        [JsonIgnore]
        [GitLabDocProperty]
        public virtual ICollection<UserProductClick> ProductClicks { get; set; }
    }
}
