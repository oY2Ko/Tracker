using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading;
using System.Threading.Tasks;
using Xamarin.Essentials;

namespace Tracker.Models
{
    public class Student
    {
        public int Id { get; set; }
        public string Login { get; set; }
        public string Password { get; set; }
        public StudentProfile studentProfile { get; set; }
        //public override bool Equals(object obj)
        //{
        //    Student student = obj as Student;
        //    return this.Id == student.Id;
        //}

        public Student(string login, string password, StudentProfile studentProfile)
        {
            Login = login;
            Password = password;
            this.studentProfile = studentProfile;
        }
    }

    public class StudentProfile
    {
        public string FirstName { get;  set; }
        public string LastName { get; set; }
        public string GroupNumber { get; set; }
        public  StudentProfile(string firstName, string lastname, string groupNubmer)
        {
            FirstName = firstName;
            LastName = lastname;
            GroupNumber = groupNubmer;
        }

    }
}
