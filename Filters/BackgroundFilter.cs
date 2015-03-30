using Orchard.Caching;
using Orchard.MediaPicker.Fields;
using Orchard.Mvc.Filters;
using Orchard.RandomBackground.Models;
using Orchard.RandomBackground.Services;
using Orchard.UI.Admin;
using Orchard.UI.Resources;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Mvc;

namespace Orchard.RandomBackground.Filters
{
	public class BackgroundFilter : FilterProvider, IResultFilter
	{
		private readonly IWorkContextAccessor _workContextAccessor;
		private readonly IBackgroundService _backgroundService;
		private readonly ICacheManager _cacheManager;
		private readonly ISignals _signals;
		private readonly IResourceManager _resourceManager;

		public BackgroundFilter(
			IWorkContextAccessor workContextAccessor,
			IBackgroundService settingsService,
			ICacheManager cacheManager,
			ISignals signals,
			IResourceManager resourceManager)
		{
			_workContextAccessor = workContextAccessor;
			_backgroundService = settingsService;
			_cacheManager = cacheManager;
			_signals = signals;
			_resourceManager = resourceManager;
		}

		
		public void OnResultExecuting(ResultExecutingContext filterContext)
		{
			// ignore background on admin pages
			if (AdminFilter.IsApplied(filterContext.RequestContext))
				return;
			
			// should only run on a full view rendering result
			if (!(filterContext.Result is ViewResult))
				return;

			_resourceManager.Require("script", "RandomBackground");

			List<BackgroundPart> backgrounds = _cacheManager.Get(
									"Randombackground.BackgroundList",
									ctx =>
									{
										ctx.Monitor(_signals.When("Randombackground.BackgroundListChanged"));
										return _backgroundService.Get().ToList();
									});
			
			int backgroundCount = backgrounds.Count();

			
			if (backgroundCount == 0)
			{
				return;
			}

			Random rnd = new Random();
			int randomNumber = rnd.Next(0, (backgroundCount-1)); 
			
			MediaPickerField backgroundField = (MediaPickerField)backgrounds[randomNumber].Fields.FirstOrDefault();
			
			UrlHelper helper = new UrlHelper(filterContext.RequestContext);
			string imgPath = helper.Content(backgroundField.Url);

			StringBuilder script = new StringBuilder();

			script.Append("<script type=\"text/javascript\">\n");
			script.Append("$(document).ready(function() { \n");
			script.AppendFormat("$('html').css('background-image', 'url(\"{0}\")');\n", imgPath);
			script.Append("});\n");
			script.Append("</script>\n");
			
			var context = _workContextAccessor.GetContext();
			
			var tail = context.Layout.Tail;
			tail.Add(new MvcHtmlString(script.ToString()));
		}
		
		public void OnResultExecuted(ResultExecutedContext filterContext)
		{
		}
	}
}