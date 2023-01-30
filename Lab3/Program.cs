// Create a system in which Students can register for Courses
// A student may only take one Course, where a Course can have many students

// Student Class
// Course Class

// one-to-many relationship
using Lab3;
using System.ComponentModel.DataAnnotations;

Course Software = new Course("Software Developer");
Student Jimmy = new Student("Jimmy");

HashSet<Enrolment> enrolments = new HashSet<Enrolment>();
HashSet<Student> students = new HashSet<Student>();
HashSet<Course> courses = new HashSet<Course>();

// a course can have many students in it
// and a student can take one course
// one-to-many relationship (one course, many students)

// "one" component needs a collection of the many (course needs a collection of students)
// "many" component needs a property for the "one" (student needs a property of Course)

// something outside of the objects creating the relationship between them

try
{
    RegisterStudent(Jimmy, Software);
    //DeregisterStudent(Jimmy, Software);
    //Console.WriteLine(Jimmy.Course.Title);
} catch (Exception ex)
{
    Console.WriteLine(ex.Message.ToString());
}

Console.WriteLine("Who would you like to register?");
Console.Write("Name: ");
string name = Console.ReadLine();
while (string.IsNullOrWhiteSpace(name))
{
    Console.WriteLine("Error: please input name:");
    name = Console.ReadLine();
}
Student newStudent = new Student(name);
Console.WriteLine("What course would you like to register them in?");
Console.Write("Course Name: ");
string courseName = Console.ReadLine();
while (string.IsNullOrWhiteSpace(courseName))
{
    Console.WriteLine("Error: please input course name:");
    courseName = Console.ReadLine();
}
Course newCourse = new Course(courseName);
courses.Add(newCourse);
students.Add(newStudent);
RegisterStudent(newStudent, newCourse);
bool operation = true;

while (operation)
{
    int option = 0;
    Console.WriteLine("What would you like to do?");
    Console.WriteLine("Type 'cancel' to exit");
    Console.WriteLine("1: Register a student");
    Console.WriteLine("2: Remove a student from a course");
    string selection = Console.ReadLine();
    while (!selection.Trim().All(c => char.IsDigit(c)) && selection.ToLower().Trim() != "cancel")
    {
        Console.WriteLine("Please select a valid option");
        selection = Console.ReadLine();
    }
    if (selection == "cancel")
    {
        break;
    } else
    {
        option = Int32.Parse(selection.Trim());
    }
    if (option == 1)
    {
        Console.WriteLine("Who would you like to register?");
        Console.Write("Name: ");
        name = Console.ReadLine();
        while (string.IsNullOrWhiteSpace(name))
        {
            Console.WriteLine("Error: please input name:");
            name = Console.ReadLine();
        }
        if (name.ToLower() == "cancel")
        {
            break;
        }
        newStudent = new Student(name);
        Console.WriteLine("What course would you like to register them in?");
        Console.Write("Course Name: ");
        courseName = Console.ReadLine();
        while (string.IsNullOrWhiteSpace(courseName))
        {
            Console.WriteLine("Error: please input course name:");
            courseName = Console.ReadLine();
        }
        bool alreadyThere = false;
        foreach (Course c in courses)
        {
            if (courseName == c.Title)
            {
                newCourse = c;
                alreadyThere = true;
                break;
            }
        }
        if (!alreadyThere)
        {
            newCourse = new Course(courseName);
        }
        courses.Add(newCourse);
        students.Add(newStudent);
        RegisterStudent(newStudent, newCourse);
    } else if (option == 2)
    {
        Console.WriteLine("Please input the ID of the student you wish to deregister:");
        string studentId = Console.ReadLine();
        while (!studentId.All(c => Char.IsDigit(c)) && studentId.ToLower() != "cancel")
        {
            Console.WriteLine("Please enter a valid id");
            studentId = Console.ReadLine();
        }
        if (studentId.Trim() == "cancel") { break; }
        int sId = Int32.Parse(studentId.Trim());

        DeregisterStudent(sId);
    }
}


void RegisterStudent(Student student, Course course)
{
    Enrolment newEnrolment = new Enrolment(student, course);
    student.CurrentEnrolment = newEnrolment;
    course.AddEnrolment(newEnrolment);
    enrolments.Add(newEnrolment);
    Console.WriteLine($"Student {student.StudentId}: {student.Name} has been registered in course {course.CourseId}: {course.Title}");
}
void DeregisterStudent(int studentId)
{
    Student? student = null;
    foreach (Student s in students)
    {
        if (s.StudentId == studentId)
        {
            student = s;
        }
    }
    if (student == null)
    {
        Console.WriteLine("Student does not exist");
        return;
    }
    Enrolment? enrolment = student.CurrentEnrolment;
    Course? course = student.CurrentEnrolment.Course;
    course.RemoveEnrolment(enrolment);
    student.CurrentEnrolment = null;
    Console.WriteLine($"{student.Name} has been removed from {course.Title}");
}