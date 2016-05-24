using System;
using System.Collections.Generic;
using Microsoft.Data.Entity.Migrations;

namespace Diploma.Migrations
{
    public partial class fg : Migration
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
            migrationBuilder.DropForeignKey(name: "FK_SubjectTeacher_Teacher_SubjectId", table: "SubjectTeacher");
            migrationBuilder.DropForeignKey(name: "FK_Table_Dashboard_DashboardId", table: "Table");
            migrationBuilder.DropForeignKey(name: "FK_TeacherGroup_Group_GroupId", table: "TeacherGroup");
            migrationBuilder.DropForeignKey(name: "FK_TeacherGroup_Teacher_TeacherId", table: "TeacherGroup");
            migrationBuilder.DropForeignKey(name: "FK_IdentityRoleClaim<string>_IdentityRole_RoleId", table: "AspNetRoleClaims");
            migrationBuilder.DropForeignKey(name: "FK_IdentityUserClaim<string>_User_UserId", table: "AspNetUserClaims");
            migrationBuilder.DropForeignKey(name: "FK_IdentityUserLogin<string>_User_UserId", table: "AspNetUserLogins");
            migrationBuilder.DropForeignKey(name: "FK_IdentityUserRole<string>_IdentityRole_RoleId", table: "AspNetUserRoles");
            migrationBuilder.DropForeignKey(name: "FK_IdentityUserRole<string>_User_UserId", table: "AspNetUserRoles");
            migrationBuilder.AddColumn<int>(
                name: "SubjectTeacherId",
                table: "SubjectTeacher",
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
                name: "FK_SubjectTeacher_Teacher_SubjectId",
                table: "SubjectTeacher",
                column: "SubjectId",
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
            migrationBuilder.DropForeignKey(name: "FK_SubjectTeacher_Teacher_SubjectId", table: "SubjectTeacher");
            migrationBuilder.DropForeignKey(name: "FK_Table_Dashboard_DashboardId", table: "Table");
            migrationBuilder.DropForeignKey(name: "FK_TeacherGroup_Group_GroupId", table: "TeacherGroup");
            migrationBuilder.DropForeignKey(name: "FK_TeacherGroup_Teacher_TeacherId", table: "TeacherGroup");
            migrationBuilder.DropForeignKey(name: "FK_IdentityRoleClaim<string>_IdentityRole_RoleId", table: "AspNetRoleClaims");
            migrationBuilder.DropForeignKey(name: "FK_IdentityUserClaim<string>_User_UserId", table: "AspNetUserClaims");
            migrationBuilder.DropForeignKey(name: "FK_IdentityUserLogin<string>_User_UserId", table: "AspNetUserLogins");
            migrationBuilder.DropForeignKey(name: "FK_IdentityUserRole<string>_IdentityRole_RoleId", table: "AspNetUserRoles");
            migrationBuilder.DropForeignKey(name: "FK_IdentityUserRole<string>_User_UserId", table: "AspNetUserRoles");
            migrationBuilder.DropColumn(name: "SubjectTeacherId", table: "SubjectTeacher");
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
                name: "FK_SubjectTeacher_Teacher_SubjectId",
                table: "SubjectTeacher",
                column: "SubjectId",
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
