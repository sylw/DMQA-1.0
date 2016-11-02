namespace DMQA.Database.Models
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class BaseDbContext : DbContext
    {
        public BaseDbContext()
            : base("name=BaseDbContext")
        {
        }

        public virtual DbSet<tb_Answer> tb_Answer { get; set; }
        public virtual DbSet<tb_Question> tb_Question { get; set; }
        public virtual DbSet<tb_UserInfo> tb_UserInfo { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<tb_Answer>()
                .Property(e => e.Code)
                .IsUnicode(false);

            modelBuilder.Entity<tb_Answer>()
                .Property(e => e.QuestionCode)
                .IsUnicode(false);

            modelBuilder.Entity<tb_Answer>()
                .Property(e => e.UserCode)
                .IsUnicode(false);

            modelBuilder.Entity<tb_Question>()
                .Property(e => e.Code)
                .IsUnicode(false);

            modelBuilder.Entity<tb_Question>()
                .Property(e => e.CatalogCode)
                .IsUnicode(false);

            modelBuilder.Entity<tb_Question>()
                .Property(e => e.UserCode)
                .IsUnicode(false);

            modelBuilder.Entity<tb_UserInfo>()
                .Property(e => e.Code)
                .IsUnicode(false);

            modelBuilder.Entity<tb_UserInfo>()
                .Property(e => e.Password)
                .IsUnicode(false);

            modelBuilder.Entity<tb_UserInfo>()
                .Property(e => e.Sex)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<tb_UserInfo>()
                .Property(e => e.Email)
                .IsUnicode(false);
        }
    }
}
