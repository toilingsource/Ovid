using Ovid.Data.Models.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Ovid.Data.Models.Ratings
{
    /// <summary>
    /// Product Review
    /// </summary>
    public class ProductReview : AuditableBase<ProductReview>
    {

        /// <summary>
        /// Review Id
        /// </summary>
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long ReviewId { get; set; }




    }
}
