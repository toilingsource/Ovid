using Microsoft.EntityFrameworkCore;
using Ovid.Data.Models.Accounts;
using Ovid.Data.Models.Advertising;
using Ovid.Data.Models.Campaigns;
using Ovid.Data.Models.Common;
using Ovid.Data.Models.Marketers;
using Ovid.Data.Models.Posts;
using Ovid.Data.Models.Products;
using Ovid.Data.Models.Ratings;
using Ovid.Data.Models.SocialMedia;
using System;
using System.Collections.Generic;
using System.Text;

namespace Ovid.Data
{
    /// <summary>
    /// Ovid General Db Context
    /// </summary>
    public class OvidDbContext : DbContext
    {
        #region Tables
        /// <summary>
        /// Account Types
        /// </summary>
        public DbSet<AccountType> AccountTypes { get; set; }
        /// <summary>
        /// Follwed Accounts
        /// </summary>
        public DbSet<Followed> Followeds { get; set; }
        /// <summary>
        /// User Acocunts
        /// </summary>
        public DbSet<UserAccount> UserAccounts { get; set; }
        /// <summary>
        /// User Intrest
        /// </summary>
        public DbSet<UserIntrest> UserIntrests { get; set; }
        /// <summary>
        /// Advertisments
        /// </summary>
        public DbSet<Advertisment> Advertisments { get; set; }
        /// <summary>
        /// User Add Clicks
        /// </summary>
        public DbSet<UserAddClick> UserAddClicks { get; set; }
        /// <summary>
        /// User Campign Item Clicks
        /// </summary>
        public DbSet<UserCampaignItemClick> UserCampaignItemClicks { get; set; }
        /// <summary>
        /// User Capign Clicks
        /// </summary>
        public DbSet<UserCampaignClick> UserCampaignClicks { get; set; }
        /// <summary>
        /// Capaign Items
        /// </summary>
        public DbSet<CampaignItem> CampaignItems { get; set; }
        /// <summary>
        /// Campaigns
        /// </summary>
        public DbSet<Campaign> Campaigns { get; set; }
        /// <summary>
        /// Camppgin Types
        /// </summary>
        public DbSet<CampaignType> CampaignTypes { get; set; }
        /// <summary>
        /// Slaaries
        /// </summary>
        public DbSet<Salalary> Salalaries { get; set; }
        /// <summary>
        /// Ocupations
        /// </summary>
        public DbSet<Ocupation> Ocupations { get; set; }
        /// <summary>
        /// Intrest list
        /// </summary>
        public DbSet<IntrestList> IntrestLists { get; set; }
        /// <summary>
        /// Marketers
        /// </summary>
        public DbSet<Marketer> Marketers { get; set; }
        /// <summary>
        /// User Post
        /// </summary>
        public DbSet<UserPost> UserPosts { get; set; }
        /// <summary>
        /// Post Images
        /// </summary>
        public DbSet<PostImage> PostImages { get; set; }
        /// <summary>
        /// Product Clicks
        /// </summary>
        public DbSet<UserProductClick> UserProductClicks { get; set; }
        /// <summary>
        /// Sponsored Products
        /// </summary>
        public DbSet<SponsoredProduct> SponsoredProducts { get; set; }
        /// <summary>
        /// Product Images
        /// </summary>
        public DbSet<ProductImage> ProductImages { get; set; }
        /// <summary>
        /// Product Categories
        /// </summary>
        public DbSet<ProductCategory> ProductCategories { get; set; }
        /// <summary>
        /// Accopunt Ratings
        /// </summary>
        public DbSet<AccountRating> AccountRatings { get; set; }
        /// <summary>
        /// Product Revies
        /// </summary>
        public DbSet<ProductReview> ProductReviews { get; set; }
        /// <summary>
        /// Social Medua Feeds
        /// </summary>
        public DbSet<SocialFeed> SocialFeeds { get; set; }


        #endregion Tables


        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="options"></param>
        public OvidDbContext(DbContextOptions<OvidDbContext> options) : base(options)
        {

        }

        /// <summary>
        /// Constructor
        /// </summary>
        protected OvidDbContext()
        {

        }

        /// <summary>
        /// Configure Connaction
        /// </summary>
        /// <param name="optionsBuilder"></param>
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Data Source=SQL5063.site4now.net;Initial Catalog=DB_9FA651_ovid;User Id=DB_9FA651_ovid_admin;Password=Shwn2004;");
        }

        /// <summary>
        /// Model Builder
        /// </summary>
        /// <param name="builder"></param>
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<AccountType>().HasMany(m => m.UserAccounts).WithOne(m => m.AccountType).HasForeignKey(m => m.TypeId).IsRequired().OnDelete(DeleteBehavior.Cascade);


            builder.Entity<UserAccount>().HasMany(m => m.Advertisments).WithOne(m => m.User).HasForeignKey(m => m.AccountId).IsRequired().OnDelete(DeleteBehavior.Cascade);
            builder.Entity<UserAccount>().HasMany(m => m.CampaignClicks).WithOne(m => m.User).HasForeignKey(m => m.AccountId).IsRequired().OnDelete(DeleteBehavior.Cascade);
            builder.Entity<UserAccount>().HasMany(m => m.CampaignItemClicks).WithOne(m => m.User).HasForeignKey(m => m.AccountId).IsRequired().OnDelete(DeleteBehavior.Cascade);
            builder.Entity<UserAccount>().HasMany(m => m.Campaigns).WithOne(m => m.User).HasForeignKey(m => m.AccountId).IsRequired().OnDelete(DeleteBehavior.Cascade);
            builder.Entity<UserAccount>().HasMany(m => m.Followed).WithOne(m => m.FollowedAccount).HasForeignKey(m => m.FollowedId).IsRequired().OnDelete(DeleteBehavior.Cascade);
            builder.Entity<UserAccount>().HasMany(m => m.Followers).WithOne(m => m.Follower).HasForeignKey(m => m.FollowerId).IsRequired().OnDelete(DeleteBehavior.Cascade);
            builder.Entity<UserAccount>().HasMany(m => m.Intrests).WithOne(m => m.User).HasForeignKey(m => m.AccountId).IsRequired().OnDelete(DeleteBehavior.Cascade);
            builder.Entity<UserAccount>().HasMany(m => m.Marketers).WithOne(m => m.User).HasForeignKey(m => m.UserId).IsRequired().OnDelete(DeleteBehavior.Cascade);
            builder.Entity<UserAccount>().HasMany(m => m.PostImages).WithOne(m => m.User).HasForeignKey(m => m.AccountId).IsRequired().OnDelete(DeleteBehavior.Cascade);
            builder.Entity<UserAccount>().HasMany(m => m.ProductClicks).WithOne(m => m.User).HasForeignKey(m => m.AccountId).IsRequired().OnDelete(DeleteBehavior.Cascade);
            builder.Entity<UserAccount>().HasMany(m => m.Ratings).WithOne(m => m.UserAccount).HasForeignKey(m => m.AccountId).IsRequired().OnDelete(DeleteBehavior.Cascade);
            builder.Entity<UserAccount>().HasMany(m => m.SocialFeeds).WithOne(m => m.User).HasForeignKey(m => m.AccountId).IsRequired().OnDelete(DeleteBehavior.Cascade);
            builder.Entity<UserAccount>().HasMany(m => m.UserAddClicks).WithOne(m => m.User).HasForeignKey(m => m.AccountId).IsRequired().OnDelete(DeleteBehavior.Cascade);
            builder.Entity<UserAccount>().HasMany(m => m.UserPosts).WithOne(m => m.UserAccount).HasForeignKey(m => m.AccountId).IsRequired().OnDelete(DeleteBehavior.Cascade);


            builder.Entity<Advertisment>().HasMany(m => m.AddClicks).WithOne(m => m.Advertisment).HasForeignKey(m => m.AddId).IsRequired().OnDelete(DeleteBehavior.Cascade);

            builder.Entity<Campaign>().HasMany(m => m.UserClicks).WithOne(m => m.Campaign).HasForeignKey(m => m.CampaignId).IsRequired().OnDelete(DeleteBehavior.Cascade);
            builder.Entity<Campaign>().HasMany(m => m.Items).WithOne(m => m.Campaign).HasForeignKey(m => m.CampaignId).IsRequired().OnDelete(DeleteBehavior.Cascade);

            builder.Entity<CampaignType>().HasMany(m => m.Campaigns).WithOne(m => m.CampaignType).HasForeignKey(m => m.TypeId).IsRequired().OnDelete(DeleteBehavior.Cascade);

            builder.Entity<IntrestList>().HasMany(m => m.UserIntrests).WithOne(m => m.Intrest).HasForeignKey(m => m.IntrestId).IsRequired().OnDelete(DeleteBehavior.Cascade);

            builder.Entity<Ocupation>().HasMany(m => m.UserAccounts).WithOne(m => m.Ocupation).HasForeignKey(m => m.OcupationId).IsRequired().OnDelete(DeleteBehavior.SetNull);
            builder.Entity<Salalary>().HasMany(m => m.UserAccounts).WithOne(m => m.Salalary).HasForeignKey(m => m.SalaryId).IsRequired().OnDelete(DeleteBehavior.SetNull);

            builder.Entity<Marketer>().HasMany(m => m.Advertisments).WithOne(m => m.Markerter).HasForeignKey(m => m.MarketerId).IsRequired().OnDelete(DeleteBehavior.Cascade);
            builder.Entity<Marketer>().HasMany(m => m.SponsoredProducts).WithOne(m => m.Marketer).HasForeignKey(m => m.MarkerterId).IsRequired().OnDelete(DeleteBehavior.Cascade);


        }
    }
}
