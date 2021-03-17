using Newtonsoft.Json;
using Ovid.Tools;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Ovid.Data.Models.Campaigns
{
    /// <summary>
    /// Campaign Types
    /// </summary>
    [GitLabDoc(typeof(CampaignType))]
    public class CampaignType
    {
        /// <summary>
        /// Record Id
        /// </summary>
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [GitLabDocProperty]
        public long TypeId { get; set; }
        /// <summary>
        /// Type Name
        /// </summary>
        [Required]
        [StringLength(150)]
        [GitLabDocProperty]
        public string Name { get; set; }
        /// <summary>
        /// Description
        /// </summary>
        [Required]
        [StringLength(500)]
        [GitLabDocProperty]
        public string Description { get; set; }

        /// <summary>
        /// Campaign Nav
        /// </summary>
        [JsonIgnore]
        [GitLabDocProperty]
        public virtual ICollection<Campaign> Campaigns { get; set; }


        
    }
}
