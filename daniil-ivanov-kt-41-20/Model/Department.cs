namespace daniil_ivanov_kt_41_20.Model;

public class Department
{
    public int Id { get; set; }
    public string ShortName { get; set; }
    public string FullName { get; set; }
    public DateTime CreateDate { get; set; }
    public int HeadTeacherId { get; set; }
    public Teacher HeadTeacher { get; set; }
}