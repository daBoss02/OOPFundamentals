// Create a system in which Students can register for Courses
// A student may only take one Course, where a Course can have many students

// Student Class
// Course Class

// one-to-many relationship
using Lab3;

Course Software = new Course(200, "Software Developer", 30);
Student Jimmy = new Student(1000, "Jimmy", "Smith");

HashSet<Enrolment> enrolments = new HashSet<Enrolment>();

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


void RegisterStudent(Student student, Course course)
{
    Enrolment newEnrolment = new Enrolment(student, course);
    student.CurrentEnrolment = newEnrolment;
    course.AddEnrolment(newEnrolment);
    enrolments.Add(newEnrolment);
}
void DeregisterStudent(Student student, Course course, Enrolment enrolment)
{
    student.CurrentEnrolment = null;
    course.RemoveEnrolment(enrolment);
}