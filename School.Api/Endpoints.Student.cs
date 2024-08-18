using AutoMapper;
using School.Core.Contracts;
using School.Core.DTOs.Student;
using School.Core.Entities;

namespace School.Api
{
    public static partial class Endpoints
    {
        public static void ConfigureStudentEndpoints(this WebApplication app)
        {
            app.MapGet("/api/students", async (IRepository<Student> db) =>
            {
                return Results.Ok(await db.GetAllAsync());
            });

            app.MapGet("/api/students/{id:int}", async (int id, IRepository<Student> db) =>
            {
                var student = await db.GetByIdAsync(id);
                return student != null ? Results.Ok(student) : Results.NotFound();
            });

            app.MapPost("/api/students", async (CreateStudentDto createStudentDto, 
                IMapper mapper,
                IRepository<Student> db) =>
            {
                var student = mapper.Map<Student>(createStudentDto);
                await db.AddAsync(student);
                return Results.Created($"/api/students/{student.Id}", student);
            });

            app.MapPut("/api/students/{id:int}", async (int id,
                UpdateStudentDto updateStudentDto,
                IMapper mapper,
                IRepository<Student> db) =>
            {
                var student = mapper.Map<Student>(updateStudentDto);
                var existingStudent = await db.GetByIdAsync(id);
                if (existingStudent == null) return Results.NotFound();

                existingStudent.Name = student.Name;
                existingStudent.LastName = student.LastName;
                existingStudent.Gender = student.Gender;
                existingStudent.BirthDate = student.BirthDate;

                await db.UpdateAsync(existingStudent);
                return Results.NoContent();
            });

            app.MapDelete("/api/students/{id:int}", async (int id, IRepository<Student> db) =>
            {
                await db.DeleteAsync(id);
                return Results.NoContent();
            });
        }
    }
}
