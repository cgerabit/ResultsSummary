namespace ResultsSummary.ViewModels
{
    public class ResultViewModel
    {
        public int Id { get; set; }
        public int ReactionScore { get; set; }
        public int MemoryScore { get; set; }
        public int VerbalScore { get; set; }
        public int VisualScore { get; set; }

        public int PercentOfPeople { get; set; }
        public double AverageScore { get; set; }
    }
}
