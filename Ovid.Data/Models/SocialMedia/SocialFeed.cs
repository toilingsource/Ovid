using Newtonsoft.Json;
using Ovid.Data.Models.Accounts;
using Ovid.Data.Models.Common;
using Ovid.Tools;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Ovid.Data.Models.SocialMedia
{
    /// <summary>
    /// User Connected Social Media Feeds
    /// </summary>
    [GitLabDoc(typeof(SocialFeed))]
    public class SocialFeed : AuditableBase<SocialFeed>
    {

        /// <summary>
        /// Feed Id
        /// </summary>
        [Key]
        [StringLength(150)]
        [GitLabDocProperty]
        public long FeedId { get; set; }
        /// <summary>
        /// Accoutn
        /// </summary>
        [Required]
        [StringLength(150)]
        [GitLabDocProperty]
        public string AccountId { get; set; }
        /// <summary>
        /// User Account nav
        /// </summary>
        [JsonIgnore]
        [GitLabDocProperty]
        public UserAccount User { get; set; }
        /// <summary>
        /// Provider
        /// </summary>
        [Required]
        [StringLength(150)]
        [GitLabDocProperty]
        public string Provider { get; set; }
        /// <summary>
        /// Pull Feeds
        /// </summary>
        [Required]
        [GitLabDocProperty]
        public bool PullFeeds { get; set; } = false;
        /// <summary>
        /// Cross Post feeds from this site
        /// </summary>
        [Required]
        [GitLabDocProperty]
        public bool CrossPost { get; set; } = true;
        /// <summary>
        /// Current Followers
        /// </summary>
        [Required]
        [GitLabDocProperty]
        public long Followers { get; set; } = 0;
        /// <summary>
        /// External Link
        /// </summary>
        [Required]
        [StringLength(255)]
        [GitLabDocProperty]
        public string Link { get; set; } = string.Empty;


    }
}
