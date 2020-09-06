using ChatApp.WebApi.Models;
using ChatApp.WepApi.Models.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;

namespace ChatApp.WebApi.Infrastructure
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser, ApplicationRole, Guid>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<Messages>().HasOne(p => p.Conversation).WithMany(b => b.Messages).HasForeignKey(a => a.ConversationId);
            builder.Entity<UserConversation>().HasOne(p => p.User).WithMany(b => b.UserConversations).HasForeignKey(a => a.UserId);
            builder.Entity<UserConversation>().HasOne(p => p.Conversation).WithMany(b => b.UserConversations).HasForeignKey(a => a.Conversionid);
        }
    }
}
