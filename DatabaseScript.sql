CREATE DATABASE StudentDB;
GO

USE StudentDB;
GO

CREATE TABLE Students (
    StudentId INT PRIMARY KEY IDENTITY(1,1),
    FirstName NVARCHAR(50) NOT NULL,
    LastName NVARCHAR(50) NOT NULL,
    Email NVARCHAR(100) NOT NULL,
    DateOfBirth DATE NOT NULL,
    CreatedDate DATETIME DEFAULT GETDATE()
);

CREATE TABLE Courses (
    CourseId INT PRIMARY KEY IDENTITY(1,1),
    CourseName NVARCHAR(100) NOT NULL,
    Credits INT NOT NULL,
    Description NVARCHAR(500)
);

CREATE TABLE StudentCourses (
    StudentId INT,
    CourseId INT,
    EnrollmentDate DATETIME DEFAULT GETDATE(),
    FOREIGN KEY (StudentId) REFERENCES Students(StudentId) ON DELETE CASCADE,
    FOREIGN KEY (CourseId) REFERENCES Courses(CourseId) ON DELETE CASCADE,
    PRIMARY KEY (StudentId, CourseId)
);

-- Insert some sample data
INSERT INTO Students (FirstName, LastName, Email, DateOfBirth)
VALUES 
('John', 'Doe', 'john.doe@example.com', '2000-01-01'),
('Jane', 'Smith', 'jane.smith@example.com', '2001-02-15');

INSERT INTO Courses (CourseName, Credits, Description)
VALUES 
('Introduction to Programming', 3, 'Basic programming concepts'),
('Database Management', 4, 'Database design and management'),
('Web Development', 3, 'Web application development'); 