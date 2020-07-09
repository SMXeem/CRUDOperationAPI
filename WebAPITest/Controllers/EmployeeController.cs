using System;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Web.Http;
using WebAPITest.Models;

namespace WebAPITest.Controllers
{
    //[RoutePrefix("api/Employee")]
    public class EmployeeController : ApiController
    {
        RdlcReportEntities aStudentEntities = new RdlcReportEntities();
        // GET: Employee
        
        [System.Web.Mvc.HttpGet]
        //[System.Web.Mvc.Route("Getall")]
        public HttpResponseMessage GetAll()
        {

            try
            {
                List<Student> aStudentList = aStudentEntities.Students.ToList();
                var response = new HttpResponseMessage(HttpStatusCode.OK);

                //response.Content = new StringContent(JsonConvert.SerializeObject());
                response.Content = new StringContent(JsonConvert.SerializeObject(aStudentList, new JsonSerializerSettings
                                                    {
                                                        ReferenceLoopHandling = ReferenceLoopHandling.Ignore
                                                    }));
                response.Content.Headers.ContentType = new MediaTypeHeaderValue("application/json");
                return response;
            }
            catch
            {
                return new HttpResponseMessage(HttpStatusCode.BadRequest);
            }
        }
        [HttpGet]
        //[System.Web.Mvc.Route("Getall")]
        public HttpResponseMessage GetById(int id)
        {

            try
            {
                Student astudentList = aStudentEntities.Students.FirstOrDefault(w => w.ID == id);
                var response = new HttpResponseMessage(HttpStatusCode.OK);
                response.Content = new StringContent(JsonConvert.SerializeObject(astudentList, new JsonSerializerSettings
                {
                    ReferenceLoopHandling = ReferenceLoopHandling.Ignore
                }));
                response.Content.Headers.ContentType = new MediaTypeHeaderValue("application/json");
                return response;
            }
            catch
            {
                return new HttpResponseMessage(HttpStatusCode.BadRequest);
            }
        }
        [HttpPost]
        public HttpResponseMessage Create(Student student)
        {

            try
            {
                if (student.EnrollmentDate== null)
                {
                    student.EnrollmentDate = DateTime.Now;
                }
                
                var response = new HttpResponseMessage(HttpStatusCode.OK);
                aStudentEntities.Students.Add(student);
                aStudentEntities.SaveChanges();
                return response;
            }
            catch(Exception e)
            {
                return new HttpResponseMessage(HttpStatusCode.BadRequest);
            }
        }
        [HttpDelete]
        //[System.Web.Mvc.Route("Getall")]
        public HttpResponseMessage DeleteById(int id)
        {

            try
            {
                Student aStudent = aStudentEntities.Students.FirstOrDefault(w => w.ID == id);
                var response = new HttpResponseMessage(HttpStatusCode.OK);
                aStudentEntities.Students.Remove(aStudent ?? throw new InvalidOperationException());
                aStudentEntities.SaveChanges();
                return response;
            }
            catch
            {
                return new HttpResponseMessage(HttpStatusCode.BadRequest);
            }
        }
        [HttpPut]
        //[System.Web.Mvc.Route("Getall")]
        public HttpResponseMessage Update(Student student)
        {

            try
            {
                Student aStudent = aStudentEntities.Students.FirstOrDefault(w => w.ID ==student.ID);
                var response = new HttpResponseMessage(HttpStatusCode.OK);
                aStudent.FirstMidName=student.FirstMidName;
                aStudent.LastName=student.LastName;
                aStudent.EnrollmentDate=student.EnrollmentDate;
                aStudentEntities.SaveChanges();
                return response;
            }
            catch
            {
                return new HttpResponseMessage(HttpStatusCode.BadRequest);
            }
        }
    }
}