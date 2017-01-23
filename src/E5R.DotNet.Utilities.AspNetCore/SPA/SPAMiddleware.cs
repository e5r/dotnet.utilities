using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;

namespace E5R.DotNet.Utilities.AspNetCore.SPA
{
	public class SPAMiddleware
	{
		private readonly RequestDelegate _next;
		private readonly ILogger _logger;

		public SPAMiddleware(RequestDelegate next, ILoggerFactory loggerFactory)
		{
			if (next == null)
			{
				throw new ArgumentNullException(nameof(next));
			}

			if (loggerFactory == null)
			{
				throw new ArgumentNullException(nameof(loggerFactory));
			}

			_next = next;
			_logger = loggerFactory.CreateLogger<SPAMiddleware>();
		}

		public async Task Invoke(HttpContext context)
		{
			await _next(context);

			if (context.Response.StatusCode == StatusCodes.Status404NotFound)
			{
				context.Request.Path = "/";
				context.Response.StatusCode = StatusCodes.Status200OK;

				await _next(context);
			}
		}
	}
}
