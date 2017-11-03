using System;
using System.Collections.Generic;
using Task2;

namespace ConsoleApplication
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            TodoRepository repo = new TodoRepository();
            TodoItem test1 = new TodoItem("test");
            TodoItem test2 = new TodoItem("testiranje");
            Console.WriteLine(repo.Get(test1.Id).Text);
        }
    }
}