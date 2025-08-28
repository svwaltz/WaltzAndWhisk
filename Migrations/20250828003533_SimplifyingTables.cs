using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WaltzAndWhisk.Migrations
{
    /// <inheritdoc />
    public partial class SimplifyingTables : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Ingredients_IngredientSubsections_IngredientSubsectionId",
                table: "Ingredients");

            migrationBuilder.DropForeignKey(
                name: "FK_Instructions_InstructionSubsections_InstructionSubsectionId",
                table: "Instructions");

            migrationBuilder.DropForeignKey(
                name: "FK_Recipes_Categories_CategoryId",
                table: "Recipes");

            migrationBuilder.DropTable(
                name: "Categories");

            migrationBuilder.DropTable(
                name: "IngredientSubsections");

            migrationBuilder.DropTable(
                name: "InstructionSubsections");

            migrationBuilder.DropTable(
                name: "Macros");

            migrationBuilder.DropTable(
                name: "IngredientsSections");

            migrationBuilder.DropTable(
                name: "InstructionsSections");

            migrationBuilder.DropIndex(
                name: "IX_Recipes_CategoryId",
                table: "Recipes");

            migrationBuilder.DropIndex(
                name: "IX_Ingredients_IngredientSubsectionId",
                table: "Ingredients");

            migrationBuilder.DropColumn(
                name: "CategoryId",
                table: "Recipes");

            migrationBuilder.DropColumn(
                name: "IngredientSubsectionId",
                table: "Ingredients");

            migrationBuilder.DropColumn(
                name: "Notes",
                table: "Ingredients");

            migrationBuilder.RenameColumn(
                name: "InstructionSubsectionId",
                table: "Instructions",
                newName: "RecipeId");

            migrationBuilder.RenameIndex(
                name: "IX_Instructions_InstructionSubsectionId",
                table: "Instructions",
                newName: "IX_Instructions_RecipeId");

            migrationBuilder.RenameColumn(
                name: "Order",
                table: "Ingredients",
                newName: "RecipeId");

            migrationBuilder.RenameColumn(
                name: "Name",
                table: "Ingredients",
                newName: "Section");

            migrationBuilder.AddColumn<int>(
                name: "Calories",
                table: "Recipes",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<decimal>(
                name: "Carbs",
                table: "Recipes",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<string>(
                name: "Category",
                table: "Recipes",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<decimal>(
                name: "Fat",
                table: "Recipes",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "Protein",
                table: "Recipes",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<string>(
                name: "Section",
                table: "Instructions",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "IngredientName",
                table: "Ingredients",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateIndex(
                name: "IX_Ingredients_RecipeId",
                table: "Ingredients",
                column: "RecipeId");

            migrationBuilder.AddForeignKey(
                name: "FK_Ingredients_Recipes_RecipeId",
                table: "Ingredients",
                column: "RecipeId",
                principalTable: "Recipes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Instructions_Recipes_RecipeId",
                table: "Instructions",
                column: "RecipeId",
                principalTable: "Recipes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Ingredients_Recipes_RecipeId",
                table: "Ingredients");

            migrationBuilder.DropForeignKey(
                name: "FK_Instructions_Recipes_RecipeId",
                table: "Instructions");

            migrationBuilder.DropIndex(
                name: "IX_Ingredients_RecipeId",
                table: "Ingredients");

            migrationBuilder.DropColumn(
                name: "Calories",
                table: "Recipes");

            migrationBuilder.DropColumn(
                name: "Carbs",
                table: "Recipes");

            migrationBuilder.DropColumn(
                name: "Category",
                table: "Recipes");

            migrationBuilder.DropColumn(
                name: "Fat",
                table: "Recipes");

            migrationBuilder.DropColumn(
                name: "Protein",
                table: "Recipes");

            migrationBuilder.DropColumn(
                name: "Section",
                table: "Instructions");

            migrationBuilder.DropColumn(
                name: "IngredientName",
                table: "Ingredients");

            migrationBuilder.RenameColumn(
                name: "RecipeId",
                table: "Instructions",
                newName: "InstructionSubsectionId");

            migrationBuilder.RenameIndex(
                name: "IX_Instructions_RecipeId",
                table: "Instructions",
                newName: "IX_Instructions_InstructionSubsectionId");

            migrationBuilder.RenameColumn(
                name: "Section",
                table: "Ingredients",
                newName: "Name");

            migrationBuilder.RenameColumn(
                name: "RecipeId",
                table: "Ingredients",
                newName: "Order");

            migrationBuilder.AddColumn<int>(
                name: "CategoryId",
                table: "Recipes",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "IngredientSubsectionId",
                table: "Ingredients",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "Notes",
                table: "Ingredients",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Categories",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "IngredientsSections",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RecipeId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_IngredientsSections", x => x.Id);
                    table.ForeignKey(
                        name: "FK_IngredientsSections_Recipes_RecipeId",
                        column: x => x.RecipeId,
                        principalTable: "Recipes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "InstructionsSections",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RecipeId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InstructionsSections", x => x.Id);
                    table.ForeignKey(
                        name: "FK_InstructionsSections_Recipes_RecipeId",
                        column: x => x.RecipeId,
                        principalTable: "Recipes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Macros",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RecipeId = table.Column<int>(type: "int", nullable: false),
                    Calories = table.Column<int>(type: "int", nullable: false),
                    Carbs = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Fat = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Protein = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Macros", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Macros_Recipes_RecipeId",
                        column: x => x.RecipeId,
                        principalTable: "Recipes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "IngredientSubsections",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IngredientsSectionId = table.Column<int>(type: "int", nullable: false),
                    Order = table.Column<int>(type: "int", nullable: false),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_IngredientSubsections", x => x.Id);
                    table.ForeignKey(
                        name: "FK_IngredientSubsections_IngredientsSections_IngredientsSectionId",
                        column: x => x.IngredientsSectionId,
                        principalTable: "IngredientsSections",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "InstructionSubsections",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    InstructionsSectionId = table.Column<int>(type: "int", nullable: false),
                    Order = table.Column<int>(type: "int", nullable: false),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InstructionSubsections", x => x.Id);
                    table.ForeignKey(
                        name: "FK_InstructionSubsections_InstructionsSections_InstructionsSectionId",
                        column: x => x.InstructionsSectionId,
                        principalTable: "InstructionsSections",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Recipes_CategoryId",
                table: "Recipes",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_Ingredients_IngredientSubsectionId",
                table: "Ingredients",
                column: "IngredientSubsectionId");

            migrationBuilder.CreateIndex(
                name: "IX_IngredientsSections_RecipeId",
                table: "IngredientsSections",
                column: "RecipeId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_IngredientSubsections_IngredientsSectionId",
                table: "IngredientSubsections",
                column: "IngredientsSectionId");

            migrationBuilder.CreateIndex(
                name: "IX_InstructionsSections_RecipeId",
                table: "InstructionsSections",
                column: "RecipeId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_InstructionSubsections_InstructionsSectionId",
                table: "InstructionSubsections",
                column: "InstructionsSectionId");

            migrationBuilder.CreateIndex(
                name: "IX_Macros_RecipeId",
                table: "Macros",
                column: "RecipeId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Ingredients_IngredientSubsections_IngredientSubsectionId",
                table: "Ingredients",
                column: "IngredientSubsectionId",
                principalTable: "IngredientSubsections",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Instructions_InstructionSubsections_InstructionSubsectionId",
                table: "Instructions",
                column: "InstructionSubsectionId",
                principalTable: "InstructionSubsections",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Recipes_Categories_CategoryId",
                table: "Recipes",
                column: "CategoryId",
                principalTable: "Categories",
                principalColumn: "Id");
        }
    }
}
