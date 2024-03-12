using System;
using System.Data;
using System.Data.SqlClient;
using Dapper;
using DapperHome;
using DapperHome.Models;


string connectionString = "Data Source=KOMPUTER;Initial Catalog=Academy;Integrated Security=True;Connect Timeout=30;Encrypt=True;Trust Server Certificate=True;Application Intent=ReadWrite;Multi Subnet Failover=False";

using SqlConnection connection = new SqlConnection(connectionString);

connection.Open();
AcademyRepository repository = new AcademyRepository(connection);

var newStudent = new Student
{
  Name = "Elvin",
  Surname = "Azimov",
  Age = 22,
  Email = "profbat018@gmail.com"
};

repository.Add(newStudent);

int studentId = 1;
var reptrievedStudent = repository.Get(studentId);
Console.WriteLine($"Извлеченный студент: {reptrievedStudent.Name}, Фамилия: {reptrievedStudent.Surname}, Возвраст: {reptrievedStudent.Age}, Электронная почта: {reptrievedStudent.Email}");


reptrievedStudent.Age = 26;
repository.Update(reptrievedStudent);


repository.Delete(studentId);
Console.WriteLine("Студент удалён");
