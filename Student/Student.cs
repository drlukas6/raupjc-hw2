using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Security.Cryptography;
using System.Xml.Xsl.Runtime;

namespace Student
{
    public class Student 
    {
        
        public string Name { get; set; } 
        public string Jmbag { get; set; } 
        public Gender Gender { get; set; }
        public Student(string name, string jmbag) 
        {
            Name = name;
            Jmbag = jmbag; 
        }

        public override bool Equals(object obj)
        {
            Student tmp = obj as Student;
            if (obj is Student)
            {
                if (this == (Student) obj)
                {
                    return true;
                }
                return false;
            }
            return false;
        }

        public override int GetHashCode()
        {
            var hashCode = 430495180;
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(Name);
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(Jmbag);
            hashCode = hashCode * -1521134295 + Gender.GetHashCode();
            return hashCode;
        }



        public static bool operator ==(Student s1, Student s2)
        {
            if (s1.Equals(null) || s2.Equals(null))
            {
                return false;
            }
            if (s1.Name == null || s2.Name == null || s1.Jmbag == null || s2.Jmbag == null)
            {
                return false;
            }
            if (s1.Name == s2.Name && s1.Jmbag == s2.Jmbag && s1.Gender == s2.Gender)
            {
                return true;
            }
            return false;
        }
        
        public static bool operator !=(Student s1, Student s2)
        {
            return !(s1 == s2);
        }
        
        
        public void Case1 ()
        {
            var topStudents = new List <Student >() 
            {
                new Student("Ivan", jmbag:"001234567"), 
                new Student("Luka", jmbag:"3274272"), 
                new Student("Ana", jmbag:"9382832")
            };
            var ivan = new Student("Ivan", jmbag: "001234567");
            
            // false :(
            bool isIvanTopStudent = topStudents.Contains(ivan);
            

        }
        
        
        void Case2 ()
        {
            var list = new List<Student>() 
            {
                new Student("Ivan", jmbag:"001234567"),
                new Student("Ivan", jmbag:"001234567") 
            };
            // 2 :(
            var distinctStudentsCount = list.Distinct().Count();
        }
        
        void Case3 ()
        {
            var topStudents = new List <Student >() {
                new Student("Ivan", jmbag:"001234567"), 
                new Student("Luka", jmbag:"3274272"), 
                new Student("Ana", jmbag:"9382832")
            };
            var ivan = new Student("Ivan", jmbag: "001234567");
            
            // false :(
            // == operator is a different operation from .Equals() // Maybe it isn’t such a bad idea to override it as well 
            bool isIvanTopStudent = topStudents.Any(s => s == ivan);
            

        }


        
    }
    
    public enum Gender 
    {
        Male , Female 
    }
    
    
    
}
