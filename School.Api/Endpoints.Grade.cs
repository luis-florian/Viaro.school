using AutoMapper;
using School.Core.Contracts;
using School.Core.DTOs.Grade;
using School.Core.DTOs.GradeStudent;
using School.Core.Entities;

namespace School.Api
{
    public static partial class Endpoints
    {
        public static void ConfigureGradeEndpoints(this WebApplication app)
        {
            app.MapGet("/api/grades", async (IRepository<Grade> db) =>
            {
                return Results.Ok(await db.GetAllAsync());
            });

            app.MapGet("/api/grades/{id:int}", async (int id, IRepository<Grade> db) =>
            {
                var grade = await db.GetByIdAsync(id);
                return grade != null ? Results.Ok(grade) : Results.NotFound();
            });

            app.MapPost("/api/grades", async (CreateGradeDto createGradeDto,
                IMapper mapper,
                IRepository<Teacher> dbTeacher,
                IRepository<Grade> db) =>
            {
                var existingTeacher = await dbTeacher.GetByIdAsync(createGradeDto.TeacherId);
                if (existingTeacher == null) return Results.NotFound();

                var grade = mapper.Map<Grade>(createGradeDto);
                grade.Teacher = existingTeacher;
                await db.AddAsync(grade);
                return Results.Created($"/api/grades/{grade.Id}", grade);
            });

            app.MapPut("/api/grades/{id:int}", async (int id,
                UpdateGradeDto updateGradeDto,
                IMapper mapper,
                IRepository<Grade> db) =>
            {
                var grade = mapper.Map<Grade>(updateGradeDto);
                var existingGrade = await db.GetByIdAsync(id);
                if (existingGrade == null) return Results.NotFound();

                existingGrade.Name = grade.Name;
                existingGrade.TeacherId = grade.TeacherId;

                await db.UpdateAsync(existingGrade);
                return Results.NoContent();
            });

            app.MapDelete("/api/grades/{id:int}", async (int id, IRepository<Grade> db) =>
            {
                await db.DeleteAsync(id);
                return Results.NoContent();
            });

            //app.MapPost("/api/grades/{gradeId:int}/teacher/{teacherId:int}", async (
            //    int gradeId,
            //    int teacherId,
            //    IMapper mapper,
            //    IRepository<Grade> dbGrade,
            //    IRepository<Grade> dbTeacher) =>
            //{
            //    var existingGrade = await dbGrade.GetByIdAsync(gradeId);
            //    if (existingGrade == null) return Results.NotFound();

            //    var existingTeacher = await dbTeacher.GetByIdAsync(teacherId);
            //    if (existingTeacher == null) return Results.NotFound();

            //    existingGrade.TeacherId = teacherId;

            //    await dbGrade.UpdateAsync(existingGrade);
            //    return Results.NoContent();
            //});

            app.MapPost("/api/grade/{gradeId:int}/student/{studentId:int}", async (
                int gradeId,
                int studentId,
                CreateGradeStudentDto createGradeStudentDto,
                IMapper mapper,
                IRepository<Grade> dbGrade,
                IRepository<Student> dbStudent,
                IRepository<GradeStudent> dbGradeStudent) =>
            {
                var existingGrade = await dbGrade.GetByIdAsync(gradeId);
                if (existingGrade == null) return Results.NotFound();

                var existingStudent = await dbStudent.GetByIdAsync(studentId);
                if (existingStudent == null) return Results.NotFound();

                var gradeStudent = mapper.Map<GradeStudent>(createGradeStudentDto);

                gradeStudent.GradeId = gradeId;
                gradeStudent.StudentId = studentId;

                await dbGradeStudent.AddAsync(gradeStudent);
                return Results.NoContent();
            });

            app.MapPut("/api/gradeStudent{gradeStudentId:int}", async (
                int gradeStudentId,
                UpdateGradeStudentDto updateGradeStudentDto,
                IMapper mapper,
                IRepository<Grade> dbGrade,
                IRepository<Grade> dbStudent,
                IRepository<GradeStudent> dbGradeStudent) =>
            {
                var existingGradeStudent = await dbGradeStudent.GetByIdAsync(gradeStudentId);
                if (existingGradeStudent == null) return Results.NotFound();

                var existingGrade = await dbGrade.GetByIdAsync(updateGradeStudentDto.GradeId);
                if (existingGrade == null) return Results.NotFound();

                var existingTeacher = await dbStudent.GetByIdAsync(updateGradeStudentDto.StudentId);
                if (existingTeacher == null) return Results.NotFound();

                var gradeStudent = mapper.Map<GradeStudent>(updateGradeStudentDto);

                existingGradeStudent.Section = gradeStudent.Section;
                existingGradeStudent.GradeId = gradeStudent.GradeId;
                existingGradeStudent.StudentId = gradeStudent.StudentId;

                await dbGradeStudent.UpdateAsync(existingGradeStudent);
                return Results.NoContent();
            });
        }
    }
}
