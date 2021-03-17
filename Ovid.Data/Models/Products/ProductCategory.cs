using Newtonsoft.Json;
using Ovid.Tools;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Ovid.Data.Models.Products
{
    /// <summary>
    /// Product Catgory
    /// </summary>
    [GitLabDoc(typeof(ProductCategory))]
    public class ProductCategory
    {
        /// <summary>
        /// Record Id
        /// </summary>
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [GitLabDocProperty]
        public long CategoryId { get; set; }
        /// <summary>
        /// Catehory Names
        /// </summary>
        [Required]
        [StringLength(150)]
        [GitLabDocProperty]
        public string Name { get; set; }
        /// <summary>
        /// Icon
        /// </summary>
        [Required]
        [StringLength(255)]
        [GitLabDocProperty]
        public string Icon { get; set; } = "noicon.png";
        /// <summary>
        /// Product Nav
        /// </summary>
        [JsonIgnore]
        [GitLabDocProperty]
        public virtual ICollection<SponsoredProduct> Products { get; set; }
    }
}
