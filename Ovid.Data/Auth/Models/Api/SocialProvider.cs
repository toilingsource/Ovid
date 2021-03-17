using Ovid.Tools;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Ovid.Data.Auth.Models.Api
{
    /// <summary>
    /// Social Media Provider
    /// </summary>
    [GitLabDoc(typeof(SocialProvider))]
    public class SocialProvider
    {
        /// <summary>
        /// Provider Id
        /// </summary>
        [Key]
        [StringLength(150)]
        [GitLabDocProperty]
        public string ProviderId { get; set; }
        /// <summary>
        /// Provider Name
        /// </summary>
        [Required]
        [StringLength(150)]
        [GitLabDocProperty]
        public string Name { get; set; }
        /// <summary>
        /// Icon
        /// </summary>
        [Required]
        [GitLabDocProperty]
        public string Icon { get; set; }
        /// <summary>
        /// Application Id
        /// </summary>
        [Required]
        [GitLabDocProperty]
        public string AppId { get; set; }
        /// <summary>
        /// Aplication Secret
        /// </summary>
        [Required]
        [GitLabDocProperty]
        public string AppSecret { get; set; }
        /// <summary>
        /// Auth Endpoint
        /// </summary>
        [Required]
        [StringLength(255)]
        [GitLabDocProperty]
        public string AuthEndPoint { get; set; }
        /// <summary>
        /// Api Base Endpoint
        /// </summary>
        [Required]
        [StringLength(255)]
        [GitLabDocProperty]
        public string ApiEndPointBase { get; set; }
        /// <summary>
        /// Configuration Data for Provider
        /// </summary>
        [GitLabDocProperty]
        public string ConfigData { get; set; }

    }
}
