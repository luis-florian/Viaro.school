using AutoMapper;
using School.Core.DTOs.Grade;
using School.Core.DTOs.GradeStudent;
using School.Core.DTOs.Student;
using School.Core.DTOs.Teacher;
using School.Core.Entities;

namespace School.Api.Middleware
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Student, CreateStudentDto>().ReverseMap();
            CreateMap<Student, UpdateStudentDto>().ReverseMap();

            CreateMap<Teacher, CreateTeacherDto>().ReverseMap();
            CreateMap<Teacher, UpdateTeacherDto>().ReverseMap();

            CreateMap<Grade, CreateGradeDto>().ReverseMap();
            CreateMap<Grade, UpdateGradeDto>().ReverseMap();

            CreateMap<GradeStudent, CreateGradeStudentDto>().ReverseMap();
            CreateMap<GradeStudent, UpdateGradeStudentDto>().ReverseMap();
        }
    }
}
