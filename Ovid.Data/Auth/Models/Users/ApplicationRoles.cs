using Microsoft.AspNetCore.Identity;
using Newtonsoft.Json;
using Ovid.Tools;
using System;
using System.Collections.Generic;
using System.Text;

namespace Ovid.Data.Auth.Models.Users
{
    /// <summary>
    /// Application User Roles
    /// </summary>
    [GitLabDoc(typeof(ApplicationRole))]
    public class ApplicationRole : IdentityRole
    {

        /// <summary>
        /// Navigation property for the users in this role.
        /// </summary>
        [JsonIgnore]
        [GitLabDocProperty]
        public virtual ICollection<IdentityUserRole<string>> Users { get; set; }

        /// <summary>
        /// Navigation property for claims in this role.
        /// </summary>
        [JsonIgnore]
        [GitLabDocProperty]
        public virtual ICollection<IdentityRoleClaim<string>> Claims { get; set; }
    }
}
