using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Votedress.DataAccessLayer.EntityFramework;
using Votedress.Entities;
using Votedress.Entities.VeritabaniModellerim;

namespace Votedress.DataAccessLayer
{
    public class DatabaseContext:DbContext
    {

        public DbSet<VotedressUser> VotedressUsers { get; set; }
        public DbSet<UserDetail> UserDetail { get; set; }
        public DbSet<City> Cities { get; set; }
        public DbSet<County> Counties { get; set; }
        public DbSet<Area> Areas { get; set; }
        public DbSet<Neighborhood> Neighborhoods { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<ProductSize> ProductSizes { get; set; }
        public DbSet<ProductColor> ProductColors { get; set; }
        public DbSet<ProductColorDetail> ProductColorDetails { get; set; }
        public DbSet<ProductImageGallery> ProductImageGallery { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<ProductCategory> ProductCategories { get; set; }
        public DbSet<ProductCollection> ProductCollections { get; set; }
        public DbSet<Collection> Collections { get; set; }
        public DbSet<Friend> Friends { get; set; }
        public DbSet<OnlineUser> OnlineUsers { get; set; }
        public DbSet<PrivateMessage> PrivateMessages { get; set; }
        public DbSet<Vote> Votes { get; set; }
        public DbSet<SocialShare> SocialShares { get; set; }
        public DbSet<Bahsedilen> Bahsedilenler { get; set; } public DbSet<FollowVote> FollowVotes { get; set; }  public DbSet<MyVoted> MyVoteds { get; set; }  public DbSet<VoteImage> VoteImages { get; set; }
        public DbSet<VoteProduct> VoteProduct { get; set; }
        public DbSet<InVoteChat> InVoteChats { get; set; }      public DbSet<Franchise> Franchises { get; set; }       public DbSet<ControllerLoglama> ControllerLoglamalar { get; set; }      public DbSet<Color> Colors { get; set; }
        public DbSet<ProductComment> ProductComments { get; set; }
        public DbSet<ProductCommentLike> ProductCommentLike { get; set; }
        public DbSet<ProductCommentReply> ProductCommentReplies { get; set; }
        public DbSet<ProductCommentReplyLike> ProductCommentReplyLikes { get; set; }
        public DbSet<ProductLike> ProductLikes { get; set; }
        public DbSet<Cart> Carts { get; set; }
        public DbSet<CartDetail> CartDetails { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderDetail> OrderDetails { get; set; }
        public DbSet<Whisper> Whispers { get; set; }
        public DbSet<BlockedUser> BlockedUsers { get; set; }
        public DbSet<VoteMessage> VoteMessages { get; set; }
        public DbSet<UserAdress> UserAdresses { get; set; }


        public DatabaseContext()
        {
            Database.SetInitializer(new BitirmeInitializer());
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {

        }
    }
}
