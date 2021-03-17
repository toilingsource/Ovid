using Newtonsoft.Json;
using Ovid.Data.Models.Accounts;
using Ovid.Data.Models.Common;
using Ovid.Data.Models.Products;
using Ovid.Tools;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Ovid.Data.Models.Campaigns
{
    /// <summary>
    /// Promotional Campign 
    /// </summary>
    [GitLabDoc(typeof(Campaign))]
    public class Campaign : AuditableBase<Campaign>
    {

        /// <summary>
        /// Campaign Id
        /// </summary>
        [Key]
        [StringLength(150)]
        [GitLabDocProperty]
        public string CampaignId { get; set; }
        /// <summary>
        /// Campaign Type Id
        /// </summary>
        [Required]
        [GitLabDocProperty]
        public long TypeId { get; set; }
        /// <summary>
        /// Campaign Type Name
        /// </summary>
        [JsonIgnore]
        [GitLabDocProperty]
        public virtual CampaignType CampaignType { get; set; }
        /// <summary>
        /// Account Id
        /// </summary>
        [Required]
        [StringLength(150)]
        [GitLabDocProperty]
        public string AccountId { get; set; }
        /// <summary>
        /// User Account Nav
        /// </summary>
        [JsonIgnore]
        [GitLabDocProperty]
        public virtual UserAccount User { get; set; }
        /// <summary>
        /// Campaign Starts
        /// </summary>
        [Required]
        [GitLabDocProperty]
        public DateTime StartDate { get; set; }
        /// <summary>
        /// Campaign Ends
        /// </summary>
        [Required]
        [GitLabDocProperty]
        public DateTime EndDate { get; set; }
        /// <summary>
        /// Banner Image
        /// </summary>
        [Required]
        [GitLabDocProperty]
        public string Graphic { get; set; }
        /// <summary>
        /// Banner Width
        /// </summary>
        [Required]
        [GitLabDocProperty]
        public int Width { get; set; }
        /// <summary>
        /// Banner Height
        /// </summary>
        [Required]
        [GitLabDocProperty]
        public int Height { get; set; }
        /// <summary>
        /// Banner Clicks
        /// </summary>
        [Required]
        [GitLabDocProperty]
        public long Clicks { get; set; } = 0;
        /// <summary>
        /// Banner Impressions
        /// </summary>
        [Required]
        [GitLabDocProperty]
        public long Impressions { get; set; } = 0;

       /// <summary>
       /// Items Nav
       /// </summary>
        [JsonIgnore]
        [GitLabDocProperty]
        public virtual ICollection<CampaignItem> Items { get; set; }
        /// <summary>
        /// User Clicks Nav
        /// </summary>
        [JsonIgnore]
        [GitLabDocProperty]
        public virtual ICollection<UserCampaignClick> UserClicks { get; set; }

    }
}
