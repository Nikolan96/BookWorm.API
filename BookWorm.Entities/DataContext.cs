using BookWorm.Entities.Entities;
using Microsoft.EntityFrameworkCore;

namespace BookWorm.Entities
{
    public class DataContext : DbContext
    {

        public DataContext(DbContextOptions options)
          : base(options)
        {
        }

        public DbSet<User> Users { get; set; }
        public DbSet<UserReview> UserReviews { get; set; }
        public DbSet<ReasonToRead> ReasonsToRead { get; set; }
        public DbSet<CriticReview> CriticReviews { get; set; }
        public DbSet<Case> Cases { get; set; }
        public DbSet<BookCase> BookCases { get; set; }
        public DbSet<Book> Books { get; set; }
        public DbSet<BookFact> BookFacts { get; set; }
        public DbSet<Author> Authors { get; set; }
        public DbSet<BookAuthor> BookAuthors { get; set; }
        public DbSet<AuthorFact> AuthorFacts { get; set; }
        public DbSet<UserBookNote> UserBookNotes { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            #region Id setup
            modelBuilder.Entity<ReasonToRead>()
                .HasKey(x => x.Id);

            modelBuilder.Entity<BookFact>()
                .HasKey(x => x.Id);

            modelBuilder.Entity<CriticReview>()
             .HasKey(x => x.Id);

            modelBuilder.Entity<Book>()
                .HasKey(x => x.Id);

            modelBuilder.Entity<BookAuthor>()
                .HasKey(x => x.Id);

            modelBuilder.Entity<Author>()
                .HasKey(x => x.Id);

            modelBuilder.Entity<AuthorFact>()
                .HasKey(x => x.Id);

            modelBuilder.Entity<UserReview>()
                .HasKey(x => x.Id);

            modelBuilder.Entity<BookCase>()
               .HasKey(x => x.Id);

            modelBuilder.Entity<Case>()
               .HasKey(x => x.Id);

            modelBuilder.Entity<UserReview>()
               .HasKey(x => x.Id);

            modelBuilder.Entity<User>()
               .HasKey(x => x.Id);

            modelBuilder.Entity<UserBookNote>()
              .HasKey(x => x.Id);

            #endregion

            modelBuilder.Entity<Author>()
                 .HasMany(c => c.AuthorFacts)
                 .WithOne(e => e.Author);

            modelBuilder.Entity<BookAuthor>()
                .HasOne(bc => bc.Book)
                .WithMany(b => b.BookAuthors)
                .HasForeignKey(bc => bc.BookId);
            modelBuilder.Entity<BookAuthor>()
                .HasOne(bc => bc.Author)
                .WithMany(c => c.BookAuthors)
                .HasForeignKey(bc => bc.AuthorId);

            modelBuilder.Entity<Book>()
                .HasMany(c => c.BookFacts)
                .WithOne(e => e.Book);

            modelBuilder.Entity<Book>()
                .HasMany(c => c.CriticReviews)
                .WithOne(e => e.Book);

            modelBuilder.Entity<BookCase>()
                .HasOne(bc => bc.Book)
                .WithMany(b => b.BookCases)
                .HasForeignKey(bc => bc.BookId);
            modelBuilder.Entity<BookCase>()
                .HasOne(bc => bc.Case)
                .WithMany(c => c.BookCases)
                .HasForeignKey(bc => bc.CaseId);

            modelBuilder.Entity<UserReview>()
                .HasOne(bc => bc.Book)
                .WithMany(b => b.UserReviews)
                .HasForeignKey(bc => bc.BookId);
            modelBuilder.Entity<UserReview>()
                .HasOne(bc => bc.User)
                .WithMany(c => c.UserReviews)
                .HasForeignKey(bc => bc.UserId);

            modelBuilder.Entity<User>()
                .HasMany(c => c.Cases)
                .WithOne(e => e.User);

            modelBuilder.Entity<UserBookNote>()
                .HasOne(bc => bc.Book)
                .WithMany(b => b.UserBookNotes)
                .HasForeignKey(bc => bc.BookId);
            modelBuilder.Entity<UserBookNote>()
                .HasOne(bc => bc.User)
                .WithMany(c => c.UserBookNotes)
                .HasForeignKey(bc => bc.UserId);


            #region Uniques

            modelBuilder.Entity<User>()
                .HasIndex(u => u.Email)
                .IsUnique();

            modelBuilder.Entity<Book>()
               .HasIndex(u => u.ISBN)
               .IsUnique();

            #endregion

        }
    }
}
