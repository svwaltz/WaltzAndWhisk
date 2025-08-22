# WaltzAndWhisk
A personal recipe & cooking journal app built with .NET and cshtml.

## Tech Stack
* C#
* .NET 9 (ASP.NET Core MVC)
* Razor Pages (cshtml)
* Entity Framework Core (EF Core) for migrations
* Azure SQL Database (hosted)
* CSS for front-end styling
* Git + GitHub for version control

## Features
* Home page
* View recipe page

## Database Tables
### Recipe
* Id (int, PK) – unique identifier
* Title (string) – recipe title
* Description (string, optional) – short description
* PrepTimeMinutes (int) – preparation time in minutes
* CookTimeMinutes (int) – cooking time in minutes
* InactiveTimeMinutes (int) – resting/inactive time in minutes
* NumServings (int) – number of servings
* CreatedDate (DateTime) – creation timestamp
* UpdatedDate (DateTime) – last updated timestamp
* CategoryId (int, optional, FK) – links to Category
* MacrosId (int, optional, FK) – links to Macros
* IsFeatured (bool) – highlights recipe on homepage
### Category
* Id (int, PK) – unique identifier
* Name (string) – category name (e.g., Dessert, Breakfast)
### IngredientsSection
* Id (int, PK) – unique identifier
* RecipeId (int, FK) – links to Recipe
* Subsections (collection) – ingredient subsections
#### IngredientSubsection
* Id (int, PK) – unique identifier
* IngredientsSectionId (int, FK) – links to IngredientsSection
* Title (string) – subsection title (e.g., “Cake”, “Frosting”)
* Items (collection) – ingredients
* Order (int) – display order
##### Ingredient
* Id (int, PK) – unique identifier
* IngredientSubsectionId (int, FK) – links to IngredientSubsection
* Name (string) – ingredient name
* Quantity (decimal) – amount
* Unit (string, optional) – unit of measure
* Notes (string, optional) – extra notes
* Order (int) – display order
### InstructionsSection
* Id (int, PK) – unique identifier
* RecipeId (int, FK) – links to Recipe
* Subsections (collection) – instruction subsections
#### InstructionSubsection
* Id (int, PK) – unique identifier
* InstructionsSectionId (int, FK) – links to InstructionsSection
* Title (string) – subsection title (e.g., “Cake”, “Frosting”)
* Steps (collection) – steps for this subsection
* Order (int) – display order
##### Instruction
* Id (int, PK) – unique identifier
* InstructionSubsectionId (int, FK) – links to InstructionSubsection
* StepText (string) – text for the instruction step
* Order (int) – step order
### RecipeImage
* Id (int, PK) – unique identifier
* RecipeId (int, FK) – links to Recipe
* ImageUrl (string) – URL to image
* Order (int) – display order
### Macros
* Id (int, PK) – unique identifier
* RecipeId (int, FK) – links to Recipe
* Calories (int)
* Protein (decimal)
* Carbs (decimal)
* Fat (decimal)

## Getting Started