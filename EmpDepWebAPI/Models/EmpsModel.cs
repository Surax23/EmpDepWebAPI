using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EmpDepWebAPI.Models
{
    public class EmpsModel
    {
        public EmpsModel()
        {
        }

        /// <summary>
        /// Метод получает всех работников из таблицы.
        /// </summary>
        /// <returns></returns>
        public List<Employee> GetEmployees()
        {
            return DBModel.entities.Employee.ToList();
        }

        /// <summary>
        /// Метод получает сотрудника по идентификатору.
        /// </summary>
        /// <param name="id">Идентификатор сотрудника.</param>
        /// <returns></returns>
        public Employee GetEmployee(int id)
        {
            return DBModel.entities.Employee.ToList()[id];
        }

        /// <summary>
        /// Метод добавляет сотрудника.
        /// </summary>
        public bool AddEmployee(Employee n)
        {
            DBModel.entities.Employee.Add(new Employee() {
                Name = n.Name,
                Age = n.Age,
                Salary = n.Salary,
                DepartmentID = n.DepartmentID
            });
            DBModel.entities.SaveChanges();
            return true;
        }

        /// <summary>
        /// Метод удаляет сотрудника по идентификатору.
        /// </summary>
        /// <param name="id">Идентификатор сотрудника.</param>
        public bool DeleteEmployee(int id)
        {
            if (DBModel.entities.Employee.ToList().Count != 0)
            {
                //DBModel.entities.Employee.ToList().RemoveAt(id);
                Employee tmp = DBModel.entities.Employee
                    .Where(e => e.Id == id)
                    .FirstOrDefault();
                //DBModel.entities.Employee.Attach(tmp);
                DBModel.entities.Employee.Remove(tmp);
                DBModel.entities.SaveChanges();
                return true;
            }
            else
                return false;
        }
    }
}