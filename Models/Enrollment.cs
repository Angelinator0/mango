namespace StudentPortal.Models
{
    // Модель Enrollment (запись на курс). связующая таблица между Student и Course
    public class Enrollment
    {
        public int Id { get; set; }

        public int StudentId { get; set; }
        public Student Student { get; set; } = null!;

        public int CourseId { get; set; }
        public Course Course { get; set; } = null!;

        public string? Grade { get; set; }
    }
}