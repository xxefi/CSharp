using System;
using System.Data;
using System.Data.SqlClient;
using Dapper;
using DapperHome.Models;

namespace DapperHome;

public class AcademyRepository
{
    private readonly IDbConnection _connection;

    public AcademyRepository(IDbConnection connectionString)
    {
        _connection = connectionString;
    }

    public void Add(Student student)
    {
        string query = @"INSERT INTO Students (Name, Surname, Age, Email) VALUES (@Name, @Surname, @Age, @Email)";
        _connection.Execute(query, student);
    }

    public Student Get(int id)
    {
        string query = "SELECT* From Students WHERE Id = @Id";
        return _connection.QueryFirstOrDefault<Student>(query, new { Id = id });
    }

    public void Update(Student student)
    {
        string query = @"UPDATE Students SET Name = @Name, Surname = @Surname, Age = @Age, Email = @Email  WHERE Id = @Id";
    }

    public void Delete(int id)
    {
        string query = "DELETE From Students Where Id = @Id";
        _connection.Execute(query, new { Id = id });
    }
    
}