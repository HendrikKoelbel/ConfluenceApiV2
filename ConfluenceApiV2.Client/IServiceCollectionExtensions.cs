namespace ConfluenceApiV2.Client
{
	using System;
	using Microsoft.Extensions.DependencyInjection;
	using Refit;

	/// <summary>
	/// Extension methods for setting up Refit clients in an <see cref="IServiceCollection" />.
	/// </summary>
	public static partial class IServiceCollectionExtensions
	{
		/// <summary>
		/// Configures the Refit clients for the Confluence API.
		/// </summary>
		/// <param name="services">The <see cref="IServiceCollection" /> to add the services to.</param>
		/// <param name="baseUrl">The base URL for the API clients. The base URL should be in the format "https://{yourDomain}.atlassian.net/wiki/api/v2", where {yourDomain} is your Confluence Cloud subdomain.</param>
		/// <param name="builder">An optional action to configure the <see cref="IHttpClientBuilder" />.</param>
		/// <returns>The <see cref="IServiceCollection" /> so that additional calls can be chained.</returns>
		/// <example>
		/// <code>
		/// services.ConfigureRefitClients(new Uri("https://myDomain.atlassian.net/wiki/api/v2"));
		/// </code>
		/// </example>
		/// <remarks>
		/// This method sets up Refit clients for various Confluence API endpoints. Each client is configured with the provided base URL.
		/// </remarks>
		public static IServiceCollection ConfigureRefitClients(this IServiceCollection services, Uri baseUrl, Action<IHttpClientBuilder>? builder = default)
		{
			var clientBuilderIAttachmentApi = services
				.AddRefitClient<IAttachmentApi>()
				.ConfigureHttpClient(c => c.BaseAddress = baseUrl);
			builder?.Invoke(clientBuilderIAttachmentApi);

			var clientBuilderILabelApi = services
				.AddRefitClient<ILabelApi>()
				.ConfigureHttpClient(c => c.BaseAddress = baseUrl);
			builder?.Invoke(clientBuilderILabelApi);

			var clientBuilderIOperationApi = services
				.AddRefitClient<IOperationApi>()
				.ConfigureHttpClient(c => c.BaseAddress = baseUrl);
			builder?.Invoke(clientBuilderIOperationApi);

			var clientBuilderIContentPropertiesApi = services
				.AddRefitClient<IContentPropertiesApi>()
				.ConfigureHttpClient(c => c.BaseAddress = baseUrl);
			builder?.Invoke(clientBuilderIContentPropertiesApi);

			var clientBuilderIVersionApi = services
				.AddRefitClient<IVersionApi>()
				.ConfigureHttpClient(c => c.BaseAddress = baseUrl);
			builder?.Invoke(clientBuilderIVersionApi);

			var clientBuilderICommentApi = services
				.AddRefitClient<ICommentApi>()
				.ConfigureHttpClient(c => c.BaseAddress = baseUrl);
			builder?.Invoke(clientBuilderICommentApi);

			var clientBuilderIBlogPostApi = services
				.AddRefitClient<IBlogPostApi>()
				.ConfigureHttpClient(c => c.BaseAddress = baseUrl);
			builder?.Invoke(clientBuilderIBlogPostApi);

			var clientBuilderICustomContentApi = services
				.AddRefitClient<ICustomContentApi>()
				.ConfigureHttpClient(c => c.BaseAddress = baseUrl);
			builder?.Invoke(clientBuilderICustomContentApi);

			var clientBuilderILikeApi = services
				.AddRefitClient<ILikeApi>()
				.ConfigureHttpClient(c => c.BaseAddress = baseUrl);
			builder?.Invoke(clientBuilderILikeApi);

			var clientBuilderIContentApi = services
				.AddRefitClient<IContentApi>()
				.ConfigureHttpClient(c => c.BaseAddress = baseUrl);
			builder?.Invoke(clientBuilderIContentApi);

			var clientBuilderIPageApi = services
				.AddRefitClient<IPageApi>()
				.ConfigureHttpClient(c => c.BaseAddress = baseUrl);
			builder?.Invoke(clientBuilderIPageApi);

			var clientBuilderIWhiteboardApi = services
				.AddRefitClient<IWhiteboardApi>()
				.ConfigureHttpClient(c => c.BaseAddress = baseUrl);
			builder?.Invoke(clientBuilderIWhiteboardApi);

			var clientBuilderIAncestorsApi = services
				.AddRefitClient<IAncestorsApi>()
				.ConfigureHttpClient(c => c.BaseAddress = baseUrl);
			builder?.Invoke(clientBuilderIAncestorsApi);

			var clientBuilderIDatabaseApi = services
				.AddRefitClient<IDatabaseApi>()
				.ConfigureHttpClient(c => c.BaseAddress = baseUrl);
			builder?.Invoke(clientBuilderIDatabaseApi);

			var clientBuilderISmartLinkApi = services
				.AddRefitClient<ISmartLinkApi>()
				.ConfigureHttpClient(c => c.BaseAddress = baseUrl);
			builder?.Invoke(clientBuilderISmartLinkApi);

			var clientBuilderISpaceApi = services
				.AddRefitClient<ISpaceApi>()
				.ConfigureHttpClient(c => c.BaseAddress = baseUrl);
			builder?.Invoke(clientBuilderISpaceApi);

			var clientBuilderISpacePropertiesApi = services
				.AddRefitClient<ISpacePropertiesApi>()
				.ConfigureHttpClient(c => c.BaseAddress = baseUrl);
			builder?.Invoke(clientBuilderISpacePropertiesApi);

			var clientBuilderISpacePermissionsApi = services
				.AddRefitClient<ISpacePermissionsApi>()
				.ConfigureHttpClient(c => c.BaseAddress = baseUrl);
			builder?.Invoke(clientBuilderISpacePermissionsApi);

			var clientBuilderITaskApi = services
				.AddRefitClient<ITaskApi>()
				.ConfigureHttpClient(c => c.BaseAddress = baseUrl);
			builder?.Invoke(clientBuilderITaskApi);

			var clientBuilderIChildrenApi = services
				.AddRefitClient<IChildrenApi>()
				.ConfigureHttpClient(c => c.BaseAddress = baseUrl);
			builder?.Invoke(clientBuilderIChildrenApi);

			var clientBuilderIUserApi = services
				.AddRefitClient<IUserApi>()
				.ConfigureHttpClient(c => c.BaseAddress = baseUrl);
			builder?.Invoke(clientBuilderIUserApi);

			var clientBuilderIDataPoliciesApi = services
				.AddRefitClient<IDataPoliciesApi>()
				.ConfigureHttpClient(c => c.BaseAddress = baseUrl);
			builder?.Invoke(clientBuilderIDataPoliciesApi);

			var clientBuilderIClassificationLevelApi = services
				.AddRefitClient<IClassificationLevelApi>()
				.ConfigureHttpClient(c => c.BaseAddress = baseUrl);
			builder?.Invoke(clientBuilderIClassificationLevelApi);

			return services;
		}
	}
}