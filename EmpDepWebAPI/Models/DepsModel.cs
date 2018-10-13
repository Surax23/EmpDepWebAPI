using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EmpDepWebAPI.Models
{
    public class DepsModel
    {
        public DepsModel()
        {
        }

        /// <summary>
        /// Метод получает все департаменты из таблицы.
        /// </summary>
        /// <returns></returns>
        public List<Department> GetDepartments()
        {
            return DBModel.entities.Department.ToList();
        }

        /// <summary>
        /// Метод получает департамент по идентификатору.
        /// </summary>
        /// <param name="id">Идентификатор сотрудника.</param>
        /// <returns></returns>
        public Department GetDepartment(int id)
        {
            return DBModel.entities.Department.ToList()[id];
        }

        /// <summary>
        /// Метод добавляет департамент.
        /// </summary>
        public bool AddDepartment(Department n)
        {
            DBModel.entities.Department.Add(new Department()
            {
                Name = n.Name
            });
            DBModel.entities.SaveChanges();
            return true;
        }

        /// <summary>
        /// Метод удаляет департамент по идентификатору.
        /// </summary>
        /// <param name="id">Идентификатор департамента.</param>
        public bool DeleteDepartment(int id)
        {
            if (DBModel.entities.Department.ToList().Count != 0)
            {
                Department tmp = DBModel.entities.Department
                    .Where(e => e.Id == id)
                    .FirstOrDefault();
                DBModel.entities.Department.Remove(tmp);
                DBModel.entities.SaveChanges();
                return true;
            }
            else
                return false;
        }
    }
}