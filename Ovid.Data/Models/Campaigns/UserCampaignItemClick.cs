using Newtonsoft.Json;
using Ovid.Data.Models.Accounts;
using Ovid.Tools;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Ovid.Data.Models.Campaigns
{
    /// <summary>
    /// User Campign Click Tracing
    /// </summary>
    [GitLabDoc(typeof(UserCampaignItemClick))]
    public class UserCampaignItemClick
    {
        /// <summary>
        /// Record Id
        /// </summary>
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [GitLabDocProperty]
        public long ClickId { get; set; }
        /// <summary>
        /// Clicked Date
        /// </summary>
        [Required]
        [GitLabDocProperty]
        public DateTime ClickDate { get; set; } = DateTime.Now;
        /// <summary>
        /// Campaign
        /// </summary>
        [Required]
        [StringLength(150)]
        [GitLabDocProperty]
        public long CampItemId { get; set; }
        /// <summary>
        /// Item Nav
        /// </summary>
        [JsonIgnore]
        [GitLabDocProperty]
        public virtual CampaignItem Item { get; set; }
        /// <summary>
        /// User
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
    }
}
