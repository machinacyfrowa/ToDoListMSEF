using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace ToDoListMSEF
{
    /// <summary>
    /// Klasa reprezentuje kontekst bazy danych dla aplikacji ToDoListMSEF.
    /// Dziedziczy po DbContext z Entity Framework Core.
    /// </summary>
    internal class Database : DbContext
    {
        /// <summary>
        /// To jest nasza baza - zbiór zadań do wykonania.
        /// </summary>
        public DbSet<ToDoItem> ToDoItems { get; set; }
        /// <summary>
        /// Ta metoda deklaruje użycie bazy danych SQLite.
        /// </summary>
        /// <param name="optionsBuilder"></param>
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            // Konfiguracja połączenia z bazą danych SQLite
            optionsBuilder.UseSqlite("Data Source=ToDoList.db");
        }
    }
}
