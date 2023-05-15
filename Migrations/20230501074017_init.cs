using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Capstonep2.Migrations
{
    public partial class init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterDatabase()
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Patients",
                columns: table => new
                {
                    ID = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    FirstName = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    LastName = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    MiddleName = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Address = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    BirthDate = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    Gender = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Patients", x => x.ID);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Roles",
                columns: table => new
                {
                    ID = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    Name = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Description = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Abbreviation = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Roles", x => x.ID);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "UserLogins",
                columns: table => new
                {
                    ID = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    UserID = table.Column<Guid>(type: "char(36)", nullable: true, collation: "ascii_general_ci"),
                    Type = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Key = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Value = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserLogins", x => x.ID);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Appointments",
                columns: table => new
                {
                    ID = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    StartTime = table.Column<DateTime>(type: "datetime(6)", nullable: true),
                    EndTime = table.Column<DateTime>(type: "datetime(6)", nullable: true),
                    Symptom = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    PurposeOfVisit = table.Column<int>(type: "int", nullable: false),
                    PatientID = table.Column<Guid>(type: "char(36)", nullable: true, collation: "ascii_general_ci"),
                    Status = table.Column<int>(type: "int", nullable: false),
                    Visit = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Appointments", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Appointments_Patients_PatientID",
                        column: x => x.PatientID,
                        principalTable: "Patients",
                        principalColumn: "ID");
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    ID = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    PatientID = table.Column<Guid>(type: "char(36)", nullable: true, collation: "ascii_general_ci"),
                    Email = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    FirstName = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    LastName = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    MiddleName = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Address = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Gender = table.Column<int>(type: "int", nullable: false),
                    BirthDate = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    RoleID = table.Column<Guid>(type: "char(36)", nullable: true, collation: "ascii_general_ci")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Users_Patients_PatientID",
                        column: x => x.PatientID,
                        principalTable: "Patients",
                        principalColumn: "ID");
                    table.ForeignKey(
                        name: "FK_Users_Roles_RoleID",
                        column: x => x.RoleID,
                        principalTable: "Roles",
                        principalColumn: "ID");
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "ConsultationRecords",
                columns: table => new
                {
                    ID = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    PatientID = table.Column<Guid>(type: "char(36)", nullable: true, collation: "ascii_general_ci"),
                    AppointmentID = table.Column<Guid>(type: "char(36)", nullable: true, collation: "ascii_general_ci")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ConsultationRecords", x => x.ID);
                    table.ForeignKey(
                        name: "FK_ConsultationRecords_Appointments_AppointmentID",
                        column: x => x.AppointmentID,
                        principalTable: "Appointments",
                        principalColumn: "ID");
                    table.ForeignKey(
                        name: "FK_ConsultationRecords_Patients_PatientID",
                        column: x => x.PatientID,
                        principalTable: "Patients",
                        principalColumn: "ID");
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "UserRoles",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    UserID = table.Column<Guid>(type: "char(36)", nullable: true, collation: "ascii_general_ci"),
                    RoleID = table.Column<Guid>(type: "char(36)", nullable: true, collation: "ascii_general_ci")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserRoles", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UserRoles_Roles_RoleID",
                        column: x => x.RoleID,
                        principalTable: "Roles",
                        principalColumn: "ID");
                    table.ForeignKey(
                        name: "FK_UserRoles_Users_UserID",
                        column: x => x.UserID,
                        principalTable: "Users",
                        principalColumn: "ID");
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Findings",
                columns: table => new
                {
                    ID = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    Tags = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Description = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    ConsultationRecordID = table.Column<Guid>(type: "char(36)", nullable: true, collation: "ascii_general_ci")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Findings", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Findings_ConsultationRecords_ConsultationRecordID",
                        column: x => x.ConsultationRecordID,
                        principalTable: "ConsultationRecords",
                        principalColumn: "ID");
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Prescriptions",
                columns: table => new
                {
                    ID = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    Tags = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Description = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    ConsultationRecordID = table.Column<Guid>(type: "char(36)", nullable: true, collation: "ascii_general_ci")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Prescriptions", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Prescriptions_ConsultationRecords_ConsultationRecordID",
                        column: x => x.ConsultationRecordID,
                        principalTable: "ConsultationRecords",
                        principalColumn: "ID");
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.InsertData(
                table: "Patients",
                columns: new[] { "ID", "Address", "BirthDate", "FirstName", "Gender", "LastName", "MiddleName" },
                values: new object[,]
                {
                    { new Guid("2b792220-f333-49ec-abe2-3a6fc4edb0c2"), "Luakan,Dinalupihan, Bataan", new DateTime(2023, 3, 23, 0, 0, 0, 0, DateTimeKind.Unspecified), "Luisa Katrina", 0, "Reyes", "Pangilinan" },
                    { new Guid("5a7e7bc3-8816-41df-b44d-eeb60ae99b5b"), "Luakan,Dinalupihan, Bataan", new DateTime(2023, 3, 23, 0, 0, 0, 0, DateTimeKind.Unspecified), "Clarissa Joy", 0, "Flores", "Gozon" },
                    { new Guid("8664a4bd-0ec6-4aaa-83e6-7d2bd0315b5a"), "Bacong,Hermosa, Bataan", new DateTime(2023, 3, 23, 0, 0, 0, 0, DateTimeKind.Unspecified), "Raniel", 1, "David", "Mallari" }
                });

            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "ID", "Abbreviation", "Description", "Name" },
                values: new object[,]
                {
                    { new Guid("2afa881f-e519-4e67-a841-e4a2630e8a2a"), "Pt", "One who receives medical treatment", "patient" },
                    { new Guid("54f00f70-72b8-4d34-a953-83321ff6b101"), "Adm", "One who manages the system", "admin" }
                });

            migrationBuilder.InsertData(
                table: "UserLogins",
                columns: new[] { "ID", "Key", "Type", "UserID", "Value" },
                values: new object[,]
                {
                    { new Guid("03123593-cde9-46c5-aaed-7d0c023bf79c"), "Password", "General", new Guid("1bd5f519-b891-4491-9a7c-a86cd0c2a15e"), "$2a$11$3UnE5Ie.TTNBWixo6RES4eLA0zTaH9Rq0YtqWKRP30NgBzUC1Cnqu" },
                    { new Guid("0c26e67d-7938-4533-9c40-c35d95775362"), "Password", "General", new Guid("7e5e4f74-9902-43da-9974-4b2a08814398"), "$2a$11$3u3q4tpUJC.LT/.dZr5Qk.TVOo5GA/pWf4J.3kPUWJp5D2zRZPT7G" },
                    { new Guid("0e3aaef2-2bc7-49c2-81e4-d8d56a8a57d2"), "IsActive", "General", new Guid("d7dbd16f-1c71-4415-a147-22a2b428bf95"), "true" },
                    { new Guid("68167506-790a-43a0-9993-1cb779028ae0"), "LoginRetries", "General", new Guid("00acfb7f-6c90-459a-b53f-bf73ddac85b4"), "0" },
                    { new Guid("75a45cf2-d97f-4a11-8d69-a180b99af367"), "LoginRetries", "General", new Guid("0352c124-f290-4f99-b1a5-e235cafcd836"), "0" },
                    { new Guid("77bdc284-db91-45d4-9595-f6902a95f8cb"), "IsActive", "General", new Guid("7e5e4f74-9902-43da-9974-4b2a08814398"), "true" },
                    { new Guid("7e3543dd-eff8-4851-97e8-b6c3253a0fac"), "IsActive", "General", new Guid("1bd5f519-b891-4491-9a7c-a86cd0c2a15e"), "true" },
                    { new Guid("8e1df331-4b1b-4752-bbb6-8f446b2dfaa8"), "IsActive", "General", new Guid("0352c124-f290-4f99-b1a5-e235cafcd836"), "true" },
                    { new Guid("a1310fb9-b0d2-4fc2-84a7-9a1bd5b2c2ae"), "LoginRetries", "General", new Guid("1bd5f519-b891-4491-9a7c-a86cd0c2a15e"), "0" },
                    { new Guid("c5e35c93-eeab-4c33-9ef7-ad0c89e4fd1e"), "Password", "General", new Guid("00acfb7f-6c90-459a-b53f-bf73ddac85b4"), "$2a$11$l7VPwqV/OgUK8HWgH4Q1oeMvjP8wyS7PAyIdHgtMzQzoeH80ybl7q" },
                    { new Guid("d71090f0-28e3-46c1-a179-202c4baf070a"), "LoginRetries", "General", new Guid("d7dbd16f-1c71-4415-a147-22a2b428bf95"), "0" },
                    { new Guid("ddcf2362-8808-4f90-b349-5618de6b03ff"), "Password", "General", new Guid("d7dbd16f-1c71-4415-a147-22a2b428bf95"), "$2a$11$ub6uNALb3MHX3aky.2wlVucrpXfN/1rQh7MpdUxYkiNjoxeqRCyxy" },
                    { new Guid("e513dc2b-28f8-4425-8226-fa7f85872caf"), "LoginRetries", "General", new Guid("7e5e4f74-9902-43da-9974-4b2a08814398"), "0" },
                    { new Guid("e93806dd-5192-4684-b0a8-c7f4582217ed"), "Password", "General", new Guid("0352c124-f290-4f99-b1a5-e235cafcd836"), "$2a$11$T./I.uBT9yV4fKZ4/uNLtOas2Ljzo6n3ULZk7P4hWwiMIKbFVpjyi" },
                    { new Guid("efa83d3f-5ae9-4d04-9b16-23c766351679"), "IsActive", "General", new Guid("00acfb7f-6c90-459a-b53f-bf73ddac85b4"), "true" }
                });

            migrationBuilder.InsertData(
                table: "Appointments",
                columns: new[] { "ID", "EndTime", "PatientID", "PurposeOfVisit", "StartTime", "Status", "Symptom", "Visit" },
                values: new object[,]
                {
                    { new Guid("20f20659-d4e3-466e-b2df-e6a6b1f62fab"), new DateTime(2022, 2, 2, 12, 0, 0, 0, DateTimeKind.Unspecified), new Guid("8664a4bd-0ec6-4aaa-83e6-7d2bd0315b5a"), 0, new DateTime(2022, 2, 12, 11, 30, 0, 0, DateTimeKind.Unspecified), 4, "Red Eyes", 0 },
                    { new Guid("2222ed0f-aaea-45f3-8a72-f0ee3ed23a22"), new DateTime(2022, 2, 2, 12, 0, 0, 0, DateTimeKind.Unspecified), new Guid("8664a4bd-0ec6-4aaa-83e6-7d2bd0315b5a"), 0, new DateTime(2022, 2, 12, 11, 30, 0, 0, DateTimeKind.Unspecified), 3, "Swelling", 0 },
                    { new Guid("3ce371f9-dc79-4623-b84f-0b2fe7c99962"), new DateTime(2023, 2, 2, 12, 0, 0, 0, DateTimeKind.Unspecified), new Guid("5a7e7bc3-8816-41df-b44d-eeb60ae99b5b"), 1, new DateTime(2023, 2, 12, 11, 30, 0, 0, DateTimeKind.Unspecified), 4, "Light Sensitivity", 1 },
                    { new Guid("7297d64f-7912-4e46-a663-e543af0102fb"), new DateTime(22, 2, 23, 12, 0, 0, 0, DateTimeKind.Unspecified), new Guid("5a7e7bc3-8816-41df-b44d-eeb60ae99b5b"), 1, new DateTime(2023, 2, 12, 11, 30, 0, 0, DateTimeKind.Unspecified), 1, "Light Sensitivity", 1 },
                    { new Guid("861c579e-bb80-4dea-b8f2-4b189cb6a362"), new DateTime(2022, 2, 2, 12, 0, 0, 0, DateTimeKind.Unspecified), new Guid("8664a4bd-0ec6-4aaa-83e6-7d2bd0315b5a"), 0, new DateTime(2022, 2, 12, 11, 30, 0, 0, DateTimeKind.Unspecified), 1, "Headache", 1 },
                    { new Guid("a0d287bc-73e8-41b6-88f1-e7385ea7da7d"), new DateTime(2023, 2, 2, 12, 0, 0, 0, DateTimeKind.Unspecified), new Guid("5a7e7bc3-8816-41df-b44d-eeb60ae99b5b"), 1, new DateTime(2023, 2, 12, 11, 30, 0, 0, DateTimeKind.Unspecified), 0, "Light Sensitivity", 1 },
                    { new Guid("c7d431a6-579b-4841-8629-2bbcb79a5e15"), new DateTime(2023, 2, 12, 12, 0, 0, 0, DateTimeKind.Unspecified), new Guid("8664a4bd-0ec6-4aaa-83e6-7d2bd0315b5a"), 2, new DateTime(2023, 2, 12, 11, 30, 0, 0, DateTimeKind.Unspecified), 0, "Light Sensitivity", 0 },
                    { new Guid("e822435f-5110-465f-a276-c89ee9a5dc54"), new DateTime(2023, 2, 2, 12, 0, 0, 0, DateTimeKind.Unspecified), new Guid("5a7e7bc3-8816-41df-b44d-eeb60ae99b5b"), 1, new DateTime(2023, 2, 12, 11, 30, 0, 0, DateTimeKind.Unspecified), 3, "Light Sensitivity", 1 }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "ID", "Address", "BirthDate", "Email", "FirstName", "Gender", "LastName", "MiddleName", "PatientID", "RoleID" },
                values: new object[,]
                {
                    { new Guid("00acfb7f-6c90-459a-b53f-bf73ddac85b4"), "Dinalupihan, Orani , Bataan", new DateTime(2002, 2, 21, 0, 0, 0, 0, DateTimeKind.Unspecified), "Janedavid@yahoo.com", "Jane", 0, "David", "Adan", null, new Guid("54f00f70-72b8-4d34-a953-83321ff6b101") },
                    { new Guid("0352c124-f290-4f99-b1a5-e235cafcd836"), "Dinalupihan, Orani, Bataan", new DateTime(2001, 1, 23, 0, 0, 0, 0, DateTimeKind.Unspecified), "luisa@yahoo.com", "Luisa Katrina", 0, "Pangilinan", "Reyes", new Guid("2b792220-f333-49ec-abe2-3a6fc4edb0c2"), new Guid("2afa881f-e519-4e67-a841-e4a2630e8a2a") },
                    { new Guid("1bd5f519-b891-4491-9a7c-a86cd0c2a15e"), "Dinalupihan, Orani , Bataan", new DateTime(2002, 2, 21, 0, 0, 0, 0, DateTimeKind.Unspecified), "admin@yahoo.com", "admin", 0, "admin", "admin", null, new Guid("54f00f70-72b8-4d34-a953-83321ff6b101") },
                    { new Guid("7e5e4f74-9902-43da-9974-4b2a08814398"), "Dinalupihan, Orani, Bataan", new DateTime(2001, 1, 23, 0, 0, 0, 0, DateTimeKind.Unspecified), "renieldavid@yahoo.com", "Reniel", 1, "Mallari", "David", new Guid("8664a4bd-0ec6-4aaa-83e6-7d2bd0315b5a"), new Guid("2afa881f-e519-4e67-a841-e4a2630e8a2a") },
                    { new Guid("d7dbd16f-1c71-4415-a147-22a2b428bf95"), "Dinalupihan, Orani, Bataan", new DateTime(2001, 1, 23, 0, 0, 0, 0, DateTimeKind.Unspecified), "joy@yahoo.com", "Clarissa Joy", 1, "Gozon", "Flores", new Guid("5a7e7bc3-8816-41df-b44d-eeb60ae99b5b"), new Guid("2afa881f-e519-4e67-a841-e4a2630e8a2a") }
                });

            migrationBuilder.InsertData(
                table: "ConsultationRecords",
                columns: new[] { "ID", "AppointmentID", "PatientID" },
                values: new object[,]
                {
                    { new Guid("0c096359-c9ef-4f37-9c37-47b7bf247746"), new Guid("c7d431a6-579b-4841-8629-2bbcb79a5e15"), new Guid("8664a4bd-0ec6-4aaa-83e6-7d2bd0315b5a") },
                    { new Guid("73ec06ac-56aa-453a-a29d-447691d51cd9"), new Guid("20f20659-d4e3-466e-b2df-e6a6b1f62fab"), new Guid("8664a4bd-0ec6-4aaa-83e6-7d2bd0315b5a") },
                    { new Guid("a11b823f-8eff-4d89-abdc-8efa8f28291c"), new Guid("3ce371f9-dc79-4623-b84f-0b2fe7c99962"), new Guid("5a7e7bc3-8816-41df-b44d-eeb60ae99b5b") }
                });

            migrationBuilder.InsertData(
                table: "UserRoles",
                columns: new[] { "Id", "RoleID", "UserID" },
                values: new object[,]
                {
                    { new Guid("1c5c0392-7254-446b-a4e4-0ec6e9d3b71b"), new Guid("2afa881f-e519-4e67-a841-e4a2630e8a2a"), new Guid("7e5e4f74-9902-43da-9974-4b2a08814398") },
                    { new Guid("63fd5922-5c1c-4f47-8c75-4c0e27ab19ab"), new Guid("54f00f70-72b8-4d34-a953-83321ff6b101"), new Guid("00acfb7f-6c90-459a-b53f-bf73ddac85b4") },
                    { new Guid("98882b17-dd36-48b2-b815-e50bdb09f177"), new Guid("2afa881f-e519-4e67-a841-e4a2630e8a2a"), new Guid("d7dbd16f-1c71-4415-a147-22a2b428bf95") },
                    { new Guid("bea622e1-517d-416a-9a4a-8b5973583d1c"), new Guid("2afa881f-e519-4e67-a841-e4a2630e8a2a"), new Guid("0352c124-f290-4f99-b1a5-e235cafcd836") },
                    { new Guid("f1b3dc55-c16e-4b37-b79f-f0be614323f6"), new Guid("54f00f70-72b8-4d34-a953-83321ff6b101"), new Guid("1bd5f519-b891-4491-9a7c-a86cd0c2a15e") }
                });

            migrationBuilder.InsertData(
                table: "Findings",
                columns: new[] { "ID", "ConsultationRecordID", "Description", "Tags" },
                values: new object[,]
                {
                    { new Guid("3a1caafa-dfbe-42e0-9904-4d425445db65"), new Guid("a11b823f-8eff-4d89-abdc-8efa8f28291c"), "test2", "test2" },
                    { new Guid("84777f90-b045-4ee9-8cfb-05276efa72fa"), new Guid("73ec06ac-56aa-453a-a29d-447691d51cd9"), "findings test 1", "testtable123" },
                    { new Guid("da30a891-9417-4241-8292-7e8b89daa204"), new Guid("0c096359-c9ef-4f37-9c37-47b7bf247746"), "sore eyes", "123" }
                });

            migrationBuilder.InsertData(
                table: "Prescriptions",
                columns: new[] { "ID", "ConsultationRecordID", "Description", "Tags" },
                values: new object[,]
                {
                    { new Guid("25af8556-2b25-45a8-87ed-3ab90b05203b"), new Guid("0c096359-c9ef-4f37-9c37-47b7bf247746"), "biogesic", "123" },
                    { new Guid("7c960f61-6dbb-47fa-a235-4a8d6ba0f94a"), new Guid("a11b823f-8eff-4d89-abdc-8efa8f28291c"), " test 2", "test2" },
                    { new Guid("8c6acbcd-7955-46a3-8548-16056d7a5d38"), new Guid("73ec06ac-56aa-453a-a29d-447691d51cd9"), "prescriptions test 2", "tabletest123" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Appointments_PatientID",
                table: "Appointments",
                column: "PatientID");

            migrationBuilder.CreateIndex(
                name: "IX_ConsultationRecords_AppointmentID",
                table: "ConsultationRecords",
                column: "AppointmentID");

            migrationBuilder.CreateIndex(
                name: "IX_ConsultationRecords_PatientID",
                table: "ConsultationRecords",
                column: "PatientID");

            migrationBuilder.CreateIndex(
                name: "IX_Findings_ConsultationRecordID",
                table: "Findings",
                column: "ConsultationRecordID");

            migrationBuilder.CreateIndex(
                name: "IX_Prescriptions_ConsultationRecordID",
                table: "Prescriptions",
                column: "ConsultationRecordID");

            migrationBuilder.CreateIndex(
                name: "IX_UserRoles_RoleID",
                table: "UserRoles",
                column: "RoleID");

            migrationBuilder.CreateIndex(
                name: "IX_UserRoles_UserID",
                table: "UserRoles",
                column: "UserID");

            migrationBuilder.CreateIndex(
                name: "IX_Users_PatientID",
                table: "Users",
                column: "PatientID");

            migrationBuilder.CreateIndex(
                name: "IX_Users_RoleID",
                table: "Users",
                column: "RoleID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Findings");

            migrationBuilder.DropTable(
                name: "Prescriptions");

            migrationBuilder.DropTable(
                name: "UserLogins");

            migrationBuilder.DropTable(
                name: "UserRoles");

            migrationBuilder.DropTable(
                name: "ConsultationRecords");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "Appointments");

            migrationBuilder.DropTable(
                name: "Roles");

            migrationBuilder.DropTable(
                name: "Patients");
        }
    }
}
