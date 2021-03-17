using Newtonsoft.Json;
using Ovid.Data.Models.Accounts;
using Ovid.Data.Models.Common;
using Ovid.Data.Models.Posts;
using Ovid.Tools;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Ovid.Data.Models.Ratings
{
    /// <summary>
    /// Account Post Ratings
    /// </summary>
    [GitLabDoc(typeof(AccountRating))]
    public class AccountRating : AuditableBase<AccountRating>
    {
        /// <summary>
        /// Rating Id
        /// </summary>
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [GitLabDocProperty]
        public long RattingId { get; set; }
        /// <summary>
        /// Post ID
        /// </summary>
        [Required]
        [StringLength(150)]
        [GitLabDocProperty]
        public string PostId { get; set; }
        /// <summary>
        /// USer Post Nav
        /// </summary>
        [JsonIgnore]
        [GitLabDocProperty]
        public virtual UserPost UserPost { get; set; }
        /// <summary>
        /// User Account
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
        public virtual UserAccount UserAccount { get; set; }
        /// <summary>
        /// Rating
        /// </summary>
        [Required]
        [GitLabDocProperty]
        public int Rating { set; get; }
        /// <summary>
        /// Rating Message
        /// </summary>
        [StringLength(250)]
        [GitLabDocProperty]
        public string RatingText { get; set; }

    }
}
