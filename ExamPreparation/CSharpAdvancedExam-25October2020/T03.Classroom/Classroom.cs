using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ClassroomProject
{
    public class Classroom
    {
        private List<Student> students;

        public Classroom(int capacity)
        {
            Capacity = capacity;
            students = new List<Student>();
        }

        public int Capacity { get; set; }

        public int Count => students.Count;

        public string RegisterStudent(Student student)
        {
            if (Count >= Capacity)
            {
                return "No seats in the classroom";
            }

            students.Add(student);
            return $"Added student {student.FirstName} {student.LastName}";
        }

        public string DismissStudent(string firstName, string lastName)
        {
            Student student = GetStudent(firstName, lastName);
            if (student == null)
            {
                return "Student not found";
            }

            students.Remove(student);
            return $"Dismissed student {firstName} {lastName}";
        }

        public string GetSubjectInfo(string subject)
        {
            if (!students.Any(x => x.Subject == subject))
            {
                return $"No students enrolled for the subject";
            }

            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"Subject: {subject}");
            sb.AppendLine("Students:");
            students.Where(x => x.Subject == subject).ToList()
                .ForEach(x => sb.AppendLine($"{x.FirstName} {x.LastName}"));

            return sb.ToString().TrimEnd();
        }

        public int GetStudentsCount() => Count;

        public Student GetStudent(string firstName, string lastName) =>
            students.FirstOrDefault(x => x.FirstName == firstName && x.LastName == lastName);
    }
}
