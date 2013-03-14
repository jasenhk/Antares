using System;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Data.Objects;

namespace Antares.Data
{
    public class UsersContext : DbContext
    {
        public UsersContext(string connectionString) : base(connectionString)
        {
            this.Configuration.LazyLoadingEnabled = true;
            this.Configuration.ProxyCreationEnabled = true;
            this.Configuration.ValidateOnSaveEnabled = true;
        }

        public ObjectContext ObjectContext()
        {
            return (this as IObjectContextAdapter).ObjectContext;
        }

        #region Entities

        public DbSet<UserProfile> UserProfiles { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<Membership> Membership { get; set; }
        public DbSet<OAuthMembership> OAuthMembership { get; set; }
        
        #endregion


        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            MapUsersInRolesRelation(modelBuilder);

            base.OnModelCreating(modelBuilder);
        }

        #region Relation Mapping

        private void MapUsersInRolesRelation(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<UserProfile>()
                .HasMany(r => r.Roles).WithMany()
                .Map(m =>
                    {
                        m.MapLeftKey("UserId");
                        m.MapRightKey("RoleId");
                        m.ToTable("webpages_UsersInRoles");
                    });
        }

        #endregion
    }
}