using System;

namespace TODOArray.Models
{
    class Task
    {
        // fält
        public string description;
        public DateTime dueDate;

        // Konstruktor, t.ex.  new Task("Tvätta bilen", new DateTime(2021, 9, 30))
        public Task(string description, DateTime dueDate)
        {
            this.description = description;
            this.dueDate = dueDate;
        }
    }
}