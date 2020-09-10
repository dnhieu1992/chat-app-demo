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
        public DbSet<Conversation> Conversation { get; set; }
        public DbSet<Messages> Messages { get; set; }
        public DbSet<Participant> Participant { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<Messages>().HasOne(p => p.Conversation).WithMany(b => b.Messages).HasForeignKey(a => a.ConversationId);
            builder.Entity<Participant>().HasOne(p => p.Conversation).WithMany(b => b.Participants).HasForeignKey(a => a.ConversationId);
            builder.Entity<Participant>().HasOne(p => p.User).WithMany(b => b.Participants).HasForeignKey(a => a.UserId);
        }
    }
}
