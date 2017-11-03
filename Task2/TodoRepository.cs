using System;
using System.Collections.Generic;
using TaskNo1;
using System.Linq;

namespace Task2
{
    /// <summary >
    /// Class that encapsulates all the logic for accessing TodoTtems. 
    /// </summary >
    public class TodoRepository : ITodoRepository
    {
        /// <summary >
        /// Repository does not fetch todoItems from the actual database, 
        /// it uses in memory storage for this excersise.
        /// </summary >
        private readonly IGenericList<TodoItem> _inMemoryTodoDatabase;

        public TodoRepository(IGenericList<TodoItem> initialDbState = null)
        {
            if (initialDbState != null) 
            {
                _inMemoryTodoDatabase = initialDbState; 
            }
            else
            {
                _inMemoryTodoDatabase = new GenericList <TodoItem >();
            }
            // Shorter way to write this in C# using ?? operator:
            // x ?? y => if x is not null, expression returns x. Else it will return y.
            // _inMemoryTodoDatabase = initialDbState ?? new List<TodoItem>();
        }

        public TodoItem Get(Guid todoId)
        {
            return _inMemoryTodoDatabase.FirstOrDefault(todo => todo.Id == todoId);
        }

        public TodoItem Add(TodoItem todoItem)
        {
            if (_inMemoryTodoDatabase.Contains(todoItem))
            {
                throw new DuplicateTodoItemException($"Duplicate ID: {todoItem.Id}");
            }
            _inMemoryTodoDatabase.Add(todoItem);
            return todoItem;
        }

        public bool Remove(Guid todoId)
        {
            var victim = _inMemoryTodoDatabase.FirstOrDefault(todo => todo.Id == todoId);
            return _inMemoryTodoDatabase.Remove(victim);
        }

        public TodoItem Update(TodoItem todoItem)
        {
            var tmp = _inMemoryTodoDatabase.FirstOrDefault(t => t.Id == todoItem.Id);
            _inMemoryTodoDatabase.Add(todoItem);
            if (tmp == null)
            {
                return todoItem;
            }
            _inMemoryTodoDatabase.Remove(tmp);
            return todoItem;
        }

        public bool MarkAsCompleted(Guid todoId)
        {
            var toComplete = Get(todoId);
            if (toComplete == null) return false;
            toComplete.DateCompleted = DateTime.Now;
            Update(toComplete);
            return true;
        }

        public List<TodoItem> GetAll()
        {
            return _inMemoryTodoDatabase.Where(t => 1 > 0).OrderByDescending(t => t.DateCreated).ToList();
        }

        public List<TodoItem> GetActive()
        {
            return _inMemoryTodoDatabase.Where(t => !t.IsCompleted).ToList();
        }

        public List<TodoItem> GetCompleted()
        {
            return _inMemoryTodoDatabase.Where(t => t.IsCompleted).ToList();
        }

        public List<TodoItem> GetFiltered(Func<TodoItem, bool> filterFunction)
        {
            return _inMemoryTodoDatabase.Where(filterFunction).ToList();
        }
    }
}