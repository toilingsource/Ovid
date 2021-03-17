using Newtonsoft.Json;
using Ovid.Data.Models.Accounts;
using Ovid.Data.Models.Common;
using Ovid.Data.Models.Products;
using Ovid.Data.Models.Ratings;
using Ovid.Tools;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Ovid.Data.Models.Posts
{
    /// <summary>
    /// User Item Post
    /// </summary>
    [GitLabDoc(typeof(UserPost))]
    public class UserPost : AuditableBase<UserPost>
    {
        /// <summary>
        /// Post Id
        /// </summary>
        [Key]
        [StringLength(150)]
        [GitLabDocProperty]
        public string PostId { get; set; }
        /// <summary>
        /// User Account
        /// </summary>
        [Required]
        [StringLength(150)]
        [GitLabDocProperty]
        public string AccountId { get; set; }
        /// <summary>
        /// User account Nav
        /// </summary>
        [JsonIgnore]
        [GitLabDocProperty]
        public virtual UserAccount UserAccount { get; set; }
        /// <summary>
        /// Item Text
        /// </summary>
        [Required]
        [StringLength(500)]
        [GitLabDocProperty]
        public string ItemText { get; set; }
        /// <summary>
        /// Item Rating
        /// </summary>
        [Required]
        [GitLabDocProperty]
        public int ItemRating { get; set; }
        /// <summary>
        /// Review Url Link
        /// </summary>
        [GitLabDocProperty]
        public string ReviewLink { get; set; } = string.Empty;
        /// <summary>
        /// Review Text
        /// </summary>
        [GitLabDocProperty]
        public string ReviewText { get; set; } = string.Empty;
        /// <summary>
        /// Product Id if Sponsored
        /// </summary>
        [StringLength(150)]
        [GitLabDocProperty]
        public string ProductId { get; set; } = string.Empty;
        /// <summary>
        /// Product Nav
        /// </summary>
        [JsonIgnore]
        [GitLabDocProperty]
        public virtual SponsoredProduct Product { get; set; } = null;
        /// <summary>
        /// Parent post Id
        /// </summary>
        [StringLength(150)]
        [GitLabDocProperty]
        public string ParentPostId { get; set; } = string.Empty;
        /// <summary>
        /// Rating Nav
        /// </summary>
        [JsonIgnore]
        [GitLabDocProperty]
        public virtual ICollection<AccountRating> Ratings { get; set; }
        /// <summary>
        /// Images Nav
        /// </summary>
        [JsonIgnore]
        [GitLabDocProperty]
        public virtual ICollection<PostImage> Images { get; set; }
    }
}
