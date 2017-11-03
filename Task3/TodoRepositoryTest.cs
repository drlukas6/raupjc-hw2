using System;
using System.Collections.Generic;
using NUnit.Framework;
using Task2;

namespace Task3
{
    
    [TestFixture]
    public class TodoRepositoryTest
    {
        private TodoRepository _repoTest;
        private TodoItem test1, test2, test3, test4;

        [SetUp]
        protected void SetUp()
        {
            _repoTest = new TodoRepository();
            
            test1 = new TodoItem("Buy bread");
            test2 = new TodoItem("Study C#");
            test3 = new TodoItem("Make Unit Tests");
            test4 = new TodoItem("Drink 10th cup of coffee");
            
            
        }
        
        [Test]
        public void Add()
        {
            Assert.AreNotEqual(_repoTest, null);
            Assert.AreEqual(_repoTest.Add(test1),test1);
            Assert.AreNotEqual(_repoTest.Add(test2),test3);
            _repoTest.Add(test3);
            _repoTest.Add(test4);
        }
        
        

        [Test]
        public void GetTest()
        {
            TodoItem test6 = new TodoItem("testGet");
            _repoTest.Add(test6);
            Assert.AreEqual(_repoTest.Get(test6.Id),test6);
        }

        [Test]
        public void RemoveTest()
        {
            TodoItem test6 = new TodoItem("testGet");
            _repoTest.Add(test6);
            Assert.AreEqual(_repoTest.Remove(test6.Id),true);
            TodoItem test7 = new TodoItem("testNotAddedShouldBeFalse");
            Assert.AreNotEqual(_repoTest.Remove(test7.Id),true);
        }

        [Test]
        public void UpdateTest()
        {
            test1 = new TodoItem("This will be updated");
            test2 = new TodoItem("This is a tmp toDo item");
            _repoTest.Add(test1);
            _repoTest.Add(test2);
            test1.DateCompleted = DateTime.Now;
            
            Assert.AreEqual(_repoTest.Update(test1),test1);
        }

        [Test]
        public void MarkAsCompletedTest()
        {
            test1 = new TodoItem("When added was not completed");
            _repoTest.Add(test1);
            Assert.IsTrue(_repoTest.MarkAsCompleted(test1.Id));
        }

        [Test]
        public void ReturnAllTest()
        {
            test1 = new TodoItem("abcd");
            test2 = new TodoItem("abcde");
            test3 = new TodoItem("abcdef");
            _repoTest.Add(test1);
            _repoTest.Add(test2);
            _repoTest.Add(test3);
            List<TodoItem> secondRepo = _repoTest.GetAll();
            Assert.AreEqual(secondRepo[2].Id,test1.Id);
        }
        
        
    }
}