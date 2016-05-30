using System;
using System.Collections.Generic;
using Microsoft.Data.Entity.Migrations;
using Microsoft.Data.Entity.Metadata;

namespace Diploma.Migrations
{
    public partial class newOne : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(name: "FK_Issue_Table_TableId", table: "Issue");
            migrationBuilder.DropForeignKey(name: "FK_Schedule_Group_GroupId", table: "Schedule");
            migrationBuilder.DropForeignKey(name: "FK_Schedule_Subject_SubjectId", table: "Schedule");
            migrationBuilder.DropForeignKey(name: "FK_Schedule_Teacher_TeacherId", table: "Schedule");
            migrationBuilder.DropForeignKey(name: "FK_Schedule_TimeTable_TimeTableId", table: "Schedule");
            migrationBuilder.DropForeignKey(name: "FK_SubjectGroups_Group_GroupId", table: "SubjectGroups");
            migrationBuilder.DropForeignKey(name: "FK_SubjectGroups_Subject_SubjectId", table: "SubjectGroups");
            migrationBuilder.DropForeignKey(name: "FK_SubjectTeacher_Subject_SubjectId", table: "SubjectTeacher");
            migrationBuilder.DropForeignKey(name: "FK_SubjectTeacher_Teacher_TeacherId", table: "SubjectTeacher");
            migrationBuilder.DropForeignKey(name: "FK_Table_Dashboard_DashboardId", table: "Table");
            migrationBuilder.DropForeignKey(name: "FK_TeacherGroup_Group_GroupId", table: "TeacherGroup");
            migrationBuilder.DropForeignKey(name: "FK_TeacherGroup_Teacher_TeacherId", table: "TeacherGroup");
            migrationBuilder.DropForeignKey(name: "FK_IdentityRoleClaim<string>_IdentityRole_RoleId", table: "AspNetRoleClaims");
            migrationBuilder.DropForeignKey(name: "FK_IdentityUserClaim<string>_User_UserId", table: "AspNetUserClaims");
            migrationBuilder.DropForeignKey(name: "FK_IdentityUserLogin<string>_User_UserId", table: "AspNetUserLogins");
            migrationBuilder.DropForeignKey(name: "FK_IdentityUserRole<string>_IdentityRole_RoleId", table: "AspNetUserRoles");
            migrationBuilder.DropForeignKey(name: "FK_IdentityUserRole<string>_User_UserId", table: "AspNetUserRoles");
            migrationBuilder.CreateTable(
                name: "LectureNotes",
                columns: table => new
                {
                    LectureNotesId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Attachment = table.Column<string>(nullable: true),
                    Course = table.Column<int>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    PubDate = table.Column<DateTime>(nullable: false),
                    SubjectId = table.Column<int>(nullable: false),
                    TeacherId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LectureNotes", x => x.LectureNotesId);
                    table.ForeignKey(
                        name: "FK_LectureNotes_Subject_SubjectId",
                        column: x => x.SubjectId,
                        principalTable: "Subject",
                        principalColumn: "SubjectId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_LectureNotes_Teacher_TeacherId",
                        column: x => x.TeacherId,
                        principalTable: "Teacher",
                        principalColumn: "TeacherId",
                        onDelete: ReferentialAction.Cascade);
                });
            migrationBuilder.AddColumn<int>(
                name: "Course",
                table: "Student",
                nullable: false,
                defaultValue: 0);
            migrationBuilder.AddForeignKey(
                name: "FK_Issue_Table_TableId",
                table: "Issue",
                column: "TableId",
                principalTable: "Table",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
            migrationBuilder.AddForeignKey(
                name: "FK_Schedule_Group_GroupId",
                table: "Schedule",
                column: "GroupId",
                principalTable: "Group",
                principalColumn: "GroupId",
                onDelete: ReferentialAction.Cascade);
            migrationBuilder.AddForeignKey(
                name: "FK_Schedule_Subject_SubjectId",
                table: "Schedule",
                column: "SubjectId",
                principalTable: "Subject",
                principalColumn: "SubjectId",
                onDelete: ReferentialAction.Cascade);
            migrationBuilder.AddForeignKey(
                name: "FK_Schedule_Teacher_TeacherId",
                table: "Schedule",
                column: "TeacherId",
                principalTable: "Teacher",
                principalColumn: "TeacherId",
                onDelete: ReferentialAction.Cascade);
            migrationBuilder.AddForeignKey(
                name: "FK_Schedule_TimeTable_TimeTableId",
                table: "Schedule",
                column: "TimeTableId",
                principalTable: "TimeTable",
                principalColumn: "TimeTableId",
                onDelete: ReferentialAction.Cascade);
            migrationBuilder.AddForeignKey(
                name: "FK_SubjectGroups_Group_GroupId",
                table: "SubjectGroups",
                column: "GroupId",
                principalTable: "Group",
                principalColumn: "GroupId",
                onDelete: ReferentialAction.Cascade);
            migrationBuilder.AddForeignKey(
                name: "FK_SubjectGroups_Subject_SubjectId",
                table: "SubjectGroups",
                column: "SubjectId",
                principalTable: "Subject",
                principalColumn: "SubjectId",
                onDelete: ReferentialAction.Cascade);
            migrationBuilder.AddForeignKey(
                name: "FK_SubjectTeacher_Subject_SubjectId",
                table: "SubjectTeacher",
                column: "SubjectId",
                principalTable: "Subject",
                principalColumn: "SubjectId",
                onDelete: ReferentialAction.Cascade);
            migrationBuilder.AddForeignKey(
                name: "FK_SubjectTeacher_Teacher_TeacherId",
                table: "SubjectTeacher",
                column: "TeacherId",
                principalTable: "Teacher",
                principalColumn: "TeacherId",
                onDelete: ReferentialAction.Cascade);
            migrationBuilder.AddForeignKey(
                name: "FK_Table_Dashboard_DashboardId",
                table: "Table",
                column: "DashboardId",
                principalTable: "Dashboard",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
            migrationBuilder.AddForeignKey(
                name: "FK_TeacherGroup_Group_GroupId",
                table: "TeacherGroup",
                column: "GroupId",
                principalTable: "Group",
                principalColumn: "GroupId",
                onDelete: ReferentialAction.Cascade);
            migrationBuilder.AddForeignKey(
                name: "FK_TeacherGroup_Teacher_TeacherId",
                table: "TeacherGroup",
                column: "TeacherId",
                principalTable: "Teacher",
                principalColumn: "TeacherId",
                onDelete: ReferentialAction.Cascade);
            migrationBuilder.AddForeignKey(
                name: "FK_IdentityRoleClaim<string>_IdentityRole_RoleId",
                table: "AspNetRoleClaims",
                column: "RoleId",
                principalTable: "AspNetRoles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
            migrationBuilder.AddForeignKey(
                name: "FK_IdentityUserClaim<string>_User_UserId",
                table: "AspNetUserClaims",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
            migrationBuilder.AddForeignKey(
                name: "FK_IdentityUserLogin<string>_User_UserId",
                table: "AspNetUserLogins",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
            migrationBuilder.AddForeignKey(
                name: "FK_IdentityUserRole<string>_IdentityRole_RoleId",
                table: "AspNetUserRoles",
                column: "RoleId",
                principalTable: "AspNetRoles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
            migrationBuilder.AddForeignKey(
                name: "FK_IdentityUserRole<string>_User_UserId",
                table: "AspNetUserRoles",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(name: "FK_Issue_Table_TableId", table: "Issue");
            migrationBuilder.DropForeignKey(name: "FK_Schedule_Group_GroupId", table: "Schedule");
            migrationBuilder.DropForeignKey(name: "FK_Schedule_Subject_SubjectId", table: "Schedule");
            migrationBuilder.DropForeignKey(name: "FK_Schedule_Teacher_TeacherId", table: "Schedule");
            migrationBuilder.DropForeignKey(name: "FK_Schedule_TimeTable_TimeTableId", table: "Schedule");
            migrationBuilder.DropForeignKey(name: "FK_SubjectGroups_Group_GroupId", table: "SubjectGroups");
            migrationBuilder.DropForeignKey(name: "FK_SubjectGroups_Subject_SubjectId", table: "SubjectGroups");
            migrationBuilder.DropForeignKey(name: "FK_SubjectTeacher_Subject_SubjectId", table: "SubjectTeacher");
            migrationBuilder.DropForeignKey(name: "FK_SubjectTeacher_Teacher_TeacherId", table: "SubjectTeacher");
            migrationBuilder.DropForeignKey(name: "FK_Table_Dashboard_DashboardId", table: "Table");
            migrationBuilder.DropForeignKey(name: "FK_TeacherGroup_Group_GroupId", table: "TeacherGroup");
            migrationBuilder.DropForeignKey(name: "FK_TeacherGroup_Teacher_TeacherId", table: "TeacherGroup");
            migrationBuilder.DropForeignKey(name: "FK_IdentityRoleClaim<string>_IdentityRole_RoleId", table: "AspNetRoleClaims");
            migrationBuilder.DropForeignKey(name: "FK_IdentityUserClaim<string>_User_UserId", table: "AspNetUserClaims");
            migrationBuilder.DropForeignKey(name: "FK_IdentityUserLogin<string>_User_UserId", table: "AspNetUserLogins");
            migrationBuilder.DropForeignKey(name: "FK_IdentityUserRole<string>_IdentityRole_RoleId", table: "AspNetUserRoles");
            migrationBuilder.DropForeignKey(name: "FK_IdentityUserRole<string>_User_UserId", table: "AspNetUserRoles");
            migrationBuilder.DropColumn(name: "Course", table: "Student");
            migrationBuilder.DropTable("LectureNotes");
            migrationBuilder.AddForeignKey(
                name: "FK_Issue_Table_TableId",
                table: "Issue",
                column: "TableId",
                principalTable: "Table",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
            migrationBuilder.AddForeignKey(
                name: "FK_Schedule_Group_GroupId",
                table: "Schedule",
                column: "GroupId",
                principalTable: "Group",
                principalColumn: "GroupId",
                onDelete: ReferentialAction.Restrict);
            migrationBuilder.AddForeignKey(
                name: "FK_Schedule_Subject_SubjectId",
                table: "Schedule",
                column: "SubjectId",
                principalTable: "Subject",
                principalColumn: "SubjectId",
                onDelete: ReferentialAction.Restrict);
            migrationBuilder.AddForeignKey(
                name: "FK_Schedule_Teacher_TeacherId",
                table: "Schedule",
                column: "TeacherId",
                principalTable: "Teacher",
                principalColumn: "TeacherId",
                onDelete: ReferentialAction.Restrict);
            migrationBuilder.AddForeignKey(
                name: "FK_Schedule_TimeTable_TimeTableId",
                table: "Schedule",
                column: "TimeTableId",
                principalTable: "TimeTable",
                principalColumn: "TimeTableId",
                onDelete: ReferentialAction.Restrict);
            migrationBuilder.AddForeignKey(
                name: "FK_SubjectGroups_Group_GroupId",
                table: "SubjectGroups",
                column: "GroupId",
                principalTable: "Group",
                principalColumn: "GroupId",
                onDelete: ReferentialAction.Restrict);
            migrationBuilder.AddForeignKey(
                name: "FK_SubjectGroups_Subject_SubjectId",
                table: "SubjectGroups",
                column: "SubjectId",
                principalTable: "Subject",
                principalColumn: "SubjectId",
                onDelete: ReferentialAction.Restrict);
            migrationBuilder.AddForeignKey(
                name: "FK_SubjectTeacher_Subject_SubjectId",
                table: "SubjectTeacher",
                column: "SubjectId",
                principalTable: "Subject",
                principalColumn: "SubjectId",
                onDelete: ReferentialAction.Restrict);
            migrationBuilder.AddForeignKey(
                name: "FK_SubjectTeacher_Teacher_TeacherId",
                table: "SubjectTeacher",
                column: "TeacherId",
                principalTable: "Teacher",
                principalColumn: "TeacherId",
                onDelete: ReferentialAction.Restrict);
            migrationBuilder.AddForeignKey(
                name: "FK_Table_Dashboard_DashboardId",
                table: "Table",
                column: "DashboardId",
                principalTable: "Dashboard",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
            migrationBuilder.AddForeignKey(
                name: "FK_TeacherGroup_Group_GroupId",
                table: "TeacherGroup",
                column: "GroupId",
                principalTable: "Group",
                principalColumn: "GroupId",
                onDelete: ReferentialAction.Restrict);
            migrationBuilder.AddForeignKey(
                name: "FK_TeacherGroup_Teacher_TeacherId",
                table: "TeacherGroup",
                column: "TeacherId",
                principalTable: "Teacher",
                principalColumn: "TeacherId",
                onDelete: ReferentialAction.Restrict);
            migrationBuilder.AddForeignKey(
                name: "FK_IdentityRoleClaim<string>_IdentityRole_RoleId",
                table: "AspNetRoleClaims",
                column: "RoleId",
                principalTable: "AspNetRoles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
            migrationBuilder.AddForeignKey(
                name: "FK_IdentityUserClaim<string>_User_UserId",
                table: "AspNetUserClaims",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
            migrationBuilder.AddForeignKey(
                name: "FK_IdentityUserLogin<string>_User_UserId",
                table: "AspNetUserLogins",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
            migrationBuilder.AddForeignKey(
                name: "FK_IdentityUserRole<string>_IdentityRole_RoleId",
                table: "AspNetUserRoles",
                column: "RoleId",
                principalTable: "AspNetRoles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
            migrationBuilder.AddForeignKey(
                name: "FK_IdentityUserRole<string>_User_UserId",
                table: "AspNetUserRoles",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
