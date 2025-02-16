﻿using Core.Entities.Concrete;
using Entities.Concrete;
using Entities.Concretes;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System.Reflection;

namespace DataAccess.Context;
public class TobetoDbContext : DbContext
{
    protected IConfiguration Configuration { get; set; }

    public DbSet<OperationClaim> OperationClaims { get; set; }

    public DbSet<User> Users { get; set; }
    public DbSet<UserOperationClaim> UserOperationClaims { get; set; }

    public DbSet<Employee> Employees { get; set; }
    public DbSet<EmployeeOperationClaim> EmployeeOperationClaims { get; set; }

    public DbSet<Instructor> Instructors { get; set; }
    public DbSet<InstructorOperationClaim> InstructorOperationClaims { get; set; }


    public DbSet<Notification> Notifications { get; set; }
    public DbSet<Blog> Blogs { get; set; }
    public DbSet<BlogPress> BlogsPress { get; set; }


    public DbSet<UserEducation> UserEducations { get; set; }
    public DbSet<SocialMedia> SocialMedias { get; set; }
    public DbSet<Address> Addresses { get; set; }
    public DbSet<Country> Countries { get; set; }
    public DbSet<City> Cities { get; set; }
    public DbSet<Town> Towns { get; set; }
    public DbSet<ForeignLanguage> ForeignLanguages { get; set; }
    public DbSet<ForeignLanguageLevel> ForeignLanguageLevels { get; set; }
    public DbSet<UserLanguage> UserLanguages { get; set; }
    public DbSet<Skill> Skills { get; set; }
    public DbSet<UserSkill> UserSkills { get; set; }
    public DbSet<Certificate> Certificates { get; set; }
    public DbSet<UserSocial> UserSocials { get; set; } 
    public DbSet<Experience> Experiences { get; set; }


    public DbSet<Exam> Exams { get; set; }
    public DbSet<Grade> Grades { get; set; }
    public DbSet<Question> Questions { get; set; }
    public DbSet<StudentAnswer> StudentAnswers { get; set; }
    public DbSet<AboutOfCourse> AboutOfCourses { get; set; }
    public DbSet<Category> Categories { get; set; }
    public DbSet<Homework> Homeworks { get; set; }
    public DbSet<Course> Courses { get; set; }

    public DbSet<Image> Images { get; set; }


    public DbSet<AsyncLessonDetail> AsyncLessonDetails { get; set; }
    public DbSet<CourseType> CourseTypes { get; set; }
    public DbSet<CourseModule> CourseModules { get; set; }
    public DbSet<CourseProgram> CoursePrograms { get; set; }
    public DbSet<CourseStudent> CourseStudents { get; set; }

    public DbSet<SubType> SubTypes { get; set; }
    public DbSet<Program> Programs { get; set; }
    public DbSet<LessonLanguage> LessonLanguages { get; set; }
    public DbSet<AsyncLesson> AsyncLessons { get; set; }
    public DbSet<SynchronLesson> SynchronLessons { get; set; }
    public DbSet<SynchronLessonDetail> SynchronLessonDetails { get; set; }
    public DbSet<SynchronLessonInstructor> SynchronLessonInstructors { get; set; }
    public DbSet<Manufacturer> Manufacturers { get; set; }

    public DbSet<ContactInformation> ContactInformations { get; set; }


    public TobetoDbContext(DbContextOptions dbContextOptions, IConfiguration configuration) : base(dbContextOptions)
    {
        Configuration = configuration;
      //  Database.EnsureCreated();
    }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        foreach (var relationship in modelBuilder.Model.GetEntityTypes().SelectMany(e => e.GetForeignKeys()))
        {
            relationship.DeleteBehavior = DeleteBehavior.Restrict;
        }
    }
}
