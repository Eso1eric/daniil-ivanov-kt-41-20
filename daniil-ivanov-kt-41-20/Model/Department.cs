namespace daniil_ivanov_kt_41_20.Model;

public class Department
{
    public int Id { get; set; }
    public string ShortName { get; set; }
    public string FullName { get; set; }
    public DateTime CreateDate { get; set; }

    public bool IsValidShortName()
    {
        var abbreviation = string.Join(string.Empty, FullName.Split(" ").Where(e => e.Length > 1).Select(e => e[0]));
        
        return ShortName.Equals(abbreviation, StringComparison.InvariantCultureIgnoreCase);
    }
}