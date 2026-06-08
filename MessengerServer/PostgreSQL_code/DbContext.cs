using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace MessengerServer
{
    internal class AppDbContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<UserDevices> UserDevices { get; set; }
        public DbSet<Message> Messages { get; set; }
        public DbSet<Chat> Chats { get; set; }
        public DbSet<Participant> Participants { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseNpgsql("Host=localhost;Database=JabNetDatabase;Username=Jadmin;Password=4649");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<UserDevices>()
            .HasKey(ud => new { ud.UserSUID, ud.deviceID, ud.sessionID });

            modelBuilder.Entity<Participant>()
            .HasKey(p => new { p.UserSUID, p.ChatSUID });
        }
    }
}
