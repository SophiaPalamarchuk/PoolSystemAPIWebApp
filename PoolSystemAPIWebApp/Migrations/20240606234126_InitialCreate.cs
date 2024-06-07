using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PoolSystemAPIWebApp.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Schedules",
                columns: table => new
                {
                    schedule_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    day_of_week = table.Column<string>(type: "varchar(20)", unicode: false, maxLength: 20, nullable: false),
                    start_time = table.Column<TimeOnly>(type: "time", nullable: false),
                    end_time = table.Column<TimeOnly>(type: "time", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Schedule__C46A8A6FDC997DC1", x => x.schedule_id);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    user_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    username = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: false),
                    email = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: false),
                    password = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Users__B9BE370F748B09A1", x => x.user_id);
                });

            migrationBuilder.CreateTable(
                name: "Classes",
                columns: table => new
                {
                    class_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    class_name = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: false),
                    description = table.Column<string>(type: "text", nullable: true),
                    schedule_id = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Classes__FDF47986C5BAE7B7", x => x.class_id);
                    table.ForeignKey(
                        name: "FK__Classes__schedul__4222D4EF",
                        column: x => x.schedule_id,
                        principalTable: "Schedules",
                        principalColumn: "schedule_id");
                });

            migrationBuilder.CreateTable(
                name: "Abonnements",
                columns: table => new
                {
                    abonnement_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    user_id = table.Column<int>(type: "int", nullable: true),
                    type = table.Column<string>(type: "varchar(20)", unicode: false, maxLength: 20, nullable: false),
                    start_date = table.Column<DateOnly>(type: "date", nullable: false),
                    end_date = table.Column<DateOnly>(type: "date", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Abonneme__920B30F8E374D5EE", x => x.abonnement_id);
                    table.ForeignKey(
                        name: "FK__Abonnemen__user___3C69FB99",
                        column: x => x.user_id,
                        principalTable: "Users",
                        principalColumn: "user_id");
                });

            migrationBuilder.CreateTable(
                name: "Administrators",
                columns: table => new
                {
                    admin_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    user_id = table.Column<int>(type: "int", nullable: true),
                    role = table.Column<string>(type: "varchar(20)", unicode: false, maxLength: 20, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Administ__43AA41414F2448F6", x => x.admin_id);
                    table.ForeignKey(
                        name: "FK__Administr__user___49C3F6B7",
                        column: x => x.user_id,
                        principalTable: "Users",
                        principalColumn: "user_id");
                });

            migrationBuilder.CreateTable(
                name: "Class_Users",
                columns: table => new
                {
                    class_id = table.Column<int>(type: "int", nullable: false),
                    user_id = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Class_Us__166F9AF65884513F", x => new { x.class_id, x.user_id });
                    table.ForeignKey(
                        name: "FK__Class_Use__class__44FF419A",
                        column: x => x.class_id,
                        principalTable: "Classes",
                        principalColumn: "class_id");
                    table.ForeignKey(
                        name: "FK__Class_Use__user___45F365D3",
                        column: x => x.user_id,
                        principalTable: "Users",
                        principalColumn: "user_id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Abonnements_user_id",
                table: "Abonnements",
                column: "user_id");

            migrationBuilder.CreateIndex(
                name: "IX_Administrators_user_id",
                table: "Administrators",
                column: "user_id");

            migrationBuilder.CreateIndex(
                name: "IX_Class_Users_user_id",
                table: "Class_Users",
                column: "user_id");

            migrationBuilder.CreateIndex(
                name: "IX_Classes_schedule_id",
                table: "Classes",
                column: "schedule_id");

            migrationBuilder.CreateIndex(
                name: "UQ__Users__AB6E616417756828",
                table: "Users",
                column: "email",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "UQ__Users__F3DBC572A495439A",
                table: "Users",
                column: "username",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Abonnements");

            migrationBuilder.DropTable(
                name: "Administrators");

            migrationBuilder.DropTable(
                name: "Class_Users");

            migrationBuilder.DropTable(
                name: "Classes");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "Schedules");
        }
    }
}
