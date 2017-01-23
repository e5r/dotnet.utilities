using System;
using System.IO;
using Microsoft.AspNetCore.Hosting;

namespace E5R.DotNet.Utilities.AspNetCore.SPA
{
	public static class SPAOptionsExtensions
	{
		public static void FillNullOptions(this SPAOptions options, IHostingEnvironment env)
		{
			if (env == null)
			{
				throw new ArgumentNullException(nameof(env));
			}

			options.BootstrapperPath = options.BootstrapperPath ?? "";
			options.AppPath = options.AppPath ?? "/app";
			options.LibPath = options.LibPath ?? "/lib";
			options.StaticPath = options.StaticPath ?? "/static";

			string webRootPath = env.WebRootPath ?? env.ContentRootPath;

			options.BootstrapperPhysicalPath = options.BootstrapperPhysicalPath
				?? Path.Combine(webRootPath, "bootstrapper");
			options.AppPhysicalPath = options.AppPhysicalPath
				?? Path.Combine(webRootPath, "app");
			options.LibPhysicalPath = options.LibPhysicalPath
				?? Path.Combine(webRootPath, "lib");
			options.StaticPhysicalPath = options.StaticPhysicalPath
				?? Path.Combine(webRootPath, "static");
		}
	}
}
