using System.ComponentModel.DataAnnotations;

namespace WebApp5ByKhagendra.Models
{
    public class Course
    {
        public int CourseId { get; set; }

        [Required]
        public string CourseName { get; set; } = string.Empty;

        [Required]
        [Range(1, 5)]
        public int Credits { get; set; }

        public string? Description { get; set; }
        public ICollection<StudentCourse> StudentCourses { get; set; } = new List<StudentCourse>();
    }
} 