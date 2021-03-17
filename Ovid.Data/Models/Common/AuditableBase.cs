using Newtonsoft.Json;
using Ovid.Tools;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Security.Cryptography;
using System.Text;

namespace Ovid.Data.Models.Common
{
    /// <summary>
    /// Auditable Base Class
    /// </summary>
    /// <typeparam name="T">Object Being Auidtied</typeparam>
    public class AuditableBase<T> : IAuditable where T : class
    {

        /// <summary>
        /// Created By
        /// </summary>
        [StringLength(150)]
        public string CreatedBy { get; set; }

        /// <summary>
        /// Updated By
        /// </summary>
        [StringLength(150)]
        public string UpdatedBy { get; set; }

        /// <summary>
        /// Date Created
        /// </summary>
        [Required]
        public DateTime Created { get; set; } = DateTime.Now;
        /// <summary>
        /// Date Updated
        /// </summary>
        [Required]
        public DateTime Updated { get; set; } = DateTime.Now;

        /// <summary>
        /// Object Hash
        /// </summary>
        /// <param name="obj">Object</param>
        /// <returns>Hashed String</returns>
        protected string GetHash(T obj)
        {
            using (SHA256 sha = SHA256.Create())
            {
                byte[] data = Encoding.UTF8.GetBytes(JsonConvert.SerializeObject(obj));
                byte[] bts = sha.ComputeHash(data);
                return Encoding.UTF8.GetString(bts);
            }
        }

        /// <summary>
        /// Get Data Hash
        /// </summary>
        /// <returns>Hashed object string</returns>
        public virtual string GetDataHash()
        {
            using (SHA256 sha = SHA256.Create())
            {
                byte[] data = Encoding.UTF8.GetBytes(JsonConvert.SerializeObject(this));
                byte[] bts = sha.ComputeHash(data);
                return Encoding.UTF8.GetString(bts);
            }
        }
    }
}
