using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EmpDepWebAPI.Models
{
    public class EmpsModel
    {

        System.Data.Entity.DbSet<Employee> emp_list = DBModel.entities.Employee;

        public EmpsModel()
        {
        }

        /// <summary>
        /// Метод получает всех работников из таблицы.
        /// </summary>
        /// <returns></returns>
        public IEnumerable<Employee> GetEmployees()
        {
            var tmp = emp_list.ToList();
            return tmp;
        }

        /// <summary>
        /// Метод получает сотрудника по идентификатору.
        /// </summary>
        /// <param name="id">Идентификатор сотрудника.</param>
        /// <returns></returns>
        public Employee GetEmployee(int id)
        {
            return emp_list.Where(e => e.Id == id).FirstOrDefault();
        }

        /// <summary>
        /// Метод добавляет сотрудника.
        /// </summary>
        public bool AddEmployee(Employee n)
        {
            emp_list.Add(new Employee() {
                Name = n.Name,
                Age = n.Age,
                Salary = n.Salary,
                DepartmentID = n.DepartmentID
            });
            DBModel.entities.SaveChanges();
            return true;
        }

        /// <summary>
        /// Изменяет свойства сотрудника.
        /// </summary>
        /// <param name="n">Измененный сотрудник.</param>
        /// <returns></returns>
        public bool ChangeEmployee(Employee n)
        {
            //DBModel.entities.Department[n.Id]
            Employee newEmp = emp_list
                    .Where(e => e.Id == n.Id)
                    .FirstOrDefault();
            if (newEmp != null)
            {
                newEmp.Name = n.Name;
                newEmp.Age = n.Age;
                newEmp.Salary = n.Salary;
                newEmp.DepartmentID = n.DepartmentID;
                DBModel.entities.SaveChanges();
                return true;
            }
            else
                return false;
        }

        /// <summary>
        /// Метод удаляет сотрудника по идентификатору.
        /// </summary>
        /// <param name="id">Идентификатор сотрудника.</param>
        public bool DeleteEmployee(int id)
        {
            Employee curremp = emp_list.Where(e => e.Id == id).FirstOrDefault();
            if (emp_list.ToList().Count != 0 && curremp != null)
            {
                DBModel.entities.Employee.Remove(curremp);
                DBModel.entities.SaveChanges();
                return true;
            }
            else
                return false;
        }
    }
}