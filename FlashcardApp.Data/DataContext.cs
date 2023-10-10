using flashcardApp.Domain.Models;
using FlashcardApp.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace FlashcardApp.Data
{
    public class DataContext : DbContext
    {
        private readonly IConfiguration _configuration;

        public DbSet<Flashcard> Flashcards { get; set; }
        public DbSet<CardDeck> CardDecks { get; set; }

        //TODO ctor with config not working, and so the connection string cannot be called and needs to be hardcoded. FIX THIS D:

        /*        public DataContext(IConfiguration configuration)
                {
                    _configuration = configuration;
                }

                public DataContext()
                {
                }*/

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(
                "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=FlashcardDB;Integrated Security=True;Connect Timeout=30;Encrypt=False;" +
                "Trust Server Certificate=False;Application Intent=ReadWrite;Multi Subnet Failover=False");
            /*           optionsBuilder.UseSqlServer(_configuration.GetConnectionString("DefaultConnection"))
                                     .EnableSensitiveDataLogging();*/
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            AddCardDecks(modelBuilder);
            AddFlashcards(modelBuilder);
            base.OnModelCreating(modelBuilder);
        }

        private static void AddCardDecks(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<CardDeck>(d =>
            {
                d.HasData(new CardDeck
                {
                    DeckId = 1,
                    DeckName = "test deck 1",
                });
                d.HasData(new CardDeck
                {
                    DeckId = 2,
                    DeckName = "test deck 2",
                });
            });
        }

        private static void AddFlashcards(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Flashcard>(d =>
            {
                d.HasData(
                    new Flashcard
                    {
                        Id = 1,
                        Answer = "Answer 1",
                        Question = "Question 1",
                        DeckId = 1,
                    },
                    new Flashcard
                    {
                        Id = 2,
                        Answer = "Answer 2",
                        Question = "Question 2",
                        DeckId = 1,
                    },
                    new Flashcard
                    {
                        Id = 3,
                        Answer = "Answer 3",
                        Question = "Question 3",
                        DeckId = 1,
                    },
                    new Flashcard
                    {
                        Id = 4,
                        Answer = "Answer 4",
                        Question = "Question 4",
                        DeckId = 1,
                    },
                    new Flashcard
                    {
                        Id = 5,
                        Answer = "Answer 1 D2",
                        Question = "Question 1",
                        DeckId = 2,
                    },
                    new Flashcard
                    {
                        Id = 6,
                        Answer = "Answer 2 D2",
                        Question = "Question 2",
                        DeckId = 2,
                    },
                    new Flashcard
                    {
                        Id = 7,
                        Answer = "Answer 3 D2",
                        Question = "Question 3",
                        DeckId = 2,
                    },
                    new Flashcard
                    {
                        Id = 8,
                        Answer = "Answer 4 D2",
                        Question = "Question 4",
                        DeckId = 2,
                    });
            });
        }
    }
}