namespace WaltzAndWhisk.Models
{
    public class InstructionStep
    {
        public int Id { get; set; }
        public int RecipeSectionId { get; set; }
        public RecipeSection RecipeSection { get; set; }

        public int StepNumber { get; set; }
        public string Description { get; set; }
    }
}
