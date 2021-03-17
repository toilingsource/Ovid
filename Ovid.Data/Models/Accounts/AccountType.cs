using Newtonsoft.Json;
using Ovid.Tools;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Ovid.Data.Models.Accounts
{
    /// <summary>
    /// Account Types
    /// </summary>
    [GitLabDoc(typeof(AccountType))]
    public class AccountType
    {
        /// <summary>
        /// Record Id
        /// </summary>
        [Key]
        [StringLength(150)]
        [GitLabDocProperty]
        public string AccontTypeId { get; set; }

        /// <summary>
        /// Account Type Name
        /// </summary>
        [Required]
        [StringLength(150)]
        [GitLabDocProperty]
        public string Name { get; set; }
        /// <summary>
        /// Description
        /// </summary>
        [Required]
        [StringLength(150)]
        [GitLabDocProperty]
        public string Description { get; set; }
        /// <summary>
        /// User Accounts Navigation Property
        /// </summary>
        [JsonIgnore]
        [GitLabDocProperty]
        public virtual ICollection<UserAccount> UserAccounts { get; set; }

    }
}
