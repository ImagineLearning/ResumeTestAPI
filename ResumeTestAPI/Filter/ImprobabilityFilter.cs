using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Controllers;
using System.Web.Http.Filters;
using ResumeTestAPI.Service;

namespace ResumeTestAPI.Filter
{
	public class ImprobabilityFilter : ActionFilterAttribute
	{
		private readonly InfiniteImprobabilityDrive _improbability;

		public ImprobabilityFilter()
		{
			_improbability = new InfiniteImprobabilityDrive();
		}

		public override void OnActionExecuting(HttpActionContext actionContext)
		{
			HttpResponseMessage result = null;
			//provide some 400s during a post
			if (actionContext.Request.Method == HttpMethod.Post)
			{
				result = _improbability.DidIGetUnluckyWithA400();
			}

			//add in some 503s on occasion
			if (result == null)
			{
				result = _improbability.DidIGetUnluckyWithA503();
			}

			//send back errors if we did get one of the above scenarios
			if (result != null)
			{
				throw new HttpResponseException(result.StatusCode);
			}
		}

		public override async void OnActionExecuted(HttpActionExecutedContext actionExecutedContext)
		{
			base.OnActionExecuted(actionExecutedContext);

			if (actionExecutedContext.Response.StatusCode == HttpStatusCode.NoContent)
			{
				return;
			}

			var responseString = await actionExecutedContext.Response.Content.ReadAsStringAsync();
			if (responseString == null) return;

			var newString = _improbability.DoubleCheckMyJson(responseString);
			actionExecutedContext.Response.Content = new StringContent(newString);
		}
	}
}