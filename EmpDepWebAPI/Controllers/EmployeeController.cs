using EmpDepWebAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace EmpDepWebAPI.Controllers
{
    public class EmployeeController : ApiController
    {
        EmpsModel emps = new EmpsModel();

        // GET: getemps
        /// <summary>
        /// Возвращает список сотрудников из БД, из таблицы Employee.
        /// </summary>
        /// <returns></returns>
        [Route("getemps")]
        public IEnumerable<Employee> GetEmployees()
        {
            return emps.GetEmployees();
        }

        // GET: getemps/{id}
        /// <summary>
        /// Возвращает сотрудника из таблицы Employees по идентификатору.
        /// </summary>
        /// <param name="id">Идентификатор сотрудника.</param>
        /// <returns></returns>
        [Route("getemps/{id}")]
        public IHttpActionResult GetEmployeesByID(int id)
        {
            var tmp = emps.GetEmployee(id);
            if (tmp == null)
                return NotFound();
            return Ok(tmp);
        }

        // POST: api/Employee
        /// <summary>
        /// Добавляет сотрудника в таблицу Employee.
        /// </summary>
        /// <param name="value">Объект "Сотрудник"</param>
        /// <returns></returns>
        [Route("addemps")]
        public HttpResponseMessage AddEmployee([FromBody]Employee value)
        {
            if (emps.AddEmployee(value))
                return Request.CreateResponse(HttpStatusCode.Created);
            else
                return Request.CreateResponse(HttpStatusCode.BadRequest);
        }

        // POST: changeemps
        /// <summary>
        /// Изменение сотрудника.
        /// </summary>
        /// <param name="value">Измененный сотрудник.</param>
        /// <returns></returns>
        [Route("changeemps")]
        public HttpResponseMessage ChangeEmployee([FromBody]Employee value)
        {
            if (emps.ChangeEmployee(value))
                return Request.CreateResponse(HttpStatusCode.Created);
            else
                return Request.CreateResponse(HttpStatusCode.BadRequest);
        }

        //// PUT: api/Employee/5
        //public void Put(int id, [FromBody]string value)
        //{
        //}

        // DELETE: delemps/{id}
        /// <summary>
        /// Удаляет сотрнудника из таблицы Employee.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [Route("delemps/{id}")]
        public HttpResponseMessage Delete(int id)
        {
            if (emps.DeleteEmployee(id))
                return Request.CreateResponse(HttpStatusCode.Created);
            else
                return Request.CreateResponse(HttpStatusCode.BadRequest);
        }
    }
}
