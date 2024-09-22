using EmployeeService.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net;
using System.Web.Http;


namespace EmployeeService.Controllers
{
   public class EmployeesController : ApiController
    {
       /* public HttpResponseMessage Get(string gender = "All")
        {
            using (WEBAPI_DBEntities1 dbContext = new WEBAPI_DBEntities1())
            {
                switch (gender.ToLower())
                {
                    case "all":
                        return Request.CreateResponse(HttpStatusCode.OK,
                            dbContext.Employees.ToList());
                    case "male":
                        return Request.CreateResponse(HttpStatusCode.OK,
                            dbContext.Employees.Where(e => e.Gender.ToLower() == "male").ToList());
                    case "female":
                        return Request.CreateResponse(HttpStatusCode.OK,
                            dbContext.Employees.Where(e => e.Gender.ToLower() == "female").ToList());
                    default:
                        return Request.CreateErrorResponse(HttpStatusCode.BadRequest,
                            "Value for gender must be Male, Female or All. " + gender + " is invalid.");
                }
            }
        }*/
         public IEnumerable<Employee> Get()
         {
             using (WEBAPI_DBEntities1 dbContext = new WEBAPI_DBEntities1())
             {
                 return dbContext.Employees.ToList();
             }
         }
         public Employee Get(int id)
         {
             if (id == 0)
             {
                 throw new ArgumentException("Invalid ID.", nameof(id));
             }
            using (WEBAPI_DBEntities1 dbcontext = new WEBAPI_DBEntities1())
            {
                return dbcontext.Employees.FirstOrDefault(e => e.ID == id);
            }
         } 

        /* public HttpResponseMessage Post([FromBody] Employee employee)
         {
             try
             {
                 using (WEBAPI_DBEntities1 dbContext = new WEBAPI_DBEntities1())
                 {
                     dbContext.Employees.Add(employee);
                     dbContext.SaveChanges();
                     var message = Request.CreateResponse(HttpStatusCode.Created, employee);
                     message.Headers.Location = new Uri(Request.RequestUri +
                         employee.ID.ToString());
                     return message;
                 }
             }
             catch (Exception ex)
             {
                 return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ex);
             }
         }
     }*/
        /*  public HttpResponseMessage Put(int id, [FromBody] Employee employee)
          {
              try
              {
                  using (WEBAPI_DBEntities1 dbContext = new WEBAPI_DBEntities1())
                  {
                      var entity = dbContext.Employees.FirstOrDefault(e => e.ID == id);
                      if (entity == null)
                      {
                          return Request.CreateErrorResponse(HttpStatusCode.NotFound,
                              "Employee with Id " + id.ToString() + " not found to update");
                      }
                      else
                      {
                          entity.FirstName = employee.FirstName;
                          entity.LastName = employee.LastName;
                          entity.Gender = employee.Gender;
                          entity.Salary = employee.Salary;

                          dbContext.SaveChanges();

                          return Request.CreateResponse(HttpStatusCode.OK, entity);
                      }
                  }
              }
              catch (Exception ex)
              {
                  return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ex);
              }
          }
      } */
        public HttpResponseMessage Delete(int id)
        {
            try
            {
                using (WEBAPI_DBEntities1 dbContext = new WEBAPI_DBEntities1())
                {
                    var entity = dbContext.Employees.FirstOrDefault(e => e.ID == id);
                    if (entity == null)
                    {
                        return Request.CreateErrorResponse(HttpStatusCode.NotFound,
                            "Employee with Id = " + id.ToString() + " not found to delete");
                    }
                    else
                    {
                        dbContext.Employees.Remove(entity);
                        dbContext.SaveChanges();
                        return Request.CreateResponse(HttpStatusCode.OK);
                    }
                }
            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ex);
            }
        }
    }
}
