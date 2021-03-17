using Newtonsoft.Json;
using Ovid.Tools;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Ovid.Data.Models.Accounts
{
    /// <summary>
    /// Followed Users
    /// </summary>
    [GitLabDoc(typeof(Followed))]
    public class Followed 
    {
        /// <summary>
        /// Follow Id
        /// </summary>
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [GitLabDocProperty]
        public long FollowId { get; set; }
        /// <summary>
        /// Follower
        /// </summary>
        [Required]
        [StringLength(150)]
        [GitLabDocProperty]
        public string FollowerId { get; set; }
        /// <summary>
        /// Follwer Nvigation
        /// </summary>
        [JsonIgnore]
        [GitLabDocProperty]
        public virtual UserAccount Follower { get; set; }
        /// <summary>
        /// Followed User
        /// </summary>
        [Required]
        [StringLength(150)]
        [GitLabDocProperty]
        public string FollowedId { get; set; }
        /// <summary>
        /// Followed Navigation
        /// </summary>
        [JsonIgnore]
        [GitLabDocProperty]
        public virtual UserAccount FollowedAccount { get; set; }
        /// <summary>
        /// Send User notifications on post
        /// </summary>
        [Required]
        [GitLabDocProperty]
        public bool SendNotifications { get; set; } = true;


    }
}
