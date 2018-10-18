using EmpDepWebAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace EmpDepWebAPI.Controllers
{
    public class DepartmentController : ApiController
    {
        DepsModel deps = new DepsModel();
        // департамент
        // Department


        // GET: getemps
        /// <summary>
        /// Возвращает список департаментов из БД, из таблицы Department.
        /// </summary>
        /// <returns></returns>
        [Route("getdeps")]
        public IEnumerable<Department> GetDepartments()
        {
            return deps.GetDepartments();
        }

        // GET: getemps/{id}
        /// <summary>
        /// Возвращает департамент из таблицы Department по идентификатору.
        /// </summary>
        /// <param name="id">Идентификатор департаментa.</param>
        /// <returns></returns>
        [Route("getdeps/{id}")]
        public IHttpActionResult GetDepartmentByID(int id)
        {
            var tmp = deps.GetDepartment(id);
            if (tmp == null)
                return NotFound();
            return Ok(tmp);
        }

        // POST: adddeps
        /// <summary>
        /// Добавляет департамент в таблицу Department.
        /// </summary>
        /// <param name="value">Объект "департамент".</param>
        /// <returns></returns>
        [Route("adddeps")]
        public HttpResponseMessage AddDepartment([FromBody]Department value)
        {
            if (deps.AddDepartment(value))
                return Request.CreateResponse(HttpStatusCode.Created);
            else
                return Request.CreateResponse(HttpStatusCode.BadRequest);
        }

        // POST: changedeps
        /// <summary>
        /// Изменение департамента.
        /// </summary>
        /// <param name="value">Измененный департамент.</param>
        /// <returns></returns>
        [Route("changedeps")]
        public HttpResponseMessage ChangeDepartment([FromBody]Department value)
        {
            if (deps.ChangeDepartment(value))
                return Request.CreateResponse(HttpStatusCode.Created);
            else
                return Request.CreateResponse(HttpStatusCode.BadRequest);
        }

        // DELETE: deldeps/{id}
        /// <summary>
        /// Удаляет департамент из таблицы Department.
        /// </summary>
        /// <param name="id">Идентификатор департамента.</param>
        /// <returns></returns>
        [Route("deldeps/{id}")]
        public HttpResponseMessage Delete(int id)
        {
            if (deps.DeleteDepartment(id))
                return Request.CreateResponse(HttpStatusCode.Created);
            else
                return Request.CreateResponse(HttpStatusCode.BadRequest);
        }
    }
}
