namespace daniil_ivanov_kt_41_20.Model;

public class Subject
{
    public int Id { get; set; }
    public string Name { get; set; }
    public int TeacherId { get; set; }
    public Teacher Teacher { get; set; }
}