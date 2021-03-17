using Newtonsoft.Json;
using Ovid.Data.Models.Accounts;
using Ovid.Tools;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Ovid.Data.Models.Products
{
    /// <summary>
    /// /User Product Click Tracking
    /// </summary>
    [GitLabDoc(typeof(UserProductClick))]
    public class UserProductClick
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
        public string ProductId { get; set; }
        /// <summary>
        /// Product Nav
        /// </summary>
        [JsonIgnore]
        [GitLabDocProperty]
        public virtual SponsoredProduct Product { get; set; }
        /// <summary>
        /// User
        /// </summary>
        [Required]
        [StringLength(150)]
        [GitLabDocProperty]
        public string AccountId { get; set; }
        /// <summary>
        /// User Nav
        /// </summary>
        [JsonIgnore]
        [GitLabDocProperty]
        public virtual UserAccount User { get; set; }
    }
}
