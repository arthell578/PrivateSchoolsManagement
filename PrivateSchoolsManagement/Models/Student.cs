﻿namespace PrivateSchoolsManagement.Models
{
    public class Student
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public int ClassId { get; set; }
        public Class Class { get; set; }
    }
}
