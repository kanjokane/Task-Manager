using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Threading;
using TODOArray.Models;
using static System.Console;

namespace TODOArray
{
     class Program
     {
        static string connectionString = "Server=.;Database=TODO;Integrated Security=True";

        static List<Task> taskList = new List<Task>();
        

        public static void Main(string[] args)
        {
            
            CursorVisible = false;

            bool applicationRunning = true;

            do
            {
                WriteLine("1. Add task");
                WriteLine("2. List tasks");
                WriteLine("3. Exit");

                ConsoleKeyInfo input = ReadKey(true);

                Clear();

                switch (input.Key)
                {
                    case ConsoleKey.D1:
                        
                        AddTask();
                        
                        break;

                    case ConsoleKey.D2:

                        ListTasks();

                        break;

                    case ConsoleKey.D3:

                        applicationRunning = false;

                        break;
                }

                Clear();

            } while (applicationRunning);
        }
        private static void AddTask()
        {
            Write("Description: ");

            string description = ReadLine();

            Write("Due Date: ");

            DateTime dueDate = DateTime.Parse(ReadLine());

            Task task = new Task(description: description, dueDate: dueDate);

            string sql = @"
                    INSERT INTO Tasks (
                       Description, 
                       DueDate
                       ) VALUES (
                        @Description,  
                        @DueDate
                        )";
            using SqlConnection connection = new(connectionString);
            using SqlCommand command = new(sql, connection);

            command.Parameters.AddWithValue("@Description", task.Description);
            command.Parameters.AddWithValue("@DueDate", task.DueDate);

            connection.Open();

            command.ExecuteNonQuery();

            connection.Close();

            NotifyWithDelay("Task added", clear: true);

            Clear();

        }

        private static void NotifyWithDelay(string message, bool clear, int delayInSeconds = 2000)
        {
            if(clear) Clear();

            WriteLine("Task added");

            Thread.Sleep(delayInSeconds);
        }

        private static void ListTasks()
        {
            List<Task> taskList = FetchTasks();

            WriteLine("ID     Task                      Due Date");
            WriteLine("------------------------------------------");

            //for (int i = 0; i < tasks.Length; i++)
            foreach (Task task in taskList)
            {
                //if (tasks[i] == null) continue;
                if (task == null) continue;

                // null condition-operatorn
                //WriteLine($"Description: {tasks[i].description}");
                //WriteLine($"Due Date: {tasks[i].dueDate}");
                WriteLine($"{task.Id}  {task.Description}                     {task.DueDate}");
            }

            DeleteTask();

            ReadLine();
        }

        private static void DeleteTask()
        {
            WriteLine("\n(D)elete");

            var userInput = ReadKey(true);

            if (userInput.Key == ConsoleKey.D)
            {
                Write("ID: ");
                string idToDelete = ReadLine();

                string sql = @"
                    DELETE FROM 
                          Tasks  
                    WHERE 
                          Id=" + idToDelete
               ;

                using SqlConnection connection = new(conectionString);
                using SqlCommand command = new(sql, connection);

                connection.Open();

                command.ExecuteNonQuery();

                WriteLine($"You succesfully deleted ID: {idToDelete}");
            }
        }

        private static List<Task> FetchTasks()
        {
            string sql = @"
                SELECT Id,
                       Description,
                       DueDate
                  FROM Tasks

            ";

            using SqlConnection connection = new(conectionString);
            using SqlCommand command = new(sql, connection);

            connection.Open();

            //SqlDataReader reader =
            var reader = command.ExecuteReader();

            var taskList = new List<Task>();

            while (reader.Read())
            {
                var task = new Task(
                    id: (int)reader["Id"],
                    description: (string)reader["Description"],
                    dueDate: (DateTime)reader["DueDate"]);

                taskList.Add(task);
            }

            return taskList;
        }
    }
}
