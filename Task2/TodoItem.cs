using System;

namespace Task2
{
    public class TodoItem
    {
        /// <summary>
        /// Universal ID of ToDoItem
        /// </summary>
        public Guid Id { get; set; } 
        
        /// <summary>
        /// Contents of ToDoItem
        /// </summary>
        public string Text { get; set; }
        
        // Shorter syntax for single line getters in C#6 //public bool IsCompleted => DateCompleted.HasValue;
        /// <summary>
        /// Is ToDoItem marked as completed 
        /// </summary>
        public bool IsCompleted
        {
            get
            {
                return DateCompleted.HasValue; 
            }
        }
        
        /// <summary>
        /// NULL value if item is not completed, else date completed
        /// </summary>
        public DateTime? DateCompleted { get; set; }
        
        /// <summary>
        /// Date entry has been created
        /// </summary>
        public DateTime DateCreated { get; set; }
    }
}