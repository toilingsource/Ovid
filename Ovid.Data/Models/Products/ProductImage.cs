using Newtonsoft.Json;
using Ovid.Data.Models.Common;
using Ovid.Tools;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Ovid.Data.Models.Products
{

    /// <summary>
    /// Product Images
    /// </summary>
    [GitLabDoc(typeof(ProductImage))]
    public class ProductImage : AuditableBase<ProductImage>
    {
        /// <summary>
        /// Image Id
        /// </summary>
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [GitLabDocProperty]
        public long ImageId { get; set; }

        /// <summary>
        /// Product Id
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
        public virtual SponsoredProduct SponsoredProduct { get; set; }
        /// <summary>
        /// Image Alt Text
        /// </summary>
        [StringLength(150)]
        [GitLabDocProperty]
        public string AltText { get; set; }
        /// <summary>
        /// Image Data
        /// </summary>
        [Required]
        [GitLabDocProperty]
        public string ImageData { get; set; }

    }
}

