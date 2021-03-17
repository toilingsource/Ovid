using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ovid.Auth.Extension.Configuration
{
    /// <summary>
    /// Authentication Server Configuration
    /// </summary>
    public class AuthConfig
    {
        /// <summary>
        /// Issuer URI
        /// </summary>
        public string IssuerUri { get; set; }
        /// <summary>
        /// Cors Policy Name to apply
        /// </summary>
        public string CorsPolicyName { get; set; }
        /// <summary>
        /// Add Developer Signing Credentials
        /// </summary>
        public bool AddDeveloperSigningCredential { get; set; }
        /// <summary>
        /// Path to TLS Sigining Ceertificate
        /// </summary>
        public string TlsPath { get; set; }
        /// <summary>
        /// TLS Certificate Password
        /// </summary>
        public string TlsPassword { get; set; }
    }
}
