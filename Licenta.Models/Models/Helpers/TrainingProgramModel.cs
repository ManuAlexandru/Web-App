namespace Licenta.Models.Models.Helpers
{
    public class TrainingProgramModel
    {
        public string Name { get; set; }
        public List<string> Services { get; set; }
        public string Price { get; set; }
        public StyleModel ProgramStyle { get; set; }
    }
}
