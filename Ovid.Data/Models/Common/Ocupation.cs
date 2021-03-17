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
    /// Ocupation List
    /// </summary>
    [GitLabDoc(typeof(Ocupation))]
    public class Ocupation
    {
        /// <summary>
        /// Record Id
        /// </summary>
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [GitLabDocProperty]
        public long OcupationId { get; set; }
        /// <summary>
        /// Ocumaption Name
        /// </summary>
        [Required]
        [StringLength(250)]
        [GitLabDocProperty]
        public string Name { get; set; }

        /// <summary>
        /// User account Nav
        /// </summary>
        [JsonIgnore]
        [GitLabDocProperty]
        public virtual ICollection<UserAccount> UserAccounts { get; set; }
    }
}
