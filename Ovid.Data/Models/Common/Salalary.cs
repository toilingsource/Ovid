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
    /// Salary Range
    /// </summary>
    [GitLabDoc(typeof(Salalary))]
    public class Salalary
    {
        /// <summary>
        /// Record Id
        /// </summary>
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [GitLabDocProperty]
        public long SalaryId { get; set; }
        /// <summary>
        /// Start Range
        /// </summary>
        [Required]
        [GitLabDocProperty]
        public decimal StartRange { get; set; } = 0;
        /// <summary>
        /// End Range
        /// </summary>
        [Required]
        [GitLabDocProperty]
        public decimal EndRange { get; set; } = 0;

        /// <summary>
        /// Formated string in start - end currency formated
        /// </summary>
        /// <returns>string</returns>
        public override string ToString()
        {
            return String.Format("{0:C} - {1:C}", StartRange, EndRange);
        }

        /// <summary>
        /// User Account Navigation
        /// </summary>
        [JsonIgnore]
        [GitLabDocProperty]
        public virtual ICollection<UserAccount> UserAccounts { get; set; }
    }
}
