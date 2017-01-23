using System;
using Microsoft.Extensions.Options;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.FileProviders;
using Microsoft.AspNetCore.Hosting;

namespace Microsoft.AspNetCore.Builder
{
	using E5R.DotNet.Utilities.AspNetCore.SPA;

	public static class SPAApplicationBuilderExtensions
	{
		public static IApplicationBuilder UseSPA(this IApplicationBuilder builder)
		{
			IServiceProvider serviceProvider = builder.ApplicationServices;
			var options = serviceProvider.GetService<IOptions<SPAOptions>>().Value;
			var env = serviceProvider.GetService<IHostingEnvironment>();

			if (options == null)
			{
				throw new NullReferenceException(typeof(IOptions<SPAOptions>).Name + " reference is null.");
			}

			if (env == null)
			{
				throw new NullReferenceException(typeof(IHostingEnvironment).Name + " reference is null.");
			}

			options.FillNullOptions(env);

			return builder.UseMiddleware<SPAMiddleware>()
						  .ConfigureBootstrapper(options)
						  .ConfigureApp(options)
						  .ConfigureLib(options)
						  .ConfigureStatic(options);
		}

		static IApplicationBuilder ConfigureBootstrapper(this IApplicationBuilder builder, SPAOptions options)
		{
			return builder.UseFileServer(new FileServerOptions
			{
				FileProvider = new PhysicalFileProvider(options.BootstrapperPhysicalPath),
				EnableDefaultFiles = true,
				EnableDirectoryBrowsing = false,
				RequestPath = options.BootstrapperPath
			});
		}

		static IApplicationBuilder ConfigureApp(this IApplicationBuilder builder, SPAOptions options)
		{
			return builder.UseFileServer(new FileServerOptions
			{
				FileProvider = new PhysicalFileProvider(options.AppPhysicalPath),
				EnableDefaultFiles = false,
				EnableDirectoryBrowsing = false,
				RequestPath = options.AppPath
			});
		}

		static IApplicationBuilder ConfigureLib(this IApplicationBuilder builder, SPAOptions options)
		{
			return builder.UseFileServer(new FileServerOptions
			{
				FileProvider = new PhysicalFileProvider(options.LibPhysicalPath),
				EnableDefaultFiles = false,
				EnableDirectoryBrowsing = false,
				RequestPath = options.LibPath
			});
		}

		static IApplicationBuilder ConfigureStatic(this IApplicationBuilder builder, SPAOptions options)
		{
			return builder.UseFileServer(new FileServerOptions
			{
				FileProvider = new PhysicalFileProvider(options.StaticPhysicalPath),
				EnableDefaultFiles = false,
				EnableDirectoryBrowsing = false,
				RequestPath = options.StaticPath
			});
		}
	}
}
