using flashcardApp.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace FlashcardApp.Data
{
    public class DataContext : DbContext
    {
        private readonly IConfiguration _configuration;

        public DbSet<Flashcard> Flashcards { get; set; }

        public DataContext(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            /*            optionsBuilder.UseSqlServer(
                            "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=FlashcardDB;Integrated Security=True;Connect Timeout=30;Encrypt=False;" +
                            "Trust Server Certificate=False;Application Intent=ReadWrite;Multi Subnet Failover=False");*/
            optionsBuilder.UseSqlServer(_configuration.GetConnectionString("DefaultConnection"));
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            AddFlashcards(modelBuilder);
            base.OnModelCreating(modelBuilder);
        }

        private static void AddFlashcards(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Flashcard>().HasData(
                new Flashcard
                {
                    Id = 1,
                    Question = "Question 1",
                    Answer = "Answer 1"
                },
                new Flashcard
                {
                    Id = 2,
                    Question = "Question 2",
                    Answer = "Answer 2"
                },
                new Flashcard
                {
                    Id = 3,
                    Question = "Question 3",
                    Answer = "Answer 3"
                },
                new Flashcard
                {
                    Id = 4,
                    Question = "Question 4",
                    Answer = "Answer 4"
                },
                new Flashcard
                {
                    Id = 5,
                    Question = "Question 5",
                    Answer = "Answer 5"
                });
        }
    }
}