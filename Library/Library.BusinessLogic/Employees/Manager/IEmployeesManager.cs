using Library.BusinessLogic.Employees.Entities;

namespace Library.BusinessLogic.Employees.Manager;

public interface IEmployeesManager
{
    EmployeeModel CreateEmployee(CreateEmployeeModel createModel);
    void DeleteEmployee(int id);
    EmployeeModel UpdateEmployee(UpdateEmployeeModel updateModel);
}