using Newtonsoft.Json;
using Ovid.Data.Models.Accounts;
using Ovid.Tools;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Ovid.Data.Models.Common
{
    /// <summary>
    /// Intrest List
    /// </summary>
    [GitLabDoc(typeof(IntrestList))]
    public class IntrestList
    {
        /// <summary>
        /// Record Id
        /// </summary>
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [GitLabDocProperty]
        public long IntrestId { get; set; }
        /// <summary>
        /// Instrest
        /// </summary>
        [Required]
        [StringLength(250)]
        [GitLabDocProperty]
        public string Intrest { get; set; }


        /// <summary>
        /// User Intrest Nav
        /// </summary>
        [JsonIgnore]
        [GitLabDocProperty]
        public virtual ICollection<UserIntrest> UserIntrests { get; set; }
    }
}
