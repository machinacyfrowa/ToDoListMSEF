using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToDoListMSEF
{
    /// <summary>
    /// Klasa opisuje jedno z zadań do wykonania
    /// Klasa zawiera właściwości opisujące zadanie: nazwa, data utworzenia, termin wykonania,
    /// oraz status wykonania (zrobione/nie zrobione).
    /// </summary>
    internal class ToDoItem
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime DueDate { get; set; }
        public bool IsCompleted { get; set; }
    }
}
