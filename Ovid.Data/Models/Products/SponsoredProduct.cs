using Newtonsoft.Json;
using Ovid.Data.Models.Common;
using Ovid.Data.Models.Marketers;
using Ovid.Tools;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Ovid.Data.Models.Products
{
    /// <summary>
    /// Sponsored Products
    /// </summary>
    [GitLabDoc(typeof(UserProductClick))]
    public class SponsoredProduct : AuditableBase<SponsoredProduct>
    {

        /// <summary>
        /// /Product Id
        /// </summary>
        [Key]
        [StringLength(150)]
        [GitLabDocProperty]
        public string ProductId { get; set; }

        /// <summary>
        /// Manufacture
        /// </summary>
        [Required]
        [StringLength(150)]
        [GitLabDocProperty]
        public string MarkerterId { get; set; }
        /// <summary>
        /// Marketer Nav
        /// </summary>
        [JsonIgnore]
        [GitLabDocProperty]
        public virtual Marketer Marketer { get; set; }

        /// <summary>
        /// Product Category
        /// </summary>
        [Required]
        [GitLabDocProperty]
        public long CategoryId { get; set; }
        /// <summary>
        /// Category Nav
        /// </summary>
        [JsonIgnore]
        [GitLabDocProperty]
        public virtual ProductCategory Category { get; set; }

        /// <summary>
        /// Product Name
        /// </summary>
        [Required]
        [StringLength(250)]
        [GitLabDocProperty]
        public string Name { get; set; }

        /// <summary>
        /// Web Url Link
        /// </summary>
        [Required]
        [GitLabDocProperty]
        [StringLength(250)]
        public string ProductLink { get; set; }

        /// <summary>
        /// Description
        /// </summary>
        [Required]
        [GitLabDocProperty]
        public string Description { get; set; }

        /// <summary>
        /// Extra Infroamiton
        /// </summary>
        [GitLabDocProperty]
        public string Infromation { get; set; }

        /// <summary>
        /// Sale Price
        /// </summary>
        [Required]
        [GitLabDocProperty]
        public decimal Price { get; set; }

        /// <summary>
        /// Influener Pay Out
        /// </summary>
        [Required]
        [GitLabDocProperty]
        public decimal InfulencePrice { get; set; }

        /// <summary>
        /// Units Sold
        /// </summary>
        [Required]
        [GitLabDocProperty]
        public long NumberSold { get; set; } = 0;

        /// <summary>
        /// product Key Terms
        /// </summary>
        [GitLabDocProperty]
        public string KeyWords { get; set; }

        /// <summary>
        /// Images Nav
        /// </summary>
        [JsonIgnore]
        [GitLabDocProperty]
        public virtual ICollection<ProductImage> Images { get; set; }
        /// <summary>
        /// Clicks Nav
        /// </summary>
        [JsonIgnore]
        [GitLabDocProperty]
        public virtual ICollection<UserProductClick> ProductClicks { get; set; }



    }
}
