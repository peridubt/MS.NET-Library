using Library.BusinessLogic.Employees.Entities;

namespace Library.BusinessLogic.Employees.Provider;

public interface IEmployeesProvider
{
    IEnumerable<EmployeeModel> GetEmployees(FilterEmployeeModel? filter = null);
    EmployeeModel GerEmployeeInfo(int id);
}