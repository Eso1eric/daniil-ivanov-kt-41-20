using daniil_ivanov_kt_41_20.Model;

namespace Tests;

public class DepartmentTests
{
    [Fact]
    public void IsValidShortName_IVT_True()
    {
        var testDepartment = new Department()
        {
            FullName = "Информатика и вычислительная техника",
            ShortName = "ИВТ"
        };

        var result = testDepartment.IsValidShortName();

        Assert.True(result);
    }
}