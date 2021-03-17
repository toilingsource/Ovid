using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Ovid.Data.Sales
{
    /// <summary>
    /// Ovid Sales Db Context
    /// </summary>
    public class OvidSalesContext : DbContext
    {
        #region Tables




        #endregion Tables


        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="options"></param>
        public OvidSalesContext(DbContextOptions<OvidSalesContext> options) : base(options)
        {

        }

        /// <summary>
        /// Constructor
        /// </summary>
        protected OvidSalesContext()
        {

        }

        /// <summary>
        /// Configure Connection
        /// </summary>
        /// <param name="optionsBuilder"></param>
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Data Source=SQL5063.site4now.net;Initial Catalog=DB_9FA651_salesovid;User Id=DB_9FA651_salesovid_admin;Password=Shwn2004;");
        }

        /// <summary>
        /// Model Builder
        /// </summary>
        /// <param name="builder"></param>
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
        }
    }
}
