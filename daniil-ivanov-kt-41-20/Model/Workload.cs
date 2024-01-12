namespace daniil_ivanov_kt_41_20.Model;

public class Workload
{
    public int Id { get; set; }
    public int Hours { get; set; }
    public int DepartmentId { get; set; }
    public Department Department { get; set; }
    public int TeacherId { get; set; }
    public Teacher Teacher { get; set; }
    public int SubjectId { get; set; }
    public Subject Subject { get; set; }
}