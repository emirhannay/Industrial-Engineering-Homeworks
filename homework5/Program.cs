using System;
using System.Collections.Generic;

class Student
{
    public int studentNo { get; set; }
    public string fullName { get; set; }
    public int grade { get; set; }
    public List<string> courses { get; set; }
}

class StudentManagementSystem
{
    //Defining the variable as const guarantees that it cannot be changed later.
    private const int MaxStudents = 50;


    private List<Student> students;

    public StudentManagementSystem()
    {
        students = new List<Student>();

        
    }
    
    public void AddStudent (Student student )
    {

        if (students.Count < MaxStudents)
        {
            students.Add(student);
        }
        else
        {
            Console.WriteLine("Öğrenci yönetim sistmei dolu. Öğrenci Eklenemedi.");
        }
    } 
  

    public void DeleteStudent(int studentNo)
    {
        Student studentToRemove = students.Find(s => s.studentNo == studentNo);
        if (studentToRemove != null)
        {
            students.Remove(studentToRemove);
        }
        else
        {
            Console.WriteLine("Öğrenci Bulunamadı.");
        }
    }

    public void UpdateStudent(int studentNo, Student updatedStudent)
    {
        Student studentToUpdate = students.Find(s => s.studentNo == studentNo);
        if (studentToUpdate != null)
        {
            int index = students.IndexOf(studentToUpdate);
            students[index] = updatedStudent;
        }
        else
        {
            Console.WriteLine("Öğrenci Bulunamadı.");
        }
    }

    public void ListStudents()
    {
        int i = 1;
        foreach (var student in students)
        {
            
            Console.WriteLine(i +". Öğrenci = "+$"No: {student.studentNo}, İsim: {student.fullName}, Sınıf: {student.grade}, Dersler: {string.Join(", ", student.courses)}");
            i++;
        }
    }

    public int WriteTotalStudentsCount()
    {
        return students.Count;
    }
}

class Program
{
    static void Main()
    {
        StudentManagementSystem sms = new StudentManagementSystem();      

        //Add students
        Student student1 = new Student { studentNo = 2023001, fullName = "Ahmet Yılmaz", grade = 11, courses = new List<string> { "Matematik", "Fizik", "Kimya" } };
        Student student2 = new Student { studentNo = 2023002, fullName = "Ayşe Demir", grade = 10, courses = new List<string> { "Türkçe", "Edebiyat", "Biyoloji" } };
        Student student3 = new Student { studentNo = 2023003, fullName = "Mehmet Kaya", grade = 12, courses = new List<string> { "Tarih", "Coğrafya", "İngilizce" } };
        Student student4 = new Student { studentNo = 2023004, fullName = "Zeynep Akgün", grade = 11, courses = new List<string> { "Kimya", "Fizik", "Matematik" } };
        Student student5 = new Student { studentNo = 2023005, fullName = "Mustafa Öztürk", grade = 9, courses = new List<string> { "Biyoloji", "Türkçe", "Fizik" } };

        sms.AddStudent(student1);
        sms.AddStudent(student2);
        sms.AddStudent(student3);
        sms.AddStudent(student4);
        sms.AddStudent(student5);

        //List All Students
        Console.WriteLine("List All Students");
        sms.ListStudents();

        //Update Student Then Write All Students To Console
        Student updatedStudent = new Student { studentNo = 2023001, fullName = "Ahmet Yılmaz", grade = 11, courses = new List<string> { "Beden Eğitimi", "Tarih", "Biyoloji" } };
        Student updatedStudent2 = new Student { studentNo = 2023002, fullName = "Ayşe Demir", grade = 9, courses = new List<string> { "Müzik", "Din Kültürü", "Fizik" } };
        sms.UpdateStudent(2023001, updatedStudent);
        sms.UpdateStudent(2023002, updatedStudent2);

        //Update Student Then Write All Students To Console
        Console.WriteLine("\nList All Students Then Update Student:");
        sms.ListStudents();

        //Remove Student According To Student No
        sms.DeleteStudent(2023002);
        sms.DeleteStudent(2023003);

        //List All Students Then Remove Student
        Console.WriteLine("\nBefore Delete Student:");
        sms.ListStudents();

        //Write Students Count In System
        Console.WriteLine("Total students in Student Management System: " + sms.WriteTotalStudentsCount());
    }
}
