// AlexeyQwake Qwake

using System;
using System.Threading.Channels;
using Microsoft.EntityFrameworkCore;
using MVCStartApp.Models.Db;

namespace MVCStartApp
{
    public sealed class BlogContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<UserPost> UserPosts { get; set; }
        public DbSet<Request> Requests { get; set; }

        public BlogContext(DbContextOptions<BlogContext> options) : base(options)
        {
            Database.EnsureCreated();
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<User>().ToTable("Users"); 
            builder.Entity<UserPost>().ToTable("UserPosts"); 
            builder.Entity<Request>().ToTable("Requests"); 
        }
    }
}