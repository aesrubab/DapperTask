using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using Dapper;

namespace ConsoleApp23;

public class TeacherRepository
{
    private readonly IDbConnection _db;

    public TeacherRepository(string connectionString)
    {
        _db = new SqlConnection(connectionString);
    }

    public void Insert(Teacher teacher)
    {
        var sql = "INSERT INTO Teachers (Name, Subject, Email, Phone) VALUES (@Name, @Subject, @Email, @Phone)";
        _db.Execute(sql, teacher);
    }

    public Teacher GetById(int id)
    {
        var sql = "SELECT * FROM Teachers WHERE Id = @Id";
        return _db.Query<Teacher>(sql, new { Id = id }).FirstOrDefault();
    }


    public IEnumerable<Teacher> GetAll()
    {
        var sql = "SELECT * FROM Teachers";
        return _db.Query<Teacher>(sql).ToList();
    }

    public void Delete(int id)
    {
        var sql = "DELETE FROM Teachers WHERE Id = @Id";
        _db.Execute(sql, new { Id = id });
    }

    public void Update(Teacher teacher)
    {
        var sql = "UPDATE Teachers SET Name = @Name, Subject = @Subject, Email = @Email, Phone = @Phone WHERE Id = @Id";
        _db.Execute(sql, teacher);
    }
}
