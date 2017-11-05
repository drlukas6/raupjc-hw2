using System;
using System.Linq;
using Student;
using Student = Student.Student;

namespace Task4
{
    public class HomeworkLinqQueries
    {
        public static string[] Linq1(int[] intArray)
        {
            var groups = intArray.OrderBy(i => i).ToArray();
            throw new NotImplementedException(); 
        }
        
        public static University[] Linq2_1(University[] universityArray)
        {
            University[] ss = universityArray.Where(s => s.Students).ToArray();
        }
        
        public static University[] Linq2_2(University[] universityArray) 
        {
            throw new NotImplementedException(); 
        }
        
        public static Student.Student[] Linq2_3(University[] universityArray)
        {
            return 
        }
        
        public static Student.Student[] Linq2_4(University[] universityArray) 
        {
            throw new NotImplementedException(); 
        }
        
        public static Student.Student[] Linq2_5(University[] universityArray) 
        {
            throw new NotImplementedException(); 
        }
    }
}