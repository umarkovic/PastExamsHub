﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using PastExamsHub.Core.Infrastructure.Persistence;

namespace PastExamsHub.Core.Infrastructure.Persistence.Migrations.CoreDb
{
    [DbContext(typeof(CoreDbContext))]
    [Migration("20240203220041_AddsExamSolutionTable")]
    partial class AddsExamSolutionTable
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.12")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("PastExamsHub.Core.Domain.Entities.Course", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("CourseType")
                        .HasColumnType("int");

                    b.Property<int>("ESPB")
                        .HasColumnType("int");

                    b.Property<int?>("LecturerId")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Semester")
                        .HasColumnType("int");

                    b.Property<int>("StudyType")
                        .HasColumnType("int");

                    b.Property<int>("StudyYear")
                        .HasColumnType("int");

                    b.Property<string>("Uid")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("Id");

                    b.HasIndex("LecturerId");

                    b.ToTable("Courses");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            CourseType = 1,
                            ESPB = 6,
                            LecturerId = 2,
                            Name = "Algoritmi i programiranje",
                            Semester = 2,
                            StudyType = 1,
                            StudyYear = 1,
                            Uid = "aip"
                        },
                        new
                        {
                            Id = 2,
                            CourseType = 1,
                            ESPB = 6,
                            LecturerId = 2,
                            Name = "Elektronske komponente",
                            Semester = 1,
                            StudyType = 1,
                            StudyYear = 1,
                            Uid = "elkomp"
                        },
                        new
                        {
                            Id = 3,
                            CourseType = 1,
                            ESPB = 6,
                            LecturerId = 2,
                            Name = "Fizika",
                            Semester = 1,
                            StudyType = 1,
                            StudyYear = 1,
                            Uid = "fizika"
                        },
                        new
                        {
                            Id = 4,
                            CourseType = 1,
                            ESPB = 3,
                            LecturerId = 2,
                            Name = "Lab praktikum - Fizika",
                            Semester = 1,
                            StudyType = 1,
                            StudyYear = 1,
                            Uid = "labfizika"
                        },
                        new
                        {
                            Id = 5,
                            CourseType = 1,
                            ESPB = 6,
                            LecturerId = 2,
                            Name = "Matematika 1",
                            Semester = 1,
                            StudyType = 1,
                            StudyYear = 1,
                            Uid = "mat1"
                        },
                        new
                        {
                            Id = 6,
                            CourseType = 1,
                            ESPB = 5,
                            LecturerId = 2,
                            Name = "Matematika 2",
                            Semester = 2,
                            StudyType = 1,
                            StudyYear = 1,
                            Uid = "mat2"
                        },
                        new
                        {
                            Id = 7,
                            CourseType = 1,
                            ESPB = 6,
                            LecturerId = 2,
                            Name = "Osnovi elektrotehnike 1",
                            Semester = 1,
                            StudyType = 1,
                            StudyYear = 1,
                            Uid = "oe1"
                        },
                        new
                        {
                            Id = 8,
                            CourseType = 1,
                            ESPB = 6,
                            LecturerId = 2,
                            Name = "Osnovi elektrotehnike 2",
                            Semester = 2,
                            StudyType = 1,
                            StudyYear = 1,
                            Uid = "oe2"
                        },
                        new
                        {
                            Id = 9,
                            CourseType = 1,
                            ESPB = 3,
                            LecturerId = 2,
                            Name = "Uvod u elektroniku",
                            Semester = 2,
                            StudyType = 1,
                            StudyYear = 1,
                            Uid = "uue"
                        },
                        new
                        {
                            Id = 10,
                            CourseType = 1,
                            ESPB = 3,
                            LecturerId = 2,
                            Name = "Uvod u inzenjerstvo",
                            Semester = 2,
                            StudyType = 1,
                            StudyYear = 1,
                            Uid = "uui"
                        },
                        new
                        {
                            Id = 11,
                            CourseType = 1,
                            ESPB = 3,
                            LecturerId = 2,
                            Name = "Uvod u racunarstvo",
                            Semester = 2,
                            StudyType = 1,
                            StudyYear = 1,
                            Uid = "uur"
                        },
                        new
                        {
                            Id = 12,
                            CourseType = 1,
                            ESPB = 6,
                            LecturerId = 2,
                            Name = "Arhitektura i organizacija racunara",
                            Semester = 1,
                            StudyType = 1,
                            StudyYear = 2,
                            Uid = "aor"
                        },
                        new
                        {
                            Id = 13,
                            CourseType = 1,
                            ESPB = 6,
                            LecturerId = 2,
                            Name = "Baze Podataka",
                            Semester = 1,
                            StudyType = 1,
                            StudyYear = 2,
                            Uid = "baze"
                        },
                        new
                        {
                            Id = 14,
                            CourseType = 1,
                            ESPB = 5,
                            LecturerId = 2,
                            Name = "Digitalna elektronika",
                            Semester = 1,
                            StudyType = 1,
                            StudyYear = 2,
                            Uid = "digitalelekt"
                        },
                        new
                        {
                            Id = 15,
                            CourseType = 1,
                            ESPB = 5,
                            LecturerId = 2,
                            Name = "Diskretna matematika",
                            Semester = 1,
                            StudyType = 1,
                            StudyYear = 2,
                            Uid = "diskrmat"
                        },
                        new
                        {
                            Id = 16,
                            CourseType = 2,
                            ESPB = 5,
                            LecturerId = 2,
                            Name = "Logicko projektovanje",
                            Semester = 2,
                            StudyType = 1,
                            StudyYear = 2,
                            Uid = "logproj"
                        },
                        new
                        {
                            Id = 17,
                            CourseType = 2,
                            ESPB = 6,
                            LecturerId = 2,
                            Name = "Matematicki metodi u racunarstvu",
                            Semester = 1,
                            StudyType = 1,
                            StudyYear = 2,
                            Uid = "mmur"
                        },
                        new
                        {
                            Id = 18,
                            CourseType = 1,
                            ESPB = 6,
                            LecturerId = 2,
                            Name = "Objektno orijentisano programiranje",
                            Semester = 2,
                            StudyType = 1,
                            StudyYear = 2,
                            Uid = "oop"
                        },
                        new
                        {
                            Id = 19,
                            CourseType = 1,
                            ESPB = 6,
                            LecturerId = 2,
                            Name = "Programski jezici",
                            Semester = 1,
                            StudyType = 1,
                            StudyYear = 2,
                            Uid = "pj"
                        },
                        new
                        {
                            Id = 20,
                            CourseType = 1,
                            ESPB = 6,
                            LecturerId = 2,
                            Name = "Strukture Podataka",
                            Semester = 2,
                            StudyType = 1,
                            StudyYear = 2,
                            Uid = "strukture"
                        },
                        new
                        {
                            Id = 21,
                            CourseType = 1,
                            ESPB = 6,
                            LecturerId = 2,
                            Name = "Racunarski Sistemi",
                            Semester = 1,
                            StudyType = 1,
                            StudyYear = 2,
                            Uid = "rs"
                        },
                        new
                        {
                            Id = 22,
                            CourseType = 2,
                            ESPB = 6,
                            LecturerId = 2,
                            Name = "Teorija grafova",
                            Semester = 1,
                            StudyType = 1,
                            StudyYear = 2,
                            Uid = "tg"
                        },
                        new
                        {
                            Id = 23,
                            CourseType = 2,
                            ESPB = 6,
                            LecturerId = 2,
                            Name = "Verovatnoca i statistika",
                            Semester = 2,
                            StudyType = 1,
                            StudyYear = 2,
                            Uid = "statistika"
                        },
                        new
                        {
                            Id = 24,
                            CourseType = 1,
                            ESPB = 6,
                            LecturerId = 2,
                            Name = "Distribuirani Sistemi",
                            Semester = 1,
                            StudyType = 1,
                            StudyYear = 3,
                            Uid = "ds"
                        },
                        new
                        {
                            Id = 25,
                            CourseType = 1,
                            ESPB = 6,
                            LecturerId = 2,
                            Name = "Engleski jezik 1",
                            Semester = 1,
                            StudyType = 1,
                            StudyYear = 3,
                            Uid = "eng1"
                        },
                        new
                        {
                            Id = 26,
                            CourseType = 1,
                            ESPB = 6,
                            LecturerId = 2,
                            Name = "Engleski jezik 2",
                            Semester = 1,
                            StudyType = 1,
                            StudyYear = 3,
                            Uid = "eng2"
                        },
                        new
                        {
                            Id = 27,
                            CourseType = 1,
                            ESPB = 6,
                            LecturerId = 2,
                            Name = "Informacioni sistemi",
                            Semester = 1,
                            StudyType = 1,
                            StudyYear = 3,
                            Uid = "is"
                        },
                        new
                        {
                            Id = 28,
                            CourseType = 1,
                            ESPB = 6,
                            LecturerId = 2,
                            Name = "Mikroracunarski sistemi",
                            Semester = 2,
                            StudyType = 1,
                            StudyYear = 3,
                            Uid = "mkis"
                        },
                        new
                        {
                            Id = 29,
                            CourseType = 1,
                            ESPB = 6,
                            LecturerId = 2,
                            Name = "Objektno orijentisano projektovanje",
                            Semester = 1,
                            StudyType = 1,
                            StudyYear = 3,
                            Uid = "ooproj"
                        },
                        new
                        {
                            Id = 30,
                            CourseType = 1,
                            ESPB = 6,
                            LecturerId = 2,
                            Name = "Racunarske mreze",
                            Semester = 1,
                            StudyType = 1,
                            StudyYear = 3,
                            Uid = "mreze"
                        },
                        new
                        {
                            Id = 31,
                            CourseType = 1,
                            ESPB = 6,
                            LecturerId = 2,
                            Name = "Sistemi baza podataka",
                            Semester = 2,
                            StudyType = 1,
                            StudyYear = 3,
                            Uid = "sitemibaza"
                        },
                        new
                        {
                            Id = 32,
                            CourseType = 1,
                            ESPB = 6,
                            LecturerId = 2,
                            Name = "Softversko inzenjerstvo",
                            Semester = 2,
                            StudyType = 1,
                            StudyYear = 3,
                            Uid = "softversko"
                        },
                        new
                        {
                            Id = 33,
                            CourseType = 1,
                            ESPB = 6,
                            LecturerId = 2,
                            Name = "Web programiranje",
                            Semester = 2,
                            StudyType = 1,
                            StudyYear = 3,
                            Uid = "webprog"
                        },
                        new
                        {
                            Id = 34,
                            CourseType = 1,
                            ESPB = 6,
                            LecturerId = 2,
                            Name = "Napredne baze podataka",
                            Semester = 2,
                            StudyType = 1,
                            StudyYear = 4,
                            Uid = "npbaze"
                        },
                        new
                        {
                            Id = 35,
                            CourseType = 1,
                            ESPB = 6,
                            LecturerId = 2,
                            Name = "Paralelni sistemi",
                            Semester = 1,
                            StudyType = 1,
                            StudyYear = 4,
                            Uid = "ps"
                        },
                        new
                        {
                            Id = 36,
                            CourseType = 1,
                            ESPB = 6,
                            LecturerId = 2,
                            Name = "Programski prevodioci",
                            Semester = 1,
                            StudyType = 1,
                            StudyYear = 4,
                            Uid = "pprevodioci"
                        },
                        new
                        {
                            Id = 37,
                            CourseType = 1,
                            ESPB = 6,
                            LecturerId = 2,
                            Name = "Racunarska grafika",
                            Semester = 2,
                            StudyType = 1,
                            StudyYear = 4,
                            Uid = "grafika"
                        },
                        new
                        {
                            Id = 38,
                            CourseType = 1,
                            ESPB = 6,
                            LecturerId = 2,
                            Name = "Vestacka inteligencija",
                            Semester = 2,
                            StudyType = 1,
                            StudyYear = 4,
                            Uid = "vestacka"
                        },
                        new
                        {
                            Id = 39,
                            CourseType = 1,
                            ESPB = 6,
                            LecturerId = 2,
                            Name = "Zastita informacija",
                            Semester = 1,
                            StudyType = 1,
                            StudyYear = 4,
                            Uid = "zastita"
                        });
                });

            modelBuilder.Entity("PastExamsHub.Core.Domain.Entities.Document", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<byte[]>("Content")
                        .HasColumnType("varbinary(max)");

                    b.Property<string>("ContentType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FileName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Uid")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("Id");

                    b.ToTable("Document");
                });

            modelBuilder.Entity("PastExamsHub.Core.Domain.Entities.Exam", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("CourseId")
                        .HasColumnType("int");

                    b.Property<DateTime>("CreatedDateTimeUtc")
                        .HasColumnType("datetime2");

                    b.Property<int?>("DocumentId")
                        .HasColumnType("int");

                    b.Property<DateTime>("ExamDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Notes")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("NumberOfTasks")
                        .HasColumnType("int");

                    b.Property<int?>("PeriodId")
                        .HasColumnType("int");

                    b.Property<int>("Type")
                        .HasColumnType("int");

                    b.Property<string>("Uid")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("Id");

                    b.HasIndex("CourseId");

                    b.HasIndex("DocumentId");

                    b.HasIndex("PeriodId");

                    b.ToTable("Exams");
                });

            modelBuilder.Entity("PastExamsHub.Core.Domain.Entities.ExamPeriod", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("EndDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("PeriodType")
                        .HasColumnType("int");

                    b.Property<DateTime>("StartDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Uid")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("Id");

                    b.ToTable("ExamPeriods");
                });

            modelBuilder.Entity("PastExamsHub.Core.Domain.Entities.ExamPeriodExam", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("ExamId")
                        .HasColumnType("int");

                    b.Property<int?>("ExamPeriodId")
                        .HasColumnType("int");

                    b.Property<string>("Uid")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("Id");

                    b.HasIndex("ExamId");

                    b.HasIndex("ExamPeriodId");

                    b.ToTable("ExamPeriodExam");
                });

            modelBuilder.Entity("PastExamsHub.Core.Domain.Entities.ExamSolution", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Comment")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("CreatedDateTimeUtc")
                        .HasColumnType("datetime2");

                    b.Property<int?>("DocumentId")
                        .HasColumnType("int");

                    b.Property<int?>("ExamId")
                        .HasColumnType("int");

                    b.Property<int>("GradeCount")
                        .HasColumnType("int");

                    b.Property<int>("PeriodType")
                        .HasColumnType("int");

                    b.Property<int?>("TaskNumber")
                        .HasColumnType("int");

                    b.Property<string>("Uid")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<int?>("UserId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("DocumentId");

                    b.HasIndex("ExamId");

                    b.HasIndex("UserId");

                    b.ToTable("ExamSolutions");
                });

            modelBuilder.Entity("PastExamsHub.Core.Domain.Entities.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FirstName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FullName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Gender")
                        .HasColumnType("int");

                    b.Property<int?>("Index")
                        .HasColumnType("int");

                    b.Property<string>("LastName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Role")
                        .HasColumnType("int");

                    b.Property<int?>("StudyYear")
                        .HasColumnType("int");

                    b.Property<string>("Uid")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("Id");

                    b.ToTable("Users");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Email = "administrator@localhostt",
                            FirstName = "Administrator",
                            Gender = 1,
                            LastName = "System",
                            Role = 1,
                            Uid = "admin"
                        },
                        new
                        {
                            Id = 2,
                            Email = "profesor@localhost",
                            FirstName = "Profesor",
                            Gender = 1,
                            LastName = "Elfakovic",
                            Role = 3,
                            Uid = "profesor"
                        });
                });

            modelBuilder.Entity("PastExamsHub.Core.Domain.Entities.Course", b =>
                {
                    b.HasOne("PastExamsHub.Core.Domain.Entities.User", "Lecturer")
                        .WithMany()
                        .HasForeignKey("LecturerId");

                    b.Navigation("Lecturer");
                });

            modelBuilder.Entity("PastExamsHub.Core.Domain.Entities.Exam", b =>
                {
                    b.HasOne("PastExamsHub.Core.Domain.Entities.Course", "Course")
                        .WithMany()
                        .HasForeignKey("CourseId");

                    b.HasOne("PastExamsHub.Core.Domain.Entities.Document", "Document")
                        .WithMany()
                        .HasForeignKey("DocumentId");

                    b.HasOne("PastExamsHub.Core.Domain.Entities.ExamPeriod", "Period")
                        .WithMany()
                        .HasForeignKey("PeriodId");

                    b.Navigation("Course");

                    b.Navigation("Document");

                    b.Navigation("Period");
                });

            modelBuilder.Entity("PastExamsHub.Core.Domain.Entities.ExamPeriodExam", b =>
                {
                    b.HasOne("PastExamsHub.Core.Domain.Entities.Exam", "Exam")
                        .WithMany()
                        .HasForeignKey("ExamId");

                    b.HasOne("PastExamsHub.Core.Domain.Entities.ExamPeriod", "ExamPeriod")
                        .WithMany("Exams")
                        .HasForeignKey("ExamPeriodId");

                    b.Navigation("Exam");

                    b.Navigation("ExamPeriod");
                });

            modelBuilder.Entity("PastExamsHub.Core.Domain.Entities.ExamSolution", b =>
                {
                    b.HasOne("PastExamsHub.Core.Domain.Entities.Document", "Document")
                        .WithMany()
                        .HasForeignKey("DocumentId");

                    b.HasOne("PastExamsHub.Core.Domain.Entities.Exam", "Exam")
                        .WithMany()
                        .HasForeignKey("ExamId");

                    b.HasOne("PastExamsHub.Core.Domain.Entities.User", "User")
                        .WithMany()
                        .HasForeignKey("UserId");

                    b.Navigation("Document");

                    b.Navigation("Exam");

                    b.Navigation("User");
                });

            modelBuilder.Entity("PastExamsHub.Core.Domain.Entities.ExamPeriod", b =>
                {
                    b.Navigation("Exams");
                });
#pragma warning restore 612, 618
        }
    }
}