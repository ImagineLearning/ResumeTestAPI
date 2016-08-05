using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;

namespace ResumeTestAPI.Service
{
	public class InfiniteImprobabilityDrive
	{
		public HttpResponseMessage DidIGetUnluckyWithA503()
		{
			var randomNumber = RandomNumber.Next(1, 10);
			if (randomNumber == 1)
			{
				//aww man a 503
				var response = new HttpResponseMessage();
				response.StatusCode = HttpStatusCode.ServiceUnavailable;
				return response;
			}

			return null;
		}

		public HttpResponseMessage DidIGetUnluckyWithA400()
		{
			var randomNumber = RandomNumber.Next(1, 10);
			if (randomNumber == 1)
			{
				//aww man a 400
				var response = new HttpResponseMessage();
				response.StatusCode = HttpStatusCode.BadRequest;
				return response;
			}

			return null;
		}

		const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
		public string DoubleCheckMyJson(string json)
		{
			var randomNumber = RandomNumber.Next(1, 10);
			if (randomNumber == 1)
			{
				return new string(Enumerable.Repeat(chars, RandomNumber.Next(1, 50))
					.Select(s => s[RandomNumber.Next(s.Length)]).ToArray());
			}

			return json;
		}

	}
}