using Newtonsoft.Json;
using Ovid.Data.Models.Accounts;
using Ovid.Data.Models.Common;
using Ovid.Data.Models.Marketers;
using Ovid.Tools;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Ovid.Data.Models.Advertising
{
    /// <summary>
    /// Advertising Material
    /// </summary>
    [GitLabDoc(typeof(Advertisment))]
    public class Advertisment :AuditableBase<Advertisment>
    {
        /// <summary>
        /// Add Id
        /// </summary>
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [GitLabDocProperty]
        public long AddId { get; set; }

        /// <summary>
        /// Account Id
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
        /// Markerter Id
        /// </summary>
        [Required]
        [StringLength(150)]
        [GitLabDocProperty]
        public string MarketerId { get; set; }
        /// <summary>
        /// Mareter Nav
        /// </summary>
        [GitLabDocProperty]
        [JsonIgnore]
        public virtual Marketer Markerter { get; set; }
        /// <summary>
        /// Image Alt Text
        /// </summary>
        [Required]
        [StringLength(150)]
        [GitLabDocProperty]
        public string AltText { get; set; }
        /// <summary>
        /// Image Data
        /// </summary>
        [Required]
        [GitLabDocProperty]
        public string AddData { get; set; }
        /// <summary>
        /// Number of Clicks
        /// </summary>
        [Required]
        [GitLabDocProperty]
        public long Clicks { get; set; } = 0;
        /// <summary>
        /// Number of Impressions shown
        /// </summary>
        [Required]
        [GitLabDocProperty]
        public long Impressions { get; set; } = 0;
        /// <summary>
        /// Add Roatation Weight
        /// </summary>
        [Required]
        public float Weight { get; set; } = 1;
        /// <summary>
        /// Start Date
        /// </summary>
        [Required]
        [GitLabDocProperty]
        public DateTime StartDate { get; set; }
        /// <summary>
        /// End Date
        /// </summary>
        [Required]
        [GitLabDocProperty]
        public DateTime EndDate { get; set; }
        /// <summary>
        /// Add Clicks Nav
        /// </summary>
        [JsonIgnore]
        [GitLabDocProperty]
        public virtual ICollection<UserAddClick> AddClicks { get; set; }

    }
}
