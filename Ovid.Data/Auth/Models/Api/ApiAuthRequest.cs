using Microsoft.AspNetCore.Identity;
using Newtonsoft.Json;
using Ovid.Data.Auth.Models.Users;
using Ovid.Tools;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Ovid.Data.Auth.Models.Api
{
    /// <summary>
    /// Api Authentication Tokens For Users
    /// </summary>
    [GitLabDoc(typeof(ApiAuthRequest))]
    public class ApiAuthRequest
    {
        /// <summary>
        /// Record ID
        /// </summary>
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [GitLabDocProperty]
        public int AuthRequestId { get; set; }
        /// <summary>
        /// Provider Name
        /// </summary>
        [Required]
        [StringLength(250)]
        [GitLabDocProperty]
        public string ProviderName { get; set; }
        /// <summary>
        /// Authentication Token
        /// </summary>
        [Required]
        [StringLength(250)]
        [GitLabDocProperty]
        public string AuthToken { get; set; }
        /// <summary>
        /// Token Expires
        /// </summary>
        [Required]
        [GitLabDocProperty]
        public DateTime Expires { get; set; }
        /// <summary>
        /// Refresh Token
        /// </summary>
        [Required]
        [StringLength(250)]
        [GitLabDocProperty]
        public string RefreshToken { get; set; }
        /// <summary>
        /// User
        /// </summary>
        [Required]
        [StringLength(250)]
        [GitLabDocProperty]
        public string UserId { get; set; }
        /// <summary>
        /// User Naivagtion Property
        /// </summary>
        [JsonIgnore]
        [GitLabDocProperty]
        public virtual ApplicationUser User { get; set; }

    }
}
