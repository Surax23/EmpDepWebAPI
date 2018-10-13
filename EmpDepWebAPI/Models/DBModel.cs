using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EmpDepWebAPI.Models
{
    /// <summary>
    /// Статический класс для доступа к базе данных с помощью Entity Framework?
    /// </summary>
    public static class DBModel
    {
        /// <summary>
        /// Статический доступ к базе данных с помощью Entity Framework?
        /// </summary>
        public static EmpDepEntities entities = new EmpDepEntities();
    }
}