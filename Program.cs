using System;
using System.Collections.Generic;
using System.Threading;
using TODOArray.Models;
using static System.Console;

namespace TODOArray
{
    class Program
    {
        static void Main(string[] args)
        {
            // Task[] (array) -------------------------------------------------
            // - Sekventiell
            // - Vi kommer åt enskilda element via numeriskt index (te.x. [0])
            // - Storleken är statiskt (kan inte förändras i efterhand, dvs. när den väl skapats)

            // List<Task> -----------------------------------------------------
            // - Sekventiell
            // - Vi kommer åt enskilda element via numeriskt index (te.x. [0])
            // - Storlek är dynamisk (kan föränras i efterhand)

            List<Task> taskList = new List<Task>();

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
                        {
                            Write("Description: ");

                            string description = ReadLine();

                            Write("Due Date: ");

                            DateTime dueDate = DateTime.Parse(ReadLine());

                            Task task = new Task(description: description, dueDate: dueDate);

                            taskList.Add(task);
                            
                            Clear();

                            WriteLine("Task added");

                            Thread.Sleep(2000); // 2 sec
                        }

                        break;

                    case ConsoleKey.D2:

                        WriteLine("Task                      Due Date");
                        WriteLine("------------------------------------------");

                        //for (int i = 0; i < tasks.Length; i++)
                        foreach (Task task in taskList)
                        {
                            //if (tasks[i] == null) continue;
                            if (task == null) continue;

                            // null condition-operatorn
                            //WriteLine($"Description: {tasks[i].description}");
                            //WriteLine($"Due Date: {tasks[i].dueDate}");
                            WriteLine($"{task.description}                     {task.dueDate}");
                        }

                        ReadLine();

                        break;

                    case ConsoleKey.D3:

                        applicationRunning = false;

                        break;
                }

                Clear();

            } while (applicationRunning);


            // --------------------------------------------------------------
            // ARRAY
            // --------------------------------------------------------------

            //Task[] tasks = new Task[2];

            //int nextTaskIndex = 0;

            //CursorVisible = false;

            //bool applicationRunning = true;

            //do
            //{
            //    WriteLine("1. Add task");
            //    WriteLine("2. List tasks");
            //    WriteLine("3. Exit");

            //    ConsoleKeyInfo input = ReadKey(true);

            //    Clear();

            //    switch (input.Key)
            //    {
            //        case ConsoleKey.D1:
            //            {
            //                Write("Description: ");

            //                string description = ReadLine();

            //                Write("Due Date: ");

            //                DateTime dueDate = DateTime.Parse(ReadLine());

            //                Task task = new Task(description: description, dueDate: dueDate);

            //                tasks[nextTaskIndex++] = task;

            //                Clear();

            //                WriteLine("Task added");

            //                Thread.Sleep(2000); // 2 sec
            //            }

            //            break;

            //        case ConsoleKey.D2:

            //            WriteLine("Task                      Due Date");
            //            WriteLine("------------------------------------------");

            //            //for (int i = 0; i < tasks.Length; i++)
            //            foreach (Task task in tasks)
            //            {
            //                //if (tasks[i] == null) continue;
            //                if (task == null) continue;

            //                // null condition-operatorn
            //                //WriteLine($"Description: {tasks[i].description}");
            //                //WriteLine($"Due Date: {tasks[i].dueDate}");
            //                WriteLine($"{task.description}                     {task.dueDate}");
            //            }

            //            ReadLine();

            //            break;

            //        case ConsoleKey.D3:

            //            applicationRunning = false;

            //            break;
            //    }

            //    Clear();

            //} while (applicationRunning);
        }
    }
}
