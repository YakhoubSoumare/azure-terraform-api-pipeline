using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace TaskManagerApi.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "TaskItems",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    RequestTeam = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ReceivingTeam = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Status = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ReviewMessage = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsApproved = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TaskItems", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "TaskItems",
                columns: new[] { "Id", "IsApproved", "ReceivingTeam", "RequestTeam", "ReviewMessage", "Status", "Title" },
                values: new object[,]
                {
                    { 1L, false, "Frontend", "DevOps", null, "Pending", "Task 1" },
                    { 2L, true, "Frontend", "Backend", "Reviewed and approved", "Active", "Task 2" },
                    { 3L, false, "Test", "Frontend", "Needs modifications", "Review", "Task 3" },
                    { 4L, true, "Backend", "DevOps", null, "Pending", "Task 4" },
                    { 5L, true, "DevOps", "Backend", "Approved after review", "Active", "Task 5" },
                    { 6L, false, "Backend", "Frontend", "Review pending", "Pending", "Task 6" },
                    { 7L, true, "Frontend", "DevOps", "Reviewed successfully", "Review", "Task 7" },
                    { 8L, false, "Frontend", "Backend", "In review process", "Pending", "Task 8" },
                    { 9L, true, "Backend", "Test", null, "Active", "Task 9" },
                    { 10L, false, "Test", "DevOps", "Pending feedback", "Review", "Task 10" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TaskItems");
        }
    }
}
