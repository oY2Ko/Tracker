using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading;
using System.Threading.Tasks;
using Xamarin.Essentials;

namespace Tracker.Models
{
    class Student
    {
        [JsonInclude]
        public int Id { get; set; }
        [JsonInclude]
        public string Login { get; set; }
        [JsonInclude]
        public string Password { get; set; }
        [JsonInclude]
        public StudentProfile studentProfile { get; set; }
        //public override bool Equals(object obj)
        //{
        //    Student student = obj as Student;
        //    return this.Id == student.Id;
        //}

        public Student(int Id, string login, string password, StudentProfile studentProfile)
        {
            Login = login;
            Password = password;
            this.studentProfile = studentProfile;
        }
    }

    class StudentProfile
    {
        public string FirstName { get; private set; }
        public string LastName { get; private set; }

        public string GroupNumber { get; set; }
        public StudentProfile(string firstName, string lastname, string groupNubmer)
        {
            FirstName = firstName;
            LastName = lastname;
            GroupNumber = groupNubmer;
        }

    }
}
