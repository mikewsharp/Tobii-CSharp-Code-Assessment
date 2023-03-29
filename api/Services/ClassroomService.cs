using System;
using System.Collections.Generic;
using edu_services.Domain;

namespace edu_services.Services
{
    public class ClassroomService
    {
        private static Classroom<Teacher, Student> _classroom = new Classroom<Teacher, Student>();
        public static ClassroomService _service = new ClassroomService();

        private ClassroomService()
        {
        }

        internal void AddStudent(Student student)
        {
            _classroom.AddStudent(student);
        }

        internal void AddTeacher(Teacher teacher)
        {
            _classroom.AddTeacher(teacher);
        }

        internal (Teacher, List<Student>) GetRoster()
        {
            var (teacher, students) = _classroom.GetRoster();
            return (teacher, students);
        }
    }
}
