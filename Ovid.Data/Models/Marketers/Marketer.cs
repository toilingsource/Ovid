using Newtonsoft.Json;
using Ovid.Data.Models.Accounts;
using Ovid.Data.Models.Advertising;
using Ovid.Data.Models.Common;
using Ovid.Data.Models.Products;
using Ovid.Tools;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Ovid.Data.Models.Marketers
{
    /// <summary>
    /// Marketer Data
    /// </summary>
    [GitLabDoc(typeof(Marketer))]
    public class Marketer : AuditableBase<Marketer>
    {
        /// <summary>
        /// Marketer Id
        /// </summary>
        [Key]
        [StringLength(150)]
        [GitLabDocProperty]
        public string MarketerId { get; set; }
        /// <summary>
        /// Manufacture Name
        /// </summary>
        [Required]
        [StringLength(150)]
        [GitLabDocProperty]
        public string Name { get; set; }
        /// <summary>
        /// Logo
        /// </summary>
        [Required]
        [GitLabDocProperty]
        public string Logo { get; set; }
        /// <summary>
        /// Main Web Url
        /// </summary>
        [Required]
        [StringLength(250)]
        [GitLabDocProperty]
        public string WebSite { get; set; }
        /// <summary>
        /// Support Url
        /// </summary>
        [StringLength(250)]
        [GitLabDocProperty]
        public string SupportUrl { get; set; }
        /// <summary>
        /// Description
        /// </summary>
        [Required]
        [GitLabDocProperty]
        public string Description { get; set; }
        /// <summary>
        /// Contact Email
        /// </summary>
        [Required]
        [StringLength(250)]
        [GitLabDocProperty]
        public string ContactEmail { get; set; }
        /// <summary>
        /// Support Phone
        /// </summary>
        [StringLength(25)]
        [GitLabDocProperty]
        public string SupportPhone { get; set; }
        /// <summary>
        /// Record Creted By
        /// </summary>
        [Required]
        [StringLength(250)]
        [GitLabDocProperty]
        public string UserId { get; set; }
        /// <summary>
        /// User Account Navigation
        /// </summary>
        [JsonIgnore]
        [GitLabDocProperty]
        public virtual UserAccount User { get; set; }


        /// <summary>
        /// Products Nav
        /// </summary>
        [JsonIgnore]
        [GitLabDocProperty]
        public virtual ICollection<SponsoredProduct> SponsoredProducts { get; set; }
        /// <summary>
        /// Adds Nav
        /// </summary>
        [JsonIgnore]
        [GitLabDocProperty]
        public virtual ICollection<Advertisment> Advertisments { get; set; }

    }
}
