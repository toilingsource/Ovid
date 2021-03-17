using Newtonsoft.Json;
using Ovid.Data.Models.Products;
using Ovid.Tools;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Ovid.Data.Models.Campaigns
{
    /// <summary>
    /// Campaing Items
    /// </summary>
    [GitLabDoc(typeof(CampaignItem))]
    public class CampaignItem
    {
        /// <summary>
        /// Record Id
        /// </summary>
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [GitLabDocProperty]
        public long CampItemId { get; set; }
        /// <summary>
        /// Campaign
        /// </summary>
        [Required]
        [StringLength(150)]
        [GitLabDocProperty]
        public string CampaignId { get; set; }
        /// <summary>
        /// Capaign Nav
        /// </summary>
        [JsonIgnore]
        [GitLabDocProperty]
        public virtual Campaign Campaign { get; set; }
        /// <summary>
        /// Product
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
        /// Sale Price
        /// </summary>
        [Required]
        [GitLabDocProperty]
        public decimal SalePrice { get; set; }
        /// <summary>
        /// Reqular Price
        /// </summary>
        [Required]
        [GitLabDocProperty]
        public decimal RegularPrice { get; set; }
        /// <summary>
        /// Sale tag line or text (optional)
        /// </summary>
        [StringLength(150)]
        [GitLabDocProperty]
        public string SalesText { get; set; }
        /// <summary>
        /// Affiliate Link
        /// </summary>
        [Required]
        [StringLength(255)]
        [GitLabDocProperty]
        public string CampaignLink { get; set; }
        /// <summary>
        /// Affiliiate Link Clicks
        /// </summary>
        [Required]
        [GitLabDocProperty]
        public long Clicks { get; set; }
        /// <summary>
        /// Campaign Item Nav
        /// </summary>
        [JsonIgnore]
        [GitLabDocProperty]
        public virtual ICollection<UserCampaignItemClick> ItemClicks { get; set; }

    }
}
