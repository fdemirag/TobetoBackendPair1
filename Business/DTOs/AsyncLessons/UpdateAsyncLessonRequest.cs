﻿namespace Business.DTOs.AsyncLessons;

public class UpdateAsyncLessonRequest
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public DateTime DurationTime { get; set; }
    public DateTime TimeSpent { get; set; }
    public Guid InstructorId { get; set; }
    public Guid CourseModuleId { get; set; }
    public string Video { get; set; }

    /*public string InstructorName { get; set; }
   public string CourseModuleName { get; set; }*/
}
