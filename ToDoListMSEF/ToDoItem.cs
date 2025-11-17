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
        int Id { get; set; }
        string Name { get; set; }
        DateTime CreatedAt { get; set; }
        DateTime DueDate { get; set; }
        bool IsCompleted { get; set; }
    }
}
