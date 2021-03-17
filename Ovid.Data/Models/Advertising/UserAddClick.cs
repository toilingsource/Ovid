using Newtonsoft.Json;
using Ovid.Data.Models.Accounts;
using Ovid.Data.Models.Common;
using Ovid.Tools;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Ovid.Data.Models.Advertising
{
    /// <summary>
    /// User Adveritisment Clicked
    /// </summary>
    [GitLabDoc(typeof(UserAddClick))]
    public class UserAddClick 
    {
        /// <summary>
        /// Record ID
        /// </summary>
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [GitLabDocProperty]
        public long ClickId { get; set; }
        /// <summary>
        /// Advertisement
        /// </summary>
        [Required]
        [GitLabDocProperty]
        public long AddId { get; set; }
        /// <summary>
        /// Add Nav
        /// </summary>
        [JsonIgnore]
        [GitLabDocProperty]
        public Advertisment Advertisment { get; set; }
        /// <summary>
        /// User account
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
        /// Clicked Date
        /// </summary>
        [Required]
        [GitLabDocProperty]
        public DateTime ClickDate { get; set; } = DateTime.Now;

    }
}
