using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using VRM.DAL.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace VRM.DAL.Data
{
    public partial class VRMContext : IdentityDbContext<User, AppRole, string>
    {
        public VRMContext(DbContextOptions<VRMContext> options)
            : base(options)
        {
            //Database.EnsureCreated();
        }

        public DbSet<Admin> Admin { get; set; }
        public DbSet<Answer> Answer { get; set; }
        public DbSet<Question> Question { get; set; }
        public DbSet<Teacher> Teacher { get; set; }
        public DbSet<Test> Test { get; set; }
        public DbSet<Student> Student { get; set; }
        public DbSet<TQ> tqs { get; set; }
        public DbSet<TS> tss { get; set; }
        public DbSet<QA> qas { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Teacher>().HasData(
            new Teacher[]
                {
                    new Teacher
                    {
                        TeacherId = 1,
                        AdminId = 1,
                        Email = "teacher1@gmail.com",
                        Username = "Techer1",
                        Password = "123"
                    },
                }) ;
            modelBuilder.Entity<Student>().HasData(
            new Student[]
                {
                    new Student
                    {
                        StudentId = 1,
                        Email = "stud1@gmail.com",
                        Password = "123",
                        Username = "Student1"
                    },
                });
            modelBuilder.Entity<Admin>().HasData(
            new Admin[]
                {
                    new Admin
                    {
                        AdminId = 1,
                        Email = "adm1@gmail.com",
                        Password = "admin",
                        Username = "Admin"
                    },
                });
            modelBuilder.Entity<Test>().HasData(
            new Test[]
                {
                    new Test
                    {
                        TestId = 1,
                        Time = 15,
                        Title = "Test1",
                        Date = DateTime.Parse("06/06/2022")
                    },
                });
            modelBuilder.Entity<Question>().HasData(
            new Question[]
                {
                    new Question
                    {
                        QuestionId = 1,
                        Question1 = "What is your name?"
                    },
                });
            modelBuilder.Entity<Answer>().HasData(
            new Answer[]
                {
                    new Answer
                    {
                        AnswerId = 1, Answer1 = "Dunno"
                    },
                });

            modelBuilder.Entity<Test>()
            .HasMany(p => p.Questions);

            modelBuilder.Entity<Test>()
            .HasMany(p => p.Students);

            modelBuilder.Entity<Teacher>()
            .HasMany(p => p.Tests);

            modelBuilder.Entity<Question>()
            .HasMany(p => p.Answers);

            base.OnModelCreating(modelBuilder);
    }
}
