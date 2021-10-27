using System;

namespace TODOArray.Models
{
    class Task
    {
        // Properties

        public int Id { get; }
        public string Description { get; }
        public DateTime DueDate { get; }

        // Konstruktor, t.ex.  new Task("Tvätta bilen", new DateTime(2021, 9, 30))
        public Task(string description, DateTime dueDate)
        {
            Description = description;
            DueDate = dueDate;
            
        }

        public Task(int id, string description, DateTime dueDate)
        {
            Description = description;
            DueDate = dueDate;
            Id = id;

        }
    }
}