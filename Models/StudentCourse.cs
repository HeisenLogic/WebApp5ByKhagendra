namespace WebApp5ByKhagendra.Models
{
    public class StudentCourse
    {
        public int StudentId { get; set; }
        public int CourseId { get; set; }
        public DateTime EnrollmentDate { get; set; }
        public Student Student { get; set; } = null!;
        public Course Course { get; set; } = null!;
    }
} 