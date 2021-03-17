using Newtonsoft.Json;
using Ovid.Data.Models.Common;
using Ovid.Tools;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Ovid.Data.Models.Accounts
{
    /// <summary>
    /// User Intrest 
    /// </summary>
    [GitLabDoc(typeof(Followed))]
    public class UserIntrest
    {
        /// <summary>
        /// Intrest Id
        /// </summary>
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [GitLabDocProperty]
        public long UserIntrestId { get; set; }
        /// <summary>
        /// Account 
        /// </summary>
        [Required]
        [StringLength(150)]
        [GitLabDocProperty]
        public string AccountId { get; set; }
        /// <summary>
        /// Account Navigation Property
        /// </summary>
        [JsonIgnore]
        [GitLabDocProperty]
        public virtual UserAccount User { get; set; }
        /// <summary>
        /// Intrest 
        /// </summary>
        [Required]
        [GitLabDocProperty]
        public long IntrestId { get; set; }
        /// <summary>
        /// Iintrest Navigation Property
        /// </summary>
        [JsonIgnore]
        [GitLabDocProperty]
        public virtual IntrestList Intrest { get; set; }
    }
}
