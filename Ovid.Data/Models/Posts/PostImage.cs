using Newtonsoft.Json;
using Ovid.Data.Models.Accounts;
using Ovid.Tools;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Ovid.Data.Models.Posts
{
    /// <summary>
    /// /Post Image Record
    /// </summary>
    [GitLabDoc(typeof(PostImage))]
    public class PostImage 
    {
        /// <summary>
        /// Record Id
        /// </summary>
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [GitLabDocProperty]
        public long ImageId { get; set; }

        /// <summary>
        /// Image Alt Text
        /// </summary>
        [StringLength(150)]
        [GitLabDocProperty]
        public string AltText { get; set; }

        /// <summary>
        /// Image Data
        /// </summary>
        [Required]
        [GitLabDocProperty]
        public string ImageData { get; set; }

        /// <summary>
        /// Account 
        /// </summary>
        [GitLabDocProperty]
        public string AccountId { get; set; }
        /// <summary>
        /// User account nav
        /// </summary>
        [JsonIgnore]
        [GitLabDocProperty]
        public virtual UserAccount User { get; set; }

        /// <summary>
        /// Post
        /// </summary>
        [GitLabDocProperty]
        public string PostId { get; set; }
        /// <summary>
        /// User Post Nav
        /// </summary>
        [JsonIgnore]
        [GitLabDocProperty]
        public virtual UserPost Post { get; set; }

    }
}
