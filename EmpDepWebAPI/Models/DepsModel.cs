using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EmpDepWebAPI.Models
{
    public class DepsModel
    {
        System.Data.Entity.DbSet<Department> dep_list = DBModel.entities.Department;

        public DepsModel()
        {
        }

        /// <summary>
        /// Метод получает все департаменты из таблицы.
        /// </summary>
        /// <returns></returns>
        public List<Department> GetDepartments()
        {
            return dep_list.ToList();
        }

        /// <summary>
        /// Метод получает департамент по идентификатору.
        /// </summary>
        /// <param name="id">Идентификатор сотрудника.</param>
        /// <returns></returns>
        public Department GetDepartment(int id)
        {
            return dep_list.Where(e => e.Id == id).FirstOrDefault() as Department;
        }

        /// <summary>
        /// Метод добавляет департамент.
        /// </summary>
        public bool AddDepartment(Department n)
        {
            dep_list.Add(new Department()
            {
                Name = n.Name
            });
            DBModel.entities.SaveChanges();
            return true;
        }

        /// <summary>
        /// Изменяет свойства департамента.
        /// </summary>
        /// <param name="n">Измененный департамент.</param>
        /// <returns></returns>
        public bool ChangeDepartment(Department n)
        {
            //DBModel.entities.Department[n.Id]
            if (dep_list.Where(e => e.Id == n.Id).FirstOrDefault() != null)
            {
                DBModel.entities.Department
                    .Where(e => e.Id == n.Id)
                    .FirstOrDefault().Name = n.Name;
                DBModel.entities.SaveChanges();
                return true;
            }
            else
                return false;
        }

        /// <summary>
        /// Метод удаляет департамент по идентификатору.
        /// </summary>
        /// <param name="id">Идентификатор департамента.</param>
        public bool DeleteDepartment(int id)
        {
            Department currdep = dep_list.Where(e => e.Id == id).FirstOrDefault();
            if (dep_list.ToList().Count != 0 && currdep != null)
            {
                dep_list.Remove(currdep);
                DBModel.entities.SaveChanges();
                return true;
            }
            else
                return false;
        }
    }
}