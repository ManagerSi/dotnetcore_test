using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IOCDemo.V1.Models
{
    public class Student
    {
        public School _school { get; set; }
        public Teacher _teacher { get; set; }

        public Student(School school, Teacher teacher)
        {
            this._school = school;
            this._teacher = teacher;
        }
    }
}
