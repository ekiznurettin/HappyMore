using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DataAccess.Migrations
{
    public partial class addMig01 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Favorites",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Liking = table.Column<string>(maxLength: 150, nullable: false),
                    Liked = table.Column<string>(maxLength: 150, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Favorites", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "OperationClaims",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OperationClaims", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "UserImages",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    UserKey = table.Column<string>(nullable: false),
                    ImageUrl = table.Column<string>(maxLength: 150, nullable: false),
                    Status = table.Column<int>(nullable: false),
                    CreatedDate = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserImages", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "UserOperationClaims",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    UserId = table.Column<int>(nullable: false),
                    OperationClaimId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserOperationClaims", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    UserId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    UserKey = table.Column<string>(nullable: true),
                    Name = table.Column<string>(maxLength: 50, nullable: false),
                    Surname = table.Column<string>(maxLength: 50, nullable: false),
                    Mail = table.Column<string>(maxLength: 75, nullable: false),
                    ProfileImage = table.Column<string>(maxLength: 250, nullable: true),
                    PasswordHash = table.Column<byte[]>(nullable: true),
                    PasswordSalt = table.Column<byte[]>(nullable: true),
                    Bio = table.Column<string>(maxLength: 500, nullable: true),
                    Gender = table.Column<int>(maxLength: 2, nullable: true),
                    Relation = table.Column<int>(maxLength: 100, nullable: true),
                    Province = table.Column<string>(maxLength: 250, nullable: true),
                    Instagram = table.Column<string>(maxLength: 50, nullable: true),
                    Hobiler = table.Column<string>(maxLength: 500, nullable: true),
                    Phone = table.Column<string>(maxLength: 13, nullable: true),
                    Address = table.Column<string>(maxLength: 150, nullable: true),
                    IsGender = table.Column<int>(nullable: true),
                    IsBio = table.Column<int>(nullable: true),
                    IsPlace = table.Column<int>(nullable: true),
                    Status = table.Column<int>(nullable: true),
                    Age = table.Column<int>(nullable: true),
                    Lat = table.Column<decimal>(type: "DECIMAL(18,12)", nullable: false),
                    Lng = table.Column<decimal>(type: "DECIMAL(18,12)", nullable: false),
                    Job = table.Column<string>(maxLength: 250, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.UserId);
                });

            migrationBuilder.CreateTable(
                name: "Posts",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    UserId = table.Column<int>(nullable: false),
                    Place = table.Column<string>(nullable: true),
                    Longitude = table.Column<float>(nullable: false),
                    Latitude = table.Column<float>(nullable: false),
                    Status = table.Column<int>(nullable: false),
                    PostDate = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Posts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Posts_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Posts_UserId",
                table: "Posts",
                column: "UserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Favorites");

            migrationBuilder.DropTable(
                name: "OperationClaims");

            migrationBuilder.DropTable(
                name: "Posts");

            migrationBuilder.DropTable(
                name: "UserImages");

            migrationBuilder.DropTable(
                name: "UserOperationClaims");

            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
