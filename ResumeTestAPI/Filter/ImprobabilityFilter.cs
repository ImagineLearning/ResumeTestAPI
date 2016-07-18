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
			var result = _improbability.DidIGetUnluckyWithA503();
			if (result != null)
			{
				throw new HttpResponseException(result.StatusCode);
			}
		}

		public override async void OnActionExecuted(HttpActionExecutedContext actionExecutedContext)
		{
			base.OnActionExecuted(actionExecutedContext);

			var responseString = await actionExecutedContext.Response.Content.ReadAsStringAsync();
			if (responseString == null) return;

			var newString = _improbability.DoubleCheckMyJson(responseString);
			actionExecutedContext.Response.Content = new StringContent(newString);
		}
	}
}