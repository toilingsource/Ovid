using System;
using System.Collections.Generic;
using System.Text;

namespace Ovid.Data.Models.Common
{
    /// <summary>
    /// Auitable Trail Interface
    /// </summary>
    public interface IAuditable
    {
        /// <summary>
        /// Cretaed By User ID
        /// </summary>
        string CreatedBy { get; set; }
        /// <summary>
        /// Updated By User Id
        /// </summary>
        string UpdatedBy { get; set; }
        /// <summary>
        /// Created Date
        /// </summary>
        DateTime Created { get; set; }
        /// <summary>
        /// Updated Date
        /// </summary>
        DateTime Updated { get; set; }
    }
}
