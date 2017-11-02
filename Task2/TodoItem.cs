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

        /// <summary>
        /// Constructor for ToDoItem 
        /// </summary>
        /// <param name="text">Contents of ToDoItem </param>
        public TodoItem(string text)
        {
            // Generates new unique identifier
            Id = Guid.NewGuid();

            // DateTime.Now returns local time, it wont always be what you expect (depending where the server is).
            // We want to use universal (UTC) time which we can easily convert to local when needed.
            // (usually done in browser on the client side)
            DateCreated = DateTime.UtcNow;
            Text = text;
        }
    }
}