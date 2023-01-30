using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab3
{
    public class Student
    {
        private int? _courseGrade;
        public int? CourseGrade { get { return _courseGrade; } }
        private DateTime? _registrationDate;
        public DateTime? RegistrationDate
        {
            get { return _registrationDate; }
            set
            {
                _registrationDate = value;
            }
        }

        public void UnRegister()
        {
            _registrationDate = null;
        }

        public Enrolment CurrentEnrolment { get; set; }

        public void SetCourseGrade(int grade)
        {
            if (Course == null)
            {
                throw new Exception("Not enrolled in a course");
            }
            else if (grade < 0 || grade > 100)
            {
                throw new Exception("Grade must be between 0 and 100");
            }
            else
            {
                _courseGrade = grade;
            }
        }
        public void RemoveGrade()
        {
            _courseGrade = null;
        }
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


        private string _firstName;
        public string FirstName
        {
            get { return _firstName; }
            set
            {
                if (value.Length > 0)
                {
                    _firstName = value;
                }
                else
                {
                    throw new Exception("Value cannot be empty.");
                }
            }
        }


        private string _lastName;
        public string LastName
        {
            get { return _lastName; }
            set
            {
                if (value.Length > 0)
                {
                    _lastName = value;
                }
                else
                {
                    throw new Exception("Value cannot be empty.");
                }
            }
        }

        // many students can each take one course
        public Course Course { get; set; }


        // === CONSTRUCTORS ===
        public Student(int studentId)
        {
            _setStudentId(studentId);
        }

        public Student(int studentId, string firstName, string lastName)
        {
            _setStudentId(studentId);

            // if we define public set methods on properties, we should ONLY use those to change the value of a field, so that we use their validation
            FirstName = firstName;
            LastName = lastName;

            // if we use a field to change a value, we do not validate
            // avoid direct assignment to a field (e.g. _lastName = lastName)
        }
    }
}
