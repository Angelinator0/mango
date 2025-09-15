namespace StudentPortal.Models
{
    public class Student
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public int Age { get; set; }
        
    // Навигационное свойство для связи многие-ко-многим через Enrollment.
        public ICollection<Enrollment> Enrollments { get; set; } = new List<Enrollment>();
    }
}