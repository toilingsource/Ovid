using Microsoft.AspNetCore.Identity;
using Newtonsoft.Json;
using Ovid.Data.Auth.Models.Api;
using Ovid.Tools;
using System;
using System.Collections.Generic;
using System.Text;

namespace Ovid.Data.Auth.Models.Users
{
    /// <summary>
    /// Application User Account
    /// </summary>
    [GitLabDoc(typeof(ApplicationUser))]
    public class ApplicationUser : IdentityUser
    {


        /// <summary>
        /// Navigation property for the roles this user belongs to.
        /// </summary>
        [JsonIgnore]
        [GitLabDocProperty]
        public virtual ICollection<Microsoft.AspNetCore.Identity.IdentityUserRole<string>> Roles { get; set; }
        /// <summary>
        /// Navigation property for the claims this user possesses.
        /// </summary>
        [JsonIgnore]
        [GitLabDocProperty]
        public virtual ICollection<Microsoft.AspNetCore.Identity.IdentityUserClaim<string>> Claims { get; set; }
        /// <summary>
        /// Api Authtication Tokens
        /// </summary>
        [JsonIgnore]
        [GitLabDocProperty]
        public virtual ICollection<ApiAuthRequest> ApiTokens { get; set; }

    }
}
