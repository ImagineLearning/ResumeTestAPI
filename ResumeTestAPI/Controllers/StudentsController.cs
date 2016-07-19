using System.Collections.Generic;
using System.Web.Http;
using ResumeTestAPI.Models;
using ResumeTestAPI.Service;

namespace ResumeTestAPI.Controllers
{
	public class StudentsController : ApiController
	{
		// GET api/values
		public IEnumerable<Student> Get()
		{
			return Student.GiveMeSomeStudents();
		}

		// GET api/values/5
		public Student Get(int id)
		{

			return Student.GiveMeAStudent(id);
		}

	}
}