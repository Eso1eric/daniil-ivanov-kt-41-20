namespace daniil_ivanov_kt_41_20.Model;

public class Teacher
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Surname { get; set; }
    public string? Lastname { get; set; }
    public bool isHeadTeacher { get; set; }
    public int DegreeId { get; set; }
    public Degree Degree { get; set; }
    public int PositionId { get; set; }
    public Position Position { get; set; }
    public int DepartmentId { get; set; }
    public Department Department { get; set; }
}