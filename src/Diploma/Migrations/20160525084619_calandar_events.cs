using System;
using System.Collections.Generic;
using Microsoft.Data.Entity.Migrations;
using Microsoft.Data.Entity.Metadata;

namespace Diploma.Migrations
{
    public partial class calandar_events : Migration
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
            migrationBuilder.DropForeignKey(name: "FK_User_Student_StudentId", table: "AspNetUsers");
            migrationBuilder.DropForeignKey(name: "FK_User_Teacher_TeacherId", table: "AspNetUsers");
            migrationBuilder.DropForeignKey(name: "FK_IdentityRoleClaim<string>_IdentityRole_RoleId", table: "AspNetRoleClaims");
            migrationBuilder.DropForeignKey(name: "FK_IdentityUserClaim<string>_User_UserId", table: "AspNetUserClaims");
            migrationBuilder.DropForeignKey(name: "FK_IdentityUserLogin<string>_User_UserId", table: "AspNetUserLogins");
            migrationBuilder.DropForeignKey(name: "FK_IdentityUserRole<string>_IdentityRole_RoleId", table: "AspNetUserRoles");
            migrationBuilder.DropForeignKey(name: "FK_IdentityUserRole<string>_User_UserId", table: "AspNetUserRoles");
            migrationBuilder.DropColumn(name: "StudentId", table: "AspNetUsers");
            migrationBuilder.DropColumn(name: "TeacherId", table: "AspNetUsers");
            migrationBuilder.CreateTable(
                name: "CalendarEvent",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    UserName = table.Column<string>(nullable: true),
                    allDay = table.Column<bool>(nullable: false),
                    backgroundColor = table.Column<string>(nullable: true),
                    borderColor = table.Column<string>(nullable: true),
                    className = table.Column<string>(nullable: true),
                    color = table.Column<string>(nullable: true),
                    durationEditable = table.Column<bool>(nullable: false),
                    editable = table.Column<bool>(nullable: false),
                    end = table.Column<DateTime>(nullable: false),
                    rendering = table.Column<string>(nullable: true),
                    start = table.Column<DateTime>(nullable: false),
                    startEditable = table.Column<bool>(nullable: false),
                    textColor = table.Column<string>(nullable: true),
                    title = table.Column<string>(nullable: true),
                    url = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CalendarEvent", x => x.id);
                });
            migrationBuilder.AddColumn<string>(
                name: "UserId",
                table: "Teacher",
                nullable: true);
            migrationBuilder.AddColumn<string>(
                name: "UserId",
                table: "Student",
                nullable: true);
            migrationBuilder.AddColumn<int>(
                name: "day",
                table: "Schedule",
                nullable: false,
                defaultValue: DayOfWeek.Sunday);
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
                name: "FK_Student_User_UserId",
                table: "Student",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
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
                name: "FK_Teacher_User_UserId",
                table: "Teacher",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
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
            migrationBuilder.DropForeignKey(name: "FK_Student_User_UserId", table: "Student");
            migrationBuilder.DropForeignKey(name: "FK_SubjectGroups_Group_GroupId", table: "SubjectGroups");
            migrationBuilder.DropForeignKey(name: "FK_SubjectGroups_Subject_SubjectId", table: "SubjectGroups");
            migrationBuilder.DropForeignKey(name: "FK_SubjectTeacher_Subject_SubjectId", table: "SubjectTeacher");
            migrationBuilder.DropForeignKey(name: "FK_SubjectTeacher_Teacher_TeacherId", table: "SubjectTeacher");
            migrationBuilder.DropForeignKey(name: "FK_Table_Dashboard_DashboardId", table: "Table");
            migrationBuilder.DropForeignKey(name: "FK_Teacher_User_UserId", table: "Teacher");
            migrationBuilder.DropForeignKey(name: "FK_TeacherGroup_Group_GroupId", table: "TeacherGroup");
            migrationBuilder.DropForeignKey(name: "FK_TeacherGroup_Teacher_TeacherId", table: "TeacherGroup");
            migrationBuilder.DropForeignKey(name: "FK_IdentityRoleClaim<string>_IdentityRole_RoleId", table: "AspNetRoleClaims");
            migrationBuilder.DropForeignKey(name: "FK_IdentityUserClaim<string>_User_UserId", table: "AspNetUserClaims");
            migrationBuilder.DropForeignKey(name: "FK_IdentityUserLogin<string>_User_UserId", table: "AspNetUserLogins");
            migrationBuilder.DropForeignKey(name: "FK_IdentityUserRole<string>_IdentityRole_RoleId", table: "AspNetUserRoles");
            migrationBuilder.DropForeignKey(name: "FK_IdentityUserRole<string>_User_UserId", table: "AspNetUserRoles");
            migrationBuilder.DropColumn(name: "UserId", table: "Teacher");
            migrationBuilder.DropColumn(name: "UserId", table: "Student");
            migrationBuilder.DropColumn(name: "day", table: "Schedule");
            migrationBuilder.DropTable("CalendarEvent");
            migrationBuilder.AddColumn<int>(
                name: "StudentId",
                table: "AspNetUsers",
                nullable: true);
            migrationBuilder.AddColumn<int>(
                name: "TeacherId",
                table: "AspNetUsers",
                nullable: true);
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
                name: "FK_User_Student_StudentId",
                table: "AspNetUsers",
                column: "StudentId",
                principalTable: "Student",
                principalColumn: "StudentId",
                onDelete: ReferentialAction.Restrict);
            migrationBuilder.AddForeignKey(
                name: "FK_User_Teacher_TeacherId",
                table: "AspNetUsers",
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
