using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IOCDemo.V1.Models
{
    public class Teacher
    {
        public School _school { get; set; }

        public Teacher(School school)
        {
            this._school = school;
        }
    }
}
