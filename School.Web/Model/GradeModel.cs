﻿namespace School.Web.Model
{
    public class GradeModel
    {
        public int Id { get; set; }
        public int TeacherId { get; set; }
        public required string Name { get; set; }
    }
}
