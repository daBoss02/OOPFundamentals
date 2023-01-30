using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab3
{
    public class Student
    {
        private static int _studentIdCounter = 1;
        public Enrolment? CurrentEnrolment { get; set; }
        private int _studentId;
        public int StudentId { get { return _studentId; } }
        private void _setStudentId(int studentId)
        {
            if (studentId > 0)
            {
                _studentId = studentId;
            }
            else
            {
                throw new Exception("Student ID must be greater than zero.");
            }
        }


        private string _name;
        public string Name
        {
            get { return _name; }
            set
            {
                if (value.Length > 0)
                {
                    _name = value;
                }
                else
                {
                    throw new Exception("Value cannot be empty.");
                }
            }
        }
        // === CONSTRUCTORS ===
        public Student(int studentId)
        {
            _setStudentId(studentId);
        }

        public Student(string name)
        {
            _setStudentId(_studentIdCounter);
            _studentIdCounter++;
            Name = name;
        }
    }
}
