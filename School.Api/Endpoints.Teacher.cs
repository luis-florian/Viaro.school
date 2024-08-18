using AutoMapper;
using School.Core.Contracts;
using School.Core.DTOs.Teacher;
using School.Core.Entities;

namespace School.Api
{
    public static partial class Endpoints
    {
        public static void ConfigureTeacherEndpoints(this WebApplication app)
        {
            app.MapGet("/api/teachers", async (IRepository<Teacher> db) =>
            {
                return Results.Ok(await db.GetAllAsync());
            });

            app.MapGet("/api/teachers/{id:int}", async (int id, IRepository<Teacher> db) =>
            {
                var teacher = await db.GetByIdAsync(id);
                return teacher != null ? Results.Ok(teacher) : Results.NotFound();
            });

            app.MapPost("/api/teachers", async (CreateTeacherDto createTeacherDto,
                IMapper mapper,
                IRepository<Teacher> db) =>
            {
                var teacher = mapper.Map<Teacher>(createTeacherDto);
                await db.AddAsync(teacher);
                return Results.Created($"/api/teachers/{teacher.Id}", teacher);
            });

            app.MapPut("/api/teachers/{id:int}", async (int id,
                UpdateTeacherDto updateTeacherDto,
                IMapper mapper,
                IRepository<Teacher> db) =>
            {
                var teacher = mapper.Map<Teacher>(updateTeacherDto);
                var existingTeacher = await db.GetByIdAsync(id);
                if (existingTeacher == null) return Results.NotFound();

                existingTeacher.Name = teacher.Name;
                existingTeacher.LastName = teacher.LastName;
                existingTeacher.Gender = teacher.Gender;

                await db.UpdateAsync(existingTeacher);
                return Results.NoContent();
            });

            app.MapDelete("/api/teachers/{id:int}", async (int id, IRepository<Teacher> db) =>
            {
                await db.DeleteAsync(id);
                return Results.NoContent();
            });
        }
    }
}
