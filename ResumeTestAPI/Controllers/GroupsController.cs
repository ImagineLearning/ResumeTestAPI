using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;

namespace ResumeTestAPI.Controllers
{
	public class GroupsController : ApiController
	{
		// GET api/values	
		public IEnumerable<string> Get()
		{
			return new string[] { "group1", "group2" };
		}

		// GET api/values/5
		public string Get(int id)
		{
			return "groupwithid";
		}
	}
}