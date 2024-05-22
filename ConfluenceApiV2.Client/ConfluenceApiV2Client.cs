using Refit;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading;
using System.Threading.Tasks;

#nullable enable
namespace ConfluenceApiV2.Client
{
    /// <summary>Get attachments</summary>
    [System.CodeDom.Compiler.GeneratedCode("Refitter", "1.0.0.0")]
    public partial interface IAttachmentApi
    {
        /// <summary>Get attachments</summary>
        /// <remarks>
        /// Returns all attachments. The number of results is limited by the `limit` parameter and additional results (if available)
        /// will be available through the `next` URL present in the `Link` response header.
        /// 
        /// **[Permissions](https://confluence.atlassian.com/x/_AozKw) required**:
        /// Permission to view the container of the attachment.
        /// </remarks>
        /// <param name="sort">Used to sort the result by a particular field.</param>
        /// <param name="cursor">Used for pagination, this opaque cursor will be returned in the `next` URL in the `Link` response header. Use the relative URL in the `Link` header to retrieve the `next` set of results.</param>
        /// <param name="status">Filter the results to attachments based on their status. By default, `current` and `archived` are used.</param>
        /// <param name="mediaType">Filters on the mediaType of attachments. Only one may be specified.</param>
        /// <param name="filename">Filters on the file-name of attachments. Only one may be specified.</param>
        /// <param name="limit">Maximum number of attachments per result to return. If more results exist, use the `Link` header to retrieve a relative URL that will return the next set of results.</param>
        /// <returns>
        /// A <see cref="Task"/> representing the <see cref="IApiResponse"/> instance containing the result:
        /// <list type="table">
        /// <listheader>
        /// <term>Status</term>
        /// <description>Description</description>
        /// </listheader>
        /// <item>
        /// <term>200</term>
        /// <description>Returned if the requested attachments are returned.</description>
        /// </item>
        /// <item>
        /// <term>400</term>
        /// <description>Returned if an invalid request is provided.</description>
        /// </item>
        /// <item>
        /// <term>401</term>
        /// <description>Returned if the authentication credentials are incorrect or missing\nfrom the request.</description>
        /// </item>
        /// </list>
        /// </returns>
        [Headers("Accept: application/json")]
        [Get("/attachments")]
        Task<IApiResponse<Response>> GetAttachmentsAsync([Query] AttachmentSortOrder? sort = default, [Query] string? cursor = default, [Query(CollectionFormat.Multi)] IEnumerable<Anonymous>? status = default, [Query] string? mediaType = default, [Query] string? filename = default, [Query] int? limit = default, CancellationToken cancellationToken = default);

        /// <summary>Get attachment by id</summary>
        /// <remarks>
        /// Returns a specific attachment.
        /// 
        /// **[Permissions](https://confluence.atlassian.com/x/_AozKw) required**:
        /// Permission to view the attachment's container.
        /// </remarks>
        /// <param name="id">The ID of the attachment to be returned. If you don't know the attachment's ID, use Get attachments for page/blogpost/custom content.</param>
        /// <param name="version">Allows you to retrieve a previously published version. Specify the previous version's number to retrieve its details.</param>
        /// <param name="include_labels">
        /// Includes labels associated with this attachment in the response.
        /// The number of results will be limited to 50 and sorted in the default sort order.
        /// A `meta` and `_links` property will be present to indicate if more results are available and a link to retrieve the rest of the results.
        /// </param>
        /// <param name="include_properties">
        /// Includes content properties associated with this attachment in the response.
        /// The number of results will be limited to 50 and sorted in the default sort order.
        /// A `meta` and `_links` property will be present to indicate if more results are available and a link to retrieve the rest of the results.
        /// </param>
        /// <param name="include_operations">
        /// Includes operations associated with this attachment in the response.
        /// The number of results will be limited to 50 and sorted in the default sort order.
        /// A `meta` and `_links` property will be present to indicate if more results are available and a link to retrieve the rest of the results.
        /// </param>
        /// <param name="include_versions">
        /// Includes versions associated with this attachment in the response.
        /// The number of results will be limited to 50 and sorted in the default sort order.
        /// A `meta` and `_links` property will be present to indicate if more results are available and a link to retrieve the rest of the results.
        /// </param>
        /// <param name="include_version">
        /// Includes the current version associated with this attachment in the response.
        /// By default this is included and can be omitted by setting the value to `false`.
        /// </param>
        /// <returns>
        /// A <see cref="Task"/> representing the <see cref="IApiResponse"/> instance containing the result:
        /// <list type="table">
        /// <listheader>
        /// <term>Status</term>
        /// <description>Description</description>
        /// </listheader>
        /// <item>
        /// <term>200</term>
        /// <description>Returned if the requested attachment is returned.</description>
        /// </item>
        /// <item>
        /// <term>400</term>
        /// <description>Returned if an invalid request is provided.</description>
        /// </item>
        /// <item>
        /// <term>401</term>
        /// <description>Returned if the authentication credentials are incorrect or missing\nfrom the request.</description>
        /// </item>
        /// <item>
        /// <term>404</term>
        /// <description>Returned if the calling user does not have permission to view the\nrequested attachment or the attachment was not found.</description>
        /// </item>
        /// </list>
        /// </returns>
        [Headers("Accept: application/json")]
        [Get("/attachments/{id}")]
        Task<IApiResponse<Response2>> GetAttachmentByIdAsync(string id, [Query] int? version = default, [Query, AliasAs("include-labels")] bool? include_labels = default, [Query, AliasAs("include-properties")] bool? include_properties = default, [Query, AliasAs("include-operations")] bool? include_operations = default, [Query, AliasAs("include-versions")] bool? include_versions = default, [Query, AliasAs("include-version")] bool? include_version = default, CancellationToken cancellationToken = default);

        /// <summary>Delete attachment</summary>
        /// <remarks>
        /// Delete an attachment by id.
        /// 
        /// Deleting an attachment moves the attachment to the trash, where it can be restored later. To permanently delete an attachment (or "purge" it),
        /// the endpoint must be called on a **trashed** attachment with the following param `purge=true`.
        /// 
        /// **[Permissions](https://confluence.atlassian.com/x/_AozKw) required**:
        /// Permission to view the container of the attachment.
        /// Permission to delete attachments in the space.
        /// Permission to administer the space (if attempting to purge).
        /// </remarks>
        /// <param name="id">The ID of the attachment to be deleted.</param>
        /// <param name="purge">If attempting to purge the attachment.</param>
        /// <returns>
        /// A <see cref="Task"/> representing the <see cref="IApiResponse"/> instance containing the result:
        /// <list type="table">
        /// <listheader>
        /// <term>Status</term>
        /// <description>Description</description>
        /// </listheader>
        /// <item>
        /// <term>204</term>
        /// <description>Returned if the attachment was successfully deleted.</description>
        /// </item>
        /// <item>
        /// <term>400</term>
        /// <description>Returned if an invalid request is provided.</description>
        /// </item>
        /// <item>
        /// <term>401</term>
        /// <description>Returned if the authentication credentials are incorrect or missing\nfrom the request.</description>
        /// </item>
        /// <item>
        /// <term>404</term>
        /// <description>Returned if:\n- The provided attachment does not exist\n- The user does not have permissions to view the container of the attachment\n- The user does not have the needed permissions to delete an attachment in the space</description>
        /// </item>
        /// </list>
        /// </returns>
        [Delete("/attachments/{id}")]
        Task<IApiResponse> DeleteAttachmentAsync(long id, [Query] bool? purge = default, CancellationToken cancellationToken = default);

        /// <summary>Get attachments for blog post</summary>
        /// <remarks>
        /// Returns the attachments of specific blog post. The number of results is limited by the `limit` parameter and additional results (if available)
        /// will be available through the `next` URL present in the `Link` response header.
        /// 
        /// **[Permissions](https://confluence.atlassian.com/x/_AozKw) required**:
        /// Permission to view the content of the blog post and its corresponding space.
        /// </remarks>
        /// <param name="id">The ID of the blog post for which attachments should be returned.</param>
        /// <param name="sort">Used to sort the result by a particular field.</param>
        /// <param name="cursor">Used for pagination, this opaque cursor will be returned in the `next` URL in the `Link` response header. Use the relative URL in the `Link` header to retrieve the `next` set of results.</param>
        /// <param name="status">Filter the results to attachments based on their status. By default, `current` and `archived` are used.</param>
        /// <param name="mediaType">Filters on the mediaType of attachments. Only one may be specified.</param>
        /// <param name="filename">Filters on the file-name of attachments. Only one may be specified.</param>
        /// <param name="limit">Maximum number of attachments per result to return. If more results exist, use the `Link` header to retrieve a relative URL that will return the next set of results.</param>
        /// <returns>
        /// A <see cref="Task"/> representing the <see cref="IApiResponse"/> instance containing the result:
        /// <list type="table">
        /// <listheader>
        /// <term>Status</term>
        /// <description>Description</description>
        /// </listheader>
        /// <item>
        /// <term>200</term>
        /// <description>Returned if the requested attachments are returned.</description>
        /// </item>
        /// <item>
        /// <term>400</term>
        /// <description>Returned if an invalid request is provided.</description>
        /// </item>
        /// <item>
        /// <term>401</term>
        /// <description>Returned if the authentication credentials are incorrect or missing\nfrom the request.</description>
        /// </item>
        /// <item>
        /// <term>404</term>
        /// <description>Returned if the calling user does not have permission to view the\nrequested blog post or the blog post was not found.</description>
        /// </item>
        /// </list>
        /// </returns>
        [Headers("Accept: application/json")]
        [Get("/blogposts/{id}/attachments")]
        Task<IApiResponse<Response11>> GetBlogpostAttachmentsAsync(long id, [Query] AttachmentSortOrder? sort = default, [Query] string? cursor = default, [Query(CollectionFormat.Multi)] IEnumerable<Anonymous3>? status = default, [Query] string? mediaType = default, [Query] string? filename = default, [Query] int? limit = default, CancellationToken cancellationToken = default);

        /// <summary>Get attachments for custom content</summary>
        /// <remarks>
        /// Returns the attachments of specific custom content. The number of results is limited by the `limit` parameter and additional results (if available)
        /// will be available through the `next` URL present in the `Link` response header.
        /// 
        /// **[Permissions](https://confluence.atlassian.com/x/_AozKw) required**:
        /// Permission to view the content of the custom content and its corresponding space.
        /// </remarks>
        /// <param name="id">The ID of the custom content for which attachments should be returned.</param>
        /// <param name="sort">Used to sort the result by a particular field.</param>
        /// <param name="cursor">Used for pagination, this opaque cursor will be returned in the `next` URL in the `Link` response header. Use the relative URL in the `Link` header to retrieve the `next` set of results.</param>
        /// <param name="status">Filter the results to attachments based on their status. By default, `current` and `archived` are used.</param>
        /// <param name="mediaType">Filters on the mediaType of attachments. Only one may be specified.</param>
        /// <param name="filename">Filters on the file-name of attachments. Only one may be specified.</param>
        /// <param name="limit">Maximum number of attachments per result to return. If more results exist, use the `Link` header to retrieve a relative URL that will return the next set of results.</param>
        /// <returns>
        /// A <see cref="Task"/> representing the <see cref="IApiResponse"/> instance containing the result:
        /// <list type="table">
        /// <listheader>
        /// <term>Status</term>
        /// <description>Description</description>
        /// </listheader>
        /// <item>
        /// <term>200</term>
        /// <description>Returned if the requested attachments are returned.</description>
        /// </item>
        /// <item>
        /// <term>400</term>
        /// <description>Returned if an invalid request is provided.</description>
        /// </item>
        /// <item>
        /// <term>401</term>
        /// <description>Returned if the authentication credentials are incorrect or missing\nfrom the request.</description>
        /// </item>
        /// <item>
        /// <term>404</term>
        /// <description>Returned if the calling user does not have permission to view the\nrequested custom content or the custom content was not found.</description>
        /// </item>
        /// </list>
        /// </returns>
        [Headers("Accept: application/json")]
        [Get("/custom-content/{id}/attachments")]
        Task<IApiResponse<Response21>> GetCustomContentAttachmentsAsync(long id, [Query] AttachmentSortOrder? sort = default, [Query] string? cursor = default, [Query(CollectionFormat.Multi)] IEnumerable<Anonymous4>? status = default, [Query] string? mediaType = default, [Query] string? filename = default, [Query] int? limit = default, CancellationToken cancellationToken = default);

        /// <summary>Get attachments for label</summary>
        /// <remarks>
        /// Returns the attachments of specified label. The number of results is limited by the `limit` parameter and additional results (if available)
        /// will be available through the `next` URL present in the `Link` response header.
        /// 
        /// **[Permissions](https://confluence.atlassian.com/x/_AozKw) required**:
        /// Permission to view the attachment and its corresponding space.
        /// </remarks>
        /// <param name="id">The ID of the label for which attachments should be returned.</param>
        /// <param name="sort">Used to sort the result by a particular field.</param>
        /// <param name="cursor">Used for pagination, this opaque cursor will be returned in the `next` URL in the `Link` response header. Use the relative URL in the `Link` header to retrieve the `next` set of results.</param>
        /// <param name="limit">Maximum number of pages per result to return. If more results exist, use the `Link` header to retrieve a relative URL that will return the next set of results.</param>
        /// <returns>
        /// A <see cref="Task"/> representing the <see cref="IApiResponse"/> instance containing the result:
        /// <list type="table">
        /// <listheader>
        /// <term>Status</term>
        /// <description>Description</description>
        /// </listheader>
        /// <item>
        /// <term>200</term>
        /// <description>Returned if the requested attachments for specified label were successfully fetched.</description>
        /// </item>
        /// <item>
        /// <term>400</term>
        /// <description>Returned if an invalid request is provided.</description>
        /// </item>
        /// <item>
        /// <term>401</term>
        /// <description>Returned if the authentication credentials are incorrect or missing\nfrom the request.</description>
        /// </item>
        /// <item>
        /// <term>404</term>
        /// <description>Returned if the calling user does not have permission to view the\nrequested label or label was not found.</description>
        /// </item>
        /// </list>
        /// </returns>
        [Headers("Accept: application/json")]
        [Get("/labels/{id}/attachments")]
        Task<IApiResponse<Response26>> GetLabelAttachmentsAsync(long id, [Query] AttachmentSortOrder? sort = default, [Query] string? cursor = default, [Query] int? limit = default, CancellationToken cancellationToken = default);

        /// <summary>Get attachments for page</summary>
        /// <remarks>
        /// Returns the attachments of specific page. The number of results is limited by the `limit` parameter and additional results (if available)
        /// will be available through the `next` URL present in the `Link` response header.
        /// 
        /// **[Permissions](https://confluence.atlassian.com/x/_AozKw) required**:
        /// Permission to view the content of the page and its corresponding space.
        /// </remarks>
        /// <param name="id">The ID of the page for which attachments should be returned.</param>
        /// <param name="sort">Used to sort the result by a particular field.</param>
        /// <param name="cursor">Used for pagination, this opaque cursor will be returned in the `next` URL in the `Link` response header. Use the relative URL in the `Link` header to retrieve the `next` set of results.</param>
        /// <param name="status">Filter the results to attachments based on their status. By default, `current` and `archived` are used.</param>
        /// <param name="mediaType">Filters on the mediaType of attachments. Only one may be specified.</param>
        /// <param name="filename">Filters on the file-name of attachments. Only one may be specified.</param>
        /// <param name="limit">Maximum number of attachments per result to return. If more results exist, use the `Link` header to retrieve a relative URL that will return the next set of results.</param>
        /// <returns>
        /// A <see cref="Task"/> representing the <see cref="IApiResponse"/> instance containing the result:
        /// <list type="table">
        /// <listheader>
        /// <term>Status</term>
        /// <description>Description</description>
        /// </listheader>
        /// <item>
        /// <term>200</term>
        /// <description>Returned if the requested attachments are returned.</description>
        /// </item>
        /// <item>
        /// <term>400</term>
        /// <description>Returned if an invalid request is provided.</description>
        /// </item>
        /// <item>
        /// <term>401</term>
        /// <description>Returned if the authentication credentials are incorrect or missing\nfrom the request.</description>
        /// </item>
        /// <item>
        /// <term>404</term>
        /// <description>Returned if the calling user does not have permission to view the\nrequested page or the page was not found.</description>
        /// </item>
        /// </list>
        /// </returns>
        [Headers("Accept: application/json")]
        [Get("/pages/{id}/attachments")]
        Task<IApiResponse<Response33>> GetPageAttachmentsAsync(long id, [Query] AttachmentSortOrder? sort = default, [Query] string? cursor = default, [Query(CollectionFormat.Multi)] IEnumerable<Anonymous6>? status = default, [Query] string? mediaType = default, [Query] string? filename = default, [Query] int? limit = default, CancellationToken cancellationToken = default);
    }

    /// <summary>Get labels for attachment</summary>
    [System.CodeDom.Compiler.GeneratedCode("Refitter", "1.0.0.0")]
    public partial interface ILabelApi
    {
        /// <summary>Get labels for attachment</summary>
        /// <remarks>
        /// Returns the labels of specific attachment. The number of results is limited by the `limit` parameter and additional results (if available)
        /// will be available through the `next` URL present in the `Link` response header.
        /// 
        /// **[Permissions](https://confluence.atlassian.com/x/_AozKw) required**:
        /// Permission to view the parent content of the attachment and its corresponding space.
        /// </remarks>
        /// <param name="id">The ID of the attachment for which labels should be returned.</param>
        /// <param name="prefix">Filter the results to labels based on their prefix.</param>
        /// <param name="sort">Used to sort the result by a particular field.</param>
        /// <param name="cursor">Used for pagination, this opaque cursor will be returned in the `next` URL in the `Link` response header. Use the relative URL in the `Link` header to retrieve the `next` set of results.</param>
        /// <param name="limit">Maximum number of labels per result to return. If more results exist, use the `Link` header to retrieve a relative URL that will return the next set of results.</param>
        /// <returns>
        /// A <see cref="Task"/> representing the <see cref="IApiResponse"/> instance containing the result:
        /// <list type="table">
        /// <listheader>
        /// <term>Status</term>
        /// <description>Description</description>
        /// </listheader>
        /// <item>
        /// <term>200</term>
        /// <description>Returned if the requested labels are returned.</description>
        /// </item>
        /// <item>
        /// <term>400</term>
        /// <description>Returned if an invalid request is provided.</description>
        /// </item>
        /// <item>
        /// <term>401</term>
        /// <description>Returned if the authentication credentials are incorrect or missing\nfrom the request.</description>
        /// </item>
        /// <item>
        /// <term>404</term>
        /// <description>Returned if the calling user does not have permission to view the\nparent content of the requested attachment or the attachment was not found.</description>
        /// </item>
        /// </list>
        /// </returns>
        [Headers("Accept: application/json")]
        [Get("/attachments/{id}/labels")]
        Task<IApiResponse<Response3>> GetAttachmentLabelsAsync(long id, [Query] Prefix? prefix = default, [Query] string? sort = default, [Query] string? cursor = default, [Query] int? limit = default, CancellationToken cancellationToken = default);

        /// <summary>Get labels for blog post</summary>
        /// <remarks>
        /// Returns the labels of specific blog post. The number of results is limited by the `limit` parameter and additional results (if available)
        /// will be available through the `next` URL present in the `Link` response header.
        /// 
        /// **[Permissions](https://confluence.atlassian.com/x/_AozKw) required**:
        /// Permission to view the content of the blog post and its corresponding space.
        /// </remarks>
        /// <param name="id">The ID of the blog post for which labels should be returned.</param>
        /// <param name="prefix">Filter the results to labels based on their prefix.</param>
        /// <param name="sort">Used to sort the result by a particular field.</param>
        /// <param name="cursor">Used for pagination, this opaque cursor will be returned in the `next` URL in the `Link` response header. Use the relative URL in the `Link` header to retrieve the `next` set of results.</param>
        /// <param name="limit">Maximum number of labels per result to return. If more results exist, use the `Link` header to retrieve a relative URL that will return the next set of results.</param>
        /// <returns>
        /// A <see cref="Task"/> representing the <see cref="IApiResponse"/> instance containing the result:
        /// <list type="table">
        /// <listheader>
        /// <term>Status</term>
        /// <description>Description</description>
        /// </listheader>
        /// <item>
        /// <term>200</term>
        /// <description>Returned if the requested labels are returned.</description>
        /// </item>
        /// <item>
        /// <term>400</term>
        /// <description>Returned if an invalid request is provided.</description>
        /// </item>
        /// <item>
        /// <term>401</term>
        /// <description>Returned if the authentication credentials are incorrect or missing\nfrom the request.</description>
        /// </item>
        /// <item>
        /// <term>404</term>
        /// <description>Returned if the calling user does not have permission to view the\nrequested blog post or the blog post was not found.</description>
        /// </item>
        /// </list>
        /// </returns>
        [Headers("Accept: application/json")]
        [Get("/blogposts/{id}/labels")]
        Task<IApiResponse<Response13>> GetBlogPostLabelsAsync(long id, [Query] Prefix2? prefix = default, [Query] string? sort = default, [Query] string? cursor = default, [Query] int? limit = default, CancellationToken cancellationToken = default);

        /// <summary>Get labels for custom content</summary>
        /// <remarks>
        /// Returns the labels for a specific piece of custom content. The number of results is limited by the `limit` parameter and additional results (if available)
        /// will be available through the `next` URL present in the `Link` response header.
        /// 
        /// **[Permissions](https://confluence.atlassian.com/x/_AozKw) required**:
        /// Permission to view the custom content and its corresponding space.
        /// </remarks>
        /// <param name="id">The ID of the custom content for which labels should be returned.</param>
        /// <param name="prefix">Filter the results to labels based on their prefix.</param>
        /// <param name="sort">Used to sort the result by a particular field.</param>
        /// <param name="cursor">Used for pagination, this opaque cursor will be returned in the `next` URL in the `Link` response header. Use the relative URL in the `Link` header to retrieve the `next` set of results.</param>
        /// <param name="limit">Maximum number of labels per result to return. If more results exist, use the `Link` header to retrieve a relative URL that will return the next set of results.</param>
        /// <returns>
        /// A <see cref="Task"/> representing the <see cref="IApiResponse"/> instance containing the result:
        /// <list type="table">
        /// <listheader>
        /// <term>Status</term>
        /// <description>Description</description>
        /// </listheader>
        /// <item>
        /// <term>200</term>
        /// <description>Returned if the requested labels are returned.</description>
        /// </item>
        /// <item>
        /// <term>400</term>
        /// <description>Returned if an invalid request is provided.</description>
        /// </item>
        /// <item>
        /// <term>401</term>
        /// <description>Returned if the authentication credentials are incorrect or missing\nfrom the request.</description>
        /// </item>
        /// <item>
        /// <term>404</term>
        /// <description>Returned if the calling user does not have permission to view the\nrequested page or the page was not found.</description>
        /// </item>
        /// </list>
        /// </returns>
        [Headers("Accept: application/json")]
        [Get("/custom-content/{id}/labels")]
        Task<IApiResponse<Response23>> GetCustomContentLabelsAsync(long id, [Query] Prefix3? prefix = default, [Query] string? sort = default, [Query] string? cursor = default, [Query] int? limit = default, CancellationToken cancellationToken = default);

        /// <summary>Get labels</summary>
        /// <remarks>
        /// Returns all labels. The number of results is limited by the `limit` parameter and additional results (if available)
        /// will be available through the `next` URL present in the `Link` response header.
        /// 
        /// **[Permissions](https://confluence.atlassian.com/x/_AozKw) required**:
        /// Permission to access the Confluence site ('Can use' global permission).
        /// Only labels that the user has permission to view will be returned.
        /// </remarks>
        /// <param name="label_id">Filters on label ID. Multiple IDs can be specified as a comma-separated list.</param>
        /// <param name="prefix">Filters on label prefix. Multiple IDs can be specified as a comma-separated list.</param>
        /// <param name="cursor">Used for pagination, this opaque cursor will be returned in the `next` URL in the `Link` response header. Use the relative URL in the `Link` header to retrieve the `next` set of results.</param>
        /// <param name="sort">Used to sort the result by a particular field.</param>
        /// <param name="limit">Maximum number of labels per result to return. If more results exist, use the `Link` header to retrieve a relative URL that will return the next set of results.</param>
        /// <returns>
        /// A <see cref="Task"/> representing the <see cref="IApiResponse"/> instance containing the result:
        /// <list type="table">
        /// <listheader>
        /// <term>Status</term>
        /// <description>Description</description>
        /// </listheader>
        /// <item>
        /// <term>200</term>
        /// <description>Returned if the requested labels are returned.</description>
        /// </item>
        /// <item>
        /// <term>400</term>
        /// <description>Returned if an invalid request is provided.</description>
        /// </item>
        /// <item>
        /// <term>401</term>
        /// <description>Returned if the authentication credentials are incorrect or missing\nfrom the request.</description>
        /// </item>
        /// </list>
        /// </returns>
        [Headers("Accept: application/json")]
        [Get("/labels")]
        Task<IApiResponse<Response25>> GetLabelsAsync([Query(CollectionFormat.Multi), AliasAs("label-id")] IEnumerable<long>? label_id = default, [Query(CollectionFormat.Multi)] IEnumerable<string>? prefix = default, [Query] string? cursor = default, [Query] string? sort = default, [Query] int? limit = default, CancellationToken cancellationToken = default);

        /// <summary>Get labels for page</summary>
        /// <remarks>
        /// Returns the labels of specific page. The number of results is limited by the `limit` parameter and additional results (if available)
        /// will be available through the `next` URL present in the `Link` response header.
        /// 
        /// **[Permissions](https://confluence.atlassian.com/x/_AozKw) required**:
        /// Permission to view the content of the page and its corresponding space.
        /// </remarks>
        /// <param name="id">The ID of the page for which labels should be returned.</param>
        /// <param name="prefix">Filter the results to labels based on their prefix.</param>
        /// <param name="sort">Used to sort the result by a particular field.</param>
        /// <param name="cursor">Used for pagination, this opaque cursor will be returned in the `next` URL in the `Link` response header. Use the relative URL in the `Link` header to retrieve the `next` set of results.</param>
        /// <param name="limit">Maximum number of labels per result to return. If more results exist, use the `Link` header to retrieve a relative URL that will return the next set of results.</param>
        /// <returns>
        /// A <see cref="Task"/> representing the <see cref="IApiResponse"/> instance containing the result:
        /// <list type="table">
        /// <listheader>
        /// <term>Status</term>
        /// <description>Description</description>
        /// </listheader>
        /// <item>
        /// <term>200</term>
        /// <description>Returned if the requested labels are returned.</description>
        /// </item>
        /// <item>
        /// <term>400</term>
        /// <description>Returned if an invalid request is provided.</description>
        /// </item>
        /// <item>
        /// <term>401</term>
        /// <description>Returned if the authentication credentials are incorrect or missing\nfrom the request.</description>
        /// </item>
        /// <item>
        /// <term>404</term>
        /// <description>Returned if the calling user does not have permission to view the\nrequested page or the page was not found.</description>
        /// </item>
        /// </list>
        /// </returns>
        [Headers("Accept: application/json")]
        [Get("/pages/{id}/labels")]
        Task<IApiResponse<Response35>> GetPageLabelsAsync(long id, [Query] Prefix4? prefix = default, [Query] string? sort = default, [Query] string? cursor = default, [Query] int? limit = default, CancellationToken cancellationToken = default);

        /// <summary>Get labels for space</summary>
        /// <remarks>
        /// Returns the labels of specific space. The number of results is limited by the `limit` parameter and additional results (if available)
        /// will be available through the `next` URL present in the `Link` response header.
        /// 
        /// **[Permissions](https://confluence.atlassian.com/x/_AozKw) required**:
        /// Permission to view the space.
        /// </remarks>
        /// <param name="id">The ID of the space for which labels should be returned.</param>
        /// <param name="prefix">Filter the results to labels based on their prefix.</param>
        /// <param name="sort">Used to sort the result by a particular field.</param>
        /// <param name="cursor">Used for pagination, this opaque cursor will be returned in the `next` URL in the `Link` response header. Use the relative URL in the `Link` header to retrieve the `next` set of results.</param>
        /// <param name="limit">Maximum number of labels per result to return. If more results exist, use the `Link` header to retrieve a relative URL that will return the next set of results.</param>
        /// <returns>
        /// A <see cref="Task"/> representing the <see cref="IApiResponse"/> instance containing the result:
        /// <list type="table">
        /// <listheader>
        /// <term>Status</term>
        /// <description>Description</description>
        /// </listheader>
        /// <item>
        /// <term>200</term>
        /// <description>Returned if the requested labels are returned.</description>
        /// </item>
        /// <item>
        /// <term>400</term>
        /// <description>Returned if an invalid request is provided.</description>
        /// </item>
        /// <item>
        /// <term>401</term>
        /// <description>Returned if the authentication credentials are incorrect or missing\nfrom the request.</description>
        /// </item>
        /// <item>
        /// <term>404</term>
        /// <description>Returned if the calling user does not have permission to view the\nrequested space or the space was not found.</description>
        /// </item>
        /// </list>
        /// </returns>
        [Headers("Accept: application/json")]
        [Get("/spaces/{id}/labels")]
        Task<IApiResponse<Response55>> GetSpaceLabelsAsync(long id, [Query] Prefix5? prefix = default, [Query] string? sort = default, [Query] string? cursor = default, [Query] int? limit = default, CancellationToken cancellationToken = default);

        /// <summary>Get labels for space content</summary>
        /// <remarks>
        /// Returns the labels of space content (pages, blogposts etc). The number of results is limited by the `limit` parameter and additional results (if available)
        /// will be available through the `next` URL present in the `Link` response header.
        /// 
        /// **[Permissions](https://confluence.atlassian.com/x/_AozKw) required**:
        /// Permission to view the space.
        /// </remarks>
        /// <param name="id">The ID of the space for which labels should be returned.</param>
        /// <param name="prefix">Filter the results to labels based on their prefix.</param>
        /// <param name="sort">Used to sort the result by a particular field.</param>
        /// <param name="cursor">Used for pagination, this opaque cursor will be returned in the `next` URL in the `Link` response header. Use the relative URL in the `Link` header to retrieve the `next` set of results.</param>
        /// <param name="limit">Maximum number of labels per result to return. If more results exist, use the `Link` header to retrieve a relative URL that will return the next set of results.</param>
        /// <returns>
        /// A <see cref="Task"/> representing the <see cref="IApiResponse"/> instance containing the result:
        /// <list type="table">
        /// <listheader>
        /// <term>Status</term>
        /// <description>Description</description>
        /// </listheader>
        /// <item>
        /// <term>200</term>
        /// <description>Returned if the requested labels are returned.</description>
        /// </item>
        /// <item>
        /// <term>400</term>
        /// <description>Returned if an invalid request is provided.</description>
        /// </item>
        /// <item>
        /// <term>401</term>
        /// <description>Returned if the authentication credentials are incorrect or missing\nfrom the request.</description>
        /// </item>
        /// <item>
        /// <term>404</term>
        /// <description>Returned if the calling user does not have permission to view the\nrequested space or the space was not found.</description>
        /// </item>
        /// </list>
        /// </returns>
        [Headers("Accept: application/json")]
        [Get("/spaces/{id}/content/labels")]
        Task<IApiResponse<Response56>> GetSpaceContentLabelsAsync(long id, [Query] Prefix6? prefix = default, [Query] string? sort = default, [Query] string? cursor = default, [Query] int? limit = default, CancellationToken cancellationToken = default);
    }

    /// <summary>Get permitted operations for attachment</summary>
    [System.CodeDom.Compiler.GeneratedCode("Refitter", "1.0.0.0")]
    public partial interface IOperationApi
    {
        /// <summary>Get permitted operations for attachment</summary>
        /// <remarks>
        /// Returns the permitted operations on specific attachment.
        /// 
        /// **[Permissions](https://confluence.atlassian.com/x/_AozKw) required**:
        /// Permission to view the parent content of the attachment and its corresponding space.
        /// </remarks>
        /// <param name="id">The ID of the attachment for which operations should be returned.</param>
        /// <returns>
        /// A <see cref="Task"/> representing the <see cref="IApiResponse"/> instance containing the result:
        /// <list type="table">
        /// <listheader>
        /// <term>Status</term>
        /// <description>Description</description>
        /// </listheader>
        /// <item>
        /// <term>200</term>
        /// <description>Returned if the requested operations are returned.</description>
        /// </item>
        /// <item>
        /// <term>400</term>
        /// <description>Returned if an invalid request is provided.</description>
        /// </item>
        /// <item>
        /// <term>401</term>
        /// <description>Returned if the authentication credentials are incorrect or missing\nfrom the request.</description>
        /// </item>
        /// <item>
        /// <term>404</term>
        /// <description>Returned if the calling user does not have permission to view the\nparent content of the requested attachment or the attachment was not found.</description>
        /// </item>
        /// </list>
        /// </returns>
        [Headers("Accept: application/json")]
        [Get("/attachments/{id}/operations")]
        Task<IApiResponse<PermittedOperationsResponse>> GetAttachmentOperationsAsync(string id, CancellationToken cancellationToken = default);

        /// <summary>Get permitted operations for blog post</summary>
        /// <remarks>
        /// Returns the permitted operations on specific blog post.
        /// 
        /// **[Permissions](https://confluence.atlassian.com/x/_AozKw) required**:
        /// Permission to view the parent content of the blog post and its corresponding space.
        /// </remarks>
        /// <param name="id">The ID of the blog post for which operations should be returned.</param>
        /// <returns>
        /// A <see cref="Task"/> representing the <see cref="IApiResponse"/> instance containing the result:
        /// <list type="table">
        /// <listheader>
        /// <term>Status</term>
        /// <description>Description</description>
        /// </listheader>
        /// <item>
        /// <term>200</term>
        /// <description>Returned if the requested operations are returned.</description>
        /// </item>
        /// <item>
        /// <term>400</term>
        /// <description>Returned if an invalid request is provided.</description>
        /// </item>
        /// <item>
        /// <term>401</term>
        /// <description>Returned if the authentication credentials are incorrect or missing\nfrom the request.</description>
        /// </item>
        /// <item>
        /// <term>404</term>
        /// <description>Returned if the calling user does not have permission to view the\nparent content of the requested blog post or the blog post was not found.</description>
        /// </item>
        /// </list>
        /// </returns>
        [Headers("Accept: application/json")]
        [Get("/blogposts/{id}/operations")]
        Task<IApiResponse<PermittedOperationsResponse>> GetBlogPostOperationsAsync(long id, CancellationToken cancellationToken = default);

        /// <summary>Get permitted operations for custom content</summary>
        /// <remarks>
        /// Returns the permitted operations on specific custom content.
        /// 
        /// **[Permissions](https://confluence.atlassian.com/x/_AozKw) required**:
        /// Permission to view the parent content of the custom content and its corresponding space.
        /// </remarks>
        /// <param name="id">The ID of the custom content for which operations should be returned.</param>
        /// <returns>
        /// A <see cref="Task"/> representing the <see cref="IApiResponse"/> instance containing the result:
        /// <list type="table">
        /// <listheader>
        /// <term>Status</term>
        /// <description>Description</description>
        /// </listheader>
        /// <item>
        /// <term>200</term>
        /// <description>Returned if the requested operations are returned.</description>
        /// </item>
        /// <item>
        /// <term>400</term>
        /// <description>Returned if an invalid request is provided.</description>
        /// </item>
        /// <item>
        /// <term>401</term>
        /// <description>Returned if the authentication credentials are incorrect or missing\nfrom the request.</description>
        /// </item>
        /// <item>
        /// <term>404</term>
        /// <description>Returned if the calling user does not have permission to view the\nparent content of the requested custom content or the custom content was not found.</description>
        /// </item>
        /// </list>
        /// </returns>
        [Headers("Accept: application/json")]
        [Get("/custom-content/{id}/operations")]
        Task<IApiResponse<PermittedOperationsResponse>> GetCustomContentOperationsAsync(long id, CancellationToken cancellationToken = default);

        /// <summary>Get permitted operations for page</summary>
        /// <remarks>
        /// Returns the permitted operations on specific page.
        /// 
        /// **[Permissions](https://confluence.atlassian.com/x/_AozKw) required**:
        /// Permission to view the parent content of the page and its corresponding space.
        /// </remarks>
        /// <param name="id">The ID of the page for which operations should be returned.</param>
        /// <returns>
        /// A <see cref="Task"/> representing the <see cref="IApiResponse"/> instance containing the result:
        /// <list type="table">
        /// <listheader>
        /// <term>Status</term>
        /// <description>Description</description>
        /// </listheader>
        /// <item>
        /// <term>200</term>
        /// <description>Returned if the requested operations are returned.</description>
        /// </item>
        /// <item>
        /// <term>400</term>
        /// <description>Returned if an invalid request is provided.</description>
        /// </item>
        /// <item>
        /// <term>401</term>
        /// <description>Returned if the authentication credentials are incorrect or missing\nfrom the request.</description>
        /// </item>
        /// <item>
        /// <term>404</term>
        /// <description>Returned if the calling user does not have permission to view the\nparent content of the requested page or the page was not found.</description>
        /// </item>
        /// </list>
        /// </returns>
        [Headers("Accept: application/json")]
        [Get("/pages/{id}/operations")]
        Task<IApiResponse<PermittedOperationsResponse>> GetPageOperationsAsync(long id, CancellationToken cancellationToken = default);

        /// <summary>Get permitted operations for a whiteboard</summary>
        /// <remarks>
        /// Returns the permitted operations on specific whiteboard.
        /// 
        /// **[Permissions](https://confluence.atlassian.com/x/_AozKw) required**:
        /// Permission to view the whiteboard and its corresponding space.
        /// </remarks>
        /// <param name="id">The ID of the whiteboard for which operations should be returned.</param>
        /// <returns>
        /// A <see cref="Task"/> representing the <see cref="IApiResponse"/> instance containing the result:
        /// <list type="table">
        /// <listheader>
        /// <term>Status</term>
        /// <description>Description</description>
        /// </listheader>
        /// <item>
        /// <term>200</term>
        /// <description>Returned if the requested operations are returned.</description>
        /// </item>
        /// <item>
        /// <term>400</term>
        /// <description>Returned if an invalid request is provided.</description>
        /// </item>
        /// <item>
        /// <term>401</term>
        /// <description>Returned if the authentication credentials are incorrect or missing\nfrom the request.</description>
        /// </item>
        /// <item>
        /// <term>404</term>
        /// <description>Returned if the calling user does not have permission to view the\nrequested whiteboard or the whiteboard was not found.</description>
        /// </item>
        /// </list>
        /// </returns>
        [Headers("Accept: application/json")]
        [Get("/whiteboards/{id}/operations")]
        Task<IApiResponse<PermittedOperationsResponse>> GetWhiteboardOperationsAsync(long id, CancellationToken cancellationToken = default);

        /// <summary>Get permitted operations for a database</summary>
        /// <remarks>
        /// Returns the permitted operations on specific database.
        /// 
        /// **[Permissions](https://confluence.atlassian.com/x/_AozKw) required**:
        /// Permission to view the database and its corresponding space.
        /// </remarks>
        /// <param name="id">The ID of the database for which operations should be returned.</param>
        /// <returns>
        /// A <see cref="Task"/> representing the <see cref="IApiResponse"/> instance containing the result:
        /// <list type="table">
        /// <listheader>
        /// <term>Status</term>
        /// <description>Description</description>
        /// </listheader>
        /// <item>
        /// <term>200</term>
        /// <description>Returned if the requested operations are returned.</description>
        /// </item>
        /// <item>
        /// <term>400</term>
        /// <description>Returned if an invalid request is provided.</description>
        /// </item>
        /// <item>
        /// <term>401</term>
        /// <description>Returned if the authentication credentials are incorrect or missing\nfrom the request.</description>
        /// </item>
        /// <item>
        /// <term>404</term>
        /// <description>Returned if the calling user does not have permission to view the\nrequested database or the database was not found.</description>
        /// </item>
        /// </list>
        /// </returns>
        [Headers("Accept: application/json")]
        [Get("/databases/{id}/operations")]
        Task<IApiResponse<PermittedOperationsResponse>> GetDatabaseOperationsAsync(long id, CancellationToken cancellationToken = default);

        /// <summary>Get permitted operations for a Smart Link in the content tree</summary>
        /// <remarks>
        /// Returns the permitted operations on specific Smart Link in the content tree.
        /// 
        /// **[Permissions](https://confluence.atlassian.com/x/_AozKw) required**:
        /// Permission to view the Smart Link in the content tree and its corresponding space.
        /// </remarks>
        /// <param name="id">The ID of the Smart Link in the content tree for which operations should be returned.</param>
        /// <returns>
        /// A <see cref="Task"/> representing the <see cref="IApiResponse"/> instance containing the result:
        /// <list type="table">
        /// <listheader>
        /// <term>Status</term>
        /// <description>Description</description>
        /// </listheader>
        /// <item>
        /// <term>200</term>
        /// <description>Returned if the requested operations are returned.</description>
        /// </item>
        /// <item>
        /// <term>400</term>
        /// <description>Returned if an invalid request is provided.</description>
        /// </item>
        /// <item>
        /// <term>401</term>
        /// <description>Returned if the authentication credentials are incorrect or missing\nfrom the request.</description>
        /// </item>
        /// <item>
        /// <term>404</term>
        /// <description>Returned if the calling user does not have permission to view the\nrequested Smart Link in the content tree or the Smart Link was not found.</description>
        /// </item>
        /// </list>
        /// </returns>
        [Headers("Accept: application/json")]
        [Get("/embeds/{id}/operations")]
        Task<IApiResponse<PermittedOperationsResponse>> GetSmartLinkOperationsAsync(long id, CancellationToken cancellationToken = default);

        /// <summary>Get permitted operations for space</summary>
        /// <remarks>
        /// Returns the permitted operations on specific space.
        /// 
        /// **[Permissions](https://confluence.atlassian.com/x/_AozKw) required**:
        /// Permission to view the corresponding space.
        /// </remarks>
        /// <param name="id">The ID of the space for which operations should be returned.</param>
        /// <returns>
        /// A <see cref="Task"/> representing the <see cref="IApiResponse"/> instance containing the result:
        /// <list type="table">
        /// <listheader>
        /// <term>Status</term>
        /// <description>Description</description>
        /// </listheader>
        /// <item>
        /// <term>200</term>
        /// <description>Returned if the requested operations are returned.</description>
        /// </item>
        /// <item>
        /// <term>400</term>
        /// <description>Returned if an invalid request is provided.</description>
        /// </item>
        /// <item>
        /// <term>401</term>
        /// <description>Returned if the authentication credentials are incorrect or missing\nfrom the request.</description>
        /// </item>
        /// <item>
        /// <term>404</term>
        /// <description>Returned if the calling user does not have permission to view the\nspace or the space was not found.</description>
        /// </item>
        /// </list>
        /// </returns>
        [Headers("Accept: application/json")]
        [Get("/spaces/{id}/operations")]
        Task<IApiResponse<PermittedOperationsResponse>> GetSpaceOperationsAsync(long id, CancellationToken cancellationToken = default);

        /// <summary>Get permitted operations for footer comment</summary>
        /// <remarks>
        /// Returns the permitted operations on specific footer comment.
        /// 
        /// **[Permissions](https://confluence.atlassian.com/x/_AozKw) required**:
        /// Permission to view the parent content of the footer comment and its corresponding space.
        /// </remarks>
        /// <param name="id">The ID of the footer comment for which operations should be returned.</param>
        /// <returns>
        /// A <see cref="Task"/> representing the <see cref="IApiResponse"/> instance containing the result:
        /// <list type="table">
        /// <listheader>
        /// <term>Status</term>
        /// <description>Description</description>
        /// </listheader>
        /// <item>
        /// <term>200</term>
        /// <description>Returned if the requested operations are returned.</description>
        /// </item>
        /// <item>
        /// <term>400</term>
        /// <description>Returned if an invalid request is provided.</description>
        /// </item>
        /// <item>
        /// <term>401</term>
        /// <description>Returned if the authentication credentials are incorrect or missing\nfrom the request.</description>
        /// </item>
        /// <item>
        /// <term>404</term>
        /// <description>Returned if the calling user does not have permission to view the\nparent content of the requested footer comment or the footer comment was not found.</description>
        /// </item>
        /// </list>
        /// </returns>
        [Headers("Accept: application/json")]
        [Get("/footer-comments/{id}/operations")]
        Task<IApiResponse<PermittedOperationsResponse>> GetFooterCommentOperationsAsync(long id, CancellationToken cancellationToken = default);

        /// <summary>Get permitted operations for inline comment</summary>
        /// <remarks>
        /// Returns the permitted operations on specific inline comment.
        /// 
        /// **[Permissions](https://confluence.atlassian.com/x/_AozKw) required**:
        /// Permission to view the parent content of the inline comment and its corresponding space.
        /// </remarks>
        /// <param name="id">The ID of the inline comment for which operations should be returned.</param>
        /// <returns>
        /// A <see cref="Task"/> representing the <see cref="IApiResponse"/> instance containing the result:
        /// <list type="table">
        /// <listheader>
        /// <term>Status</term>
        /// <description>Description</description>
        /// </listheader>
        /// <item>
        /// <term>200</term>
        /// <description>Returned if the requested operations are returned.</description>
        /// </item>
        /// <item>
        /// <term>400</term>
        /// <description>Returned if an invalid request is provided.</description>
        /// </item>
        /// <item>
        /// <term>401</term>
        /// <description>Returned if the authentication credentials are incorrect or missing\nfrom the request.</description>
        /// </item>
        /// <item>
        /// <term>404</term>
        /// <description>Returned if the calling user does not have permission to view the\nparent content of the requested inline comment or the inline comment was not found.</description>
        /// </item>
        /// </list>
        /// </returns>
        [Headers("Accept: application/json")]
        [Get("/inline-comments/{id}/operations")]
        Task<IApiResponse<PermittedOperationsResponse>> GetInlineCommentOperationsAsync(long id, CancellationToken cancellationToken = default);
    }

    /// <summary>Get content properties for attachment</summary>
    [System.CodeDom.Compiler.GeneratedCode("Refitter", "1.0.0.0")]
    public partial interface IContentPropertiesApi
    {
        /// <summary>Get content properties for attachment</summary>
        /// <remarks>
        /// Retrieves all Content Properties tied to a specified attachment.
        /// 
        /// **[Permissions](https://confluence.atlassian.com/x/_AozKw) required**:
        /// Permission to view the attachment.
        /// </remarks>
        /// <param name="attachment_id">The ID of the attachment for which content properties should be returned.</param>
        /// <param name="key">Filters the response to return a specific content property with matching key (case sensitive).</param>
        /// <param name="sort">Used to sort the result by a particular field.</param>
        /// <param name="cursor">Used for pagination, this opaque cursor will be returned in the `next` URL in the `Link` response header. Use the relative URL in the `Link` header to retrieve the `next` set of results.</param>
        /// <param name="limit">Maximum number of attachments per result to return. If more results exist, use the `Link` header to retrieve a relative URL that will return the next set of results.</param>
        /// <returns>
        /// A <see cref="Task"/> representing the <see cref="IApiResponse"/> instance containing the result:
        /// <list type="table">
        /// <listheader>
        /// <term>Status</term>
        /// <description>Description</description>
        /// </listheader>
        /// <item>
        /// <term>200</term>
        /// <description>Returned if the requested content properties are successfully retrieved.</description>
        /// </item>
        /// <item>
        /// <term>400</term>
        /// <description>Returned if an invalid request is provided.</description>
        /// </item>
        /// <item>
        /// <term>401</term>
        /// <description>Returned if the authentication credentials are incorrect or missing\nfrom the request.</description>
        /// </item>
        /// <item>
        /// <term>404</term>
        /// <description>Returned if the calling user does not have permission to view the\nspecified attachment or the attachment was not found.</description>
        /// </item>
        /// </list>
        /// </returns>
        [Headers("Accept: application/json")]
        [Get("/attachments/{attachment-id}/properties")]
        Task<IApiResponse<Response4>> GetAttachmentContentPropertiesAsync([AliasAs("attachment-id")] string attachment_id, [Query] string? key = default, [Query] ContentPropertySortOrder? sort = default, [Query] string? cursor = default, [Query] int? limit = default, CancellationToken cancellationToken = default);

        /// <summary>Create content property for attachment</summary>
        /// <remarks>
        /// Creates a new content property for an attachment.
        /// 
        /// **[Permissions](https://confluence.atlassian.com/x/_AozKw) required**:
        /// Permission to update the attachment.
        /// </remarks>
        /// <param name="attachment_id">The ID of the attachment to create a property for.</param>
        /// <param name="body">The content property to be created</param>
        /// <returns>
        /// A <see cref="Task"/> representing the <see cref="IApiResponse"/> instance containing the result:
        /// <list type="table">
        /// <listheader>
        /// <term>Status</term>
        /// <description>Description</description>
        /// </listheader>
        /// <item>
        /// <term>200</term>
        /// <description>Returned if the content property was created successfully.</description>
        /// </item>
        /// <item>
        /// <term>400</term>
        /// <description>Returned if an invalid request is provided.</description>
        /// </item>
        /// <item>
        /// <term>401</term>
        /// <description>Returned if the authentication credentials are incorrect or missing\nfrom the request.</description>
        /// </item>
        /// <item>
        /// <term>404</term>
        /// <description>Returned if the calling user does not have permission to view the\nspecified attachment or the attachment was not found.</description>
        /// </item>
        /// </list>
        /// </returns>
        [Headers("Accept: application/json")]
        [Post("/attachments/{attachment-id}/properties")]
        Task<IApiResponse<ContentProperty>> CreateAttachmentPropertyAsync([AliasAs("attachment-id")] string attachment_id, [Body] ContentPropertyCreateRequest body, CancellationToken cancellationToken = default);

        /// <summary>Get content property for attachment by id</summary>
        /// <remarks>
        /// Retrieves a specific Content Property by ID that is attached to a specified attachment.
        /// 
        /// **[Permissions](https://confluence.atlassian.com/x/_AozKw) required**:
        /// Permission to view the attachment.
        /// </remarks>
        /// <param name="attachment_id">The ID of the attachment for which content properties should be returned.</param>
        /// <param name="property_id">The ID of the content property to be returned</param>
        /// <returns>
        /// A <see cref="Task"/> representing the <see cref="IApiResponse"/> instance containing the result:
        /// <list type="table">
        /// <listheader>
        /// <term>Status</term>
        /// <description>Description</description>
        /// </listheader>
        /// <item>
        /// <term>200</term>
        /// <description>Returned if the requested content property is successfully retrieved.</description>
        /// </item>
        /// <item>
        /// <term>400</term>
        /// <description>Returned if an invalid request is provided.</description>
        /// </item>
        /// <item>
        /// <term>401</term>
        /// <description>Returned if the authentication credentials are incorrect or missing\nfrom the request.</description>
        /// </item>
        /// <item>
        /// <term>404</term>
        /// <description>Returned if the calling user does not have permission to view the\nspecified attachment,the attachment was not found, or the property was not found.</description>
        /// </item>
        /// </list>
        /// </returns>
        [Headers("Accept: application/json")]
        [Get("/attachments/{attachment-id}/properties/{property-id}")]
        Task<IApiResponse<ContentProperty>> GetAttachmentContentPropertiesByIdAsync([AliasAs("attachment-id")] string attachment_id, [AliasAs("property-id")] long property_id, CancellationToken cancellationToken = default);

        /// <summary>Update content property for attachment by id</summary>
        /// <remarks>
        /// Update a content property for attachment by its id.
        /// 
        /// **[Permissions](https://confluence.atlassian.com/x/_AozKw) required**:
        /// Permission to edit the attachment.
        /// </remarks>
        /// <param name="attachment_id">The ID of the attachment the property belongs to.</param>
        /// <param name="property_id">The ID of the property to be updated.</param>
        /// <param name="body">The content property to be updated.</param>
        /// <returns>
        /// A <see cref="Task"/> representing the <see cref="IApiResponse"/> instance containing the result:
        /// <list type="table">
        /// <listheader>
        /// <term>Status</term>
        /// <description>Description</description>
        /// </listheader>
        /// <item>
        /// <term>200</term>
        /// <description>Returned if the content property was updated successfully.</description>
        /// </item>
        /// <item>
        /// <term>400</term>
        /// <description>Returned if an invalid request is provided.</description>
        /// </item>
        /// <item>
        /// <term>401</term>
        /// <description>Returned if the authentication credentials are incorrect or missing\nfrom the request.</description>
        /// </item>
        /// <item>
        /// <term>404</term>
        /// <description>Returned if the calling user does not have permission to view the\nspecified attachment or the attachment was not found.</description>
        /// </item>
        /// </list>
        /// </returns>
        [Headers("Accept: application/json")]
        [Put("/attachments/{attachment-id}/properties/{property-id}")]
        Task<IApiResponse<ContentProperty>> UpdateAttachmentPropertyByIdAsync([AliasAs("attachment-id")] string attachment_id, [AliasAs("property-id")] long property_id, [Body] ContentPropertyUpdateRequest body, CancellationToken cancellationToken = default);

        /// <summary>Delete content property for attachment by id</summary>
        /// <remarks>
        /// Deletes a content property for an attachment by its id.
        /// 
        /// **[Permissions](https://confluence.atlassian.com/x/_AozKw) required**:
        /// Permission to attachment the page.
        /// </remarks>
        /// <param name="attachment_id">The ID of the attachment the property belongs to.</param>
        /// <param name="property_id">The ID of the property to be deleted.</param>
        /// <returns>
        /// A <see cref="Task"/> representing the <see cref="IApiResponse"/> instance containing the result:
        /// <list type="table">
        /// <listheader>
        /// <term>Status</term>
        /// <description>Description</description>
        /// </listheader>
        /// <item>
        /// <term>204</term>
        /// <description>Returned if the content property was deleted successfully.</description>
        /// </item>
        /// <item>
        /// <term>400</term>
        /// <description>Returned if an invalid request is provided.</description>
        /// </item>
        /// <item>
        /// <term>401</term>
        /// <description>Returned if the authentication credentials are incorrect or missing\nfrom the request.</description>
        /// </item>
        /// <item>
        /// <term>404</term>
        /// <description>Returned if the calling user does not have permission to view the\nspecified attachment or the attachment was not found.</description>
        /// </item>
        /// </list>
        /// </returns>
        [Delete("/attachments/{attachment-id}/properties/{property-id}")]
        Task<IApiResponse> DeleteAttachmentPropertyByIdAsync([AliasAs("attachment-id")] string attachment_id, [AliasAs("property-id")] long property_id, CancellationToken cancellationToken = default);

        /// <summary>Get content properties for blog post</summary>
        /// <remarks>
        /// Retrieves all Content Properties tied to a specified blog post.
        /// 
        /// **[Permissions](https://confluence.atlassian.com/x/_AozKw) required**:
        /// Permission to view the blog post.
        /// </remarks>
        /// <param name="blogpost_id">The ID of the blog post for which content properties should be returned.</param>
        /// <param name="key">Filters the response to return a specific content property with matching key (case sensitive).</param>
        /// <param name="sort">Used to sort the result by a particular field.</param>
        /// <param name="cursor">Used for pagination, this opaque cursor will be returned in the `next` URL in the `Link` response header. Use the relative URL in the `Link` header to retrieve the `next` set of results.</param>
        /// <param name="limit">Maximum number of attachments per result to return. If more results exist, use the `Link` header to retrieve a relative URL that will return the next set of results.</param>
        /// <returns>
        /// A <see cref="Task"/> representing the <see cref="IApiResponse"/> instance containing the result:
        /// <list type="table">
        /// <listheader>
        /// <term>Status</term>
        /// <description>Description</description>
        /// </listheader>
        /// <item>
        /// <term>200</term>
        /// <description>Returned if the requested content properties are successfully retrieved.</description>
        /// </item>
        /// <item>
        /// <term>400</term>
        /// <description>Returned if an invalid request is provided.</description>
        /// </item>
        /// <item>
        /// <term>401</term>
        /// <description>Returned if the authentication credentials are incorrect or missing\nfrom the request.</description>
        /// </item>
        /// <item>
        /// <term>404</term>
        /// <description>Returned if the calling user does not have permission to view the\nspecified blog post or the blog post was not found.</description>
        /// </item>
        /// </list>
        /// </returns>
        [Headers("Accept: application/json")]
        [Get("/blogposts/{blogpost-id}/properties")]
        Task<IApiResponse<Response15>> GetBlogpostContentPropertiesAsync([AliasAs("blogpost-id")] long blogpost_id, [Query] string? key = default, [Query] ContentPropertySortOrder? sort = default, [Query] string? cursor = default, [Query] int? limit = default, CancellationToken cancellationToken = default);

        /// <summary>Create content property for blog post</summary>
        /// <remarks>
        /// Creates a new property for a blogpost.
        /// 
        /// **[Permissions](https://confluence.atlassian.com/x/_AozKw) required**:
        /// Permission to update the blog post.
        /// </remarks>
        /// <param name="blogpost_id">The ID of the blog post to create a property for.</param>
        /// <param name="body">The content property to be created</param>
        /// <returns>
        /// A <see cref="Task"/> representing the <see cref="IApiResponse"/> instance containing the result:
        /// <list type="table">
        /// <listheader>
        /// <term>Status</term>
        /// <description>Description</description>
        /// </listheader>
        /// <item>
        /// <term>200</term>
        /// <description>Returned if the content property was created successfully.</description>
        /// </item>
        /// <item>
        /// <term>400</term>
        /// <description>Returned if an invalid request is provided.</description>
        /// </item>
        /// <item>
        /// <term>401</term>
        /// <description>Returned if the authentication credentials are incorrect or missing\nfrom the request.</description>
        /// </item>
        /// <item>
        /// <term>404</term>
        /// <description>Returned if the calling user does not have permission to view the\nspecified blog post or the blog post was not found.</description>
        /// </item>
        /// </list>
        /// </returns>
        [Headers("Accept: application/json")]
        [Post("/blogposts/{blogpost-id}/properties")]
        Task<IApiResponse<ContentProperty>> CreateBlogpostPropertyAsync([AliasAs("blogpost-id")] long blogpost_id, [Body] ContentPropertyCreateRequest body, CancellationToken cancellationToken = default);

        /// <summary>Get content property for blog post by id</summary>
        /// <remarks>
        /// Retrieves a specific Content Property by ID that is attached to a specified blog post.
        /// 
        /// **[Permissions](https://confluence.atlassian.com/x/_AozKw) required**:
        /// Permission to view the blog post.
        /// </remarks>
        /// <param name="blogpost_id">The ID of the blog post for which content properties should be returned.</param>
        /// <param name="property_id">The ID of the property being requested</param>
        /// <returns>
        /// A <see cref="Task"/> representing the <see cref="IApiResponse"/> instance containing the result:
        /// <list type="table">
        /// <listheader>
        /// <term>Status</term>
        /// <description>Description</description>
        /// </listheader>
        /// <item>
        /// <term>200</term>
        /// <description>Returned if the requested content property is successfully retrieved.</description>
        /// </item>
        /// <item>
        /// <term>400</term>
        /// <description>Returned if an invalid request is provided.</description>
        /// </item>
        /// <item>
        /// <term>401</term>
        /// <description>Returned if the authentication credentials are incorrect or missing\nfrom the request.</description>
        /// </item>
        /// <item>
        /// <term>404</term>
        /// <description>Returned if the calling user does not have permission to view the\nspecified blog post,the blog post was not found, or the property was not found.</description>
        /// </item>
        /// </list>
        /// </returns>
        [Headers("Accept: application/json")]
        [Get("/blogposts/{blogpost-id}/properties/{property-id}")]
        Task<IApiResponse<ContentProperty>> GetBlogpostContentPropertiesByIdAsync([AliasAs("blogpost-id")] long blogpost_id, [AliasAs("property-id")] long property_id, CancellationToken cancellationToken = default);

        /// <summary>Update content property for blog post by id</summary>
        /// <remarks>
        /// Update a content property for blog post by its id.
        /// 
        /// **[Permissions](https://confluence.atlassian.com/x/_AozKw) required**:
        /// Permission to edit the blog post.
        /// </remarks>
        /// <param name="blogpost_id">The ID of the blog post the property belongs to.</param>
        /// <param name="property_id">The ID of the property to be updated.</param>
        /// <param name="body">The content property to be updated.</param>
        /// <returns>
        /// A <see cref="Task"/> representing the <see cref="IApiResponse"/> instance containing the result:
        /// <list type="table">
        /// <listheader>
        /// <term>Status</term>
        /// <description>Description</description>
        /// </listheader>
        /// <item>
        /// <term>200</term>
        /// <description>Returned if the content property was updated successfully.</description>
        /// </item>
        /// <item>
        /// <term>400</term>
        /// <description>Returned if an invalid request is provided.</description>
        /// </item>
        /// <item>
        /// <term>401</term>
        /// <description>Returned if the authentication credentials are incorrect or missing\nfrom the request.</description>
        /// </item>
        /// <item>
        /// <term>404</term>
        /// <description>Returned if the calling user does not have permission to view the\nspecified blog post or the blog post was not found.</description>
        /// </item>
        /// </list>
        /// </returns>
        [Headers("Accept: application/json")]
        [Put("/blogposts/{blogpost-id}/properties/{property-id}")]
        Task<IApiResponse<ContentProperty>> UpdateBlogpostPropertyByIdAsync([AliasAs("blogpost-id")] long blogpost_id, [AliasAs("property-id")] long property_id, [Body] ContentPropertyUpdateRequest body, CancellationToken cancellationToken = default);

        /// <summary>Delete content property for blogpost by id</summary>
        /// <remarks>
        /// Deletes a content property for a blogpost by its id.
        /// 
        /// **[Permissions](https://confluence.atlassian.com/x/_AozKw) required**:
        /// Permission to edit the blog post.
        /// </remarks>
        /// <param name="blogpost_id">The ID of the blog post the property belongs to.</param>
        /// <param name="property_id">The ID of the property to be deleted.</param>
        /// <returns>
        /// A <see cref="Task"/> representing the <see cref="IApiResponse"/> instance containing the result:
        /// <list type="table">
        /// <listheader>
        /// <term>Status</term>
        /// <description>Description</description>
        /// </listheader>
        /// <item>
        /// <term>204</term>
        /// <description>Returned if the content property was deleted successfully.</description>
        /// </item>
        /// <item>
        /// <term>400</term>
        /// <description>Returned if an invalid request is provided.</description>
        /// </item>
        /// <item>
        /// <term>401</term>
        /// <description>Returned if the authentication credentials are incorrect or missing\nfrom the request.</description>
        /// </item>
        /// <item>
        /// <term>404</term>
        /// <description>Returned if the calling user does not have permission to view the\nspecified blog post or the blog post was not found.</description>
        /// </item>
        /// </list>
        /// </returns>
        [Delete("/blogposts/{blogpost-id}/properties/{property-id}")]
        Task<IApiResponse> DeleteBlogpostPropertyByIdAsync([AliasAs("blogpost-id")] long blogpost_id, [AliasAs("property-id")] long property_id, CancellationToken cancellationToken = default);

        /// <summary>Get content properties for custom content</summary>
        /// <remarks>
        /// Retrieves Content Properties tied to a specified custom content.
        /// 
        /// **[Permissions](https://confluence.atlassian.com/x/_AozKw) required**:
        /// Permission to view the custom content.
        /// </remarks>
        /// <param name="custom_content_id">The ID of the custom content for which content properties should be returned.</param>
        /// <param name="key">Filters the response to return a specific content property with matching key (case sensitive).</param>
        /// <param name="sort">Used to sort the result by a particular field.</param>
        /// <param name="cursor">Used for pagination, this opaque cursor will be returned in the `next` URL in the `Link` response header. Use the relative URL in the `Link` header to retrieve the `next` set of results.</param>
        /// <param name="limit">Maximum number of attachments per result to return. If more results exist, use the `Link` header to retrieve a relative URL that will return the next set of results.</param>
        /// <returns>
        /// A <see cref="Task"/> representing the <see cref="IApiResponse"/> instance containing the result:
        /// <list type="table">
        /// <listheader>
        /// <term>Status</term>
        /// <description>Description</description>
        /// </listheader>
        /// <item>
        /// <term>200</term>
        /// <description>Returned if the requested content properties are successfully retrieved.</description>
        /// </item>
        /// <item>
        /// <term>400</term>
        /// <description>Returned if an invalid request is provided.</description>
        /// </item>
        /// <item>
        /// <term>401</term>
        /// <description>Returned if the authentication credentials are incorrect or missing\nfrom the request.</description>
        /// </item>
        /// <item>
        /// <term>404</term>
        /// <description>Returned if the calling user does not have permission to view the\nspecified custom content or the custom content was not found.</description>
        /// </item>
        /// </list>
        /// </returns>
        [Headers("Accept: application/json")]
        [Get("/custom-content/{custom-content-id}/properties")]
        Task<IApiResponse<Response24>> GetCustomContentContentPropertiesAsync([AliasAs("custom-content-id")] long custom_content_id, [Query] string? key = default, [Query] ContentPropertySortOrder? sort = default, [Query] string? cursor = default, [Query] int? limit = default, CancellationToken cancellationToken = default);

        /// <summary>Create content property for custom content</summary>
        /// <remarks>
        /// Creates a new content property for a piece of custom content.
        /// 
        /// **[Permissions](https://confluence.atlassian.com/x/_AozKw) required**:
        /// Permission to update the custom content.
        /// </remarks>
        /// <param name="custom_content_id">The ID of the custom content to create a property for.</param>
        /// <param name="body">The content property to be created</param>
        /// <returns>
        /// A <see cref="Task"/> representing the <see cref="IApiResponse"/> instance containing the result:
        /// <list type="table">
        /// <listheader>
        /// <term>Status</term>
        /// <description>Description</description>
        /// </listheader>
        /// <item>
        /// <term>200</term>
        /// <description>Returned if the content property was created successfully.</description>
        /// </item>
        /// <item>
        /// <term>400</term>
        /// <description>Returned if an invalid request is provided.</description>
        /// </item>
        /// <item>
        /// <term>401</term>
        /// <description>Returned if the authentication credentials are incorrect or missing\nfrom the request.</description>
        /// </item>
        /// <item>
        /// <term>404</term>
        /// <description>Returned if the calling user does not have permission to view the\nspecified custom content or the custom content was not found.</description>
        /// </item>
        /// </list>
        /// </returns>
        [Headers("Accept: application/json")]
        [Post("/custom-content/{custom-content-id}/properties")]
        Task<IApiResponse<ContentProperty>> CreateCustomContentPropertyAsync([AliasAs("custom-content-id")] long custom_content_id, [Body] ContentPropertyCreateRequest body, CancellationToken cancellationToken = default);

        /// <summary>Get content property for custom content by id</summary>
        /// <remarks>
        /// Retrieves a specific Content Property by ID that is attached to a specified custom content.
        /// 
        /// **[Permissions](https://confluence.atlassian.com/x/_AozKw) required**:
        /// Permission to view the page.
        /// </remarks>
        /// <param name="custom_content_id">The ID of the custom content for which content properties should be returned.</param>
        /// <param name="property_id">The ID of the content property being requested.</param>
        /// <returns>
        /// A <see cref="Task"/> representing the <see cref="IApiResponse"/> instance containing the result:
        /// <list type="table">
        /// <listheader>
        /// <term>Status</term>
        /// <description>Description</description>
        /// </listheader>
        /// <item>
        /// <term>200</term>
        /// <description>Returned if the requested content property is successfully retrieved.</description>
        /// </item>
        /// <item>
        /// <term>400</term>
        /// <description>Returned if an invalid request is provided.</description>
        /// </item>
        /// <item>
        /// <term>401</term>
        /// <description>Returned if the authentication credentials are incorrect or missing\nfrom the request.</description>
        /// </item>
        /// <item>
        /// <term>404</term>
        /// <description>Returned if the calling user does not have permission to view the\nspecified custom content, the custom content was not found, or the property was not found.</description>
        /// </item>
        /// </list>
        /// </returns>
        [Headers("Accept: application/json")]
        [Get("/custom-content/{custom-content-id}/properties/{property-id}")]
        Task<IApiResponse<ContentProperty>> GetCustomContentContentPropertiesByIdAsync([AliasAs("custom-content-id")] long custom_content_id, [AliasAs("property-id")] long property_id, CancellationToken cancellationToken = default);

        /// <summary>Update content property for custom content by id</summary>
        /// <remarks>
        /// Update a content property for a piece of custom content by its id.
        /// 
        /// **[Permissions](https://confluence.atlassian.com/x/_AozKw) required**:
        /// Permission to edit the custom content.
        /// </remarks>
        /// <param name="custom_content_id">The ID of the custom content the property belongs to.</param>
        /// <param name="property_id">The ID of the property to be updated.</param>
        /// <param name="body">The content property to be updated.</param>
        /// <returns>
        /// A <see cref="Task"/> representing the <see cref="IApiResponse"/> instance containing the result:
        /// <list type="table">
        /// <listheader>
        /// <term>Status</term>
        /// <description>Description</description>
        /// </listheader>
        /// <item>
        /// <term>200</term>
        /// <description>Returned if the content property was updated successfully.</description>
        /// </item>
        /// <item>
        /// <term>400</term>
        /// <description>Returned if an invalid request is provided.</description>
        /// </item>
        /// <item>
        /// <term>401</term>
        /// <description>Returned if the authentication credentials are incorrect or missing\nfrom the request.</description>
        /// </item>
        /// <item>
        /// <term>404</term>
        /// <description>Returned if the calling user does not have permission to view the\nspecified custom content or the custom content was not found.</description>
        /// </item>
        /// </list>
        /// </returns>
        [Headers("Accept: application/json")]
        [Put("/custom-content/{custom-content-id}/properties/{property-id}")]
        Task<IApiResponse<ContentProperty>> UpdateCustomContentPropertyByIdAsync([AliasAs("custom-content-id")] long custom_content_id, [AliasAs("property-id")] long property_id, [Body] ContentPropertyUpdateRequest body, CancellationToken cancellationToken = default);

        /// <summary>Delete content property for custom content by id</summary>
        /// <remarks>
        /// Deletes a content property for a piece of custom content by its id.
        /// 
        /// **[Permissions](https://confluence.atlassian.com/x/_AozKw) required**:
        /// Permission to edit the custom content.
        /// </remarks>
        /// <param name="custom_content_id">The ID of the custom content the property belongs to.</param>
        /// <param name="property_id">The ID of the property to be deleted.</param>
        /// <returns>
        /// A <see cref="Task"/> representing the <see cref="IApiResponse"/> instance containing the result:
        /// <list type="table">
        /// <listheader>
        /// <term>Status</term>
        /// <description>Description</description>
        /// </listheader>
        /// <item>
        /// <term>204</term>
        /// <description>Returned if the content property was deleted successfully.</description>
        /// </item>
        /// <item>
        /// <term>400</term>
        /// <description>Returned if an invalid request is provided.</description>
        /// </item>
        /// <item>
        /// <term>401</term>
        /// <description>Returned if the authentication credentials are incorrect or missing\nfrom the request.</description>
        /// </item>
        /// <item>
        /// <term>404</term>
        /// <description>Returned if the calling user does not have permission to view the\nspecified custom content or the custom content was not found.</description>
        /// </item>
        /// </list>
        /// </returns>
        [Delete("/custom-content/{custom-content-id}/properties/{property-id}")]
        Task<IApiResponse> DeleteCustomContentPropertyByIdAsync([AliasAs("custom-content-id")] long custom_content_id, [AliasAs("property-id")] long property_id, CancellationToken cancellationToken = default);

        /// <summary>Get content properties for page</summary>
        /// <remarks>
        /// Retrieves Content Properties tied to a specified page.
        /// 
        /// **[Permissions](https://confluence.atlassian.com/x/_AozKw) required**:
        /// Permission to view the page.
        /// </remarks>
        /// <param name="page_id">The ID of the page for which content properties should be returned.</param>
        /// <param name="key">Filters the response to return a specific content property with matching key (case sensitive).</param>
        /// <param name="sort">Used to sort the result by a particular field.</param>
        /// <param name="cursor">Used for pagination, this opaque cursor will be returned in the `next` URL in the `Link` response header. Use the relative URL in the `Link` header to retrieve the `next` set of results.</param>
        /// <param name="limit">Maximum number of attachments per result to return. If more results exist, use the `Link` header to retrieve a relative URL that will return the next set of results.</param>
        /// <returns>
        /// A <see cref="Task"/> representing the <see cref="IApiResponse"/> instance containing the result:
        /// <list type="table">
        /// <listheader>
        /// <term>Status</term>
        /// <description>Description</description>
        /// </listheader>
        /// <item>
        /// <term>200</term>
        /// <description>Returned if the requested content properties are successfully retrieved.</description>
        /// </item>
        /// <item>
        /// <term>400</term>
        /// <description>Returned if an invalid request is provided.</description>
        /// </item>
        /// <item>
        /// <term>401</term>
        /// <description>Returned if the authentication credentials are incorrect or missing\nfrom the request.</description>
        /// </item>
        /// <item>
        /// <term>404</term>
        /// <description>Returned if the calling user does not have permission to view the\nspecified page or the page was not found.</description>
        /// </item>
        /// </list>
        /// </returns>
        [Headers("Accept: application/json")]
        [Get("/pages/{page-id}/properties")]
        Task<IApiResponse<Response37>> GetPageContentPropertiesAsync([AliasAs("page-id")] long page_id, [Query] string? key = default, [Query] ContentPropertySortOrder? sort = default, [Query] string? cursor = default, [Query] int? limit = default, CancellationToken cancellationToken = default);

        /// <summary>Create content property for page</summary>
        /// <remarks>
        /// Creates a new content property for a page.
        /// 
        /// **[Permissions](https://confluence.atlassian.com/x/_AozKw) required**:
        /// Permission to update the page.
        /// </remarks>
        /// <param name="page_id">The ID of the page to create a property for.</param>
        /// <param name="body">The content property to be created</param>
        /// <returns>
        /// A <see cref="Task"/> representing the <see cref="IApiResponse"/> instance containing the result:
        /// <list type="table">
        /// <listheader>
        /// <term>Status</term>
        /// <description>Description</description>
        /// </listheader>
        /// <item>
        /// <term>200</term>
        /// <description>Returned if the content property was created successfully.</description>
        /// </item>
        /// <item>
        /// <term>400</term>
        /// <description>Returned if an invalid request is provided.</description>
        /// </item>
        /// <item>
        /// <term>401</term>
        /// <description>Returned if the authentication credentials are incorrect or missing\nfrom the request.</description>
        /// </item>
        /// <item>
        /// <term>404</term>
        /// <description>Returned if the calling user does not have permission to view the\nspecified page or the page was not found.</description>
        /// </item>
        /// </list>
        /// </returns>
        [Headers("Accept: application/json")]
        [Post("/pages/{page-id}/properties")]
        Task<IApiResponse<ContentProperty>> CreatePagePropertyAsync([AliasAs("page-id")] long page_id, [Body] ContentPropertyCreateRequest body, CancellationToken cancellationToken = default);

        /// <summary>Get content property for page by id</summary>
        /// <remarks>
        /// Retrieves a specific Content Property by ID that is attached to a specified page.
        /// 
        /// **[Permissions](https://confluence.atlassian.com/x/_AozKw) required**:
        /// Permission to view the page.
        /// </remarks>
        /// <param name="page_id">The ID of the page for which content properties should be returned.</param>
        /// <param name="property_id">The ID of the content property being requested.</param>
        /// <returns>
        /// A <see cref="Task"/> representing the <see cref="IApiResponse"/> instance containing the result:
        /// <list type="table">
        /// <listheader>
        /// <term>Status</term>
        /// <description>Description</description>
        /// </listheader>
        /// <item>
        /// <term>200</term>
        /// <description>Returned if the requested content property is successfully retrieved.</description>
        /// </item>
        /// <item>
        /// <term>400</term>
        /// <description>Returned if an invalid request is provided.</description>
        /// </item>
        /// <item>
        /// <term>401</term>
        /// <description>Returned if the authentication credentials are incorrect or missing\nfrom the request.</description>
        /// </item>
        /// <item>
        /// <term>404</term>
        /// <description>Returned if the calling user does not have permission to view the\nspecified page, the page was not found, or the property was not found.</description>
        /// </item>
        /// </list>
        /// </returns>
        [Headers("Accept: application/json")]
        [Get("/pages/{page-id}/properties/{property-id}")]
        Task<IApiResponse<ContentProperty>> GetPageContentPropertiesByIdAsync([AliasAs("page-id")] long page_id, [AliasAs("property-id")] long property_id, CancellationToken cancellationToken = default);

        /// <summary>Update content property for page by id</summary>
        /// <remarks>
        /// Update a content property for a page by its id.
        /// 
        /// **[Permissions](https://confluence.atlassian.com/x/_AozKw) required**:
        /// Permission to edit the page.
        /// </remarks>
        /// <param name="page_id">The ID of the page the property belongs to.</param>
        /// <param name="property_id">The ID of the property to be updated.</param>
        /// <param name="body">The content property to be updated.</param>
        /// <returns>
        /// A <see cref="Task"/> representing the <see cref="IApiResponse"/> instance containing the result:
        /// <list type="table">
        /// <listheader>
        /// <term>Status</term>
        /// <description>Description</description>
        /// </listheader>
        /// <item>
        /// <term>200</term>
        /// <description>Returned if the content property was updated successfully.</description>
        /// </item>
        /// <item>
        /// <term>400</term>
        /// <description>Returned if an invalid request is provided.</description>
        /// </item>
        /// <item>
        /// <term>401</term>
        /// <description>Returned if the authentication credentials are incorrect or missing\nfrom the request.</description>
        /// </item>
        /// <item>
        /// <term>404</term>
        /// <description>Returned if the calling user does not have permission to view the\nspecified page or the page was not found.</description>
        /// </item>
        /// </list>
        /// </returns>
        [Headers("Accept: application/json")]
        [Put("/pages/{page-id}/properties/{property-id}")]
        Task<IApiResponse<ContentProperty>> UpdatePagePropertyByIdAsync([AliasAs("page-id")] long page_id, [AliasAs("property-id")] long property_id, [Body] ContentPropertyUpdateRequest body, CancellationToken cancellationToken = default);

        /// <summary>Delete content property for page by id</summary>
        /// <remarks>
        /// Deletes a content property for a page by its id.
        /// 
        /// **[Permissions](https://confluence.atlassian.com/x/_AozKw) required**:
        /// Permission to edit the page.
        /// </remarks>
        /// <param name="page_id">The ID of the page the property belongs to.</param>
        /// <param name="property_id">The ID of the property to be deleted.</param>
        /// <returns>
        /// A <see cref="Task"/> representing the <see cref="IApiResponse"/> instance containing the result:
        /// <list type="table">
        /// <listheader>
        /// <term>Status</term>
        /// <description>Description</description>
        /// </listheader>
        /// <item>
        /// <term>204</term>
        /// <description>Returned if the content property was deleted successfully.</description>
        /// </item>
        /// <item>
        /// <term>400</term>
        /// <description>Returned if an invalid request is provided.</description>
        /// </item>
        /// <item>
        /// <term>401</term>
        /// <description>Returned if the authentication credentials are incorrect or missing\nfrom the request.</description>
        /// </item>
        /// <item>
        /// <term>404</term>
        /// <description>Returned if the calling user does not have permission to view the\nspecified page or the page was not found.</description>
        /// </item>
        /// </list>
        /// </returns>
        [Delete("/pages/{page-id}/properties/{property-id}")]
        Task<IApiResponse> DeletePagePropertyByIdAsync([AliasAs("page-id")] long page_id, [AliasAs("property-id")] long property_id, CancellationToken cancellationToken = default);

        /// <summary>Get content properties for whiteboard</summary>
        /// <remarks>
        /// Retrieves Content Properties tied to a specified whiteboard.
        /// 
        /// **[Permissions](https://confluence.atlassian.com/x/_AozKw) required**:
        /// Permission to view the whiteboard.
        /// </remarks>
        /// <param name="id">The ID of the whiteboard for which content properties should be returned.</param>
        /// <param name="key">Filters the response to return a specific content property with matching key (case sensitive).</param>
        /// <param name="sort">Used to sort the result by a particular field.</param>
        /// <param name="cursor">Used for pagination, this opaque cursor will be returned in the `next` URL in the `Link` response header. Use the relative URL in the `Link` header to retrieve the `next` set of results.</param>
        /// <param name="limit">Maximum number of attachments per result to return. If more results exist, use the `Link` header to retrieve a relative URL that will return the next set of results.</param>
        /// <returns>
        /// A <see cref="Task"/> representing the <see cref="IApiResponse"/> instance containing the result:
        /// <list type="table">
        /// <listheader>
        /// <term>Status</term>
        /// <description>Description</description>
        /// </listheader>
        /// <item>
        /// <term>200</term>
        /// <description>Returned if the requested content properties are successfully retrieved.</description>
        /// </item>
        /// <item>
        /// <term>400</term>
        /// <description>Returned if an invalid request is provided.</description>
        /// </item>
        /// <item>
        /// <term>401</term>
        /// <description>Returned if the authentication credentials are incorrect or missing\nfrom the request.</description>
        /// </item>
        /// <item>
        /// <term>404</term>
        /// <description>Returned if the calling user does not have permission to view the\nspecified whiteboard or the whiteboard was not found.</description>
        /// </item>
        /// </list>
        /// </returns>
        [Headers("Accept: application/json")]
        [Get("/whiteboards/{id}/properties")]
        Task<IApiResponse<Response41>> GetWhiteboardContentPropertiesAsync(long id, [Query] string? key = default, [Query] ContentPropertySortOrder? sort = default, [Query] string? cursor = default, [Query] int? limit = default, CancellationToken cancellationToken = default);

        /// <summary>Create content property for whiteboard</summary>
        /// <remarks>
        /// Creates a new content property for a whiteboard.
        /// 
        /// **[Permissions](https://confluence.atlassian.com/x/_AozKw) required**:
        /// Permission to update the whiteboard.
        /// </remarks>
        /// <param name="id">The ID of the whiteboard to create a property for.</param>
        /// <param name="body">The content property to be created</param>
        /// <returns>
        /// A <see cref="Task"/> representing the <see cref="IApiResponse"/> instance containing the result:
        /// <list type="table">
        /// <listheader>
        /// <term>Status</term>
        /// <description>Description</description>
        /// </listheader>
        /// <item>
        /// <term>200</term>
        /// <description>Returned if the content property was created successfully.</description>
        /// </item>
        /// <item>
        /// <term>400</term>
        /// <description>Returned if an invalid request is provided.</description>
        /// </item>
        /// <item>
        /// <term>401</term>
        /// <description>Returned if the authentication credentials are incorrect or missing\nfrom the request.</description>
        /// </item>
        /// <item>
        /// <term>404</term>
        /// <description>Returned if the calling user does not have permission to view the\nspecified whiteboard or the whiteboard was not found.</description>
        /// </item>
        /// </list>
        /// </returns>
        [Headers("Accept: application/json")]
        [Post("/whiteboards/{id}/properties")]
        Task<IApiResponse<ContentProperty>> CreateWhiteboardPropertyAsync(long id, [Body] ContentPropertyCreateRequest body, CancellationToken cancellationToken = default);

        /// <summary>Get content property for whiteboard by id</summary>
        /// <remarks>
        /// Retrieves a specific Content Property by ID that is attached to a specified whiteboard.
        /// 
        /// **[Permissions](https://confluence.atlassian.com/x/_AozKw) required**:
        /// Permission to view the whiteboard.
        /// </remarks>
        /// <param name="whiteboard_id">The ID of the whiteboard for which content properties should be returned.</param>
        /// <param name="property_id">The ID of the content property being requested.</param>
        /// <returns>
        /// A <see cref="Task"/> representing the <see cref="IApiResponse"/> instance containing the result:
        /// <list type="table">
        /// <listheader>
        /// <term>Status</term>
        /// <description>Description</description>
        /// </listheader>
        /// <item>
        /// <term>200</term>
        /// <description>Returned if the requested content property is successfully retrieved.</description>
        /// </item>
        /// <item>
        /// <term>400</term>
        /// <description>Returned if an invalid request is provided.</description>
        /// </item>
        /// <item>
        /// <term>401</term>
        /// <description>Returned if the authentication credentials are incorrect or missing\nfrom the request.</description>
        /// </item>
        /// <item>
        /// <term>404</term>
        /// <description>Returned if the calling user does not have permission to view the\nspecified whiteboard, the whiteboard was not found, or the property was not found.</description>
        /// </item>
        /// </list>
        /// </returns>
        [Headers("Accept: application/json")]
        [Get("/whiteboards/{whiteboard-id}/properties/{property-id}")]
        Task<IApiResponse<ContentProperty>> GetWhiteboardContentPropertiesByIdAsync([AliasAs("whiteboard-id")] long whiteboard_id, [AliasAs("property-id")] long property_id, CancellationToken cancellationToken = default);

        /// <summary>Update content property for whiteboard by id</summary>
        /// <remarks>
        /// Update a content property for a whiteboard by its id.
        /// 
        /// **[Permissions](https://confluence.atlassian.com/x/_AozKw) required**:
        /// Permission to edit the whiteboard.
        /// </remarks>
        /// <param name="whiteboard_id">The ID of the whiteboard the property belongs to.</param>
        /// <param name="property_id">The ID of the property to be updated.</param>
        /// <param name="body">The content property to be updated.</param>
        /// <returns>
        /// A <see cref="Task"/> representing the <see cref="IApiResponse"/> instance containing the result:
        /// <list type="table">
        /// <listheader>
        /// <term>Status</term>
        /// <description>Description</description>
        /// </listheader>
        /// <item>
        /// <term>200</term>
        /// <description>Returned if the content property was updated successfully.</description>
        /// </item>
        /// <item>
        /// <term>400</term>
        /// <description>Returned if an invalid request is provided.</description>
        /// </item>
        /// <item>
        /// <term>401</term>
        /// <description>Returned if the authentication credentials are incorrect or missing\nfrom the request.</description>
        /// </item>
        /// <item>
        /// <term>404</term>
        /// <description>Returned if the calling user does not have permission to view the\nspecified whiteboard or the whiteboard was not found.</description>
        /// </item>
        /// </list>
        /// </returns>
        [Headers("Accept: application/json")]
        [Put("/whiteboards/{whiteboard-id}/properties/{property-id}")]
        Task<IApiResponse<ContentProperty>> UpdateWhiteboardPropertyByIdAsync([AliasAs("whiteboard-id")] long whiteboard_id, [AliasAs("property-id")] long property_id, [Body] ContentPropertyUpdateRequest body, CancellationToken cancellationToken = default);

        /// <summary>Delete content property for whiteboard by id</summary>
        /// <remarks>
        /// Deletes a content property for a whiteboard by its id.
        /// 
        /// **[Permissions](https://confluence.atlassian.com/x/_AozKw) required**:
        /// Permission to edit the whiteboard.
        /// </remarks>
        /// <param name="whiteboard_id">The ID of the whiteboard the property belongs to.</param>
        /// <param name="property_id">The ID of the property to be deleted.</param>
        /// <returns>
        /// A <see cref="Task"/> representing the <see cref="IApiResponse"/> instance containing the result:
        /// <list type="table">
        /// <listheader>
        /// <term>Status</term>
        /// <description>Description</description>
        /// </listheader>
        /// <item>
        /// <term>204</term>
        /// <description>Returned if the content property was deleted successfully.</description>
        /// </item>
        /// <item>
        /// <term>400</term>
        /// <description>Returned if an invalid request is provided.</description>
        /// </item>
        /// <item>
        /// <term>401</term>
        /// <description>Returned if the authentication credentials are incorrect or missing\nfrom the request.</description>
        /// </item>
        /// <item>
        /// <term>404</term>
        /// <description>Returned if the calling user does not have permission to view the\nspecified whiteboard or the whiteboard was not found.</description>
        /// </item>
        /// </list>
        /// </returns>
        [Delete("/whiteboards/{whiteboard-id}/properties/{property-id}")]
        Task<IApiResponse> DeleteWhiteboardPropertyByIdAsync([AliasAs("whiteboard-id")] long whiteboard_id, [AliasAs("property-id")] long property_id, CancellationToken cancellationToken = default);

        /// <summary>Get content properties for database</summary>
        /// <remarks>
        /// Retrieves Content Properties tied to a specified database.
        /// 
        /// **[Permissions](https://confluence.atlassian.com/x/_AozKw) required**:
        /// Permission to view the database.
        /// </remarks>
        /// <param name="id">The ID of the database for which content properties should be returned.</param>
        /// <param name="key">Filters the response to return a specific content property with matching key (case sensitive).</param>
        /// <param name="sort">Used to sort the result by a particular field.</param>
        /// <param name="cursor">Used for pagination, this opaque cursor will be returned in the `next` URL in the `Link` response header. Use the relative URL in the `Link` header to retrieve the `next` set of results.</param>
        /// <param name="limit">Maximum number of attachments per result to return. If more results exist, use the `Link` header to retrieve a relative URL that will return the next set of results.</param>
        /// <returns>
        /// A <see cref="Task"/> representing the <see cref="IApiResponse"/> instance containing the result:
        /// <list type="table">
        /// <listheader>
        /// <term>Status</term>
        /// <description>Description</description>
        /// </listheader>
        /// <item>
        /// <term>200</term>
        /// <description>Returned if the requested content properties are successfully retrieved.</description>
        /// </item>
        /// <item>
        /// <term>400</term>
        /// <description>Returned if an invalid request is provided.</description>
        /// </item>
        /// <item>
        /// <term>401</term>
        /// <description>Returned if the authentication credentials are incorrect or missing\nfrom the request.</description>
        /// </item>
        /// <item>
        /// <term>404</term>
        /// <description>Returned if the calling user does not have permission to view the\nspecified database or the database was not found.</description>
        /// </item>
        /// </list>
        /// </returns>
        [Headers("Accept: application/json")]
        [Get("/databases/{id}/properties")]
        Task<IApiResponse<Response45>> GetDatabaseContentPropertiesAsync(long id, [Query] string? key = default, [Query] ContentPropertySortOrder? sort = default, [Query] string? cursor = default, [Query] int? limit = default, CancellationToken cancellationToken = default);

        /// <summary>Create content property for database</summary>
        /// <remarks>
        /// Creates a new content property for a database.
        /// 
        /// **[Permissions](https://confluence.atlassian.com/x/_AozKw) required**:
        /// Permission to update the database.
        /// </remarks>
        /// <param name="id">The ID of the database to create a property for.</param>
        /// <param name="body">The content property to be created</param>
        /// <returns>
        /// A <see cref="Task"/> representing the <see cref="IApiResponse"/> instance containing the result:
        /// <list type="table">
        /// <listheader>
        /// <term>Status</term>
        /// <description>Description</description>
        /// </listheader>
        /// <item>
        /// <term>200</term>
        /// <description>Returned if the content property was created successfully.</description>
        /// </item>
        /// <item>
        /// <term>400</term>
        /// <description>Returned if an invalid request is provided.</description>
        /// </item>
        /// <item>
        /// <term>401</term>
        /// <description>Returned if the authentication credentials are incorrect or missing\nfrom the request.</description>
        /// </item>
        /// <item>
        /// <term>404</term>
        /// <description>Returned if the calling user does not have permission to view the\nspecified database or the database was not found.</description>
        /// </item>
        /// </list>
        /// </returns>
        [Headers("Accept: application/json")]
        [Post("/databases/{id}/properties")]
        Task<IApiResponse<ContentProperty>> CreateDatabasePropertyAsync(long id, [Body] ContentPropertyCreateRequest body, CancellationToken cancellationToken = default);

        /// <summary>Get content property for database by id</summary>
        /// <remarks>
        /// Retrieves a specific Content Property by ID that is attached to a specified database.
        /// 
        /// **[Permissions](https://confluence.atlassian.com/x/_AozKw) required**:
        /// Permission to view the database.
        /// </remarks>
        /// <param name="database_id">The ID of the database for which content properties should be returned.</param>
        /// <param name="property_id">The ID of the content property being requested.</param>
        /// <returns>
        /// A <see cref="Task"/> representing the <see cref="IApiResponse"/> instance containing the result:
        /// <list type="table">
        /// <listheader>
        /// <term>Status</term>
        /// <description>Description</description>
        /// </listheader>
        /// <item>
        /// <term>200</term>
        /// <description>Returned if the requested content property is successfully retrieved.</description>
        /// </item>
        /// <item>
        /// <term>400</term>
        /// <description>Returned if an invalid request is provided.</description>
        /// </item>
        /// <item>
        /// <term>401</term>
        /// <description>Returned if the authentication credentials are incorrect or missing\nfrom the request.</description>
        /// </item>
        /// <item>
        /// <term>404</term>
        /// <description>Returned if the calling user does not have permission to view the\nspecified database, the database was not found, or the property was not found.</description>
        /// </item>
        /// </list>
        /// </returns>
        [Headers("Accept: application/json")]
        [Get("/databases/{database-id}/properties/{property-id}")]
        Task<IApiResponse<ContentProperty>> GetDatabaseContentPropertiesByIdAsync([AliasAs("database-id")] long database_id, [AliasAs("property-id")] long property_id, CancellationToken cancellationToken = default);

        /// <summary>Update content property for database by id</summary>
        /// <remarks>
        /// Update a content property for a database by its id.
        /// 
        /// **[Permissions](https://confluence.atlassian.com/x/_AozKw) required**:
        /// Permission to edit the database.
        /// </remarks>
        /// <param name="database_id">The ID of the database the property belongs to.</param>
        /// <param name="property_id">The ID of the property to be updated.</param>
        /// <param name="body">The content property to be updated.</param>
        /// <returns>
        /// A <see cref="Task"/> representing the <see cref="IApiResponse"/> instance containing the result:
        /// <list type="table">
        /// <listheader>
        /// <term>Status</term>
        /// <description>Description</description>
        /// </listheader>
        /// <item>
        /// <term>200</term>
        /// <description>Returned if the content property was updated successfully.</description>
        /// </item>
        /// <item>
        /// <term>400</term>
        /// <description>Returned if an invalid request is provided.</description>
        /// </item>
        /// <item>
        /// <term>401</term>
        /// <description>Returned if the authentication credentials are incorrect or missing\nfrom the request.</description>
        /// </item>
        /// <item>
        /// <term>404</term>
        /// <description>Returned if the calling user does not have permission to view the\nspecified database or the database was not found.</description>
        /// </item>
        /// </list>
        /// </returns>
        [Headers("Accept: application/json")]
        [Put("/databases/{database-id}/properties/{property-id}")]
        Task<IApiResponse<ContentProperty>> UpdateDatabasePropertyByIdAsync([AliasAs("database-id")] long database_id, [AliasAs("property-id")] long property_id, [Body] ContentPropertyUpdateRequest body, CancellationToken cancellationToken = default);

        /// <summary>Delete content property for database by id</summary>
        /// <remarks>
        /// Deletes a content property for a database by its id.
        /// 
        /// **[Permissions](https://confluence.atlassian.com/x/_AozKw) required**:
        /// Permission to edit the database.
        /// </remarks>
        /// <param name="database_id">The ID of the database the property belongs to.</param>
        /// <param name="property_id">The ID of the property to be deleted.</param>
        /// <returns>
        /// A <see cref="Task"/> representing the <see cref="IApiResponse"/> instance containing the result:
        /// <list type="table">
        /// <listheader>
        /// <term>Status</term>
        /// <description>Description</description>
        /// </listheader>
        /// <item>
        /// <term>204</term>
        /// <description>Returned if the content property was deleted successfully.</description>
        /// </item>
        /// <item>
        /// <term>400</term>
        /// <description>Returned if an invalid request is provided.</description>
        /// </item>
        /// <item>
        /// <term>401</term>
        /// <description>Returned if the authentication credentials are incorrect or missing\nfrom the request.</description>
        /// </item>
        /// <item>
        /// <term>404</term>
        /// <description>Returned if the calling user does not have permission to view the\nspecified database or the database was not found.</description>
        /// </item>
        /// </list>
        /// </returns>
        [Delete("/databases/{database-id}/properties/{property-id}")]
        Task<IApiResponse> DeleteDatabasePropertyByIdAsync([AliasAs("database-id")] long database_id, [AliasAs("property-id")] long property_id, CancellationToken cancellationToken = default);

        /// <summary>Get content properties for Smart Link in the content tree</summary>
        /// <remarks>
        /// Retrieves Content Properties tied to a specified Smart Link in the content tree.
        /// 
        /// **[Permissions](https://confluence.atlassian.com/x/_AozKw) required**:
        /// Permission to view the Smart Link in the content tree.
        /// </remarks>
        /// <param name="id">The ID of the Smart Link in the content tree for which content properties should be returned.</param>
        /// <param name="key">Filters the response to return a specific content property with matching key (case sensitive).</param>
        /// <param name="sort">Used to sort the result by a particular field.</param>
        /// <param name="cursor">Used for pagination, this opaque cursor will be returned in the `next` URL in the `Link` response header. Use the relative URL in the `Link` header to retrieve the `next` set of results.</param>
        /// <param name="limit">Maximum number of attachments per result to return. If more results exist, use the `Link` header to retrieve a relative URL that will return the next set of results.</param>
        /// <returns>
        /// A <see cref="Task"/> representing the <see cref="IApiResponse"/> instance containing the result:
        /// <list type="table">
        /// <listheader>
        /// <term>Status</term>
        /// <description>Description</description>
        /// </listheader>
        /// <item>
        /// <term>200</term>
        /// <description>Returned if the requested content properties are successfully retrieved.</description>
        /// </item>
        /// <item>
        /// <term>400</term>
        /// <description>Returned if an invalid request is provided.</description>
        /// </item>
        /// <item>
        /// <term>401</term>
        /// <description>Returned if the authentication credentials are incorrect or missing\nfrom the request.</description>
        /// </item>
        /// <item>
        /// <term>404</term>
        /// <description>Returned if the calling user does not have permission to view the\nspecified Smart Link in the content tree or the Smart Link was not found.</description>
        /// </item>
        /// </list>
        /// </returns>
        [Headers("Accept: application/json")]
        [Get("/embeds/{id}/properties")]
        Task<IApiResponse<Response49>> GetSmartLinkContentPropertiesAsync(long id, [Query] string? key = default, [Query] ContentPropertySortOrder? sort = default, [Query] string? cursor = default, [Query] int? limit = default, CancellationToken cancellationToken = default);

        /// <summary>Create content property for Smart Link in the content tree</summary>
        /// <remarks>
        /// Creates a new content property for a Smart Link in the content tree.
        /// 
        /// **[Permissions](https://confluence.atlassian.com/x/_AozKw) required**:
        /// Permission to update the Smart Link in the content tree.
        /// </remarks>
        /// <param name="id">The ID of the Smart Link in the content tree to create a property for.</param>
        /// <param name="body">The content property to be created</param>
        /// <returns>
        /// A <see cref="Task"/> representing the <see cref="IApiResponse"/> instance containing the result:
        /// <list type="table">
        /// <listheader>
        /// <term>Status</term>
        /// <description>Description</description>
        /// </listheader>
        /// <item>
        /// <term>200</term>
        /// <description>Returned if the content property was created successfully.</description>
        /// </item>
        /// <item>
        /// <term>400</term>
        /// <description>Returned if an invalid request is provided.</description>
        /// </item>
        /// <item>
        /// <term>401</term>
        /// <description>Returned if the authentication credentials are incorrect or missing\nfrom the request.</description>
        /// </item>
        /// <item>
        /// <term>404</term>
        /// <description>Returned if the calling user does not have permission to view the\nspecified Smart Link in the content tree or the Smart Link was not found.</description>
        /// </item>
        /// </list>
        /// </returns>
        [Headers("Accept: application/json")]
        [Post("/embeds/{id}/properties")]
        Task<IApiResponse<ContentProperty>> CreateSmartLinkPropertyAsync(long id, [Body] ContentPropertyCreateRequest body, CancellationToken cancellationToken = default);

        /// <summary>Get content property for Smart Link in the content tree by id</summary>
        /// <remarks>
        /// Retrieves a specific Content Property by ID that is attached to a specified Smart Link in the content tree.
        /// 
        /// **[Permissions](https://confluence.atlassian.com/x/_AozKw) required**:
        /// Permission to view the Smart Link in the content tree.
        /// </remarks>
        /// <param name="embed_id">The ID of the Smart Link in the content tree for which content properties should be returned.</param>
        /// <param name="property_id">The ID of the content property being requested.</param>
        /// <returns>
        /// A <see cref="Task"/> representing the <see cref="IApiResponse"/> instance containing the result:
        /// <list type="table">
        /// <listheader>
        /// <term>Status</term>
        /// <description>Description</description>
        /// </listheader>
        /// <item>
        /// <term>200</term>
        /// <description>Returned if the requested content property is successfully retrieved.</description>
        /// </item>
        /// <item>
        /// <term>400</term>
        /// <description>Returned if an invalid request is provided.</description>
        /// </item>
        /// <item>
        /// <term>401</term>
        /// <description>Returned if the authentication credentials are incorrect or missing\nfrom the request.</description>
        /// </item>
        /// <item>
        /// <term>404</term>
        /// <description>Returned if the calling user does not have permission to view the\nspecified Smart Link in the content tree, the Smart Link was not found, or the property was not found.</description>
        /// </item>
        /// </list>
        /// </returns>
        [Headers("Accept: application/json")]
        [Get("/embeds/{embed-id}/properties/{property-id}")]
        Task<IApiResponse<ContentProperty>> GetSmartLinkContentPropertiesByIdAsync([AliasAs("embed-id")] long embed_id, [AliasAs("property-id")] long property_id, CancellationToken cancellationToken = default);

        /// <summary>Update content property for Smart Link in the content tree by id</summary>
        /// <remarks>
        /// Update a content property for a Smart Link in the content tree by its id.
        /// 
        /// **[Permissions](https://confluence.atlassian.com/x/_AozKw) required**:
        /// Permission to edit the Smart Link in the content tree.
        /// </remarks>
        /// <param name="embed_id">The ID of the Smart Link in the content tree the property belongs to.</param>
        /// <param name="property_id">The ID of the property to be updated.</param>
        /// <param name="body">The content property to be updated.</param>
        /// <returns>
        /// A <see cref="Task"/> representing the <see cref="IApiResponse"/> instance containing the result:
        /// <list type="table">
        /// <listheader>
        /// <term>Status</term>
        /// <description>Description</description>
        /// </listheader>
        /// <item>
        /// <term>200</term>
        /// <description>Returned if the content property was updated successfully.</description>
        /// </item>
        /// <item>
        /// <term>400</term>
        /// <description>Returned if an invalid request is provided.</description>
        /// </item>
        /// <item>
        /// <term>401</term>
        /// <description>Returned if the authentication credentials are incorrect or missing\nfrom the request.</description>
        /// </item>
        /// <item>
        /// <term>404</term>
        /// <description>Returned if the calling user does not have permission to view the\nspecified Smart Link in the content tree or the Smart Link was not found.</description>
        /// </item>
        /// </list>
        /// </returns>
        [Headers("Accept: application/json")]
        [Put("/embeds/{embed-id}/properties/{property-id}")]
        Task<IApiResponse<ContentProperty>> UpdateSmartLinkPropertyByIdAsync([AliasAs("embed-id")] long embed_id, [AliasAs("property-id")] long property_id, [Body] ContentPropertyUpdateRequest body, CancellationToken cancellationToken = default);

        /// <summary>Delete content property for Smart Link in the content tree by id</summary>
        /// <remarks>
        /// Deletes a content property for a Smart Link in the content tree by its id.
        /// 
        /// **[Permissions](https://confluence.atlassian.com/x/_AozKw) required**:
        /// Permission to edit the Smart Link in the content tree.
        /// </remarks>
        /// <param name="embed_id">The ID of the Smart Link in the content tree the property belongs to.</param>
        /// <param name="property_id">The ID of the property to be deleted.</param>
        /// <returns>
        /// A <see cref="Task"/> representing the <see cref="IApiResponse"/> instance containing the result:
        /// <list type="table">
        /// <listheader>
        /// <term>Status</term>
        /// <description>Description</description>
        /// </listheader>
        /// <item>
        /// <term>204</term>
        /// <description>Returned if the content property was deleted successfully.</description>
        /// </item>
        /// <item>
        /// <term>400</term>
        /// <description>Returned if an invalid request is provided.</description>
        /// </item>
        /// <item>
        /// <term>401</term>
        /// <description>Returned if the authentication credentials are incorrect or missing\nfrom the request.</description>
        /// </item>
        /// <item>
        /// <term>404</term>
        /// <description>Returned if the calling user does not have permission to view the\nspecified Smart Link in the content tree or the Smart Link was not found.</description>
        /// </item>
        /// </list>
        /// </returns>
        [Delete("/embeds/{embed-id}/properties/{property-id}")]
        Task<IApiResponse> DeleteSmartLinkPropertyByIdAsync([AliasAs("embed-id")] long embed_id, [AliasAs("property-id")] long property_id, CancellationToken cancellationToken = default);

        /// <summary>Get content properties for comment</summary>
        /// <remarks>
        /// Retrieves Content Properties attached to a specified comment.
        /// 
        /// **[Permissions](https://confluence.atlassian.com/x/_AozKw) required**:
        /// Permission to view the comment.
        /// </remarks>
        /// <param name="comment_id">The ID of the comment for which content properties should be returned.</param>
        /// <param name="key">Filters the response to return a specific content property with matching key (case sensitive).</param>
        /// <param name="sort">Used to sort the result by a particular field.</param>
        /// <param name="cursor">Used for pagination, this opaque cursor will be returned in the `next` URL in the `Link` response header. Use the relative URL in the `Link` header to retrieve the `next` set of results.</param>
        /// <param name="limit">Maximum number of attachments per result to return. If more results exist, use the `Link` header to retrieve a relative URL that will return the next set of results.</param>
        /// <returns>
        /// A <see cref="Task"/> representing the <see cref="IApiResponse"/> instance containing the result:
        /// <list type="table">
        /// <listheader>
        /// <term>Status</term>
        /// <description>Description</description>
        /// </listheader>
        /// <item>
        /// <term>200</term>
        /// <description>Returned if the requested content properties are successfully retrieved.</description>
        /// </item>
        /// <item>
        /// <term>400</term>
        /// <description>Returned if an invalid request is provided.</description>
        /// </item>
        /// <item>
        /// <term>401</term>
        /// <description>Returned if the authentication credentials are incorrect or missing\nfrom the request.</description>
        /// </item>
        /// <item>
        /// <term>404</term>
        /// <description>Returned if the calling user does not have permission to view the\nspecified comment or the comment was not found.</description>
        /// </item>
        /// </list>
        /// </returns>
        [Headers("Accept: application/json")]
        [Get("/comments/{comment-id}/properties")]
        Task<IApiResponse<Response78>> GetCommentContentPropertiesAsync([AliasAs("comment-id")] long comment_id, [Query] string? key = default, [Query] ContentPropertySortOrder? sort = default, [Query] string? cursor = default, [Query] int? limit = default, CancellationToken cancellationToken = default);

        /// <summary>Create content property for comment</summary>
        /// <remarks>
        /// Creates a new content property for a comment.
        /// 
        /// **[Permissions](https://confluence.atlassian.com/x/_AozKw) required**:
        /// Permission to update the comment.
        /// </remarks>
        /// <param name="comment_id">The ID of the comment to create a property for.</param>
        /// <param name="body">The content property to be created</param>
        /// <returns>
        /// A <see cref="Task"/> representing the <see cref="IApiResponse"/> instance containing the result:
        /// <list type="table">
        /// <listheader>
        /// <term>Status</term>
        /// <description>Description</description>
        /// </listheader>
        /// <item>
        /// <term>200</term>
        /// <description>Returned if the content property was created successfully.</description>
        /// </item>
        /// <item>
        /// <term>400</term>
        /// <description>Returned if an invalid request is provided.</description>
        /// </item>
        /// <item>
        /// <term>401</term>
        /// <description>Returned if the authentication credentials are incorrect or missing\nfrom the request.</description>
        /// </item>
        /// <item>
        /// <term>404</term>
        /// <description>Returned if the calling user does not have permission to view the\nspecified page or the page was not found.</description>
        /// </item>
        /// </list>
        /// </returns>
        [Headers("Accept: application/json")]
        [Post("/comments/{comment-id}/properties")]
        Task<IApiResponse<ContentProperty>> CreateCommentPropertyAsync([AliasAs("comment-id")] long comment_id, [Body] ContentPropertyCreateRequest body, CancellationToken cancellationToken = default);

        /// <summary>Get content property for comment by id</summary>
        /// <remarks>
        /// Retrieves a specific Content Property by ID that is attached to a specified comment.
        /// 
        /// **[Permissions](https://confluence.atlassian.com/x/_AozKw) required**:
        /// Permission to view the comment.
        /// </remarks>
        /// <param name="comment_id">The ID of the comment for which content properties should be returned.</param>
        /// <param name="property_id">The ID of the content property being requested.</param>
        /// <returns>
        /// A <see cref="Task"/> representing the <see cref="IApiResponse"/> instance containing the result:
        /// <list type="table">
        /// <listheader>
        /// <term>Status</term>
        /// <description>Description</description>
        /// </listheader>
        /// <item>
        /// <term>200</term>
        /// <description>Returned if the requested content property is successfully retrieved.</description>
        /// </item>
        /// <item>
        /// <term>400</term>
        /// <description>Returned if an invalid request is provided.</description>
        /// </item>
        /// <item>
        /// <term>401</term>
        /// <description>Returned if the authentication credentials are incorrect or missing\nfrom the request.</description>
        /// </item>
        /// <item>
        /// <term>404</term>
        /// <description>Returned if the calling user does not have permission to view the\nspecified comment, the comment was not found, or the property was not found.</description>
        /// </item>
        /// </list>
        /// </returns>
        [Headers("Accept: application/json")]
        [Get("/comments/{comment-id}/properties/{property-id}")]
        Task<IApiResponse<ContentProperty>> GetCommentContentPropertiesByIdAsync([AliasAs("comment-id")] long comment_id, [AliasAs("property-id")] long property_id, CancellationToken cancellationToken = default);

        /// <summary>Update content property for comment by id</summary>
        /// <remarks>
        /// Update a content property for a comment by its id.
        /// 
        /// **[Permissions](https://confluence.atlassian.com/x/_AozKw) required**:
        /// Permission to edit the comment.
        /// </remarks>
        /// <param name="comment_id">The ID of the comment the property belongs to.</param>
        /// <param name="property_id">The ID of the property to be updated.</param>
        /// <param name="body">The content property to be updated.</param>
        /// <returns>
        /// A <see cref="Task"/> representing the <see cref="IApiResponse"/> instance containing the result:
        /// <list type="table">
        /// <listheader>
        /// <term>Status</term>
        /// <description>Description</description>
        /// </listheader>
        /// <item>
        /// <term>200</term>
        /// <description>Returned if the content property was updated successfully.</description>
        /// </item>
        /// <item>
        /// <term>400</term>
        /// <description>Returned if an invalid request is provided.</description>
        /// </item>
        /// <item>
        /// <term>401</term>
        /// <description>Returned if the authentication credentials are incorrect or missing\nfrom the request.</description>
        /// </item>
        /// <item>
        /// <term>404</term>
        /// <description>Returned if the calling user does not have permission to view the\nspecified comment or the comment was not found.</description>
        /// </item>
        /// </list>
        /// </returns>
        [Headers("Accept: application/json")]
        [Put("/comments/{comment-id}/properties/{property-id}")]
        Task<IApiResponse<ContentProperty>> UpdateCommentPropertyByIdAsync([AliasAs("comment-id")] long comment_id, [AliasAs("property-id")] long property_id, [Body] ContentPropertyUpdateRequest body, CancellationToken cancellationToken = default);

        /// <summary>Delete content property for comment by id</summary>
        /// <remarks>
        /// Deletes a content property for a comment by its id.
        /// 
        /// **[Permissions](https://confluence.atlassian.com/x/_AozKw) required**:
        /// Permission to edit the comment.
        /// </remarks>
        /// <param name="comment_id">The ID of the comment the property belongs to.</param>
        /// <param name="property_id">The ID of the property to be deleted.</param>
        /// <returns>
        /// A <see cref="Task"/> representing the <see cref="IApiResponse"/> instance containing the result:
        /// <list type="table">
        /// <listheader>
        /// <term>Status</term>
        /// <description>Description</description>
        /// </listheader>
        /// <item>
        /// <term>204</term>
        /// <description>Returned if the content property was deleted successfully.</description>
        /// </item>
        /// <item>
        /// <term>400</term>
        /// <description>Returned if an invalid request is provided.</description>
        /// </item>
        /// <item>
        /// <term>401</term>
        /// <description>Returned if the authentication credentials are incorrect or missing\nfrom the request.</description>
        /// </item>
        /// <item>
        /// <term>404</term>
        /// <description>Returned if the calling user does not have permission to view the\nspecified comment or the comment was not found.</description>
        /// </item>
        /// </list>
        /// </returns>
        [Delete("/comments/{comment-id}/properties/{property-id}")]
        Task<IApiResponse> DeleteCommentPropertyByIdAsync([AliasAs("comment-id")] long comment_id, [AliasAs("property-id")] long property_id, CancellationToken cancellationToken = default);
    }

    /// <summary>Get attachment versions</summary>
    [System.CodeDom.Compiler.GeneratedCode("Refitter", "1.0.0.0")]
    public partial interface IVersionApi
    {
        /// <summary>Get attachment versions</summary>
        /// <remarks>
        /// Returns the versions of specific attachment.
        /// 
        /// **[Permissions](https://confluence.atlassian.com/x/_AozKw) required**:
        /// Permission to view the attachment and its corresponding space.
        /// </remarks>
        /// <param name="id">The ID of the attachment to be queried for its versions. If you don't know the attachment ID, use Get attachments and filter the results.</param>
        /// <param name="cursor">Used for pagination, this opaque cursor will be returned in the `next` URL in the `Link` response header. Use the relative URL in the `Link` header to retrieve the `next` set of results.</param>
        /// <param name="limit">Maximum number of versions per result to return. If more results exist, use the `Link` header to retrieve a relative URL that will return the next set of results.</param>
        /// <param name="sort">Used to sort the result by a particular field.</param>
        /// <returns>
        /// A <see cref="Task"/> representing the <see cref="IApiResponse"/> instance containing the result:
        /// <list type="table">
        /// <listheader>
        /// <term>Status</term>
        /// <description>Description</description>
        /// </listheader>
        /// <item>
        /// <term>200</term>
        /// <description>Returned if the requested attachment versions are returned.</description>
        /// </item>
        /// <item>
        /// <term>400</term>
        /// <description>Returned if an invalid request is provided.</description>
        /// </item>
        /// <item>
        /// <term>401</term>
        /// <description>Returned if the authentication credentials are incorrect or missing\nfrom the request.</description>
        /// </item>
        /// <item>
        /// <term>404</term>
        /// <description>Returned if the calling user does not have permission to view the\nrequested page or the page was not found.</description>
        /// </item>
        /// </list>
        /// </returns>
        [Headers("Accept: application/json")]
        [Get("/attachments/{id}/versions")]
        Task<IApiResponse<Response5>> GetAttachmentVersionsAsync(string id, [Query] string? cursor = default, [Query] int? limit = default, [Query] VersionSortOrder? sort = default, CancellationToken cancellationToken = default);

        /// <summary>Get version details for attachment version</summary>
        /// <remarks>
        /// Retrieves version details for the specified attachment and version number.
        /// 
        /// **[Permissions](https://confluence.atlassian.com/x/_AozKw) required**:
        /// Permission to view the attachment.
        /// </remarks>
        /// <param name="attachment_id">The ID of the attachment for which version details should be returned.</param>
        /// <param name="version_number">The version number of the attachment to be returned.</param>
        /// <returns>
        /// A <see cref="Task"/> representing the <see cref="IApiResponse"/> instance containing the result:
        /// <list type="table">
        /// <listheader>
        /// <term>Status</term>
        /// <description>Description</description>
        /// </listheader>
        /// <item>
        /// <term>200</term>
        /// <description>Returned if the requested version details are successfully retrieved.</description>
        /// </item>
        /// <item>
        /// <term>400</term>
        /// <description>Returned if an invalid request is provided.</description>
        /// </item>
        /// <item>
        /// <term>401</term>
        /// <description>Returned if the authentication credentials are incorrect or missing\nfrom the request.</description>
        /// </item>
        /// <item>
        /// <term>404</term>
        /// <description>Returned if the calling user does not have permission to view the\nspecified attachment, the attachment was not found, or the version number does not exist.</description>
        /// </item>
        /// </list>
        /// </returns>
        [Headers("Accept: application/json")]
        [Get("/attachments/{attachment-id}/versions/{version-number}")]
        Task<IApiResponse<DetailedVersion>> GetAttachmentVersionDetailsAsync([AliasAs("attachment-id")] string attachment_id, [AliasAs("version-number")] long version_number, CancellationToken cancellationToken = default);

        /// <summary>Get blog post versions</summary>
        /// <remarks>
        /// Returns the versions of specific blog post.
        /// 
        /// **[Permissions](https://confluence.atlassian.com/x/_AozKw) required**:
        /// Permission to view the blog post and its corresponding space.
        /// </remarks>
        /// <param name="id">The ID of the blog post to be queried for its versions. If you don't know the blog post ID, use Get blog posts and filter the results.</param>
        /// <param name="body_format">The content format types to be returned in the `body` field of the response. If available, the representation will be available under a response field of the same name under the `body` field.</param>
        /// <param name="cursor">Used for pagination, this opaque cursor will be returned in the `next` URL in the `Link` response header. Use the relative URL in the `Link` header to retrieve the `next` set of results.</param>
        /// <param name="limit">Maximum number of versions per result to return. If more results exist, use the `Link` header to retrieve a relative URL that will return the next set of results.</param>
        /// <param name="sort">Used to sort the result by a particular field.</param>
        /// <returns>
        /// A <see cref="Task"/> representing the <see cref="IApiResponse"/> instance containing the result:
        /// <list type="table">
        /// <listheader>
        /// <term>Status</term>
        /// <description>Description</description>
        /// </listheader>
        /// <item>
        /// <term>200</term>
        /// <description>Returned if the requested blog post versions are returned.</description>
        /// </item>
        /// <item>
        /// <term>400</term>
        /// <description>Returned if an invalid request is provided.</description>
        /// </item>
        /// <item>
        /// <term>401</term>
        /// <description>Returned if the authentication credentials are incorrect or missing\nfrom the request.</description>
        /// </item>
        /// <item>
        /// <term>404</term>
        /// <description>Returned if the calling user does not have permission to view the\nrequested page or the page was not found.</description>
        /// </item>
        /// </list>
        /// </returns>
        [Headers("Accept: application/json")]
        [Get("/blogposts/{id}/versions")]
        Task<IApiResponse<Response16>> GetBlogPostVersionsAsync(long id, [Query, AliasAs("body-format")] PrimaryBodyRepresentation? body_format = default, [Query] string? cursor = default, [Query] int? limit = default, [Query] VersionSortOrder? sort = default, CancellationToken cancellationToken = default);

        /// <summary>Get version details for blog post version</summary>
        /// <remarks>
        /// Retrieves version details for the specified blog post and version number.
        /// 
        /// **[Permissions](https://confluence.atlassian.com/x/_AozKw) required**:
        /// Permission to view the blog post.
        /// </remarks>
        /// <param name="blogpost_id">The ID of the blog post for which version details should be returned.</param>
        /// <param name="version_number">The version number of the blog post to be returned.</param>
        /// <returns>
        /// A <see cref="Task"/> representing the <see cref="IApiResponse"/> instance containing the result:
        /// <list type="table">
        /// <listheader>
        /// <term>Status</term>
        /// <description>Description</description>
        /// </listheader>
        /// <item>
        /// <term>200</term>
        /// <description>Returned if the requested version details are successfully retrieved.</description>
        /// </item>
        /// <item>
        /// <term>400</term>
        /// <description>Returned if an invalid request is provided.</description>
        /// </item>
        /// <item>
        /// <term>401</term>
        /// <description>Returned if the authentication credentials are incorrect or missing\nfrom the request.</description>
        /// </item>
        /// <item>
        /// <term>404</term>
        /// <description>Returned if the calling user does not have permission to view the\nspecified blog post, the blog post was not found, or the version number does not exist.</description>
        /// </item>
        /// </list>
        /// </returns>
        [Headers("Accept: application/json")]
        [Get("/blogposts/{blogpost-id}/versions/{version-number}")]
        Task<IApiResponse<DetailedVersion>> GetBlogPostVersionDetailsAsync([AliasAs("blogpost-id")] long blogpost_id, [AliasAs("version-number")] long version_number, CancellationToken cancellationToken = default);

        /// <summary>Get page versions</summary>
        /// <remarks>
        /// Returns the versions of specific page.
        /// 
        /// **[Permissions](https://confluence.atlassian.com/x/_AozKw) required**:
        /// Permission to view the page and its corresponding space.
        /// </remarks>
        /// <param name="id">The ID of the page to be queried for its versions. If you don't know the page ID, use Get pages and filter the results.</param>
        /// <param name="body_format">The content format types to be returned in the `body` field of the response. If available, the representation will be available under a response field of the same name under the `body` field.</param>
        /// <param name="cursor">Used for pagination, this opaque cursor will be returned in the `next` URL in the `Link` response header. Use the relative URL in the `Link` header to retrieve the `next` set of results.</param>
        /// <param name="limit">Maximum number of versions per result to return. If more results exist, use the `Link` header to retrieve a relative URL that will return the next set of results.</param>
        /// <param name="sort">Used to sort the result by a particular field.</param>
        /// <returns>
        /// A <see cref="Task"/> representing the <see cref="IApiResponse"/> instance containing the result:
        /// <list type="table">
        /// <listheader>
        /// <term>Status</term>
        /// <description>Description</description>
        /// </listheader>
        /// <item>
        /// <term>200</term>
        /// <description>Returned if the requested page versions are returned.</description>
        /// </item>
        /// <item>
        /// <term>400</term>
        /// <description>Returned if an invalid request is provided.</description>
        /// </item>
        /// <item>
        /// <term>401</term>
        /// <description>Returned if the authentication credentials are incorrect or missing\nfrom the request.</description>
        /// </item>
        /// <item>
        /// <term>404</term>
        /// <description>Returned if the calling user does not have permission to view the\nrequested page or the page was not found.</description>
        /// </item>
        /// </list>
        /// </returns>
        [Headers("Accept: application/json")]
        [Get("/pages/{id}/versions")]
        Task<IApiResponse<Response38>> GetPageVersionsAsync(long id, [Query, AliasAs("body-format")] PrimaryBodyRepresentation? body_format = default, [Query] string? cursor = default, [Query] int? limit = default, [Query] VersionSortOrder? sort = default, CancellationToken cancellationToken = default);

        /// <summary>Get version details for page version</summary>
        /// <remarks>
        /// Retrieves version details for the specified page and version number.
        /// 
        /// **[Permissions](https://confluence.atlassian.com/x/_AozKw) required**:
        /// Permission to view the page.
        /// </remarks>
        /// <param name="page_id">The ID of the page for which version details should be returned.</param>
        /// <param name="version_number">The version number of the page to be returned.</param>
        /// <returns>
        /// A <see cref="Task"/> representing the <see cref="IApiResponse"/> instance containing the result:
        /// <list type="table">
        /// <listheader>
        /// <term>Status</term>
        /// <description>Description</description>
        /// </listheader>
        /// <item>
        /// <term>200</term>
        /// <description>Returned if the requested version details are successfully retrieved.</description>
        /// </item>
        /// <item>
        /// <term>400</term>
        /// <description>Returned if an invalid request is provided.</description>
        /// </item>
        /// <item>
        /// <term>401</term>
        /// <description>Returned if the authentication credentials are incorrect or missing\nfrom the request.</description>
        /// </item>
        /// <item>
        /// <term>404</term>
        /// <description>Returned if the calling user does not have permission to view the\nspecified page, the page was not found, or the version number does not exist.</description>
        /// </item>
        /// </list>
        /// </returns>
        [Headers("Accept: application/json")]
        [Get("/pages/{page-id}/versions/{version-number}")]
        Task<IApiResponse<DetailedVersion>> GetPageVersionDetailsAsync([AliasAs("page-id")] long page_id, [AliasAs("version-number")] long version_number, CancellationToken cancellationToken = default);

        /// <summary>Get custom content versions</summary>
        /// <remarks>
        /// Returns the versions of specific custom content.
        /// 
        /// **[Permissions](https://confluence.atlassian.com/x/_AozKw) required**:
        /// Permission to view the custom content and its corresponding page and space.
        /// </remarks>
        /// <param name="custom_content_id">The ID of the custom content to be queried for its versions. If you don't know the custom content ID, use Get custom-content by type and filter the results.</param>
        /// <param name="body_format">
        /// The content format types to be returned in the `body` field of the response. If available, the representation will be available under a response field of the same name under the `body` field.
        /// 
        /// Note: If the custom content body type is `storage`, the `storage` and `atlas_doc_format` body formats are able to be returned. If the custom content body type is `raw`, only the `raw` body format is able to be returned.
        /// </param>
        /// <param name="cursor">Used for pagination, this opaque cursor will be returned in the `next` URL in the `Link` response header. Use the relative URL in the `Link` header to retrieve the `next` set of results.</param>
        /// <param name="limit">Maximum number of versions per result to return. If more results exist, use the `Link` header to retrieve a relative URL that will return the next set of results.</param>
        /// <param name="sort">Used to sort the result by a particular field.</param>
        /// <returns>
        /// A <see cref="Task"/> representing the <see cref="IApiResponse"/> instance containing the result:
        /// <list type="table">
        /// <listheader>
        /// <term>Status</term>
        /// <description>Description</description>
        /// </listheader>
        /// <item>
        /// <term>200</term>
        /// <description>Returned if the requested custom content versions are returned.</description>
        /// </item>
        /// <item>
        /// <term>400</term>
        /// <description>Returned if an invalid request is provided.</description>
        /// </item>
        /// <item>
        /// <term>401</term>
        /// <description>Returned if the authentication credentials are incorrect or missing\nfrom the request.</description>
        /// </item>
        /// <item>
        /// <term>404</term>
        /// <description>Returned if the calling user does not have permission to view the\nrequested custom content or the custom content was not found.</description>
        /// </item>
        /// </list>
        /// </returns>
        [Headers("Accept: application/json")]
        [Get("/custom-content/{custom-content-id}/versions")]
        Task<IApiResponse<Response51>> GetCustomContentVersionsAsync([AliasAs("custom-content-id")] long custom_content_id, [Query, AliasAs("body-format")] CustomContentBodyRepresentation? body_format = default, [Query] string? cursor = default, [Query] int? limit = default, [Query] VersionSortOrder? sort = default, CancellationToken cancellationToken = default);

        /// <summary>Get version details for custom content version</summary>
        /// <remarks>
        /// Retrieves version details for the specified custom content and version number.
        /// 
        /// **[Permissions](https://confluence.atlassian.com/x/_AozKw) required**:
        /// Permission to view the page.
        /// </remarks>
        /// <param name="custom_content_id">The ID of the custom content for which version details should be returned.</param>
        /// <param name="version_number">The version number of the custom content to be returned.</param>
        /// <returns>
        /// A <see cref="Task"/> representing the <see cref="IApiResponse"/> instance containing the result:
        /// <list type="table">
        /// <listheader>
        /// <term>Status</term>
        /// <description>Description</description>
        /// </listheader>
        /// <item>
        /// <term>200</term>
        /// <description>Returned if the requested version details are successfully retrieved.</description>
        /// </item>
        /// <item>
        /// <term>400</term>
        /// <description>Returned if an invalid request is provided.</description>
        /// </item>
        /// <item>
        /// <term>401</term>
        /// <description>Returned if the authentication credentials are incorrect or missing\nfrom the request.</description>
        /// </item>
        /// <item>
        /// <term>404</term>
        /// <description>Returned if the calling user does not have permission to view the\nspecified custom content, the custom content was not found, or the version number does not exist.</description>
        /// </item>
        /// </list>
        /// </returns>
        [Headers("Accept: application/json")]
        [Get("/custom-content/{custom-content-id}/versions/{version-number}")]
        Task<IApiResponse<DetailedVersion>> GetCustomContentVersionDetailsAsync([AliasAs("custom-content-id")] long custom_content_id, [AliasAs("version-number")] long version_number, CancellationToken cancellationToken = default);

        /// <summary>Get footer comment versions</summary>
        /// <remarks>
        /// Retrieves the versions of the specified footer comment.
        /// 
        /// **[Permissions](https://confluence.atlassian.com/x/_AozKw) required**:
        /// Permission to view the content of the page or blog post and its corresponding space.
        /// </remarks>
        /// <param name="id">The ID of the footer comment for which versions should be returned</param>
        /// <param name="body_format">The content format types to be returned in the `body` field of the response. If available, the representation will be available under a response field of the same name under the `body` field.</param>
        /// <param name="cursor">Used for pagination, this opaque cursor will be returned in the `next` URL in the `Link` response header. Use the relative URL in the `Link` header to retrieve the `next` set of results.</param>
        /// <param name="limit">Maximum number of versions per result to return. If more results exist, use the `Link` header to retrieve a relative URL that will return the next set of results.</param>
        /// <param name="sort">Used to sort the result by a particular field.</param>
        /// <returns>
        /// A <see cref="Task"/> representing the <see cref="IApiResponse"/> instance containing the result:
        /// <list type="table">
        /// <listheader>
        /// <term>Status</term>
        /// <description>Description</description>
        /// </listheader>
        /// <item>
        /// <term>200</term>
        /// <description>Returned if the requested footer comment versions are returned.</description>
        /// </item>
        /// <item>
        /// <term>400</term>
        /// <description>Returned if an invalid request is provided.</description>
        /// </item>
        /// <item>
        /// <term>401</term>
        /// <description>Returned if the authentication credentials are incorrect or missing\nfrom the request.</description>
        /// </item>
        /// <item>
        /// <term>404</term>
        /// <description>Returned if the calling user does not have permission to view the specified page\nor blog post, the footer comment was not found, or the version number does not exist.</description>
        /// </item>
        /// </list>
        /// </returns>
        [Headers("Accept: application/json")]
        [Get("/footer-comments/{id}/versions")]
        Task<IApiResponse<Response70>> GetFooterCommentVersionsAsync(long id, [Query, AliasAs("body-format")] PrimaryBodyRepresentation? body_format = default, [Query] string? cursor = default, [Query] int? limit = default, [Query] VersionSortOrder? sort = default, CancellationToken cancellationToken = default);

        /// <summary>Get version details for footer comment version</summary>
        /// <remarks>
        /// Retrieves version details for the specified footer comment version.
        /// 
        /// **[Permissions](https://confluence.atlassian.com/x/_AozKw) required**:
        /// Permission to view the content of the page or blog post and its corresponding space.
        /// </remarks>
        /// <param name="id">The ID of the footer comment for which version details should be returned.</param>
        /// <param name="version_number">The version number of the footer comment to be returned.</param>
        /// <returns>
        /// A <see cref="Task"/> representing the <see cref="IApiResponse"/> instance containing the result:
        /// <list type="table">
        /// <listheader>
        /// <term>Status</term>
        /// <description>Description</description>
        /// </listheader>
        /// <item>
        /// <term>200</term>
        /// <description>Returned if the requested version details are successfully retrieved.</description>
        /// </item>
        /// <item>
        /// <term>400</term>
        /// <description>Returned if an invalid request is provided.</description>
        /// </item>
        /// <item>
        /// <term>401</term>
        /// <description>Returned if the authentication credentials are incorrect or missing\nfrom the request.</description>
        /// </item>
        /// <item>
        /// <term>404</term>
        /// <description>Returned if the calling user does not have permission to view the specified page\nor blog post, the footer comment was not found, or the version number does not exist.</description>
        /// </item>
        /// </list>
        /// </returns>
        [Headers("Accept: application/json")]
        [Get("/footer-comments/{id}/versions/{version-number}")]
        Task<IApiResponse<DetailedVersion>> GetFooterCommentVersionDetailsAsync(long id, [AliasAs("version-number")] long version_number, CancellationToken cancellationToken = default);

        /// <summary>Get inline comment versions</summary>
        /// <remarks>
        /// Retrieves the versions of the specified inline comment.
        /// 
        /// **[Permissions](https://confluence.atlassian.com/x/_AozKw) required**:
        /// Permission to view the content of the page or blog post and its corresponding space.
        /// </remarks>
        /// <param name="id">The ID of the inline comment for which versions should be returned</param>
        /// <param name="body_format">The content format types to be returned in the `body` field of the response. If available, the representation will be available under a response field of the same name under the `body` field.</param>
        /// <param name="cursor">Used for pagination, this opaque cursor will be returned in the `next` URL in the `Link` response header. Use the relative URL in the `Link` header to retrieve the `next` set of results.</param>
        /// <param name="limit">Maximum number of versions per result to return. If more results exist, use the `Link` header to retrieve a relative URL that will return the next set of results.</param>
        /// <param name="sort">Used to sort the result by a particular field.</param>
        /// <returns>
        /// A <see cref="Task"/> representing the <see cref="IApiResponse"/> instance containing the result:
        /// <list type="table">
        /// <listheader>
        /// <term>Status</term>
        /// <description>Description</description>
        /// </listheader>
        /// <item>
        /// <term>200</term>
        /// <description>Returned if the requested inline comment versions are returned.</description>
        /// </item>
        /// <item>
        /// <term>400</term>
        /// <description>Returned if an invalid request is provided.</description>
        /// </item>
        /// <item>
        /// <term>401</term>
        /// <description>Returned if the authentication credentials are incorrect or missing\nfrom the request.</description>
        /// </item>
        /// <item>
        /// <term>404</term>
        /// <description>Returned if the calling user does not have permission to view the specified page\nor blog post, the inline comment was not found, or the version number does not exist.</description>
        /// </item>
        /// </list>
        /// </returns>
        [Headers("Accept: application/json")]
        [Get("/inline-comments/{id}/versions")]
        Task<IApiResponse<Response77>> GetInlineCommentVersionsAsync(long id, [Query, AliasAs("body-format")] PrimaryBodyRepresentation? body_format = default, [Query] string? cursor = default, [Query] int? limit = default, [Query] VersionSortOrder? sort = default, CancellationToken cancellationToken = default);

        /// <summary>Get version details for inline comment version</summary>
        /// <remarks>
        /// Retrieves version details for the specified inline comment version.
        /// 
        /// **[Permissions](https://confluence.atlassian.com/x/_AozKw) required**:
        /// Permission to view the content of the page or blog post and its corresponding space.
        /// </remarks>
        /// <param name="id">The ID of the inline comment for which version details should be returned.</param>
        /// <param name="version_number">The version number of the inline comment to be returned.</param>
        /// <returns>
        /// A <see cref="Task"/> representing the <see cref="IApiResponse"/> instance containing the result:
        /// <list type="table">
        /// <listheader>
        /// <term>Status</term>
        /// <description>Description</description>
        /// </listheader>
        /// <item>
        /// <term>200</term>
        /// <description>Returned if the requested version details are successfully retrieved.</description>
        /// </item>
        /// <item>
        /// <term>400</term>
        /// <description>Returned if an invalid request is provided.</description>
        /// </item>
        /// <item>
        /// <term>401</term>
        /// <description>Returned if the authentication credentials are incorrect or missing\nfrom the request.</description>
        /// </item>
        /// <item>
        /// <term>404</term>
        /// <description>Returned if the calling user does not have permission to view the specified page\nor blog post, the inline comment was not found, or the version number does not exist.</description>
        /// </item>
        /// </list>
        /// </returns>
        [Headers("Accept: application/json")]
        [Get("/inline-comments/{id}/versions/{version-number}")]
        Task<IApiResponse<DetailedVersion>> GetInlineCommentVersionDetailsAsync(long id, [AliasAs("version-number")] long version_number, CancellationToken cancellationToken = default);
    }

    /// <summary>Get attachment comments</summary>
    [System.CodeDom.Compiler.GeneratedCode("Refitter", "1.0.0.0")]
    public partial interface ICommentApi
    {
        /// <summary>Get attachment comments</summary>
        /// <remarks>
        /// Returns the comments of the specific attachment.
        /// The number of results is limited by the `limit` parameter and additional results (if available) will be available through
        /// the `next` URL present in the `Link` response header.
        /// 
        /// **[Permissions](https://confluence.atlassian.com/x/_AozKw) required**:
        /// Permission to view the attachment and its corresponding containers.
        /// </remarks>
        /// <param name="id">The ID of the attachment for which comments should be returned.</param>
        /// <param name="body_format">The content format type to be returned in the `body` field of the response. If available, the representation will be available under a response field of the same name under the `body` field.</param>
        /// <param name="cursor">Used for pagination, this opaque cursor will be returned in the `next` URL in the `Link` response header. Use the relative URL in the `Link` header to retrieve the `next` set of results.</param>
        /// <param name="limit">Maximum number of comments per result to return. If more results exist, use the `Link` header to retrieve a relative URL that will return the next set of results.</param>
        /// <param name="sort">Used to sort the result by a particular field.</param>
        /// <param name="version">Version number of the attachment to retrieve comments for. If no version provided, retrieves comments for the latest version.</param>
        /// <returns>
        /// A <see cref="Task"/> representing the <see cref="IApiResponse"/> instance containing the result:
        /// <list type="table">
        /// <listheader>
        /// <term>Status</term>
        /// <description>Description</description>
        /// </listheader>
        /// <item>
        /// <term>200</term>
        /// <description>Returned if the attachment comments were successfully retrieved</description>
        /// </item>
        /// <item>
        /// <term>400</term>
        /// <description>Returned if an invalid request is provided.</description>
        /// </item>
        /// <item>
        /// <term>401</term>
        /// <description>Returned if the authentication credentials are incorrect or missing\nfrom the request.</description>
        /// </item>
        /// <item>
        /// <term>404</term>
        /// <description>Returned if the calling user does not have permission to view the\nattachment or associated containers.</description>
        /// </item>
        /// </list>
        /// </returns>
        [Headers("Accept: application/json")]
        [Get("/attachments/{id}/footer-comments")]
        Task<IApiResponse<Response6>> GetAttachmentCommentsAsync(string id, [Query, AliasAs("body-format")] PrimaryBodyRepresentation? body_format = default, [Query] string? cursor = default, [Query] int? limit = default, [Query] CommentSortOrder? sort = default, [Query] long? version = default, CancellationToken cancellationToken = default);

        /// <summary>Get custom content comments</summary>
        /// <remarks>
        /// Returns the comments of the specific custom content.
        /// The number of results is limited by the `limit` parameter and additional results (if available) will be available through
        /// the `next` URL present in the `Link` response header.
        /// 
        /// **[Permissions](https://confluence.atlassian.com/x/_AozKw) required**:
        /// Permission to view the custom content and its corresponding containers.
        /// </remarks>
        /// <param name="id">The ID of the custom content for which comments should be returned.</param>
        /// <param name="body_format">The content format type to be returned in the `body` field of the response. If available, the representation will be available under a response field of the same name under the `body` field.</param>
        /// <param name="cursor">Used for pagination, this opaque cursor will be returned in the `next` URL in the `Link` response header. Use the relative URL in the `Link` header to retrieve the `next` set of results.</param>
        /// <param name="limit">Maximum number of comments per result to return. If more results exist, use the `Link` header to retrieve a relative URL that will return the next set of results.</param>
        /// <param name="sort">Used to sort the result by a particular field.</param>
        /// <returns>
        /// A <see cref="Task"/> representing the <see cref="IApiResponse"/> instance containing the result:
        /// <list type="table">
        /// <listheader>
        /// <term>Status</term>
        /// <description>Description</description>
        /// </listheader>
        /// <item>
        /// <term>200</term>
        /// <description>Returned if the custom content comments were successfully retrieved</description>
        /// </item>
        /// <item>
        /// <term>400</term>
        /// <description>Returned if an invalid request is provided.</description>
        /// </item>
        /// <item>
        /// <term>401</term>
        /// <description>Returned if the authentication credentials are incorrect or missing\nfrom the request.</description>
        /// </item>
        /// <item>
        /// <term>404</term>
        /// <description>Returned if the calling user does not have permission to view the\ncustom content or associated containers.</description>
        /// </item>
        /// </list>
        /// </returns>
        [Headers("Accept: application/json")]
        [Get("/custom-content/{id}/footer-comments")]
        Task<IApiResponse<Response22>> GetCustomContentCommentsAsync(long id, [Query, AliasAs("body-format")] PrimaryBodyRepresentation? body_format = default, [Query] string? cursor = default, [Query] int? limit = default, [Query] CommentSortOrder? sort = default, CancellationToken cancellationToken = default);

        /// <summary>Get footer comments for page</summary>
        /// <remarks>
        /// Returns the root footer comments of specific page. The number of results is limited by the `limit` parameter and additional results (if available)
        /// will be available through the `next` URL present in the `Link` response header.
        /// 
        /// **[Permissions](https://confluence.atlassian.com/x/_AozKw) required**:
        /// Permission to view the content of the page and its corresponding space.
        /// </remarks>
        /// <param name="id">The ID of the page for which footer comments should be returned.</param>
        /// <param name="body_format">The content format type to be returned in the `body` field of the response. If available, the representation will be available under a response field of the same name under the `body` field.</param>
        /// <param name="sort">Used to sort the result by a particular field.</param>
        /// <param name="cursor">Used for pagination, this opaque cursor will be returned in the `next` URL in the `Link` response header. Use the relative URL in the `Link` header to retrieve the `next` set of results.</param>
        /// <param name="limit">Maximum number of footer comments per result to return. If more results exist, use the `Link` header to retrieve a relative URL that will return the next set of results.</param>
        /// <returns>
        /// A <see cref="Task"/> representing the <see cref="IApiResponse"/> instance containing the result:
        /// <list type="table">
        /// <listheader>
        /// <term>Status</term>
        /// <description>Description</description>
        /// </listheader>
        /// <item>
        /// <term>200</term>
        /// <description>Returned if the requested footer comments are returned.</description>
        /// </item>
        /// <item>
        /// <term>400</term>
        /// <description>Returned if an invalid request is provided.</description>
        /// </item>
        /// <item>
        /// <term>401</term>
        /// <description>Returned if the authentication credentials are incorrect or missing\nfrom the request.</description>
        /// </item>
        /// <item>
        /// <term>404</term>
        /// <description>Returned if the calling user does not have permission to view the\nrequested page or the page was not found.</description>
        /// </item>
        /// </list>
        /// </returns>
        [Headers("Accept: application/json")]
        [Get("/pages/{id}/footer-comments")]
        Task<IApiResponse<Response61>> GetPageFooterCommentsAsync(long id, [Query, AliasAs("body-format")] PrimaryBodyRepresentation? body_format = default, [Query] CommentSortOrder? sort = default, [Query] string? cursor = default, [Query] int? limit = default, CancellationToken cancellationToken = default);

        /// <summary>Get inline comments for page</summary>
        /// <remarks>
        /// Returns the root inline comments of specific page. The number of results is limited by the `limit` parameter and additional results (if available)
        /// will be available through the `next` URL present in the `Link` response header.
        /// 
        /// **[Permissions](https://confluence.atlassian.com/x/_AozKw) required**:
        /// Permission to view the content of the page and its corresponding space.
        /// </remarks>
        /// <param name="id">The ID of the page for which inline comments should be returned.</param>
        /// <param name="body_format">The content format type to be returned in the `body` field of the response. If available, the representation will be available under a response field of the same name under the `body` field.</param>
        /// <param name="sort">Used to sort the result by a particular field.</param>
        /// <param name="cursor">Used for pagination, this opaque cursor will be returned in the `next` URL in the `Link` response header. Use the relative URL in the `Link` header to retrieve the `next` set of results.</param>
        /// <param name="limit">Maximum number of inline comments per result to return. If more results exist, use the `Link` header to retrieve a relative URL that will return the next set of results.</param>
        /// <returns>
        /// A <see cref="Task"/> representing the <see cref="IApiResponse"/> instance containing the result:
        /// <list type="table">
        /// <listheader>
        /// <term>Status</term>
        /// <description>Description</description>
        /// </listheader>
        /// <item>
        /// <term>200</term>
        /// <description>Returned if the requested inline comments are returned.</description>
        /// </item>
        /// <item>
        /// <term>400</term>
        /// <description>Returned if an invalid request is provided.</description>
        /// </item>
        /// <item>
        /// <term>401</term>
        /// <description>Returned if the authentication credentials are incorrect or missing\nfrom the request.</description>
        /// </item>
        /// <item>
        /// <term>404</term>
        /// <description>Returned if the calling user does not have permission to view the\nrequested page or the page was not found.</description>
        /// </item>
        /// </list>
        /// </returns>
        [Headers("Accept: application/json")]
        [Get("/pages/{id}/inline-comments")]
        Task<IApiResponse<Response62>> GetPageInlineCommentsAsync(long id, [Query, AliasAs("body-format")] PrimaryBodyRepresentation? body_format = default, [Query] CommentSortOrder? sort = default, [Query] string? cursor = default, [Query] int? limit = default, CancellationToken cancellationToken = default);

        /// <summary>Get footer comments for blog post</summary>
        /// <remarks>
        /// Returns the root footer comments of specific blog post. The number of results is limited by the `limit` parameter and additional results (if available)
        /// will be available through the `next` URL present in the `Link` response header.
        /// 
        /// **[Permissions](https://confluence.atlassian.com/x/_AozKw) required**:
        /// Permission to view the content of the blog post and its corresponding space.
        /// </remarks>
        /// <param name="id">The ID of the blog post for which footer comments should be returned.</param>
        /// <param name="body_format">The content format type to be returned in the `body` field of the response. If available, the representation will be available under a response field of the same name under the `body` field.</param>
        /// <param name="sort">Used to sort the result by a particular field.</param>
        /// <param name="cursor">Used for pagination, this opaque cursor will be returned in the `next` URL in the `Link` response header. Use the relative URL in the `Link` header to retrieve the `next` set of results.</param>
        /// <param name="limit">Maximum number of footer comments per result to return. If more results exist, use the `Link` header to retrieve a relative URL that will return the next set of results.</param>
        /// <returns>
        /// A <see cref="Task"/> representing the <see cref="IApiResponse"/> instance containing the result:
        /// <list type="table">
        /// <listheader>
        /// <term>Status</term>
        /// <description>Description</description>
        /// </listheader>
        /// <item>
        /// <term>200</term>
        /// <description>Returned if the requested footer comments are returned.</description>
        /// </item>
        /// <item>
        /// <term>400</term>
        /// <description>Returned if an invalid request is provided.</description>
        /// </item>
        /// <item>
        /// <term>401</term>
        /// <description>Returned if the authentication credentials are incorrect or missing\nfrom the request.</description>
        /// </item>
        /// <item>
        /// <term>404</term>
        /// <description>Returned if the calling user does not have permission to view the\nrequested blog post or the blog post was not found.</description>
        /// </item>
        /// </list>
        /// </returns>
        [Headers("Accept: application/json")]
        [Get("/blogposts/{id}/footer-comments")]
        Task<IApiResponse<Response63>> GetBlogPostFooterCommentsAsync(long id, [Query, AliasAs("body-format")] PrimaryBodyRepresentation? body_format = default, [Query] CommentSortOrder? sort = default, [Query] string? cursor = default, [Query] int? limit = default, CancellationToken cancellationToken = default);

        /// <summary>Get inline comments for blog post</summary>
        /// <remarks>
        /// Returns the root inline comments of specific blog post. The number of results is limited by the `limit` parameter and additional results (if available)
        /// will be available through the `next` URL present in the `Link` response header.
        /// 
        /// **[Permissions](https://confluence.atlassian.com/x/_AozKw) required**:
        /// Permission to view the content of the blog post and its corresponding space.
        /// </remarks>
        /// <param name="id">The ID of the blog post for which inline comments should be returned.</param>
        /// <param name="body_format">The content format type to be returned in the `body` field of the response. If available, the representation will be available under a response field of the same name under the `body` field.</param>
        /// <param name="sort">Used to sort the result by a particular field.</param>
        /// <param name="cursor">Used for pagination, this opaque cursor will be returned in the `next` URL in the `Link` response header. Use the relative URL in the `Link` header to retrieve the `next` set of results.</param>
        /// <param name="limit">Maximum number of inline comments per result to return. If more results exist, use the `Link` header to retrieve a relative URL that will return the next set of results.</param>
        /// <returns>
        /// A <see cref="Task"/> representing the <see cref="IApiResponse"/> instance containing the result:
        /// <list type="table">
        /// <listheader>
        /// <term>Status</term>
        /// <description>Description</description>
        /// </listheader>
        /// <item>
        /// <term>200</term>
        /// <description>Returned if the requested inline comments are returned.</description>
        /// </item>
        /// <item>
        /// <term>400</term>
        /// <description>Returned if an invalid request is provided.</description>
        /// </item>
        /// <item>
        /// <term>401</term>
        /// <description>Returned if the authentication credentials are incorrect or missing\nfrom the request.</description>
        /// </item>
        /// <item>
        /// <term>404</term>
        /// <description>Returned if the calling user does not have permission to view the\nrequested blog post or the blog post was not found.</description>
        /// </item>
        /// </list>
        /// </returns>
        [Headers("Accept: application/json")]
        [Get("/blogposts/{id}/inline-comments")]
        Task<IApiResponse<Response64>> GetBlogPostInlineCommentsAsync(long id, [Query, AliasAs("body-format")] PrimaryBodyRepresentation? body_format = default, [Query] CommentSortOrder? sort = default, [Query] string? cursor = default, [Query] int? limit = default, CancellationToken cancellationToken = default);

        /// <summary>Get footer comments</summary>
        /// <remarks>
        /// Returns all footer comments. The number of results is limited by the `limit` parameter and additional results (if available)
        /// will be available through the `next` URL present in the `Link` response header.
        /// 
        /// **[Permissions](https://confluence.atlassian.com/x/_AozKw) required**:
        /// Permission to view the content of the container and its corresponding space.
        /// </remarks>
        /// <param name="body_format">The content format type to be returned in the `body` field of the response. If available, the representation will be available under a response field of the same name under the `body` field.</param>
        /// <param name="sort">Used to sort the result by a particular field.</param>
        /// <param name="cursor">Used for pagination, this opaque cursor will be returned in the `next` URL in the `Link` response header. Use the relative URL in the `Link` header to retrieve the `next` set of results.</param>
        /// <param name="limit">Maximum number of footer comments per result to return. If more results exist, use the `Link` header to retrieve a relative URL that will return the next set of results.</param>
        /// <returns>
        /// A <see cref="Task"/> representing the <see cref="IApiResponse"/> instance containing the result:
        /// <list type="table">
        /// <listheader>
        /// <term>Status</term>
        /// <description>Description</description>
        /// </listheader>
        /// <item>
        /// <term>200</term>
        /// <description>Returned if the requested footer comments are returned.</description>
        /// </item>
        /// <item>
        /// <term>400</term>
        /// <description>Returned if an invalid request is provided.</description>
        /// </item>
        /// <item>
        /// <term>401</term>
        /// <description>Returned if the authentication credentials are incorrect or missing\nfrom the request.</description>
        /// </item>
        /// </list>
        /// </returns>
        [Headers("Accept: application/json")]
        [Get("/footer-comments")]
        Task<IApiResponse<Response65>> GetFooterCommentsAsync([Query, AliasAs("body-format")] PrimaryBodyRepresentation? body_format = default, [Query] CommentSortOrder? sort = default, [Query] string? cursor = default, [Query] int? limit = default, CancellationToken cancellationToken = default);

        /// <summary>Create footer comment</summary>
        /// <remarks>
        /// Create a footer comment.
        /// 
        /// The footer comment can be made against several locations:
        /// - at the top level (specifying pageId or blogPostId in the request body)
        /// - as a reply (specifying parentCommentId in the request body)
        /// - against an attachment (note: this is different than the comments added via the attachment properties page on the UI, which are referred to as version comments)
        /// - against a custom content
        /// 
        /// **[Permissions](https://confluence.atlassian.com/x/_AozKw) required**:
        /// Permission to view the content of the page or blogpost and its corresponding space. Permission to create comments in the space.
        /// </remarks>
        /// <param name="body">The footer comment to be created</param>
        /// <returns>
        /// A <see cref="Task"/> representing the <see cref="IApiResponse"/> instance containing the result:
        /// <list type="table">
        /// <listheader>
        /// <term>Status</term>
        /// <description>Description</description>
        /// </listheader>
        /// <item>
        /// <term>201</term>
        /// <description>Returned if the footer comment is created.</description>
        /// </item>
        /// <item>
        /// <term>400</term>
        /// <description>Returned if an invalid request is provided</description>
        /// </item>
        /// <item>
        /// <term>401</term>
        /// <description>Returned if the authentication credentials are incorrect or missing\nfrom the request.</description>
        /// </item>
        /// <item>
        /// <term>404</term>
        /// <description>Returned if:\n- The page, blog post, parent comment, or attachment was not found\n- The calling user does not have permission to view the parent page/blog post\n- The user is forbidden from creating a comment tied to a resource they are allowed to view</description>
        /// </item>
        /// </list>
        /// </returns>
        [Headers("Accept: application/json")]
        [Post("/footer-comments")]
        Task<IApiResponse<Response66>> CreateFooterCommentAsync([Body] CreateFooterCommentModel body, CancellationToken cancellationToken = default);

        /// <summary>Get footer comment by id</summary>
        /// <remarks>
        /// Retrieves a footer comment by id
        /// 
        /// **[Permissions](https://confluence.atlassian.com/x/_AozKw) required**:
        /// Permission to view the content of the container and its corresponding space.
        /// </remarks>
        /// <param name="comment_id">The ID of the comment to be retrieved.</param>
        /// <param name="body_format">The content format type to be returned in the `body` field of the response. If available, the representation will be available under a response field of the same name under the `body` field.</param>
        /// <param name="version">Allows you to retrieve a previously published version. Specify the previous version's number to retrieve its details.</param>
        /// <param name="include_properties">
        /// Includes content properties associated with this footer comment in the response.
        /// The number of results will be limited to 50 and sorted in the default sort order.
        /// A `meta` and `_links` property will be present to indicate if more results are available and a link to retrieve the rest of the results.
        /// </param>
        /// <param name="include_operations">
        /// Includes operations associated with this footer comment in the response.
        /// The number of results will be limited to 50 and sorted in the default sort order.
        /// A `meta` and `_links` property will be present to indicate if more results are available and a link to retrieve the rest of the results.
        /// </param>
        /// <param name="include_likes">
        /// Includes likes associated with this footer comment in the response.
        /// The number of results will be limited to 50 and sorted in the default sort order.
        /// A `meta` and `_links` property will be present to indicate if more results are available and a link to retrieve the rest of the results.
        /// </param>
        /// <param name="include_versions">
        /// Includes versions associated with this footer comment in the response.
        /// The number of results will be limited to 50 and sorted in the default sort order.
        /// A `meta` and `_links` property will be present to indicate if more results are available and a link to retrieve the rest of the results.
        /// </param>
        /// <param name="include_version">
        /// Includes the current version associated with this footer comment in the response.
        /// By default this is included and can be omitted by setting the value to `false`.
        /// </param>
        /// <returns>
        /// A <see cref="Task"/> representing the <see cref="IApiResponse"/> instance containing the result:
        /// <list type="table">
        /// <listheader>
        /// <term>Status</term>
        /// <description>Description</description>
        /// </listheader>
        /// <item>
        /// <term>200</term>
        /// <description>Returned if the footer comment is successfully retrieved.</description>
        /// </item>
        /// <item>
        /// <term>400</term>
        /// <description>Returned if an invalid request is provided.</description>
        /// </item>
        /// <item>
        /// <term>401</term>
        /// <description>Returned if the authentication credentials are incorrect or missing\nfrom the request.</description>
        /// </item>
        /// <item>
        /// <term>404</term>
        /// <description>Returned if the calling user does not have permission to view the\ncomment or the comment was not found.</description>
        /// </item>
        /// </list>
        /// </returns>
        [Headers("Accept: application/json")]
        [Get("/footer-comments/{comment-id}")]
        Task<IApiResponse<Response67>> GetFooterCommentByIdAsync([AliasAs("comment-id")] long comment_id, [Query, AliasAs("body-format")] PrimaryBodyRepresentationSingle? body_format = default, [Query] int? version = default, [Query, AliasAs("include-properties")] bool? include_properties = default, [Query, AliasAs("include-operations")] bool? include_operations = default, [Query, AliasAs("include-likes")] bool? include_likes = default, [Query, AliasAs("include-versions")] bool? include_versions = default, [Query, AliasAs("include-version")] bool? include_version = default, CancellationToken cancellationToken = default);

        /// <summary>Update footer comment</summary>
        /// <remarks>
        /// Update a footer comment. This can be used to update the body text of a comment.
        /// 
        /// **[Permissions](https://confluence.atlassian.com/x/_AozKw) required**:
        /// Permission to view the content of the page or blogpost and its corresponding space. Permission to create comments in the space.
        /// </remarks>
        /// <param name="comment_id">The ID of the comment to be retrieved.</param>
        /// <param name="body">The footer comment to be created</param>
        /// <returns>
        /// A <see cref="Task"/> representing the <see cref="IApiResponse"/> instance containing the result:
        /// <list type="table">
        /// <listheader>
        /// <term>Status</term>
        /// <description>Description</description>
        /// </listheader>
        /// <item>
        /// <term>200</term>
        /// <description>Returned if the footer comment is updated successfully</description>
        /// </item>
        /// <item>
        /// <term>400</term>
        /// <description>Returned if an invalid request is provided</description>
        /// </item>
        /// <item>
        /// <term>401</term>
        /// <description>Returned if the authentication credentials are incorrect or missing\nfrom the request.</description>
        /// </item>
        /// <item>
        /// <term>404</term>
        /// <description>Returned if:\n- The comment was not found\n- The calling user does not have permission to view the comment\n- The user is forbidden from updating a comment tied to a resource they are allowed to view</description>
        /// </item>
        /// </list>
        /// </returns>
        [Headers("Accept: application/json")]
        [Put("/footer-comments/{comment-id}")]
        Task<IApiResponse<FooterCommentModel>> UpdateFooterCommentAsync([AliasAs("comment-id")] long comment_id, [Body] Body body, CancellationToken cancellationToken = default);

        /// <summary>Delete footer comment</summary>
        /// <remarks>
        /// Deletes a footer comment. This is a permanent deletion and cannot be reverted.
        /// 
        /// **[Permissions](https://confluence.atlassian.com/x/_AozKw) required**:
        /// Permission to view the content of the page or blogpost and its corresponding space. Permission to delete comments in the space.
        /// </remarks>
        /// <param name="comment_id">The ID of the comment to be retrieved.</param>
        /// <returns>
        /// A <see cref="Task"/> representing the <see cref="IApiResponse"/> instance containing the result:
        /// <list type="table">
        /// <listheader>
        /// <term>Status</term>
        /// <description>Description</description>
        /// </listheader>
        /// <item>
        /// <term>204</term>
        /// <description>Returned if the footer comment is deleted.</description>
        /// </item>
        /// <item>
        /// <term>400</term>
        /// <description>Returned if an invalid request is provided.</description>
        /// </item>
        /// <item>
        /// <term>401</term>
        /// <description>Returned if the authentication credentials are incorrect or missing\nfrom the request.</description>
        /// </item>
        /// <item>
        /// <term>404</term>
        /// <description>Returned if:\n- The comment was not found\n- The calling user does not have permission to view the comment\n- The user is forbidden from deleting a comment tied to a resource they are allowed to view</description>
        /// </item>
        /// </list>
        /// </returns>
        [Delete("/footer-comments/{comment-id}")]
        Task<IApiResponse> DeleteFooterCommentAsync([AliasAs("comment-id")] long comment_id, CancellationToken cancellationToken = default);

        /// <summary>Get children footer comments</summary>
        /// <remarks>
        /// Returns the children footer comments of specific comment. The number of results is limited by the `limit` parameter and additional results (if available)
        /// will be available through the `next` URL present in the `Link` response header.
        /// 
        /// **[Permissions](https://confluence.atlassian.com/x/_AozKw) required**:
        /// Permission to view the content of the page and its corresponding space.
        /// </remarks>
        /// <param name="id">The ID of the parent comment for which footer comment children should be returned.</param>
        /// <param name="body_format">The content format type to be returned in the `body` field of the response. If available, the representation will be available under a response field of the same name under the `body` field.</param>
        /// <param name="sort">Used to sort the result by a particular field.</param>
        /// <param name="cursor">Used for pagination, this opaque cursor will be returned in the `next` URL in the `Link` response header. Use the relative URL in the `Link` header to retrieve the `next` set of results.</param>
        /// <param name="limit">Maximum number of footer comments per result to return. If more results exist, use the `Link` header to retrieve a relative URL that will return the next set of results.</param>
        /// <returns>
        /// A <see cref="Task"/> representing the <see cref="IApiResponse"/> instance containing the result:
        /// <list type="table">
        /// <listheader>
        /// <term>Status</term>
        /// <description>Description</description>
        /// </listheader>
        /// <item>
        /// <term>200</term>
        /// <description>Returned if the requested footer comments are returned.</description>
        /// </item>
        /// <item>
        /// <term>400</term>
        /// <description>Returned if an invalid request is provided.</description>
        /// </item>
        /// <item>
        /// <term>401</term>
        /// <description>Returned if the authentication credentials are incorrect or missing\nfrom the request.</description>
        /// </item>
        /// <item>
        /// <term>404</term>
        /// <description>Returned if the calling user does not have permission to view the\nparent page/blog post or the page/blog post was not found.</description>
        /// </item>
        /// </list>
        /// </returns>
        [Headers("Accept: application/json")]
        [Get("/footer-comments/{id}/children")]
        Task<IApiResponse<Response68>> GetFooterCommentChildrenAsync(long id, [Query, AliasAs("body-format")] PrimaryBodyRepresentation? body_format = default, [Query] CommentSortOrder? sort = default, [Query] string? cursor = default, [Query] int? limit = default, CancellationToken cancellationToken = default);

        /// <summary>Get inline comments</summary>
        /// <remarks>
        /// Returns all inline comments. The number of results is limited by the `limit` parameter and additional results (if available)
        /// will be available through the `next` URL present in the `Link` response header.
        /// 
        /// **[Permissions](https://confluence.atlassian.com/x/_AozKw) required**:
        /// Permission to view the content of the page and its corresponding space.
        /// </remarks>
        /// <param name="body_format">The content format type to be returned in the `body` field of the response. If available, the representation will be available under a response field of the same name under the `body` field.</param>
        /// <param name="sort">Used to sort the result by a particular field.</param>
        /// <param name="cursor">Used for pagination, this opaque cursor will be returned in the `next` URL in the `Link` response header. Use the relative URL in the `Link` header to retrieve the `next` set of results.</param>
        /// <param name="limit">Maximum number of footer comments per result to return. If more results exist, use the `Link` header to retrieve a relative URL that will return the next set of results.</param>
        /// <returns>
        /// A <see cref="Task"/> representing the <see cref="IApiResponse"/> instance containing the result:
        /// <list type="table">
        /// <listheader>
        /// <term>Status</term>
        /// <description>Description</description>
        /// </listheader>
        /// <item>
        /// <term>200</term>
        /// <description>Returned if the requested inline comments are returned.</description>
        /// </item>
        /// <item>
        /// <term>400</term>
        /// <description>Returned if an invalid request is provided.</description>
        /// </item>
        /// <item>
        /// <term>401</term>
        /// <description>Returned if the authentication credentials are incorrect or missing\nfrom the request.</description>
        /// </item>
        /// </list>
        /// </returns>
        [Headers("Accept: application/json")]
        [Get("/inline-comments")]
        Task<IApiResponse<Response71>> GetInlineCommentsAsync([Query, AliasAs("body-format")] PrimaryBodyRepresentation? body_format = default, [Query] CommentSortOrder? sort = default, [Query] string? cursor = default, [Query] int? limit = default, CancellationToken cancellationToken = default);

        /// <summary>Create inline comment</summary>
        /// <remarks>
        /// Create an inline comment. This can be at the top level (specifying pageId or blogPostId in the request body)
        /// or as a reply (specifying parentCommentId in the request body). Note the inlineCommentProperties object in the
        /// request body is used to select the text the inline comment should be tied to. This is what determines the text
        /// highlighting when viewing a page in Confluence.
        /// 
        /// **[Permissions](https://confluence.atlassian.com/x/_AozKw) required**:
        /// Permission to view the content of the page or blogpost and its corresponding space. Permission to create comments in the space.
        /// </remarks>
        /// <param name="body">The inline comment to be created</param>
        /// <returns>
        /// A <see cref="Task"/> representing the <see cref="IApiResponse"/> instance containing the result:
        /// <list type="table">
        /// <listheader>
        /// <term>Status</term>
        /// <description>Description</description>
        /// </listheader>
        /// <item>
        /// <term>201</term>
        /// <description>Returned if the inline comment is created.</description>
        /// </item>
        /// <item>
        /// <term>400</term>
        /// <description>Returned if an invalid request is provided.</description>
        /// </item>
        /// <item>
        /// <term>401</term>
        /// <description>Returned if the authentication credentials are incorrect or missing\nfrom the request.</description>
        /// </item>
        /// <item>
        /// <term>404</term>
        /// <description>Returned if:\n- The page/blog post was not found\n- The calling user does not have permission to view the parent page/blog post\n- The user is forbidden from creating a comment tied to a resource they are allowed to view</description>
        /// </item>
        /// </list>
        /// </returns>
        [Headers("Accept: application/json")]
        [Post("/inline-comments")]
        Task<IApiResponse<Response72>> CreateInlineCommentAsync([Body] CreateInlineCommentModel body, CancellationToken cancellationToken = default);

        /// <summary>Get inline comment by id</summary>
        /// <remarks>
        /// Retrieves an inline comment by id
        /// 
        /// **[Permissions](https://confluence.atlassian.com/x/_AozKw) required**:
        /// Permission to view the content of the page or blogpost and its corresponding space.
        /// </remarks>
        /// <param name="comment_id">The ID of the comment to be retrieved.</param>
        /// <param name="body_format">The content format type to be returned in the `body` field of the response. If available, the representation will be available under a response field of the same name under the `body` field.</param>
        /// <param name="version">Allows you to retrieve a previously published version. Specify the previous version's number to retrieve its details.</param>
        /// <param name="include_properties">
        /// Includes content properties associated with this inline comment in the response.
        /// The number of results will be limited to 50 and sorted in the default sort order.
        /// A `meta` and `_links` property will be present to indicate if more results are available and a link to retrieve the rest of the results.
        /// </param>
        /// <param name="include_operations">
        /// Includes operations associated with this inline comment in the response.
        /// The number of results will be limited to 50 and sorted in the default sort order.
        /// A `meta` and `_links` property will be present to indicate if more results are available and a link to retrieve the rest of the results.
        /// </param>
        /// <param name="include_likes">
        /// Includes likes associated with this inline comment in the response.
        /// The number of results will be limited to 50 and sorted in the default sort order.
        /// A `meta` and `_links` property will be present to indicate if more results are available and a link to retrieve the rest of the results.
        /// </param>
        /// <param name="include_versions">
        /// Includes versions associated with this inline comment in the response.
        /// The number of results will be limited to 50 and sorted in the default sort order.
        /// A `meta` and `_links` property will be present to indicate if more results are available and a link to retrieve the rest of the results.
        /// </param>
        /// <param name="include_version">
        /// Includes the current version associated with this inline comment in the response.
        /// By default this is included and can be omitted by setting the value to `false`.
        /// </param>
        /// <returns>
        /// A <see cref="Task"/> representing the <see cref="IApiResponse"/> instance containing the result:
        /// <list type="table">
        /// <listheader>
        /// <term>Status</term>
        /// <description>Description</description>
        /// </listheader>
        /// <item>
        /// <term>200</term>
        /// <description>Returned if the inline comment is successfully retrieved.</description>
        /// </item>
        /// <item>
        /// <term>400</term>
        /// <description>Returned if an invalid request is provided.</description>
        /// </item>
        /// <item>
        /// <term>401</term>
        /// <description>Returned if the authentication credentials are incorrect or missing\nfrom the request.</description>
        /// </item>
        /// <item>
        /// <term>404</term>
        /// <description>Returned if the calling user does not have permission to view the\ncomment or the comment was not found.</description>
        /// </item>
        /// </list>
        /// </returns>
        [Headers("Accept: application/json")]
        [Get("/inline-comments/{comment-id}")]
        Task<IApiResponse<Response73>> GetInlineCommentByIdAsync([AliasAs("comment-id")] long comment_id, [Query, AliasAs("body-format")] PrimaryBodyRepresentationSingle? body_format = default, [Query] int? version = default, [Query, AliasAs("include-properties")] bool? include_properties = default, [Query, AliasAs("include-operations")] bool? include_operations = default, [Query, AliasAs("include-likes")] bool? include_likes = default, [Query, AliasAs("include-versions")] bool? include_versions = default, [Query, AliasAs("include-version")] bool? include_version = default, CancellationToken cancellationToken = default);

        /// <summary>Update inline comment</summary>
        /// <remarks>
        /// Update an inline comment. This can be used to update the body text of a comment and/or to resolve the comment
        /// 
        /// **[Permissions](https://confluence.atlassian.com/x/_AozKw) required**:
        /// Permission to view the content of the page or blogpost and its corresponding space. Permission to create comments in the space.
        /// </remarks>
        /// <param name="comment_id">The ID of the comment to be retrieved.</param>
        /// <param name="body">The inline comment to be updated</param>
        /// <returns>
        /// A <see cref="Task"/> representing the <see cref="IApiResponse"/> instance containing the result:
        /// <list type="table">
        /// <listheader>
        /// <term>Status</term>
        /// <description>Description</description>
        /// </listheader>
        /// <item>
        /// <term>200</term>
        /// <description>Returned if the inline comment is updated successfully.</description>
        /// </item>
        /// <item>
        /// <term>400</term>
        /// <description>Returned if an invalid request is provided.</description>
        /// </item>
        /// <item>
        /// <term>401</term>
        /// <description>Returned if the authentication credentials are incorrect or missing\nfrom the request.</description>
        /// </item>
        /// <item>
        /// <term>404</term>
        /// <description>Returned if:\n- The comment was not found\n- The calling user does not have permission to view the comment\n- The user is forbidden from updating a comment tied to a resource they are allowed to view</description>
        /// </item>
        /// </list>
        /// </returns>
        [Headers("Accept: application/json")]
        [Put("/inline-comments/{comment-id}")]
        Task<IApiResponse<Response74>> UpdateInlineCommentAsync([AliasAs("comment-id")] long comment_id, [Body] UpdateInlineCommentModel body, CancellationToken cancellationToken = default);

        /// <summary>Delete inline comment</summary>
        /// <remarks>
        /// Deletes an inline comment. This is a permanent deletion and cannot be reverted.
        /// 
        /// **[Permissions](https://confluence.atlassian.com/x/_AozKw) required**:
        /// Permission to view the content of the page or blogpost and its corresponding space. Permission to delete comments in the space.
        /// </remarks>
        /// <param name="comment_id">The ID of the comment to be deleted.</param>
        /// <returns>
        /// A <see cref="Task"/> representing the <see cref="IApiResponse"/> instance containing the result:
        /// <list type="table">
        /// <listheader>
        /// <term>Status</term>
        /// <description>Description</description>
        /// </listheader>
        /// <item>
        /// <term>204</term>
        /// <description>Returned if the inline comment is deleted.</description>
        /// </item>
        /// <item>
        /// <term>400</term>
        /// <description>Returned if an invalid request is provided.</description>
        /// </item>
        /// <item>
        /// <term>401</term>
        /// <description>Returned if the authentication credentials are incorrect or missing\nfrom the request.</description>
        /// </item>
        /// <item>
        /// <term>404</term>
        /// <description>Returned if:\n- The comment was not found\n- The calling user does not have permission to view the comment\n- The user is forbidden from deleting a comment tied to a resource they are allowed to view</description>
        /// </item>
        /// </list>
        /// </returns>
        [Delete("/inline-comments/{comment-id}")]
        Task<IApiResponse> DeleteInlineCommentAsync([AliasAs("comment-id")] long comment_id, CancellationToken cancellationToken = default);

        /// <summary>Get children inline comments</summary>
        /// <remarks>
        /// Returns the children inline comments of specific comment. The number of results is limited by the `limit` parameter and additional results (if available)
        /// will be available through the `next` URL present in the `Link` response header.
        /// 
        /// **[Permissions](https://confluence.atlassian.com/x/_AozKw) required**:
        /// Permission to view the content of the page and its corresponding space.
        /// </remarks>
        /// <param name="id">The ID of the parent comment for which inline comment children should be returned.</param>
        /// <param name="body_format">The content format type to be returned in the `body` field of the response. If available, the representation will be available under a response field of the same name under the `body` field.</param>
        /// <param name="sort">Used to sort the result by a particular field.</param>
        /// <param name="cursor">Used for pagination, this opaque cursor will be returned in the `next` URL in the `Link` response header. Use the relative URL in the `Link` header to retrieve the `next` set of results.</param>
        /// <param name="limit">Maximum number of footer comments per result to return. If more results exist, use the `Link` header to retrieve a relative URL that will return the next set of results.</param>
        /// <returns>
        /// A <see cref="Task"/> representing the <see cref="IApiResponse"/> instance containing the result:
        /// <list type="table">
        /// <listheader>
        /// <term>Status</term>
        /// <description>Description</description>
        /// </listheader>
        /// <item>
        /// <term>200</term>
        /// <description>Returned if the requested footer comments are returned.</description>
        /// </item>
        /// <item>
        /// <term>400</term>
        /// <description>Returned if an invalid request is provided.</description>
        /// </item>
        /// <item>
        /// <term>401</term>
        /// <description>Returned if the authentication credentials are incorrect or missing\nfrom the request.</description>
        /// </item>
        /// <item>
        /// <term>404</term>
        /// <description>Returned if the calling user does not have permission to view the\nparent page/blog post or the page/blog post was not found.</description>
        /// </item>
        /// </list>
        /// </returns>
        [Headers("Accept: application/json")]
        [Get("/inline-comments/{id}/children")]
        Task<IApiResponse<Response75>> GetInlineCommentChildrenAsync(long id, [Query, AliasAs("body-format")] PrimaryBodyRepresentation? body_format = default, [Query] CommentSortOrder? sort = default, [Query] string? cursor = default, [Query] int? limit = default, CancellationToken cancellationToken = default);
    }

    /// <summary>Get blog posts</summary>
    [System.CodeDom.Compiler.GeneratedCode("Refitter", "1.0.0.0")]
    public partial interface IBlogPostApi
    {
        /// <summary>Get blog posts</summary>
        /// <remarks>
        /// Returns all blog posts. The number of results is limited by the `limit` parameter and additional results (if available)
        /// will be available through the `next` URL present in the `Link` response header.
        /// 
        /// **[Permissions](https://confluence.atlassian.com/x/_AozKw) required**:
        /// Permission to access the Confluence site ('Can use' global permission).
        /// Only blog posts that the user has permission to view will be returned.
        /// </remarks>
        /// <param name="id">Filter the results based on blog post ids. Multiple blog post ids can be specified as a comma-separated list.</param>
        /// <param name="space_id">Filter the results based on space ids. Multiple space ids can be specified as a comma-separated list.</param>
        /// <param name="sort">Used to sort the result by a particular field.</param>
        /// <param name="status">Filter the results to blog posts based on their status. By default, `current` is used.</param>
        /// <param name="title">Filter the results to blog posts based on their title.</param>
        /// <param name="body_format">The content format types to be returned in the `body` field of the response. If available, the representation will be available under a response field of the same name under the `body` field.</param>
        /// <param name="cursor">Used for pagination, this opaque cursor will be returned in the `next` URL in the `Link` response header. Use the relative URL in the `Link` header to retrieve the `next` set of results.</param>
        /// <param name="limit">Maximum number of blog posts per result to return. If more results exist, use the `Link` response header to retrieve a relative URL that will return the next set of results.</param>
        /// <returns>
        /// A <see cref="Task"/> representing the <see cref="IApiResponse"/> instance containing the result:
        /// <list type="table">
        /// <listheader>
        /// <term>Status</term>
        /// <description>Description</description>
        /// </listheader>
        /// <item>
        /// <term>200</term>
        /// <description>Returned if the requested blog posts are returned.</description>
        /// </item>
        /// <item>
        /// <term>400</term>
        /// <description>Returned if an invalid request is provided.</description>
        /// </item>
        /// <item>
        /// <term>401</term>
        /// <description>Returned if the authentication credentials are incorrect or missing\nfrom the request.</description>
        /// </item>
        /// </list>
        /// </returns>
        [Headers("Accept: application/json")]
        [Get("/blogposts")]
        Task<IApiResponse<Response7>> GetBlogPostsAsync([Query(CollectionFormat.Multi)] IEnumerable<long>? id = default, [Query(CollectionFormat.Multi), AliasAs("space-id")] IEnumerable<long>? space_id = default, [Query] BlogPostSortOrder? sort = default, [Query(CollectionFormat.Multi)] IEnumerable<Anonymous2>? status = default, [Query] string? title = default, [Query, AliasAs("body-format")] PrimaryBodyRepresentation? body_format = default, [Query] string? cursor = default, [Query] int? limit = default, CancellationToken cancellationToken = default);

        /// <summary>Create blog post</summary>
        /// <remarks>
        /// Creates a new blog post in the space specified by the spaceId.
        /// 
        /// By default this will create the blog post as a non-draft, unless the status is specified as draft.
        /// If creating a non-draft, the title must not be empty.
        /// 
        /// Currently only supports the storage representation specified in the body.representation enums below
        /// </remarks>
        /// <param name="@private">The blog post will be private. Only the user who creates this blog post will have permission to view and edit one.</param>
        /// <returns>
        /// A <see cref="Task"/> representing the <see cref="IApiResponse"/> instance containing the result:
        /// <list type="table">
        /// <listheader>
        /// <term>Status</term>
        /// <description>Description</description>
        /// </listheader>
        /// <item>
        /// <term>200</term>
        /// <description>Returned if the blog post was created successfully.</description>
        /// </item>
        /// <item>
        /// <term>400</term>
        /// <description>Returned if invalid values were passed in for any of the enums, a REQUIRED parameter was missing, or if the given title is a duplicate in the space</description>
        /// </item>
        /// <item>
        /// <term>401</term>
        /// <description>Returned if the authentication credentials are incorrect or missing from the request</description>
        /// </item>
        /// <item>
        /// <term>404</term>
        /// <description>Returned if:\n- The provided space does not exist\n- The user does not have permissions to view the space\n- The user does not have the needed permissions to create a blog post in the provided space</description>
        /// </item>
        /// <item>
        /// <term>413</term>
        /// <description>Returned if the request is too large in size (over 5 MB)</description>
        /// </item>
        /// </list>
        /// </returns>
        [Headers("Accept: application/json")]
        [Post("/blogposts")]
        Task<IApiResponse<Response8>> CreateBlogPostAsync([Query, AliasAs("private")] bool? @private = default, [Body] object? body = default, CancellationToken cancellationToken = default);

        /// <summary>Get blog post by id</summary>
        /// <remarks>
        /// Returns a specific blog post.
        /// 
        /// **[Permissions](https://confluence.atlassian.com/x/_AozKw) required**:
        /// Permission to view the blog post and its corresponding space.
        /// </remarks>
        /// <param name="id">The ID of the blog post to be returned. If you don't know the blog post ID, use Get blog posts and filter the results.</param>
        /// <param name="body_format">The content format types to be returned in the `body` field of the response. If available, the representation will be available under a response field of the same name under the `body` field.</param>
        /// <param name="get_draft">Retrieve the draft version of this blog post.</param>
        /// <param name="version">Allows you to retrieve a previously published version. Specify the previous version's number to retrieve its details.</param>
        /// <param name="include_labels">
        /// Includes labels associated with this blog post in the response.
        /// The number of results will be limited to 50 and sorted in the default sort order.
        /// A `meta` and `_links` property will be present to indicate if more results are available and a link to retrieve the rest of the results.
        /// </param>
        /// <param name="include_properties">
        /// Includes content properties associated with this blog post in the response.
        /// The number of results will be limited to 50 and sorted in the default sort order.
        /// A `meta` and `_links` property will be present to indicate if more results are available and a link to retrieve the rest of the results.
        /// </param>
        /// <param name="include_operations">
        /// Includes operations associated with this blog post in the response.
        /// The number of results will be limited to 50 and sorted in the default sort order.
        /// A `meta` and `_links` property will be present to indicate if more results are available and a link to retrieve the rest of the results.
        /// </param>
        /// <param name="include_likes">
        /// Includes likes associated with this blog post in the response.
        /// The number of results will be limited to 50 and sorted in the default sort order.
        /// A `meta` and `_links` property will be present to indicate if more results are available and a link to retrieve the rest of the results.
        /// </param>
        /// <param name="include_versions">
        /// Includes versions associated with this blog post in the response.
        /// The number of results will be limited to 50 and sorted in the default sort order.
        /// A `meta` and `_links` property will be present to indicate if more results are available and a link to retrieve the rest of the results.
        /// </param>
        /// <param name="include_version">
        /// Includes the current version associated with this blog post in the response.
        /// By default this is included and can be omitted by setting the value to `false`.
        /// </param>
        /// <param name="include_favorited_by_current_user_status">Includes whether this blog post has been favorited by the current user.</param>
        /// <returns>
        /// A <see cref="Task"/> representing the <see cref="IApiResponse"/> instance containing the result:
        /// <list type="table">
        /// <listheader>
        /// <term>Status</term>
        /// <description>Description</description>
        /// </listheader>
        /// <item>
        /// <term>200</term>
        /// <description>Returned if the requested blog post is returned.</description>
        /// </item>
        /// <item>
        /// <term>400</term>
        /// <description>Returned if an invalid request is provided.</description>
        /// </item>
        /// <item>
        /// <term>401</term>
        /// <description>Returned if the authentication credentials are incorrect or missing\nfrom the request.</description>
        /// </item>
        /// <item>
        /// <term>404</term>
        /// <description>Returned if the calling user does not have permission to view the\nrequested blog post or the blog post was not found.</description>
        /// </item>
        /// </list>
        /// </returns>
        [Headers("Accept: application/json")]
        [Get("/blogposts/{id}")]
        Task<IApiResponse<Response9>> GetBlogPostByIdAsync(long id, [Query, AliasAs("body-format")] PrimaryBodyRepresentationSingle? body_format = default, [Query, AliasAs("get-draft")] bool? get_draft = default, [Query] int? version = default, [Query, AliasAs("include-labels")] bool? include_labels = default, [Query, AliasAs("include-properties")] bool? include_properties = default, [Query, AliasAs("include-operations")] bool? include_operations = default, [Query, AliasAs("include-likes")] bool? include_likes = default, [Query, AliasAs("include-versions")] bool? include_versions = default, [Query, AliasAs("include-version")] bool? include_version = default, [Query, AliasAs("include-favorited-by-current-user-status")] bool? include_favorited_by_current_user_status = default, CancellationToken cancellationToken = default);

        /// <summary>Update blog post</summary>
        /// <remarks>
        /// Update a blog post by id.
        /// 
        /// **[Permissions](https://confluence.atlassian.com/x/_AozKw) required**:
        /// Permission to view the blog post and its corresponding space. Permission to update blog posts in the space.
        /// </remarks>
        /// <param name="id">The ID of the blog post to be updated. If you don't know the blog post ID, use Get Blog Posts and filter the results.</param>
        /// <returns>
        /// A <see cref="Task"/> representing the <see cref="IApiResponse"/> instance containing the result:
        /// <list type="table">
        /// <listheader>
        /// <term>Status</term>
        /// <description>Description</description>
        /// </listheader>
        /// <item>
        /// <term>200</term>
        /// <description>Returned if the requested blog post is successfully updated.</description>
        /// </item>
        /// <item>
        /// <term>400</term>
        /// <description>Returned if an invalid request is provided.</description>
        /// </item>
        /// <item>
        /// <term>401</term>
        /// <description>Returned if the authentication credentials are incorrect or missing\nfrom the request.</description>
        /// </item>
        /// <item>
        /// <term>404</term>
        /// <description>Returned if:\n- The provided blog post does not exist\n- The user does not have permissions to view the blog post\n- The user does not have the needed permissions to update a blog post in the space</description>
        /// </item>
        /// </list>
        /// </returns>
        [Headers("Accept: application/json")]
        [Put("/blogposts/{id}")]
        Task<IApiResponse<Response10>> UpdateBlogPostAsync(long id, [Body] object? body = default, CancellationToken cancellationToken = default);

        /// <summary>Delete blog post</summary>
        /// <remarks>
        /// Delete a blog post by id.
        /// 
        /// By default this will delete blog posts that are non-drafts. To delete a blog post that is a draft, the endpoint must be called on a
        /// draft with the following param `draft=true`. Discarded drafts are not sent to the trash and are permanently deleted.
        /// 
        /// Deleting a blog post that is not a draft moves the blog post to the trash, where it can be restored later.
        /// To permanently delete a blog post (or "purge" it), the endpoint must be called on a **trashed** blog post with the following param `purge=true`.
        /// 
        /// **[Permissions](https://confluence.atlassian.com/x/_AozKw) required**:
        /// Permission to view the blog post and its corresponding space.
        /// Permission to delete blog posts in the space.
        /// Permission to administer the space (if attempting to purge).
        /// </remarks>
        /// <param name="id">The ID of the blog post to be deleted.</param>
        /// <param name="purge">If attempting to purge the blog post.</param>
        /// <param name="draft">If attempting to delete a blog post that is a draft.</param>
        /// <returns>
        /// A <see cref="Task"/> representing the <see cref="IApiResponse"/> instance containing the result:
        /// <list type="table">
        /// <listheader>
        /// <term>Status</term>
        /// <description>Description</description>
        /// </listheader>
        /// <item>
        /// <term>204</term>
        /// <description>Returned if the blog post was successfully deleted.</description>
        /// </item>
        /// <item>
        /// <term>400</term>
        /// <description>Returned if an invalid request is provided.</description>
        /// </item>
        /// <item>
        /// <term>401</term>
        /// <description>Returned if the authentication credentials are incorrect or missing\nfrom the request.</description>
        /// </item>
        /// <item>
        /// <term>404</term>
        /// <description>Returned if:\n- The provided blog post does not exist\n- The user does not have permissions to view the blog post\n- The user does not have the needed permissions to delete a blog post in the space</description>
        /// </item>
        /// </list>
        /// </returns>
        [Delete("/blogposts/{id}")]
        Task<IApiResponse> DeleteBlogPostAsync(long id, [Query] bool? purge = default, [Query] bool? draft = default, CancellationToken cancellationToken = default);

        /// <summary>Get blog posts for label</summary>
        /// <remarks>
        /// Returns the blogposts of specified label. The number of results is limited by the `limit` parameter and additional results (if available)
        /// will be available through the `next` URL present in the `Link` response header.
        /// 
        /// **[Permissions](https://confluence.atlassian.com/x/_AozKw) required**:
        /// Permission to view the content of the page and its corresponding space.
        /// </remarks>
        /// <param name="id">The ID of the label for which blog posts should be returned.</param>
        /// <param name="space_id">Filter the results based on space ids. Multiple space ids can be specified as a comma-separated list.</param>
        /// <param name="body_format">The content format types to be returned in the `body` field of the response. If available, the representation will be available under a response field of the same name under the `body` field.</param>
        /// <param name="sort">Used to sort the result by a particular field.</param>
        /// <param name="cursor">Used for pagination, this opaque cursor will be returned in the `next` URL in the `Link` response header. Use the relative URL in the `Link` header to retrieve the `next` set of results.</param>
        /// <param name="limit">Maximum number of blog posts per result to return. If more results exist, use the `Link` header to retrieve a relative URL that will return the next set of results.</param>
        /// <returns>
        /// A <see cref="Task"/> representing the <see cref="IApiResponse"/> instance containing the result:
        /// <list type="table">
        /// <listheader>
        /// <term>Status</term>
        /// <description>Description</description>
        /// </listheader>
        /// <item>
        /// <term>200</term>
        /// <description>Returned if the requested blog posts for specified label were successfully fetched.</description>
        /// </item>
        /// <item>
        /// <term>400</term>
        /// <description>Returned if an invalid request is provided.</description>
        /// </item>
        /// <item>
        /// <term>401</term>
        /// <description>Returned if the authentication credentials are incorrect or missing\nfrom the request.</description>
        /// </item>
        /// <item>
        /// <term>404</term>
        /// <description>Returned if the calling user does not have permission to view the\nrequested label or label was not found.</description>
        /// </item>
        /// </list>
        /// </returns>
        [Headers("Accept: application/json")]
        [Get("/labels/{id}/blogposts")]
        Task<IApiResponse<Response27>> GetLabelBlogPostsAsync(long id, [Query(CollectionFormat.Multi), AliasAs("space-id")] IEnumerable<long>? space_id = default, [Query, AliasAs("body-format")] PrimaryBodyRepresentation? body_format = default, [Query] BlogPostSortOrder? sort = default, [Query] string? cursor = default, [Query] int? limit = default, CancellationToken cancellationToken = default);

        /// <summary>Get blog posts in space</summary>
        /// <remarks>
        /// Returns all blog posts in a space. The number of results is limited by the `limit` parameter and additional results (if available)
        /// will be available through the `next` URL present in the `Link` response header.
        /// 
        /// **[Permissions](https://confluence.atlassian.com/x/_AozKw) required**:
        /// Permission to access the Confluence site ('Can use' global permission) and view the space.
        /// Only blog posts that the user has permission to view will be returned.
        /// </remarks>
        /// <param name="id">The ID of the space for which blog posts should be returned.</param>
        /// <param name="sort">Used to sort the result by a particular field.</param>
        /// <param name="status">Filter the results to blog posts based on their status. By default, `current` is used.</param>
        /// <param name="title">Filter the results to blog posts based on their title.</param>
        /// <param name="body_format">The content format types to be returned in the `body` field of the response. If available, the representation will be available under a response field of the same name under the `body` field.</param>
        /// <param name="cursor">Used for pagination, this opaque cursor will be returned in the `next` URL in the `Link` response header. Use the relative URL in the `Link` header to retrieve the `next` set of results.</param>
        /// <param name="limit">Maximum number of blog posts per result to return. If more results exist, use the `Link` header to retrieve a relative URL that will return the next set of results.</param>
        /// <returns>
        /// A <see cref="Task"/> representing the <see cref="IApiResponse"/> instance containing the result:
        /// <list type="table">
        /// <listheader>
        /// <term>Status</term>
        /// <description>Description</description>
        /// </listheader>
        /// <item>
        /// <term>200</term>
        /// <description>Returned if the requested blog posts are returned.</description>
        /// </item>
        /// <item>
        /// <term>400</term>
        /// <description>Returned if an invalid request is provided.</description>
        /// </item>
        /// <item>
        /// <term>401</term>
        /// <description>Returned if the authentication credentials are incorrect or missing\nfrom the request.</description>
        /// </item>
        /// <item>
        /// <term>404</term>
        /// <description>Returned if the calling user does not have permission to view the\nspecified space or the space was not found.</description>
        /// </item>
        /// </list>
        /// </returns>
        [Headers("Accept: application/json")]
        [Get("/spaces/{id}/blogposts")]
        Task<IApiResponse<Response54>> GetBlogPostsInSpaceAsync(long id, [Query] BlogPostSortOrder? sort = default, [Query(CollectionFormat.Multi)] IEnumerable<Anonymous7>? status = default, [Query] string? title = default, [Query, AliasAs("body-format")] PrimaryBodyRepresentation? body_format = default, [Query] string? cursor = default, [Query] int? limit = default, CancellationToken cancellationToken = default);
    }

    /// <summary>Get custom content by type in blog post</summary>
    [System.CodeDom.Compiler.GeneratedCode("Refitter", "1.0.0.0")]
    public partial interface ICustomContentApi
    {
        /// <summary>Get custom content by type in blog post</summary>
        /// <remarks>
        /// Returns all custom content for a given type within a given blogpost. The number of results is limited by the `limit` parameter and additional results (if available)
        /// will be available through the `next` URL present in the `Link` response header.
        /// 
        /// **[Permissions](https://confluence.atlassian.com/x/_AozKw) required**:
        /// Permission to view the custom content, the container of the custom content (blog post), and the corresponding space.
        /// </remarks>
        /// <param name="id">The ID of the blog post for which custom content should be returned.</param>
        /// <param name="type">The type of custom content being requested. See: https://developer.atlassian.com/cloud/confluence/custom-content/ for additional details on custom content.</param>
        /// <param name="sort">Used to sort the result by a particular field.</param>
        /// <param name="cursor">Used for pagination, this opaque cursor will be returned in the `next` URL in the `Link` response header. Use the relative URL in the `Link` header to retrieve the `next` set of results.</param>
        /// <param name="limit">Maximum number of pages per result to return. If more results exist, use the `Link` header to retrieve a relative URL that will return the next set of results.</param>
        /// <param name="body_format">
        /// The content format types to be returned in the `body` field of the response. If available, the representation will be available under a response field of the same name under the `body` field.
        /// 
        /// Note: If the custom content body type is `storage`, the `storage` and `atlas_doc_format` body formats are able to be returned. If the custom content body type is `raw`, only the `raw` body format is able to be returned.
        /// </param>
        /// <returns>
        /// A <see cref="Task"/> representing the <see cref="IApiResponse"/> instance containing the result:
        /// <list type="table">
        /// <listheader>
        /// <term>Status</term>
        /// <description>Description</description>
        /// </listheader>
        /// <item>
        /// <term>200</term>
        /// <description>Returned if the requested custom content is returned.</description>
        /// </item>
        /// <item>
        /// <term>400</term>
        /// <description>Returned if an invalid request is provided.</description>
        /// </item>
        /// <item>
        /// <term>401</term>
        /// <description>Returned if the authentication credentials are incorrect or missing\nfrom the request.</description>
        /// </item>
        /// <item>
        /// <term>404</term>
        /// <description>Returned if the given blog post is not found. Returned if the type of custom content is not found. Note, this is distinct from the type being present, but no instances of the type, which would be a 200 with empty results.</description>
        /// </item>
        /// </list>
        /// </returns>
        [Headers("Accept: application/json")]
        [Get("/blogposts/{id}/custom-content")]
        Task<IApiResponse<Response12>> GetCustomContentByTypeInBlogPostAsync(long id, [Query] string type, [Query] CustomContentSortOrder? sort = default, [Query] string? cursor = default, [Query] int? limit = default, [Query, AliasAs("body-format")] CustomContentBodyRepresentation? body_format = default, CancellationToken cancellationToken = default);

        /// <summary>Get custom content by type</summary>
        /// <remarks>
        /// Returns all custom content for a given type. The number of results is limited by the `limit` parameter and additional results (if available)
        /// will be available through the `next` URL present in the `Link` response header.
        /// 
        /// **[Permissions](https://confluence.atlassian.com/x/_AozKw) required**:
        /// Permission to view the custom content, the container of the custom content, and the corresponding space (if different from the container).
        /// </remarks>
        /// <param name="type">The type of custom content being requested. See: https://developer.atlassian.com/cloud/confluence/custom-content/ for additional details on custom content.</param>
        /// <param name="id">Filter the results based on custom content ids. Multiple custom content ids can be specified as a comma-separated list.</param>
        /// <param name="space_id">Filter the results based on space ids. Multiple space ids can be specified as a comma-separated list.</param>
        /// <param name="sort">Used to sort the result by a particular field.</param>
        /// <param name="cursor">Used for pagination, this opaque cursor will be returned in the `next` URL in the `Link` response header. Use the relative URL in the `Link` header to retrieve the `next` set of results.</param>
        /// <param name="limit">Maximum number of pages per result to return. If more results exist, use the `Link` header to retrieve a relative URL that will return the next set of results.</param>
        /// <param name="body_format">
        /// The content format types to be returned in the `body` field of the response. If available, the representation will be available under a response field of the same name under the `body` field.
        /// 
        /// Note: If the custom content body type is `storage`, the `storage` and `atlas_doc_format` body formats are able to be returned. If the custom content body type is `raw`, only the `raw` body format is able to be returned.
        /// </param>
        /// <returns>
        /// A <see cref="Task"/> representing the <see cref="IApiResponse"/> instance containing the result:
        /// <list type="table">
        /// <listheader>
        /// <term>Status</term>
        /// <description>Description</description>
        /// </listheader>
        /// <item>
        /// <term>200</term>
        /// <description>Returned if the requested custom content is returned.</description>
        /// </item>
        /// <item>
        /// <term>400</term>
        /// <description>Returned if an invalid request is provided.</description>
        /// </item>
        /// <item>
        /// <term>401</term>
        /// <description>Returned if the authentication credentials are incorrect or missing\nfrom the request.</description>
        /// </item>
        /// <item>
        /// <term>404</term>
        /// <description>Returned if the type of custom content is not found. Note, this is distinct from the type being present, but no instances of the type, which would be a 200 with empty results.</description>
        /// </item>
        /// </list>
        /// </returns>
        [Headers("Accept: application/json")]
        [Get("/custom-content")]
        Task<IApiResponse<Response17>> GetCustomContentByTypeAsync([Query] string type, [Query(CollectionFormat.Multi)] IEnumerable<long>? id = default, [Query(CollectionFormat.Multi), AliasAs("space-id")] IEnumerable<long>? space_id = default, [Query] CustomContentSortOrder? sort = default, [Query] string? cursor = default, [Query] int? limit = default, [Query, AliasAs("body-format")] CustomContentBodyRepresentation? body_format = default, CancellationToken cancellationToken = default);

        /// <summary>Create custom content</summary>
        /// <remarks>
        /// Creates a new custom content in the given space, page, blogpost or other custom content.
        /// 
        /// Only one of `spaceId`, `pageId`, `blogPostId`, or `customContentId` is required in the request body.
        /// **[Permissions](https://confluence.atlassian.com/x/_AozKw) required**:
        /// Permission to view the content of the page or blogpost and its corresponding space. Permission to create custom content in the space.
        /// </remarks>
        /// <returns>
        /// A <see cref="Task"/> representing the <see cref="IApiResponse"/> instance containing the result:
        /// <list type="table">
        /// <listheader>
        /// <term>Status</term>
        /// <description>Description</description>
        /// </listheader>
        /// <item>
        /// <term>201</term>
        /// <description>Returned if the requested custom content is created successfully.</description>
        /// </item>
        /// <item>
        /// <term>400</term>
        /// <description>Returned if an invalid request is provided.</description>
        /// </item>
        /// <item>
        /// <term>401</term>
        /// <description>Returned if the authentication credentials are incorrect or missing\nfrom the request.</description>
        /// </item>
        /// <item>
        /// <term>404</term>
        /// <description>Returned if the type of custom content is not found.</description>
        /// </item>
        /// </list>
        /// </returns>
        [Headers("Accept: application/json")]
        [Post("/custom-content")]
        Task<IApiResponse<Response18>> CreateCustomContentAsync([Body] object? body = default, CancellationToken cancellationToken = default);

        /// <summary>Get custom content by id</summary>
        /// <remarks>
        /// Returns a specific piece of custom content.
        /// 
        /// **[Permissions](https://confluence.atlassian.com/x/_AozKw) required**:
        /// Permission to view the custom content, the container of the custom content, and the corresponding space (if different from the container).
        /// </remarks>
        /// <param name="id">The ID of the custom content to be returned. If you don't know the custom content ID, use Get Custom Content by Type and filter the results.</param>
        /// <param name="body_format">
        /// The content format types to be returned in the `body` field of the response. If available, the representation will be available under a response field of the same name under the `body` field.
        /// 
        /// Note: If the custom content body type is `storage`, the `storage` and `atlas_doc_format` body formats are able to be returned. If the custom content body type is `raw`, only the `raw` body format is able to be returned.
        /// </param>
        /// <param name="version">Allows you to retrieve a previously published version. Specify the previous version's number to retrieve its details.</param>
        /// <param name="include_labels">
        /// Includes labels associated with this custom content in the response.
        /// The number of results will be limited to 50 and sorted in the default sort order.
        /// A `meta` and `_links` property will be present to indicate if more results are available and a link to retrieve the rest of the results.
        /// </param>
        /// <param name="include_properties">
        /// Includes content properties associated with this custom content in the response.
        /// The number of results will be limited to 50 and sorted in the default sort order.
        /// A `meta` and `_links` property will be present to indicate if more results are available and a link to retrieve the rest of the results.
        /// </param>
        /// <param name="include_operations">
        /// Includes operations associated with this custom content in the response.
        /// The number of results will be limited to 50 and sorted in the default sort order.
        /// A `meta` and `_links` property will be present to indicate if more results are available and a link to retrieve the rest of the results.
        /// </param>
        /// <param name="include_versions">
        /// Includes versions associated with this custom content in the response.
        /// The number of results will be limited to 50 and sorted in the default sort order.
        /// A `meta` and `_links` property will be present to indicate if more results are available and a link to retrieve the rest of the results.
        /// </param>
        /// <param name="include_version">
        /// Includes the current version associated with this custom content in the response.
        /// By default this is included and can be omitted by setting the value to `false`.
        /// </param>
        /// <returns>
        /// A <see cref="Task"/> representing the <see cref="IApiResponse"/> instance containing the result:
        /// <list type="table">
        /// <listheader>
        /// <term>Status</term>
        /// <description>Description</description>
        /// </listheader>
        /// <item>
        /// <term>200</term>
        /// <description>Returned if the requested custom content is returned.</description>
        /// </item>
        /// <item>
        /// <term>400</term>
        /// <description>Returned if an invalid request is provided.</description>
        /// </item>
        /// <item>
        /// <term>401</term>
        /// <description>Returned if the authentication credentials are incorrect or missing\nfrom the request.</description>
        /// </item>
        /// <item>
        /// <term>404</term>
        /// <description>Returned if the calling user does not have permission to view the\nrequested custom content or the custom content was not found.</description>
        /// </item>
        /// </list>
        /// </returns>
        [Headers("Accept: application/json")]
        [Get("/custom-content/{id}")]
        Task<IApiResponse<Response19>> GetCustomContentByIdAsync(long id, [Query, AliasAs("body-format")] CustomContentBodyRepresentationSingle? body_format = default, [Query] int? version = default, [Query, AliasAs("include-labels")] bool? include_labels = default, [Query, AliasAs("include-properties")] bool? include_properties = default, [Query, AliasAs("include-operations")] bool? include_operations = default, [Query, AliasAs("include-versions")] bool? include_versions = default, [Query, AliasAs("include-version")] bool? include_version = default, CancellationToken cancellationToken = default);

        /// <summary>Update custom content</summary>
        /// <remarks>
        /// Update a custom content by id.
        /// 
        /// `spaceId` is always required and maximum one of `pageId`, `blogPostId`, or `customContentId` is allowed in the request body.
        /// **[Permissions](https://confluence.atlassian.com/x/_AozKw) required**:
        /// Permission to view the content of the page or blogpost and its corresponding space. Permission to update custom content in the space.
        /// </remarks>
        /// <param name="id">The ID of the custom content to be updated. If you don't know the custom content ID, use Get Custom Content by Type and filter the results.</param>
        /// <returns>
        /// A <see cref="Task"/> representing the <see cref="IApiResponse"/> instance containing the result:
        /// <list type="table">
        /// <listheader>
        /// <term>Status</term>
        /// <description>Description</description>
        /// </listheader>
        /// <item>
        /// <term>200</term>
        /// <description>Returned if the requested custom content is updated successfully.</description>
        /// </item>
        /// <item>
        /// <term>400</term>
        /// <description>Returned if an invalid request is provided.</description>
        /// </item>
        /// <item>
        /// <term>401</term>
        /// <description>Returned if the authentication credentials are incorrect or missing\nfrom the request.</description>
        /// </item>
        /// <item>
        /// <term>404</term>
        /// <description>Returned if the type of custom content is not found.</description>
        /// </item>
        /// </list>
        /// </returns>
        [Headers("Accept: application/json")]
        [Put("/custom-content/{id}")]
        Task<IApiResponse<Response20>> UpdateCustomContentAsync(long id, [Body] object? body = default, CancellationToken cancellationToken = default);

        /// <summary>Delete custom content</summary>
        /// <remarks>
        /// Delete a custom content by id.
        /// 
        /// Deleting a custom content will either move it to the trash or permanently delete it (purge it), depending on the apiSupport.
        /// To permanently delete a **trashed** custom content, the endpoint must be called with the following param `purge=true`.
        /// 
        /// **[Permissions](https://confluence.atlassian.com/x/_AozKw) required**:
        /// Permission to view the content of the page or blogpost and its corresponding space.
        /// Permission to delete custom content in the space.
        /// Permission to administer the space (if attempting to purge).
        /// </remarks>
        /// <param name="id">The ID of the custom content to be deleted.</param>
        /// <param name="purge">If attempting to purge the custom content.</param>
        /// <returns>
        /// A <see cref="Task"/> representing the <see cref="IApiResponse"/> instance containing the result:
        /// <list type="table">
        /// <listheader>
        /// <term>Status</term>
        /// <description>Description</description>
        /// </listheader>
        /// <item>
        /// <term>204</term>
        /// <description>Returned if the custom content was deleted.</description>
        /// </item>
        /// <item>
        /// <term>400</term>
        /// <description>Returned if an invalid request is provided.</description>
        /// </item>
        /// <item>
        /// <term>401</term>
        /// <description>Returned if the authentication credentials are incorrect or missing\nfrom the request.</description>
        /// </item>
        /// <item>
        /// <term>404</term>
        /// <description>Returned if the custom content is not found.</description>
        /// </item>
        /// </list>
        /// </returns>
        [Delete("/custom-content/{id}")]
        Task<IApiResponse> DeleteCustomContentAsync(long id, [Query] bool? purge = default, CancellationToken cancellationToken = default);

        /// <summary>Get custom content by type in page</summary>
        /// <remarks>
        /// Returns all custom content for a given type within a given page. The number of results is limited by the `limit` parameter and additional results (if available)
        /// will be available through the `next` URL present in the `Link` response header.
        /// 
        /// **[Permissions](https://confluence.atlassian.com/x/_AozKw) required**:
        /// Permission to view the custom content, the container of the custom content (page), and the corresponding space.
        /// </remarks>
        /// <param name="id">The ID of the page for which custom content should be returned.</param>
        /// <param name="type">The type of custom content being requested. See: https://developer.atlassian.com/cloud/confluence/custom-content/ for additional details on custom content.</param>
        /// <param name="sort">Used to sort the result by a particular field.</param>
        /// <param name="cursor">Used for pagination, this opaque cursor will be returned in the `next` URL in the `Link` response header. Use the relative URL in the `Link` header to retrieve the `next` set of results.</param>
        /// <param name="limit">Maximum number of pages per result to return. If more results exist, use the `Link` header to retrieve a relative URL that will return the next set of results.</param>
        /// <param name="body_format">
        /// The content format types to be returned in the `body` field of the response. If available, the representation will be available under a response field of the same name under the `body` field.
        /// 
        /// Note: If the custom content body type is `storage`, the `storage` and `atlas_doc_format` body formats are able to be returned. If the custom content body type is `raw`, only the `raw` body format is able to be returned.
        /// </param>
        /// <returns>
        /// A <see cref="Task"/> representing the <see cref="IApiResponse"/> instance containing the result:
        /// <list type="table">
        /// <listheader>
        /// <term>Status</term>
        /// <description>Description</description>
        /// </listheader>
        /// <item>
        /// <term>200</term>
        /// <description>Returned if the requested custom content is returned.</description>
        /// </item>
        /// <item>
        /// <term>400</term>
        /// <description>Returned if an invalid request is provided.</description>
        /// </item>
        /// <item>
        /// <term>401</term>
        /// <description>Returned if the authentication credentials are incorrect or missing\nfrom the request.</description>
        /// </item>
        /// <item>
        /// <term>404</term>
        /// <description>Returned if the given page is not found. Returned if the type of custom content is not found. Note, this is distinct from the type being present, but no instances of the type, which would be a 200 with empty results.</description>
        /// </item>
        /// </list>
        /// </returns>
        [Headers("Accept: application/json")]
        [Get("/pages/{id}/custom-content")]
        Task<IApiResponse<Response34>> GetCustomContentByTypeInPageAsync(long id, [Query] string type, [Query] CustomContentSortOrder? sort = default, [Query] string? cursor = default, [Query] int? limit = default, [Query, AliasAs("body-format")] CustomContentBodyRepresentation? body_format = default, CancellationToken cancellationToken = default);

        /// <summary>Get custom content by type in space</summary>
        /// <remarks>
        /// Returns all custom content for a given type within a given space. The number of results is limited by the `limit` parameter and additional results (if available)
        /// will be available through the `next` URL present in the `Link` response header.
        /// 
        /// **[Permissions](https://confluence.atlassian.com/x/_AozKw) required**:
        /// Permission to view the custom content and the corresponding space.
        /// </remarks>
        /// <param name="id">The ID of the space for which custom content should be returned.</param>
        /// <param name="type">The type of custom content being requested. See: https://developer.atlassian.com/cloud/confluence/custom-content/ for additional details on custom content.</param>
        /// <param name="cursor">Used for pagination, this opaque cursor will be returned in the `next` URL in the `Link` response header. Use the relative URL in the `Link` header to retrieve the `next` set of results.</param>
        /// <param name="limit">Maximum number of pages per result to return. If more results exist, use the `Link` header to retrieve a relative URL that will return the next set of results.</param>
        /// <param name="body_format">
        /// The content format types to be returned in the `body` field of the response. If available, the representation will be available under a response field of the same name under the `body` field.
        /// 
        /// Note: If the custom content body type is `storage`, the `storage` and `atlas_doc_format` body formats are able to be returned. If the custom content body type is `raw`, only the `raw` body format is able to be returned.
        /// </param>
        /// <returns>
        /// A <see cref="Task"/> representing the <see cref="IApiResponse"/> instance containing the result:
        /// <list type="table">
        /// <listheader>
        /// <term>Status</term>
        /// <description>Description</description>
        /// </listheader>
        /// <item>
        /// <term>200</term>
        /// <description>Returned if the requested custom content is returned.</description>
        /// </item>
        /// <item>
        /// <term>400</term>
        /// <description>Returned if an invalid request is provided.</description>
        /// </item>
        /// <item>
        /// <term>401</term>
        /// <description>Returned if the authentication credentials are incorrect or missing\nfrom the request.</description>
        /// </item>
        /// <item>
        /// <term>404</term>
        /// <description>Returned if the space is not found. Returned if the type of custom content is not found. Note, this is distinct from the type being present, but no instances of the type, which would be a 200 with empty results.</description>
        /// </item>
        /// </list>
        /// </returns>
        [Headers("Accept: application/json")]
        [Get("/spaces/{id}/custom-content")]
        Task<IApiResponse<Response57>> GetCustomContentByTypeInSpaceAsync(long id, [Query] string type, [Query] string? cursor = default, [Query] int? limit = default, [Query, AliasAs("body-format")] CustomContentBodyRepresentation? body_format = default, CancellationToken cancellationToken = default);
    }

    /// <summary>Get like count for blog post</summary>
    [System.CodeDom.Compiler.GeneratedCode("Refitter", "1.0.0.0")]
    public partial interface ILikeApi
    {
        /// <summary>Get like count for blog post</summary>
        /// <remarks>
        /// Returns the count of likes of specific blog post.
        /// 
        /// **[Permissions](https://confluence.atlassian.com/x/_AozKw) required**:
        /// Permission to view the content of the blog post and its corresponding space.
        /// </remarks>
        /// <param name="id">The ID of the blog post for which like count should be returned.</param>
        /// <returns>
        /// A <see cref="Task"/> representing the <see cref="IApiResponse"/> instance containing the result:
        /// <list type="table">
        /// <listheader>
        /// <term>Status</term>
        /// <description>Description</description>
        /// </listheader>
        /// <item>
        /// <term>200</term>
        /// <description>Returned if the requested count is returned.</description>
        /// </item>
        /// <item>
        /// <term>400</term>
        /// <description>Returned if an invalid request is provided.</description>
        /// </item>
        /// <item>
        /// <term>401</term>
        /// <description>Returned if the authentication credentials are incorrect or missing\nfrom the request.</description>
        /// </item>
        /// <item>
        /// <term>404</term>
        /// <description>Returned if the calling user does not have permission to view the\nrequested blog post or the blog post was not found.</description>
        /// </item>
        /// </list>
        /// </returns>
        [Headers("Accept: application/json")]
        [Get("/blogposts/{id}/likes/count")]
        Task<IApiResponse<Integer>> GetBlogPostLikeCountAsync(long id, CancellationToken cancellationToken = default);

        /// <summary>Get account IDs of likes for blog post</summary>
        /// <remarks>
        /// Returns the account IDs of likes of specific blog post.
        /// 
        /// **[Permissions](https://confluence.atlassian.com/x/_AozKw) required**:
        /// Permission to view the content of the blog post and its corresponding space.
        /// </remarks>
        /// <param name="id">The ID of the blog post for which account IDs should be returned.</param>
        /// <param name="cursor">Used for pagination, this opaque cursor will be returned in the `next` URL in the `Link` response header. Use the relative URL in the `Link` header to retrieve the `next` set of results.</param>
        /// <param name="limit">Maximum number of account IDs per result to return. If more results exist, use the `Link` header to retrieve a relative URL that will return the next set of results.</param>
        /// <returns>
        /// A <see cref="Task"/> representing the <see cref="IApiResponse"/> instance containing the result:
        /// <list type="table">
        /// <listheader>
        /// <term>Status</term>
        /// <description>Description</description>
        /// </listheader>
        /// <item>
        /// <term>200</term>
        /// <description>Returned if the requested account IDs are returned.</description>
        /// </item>
        /// <item>
        /// <term>400</term>
        /// <description>Returned if an invalid request is provided.</description>
        /// </item>
        /// <item>
        /// <term>401</term>
        /// <description>Returned if the authentication credentials are incorrect or missing\nfrom the request.</description>
        /// </item>
        /// <item>
        /// <term>404</term>
        /// <description>Returned if the calling user does not have permission to view the\nrequested blog post or the blog post was not found.</description>
        /// </item>
        /// </list>
        /// </returns>
        [Headers("Accept: application/json")]
        [Get("/blogposts/{id}/likes/users")]
        Task<IApiResponse<Response14>> GetBlogPostLikeUsersAsync(long id, [Query] string? cursor = default, [Query] int? limit = default, CancellationToken cancellationToken = default);

        /// <summary>Get like count for page</summary>
        /// <remarks>
        /// Returns the count of likes of specific page.
        /// 
        /// **[Permissions](https://confluence.atlassian.com/x/_AozKw) required**:
        /// Permission to view the content of the page and its corresponding space.
        /// </remarks>
        /// <param name="id">The ID of the page for which like count should be returned.</param>
        /// <returns>
        /// A <see cref="Task"/> representing the <see cref="IApiResponse"/> instance containing the result:
        /// <list type="table">
        /// <listheader>
        /// <term>Status</term>
        /// <description>Description</description>
        /// </listheader>
        /// <item>
        /// <term>200</term>
        /// <description>Returned if the requested count is returned.</description>
        /// </item>
        /// <item>
        /// <term>400</term>
        /// <description>Returned if an invalid request is provided.</description>
        /// </item>
        /// <item>
        /// <term>401</term>
        /// <description>Returned if the authentication credentials are incorrect or missing\nfrom the request.</description>
        /// </item>
        /// <item>
        /// <term>404</term>
        /// <description>Returned if the calling user does not have permission to view the\nrequested page or the page was not found.</description>
        /// </item>
        /// </list>
        /// </returns>
        [Headers("Accept: application/json")]
        [Get("/pages/{id}/likes/count")]
        Task<IApiResponse<Anonymous9>> GetPageLikeCountAsync(long id, CancellationToken cancellationToken = default);

        /// <summary>Get account IDs of likes for page</summary>
        /// <remarks>
        /// Returns the account IDs of likes of specific page.
        /// 
        /// **[Permissions](https://confluence.atlassian.com/x/_AozKw) required**:
        /// Permission to view the content of the page and its corresponding space.
        /// </remarks>
        /// <param name="id">The ID of the page for which like count should be returned.</param>
        /// <param name="cursor">Used for pagination, this opaque cursor will be returned in the `next` URL in the `Link` response header. Use the relative URL in the `Link` header to retrieve the `next` set of results.</param>
        /// <param name="limit">Maximum number of account IDs per result to return. If more results exist, use the `Link` header to retrieve a relative URL that will return the next set of results.</param>
        /// <returns>
        /// A <see cref="Task"/> representing the <see cref="IApiResponse"/> instance containing the result:
        /// <list type="table">
        /// <listheader>
        /// <term>Status</term>
        /// <description>Description</description>
        /// </listheader>
        /// <item>
        /// <term>200</term>
        /// <description>Returned if the requested account IDs are returned.</description>
        /// </item>
        /// <item>
        /// <term>400</term>
        /// <description>Returned if an invalid request is provided.</description>
        /// </item>
        /// <item>
        /// <term>401</term>
        /// <description>Returned if the authentication credentials are incorrect or missing\nfrom the request.</description>
        /// </item>
        /// <item>
        /// <term>404</term>
        /// <description>Returned if the calling user does not have permission to view the\nrequested page or the page was not found.</description>
        /// </item>
        /// </list>
        /// </returns>
        [Headers("Accept: application/json")]
        [Get("/pages/{id}/likes/users")]
        Task<IApiResponse<Response36>> GetPageLikeUsersAsync(long id, [Query] string? cursor = default, [Query] int? limit = default, CancellationToken cancellationToken = default);

        /// <summary>Get like count for footer comment</summary>
        /// <remarks>
        /// Returns the count of likes of specific footer comment.
        /// 
        /// **[Permissions](https://confluence.atlassian.com/x/_AozKw) required**:
        /// Permission to view the content of the page/blogpost and its corresponding space.
        /// </remarks>
        /// <param name="id">The ID of the footer comment for which like count should be returned.</param>
        /// <returns>
        /// A <see cref="Task"/> representing the <see cref="IApiResponse"/> instance containing the result:
        /// <list type="table">
        /// <listheader>
        /// <term>Status</term>
        /// <description>Description</description>
        /// </listheader>
        /// <item>
        /// <term>200</term>
        /// <description>Returned if the requested count is returned.</description>
        /// </item>
        /// <item>
        /// <term>400</term>
        /// <description>Returned if an invalid request is provided.</description>
        /// </item>
        /// <item>
        /// <term>401</term>
        /// <description>Returned if the authentication credentials are incorrect or missing\nfrom the request.</description>
        /// </item>
        /// <item>
        /// <term>404</term>
        /// <description>Returned if the calling user does not have permission to view the comment or the comment was not found.</description>
        /// </item>
        /// </list>
        /// </returns>
        [Headers("Accept: application/json")]
        [Get("/footer-comments/{id}/likes/count")]
        Task<IApiResponse<Anonymous10>> GetFooterLikeCountAsync(long id, CancellationToken cancellationToken = default);

        /// <summary>Get account IDs of likes for footer comment</summary>
        /// <remarks>
        /// Returns the account IDs of likes of specific footer comment.
        /// 
        /// **[Permissions](https://confluence.atlassian.com/x/_AozKw) required**:
        /// Permission to view the content of the page/blogpost and its corresponding space.
        /// </remarks>
        /// <param name="id">The ID of the footer comment for which like count should be returned.</param>
        /// <param name="cursor">Used for pagination, this opaque cursor will be returned in the `next` URL in the `Link` response header. Use the relative URL in the `Link` header to retrieve the `next` set of results.</param>
        /// <param name="limit">Maximum number of account IDs per result to return. If more results exist, use the `Link` header to retrieve a relative URL that will return the next set of results.</param>
        /// <returns>
        /// A <see cref="Task"/> representing the <see cref="IApiResponse"/> instance containing the result:
        /// <list type="table">
        /// <listheader>
        /// <term>Status</term>
        /// <description>Description</description>
        /// </listheader>
        /// <item>
        /// <term>200</term>
        /// <description>Returned if the requested account IDs are returned.</description>
        /// </item>
        /// <item>
        /// <term>400</term>
        /// <description>Returned if an invalid request is provided.</description>
        /// </item>
        /// <item>
        /// <term>401</term>
        /// <description>Returned if the authentication credentials are incorrect or missing\nfrom the request.</description>
        /// </item>
        /// <item>
        /// <term>404</term>
        /// <description>Returned if the calling user does not have permission to view the comment or the comment was not found.</description>
        /// </item>
        /// </list>
        /// </returns>
        [Headers("Accept: application/json")]
        [Get("/footer-comments/{id}/likes/users")]
        Task<IApiResponse<Response69>> GetFooterLikeUsersAsync(long id, [Query] string? cursor = default, [Query] int? limit = default, CancellationToken cancellationToken = default);

        /// <summary>Get like count for inline comment</summary>
        /// <remarks>
        /// Returns the count of likes of specific inline comment.
        /// 
        /// **[Permissions](https://confluence.atlassian.com/x/_AozKw) required**:
        /// Permission to view the content of the page/blogpost and its corresponding space.
        /// </remarks>
        /// <param name="id">The ID of the inline comment for which like count should be returned.</param>
        /// <returns>
        /// A <see cref="Task"/> representing the <see cref="IApiResponse"/> instance containing the result:
        /// <list type="table">
        /// <listheader>
        /// <term>Status</term>
        /// <description>Description</description>
        /// </listheader>
        /// <item>
        /// <term>200</term>
        /// <description>Returned if the requested count is returned.</description>
        /// </item>
        /// <item>
        /// <term>400</term>
        /// <description>Returned if an invalid request is provided.</description>
        /// </item>
        /// <item>
        /// <term>401</term>
        /// <description>Returned if the authentication credentials are incorrect or missing\nfrom the request.</description>
        /// </item>
        /// <item>
        /// <term>404</term>
        /// <description>Returned if the calling user does not have permission to view the comment or the comment was not found.</description>
        /// </item>
        /// </list>
        /// </returns>
        [Headers("Accept: application/json")]
        [Get("/inline-comments/{id}/likes/count")]
        Task<IApiResponse<Anonymous11>> GetInlineLikeCountAsync(long id, CancellationToken cancellationToken = default);

        /// <summary>Get account IDs of likes for inline comment</summary>
        /// <remarks>
        /// Returns the account IDs of likes of specific inline comment.
        /// 
        /// **[Permissions](https://confluence.atlassian.com/x/_AozKw) required**:
        /// Permission to view the content of the page/blogpost and its corresponding space.
        /// </remarks>
        /// <param name="id">The ID of the inline comment for which like count should be returned.</param>
        /// <param name="cursor">Used for pagination, this opaque cursor will be returned in the `next` URL in the `Link` response header. Use the relative URL in the `Link` header to retrieve the `next` set of results.</param>
        /// <param name="limit">Maximum number of account IDs per result to return. If more results exist, use the `Link` header to retrieve a relative URL that will return the next set of results.</param>
        /// <returns>
        /// A <see cref="Task"/> representing the <see cref="IApiResponse"/> instance containing the result:
        /// <list type="table">
        /// <listheader>
        /// <term>Status</term>
        /// <description>Description</description>
        /// </listheader>
        /// <item>
        /// <term>200</term>
        /// <description>Returned if the requested account IDs are returned.</description>
        /// </item>
        /// <item>
        /// <term>400</term>
        /// <description>Returned if an invalid request is provided.</description>
        /// </item>
        /// <item>
        /// <term>401</term>
        /// <description>Returned if the authentication credentials are incorrect or missing\nfrom the request.</description>
        /// </item>
        /// <item>
        /// <term>404</term>
        /// <description>Returned if the calling user does not have permission to view the comment or the comment was not found.</description>
        /// </item>
        /// </list>
        /// </returns>
        [Headers("Accept: application/json")]
        [Get("/inline-comments/{id}/likes/users")]
        Task<IApiResponse<Response76>> GetInlineLikeUsersAsync(long id, [Query] string? cursor = default, [Query] int? limit = default, CancellationToken cancellationToken = default);
    }

    /// <summary>Convert content ids to content types</summary>
    [System.CodeDom.Compiler.GeneratedCode("Refitter", "1.0.0.0")]
    public partial interface IContentApi
    {
        /// <summary>Convert content ids to content types</summary>
        /// <remarks>
        /// Converts a list of content ids into their associated content types. This is useful for users migrating from v1 to v2
        /// who may have stored just content ids without their associated type. This will return types as they should be used in v2.
        /// Notably, this will return `inline-comment` for inline comments and `footer-comment` for footer comments, which is distinct from them
        /// both being represented by `comment` in v1.
        /// 
        /// **[Permissions](https://confluence.atlassian.com/x/_AozKw) required**:
        /// Permission to view the requested content. Any content that the user does not have permission to view or does not exist will map to `null` in the response.
        /// </remarks>
        /// <returns>
        /// A <see cref="Task"/> representing the <see cref="IApiResponse"/> instance containing the result:
        /// <list type="table">
        /// <listheader>
        /// <term>Status</term>
        /// <description>Description</description>
        /// </listheader>
        /// <item>
        /// <term>200</term>
        /// <description>Returned if the requested content ids are successfully converted to their content types</description>
        /// </item>
        /// <item>
        /// <term>400</term>
        /// <description>Returned if an invalid request is provided.</description>
        /// </item>
        /// <item>
        /// <term>401</term>
        /// <description>Returned if the authentication credentials are incorrect or missing\nfrom the request.</description>
        /// </item>
        /// </list>
        /// </returns>
        [Headers("Accept: application/json")]
        [Post("/content/convert-ids-to-types")]
        Task<IApiResponse<ContentIdToContentTypeResponse>> ConvertContentIdsToContentTypesAsync([Body] object? body = default, CancellationToken cancellationToken = default);
    }

    /// <summary>Get pages for label</summary>
    [System.CodeDom.Compiler.GeneratedCode("Refitter", "1.0.0.0")]
    public partial interface IPageApi
    {
        /// <summary>Get pages for label</summary>
        /// <remarks>
        /// Returns the pages of specified label. The number of results is limited by the `limit` parameter and additional results (if available)
        /// will be available through the `next` URL present in the `Link` response header.
        /// 
        /// **[Permissions](https://confluence.atlassian.com/x/_AozKw) required**:
        /// Permission to view the content of the page and its corresponding space.
        /// </remarks>
        /// <param name="id">The ID of the label for which pages should be returned.</param>
        /// <param name="space_id">Filter the results based on space ids. Multiple space ids can be specified as a comma-separated list.</param>
        /// <param name="body_format">The content format types to be returned in the `body` field of the response. If available, the representation will be available under a response field of the same name under the `body` field.</param>
        /// <param name="sort">Used to sort the result by a particular field.</param>
        /// <param name="cursor">Used for pagination, this opaque cursor will be returned in the `next` URL in the `Link` response header. Use the relative URL in the `Link` header to retrieve the `next` set of results.</param>
        /// <param name="limit">Maximum number of pages per result to return. If more results exist, use the `Link` header to retrieve a relative URL that will return the next set of results.</param>
        /// <returns>
        /// A <see cref="Task"/> representing the <see cref="IApiResponse"/> instance containing the result:
        /// <list type="table">
        /// <listheader>
        /// <term>Status</term>
        /// <description>Description</description>
        /// </listheader>
        /// <item>
        /// <term>200</term>
        /// <description>Returned if the requested pages for specified label were successfully fetched.</description>
        /// </item>
        /// <item>
        /// <term>400</term>
        /// <description>Returned if an invalid request is provided.</description>
        /// </item>
        /// <item>
        /// <term>401</term>
        /// <description>Returned if the authentication credentials are incorrect or missing\nfrom the request.</description>
        /// </item>
        /// <item>
        /// <term>404</term>
        /// <description>Returned if the calling user does not have permission to view the\nrequested label or label was not found.</description>
        /// </item>
        /// </list>
        /// </returns>
        [Headers("Accept: application/json")]
        [Get("/labels/{id}/pages")]
        Task<IApiResponse<Response28>> GetLabelPagesAsync(long id, [Query(CollectionFormat.Multi), AliasAs("space-id")] IEnumerable<long>? space_id = default, [Query, AliasAs("body-format")] PrimaryBodyRepresentation? body_format = default, [Query] PageSortOrder? sort = default, [Query] string? cursor = default, [Query] int? limit = default, CancellationToken cancellationToken = default);

        /// <summary>Get pages</summary>
        /// <remarks>
        /// Returns all pages. The number of results is limited by the `limit` parameter and additional results (if available)
        /// will be available through the `next` URL present in the `Link` response header.
        /// 
        /// **[Permissions](https://confluence.atlassian.com/x/_AozKw) required**:
        /// Permission to access the Confluence site ('Can use' global permission).
        /// Only pages that the user has permission to view will be returned.
        /// </remarks>
        /// <param name="id">Filter the results based on page ids. Multiple page ids can be specified as a comma-separated list.</param>
        /// <param name="space_id">Filter the results based on space ids. Multiple space ids can be specified as a comma-separated list.</param>
        /// <param name="sort">Used to sort the result by a particular field.</param>
        /// <param name="status">Filter the results to pages based on their status. By default, `current` and `archived` are used.</param>
        /// <param name="title">Filter the results to pages based on their title.</param>
        /// <param name="body_format">The content format types to be returned in the `body` field of the response. If available, the representation will be available under a response field of the same name under the `body` field.</param>
        /// <param name="cursor">Used for pagination, this opaque cursor will be returned in the `next` URL in the `Link` response header. Use the relative URL in the `Link` header to retrieve the `next` set of results.</param>
        /// <param name="limit">Maximum number of pages per result to return. If more results exist, use the `Link` header to retrieve a relative URL that will return the next set of results.</param>
        /// <returns>
        /// A <see cref="Task"/> representing the <see cref="IApiResponse"/> instance containing the result:
        /// <list type="table">
        /// <listheader>
        /// <term>Status</term>
        /// <description>Description</description>
        /// </listheader>
        /// <item>
        /// <term>200</term>
        /// <description>Returned if the requested pages are returned.</description>
        /// </item>
        /// <item>
        /// <term>400</term>
        /// <description>Returned if an invalid request is provided.</description>
        /// </item>
        /// <item>
        /// <term>401</term>
        /// <description>Returned if the authentication credentials are incorrect or missing\nfrom the request.</description>
        /// </item>
        /// </list>
        /// </returns>
        [Headers("Accept: application/json")]
        [Get("/pages")]
        Task<IApiResponse<Response29>> GetPagesAsync([Query(CollectionFormat.Multi)] IEnumerable<long>? id = default, [Query(CollectionFormat.Multi), AliasAs("space-id")] IEnumerable<long>? space_id = default, [Query] PageSortOrder? sort = default, [Query(CollectionFormat.Multi)] IEnumerable<Anonymous5>? status = default, [Query] string? title = default, [Query, AliasAs("body-format")] PrimaryBodyRepresentation? body_format = default, [Query] string? cursor = default, [Query] int? limit = default, CancellationToken cancellationToken = default);

        /// <summary>Create page</summary>
        /// <remarks>
        /// Creates a page in the space.
        /// 
        /// Pages are created as published by default unless specified as a draft in the status field. If creating a published page, the title must be specified.
        /// 
        /// **[Permissions](https://confluence.atlassian.com/x/_AozKw) required**:
        /// Permission to view the corresponding space. Permission to create a page in the space.
        /// </remarks>
        /// <param name="embedded">Tag the content as embedded and content will be created in NCS.</param>
        /// <param name="@private">The page will be private. Only the user who creates this page will have permission to view and edit one.</param>
        /// <param name="root_level">The page will be created at the root level of the space (outside the space homepage tree).</param>
        /// <returns>
        /// A <see cref="Task"/> representing the <see cref="IApiResponse"/> instance containing the result:
        /// <list type="table">
        /// <listheader>
        /// <term>Status</term>
        /// <description>Description</description>
        /// </listheader>
        /// <item>
        /// <term>200</term>
        /// <description>Returned if the page was successfully created.</description>
        /// </item>
        /// <item>
        /// <term>400</term>
        /// <description>Returned if an invalid request is provided.</description>
        /// </item>
        /// <item>
        /// <term>401</term>
        /// <description>Returned if the authentication credentials are incorrect or missing from the request.</description>
        /// </item>
        /// <item>
        /// <term>404</term>
        /// <description>Returned if:\n- The space does not exist\n- The user does not have permissions to view the space\n- The user does not have the needed permissions to create a page in the provided space</description>
        /// </item>
        /// <item>
        /// <term>413</term>
        /// <description>Returned if the request is too large in size (over 5 MB).</description>
        /// </item>
        /// </list>
        /// </returns>
        [Headers("Accept: application/json")]
        [Post("/pages")]
        Task<IApiResponse<Response30>> CreatePageAsync([Query] bool? embedded = default, [Query, AliasAs("private")] bool? @private = default, [Query, AliasAs("root-level")] bool? root_level = default, [Body] object? body = default, CancellationToken cancellationToken = default);

        /// <summary>Get page by id</summary>
        /// <remarks>
        /// Returns a specific page.
        /// 
        /// **[Permissions](https://confluence.atlassian.com/x/_AozKw) required**:
        /// Permission to view the page and its corresponding space.
        /// </remarks>
        /// <param name="id">The ID of the page to be returned. If you don't know the page ID, use Get pages and filter the results.</param>
        /// <param name="body_format">The content format types to be returned in the `body` field of the response. If available, the representation will be available under a response field of the same name under the `body` field.</param>
        /// <param name="get_draft">Retrieve the draft version of this page.</param>
        /// <param name="version">Allows you to retrieve a previously published version. Specify the previous version's number to retrieve its details.</param>
        /// <param name="include_labels">
        /// Includes labels associated with this page in the response.
        /// The number of results will be limited to 50 and sorted in the default sort order.
        /// A `meta` and `_links` property will be present to indicate if more results are available and a link to retrieve the rest of the results.
        /// </param>
        /// <param name="include_properties">
        /// Includes content properties associated with this page in the response.
        /// The number of results will be limited to 50 and sorted in the default sort order.
        /// A `meta` and `_links` property will be present to indicate if more results are available and a link to retrieve the rest of the results.
        /// </param>
        /// <param name="include_operations">
        /// Includes operations associated with this page in the response.
        /// The number of results will be limited to 50 and sorted in the default sort order.
        /// A `meta` and `_links` property will be present to indicate if more results are available and a link to retrieve the rest of the results.
        /// </param>
        /// <param name="include_likes">
        /// Includes likes associated with this page in the response.
        /// The number of results will be limited to 50 and sorted in the default sort order.
        /// A `meta` and `_links` property will be present to indicate if more results are available and a link to retrieve the rest of the results.
        /// </param>
        /// <param name="include_versions">
        /// Includes versions associated with this page in the response.
        /// The number of results will be limited to 50 and sorted in the default sort order.
        /// A `meta` and `_links` property will be present to indicate if more results are available and a link to retrieve the rest of the results.
        /// </param>
        /// <param name="include_version">
        /// Includes the current version associated with this page in the response.
        /// By default this is included and can be omitted by setting the value to `false`.
        /// </param>
        /// <param name="include_favorited_by_current_user_status">Includes whether this page has been favorited by the current user.</param>
        /// <returns>
        /// A <see cref="Task"/> representing the <see cref="IApiResponse"/> instance containing the result:
        /// <list type="table">
        /// <listheader>
        /// <term>Status</term>
        /// <description>Description</description>
        /// </listheader>
        /// <item>
        /// <term>200</term>
        /// <description>Returned if the requested page is returned.</description>
        /// </item>
        /// <item>
        /// <term>400</term>
        /// <description>Returned if an invalid request is provided.</description>
        /// </item>
        /// <item>
        /// <term>401</term>
        /// <description>Returned if the authentication credentials are incorrect or missing\nfrom the request.</description>
        /// </item>
        /// <item>
        /// <term>404</term>
        /// <description>Returned if the calling user does not have permission to view the\nrequested page or the page was not found.</description>
        /// </item>
        /// </list>
        /// </returns>
        [Headers("Accept: application/json")]
        [Get("/pages/{id}")]
        Task<IApiResponse<Response31>> GetPageByIdAsync(long id, [Query, AliasAs("body-format")] PrimaryBodyRepresentationSingle? body_format = default, [Query, AliasAs("get-draft")] bool? get_draft = default, [Query] int? version = default, [Query, AliasAs("include-labels")] bool? include_labels = default, [Query, AliasAs("include-properties")] bool? include_properties = default, [Query, AliasAs("include-operations")] bool? include_operations = default, [Query, AliasAs("include-likes")] bool? include_likes = default, [Query, AliasAs("include-versions")] bool? include_versions = default, [Query, AliasAs("include-version")] bool? include_version = default, [Query, AliasAs("include-favorited-by-current-user-status")] bool? include_favorited_by_current_user_status = default, CancellationToken cancellationToken = default);

        /// <summary>Update page</summary>
        /// <remarks>
        /// Update a page by id.
        /// 
        /// **[Permissions](https://confluence.atlassian.com/x/_AozKw) required**:
        /// Permission to view the page and its corresponding space. Permission to update pages in the space.
        /// </remarks>
        /// <param name="id">The ID of the page to be updated. If you don't know the page ID, use Get Pages and filter the results.</param>
        /// <returns>
        /// A <see cref="Task"/> representing the <see cref="IApiResponse"/> instance containing the result:
        /// <list type="table">
        /// <listheader>
        /// <term>Status</term>
        /// <description>Description</description>
        /// </listheader>
        /// <item>
        /// <term>200</term>
        /// <description>Returned if the requested page is successfully updated.</description>
        /// </item>
        /// <item>
        /// <term>400</term>
        /// <description>Returned if an invalid request is provided.</description>
        /// </item>
        /// <item>
        /// <term>401</term>
        /// <description>Returned if the authentication credentials are incorrect or missing\nfrom the request.</description>
        /// </item>
        /// <item>
        /// <term>404</term>
        /// <description>Returned if:\n- The provided page does not exist\n- The user does not have permissions to view the page\n- The user does not have the needed permissions to update a page in the space\n- The user provides a parentId for a page that does not exist or they do not have permission to view\n- There are no spaces associated with the given spaceId</description>
        /// </item>
        /// </list>
        /// </returns>
        [Headers("Accept: application/json")]
        [Put("/pages/{id}")]
        Task<IApiResponse<Response32>> UpdatePageAsync(long id, [Body] object? body = default, CancellationToken cancellationToken = default);

        /// <summary>Delete page</summary>
        /// <remarks>
        /// Delete a page by id.
        /// 
        /// By default this will delete pages that are non-drafts. To delete a page that is a draft, the endpoint must be called on a
        /// draft with the following param `draft=true`. Discarded drafts are not sent to the trash and are permanently deleted.
        /// 
        /// Deleting a page moves the page to the trash, where it can be restored later. To permanently delete a page (or "purge" it),
        /// the endpoint must be called on a **trashed** page with the following param `purge=true`.
        /// 
        /// **[Permissions](https://confluence.atlassian.com/x/_AozKw) required**:
        /// Permission to view the page and its corresponding space.
        /// Permission to delete pages in the space.
        /// Permission to administer the space (if attempting to purge).
        /// </remarks>
        /// <param name="id">The ID of the page to be deleted.</param>
        /// <param name="purge">If attempting to purge the page.</param>
        /// <param name="draft">If attempting to delete a page that is a draft.</param>
        /// <returns>
        /// A <see cref="Task"/> representing the <see cref="IApiResponse"/> instance containing the result:
        /// <list type="table">
        /// <listheader>
        /// <term>Status</term>
        /// <description>Description</description>
        /// </listheader>
        /// <item>
        /// <term>204</term>
        /// <description>Returned if the page was successfully deleted.</description>
        /// </item>
        /// <item>
        /// <term>400</term>
        /// <description>Returned if an invalid request is provided.</description>
        /// </item>
        /// <item>
        /// <term>401</term>
        /// <description>Returned if the authentication credentials are incorrect or missing\nfrom the request.</description>
        /// </item>
        /// <item>
        /// <term>404</term>
        /// <description>Returned if:\n- The provided page does not exist\n- The user does not have permissions to view the page\n- The user does not have the needed permissions to delete a page in the space</description>
        /// </item>
        /// </list>
        /// </returns>
        [Delete("/pages/{id}")]
        Task<IApiResponse> DeletePageAsync(long id, [Query] bool? purge = default, [Query] bool? draft = default, CancellationToken cancellationToken = default);

        /// <summary>Get pages in space</summary>
        /// <remarks>
        /// Returns all pages in a space. The number of results is limited by the `limit` parameter and additional results (if available)
        /// will be available through the `next` URL present in the `Link` response header.
        /// 
        /// **[Permissions](https://confluence.atlassian.com/x/_AozKw) required**:
        /// Permission to access the Confluence site ('Can use' global permission) and 'View' permission for the space.
        /// Only pages that the user has permission to view will be returned.
        /// </remarks>
        /// <param name="id">The ID of the space for which pages should be returned.</param>
        /// <param name="depth">Filter the results to pages at the root level of the space or to all pages in the space.</param>
        /// <param name="sort">Used to sort the result by a particular field.</param>
        /// <param name="status">Filter the results to pages based on their status. By default, `current` and `archived` are used.</param>
        /// <param name="title">Filter the results to pages based on their title.</param>
        /// <param name="body_format">The content format types to be returned in the `body` field of the response. If available, the representation will be available under a response field of the same name under the `body` field.</param>
        /// <param name="cursor">Used for pagination, this opaque cursor will be returned in the `next` URL in the `Link` response header. Use the relative URL in the `Link` header to retrieve the `next` set of results.</param>
        /// <param name="limit">Maximum number of pages per result to return. If more results exist, use the `Link` header to retrieve a relative URL that will return the next set of results.</param>
        /// <returns>
        /// A <see cref="Task"/> representing the <see cref="IApiResponse"/> instance containing the result:
        /// <list type="table">
        /// <listheader>
        /// <term>Status</term>
        /// <description>Description</description>
        /// </listheader>
        /// <item>
        /// <term>200</term>
        /// <description>Returned if the requested pages are returned.</description>
        /// </item>
        /// <item>
        /// <term>400</term>
        /// <description>Returned if an invalid request is provided.</description>
        /// </item>
        /// <item>
        /// <term>401</term>
        /// <description>Returned if the authentication credentials are incorrect or missing\nfrom the request.</description>
        /// </item>
        /// <item>
        /// <term>404</term>
        /// <description>Returned if the calling user does not have permission to view the\nspecified space or the space was not found.</description>
        /// </item>
        /// </list>
        /// </returns>
        [Headers("Accept: application/json")]
        [Get("/spaces/{id}/pages")]
        Task<IApiResponse<Response58>> GetPagesInSpaceAsync(long id, [Query] Depth? depth = default, [Query] PageSortOrder? sort = default, [Query(CollectionFormat.Multi)] IEnumerable<Anonymous8>? status = default, [Query] string? title = default, [Query, AliasAs("body-format")] PrimaryBodyRepresentation? body_format = default, [Query] string? cursor = default, [Query] int? limit = default, CancellationToken cancellationToken = default);
    }

    /// <summary>Create whiteboard</summary>
    [System.CodeDom.Compiler.GeneratedCode("Refitter", "1.0.0.0")]
    public partial interface IWhiteboardApi
    {
        /// <summary>Create whiteboard</summary>
        /// <remarks>
        /// Creates a whiteboard in the space.
        /// 
        /// **[Permissions](https://confluence.atlassian.com/x/_AozKw) required**:
        /// Permission to view the corresponding space. Permission to create a whiteboard in the space.
        /// </remarks>
        /// <param name="@private">The whiteboard will be private. Only the user who creates this whiteboard will have permission to view and edit one.</param>
        /// <returns>
        /// A <see cref="Task"/> representing the <see cref="IApiResponse"/> instance containing the result:
        /// <list type="table">
        /// <listheader>
        /// <term>Status</term>
        /// <description>Description</description>
        /// </listheader>
        /// <item>
        /// <term>200</term>
        /// <description>Returned if the whiteboard was successfully created.</description>
        /// </item>
        /// <item>
        /// <term>400</term>
        /// <description>Returned if an invalid request is provided.</description>
        /// </item>
        /// <item>
        /// <term>401</term>
        /// <description>Returned if the authentication credentials are incorrect or missing from the request.</description>
        /// </item>
        /// <item>
        /// <term>404</term>
        /// <description>Returned if:\n- The space does not exist\n- The user does not have permissions to view the space\n- The user does not have the needed permissions to create a whiteboard in the provided space</description>
        /// </item>
        /// <item>
        /// <term>413</term>
        /// <description>Returned if the request is too large in size (over 5 MB).</description>
        /// </item>
        /// </list>
        /// </returns>
        [Headers("Accept: application/json")]
        [Post("/whiteboards")]
        Task<IApiResponse<Response39>> CreateWhiteboardAsync([Query, AliasAs("private")] bool? @private = default, [Body] object? body = default, CancellationToken cancellationToken = default);

        /// <summary>Get whiteboard by id</summary>
        /// <remarks>
        /// Returns a specific whiteboard.
        /// 
        /// **[Permissions](https://confluence.atlassian.com/x/_AozKw) required**:
        /// Permission to view the whiteboard and its corresponding space.
        /// </remarks>
        /// <param name="id">The ID of the whiteboard to be returned</param>
        /// <returns>
        /// A <see cref="Task"/> representing the <see cref="IApiResponse"/> instance containing the result:
        /// <list type="table">
        /// <listheader>
        /// <term>Status</term>
        /// <description>Description</description>
        /// </listheader>
        /// <item>
        /// <term>200</term>
        /// <description>Returned if the requested whiteboard is returned.</description>
        /// </item>
        /// <item>
        /// <term>400</term>
        /// <description>Returned if an invalid request is provided.</description>
        /// </item>
        /// <item>
        /// <term>401</term>
        /// <description>Returned if the authentication credentials are incorrect or missing\nfrom the request.</description>
        /// </item>
        /// <item>
        /// <term>404</term>
        /// <description>Returned if the calling user does not have permission to view the\nrequested whiteboard or the whiteboard was not found.</description>
        /// </item>
        /// </list>
        /// </returns>
        [Headers("Accept: application/json")]
        [Get("/whiteboards/{id}")]
        Task<IApiResponse<Response40>> GetWhiteboardByIdAsync(long id, CancellationToken cancellationToken = default);

        /// <summary>Delete whiteboard</summary>
        /// <remarks>
        /// Delete a whiteboard by id.
        /// 
        /// Deleting a whiteboard moves the whiteboard to the trash, where it can be restored later
        /// 
        /// **[Permissions](https://confluence.atlassian.com/x/_AozKw) required**:
        /// Permission to view the whiteboard and its corresponding space.
        /// Permission to delete whiteboards in the space.
        /// </remarks>
        /// <param name="id">The ID of the whiteboard to be deleted.</param>
        /// <returns>
        /// A <see cref="Task"/> representing the <see cref="IApiResponse"/> instance containing the result:
        /// <list type="table">
        /// <listheader>
        /// <term>Status</term>
        /// <description>Description</description>
        /// </listheader>
        /// <item>
        /// <term>204</term>
        /// <description>Returned if the whiteboard was successfully deleted.</description>
        /// </item>
        /// <item>
        /// <term>400</term>
        /// <description>Returned if an invalid request is provided.</description>
        /// </item>
        /// <item>
        /// <term>401</term>
        /// <description>Returned if the authentication credentials are incorrect or missing\nfrom the request.</description>
        /// </item>
        /// <item>
        /// <term>404</term>
        /// <description>Returned if:\n- The provided whiteboard does not exist\n- The user does not have permissions to view the whiteboard\n- The user does not have the needed permissions to delete a whiteboard in the space</description>
        /// </item>
        /// </list>
        /// </returns>
        [Delete("/whiteboards/{id}")]
        Task<IApiResponse> DeleteWhiteboardAsync(long id, CancellationToken cancellationToken = default);
    }

    /// <summary>Get all ancestors of the whiteboard</summary>
    [System.CodeDom.Compiler.GeneratedCode("Refitter", "1.0.0.0")]
    public partial interface IAncestorsApi
    {
        /// <summary>Get all ancestors of the whiteboard</summary>
        /// <remarks>
        /// Returns all ancestors for a given whiteboard by ID in top-to-bottom order (that is, the highest ancestor is the first
        /// item in the response payload). The number of results is limited by the `limit` parameter and additional results (if available)
        /// will be available by calling this endpoint with the ID of first ancestor in the response payload.
        /// 
        /// This endpoint returns minimal information about each ancestor. To fetch more details, use a related endpoint, such
        /// as [Get whiteboard by id](https://developer.atlassian.com/cloud/confluence/rest/v2/api-group-whiteboard/#api-whiteboards-id-get).
        /// 
        /// **[Permissions](https://confluence.atlassian.com/x/_AozKw) required**:
        /// Permission to access the Confluence site ('Can use' global permission).
        /// Permission to view the whiteboard and its corresponding space
        /// </remarks>
        /// <param name="id">The ID of the whiteboard.</param>
        /// <param name="limit">Maximum number of items per result to return. If more results exist, call the endpoint with the highest ancestor's ID to fetch the next set of results.</param>
        /// <returns>
        /// A <see cref="Task"/> representing the <see cref="IApiResponse"/> instance containing the result:
        /// <list type="table">
        /// <listheader>
        /// <term>Status</term>
        /// <description>Description</description>
        /// </listheader>
        /// <item>
        /// <term>200</term>
        /// <description>Returned if the requested ancestors are returned.</description>
        /// </item>
        /// <item>
        /// <term>400</term>
        /// <description>Returned if an invalid request is provided.</description>
        /// </item>
        /// <item>
        /// <term>401</term>
        /// <description>Returned if the authentication credentials are incorrect or missing\nfrom the request.</description>
        /// </item>
        /// <item>
        /// <term>404</term>
        /// <description>Returned if the calling user does not have permission to view the\nspecified whiteboard or the whiteboard was not found.</description>
        /// </item>
        /// </list>
        /// </returns>
        [Headers("Accept: application/json")]
        [Get("/whiteboards/{id}/ancestors")]
        Task<IApiResponse<Response42>> GetWhiteboardAncestorsAsync(long id, [Query] int? limit = default, CancellationToken cancellationToken = default);

        /// <summary>Get all ancestors of the database</summary>
        /// <remarks>
        /// Returns all ancestors for a given database by ID in top-to-bottom order (that is, the highest ancestor is the first
        /// item in the response payload). The number of results is limited by the `limit` parameter and additional results (if available)
        /// will be available by calling this endpoint with the ID of first ancestor in the response payload.
        /// 
        /// This endpoint returns minimal information about each ancestor. To fetch more details, use a related endpoint, such
        /// as [Get database by id](https://developer.atlassian.com/cloud/confluence/rest/v2/api-group-database/#api-databases-id-get).
        /// 
        /// **[Permissions](https://confluence.atlassian.com/x/_AozKw) required**:
        /// Permission to access the Confluence site ('Can use' global permission).
        /// Permission to view the database and its corresponding space
        /// </remarks>
        /// <param name="id">The ID of the database.</param>
        /// <param name="limit">Maximum number of items per result to return. If more results exist, call the endpoint with the highest ancestor's ID to fetch the next set of results.</param>
        /// <returns>
        /// A <see cref="Task"/> representing the <see cref="IApiResponse"/> instance containing the result:
        /// <list type="table">
        /// <listheader>
        /// <term>Status</term>
        /// <description>Description</description>
        /// </listheader>
        /// <item>
        /// <term>200</term>
        /// <description>Returned if the requested ancestors are returned.</description>
        /// </item>
        /// <item>
        /// <term>400</term>
        /// <description>Returned if an invalid request is provided.</description>
        /// </item>
        /// <item>
        /// <term>401</term>
        /// <description>Returned if the authentication credentials are incorrect or missing\nfrom the request.</description>
        /// </item>
        /// <item>
        /// <term>404</term>
        /// <description>Returned if the calling user does not have permission to view the\nspecified database or the database was not found.</description>
        /// </item>
        /// </list>
        /// </returns>
        [Headers("Accept: application/json")]
        [Get("/databases/{id}/ancestors")]
        Task<IApiResponse<Response46>> GetDatabaseAncestorsAsync(long id, [Query] int? limit = default, CancellationToken cancellationToken = default);

        /// <summary>Get all ancestors of the Smart Link in the content tree</summary>
        /// <remarks>
        /// Returns all ancestors for a given Smart Link in the content tree by ID in top-to-bottom order (that is, the highest ancestor is
        /// the first item in the response payload). The number of results is limited by the `limit` parameter and additional results
        /// (if available) will be available by calling this endpoint with the ID of first ancestor in the response payload.
        /// 
        /// This endpoint returns minimal information about each ancestor. To fetch more details, use a related endpoint, such
        /// as [Get Smart Link in the content tree by id](https://developer.atlassian.com/cloud/confluence/rest/v2/api-group-smart-link/#api-embeds-id-get).
        /// 
        /// **[Permissions](https://confluence.atlassian.com/x/_AozKw) required**:
        /// Permission to access the Confluence site ('Can use' global permission).
        /// Permission to view the Smart Link in the content tree and its corresponding space
        /// </remarks>
        /// <param name="id">The ID of the Smart Link in the content tree.</param>
        /// <param name="limit">Maximum number of items per result to return. If more results exist, call the endpoint with the highest ancestor's ID to fetch the next set of results.</param>
        /// <returns>
        /// A <see cref="Task"/> representing the <see cref="IApiResponse"/> instance containing the result:
        /// <list type="table">
        /// <listheader>
        /// <term>Status</term>
        /// <description>Description</description>
        /// </listheader>
        /// <item>
        /// <term>200</term>
        /// <description>Returned if the requested ancestors are returned.</description>
        /// </item>
        /// <item>
        /// <term>400</term>
        /// <description>Returned if an invalid request is provided.</description>
        /// </item>
        /// <item>
        /// <term>401</term>
        /// <description>Returned if the authentication credentials are incorrect or missing\nfrom the request.</description>
        /// </item>
        /// <item>
        /// <term>404</term>
        /// <description>Returned if the calling user does not have permission to view the\nspecified Smart Link in the content tree or the Smart Link was not found.</description>
        /// </item>
        /// </list>
        /// </returns>
        [Headers("Accept: application/json")]
        [Get("/embeds/{id}/ancestors")]
        Task<IApiResponse<Response50>> GetSmartLinkAncestorsAsync(long id, [Query] int? limit = default, CancellationToken cancellationToken = default);

        /// <summary>Get all ancestors of page</summary>
        /// <remarks>
        /// Returns all ancestors for a given page by ID in top-to-bottom order (that is, the highest ancestor is the first
        /// item in the response payload). The number of results is limited by the `limit` parameter and additional results (if available)
        /// will be available by calling this endpoint with the ID of first ancestor in the response payload.
        /// 
        /// This endpoint returns minimal information about each ancestor. To fetch more details, use a related endpoint, such
        /// as [Get page by id](https://developer.atlassian.com/cloud/confluence/rest/v2/api-group-page/#api-pages-id-get).
        /// 
        /// **[Permissions](https://confluence.atlassian.com/x/_AozKw) required**:
        /// Permission to access the Confluence site ('Can use' global permission).
        /// </remarks>
        /// <param name="id">The ID of the page.</param>
        /// <param name="limit">Maximum number of pages per result to return. If more results exist, call this endpoint with the highest ancestor's ID to fetch the next set of results.</param>
        /// <returns>
        /// A <see cref="Task"/> representing the <see cref="IApiResponse"/> instance containing the result:
        /// <list type="table">
        /// <listheader>
        /// <term>Status</term>
        /// <description>Description</description>
        /// </listheader>
        /// <item>
        /// <term>200</term>
        /// <description>Returned if the requested ancestors are returned.</description>
        /// </item>
        /// <item>
        /// <term>400</term>
        /// <description>Returned if an invalid request is provided.</description>
        /// </item>
        /// <item>
        /// <term>401</term>
        /// <description>Returned if the authentication credentials are incorrect or missing\nfrom the request.</description>
        /// </item>
        /// <item>
        /// <term>404</term>
        /// <description>Returned if the calling user does not have permission to view the\nspecified page or the page was not found.</description>
        /// </item>
        /// </list>
        /// </returns>
        [Headers("Accept: application/json")]
        [Get("/pages/{id}/ancestors")]
        Task<IApiResponse<Response82>> GetPageAncestorsAsync(long id, [Query] int? limit = default, CancellationToken cancellationToken = default);
    }

    /// <summary>Create database</summary>
    [System.CodeDom.Compiler.GeneratedCode("Refitter", "1.0.0.0")]
    public partial interface IDatabaseApi
    {
        /// <summary>Create database</summary>
        /// <remarks>
        /// Creates a database in the space.
        /// 
        /// **[Permissions](https://confluence.atlassian.com/x/_AozKw) required**:
        /// Permission to view the corresponding space. Permission to create a database in the space.
        /// </remarks>
        /// <param name="@private">The database will be private. Only the user who creates this database will have permission to view and edit one.</param>
        /// <returns>
        /// A <see cref="Task"/> representing the <see cref="IApiResponse"/> instance containing the result:
        /// <list type="table">
        /// <listheader>
        /// <term>Status</term>
        /// <description>Description</description>
        /// </listheader>
        /// <item>
        /// <term>200</term>
        /// <description>Returned if the database was successfully created.</description>
        /// </item>
        /// <item>
        /// <term>400</term>
        /// <description>Returned if an invalid request is provided.</description>
        /// </item>
        /// <item>
        /// <term>401</term>
        /// <description>Returned if the authentication credentials are incorrect or missing from the request.</description>
        /// </item>
        /// <item>
        /// <term>404</term>
        /// <description>Returned if:\n- The space does not exist\n- The user does not have permissions to view the space\n- The user does not have the needed permissions to create a database in the provided space</description>
        /// </item>
        /// <item>
        /// <term>413</term>
        /// <description>Returned if the request is too large in size (over 5 MB).</description>
        /// </item>
        /// </list>
        /// </returns>
        [Headers("Accept: application/json")]
        [Post("/databases")]
        Task<IApiResponse<Response43>> CreateDatabaseAsync([Query, AliasAs("private")] bool? @private = default, [Body] object? body = default, CancellationToken cancellationToken = default);

        /// <summary>Get database by id</summary>
        /// <remarks>
        /// Returns a specific database.
        /// 
        /// **[Permissions](https://confluence.atlassian.com/x/_AozKw) required**:
        /// Permission to view the database and its corresponding space.
        /// </remarks>
        /// <param name="id">The ID of the database to be returned</param>
        /// <returns>
        /// A <see cref="Task"/> representing the <see cref="IApiResponse"/> instance containing the result:
        /// <list type="table">
        /// <listheader>
        /// <term>Status</term>
        /// <description>Description</description>
        /// </listheader>
        /// <item>
        /// <term>200</term>
        /// <description>Returned if the requested database is returned.</description>
        /// </item>
        /// <item>
        /// <term>400</term>
        /// <description>Returned if an invalid request is provided.</description>
        /// </item>
        /// <item>
        /// <term>401</term>
        /// <description>Returned if the authentication credentials are incorrect or missing\nfrom the request.</description>
        /// </item>
        /// <item>
        /// <term>404</term>
        /// <description>Returned if the calling user does not have permission to view the\nrequested database or the database was not found.</description>
        /// </item>
        /// </list>
        /// </returns>
        [Headers("Accept: application/json")]
        [Get("/databases/{id}")]
        Task<IApiResponse<Response44>> GetDatabaseByIdAsync(long id, CancellationToken cancellationToken = default);

        /// <summary>Delete database</summary>
        /// <remarks>
        /// Delete a database by id.
        /// 
        /// Deleting a database moves the database to the trash, where it can be restored later
        /// 
        /// **[Permissions](https://confluence.atlassian.com/x/_AozKw) required**:
        /// Permission to view the database and its corresponding space.
        /// Permission to delete databases in the space.
        /// </remarks>
        /// <param name="id">The ID of the database to be deleted.</param>
        /// <returns>
        /// A <see cref="Task"/> representing the <see cref="IApiResponse"/> instance containing the result:
        /// <list type="table">
        /// <listheader>
        /// <term>Status</term>
        /// <description>Description</description>
        /// </listheader>
        /// <item>
        /// <term>204</term>
        /// <description>Returned if the database was successfully deleted.</description>
        /// </item>
        /// <item>
        /// <term>400</term>
        /// <description>Returned if an invalid request is provided.</description>
        /// </item>
        /// <item>
        /// <term>401</term>
        /// <description>Returned if the authentication credentials are incorrect or missing\nfrom the request.</description>
        /// </item>
        /// <item>
        /// <term>404</term>
        /// <description>Returned if:\n- The provided database does not exist\n- The user does not have permissions to view the database\n- The user does not have the needed permissions to delete a database in the space</description>
        /// </item>
        /// </list>
        /// </returns>
        [Delete("/databases/{id}")]
        Task<IApiResponse> DeleteDatabaseAsync(long id, CancellationToken cancellationToken = default);
    }

    /// <summary>Create Smart Link in the content tree</summary>
    [System.CodeDom.Compiler.GeneratedCode("Refitter", "1.0.0.0")]
    public partial interface ISmartLinkApi
    {
        /// <summary>Create Smart Link in the content tree</summary>
        /// <remarks>
        /// Creates a Smart Link in the content tree in the space.
        /// 
        /// **[Permissions](https://confluence.atlassian.com/x/_AozKw) required**:
        /// Permission to view the corresponding space. Permission to create a Smart Link in the content tree in the space.
        /// </remarks>
        /// <param name="@private">The Smart Link will be private. Only the user who creates this Smart Link in the content tree will have permission to view and edit one.</param>
        /// <returns>
        /// A <see cref="Task"/> representing the <see cref="IApiResponse"/> instance containing the result:
        /// <list type="table">
        /// <listheader>
        /// <term>Status</term>
        /// <description>Description</description>
        /// </listheader>
        /// <item>
        /// <term>200</term>
        /// <description>Returned if the Smart Link was successfully created in the content tree.</description>
        /// </item>
        /// <item>
        /// <term>400</term>
        /// <description>Returned if an invalid request is provided.</description>
        /// </item>
        /// <item>
        /// <term>401</term>
        /// <description>Returned if the authentication credentials are incorrect or missing from the request.</description>
        /// </item>
        /// <item>
        /// <term>404</term>
        /// <description>Returned if:\n- The space does not exist\n- The user does not have permissions to view the space\n- The user does not have the needed permissions to create a Smart Link in the content tree in the provided space</description>
        /// </item>
        /// <item>
        /// <term>413</term>
        /// <description>Returned if the request is too large in size (over 5 MB).</description>
        /// </item>
        /// </list>
        /// </returns>
        [Headers("Accept: application/json")]
        [Post("/embeds")]
        Task<IApiResponse<Response47>> CreateSmartLinkAsync([Query, AliasAs("private")] bool? @private = default, [Body] object? body = default, CancellationToken cancellationToken = default);

        /// <summary>Get Smart Link in the content tree by id</summary>
        /// <remarks>
        /// Returns a specific Smart Link in the content tree.
        /// 
        /// **[Permissions](https://confluence.atlassian.com/x/_AozKw) required**:
        /// Permission to view the Smart Link in the content tree and its corresponding space.
        /// </remarks>
        /// <param name="id">The ID of the Smart Link in the content tree to be returned.</param>
        /// <returns>
        /// A <see cref="Task"/> representing the <see cref="IApiResponse"/> instance containing the result:
        /// <list type="table">
        /// <listheader>
        /// <term>Status</term>
        /// <description>Description</description>
        /// </listheader>
        /// <item>
        /// <term>200</term>
        /// <description>Returned if the requested Smart Link in the content tree is returned.</description>
        /// </item>
        /// <item>
        /// <term>400</term>
        /// <description>Returned if an invalid request is provided.</description>
        /// </item>
        /// <item>
        /// <term>401</term>
        /// <description>Returned if the authentication credentials are incorrect or missing\nfrom the request.</description>
        /// </item>
        /// <item>
        /// <term>404</term>
        /// <description>Returned if the calling user does not have permission to view the\nrequested Smart Link in the content tree or the Smart Link was not found.</description>
        /// </item>
        /// </list>
        /// </returns>
        [Headers("Accept: application/json")]
        [Get("/embeds/{id}")]
        Task<IApiResponse<Response48>> GetSmartLinkByIdAsync(long id, CancellationToken cancellationToken = default);

        /// <summary>Delete Smart Link in the content tree</summary>
        /// <remarks>
        /// Delete a Smart Link in the content tree by id.
        /// 
        /// Deleting a Smart Link in the content tree moves the Smart Link to the trash, where it can be restored later
        /// 
        /// **[Permissions](https://confluence.atlassian.com/x/_AozKw) required**:
        /// Permission to view the Smart Link in the content tree and its corresponding space.
        /// Permission to delete Smart Links in the content tree in the space.
        /// </remarks>
        /// <param name="id">The ID of the Smart Link in the content tree to be deleted.</param>
        /// <returns>
        /// A <see cref="Task"/> representing the <see cref="IApiResponse"/> instance containing the result:
        /// <list type="table">
        /// <listheader>
        /// <term>Status</term>
        /// <description>Description</description>
        /// </listheader>
        /// <item>
        /// <term>204</term>
        /// <description>Returned if the Smart Link in the content tree was successfully deleted.</description>
        /// </item>
        /// <item>
        /// <term>400</term>
        /// <description>Returned if an invalid request is provided.</description>
        /// </item>
        /// <item>
        /// <term>401</term>
        /// <description>Returned if the authentication credentials are incorrect or missing\nfrom the request.</description>
        /// </item>
        /// <item>
        /// <term>404</term>
        /// <description>Returned if:\n- The provided Smart Link in the content tree does not exist\n- The user does not have permissions to view the Smart Link in the content tree\n- The user does not have the needed permissions to delete a Smart Link in the content tree in the space</description>
        /// </item>
        /// </list>
        /// </returns>
        [Delete("/embeds/{id}")]
        Task<IApiResponse> DeleteSmartLinkAsync(long id, CancellationToken cancellationToken = default);
    }

    /// <summary>Get spaces</summary>
    [System.CodeDom.Compiler.GeneratedCode("Refitter", "1.0.0.0")]
    public partial interface ISpaceApi
    {
        /// <summary>Get spaces</summary>
        /// <remarks>
        /// Returns all spaces. The results will be sorted by id ascending. The number of results is limited by the `limit` parameter and
        /// additional results (if available) will be available through the `next` URL present in the `Link` response header.
        /// 
        /// **[Permissions](https://confluence.atlassian.com/x/_AozKw) required**:
        /// Permission to access the Confluence site ('Can use' global permission).
        /// Only spaces that the user has permission to view will be returned.
        /// </remarks>
        /// <param name="ids">Filter the results to spaces based on their IDs. Multiple IDs can be specified as a comma-separated list.</param>
        /// <param name="keys">Filter the results to spaces based on their keys. Multiple keys can be specified as a comma-separated list.</param>
        /// <param name="type">Filter the results to spaces based on their type.</param>
        /// <param name="status">Filter the results to spaces based on their status.</param>
        /// <param name="labels">Filter the results to spaces based on their labels. Multiple labels can be specified as a comma-separated list.</param>
        /// <param name="favorited_by">Filter the results to spaces favorited by the user with the specified account ID.</param>
        /// <param name="not_favorited_by">Filter the results to spaces NOT favorited by the user with the specified account ID.</param>
        /// <param name="sort">Used to sort the result by a particular field.</param>
        /// <param name="description_format">The content format type to be returned in the `description` field of the response. If available, the representation will be available under a response field of the same name under the `description` field.</param>
        /// <param name="include_icon">If the icon for the space should be fetched or not.</param>
        /// <param name="cursor">Used for pagination, this opaque cursor will be returned in the `next` URL in the `Link` response header. Use the relative URL in the `Link` header to retrieve the `next` set of results.</param>
        /// <param name="limit">Maximum number of spaces per result to return. If more results exist, use the `Link` response header to retrieve a relative URL that will return the next set of results.</param>
        /// <returns>
        /// A <see cref="Task"/> representing the <see cref="IApiResponse"/> instance containing the result:
        /// <list type="table">
        /// <listheader>
        /// <term>Status</term>
        /// <description>Description</description>
        /// </listheader>
        /// <item>
        /// <term>200</term>
        /// <description>Returned if the requested spaces are returned.</description>
        /// </item>
        /// <item>
        /// <term>400</term>
        /// <description>Returned if an invalid request is provided.</description>
        /// </item>
        /// <item>
        /// <term>401</term>
        /// <description>Returned if the authentication credentials are incorrect or missing\nfrom the request.</description>
        /// </item>
        /// </list>
        /// </returns>
        [Headers("Accept: application/json")]
        [Get("/spaces")]
        Task<IApiResponse<Response52>> GetSpacesAsync([Query(CollectionFormat.Multi)] IEnumerable<long>? ids = default, [Query(CollectionFormat.Multi)] IEnumerable<string>? keys = default, [Query] Type? type = default, [Query] Status? status = default, [Query(CollectionFormat.Multi)] IEnumerable<string>? labels = default, [Query, AliasAs("favorited-by")] string? favorited_by = default, [Query, AliasAs("not-favorited-by")] string? not_favorited_by = default, [Query] SpaceSortOrder? sort = default, [Query, AliasAs("description-format")] SpaceDescriptionBodyRepresentation? description_format = default, [Query, AliasAs("include-icon")] bool? include_icon = default, [Query] string? cursor = default, [Query] int? limit = default, CancellationToken cancellationToken = default);

        /// <summary>Get space by id</summary>
        /// <remarks>
        /// Returns a specific space.
        /// 
        /// **[Permissions](https://confluence.atlassian.com/x/_AozKw) required**:
        /// Permission to view the space.
        /// </remarks>
        /// <param name="id">The ID of the space to be returned.</param>
        /// <param name="description_format">The content format type to be returned in the `description` field of the response. If available, the representation will be available under a response field of the same name under the `description` field.</param>
        /// <param name="include_icon">If the icon for the space should be fetched or not.</param>
        /// <param name="include_operations">
        /// Includes operations associated with this space in the response.
        /// The number of results will be limited to 50 and sorted in the default sort order.
        /// A `meta` and `_links` property will be present to indicate if more results are available and a link to retrieve the rest of the results.
        /// </param>
        /// <param name="include_properties">
        /// Includes space properties associated with this space in the response.
        /// The number of results will be limited to 50 and sorted in the default sort order.
        /// A `meta` and `_links` property will be present to indicate if more results are available and a link to retrieve the rest of the results.
        /// </param>
        /// <param name="include_permissions">
        /// Includes space permissions associated with this space in the response.
        /// The number of results will be limited to 50 and sorted in the default sort order.
        /// A `meta` and `_links` property will be present to indicate if more results are available and a link to retrieve the rest of the results.
        /// </param>
        /// <param name="include_labels">
        /// Includes labels associated with this space in the response.
        /// The number of results will be limited to 50 and sorted in the default sort order.
        /// A `meta` and `_links` property will be present to indicate if more results are available and a link to retrieve the rest of the results.
        /// </param>
        /// <returns>
        /// A <see cref="Task"/> representing the <see cref="IApiResponse"/> instance containing the result:
        /// <list type="table">
        /// <listheader>
        /// <term>Status</term>
        /// <description>Description</description>
        /// </listheader>
        /// <item>
        /// <term>200</term>
        /// <description>Returned if the requested space is returned.</description>
        /// </item>
        /// <item>
        /// <term>400</term>
        /// <description>Returned if an invalid request is provided.</description>
        /// </item>
        /// <item>
        /// <term>401</term>
        /// <description>Returned if the authentication credentials are incorrect or missing\nfrom the request.</description>
        /// </item>
        /// <item>
        /// <term>404</term>
        /// <description>Returned if the calling user does not have permission to view the\nrequested space or the space was not found.</description>
        /// </item>
        /// </list>
        /// </returns>
        [Headers("Accept: application/json")]
        [Get("/spaces/{id}")]
        Task<IApiResponse<Response53>> GetSpaceByIdAsync(long id, [Query, AliasAs("description-format")] SpaceDescriptionBodyRepresentation? description_format = default, [Query, AliasAs("include-icon")] bool? include_icon = default, [Query, AliasAs("include-operations")] bool? include_operations = default, [Query, AliasAs("include-properties")] bool? include_properties = default, [Query, AliasAs("include-permissions")] bool? include_permissions = default, [Query, AliasAs("include-labels")] bool? include_labels = default, CancellationToken cancellationToken = default);
    }

    /// <summary>Get space properties in space</summary>
    [System.CodeDom.Compiler.GeneratedCode("Refitter", "1.0.0.0")]
    public partial interface ISpacePropertiesApi
    {
        /// <summary>Get space properties in space</summary>
        /// <remarks>
        /// Returns all properties for the given space. Space properties are a key-value storage associated with a space.
        /// The limit parameter specifies the maximum number of results returned in a single response. Use the `link` response header
        /// to paginate through additional results.
        /// 
        /// **[Permissions](https://confluence.atlassian.com/x/_AozKw) required**:
        /// Permission to access the Confluence site ('Can use' global permission) and 'View' permission for the space.
        /// </remarks>
        /// <param name="space_id">The ID of the space for which space properties should be returned.</param>
        /// <param name="key">The key of the space property to retrieve. This should be used when a user knows the key of their property, but needs to retrieve the id for use in other methods.</param>
        /// <param name="cursor">Used for pagination, this opaque cursor will be returned in the `next` URL in the `Link` response header. Use the relative URL in the `Link` header to retrieve the `next` set of results.</param>
        /// <param name="limit">Maximum number of pages per result to return. If more results exist, use the `Link` header to retrieve a relative URL that will return the next set of results.</param>
        /// <returns>
        /// A <see cref="Task"/> representing the <see cref="IApiResponse"/> instance containing the result:
        /// <list type="table">
        /// <listheader>
        /// <term>Status</term>
        /// <description>Description</description>
        /// </listheader>
        /// <item>
        /// <term>200</term>
        /// <description>Returned if the requested space properties are returned. `results` may be empty if no results were found.</description>
        /// </item>
        /// <item>
        /// <term>400</term>
        /// <description>Returned if an invalid request is provided.</description>
        /// </item>
        /// <item>
        /// <term>401</term>
        /// <description>Returned if the authentication credentials are incorrect or missing\nfrom the request.</description>
        /// </item>
        /// <item>
        /// <term>404</term>
        /// <description>Returned if the calling user does not have permission to view the\nspecified space or the space was not found.</description>
        /// </item>
        /// </list>
        /// </returns>
        [Headers("Accept: application/json")]
        [Get("/spaces/{space-id}/properties")]
        Task<IApiResponse<Response59>> GetSpacePropertiesAsync([AliasAs("space-id")] long space_id, [Query] string? key = default, [Query] string? cursor = default, [Query] int? limit = default, CancellationToken cancellationToken = default);

        /// <summary>Create space property in space</summary>
        /// <remarks>
        /// Creates a new space property.
        /// 
        /// **[Permissions](https://confluence.atlassian.com/x/_AozKw) required**:
        /// Permission to access the Confluence site ('Can use' global permission) and 'Admin' permission for the space.
        /// </remarks>
        /// <param name="space_id">The ID of the space for which space properties should be returned.</param>
        /// <param name="body">The space property to be created</param>
        /// <returns>
        /// A <see cref="Task"/> representing the <see cref="IApiResponse"/> instance containing the result:
        /// <list type="table">
        /// <listheader>
        /// <term>Status</term>
        /// <description>Description</description>
        /// </listheader>
        /// <item>
        /// <term>201</term>
        /// <description>Returned if the space property was created successfully.</description>
        /// </item>
        /// <item>
        /// <term>400</term>
        /// <description>Returned if an invalid request is provided.</description>
        /// </item>
        /// <item>
        /// <term>401</term>
        /// <description>Returned if the authentication credentials are incorrect or missing\nfrom the request.</description>
        /// </item>
        /// <item>
        /// <term>404</term>
        /// <description>Returned if the calling user does not have permission to view the\nspecified space or the space was not found.</description>
        /// </item>
        /// </list>
        /// </returns>
        [Headers("Accept: application/json")]
        [Post("/spaces/{space-id}/properties")]
        Task<IApiResponse<SpaceProperty>> CreateSpacePropertyAsync([AliasAs("space-id")] long space_id, [Body] SpacePropertyCreateRequest body, CancellationToken cancellationToken = default);

        /// <summary>Get space property by id</summary>
        /// <remarks>
        /// Retrieve a space property by its id.
        /// 
        /// **[Permissions](https://confluence.atlassian.com/x/_AozKw) required**:
        /// Permission to access the Confluence site ('Can use' global permission) and 'View' permission for the space.
        /// </remarks>
        /// <param name="space_id">The ID of the space the property belongs to.</param>
        /// <param name="property_id">The ID of the property to be retrieved.</param>
        /// <returns>
        /// A <see cref="Task"/> representing the <see cref="IApiResponse"/> instance containing the result:
        /// <list type="table">
        /// <listheader>
        /// <term>Status</term>
        /// <description>Description</description>
        /// </listheader>
        /// <item>
        /// <term>200</term>
        /// <description>Returned if the space property was retrieved.</description>
        /// </item>
        /// <item>
        /// <term>400</term>
        /// <description>Returned if an invalid request is provided.</description>
        /// </item>
        /// <item>
        /// <term>401</term>
        /// <description>Returned if the authentication credentials are incorrect or missing\nfrom the request.</description>
        /// </item>
        /// <item>
        /// <term>404</term>
        /// <description>Returned if the calling user does not have permission to view the\nspecified space or the space was not found.</description>
        /// </item>
        /// </list>
        /// </returns>
        [Headers("Accept: application/json")]
        [Get("/spaces/{space-id}/properties/{property-id}")]
        Task<IApiResponse<SpaceProperty>> GetSpacePropertyByIdAsync([AliasAs("space-id")] long space_id, [AliasAs("property-id")] long property_id, CancellationToken cancellationToken = default);

        /// <summary>Update space property by id</summary>
        /// <remarks>
        /// Update a space property by its id.
        /// 
        /// **[Permissions](https://confluence.atlassian.com/x/_AozKw) required**:
        /// Permission to access the Confluence site ('Can use' global permission) and 'Admin' permission for the space.
        /// </remarks>
        /// <param name="space_id">The ID of the space the property belongs to.</param>
        /// <param name="property_id">The ID of the property to be updated.</param>
        /// <param name="body">The space property to be updated.</param>
        /// <returns>
        /// A <see cref="Task"/> representing the <see cref="IApiResponse"/> instance containing the result:
        /// <list type="table">
        /// <listheader>
        /// <term>Status</term>
        /// <description>Description</description>
        /// </listheader>
        /// <item>
        /// <term>200</term>
        /// <description>Returned if the space property was updated successfully.</description>
        /// </item>
        /// <item>
        /// <term>400</term>
        /// <description>Returned if an invalid request is provided.</description>
        /// </item>
        /// <item>
        /// <term>401</term>
        /// <description>Returned if the authentication credentials are incorrect or missing\nfrom the request.</description>
        /// </item>
        /// <item>
        /// <term>404</term>
        /// <description>Returned if the calling user does not have permission to view the\nspecified space or the space was not found.</description>
        /// </item>
        /// </list>
        /// </returns>
        [Headers("Accept: application/json")]
        [Put("/spaces/{space-id}/properties/{property-id}")]
        Task<IApiResponse<SpaceProperty>> UpdateSpacePropertyByIdAsync([AliasAs("space-id")] long space_id, [AliasAs("property-id")] long property_id, [Body] SpacePropertyUpdateRequest body, CancellationToken cancellationToken = default);

        /// <summary>Delete space property by id</summary>
        /// <remarks>
        /// Deletes a space property by its id.
        /// 
        /// **[Permissions](https://confluence.atlassian.com/x/_AozKw) required**:
        /// Permission to access the Confluence site ('Can use' global permission) and 'Admin' permission for the space.
        /// </remarks>
        /// <param name="space_id">The ID of the space the property belongs to.</param>
        /// <param name="property_id">The ID of the property to be deleted.</param>
        /// <returns>
        /// A <see cref="Task"/> representing the <see cref="IApiResponse"/> instance containing the result:
        /// <list type="table">
        /// <listheader>
        /// <term>Status</term>
        /// <description>Description</description>
        /// </listheader>
        /// <item>
        /// <term>204</term>
        /// <description>Returned if the space property was deleted successfully.</description>
        /// </item>
        /// <item>
        /// <term>400</term>
        /// <description>Returned if an invalid request is provided.</description>
        /// </item>
        /// <item>
        /// <term>401</term>
        /// <description>Returned if the authentication credentials are incorrect or missing\nfrom the request.</description>
        /// </item>
        /// <item>
        /// <term>404</term>
        /// <description>Returned if the calling user does not have permission to view the\nspecified space or the space was not found.</description>
        /// </item>
        /// </list>
        /// </returns>
        [Delete("/spaces/{space-id}/properties/{property-id}")]
        Task<IApiResponse> DeleteSpacePropertyByIdAsync([AliasAs("space-id")] long space_id, [AliasAs("property-id")] long property_id, CancellationToken cancellationToken = default);
    }

    /// <summary>Get space permissions</summary>
    [System.CodeDom.Compiler.GeneratedCode("Refitter", "1.0.0.0")]
    public partial interface ISpacePermissionsApi
    {
        /// <summary>Get space permissions</summary>
        /// <remarks>
        /// Returns space permissions for a specific space.
        /// 
        /// **[Permissions](https://confluence.atlassian.com/x/_AozKw) required**:
        /// Permission to view the space.
        /// </remarks>
        /// <param name="id">The ID of the space to be returned.</param>
        /// <param name="cursor">Used for pagination, this opaque cursor will be returned in the `next` URL in the `Link` response header. Use the relative URL in the `Link` header to retrieve the `next` set of results.</param>
        /// <param name="limit">Maximum number of spaces per result to return. If more results exist, use the `Link` response header to retrieve a relative URL that will return the next set of results.</param>
        /// <returns>
        /// A <see cref="Task"/> representing the <see cref="IApiResponse"/> instance containing the result:
        /// <list type="table">
        /// <listheader>
        /// <term>Status</term>
        /// <description>Description</description>
        /// </listheader>
        /// <item>
        /// <term>200</term>
        /// <description>Returned if the requested space permissions are returned.</description>
        /// </item>
        /// <item>
        /// <term>400</term>
        /// <description>Returned if an invalid request is provided.</description>
        /// </item>
        /// <item>
        /// <term>401</term>
        /// <description>Returned if the authentication credentials are incorrect or missing\nfrom the request.</description>
        /// </item>
        /// <item>
        /// <term>404</term>
        /// <description>Returned if the calling user does not have permission to view the\nrequested space permissions or the space was not found.</description>
        /// </item>
        /// </list>
        /// </returns>
        [Headers("Accept: application/json")]
        [Get("/spaces/{id}/permissions")]
        Task<IApiResponse<Response60>> GetSpacePermissionsAsync(long id, [Query] string? cursor = default, [Query] int? limit = default, CancellationToken cancellationToken = default);
    }

    /// <summary>Get tasks</summary>
    [System.CodeDom.Compiler.GeneratedCode("Refitter", "1.0.0.0")]
    public partial interface ITaskApi
    {
        /// <summary>Get tasks</summary>
        /// <remarks>
        /// Returns all tasks. The number of results is limited by the `limit` parameter and additional results (if available)
        /// will be available through the `next` URL present in the `Link` response header.
        /// 
        /// **[Permissions](https://confluence.atlassian.com/x/_AozKw) required**:
        /// Permission to access the Confluence site ('Can use' global permission).
        /// Only tasks that the user has permission to view will be returned.
        /// </remarks>
        /// <param name="body_format">The content format types to be returned in the `body` field of the response. If available, the representation will be available under a response field of the same name under the `body` field.</param>
        /// <param name="include_blank_tasks">Specifies whether to include blank tasks in the response. Defaults to `true`.</param>
        /// <param name="status">Filters on the status of the task.</param>
        /// <param name="task_id">Filters on task ID. Multiple IDs can be specified.</param>
        /// <param name="space_id">Filters on the space ID of the task. Multiple IDs can be specified.</param>
        /// <param name="page_id">Filters on the page ID of the task. Multiple IDs can be specified. Note - page and blog post filters can be used in conjunction.</param>
        /// <param name="blogpost_id">Filters on the blog post ID of the task. Multiple IDs can be specified. Note - page and blog post filters can be used in conjunction.</param>
        /// <param name="created_by">Filters on the Account ID of the user who created this task. Multiple IDs can be specified.</param>
        /// <param name="assigned_to">Filters on the Account ID of the user to whom this task is assigned. Multiple IDs can be specified.</param>
        /// <param name="completed_by">Filters on the Account ID of the user who completed this task. Multiple IDs can be specified.</param>
        /// <param name="created_at_from">Filters on start of date-time range of task based on creation date (inclusive). Input is epoch time in milliseconds.</param>
        /// <param name="created_at_to">Filters on end of date-time range of task based on creation date (inclusive). Input is epoch time in milliseconds.</param>
        /// <param name="due_at_from">Filters on start of date-time range of task based on due date (inclusive). Input is epoch time in milliseconds.</param>
        /// <param name="due_at_to">Filters on end of date-time range of task based on due date (inclusive). Input is epoch time in milliseconds.</param>
        /// <param name="completed_at_from">Filters on start of date-time range of task based on completion date (inclusive). Input is epoch time in milliseconds.</param>
        /// <param name="completed_at_to">Filters on end of date-time range of task based on completion date (inclusive). Input is epoch time in milliseconds.</param>
        /// <param name="cursor">Used for pagination, this opaque cursor will be returned in the `next` URL in the `Link` response header. Use the relative URL in the `Link` header to retrieve the `next` set of results.</param>
        /// <param name="limit">Maximum number of tasks per result to return. If more results exist, use the `Link` header to retrieve a relative URL that will return the next set of results.</param>
        /// <returns>
        /// A <see cref="Task"/> representing the <see cref="IApiResponse"/> instance containing the result:
        /// <list type="table">
        /// <listheader>
        /// <term>Status</term>
        /// <description>Description</description>
        /// </listheader>
        /// <item>
        /// <term>200</term>
        /// <description>Returned if the requested tasks are returned.</description>
        /// </item>
        /// <item>
        /// <term>400</term>
        /// <description>Returned if an invalid request is provided.</description>
        /// </item>
        /// <item>
        /// <term>401</term>
        /// <description>Returned if the authentication credentials are incorrect or missing\nfrom the request.</description>
        /// </item>
        /// </list>
        /// </returns>
        [Headers("Accept: application/json")]
        [Get("/tasks")]
        Task<IApiResponse<Response79>> GetTasksAsync([Query, AliasAs("body-format")] PrimaryBodyRepresentation? body_format = default, [Query, AliasAs("include-blank-tasks")] bool? include_blank_tasks = default, [Query] Status2? status = default, [Query(CollectionFormat.Multi), AliasAs("task-id")] IEnumerable<long>? task_id = default, [Query(CollectionFormat.Multi), AliasAs("space-id")] IEnumerable<long>? space_id = default, [Query(CollectionFormat.Multi), AliasAs("page-id")] IEnumerable<long>? page_id = default, [Query(CollectionFormat.Multi), AliasAs("blogpost-id")] IEnumerable<long>? blogpost_id = default, [Query(CollectionFormat.Multi), AliasAs("created-by")] IEnumerable<string>? created_by = default, [Query(CollectionFormat.Multi), AliasAs("assigned-to")] IEnumerable<string>? assigned_to = default, [Query(CollectionFormat.Multi), AliasAs("completed-by")] IEnumerable<string>? completed_by = default, [Query, AliasAs("created-at-from")] long? created_at_from = default, [Query, AliasAs("created-at-to")] long? created_at_to = default, [Query, AliasAs("due-at-from")] long? due_at_from = default, [Query, AliasAs("due-at-to")] long? due_at_to = default, [Query, AliasAs("completed-at-from")] long? completed_at_from = default, [Query, AliasAs("completed-at-to")] long? completed_at_to = default, [Query] string? cursor = default, [Query] int? limit = default, CancellationToken cancellationToken = default);

        /// <summary>Get task by id</summary>
        /// <remarks>
        /// Returns a specific task.
        /// 
        /// **[Permissions](https://confluence.atlassian.com/x/_AozKw) required**:
        /// Permission to view the containing page or blog post and its corresponding space.
        /// </remarks>
        /// <param name="id">The ID of the task to be returned. If you don't know the task ID, use Get tasks and filter the results.</param>
        /// <param name="body_format">The content format types to be returned in the `body` field of the response. If available, the representation will be available under a response field of the same name under the `body` field.</param>
        /// <returns>
        /// A <see cref="Task"/> representing the <see cref="IApiResponse"/> instance containing the result:
        /// <list type="table">
        /// <listheader>
        /// <term>Status</term>
        /// <description>Description</description>
        /// </listheader>
        /// <item>
        /// <term>200</term>
        /// <description>Returned if the requested task is returned.</description>
        /// </item>
        /// <item>
        /// <term>400</term>
        /// <description>Returned if an invalid request is provided.</description>
        /// </item>
        /// <item>
        /// <term>401</term>
        /// <description>Returned if the authentication credentials are incorrect or missing\nfrom the request.</description>
        /// </item>
        /// <item>
        /// <term>404</term>
        /// <description>Returned if the calling user does not have permission to view the\nrequested task or the task was not found.</description>
        /// </item>
        /// </list>
        /// </returns>
        [Headers("Accept: application/json")]
        [Get("/tasks/{id}")]
        Task<IApiResponse<Task>> GetTaskByIdAsync(long id, [Query, AliasAs("body-format")] PrimaryBodyRepresentation? body_format = default, CancellationToken cancellationToken = default);

        /// <summary>Update task</summary>
        /// <remarks>
        /// Update a task by id.
        /// 
        /// **[Permissions](https://confluence.atlassian.com/x/_AozKw) required**:
        /// Permission to edit the containing page or blog post and view its corresponding space.
        /// </remarks>
        /// <param name="id">The ID of the task to be updated. If you don't know the task ID, use Get tasks and filter the results.</param>
        /// <param name="body_format">The content format types to be returned in the `body` field of the response. If available, the representation will be available under a response field of the same name under the `body` field.</param>
        /// <returns>
        /// A <see cref="Task"/> representing the <see cref="IApiResponse"/> instance containing the result:
        /// <list type="table">
        /// <listheader>
        /// <term>Status</term>
        /// <description>Description</description>
        /// </listheader>
        /// <item>
        /// <term>200</term>
        /// <description>Returned if the requested task is updated.</description>
        /// </item>
        /// <item>
        /// <term>400</term>
        /// <description>Returned if an invalid request is provided.</description>
        /// </item>
        /// <item>
        /// <term>401</term>
        /// <description>Returned if the authentication credentials are incorrect or missing from the request.</description>
        /// </item>
        /// <item>
        /// <term>404</term>
        /// <description>Returned if:\n- The provided task does not exist\n- The user does not have permissions to view the task\n- The user does not have the needed permissions to update the containing page or blog post in the corresponding space</description>
        /// </item>
        /// </list>
        /// </returns>
        [Headers("Accept: application/json")]
        [Put("/tasks/{id}")]
        Task<IApiResponse<Task>> UpdateTaskAsync(long id, [Query, AliasAs("body-format")] PrimaryBodyRepresentation? body_format = default, [Body] object? body = default, CancellationToken cancellationToken = default);
    }

    /// <summary>Get child pages</summary>
    [System.CodeDom.Compiler.GeneratedCode("Refitter", "1.0.0.0")]
    public partial interface IChildrenApi
    {
        /// <summary>Get child pages</summary>
        /// <remarks>
        /// Returns all child pages for given page id. The number of results is limited by the `limit` parameter and additional results (if available)
        /// will be available through the `next` URL present in the `Link` response header.
        /// 
        /// **[Permissions](https://confluence.atlassian.com/x/_AozKw) required**:
        /// Permission to access the Confluence site ('Can use' global permission).
        /// Only pages that the user has permission to view will be returned.
        /// </remarks>
        /// <param name="id">The ID of the parent page. If you don't know the page ID, use Get pages and filter the results.</param>
        /// <param name="cursor">Used for pagination, this opaque cursor will be returned in the `next` URL in the `Link` response header. Use the relative URL in the `Link` header to retrieve the `next` set of results.</param>
        /// <param name="limit">Maximum number of pages per result to return. If more results exist, use the `Link` header to retrieve a relative URL that will return the next set of results.</param>
        /// <param name="sort">Used to sort the result by a particular field.</param>
        /// <returns>
        /// A <see cref="Task"/> representing the <see cref="IApiResponse"/> instance containing the result:
        /// <list type="table">
        /// <listheader>
        /// <term>Status</term>
        /// <description>Description</description>
        /// </listheader>
        /// <item>
        /// <term>200</term>
        /// <description>Returned if the requested child pages are returned.</description>
        /// </item>
        /// <item>
        /// <term>400</term>
        /// <description>Returned if an invalid request is provided.</description>
        /// </item>
        /// <item>
        /// <term>401</term>
        /// <description>Returned if the authentication credentials are incorrect or missing\nfrom the request.</description>
        /// </item>
        /// </list>
        /// </returns>
        [Headers("Accept: application/json")]
        [Get("/pages/{id}/children")]
        Task<IApiResponse<Response80>> GetChildPagesAsync(long id, [Query] string? cursor = default, [Query] int? limit = default, [Query] string? sort = default, CancellationToken cancellationToken = default);

        /// <summary>Get child custom content</summary>
        /// <remarks>
        /// Returns all child custom content for given custom content id. The number of results is limited by the `limit` parameter and additional results (if available)
        /// will be available through the `next` URL present in the `Link` response header.
        /// 
        /// **[Permissions](https://confluence.atlassian.com/x/_AozKw) required**:
        /// Permission to access the Confluence site ('Can use' global permission).
        /// Only custom content that the user has permission to view will be returned.
        /// </remarks>
        /// <param name="id">The ID of the parent custom content. If you don't know the custom content ID, use Get custom-content and filter the results.</param>
        /// <param name="cursor">Used for pagination, this opaque cursor will be returned in the `next` URL in the `Link` response header. Use the relative URL in the `Link` header to retrieve the `next` set of results.</param>
        /// <param name="limit">Maximum number of pages per result to return. If more results exist, use the `Link` header to retrieve a relative URL that will return the next set of results.</param>
        /// <param name="sort">Used to sort the result by a particular field.</param>
        /// <returns>
        /// A <see cref="Task"/> representing the <see cref="IApiResponse"/> instance containing the result:
        /// <list type="table">
        /// <listheader>
        /// <term>Status</term>
        /// <description>Description</description>
        /// </listheader>
        /// <item>
        /// <term>200</term>
        /// <description>Returned if the requested child custom content are returned.</description>
        /// </item>
        /// <item>
        /// <term>400</term>
        /// <description>Returned if an invalid request is provided.</description>
        /// </item>
        /// <item>
        /// <term>401</term>
        /// <description>Returned if the authentication credentials are incorrect or missing\nfrom the request.</description>
        /// </item>
        /// </list>
        /// </returns>
        [Headers("Accept: application/json")]
        [Get("/custom-content/{id}/children")]
        Task<IApiResponse<Response81>> GetChildCustomContentAsync(long id, [Query] string? cursor = default, [Query] int? limit = default, [Query] string? sort = default, CancellationToken cancellationToken = default);
    }

    /// <summary>Check site access for a list of emails</summary>
    [System.CodeDom.Compiler.GeneratedCode("Refitter", "1.0.0.0")]
    public partial interface IUserApi
    {
        /// <summary>Check site access for a list of emails</summary>
        /// <remarks>
        /// Returns the list of emails from the input list that do not have access to site.
        /// 
        /// **[Permissions](https://confluence.atlassian.com/x/_AozKw) required**:
        /// Permission to access the Confluence site ('Can use' global permission).
        /// </remarks>
        /// <returns>
        /// A <see cref="Task"/> representing the <see cref="IApiResponse"/> instance containing the result:
        /// <list type="table">
        /// <listheader>
        /// <term>Status</term>
        /// <description>Description</description>
        /// </listheader>
        /// <item>
        /// <term>200</term>
        /// <description>Returns object with list of emails without access to site.</description>
        /// </item>
        /// <item>
        /// <term>400</term>
        /// <description>Returned if an invalid request is provided.</description>
        /// </item>
        /// <item>
        /// <term>401</term>
        /// <description>Returned if the authentication credentials are incorrect or missing\nfrom the request.</description>
        /// </item>
        /// <item>
        /// <term>404</term>
        /// <description>Returned if the calling user does not have permission to check access for emails on site.</description>
        /// </item>
        /// <item>
        /// <term>503</term>
        /// <description>Returned if API is disabled on site</description>
        /// </item>
        /// </list>
        /// </returns>
        [Headers("Accept: application/json")]
        [Post("/user/access/check-access-by-email")]
        Task<IApiResponse<Response83>> CheckAccessByEmailAsync([Body] object? body = default, CancellationToken cancellationToken = default);

        /// <summary>Invite a list of emails to the site</summary>
        /// <remarks>
        /// Invite a list of emails to the site.
        /// 
        /// Ignores all invalid emails and no action is taken for the emails that already have access to the site.
        /// 
        /// <b>NOTE:</b> This API is asynchronous and may take some time to complete.
        /// 
        /// **[Permissions](https://confluence.atlassian.com/x/_AozKw) required**:
        /// Permission to access the Confluence site ('Can use' global permission).
        /// </remarks>
        /// <returns>
        /// A <see cref="Task"/> representing the <see cref="IApiResponse"/> instance containing the result:
        /// <list type="table">
        /// <listheader>
        /// <term>Status</term>
        /// <description>Description</description>
        /// </listheader>
        /// <item>
        /// <term>200</term>
        /// <description>Returns object with list of emails without access to site.</description>
        /// </item>
        /// <item>
        /// <term>400</term>
        /// <description>Returned if an invalid request is provided.</description>
        /// </item>
        /// <item>
        /// <term>401</term>
        /// <description>Returned if the authentication credentials are incorrect or missing\nfrom the request.</description>
        /// </item>
        /// <item>
        /// <term>404</term>
        /// <description>Returned if the calling user does not have permission to check access for emails on site.</description>
        /// </item>
        /// <item>
        /// <term>503</term>
        /// <description>Returned if API is disabled on site</description>
        /// </item>
        /// </list>
        /// </returns>
        [Post("/user/access/invite-by-email")]
        Task<IApiResponse> InviteByEmailAsync([Body] object? body = default, CancellationToken cancellationToken = default);
    }

    /// <summary>Get data policy metadata for the workspace</summary>
    [System.CodeDom.Compiler.GeneratedCode("Refitter", "1.0.0.0")]
    public partial interface IDataPoliciesApi
    {
        /// <summary>Get data policy metadata for the workspace</summary>
        /// <remarks>
        /// Returns data policy metadata for the workspace.
        /// 
        /// **[Permissions](#permissions) required:**
        /// Only apps can make this request.
        /// Permission to access the Confluence site ('Can use' global permission).
        /// </remarks>
        /// <returns>
        /// A <see cref="Task"/> representing the <see cref="IApiResponse"/> instance containing the result:
        /// <list type="table">
        /// <listheader>
        /// <term>Status</term>
        /// <description>Description</description>
        /// </listheader>
        /// <item>
        /// <term>200</term>
        /// <description>Returned if the request is successful.</description>
        /// </item>
        /// <item>
        /// <term>400</term>
        /// <description>Returned if the request is not valid.</description>
        /// </item>
        /// <item>
        /// <term>401</term>
        /// <description>Returned if the authentication credentials are incorrect or missing.</description>
        /// </item>
        /// </list>
        /// </returns>
        [Headers("Accept: application/json")]
        [Get("/data-policies/metadata")]
        Task<IApiResponse<DataPolicyMetadata>> GetDataPolicyMetadataAsync(CancellationToken cancellationToken = default);

        /// <summary>Get spaces with data policies</summary>
        /// <remarks>
        /// Returns all spaces. The results will be sorted by id ascending. The number of results is limited by the `limit` parameter and
        /// additional results (if available) will be available through the `next` URL present in the `Link` response header.
        /// 
        /// **[Permissions](https://confluence.atlassian.com/x/_AozKw) required**:
        /// Only apps can make this request.
        /// Permission to access the Confluence site ('Can use' global permission).
        /// Only spaces that the app has permission to view will be returned.
        /// </remarks>
        /// <param name="ids">Filter the results to spaces based on their IDs. Multiple IDs can be specified as a comma-separated list.</param>
        /// <param name="keys">Filter the results to spaces based on their keys. Multiple keys can be specified as a comma-separated list.</param>
        /// <param name="sort">Used to sort the result by a particular field.</param>
        /// <param name="cursor">Used for pagination, this opaque cursor will be returned in the `next` URL in the `Link` response header. Use the relative URL in the `Link` header to retrieve the `next` set of results.</param>
        /// <param name="limit">Maximum number of spaces per result to return. If more results exist, use the `Link` response header to retrieve a relative URL that will return the next set of results.</param>
        /// <returns>
        /// A <see cref="Task"/> representing the <see cref="IApiResponse"/> instance containing the result:
        /// <list type="table">
        /// <listheader>
        /// <term>Status</term>
        /// <description>Description</description>
        /// </listheader>
        /// <item>
        /// <term>200</term>
        /// <description>Returned if the requested spaces are returned.</description>
        /// </item>
        /// <item>
        /// <term>400</term>
        /// <description>Returned if an invalid request is provided.</description>
        /// </item>
        /// <item>
        /// <term>401</term>
        /// <description>Returned if the authentication credentials are incorrect or missing\nfrom the request.</description>
        /// </item>
        /// </list>
        /// </returns>
        [Headers("Accept: application/json")]
        [Get("/data-policies/spaces")]
        Task<IApiResponse<Response84>> GetDataPolicySpacesAsync([Query(CollectionFormat.Multi)] IEnumerable<long>? ids = default, [Query(CollectionFormat.Multi)] IEnumerable<string>? keys = default, [Query] SpaceSortOrder? sort = default, [Query] string? cursor = default, [Query] int? limit = default, CancellationToken cancellationToken = default);
    }

    /// <summary>Get list of classification levels</summary>
    [System.CodeDom.Compiler.GeneratedCode("Refitter", "1.0.0.0")]
    public partial interface IClassificationLevelApi
    {
        /// <summary>Get list of classification levels</summary>
        /// <remarks>
        /// Returns a list of [classification levels](https://developer.atlassian.com/cloud/admin/dlp/rest/intro/#Classification%20level)
        /// available.
        /// 
        /// **[Permissions](https://confluence.atlassian.com/x/_AozKw) required**:
        /// 'Permission to access the Confluence site ('Can use' global permission).
        /// </remarks>
        /// <returns>
        /// A <see cref="Task"/> representing the <see cref="IApiResponse"/> instance containing the result:
        /// <list type="table">
        /// <listheader>
        /// <term>Status</term>
        /// <description>Description</description>
        /// </listheader>
        /// <item>
        /// <term>200</term>
        /// <description>Returned if classifications levels are returned.</description>
        /// </item>
        /// <item>
        /// <term>400</term>
        /// <description>Returned if an invalid request is provided.</description>
        /// </item>
        /// <item>
        /// <term>401</term>
        /// <description>Returned if the authentication credentials are incorrect or missing\nfrom the request.</description>
        /// </item>
        /// <item>
        /// <term>404</term>
        /// <description>Returned if:\n- Classification levels do not exist\n- Site\'s edition does not have entitlement(s) for [data classification](https://support.atlassian.com/security-and-access-policies/docs/what-is-data-classification/)\n- The calling user does not have permissions to access the Confluence site\n</description>
        /// </item>
        /// </list>
        /// </returns>
        [Headers("Accept: application/json")]
        [Get("/classification-levels")]
        Task<IApiResponse<ICollection<ClassificationLevel>>> GetClassificationLevelsAsync(CancellationToken cancellationToken = default);

        /// <summary>Get space default classification level</summary>
        /// <remarks>
        /// Returns the [default classification level](https://support.atlassian.com/security-and-access-policies/docs/what-is-a-default-classification-level/)
        /// for a specific space.
        /// 
        /// **[Permissions](https://confluence.atlassian.com/x/_AozKw) required**:
        /// 'Permission to access the Confluence site ('Can use' global permission) and permission to view the space.
        /// </remarks>
        /// <param name="id">The ID of the space for which default classification level should be returned.</param>
        /// <returns>
        /// A <see cref="Task"/> representing the <see cref="IApiResponse"/> instance containing the result:
        /// <list type="table">
        /// <listheader>
        /// <term>Status</term>
        /// <description>Description</description>
        /// </listheader>
        /// <item>
        /// <term>200</term>
        /// <description>Returned if the requested default classification level for a space is returned.</description>
        /// </item>
        /// <item>
        /// <term>400</term>
        /// <description>Returned if an invalid request is provided.</description>
        /// </item>
        /// <item>
        /// <term>401</term>
        /// <description>Returned if the authentication credentials are incorrect or missing\nfrom the request.</description>
        /// </item>
        /// <item>
        /// <term>404</term>
        /// <description>Returned if:\n- Default classification level is not applied to the space\n- Site\'s edition does not have entitlement(s) for [data classification](https://support.atlassian.com/security-and-access-policies/docs/what-is-data-classification/)\n- The calling user does not have permission to view the specified space or the space was not found</description>
        /// </item>
        /// </list>
        /// </returns>
        [Headers("Accept: application/json")]
        [Get("/spaces/{id}/classification-level/default")]
        Task<IApiResponse<ClassificationLevel>> GetSpaceDefaultClassificationLevelAsync(long id, CancellationToken cancellationToken = default);

        /// <summary>Update space default classification level</summary>
        /// <remarks>
        /// Update the [default classification level](https://support.atlassian.com/security-and-access-policies/docs/what-is-a-default-classification-level/)
        /// for a specific space.
        /// 
        /// **[Permissions](https://confluence.atlassian.com/x/_AozKw) required**:
        /// 'Permission to access the Confluence site ('Can use' global permission) and 'Admin' permission for the space.
        /// </remarks>
        /// <param name="id">The ID of the space for which default classification level should be updated.</param>
        /// <returns>
        /// A <see cref="Task"/> representing the <see cref="IApiResponse"/> instance containing the result:
        /// <list type="table">
        /// <listheader>
        /// <term>Status</term>
        /// <description>Description</description>
        /// </listheader>
        /// <item>
        /// <term>204</term>
        /// <description>Returned if the default classification level was successfully updated.</description>
        /// </item>
        /// <item>
        /// <term>400</term>
        /// <description>Returned if an invalid request is provided.</description>
        /// </item>
        /// <item>
        /// <term>401</term>
        /// <description>Returned if the authentication credentials are incorrect or missing\nfrom the request.</description>
        /// </item>
        /// <item>
        /// <term>404</term>
        /// <description>Returned if:\n- Site\'s edition does not have entitlement(s) for [data classification](https://support.atlassian.com/security-and-access-policies/docs/what-is-data-classification/)\n- The calling user does not have permission to view the specified space or the space was not found</description>
        /// </item>
        /// </list>
        /// </returns>
        [Put("/spaces/{id}/classification-level/default")]
        Task<IApiResponse> PutSpaceDefaultClassificationLevelAsync(long id, [Body] object? body = default, CancellationToken cancellationToken = default);

        /// <summary>Delete space default classification level</summary>
        /// <remarks>
        /// Returns the [default classification level](https://support.atlassian.com/security-and-access-policies/docs/what-is-a-default-classification-level/)
        /// for a specific space.
        /// 
        /// **[Permissions](https://confluence.atlassian.com/x/_AozKw) required**:
        /// 'Permission to access the Confluence site ('Can use' global permission) and 'Admin' permission for the space.
        /// </remarks>
        /// <param name="id">The ID of the space for which default classification level should be deleted.</param>
        /// <returns>
        /// A <see cref="Task"/> representing the <see cref="IApiResponse"/> instance containing the result:
        /// <list type="table">
        /// <listheader>
        /// <term>Status</term>
        /// <description>Description</description>
        /// </listheader>
        /// <item>
        /// <term>204</term>
        /// <description>Returned if the default classification level was successfully deleted.</description>
        /// </item>
        /// <item>
        /// <term>400</term>
        /// <description>Returned if an invalid request is provided.</description>
        /// </item>
        /// <item>
        /// <term>401</term>
        /// <description>Returned if the authentication credentials are incorrect or missing\nfrom the request.</description>
        /// </item>
        /// <item>
        /// <term>404</term>
        /// <description>Returned if:\n- Site\'s edition does not have entitlement(s) for [data classification](https://support.atlassian.com/security-and-access-policies/docs/what-is-data-classification/)\n- The calling user does not have permission to view the specified space or the space was not found</description>
        /// </item>
        /// </list>
        /// </returns>
        [Delete("/spaces/{id}/classification-level/default")]
        Task<IApiResponse> DeleteSpaceDefaultClassificationLevelAsync(long id, CancellationToken cancellationToken = default);

        /// <summary>Get page classification level</summary>
        /// <remarks>
        /// Returns the [classification level](https://developer.atlassian.com/cloud/admin/dlp/rest/intro/#Classification%20level)
        /// for a specific page.
        /// 
        /// **[Permissions](https://confluence.atlassian.com/x/_AozKw) required**:
        /// 'Permission to access the Confluence site ('Can use' global permission) and permission to view the page.
        /// 'Permission to edit the page is required if trying to view classification level for a draft.
        /// </remarks>
        /// <param name="id">The ID of the page for which classification level should be returned.</param>
        /// <param name="status">Status of page from which classification level will fetched.</param>
        /// <returns>
        /// A <see cref="Task"/> representing the <see cref="IApiResponse"/> instance containing the result:
        /// <list type="table">
        /// <listheader>
        /// <term>Status</term>
        /// <description>Description</description>
        /// </listheader>
        /// <item>
        /// <term>200</term>
        /// <description>Returned if the requested classification level for a page is returned.</description>
        /// </item>
        /// <item>
        /// <term>400</term>
        /// <description>Returned if an invalid request is provided.</description>
        /// </item>
        /// <item>
        /// <term>401</term>
        /// <description>Returned if the authentication credentials are incorrect or missing\nfrom the request.</description>
        /// </item>
        /// <item>
        /// <term>404</term>
        /// <description>Returned if:\n- Page does not have a classification level applied\n- Site\'s edition does not have entitlement(s) for [data classification](https://support.atlassian.com/security-and-access-policies/docs/what-is-data-classification/)\n- The calling user does not have permission to view the specified page or the page was not found\n- The calling user does not have permission to edit the specified page when trying to fetch classification level for a draft</description>
        /// </item>
        /// </list>
        /// </returns>
        [Headers("Accept: application/json")]
        [Get("/pages/{id}/classification-level")]
        Task<IApiResponse<ClassificationLevel>> GetPageClassificationLevelAsync(long id, [Query] Status3? status = default, CancellationToken cancellationToken = default);

        /// <summary>Update page classification level</summary>
        /// <remarks>
        /// Updates the [classification level](https://developer.atlassian.com/cloud/admin/dlp/rest/intro/#Classification%20level)
        /// for a specific page.
        /// 
        /// **[Permissions](https://confluence.atlassian.com/x/_AozKw) required**:
        /// 'Permission to access the Confluence site ('Can use' global permission) and permission to edit the page.
        /// </remarks>
        /// <param name="id">The ID of the page for which classification level should be updated.</param>
        /// <returns>
        /// A <see cref="Task"/> representing the <see cref="IApiResponse"/> instance containing the result:
        /// <list type="table">
        /// <listheader>
        /// <term>Status</term>
        /// <description>Description</description>
        /// </listheader>
        /// <item>
        /// <term>204</term>
        /// <description>Returned if the classification level was successfully updated.</description>
        /// </item>
        /// <item>
        /// <term>400</term>
        /// <description>Returned if an invalid request is provided.</description>
        /// </item>
        /// <item>
        /// <term>401</term>
        /// <description>Returned if the authentication credentials are incorrect or missing\nfrom the request.</description>
        /// </item>
        /// <item>
        /// <term>404</term>
        /// <description>Returned if:\n- Site\'s edition does not have entitlement(s) for [data classification](https://support.atlassian.com/security-and-access-policies/docs/what-is-data-classification/)\n- The calling user does not have permission to edit the specified page or the page was not found</description>
        /// </item>
        /// </list>
        /// </returns>
        [Put("/pages/{id}/classification-level")]
        Task<IApiResponse> PutPageClassificationLevelAsync(long id, [Body] object? body = default, CancellationToken cancellationToken = default);

        /// <summary>Reset page classification level</summary>
        /// <remarks>
        /// Resets the [classification level](https://developer.atlassian.com/cloud/admin/dlp/rest/intro/#Classification%20level)
        /// for a specific page to the space
        /// [default classification level](https://support.atlassian.com/security-and-access-policies/docs/what-is-a-default-classification-level/).
        /// 
        /// **[Permissions](https://confluence.atlassian.com/x/_AozKw) required**:
        /// 'Permission to access the Confluence site ('Can use' global permission) and permission to view the page.
        /// </remarks>
        /// <param name="id">The ID of the page for which classification level should be updated.</param>
        /// <returns>
        /// A <see cref="Task"/> representing the <see cref="IApiResponse"/> instance containing the result:
        /// <list type="table">
        /// <listheader>
        /// <term>Status</term>
        /// <description>Description</description>
        /// </listheader>
        /// <item>
        /// <term>204</term>
        /// <description>Returned if the classification level was successfully reset.</description>
        /// </item>
        /// <item>
        /// <term>400</term>
        /// <description>Returned if an invalid request is provided.</description>
        /// </item>
        /// <item>
        /// <term>401</term>
        /// <description>Returned if the authentication credentials are incorrect or missing\nfrom the request.</description>
        /// </item>
        /// <item>
        /// <term>404</term>
        /// <description>Returned if:\n- Site\'s edition does not have entitlement(s) for [data classification](https://support.atlassian.com/security-and-access-policies/docs/what-is-data-classification/)\n- The calling user does not have permission to edit the specified page or the page was not found</description>
        /// </item>
        /// </list>
        /// </returns>
        [Post("/pages/{id}/classification-level/reset")]
        Task<IApiResponse> PostPageClassificationLevelAsync(long id, [Body] object? body = default, CancellationToken cancellationToken = default);

        /// <summary>Get blog post classification level</summary>
        /// <remarks>
        /// Returns the [classification level](https://developer.atlassian.com/cloud/admin/dlp/rest/intro/#Classification%20level)
        /// for a specific blog post.
        /// 
        /// **[Permissions](https://confluence.atlassian.com/x/_AozKw) required**:
        /// 'Permission to access the Confluence site ('Can use' global permission) and permission to view the blog post.
        /// 'Permission to edit the blog post is required if trying to view classification level for a draft.
        /// </remarks>
        /// <param name="id">The ID of the blog post for which classification level should be returned.</param>
        /// <param name="status">Status of blog post from which classification level will fetched.</param>
        /// <returns>
        /// A <see cref="Task"/> representing the <see cref="IApiResponse"/> instance containing the result:
        /// <list type="table">
        /// <listheader>
        /// <term>Status</term>
        /// <description>Description</description>
        /// </listheader>
        /// <item>
        /// <term>200</term>
        /// <description>Returned if the requested classification level for a blog post is returned.</description>
        /// </item>
        /// <item>
        /// <term>400</term>
        /// <description>Returned if an invalid request is provided.</description>
        /// </item>
        /// <item>
        /// <term>401</term>
        /// <description>Returned if the authentication credentials are incorrect or missing\nfrom the request.</description>
        /// </item>
        /// <item>
        /// <term>404</term>
        /// <description>Returned if:\n- Blog post does not have a classification level applied\n- Site\'s edition does not have entitlement(s) for [data classification](https://support.atlassian.com/security-and-access-policies/docs/what-is-data-classification/)\n- The calling user does not have permission to view the specified blog post or the blog post was not found\n- The calling user does not have permission to edit the specified blog post when trying to fetch classification level for a draft</description>
        /// </item>
        /// </list>
        /// </returns>
        [Headers("Accept: application/json")]
        [Get("/blogposts/{id}/classification-level")]
        Task<IApiResponse<ClassificationLevel>> GetBlogPostClassificationLevelAsync(long id, [Query] Status4? status = default, CancellationToken cancellationToken = default);

        /// <summary>Update blog post classification level</summary>
        /// <remarks>
        /// Updates the [classification level](https://developer.atlassian.com/cloud/admin/dlp/rest/intro/#Classification%20level)
        /// for a specific blog post.
        /// 
        /// **[Permissions](https://confluence.atlassian.com/x/_AozKw) required**:
        /// 'Permission to access the Confluence site ('Can use' global permission) and permission to edit the blog post.
        /// </remarks>
        /// <param name="id">The ID of the blog post for which classification level should be updated.</param>
        /// <returns>
        /// A <see cref="Task"/> representing the <see cref="IApiResponse"/> instance containing the result:
        /// <list type="table">
        /// <listheader>
        /// <term>Status</term>
        /// <description>Description</description>
        /// </listheader>
        /// <item>
        /// <term>204</term>
        /// <description>Returned if the classification level was successfully updated.</description>
        /// </item>
        /// <item>
        /// <term>400</term>
        /// <description>Returned if an invalid request is provided.</description>
        /// </item>
        /// <item>
        /// <term>401</term>
        /// <description>Returned if the authentication credentials are incorrect or missing\nfrom the request.</description>
        /// </item>
        /// <item>
        /// <term>404</term>
        /// <description>Returned if:\n- Site\'s edition does not have entitlement(s) for [data classification](https://support.atlassian.com/security-and-access-policies/docs/what-is-data-classification/)\n- The calling user does not have permission to edit the specified blog post or the blog post was not found</description>
        /// </item>
        /// </list>
        /// </returns>
        [Put("/blogposts/{id}/classification-level")]
        Task<IApiResponse> PutBlogPostClassificationLevelAsync(long id, [Body] object? body = default, CancellationToken cancellationToken = default);

        /// <summary>Reset blog post classification level</summary>
        /// <remarks>
        /// Resets the [classification level](https://developer.atlassian.com/cloud/admin/dlp/rest/intro/#Classification%20level)
        /// for a specific blog post to the space
        /// [default classification level](https://support.atlassian.com/security-and-access-policies/docs/what-is-a-default-classification-level/).
        /// 
        /// **[Permissions](https://confluence.atlassian.com/x/_AozKw) required**:
        /// 'Permission to access the Confluence site ('Can use' global permission) and permission to view the blog post.
        /// </remarks>
        /// <param name="id">The ID of the blog post for which classification level should be updated.</param>
        /// <returns>
        /// A <see cref="Task"/> representing the <see cref="IApiResponse"/> instance containing the result:
        /// <list type="table">
        /// <listheader>
        /// <term>Status</term>
        /// <description>Description</description>
        /// </listheader>
        /// <item>
        /// <term>204</term>
        /// <description>Returned if the classification level was successfully reset.</description>
        /// </item>
        /// <item>
        /// <term>400</term>
        /// <description>Returned if an invalid request is provided.</description>
        /// </item>
        /// <item>
        /// <term>401</term>
        /// <description>Returned if the authentication credentials are incorrect or missing\nfrom the request.</description>
        /// </item>
        /// <item>
        /// <term>404</term>
        /// <description>Returned if:\n- Site\'s edition does not have entitlement(s) for [data classification](https://support.atlassian.com/security-and-access-policies/docs/what-is-data-classification/)\n- The calling user does not have permission to edit the specified blog post or the blog post was not found</description>
        /// </item>
        /// </list>
        /// </returns>
        [Post("/blogposts/{id}/classification-level/reset")]
        Task<IApiResponse> PostBlogPostClassificationLevelAsync(long id, [Body] object? body = default, CancellationToken cancellationToken = default);
    }


}


//----------------------
// <auto-generated>
//     Generated using the NSwag toolchain v14.0.7.0 (NJsonSchema v11.0.0.0 (Newtonsoft.Json v13.0.0.0)) (http://NSwag.org)
// </auto-generated>
//----------------------

#pragma warning disable 108 // Disable "CS0108 '{derivedDto}.ToJson()' hides inherited member '{dtoBase}.ToJson()'. Use the new keyword if hiding was intended."
#pragma warning disable 114 // Disable "CS0114 '{derivedDto}.RaisePropertyChanged(String)' hides inherited member 'dtoBase.RaisePropertyChanged(String)'. To make the current member override that implementation, add the override keyword. Otherwise add the new keyword."
#pragma warning disable 472 // Disable "CS0472 The result of the expression is always 'false' since a value of type 'Int32' is never equal to 'null' of type 'Int32?'
#pragma warning disable 612 // Disable "CS0612 '...' is obsolete"
#pragma warning disable 1573 // Disable "CS1573 Parameter '...' has no matching param tag in the XML comment for ...
#pragma warning disable 1591 // Disable "CS1591 Missing XML comment for publicly visible type or member ..."
#pragma warning disable 8073 // Disable "CS8073 The result of the expression is always 'false' since a value of type 'T' is never equal to 'null' of type 'T?'"
#pragma warning disable 3016 // Disable "CS3016 Arrays as attribute arguments is not CLS-compliant"
#pragma warning disable 8603 // Disable "CS8603 Possible null reference return"
#pragma warning disable 8604 // Disable "CS8604 Possible null reference argument for parameter"
#pragma warning disable 8625 // Disable "CS8625 Cannot convert null literal to non-nullable reference type"
#pragma warning disable CS8765 // Nullability of type of parameter doesn't match overridden member (possibly because of nullability attributes).

namespace ConfluenceApiV2.Client
{
    using System = global::System;

    

    [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "14.0.7.0 (NJsonSchema v11.0.0.0 (Newtonsoft.Json v13.0.0.0))")]
    public partial class AttachmentSingle
    {
        /// <summary>
        /// ID of the attachment.
        /// </summary>

        [JsonPropertyName("id")]
        public string Id { get; set; }

        [JsonPropertyName("status")]
        [JsonConverter(typeof(JsonStringEnumConverter))]
        public ContentStatus Status { get; set; }

        /// <summary>
        /// Title of the comment.
        /// </summary>

        [JsonPropertyName("title")]
        public string Title { get; set; }

        /// <summary>
        /// Date and time when the attachment was created. In format "YYYY-MM-DDTHH:mm:ss.sssZ".
        /// </summary>

        [JsonPropertyName("createdAt")]
        public System.DateTimeOffset CreatedAt { get; set; }

        /// <summary>
        /// ID of the containing page.
        /// <br/>
        /// <br/>Note: This is only returned if the attachment has a container that is a page.
        /// </summary>

        [JsonPropertyName("pageId")]
        public string PageId { get; set; }

        /// <summary>
        /// ID of the containing blog post.
        /// <br/>
        /// <br/>Note: This is only returned if the attachment has a container that is a blog post.
        /// </summary>

        [JsonPropertyName("blogPostId")]
        public string BlogPostId { get; set; }

        /// <summary>
        /// ID of the containing custom content.
        /// <br/>
        /// <br/>Note: This is only returned if the attachment has a container that is custom content.
        /// </summary>

        [JsonPropertyName("customContentId")]
        public string CustomContentId { get; set; }

        /// <summary>
        /// Media Type for the attachment.
        /// </summary>

        [JsonPropertyName("mediaType")]
        public string MediaType { get; set; }

        /// <summary>
        /// Media Type description for the attachment.
        /// </summary>

        [JsonPropertyName("mediaTypeDescription")]
        public string MediaTypeDescription { get; set; }

        /// <summary>
        /// Comment for the attachment.
        /// </summary>

        [JsonPropertyName("comment")]
        public string Comment { get; set; }

        /// <summary>
        /// File ID of the attachment. This is the ID referenced in `atlas_doc_format` bodies and is distinct from the attachment ID.
        /// </summary>

        [JsonPropertyName("fileId")]
        public string FileId { get; set; }

        /// <summary>
        /// File size of the attachment.
        /// </summary>

        [JsonPropertyName("fileSize")]
        public long FileSize { get; set; }

        /// <summary>
        /// WebUI link of the attachment.
        /// </summary>

        [JsonPropertyName("webuiLink")]
        public string WebuiLink { get; set; }

        /// <summary>
        /// Download link of the attachment.
        /// </summary>

        [JsonPropertyName("downloadLink")]
        public string DownloadLink { get; set; }

        [JsonPropertyName("version")]
        public Version Version { get; set; }

        [JsonPropertyName("labels")]
        public Labels Labels { get; set; }

        [JsonPropertyName("properties")]
        public Properties Properties { get; set; }

        [JsonPropertyName("operations")]
        public Operations Operations { get; set; }

        [JsonPropertyName("versions")]
        public Versions Versions { get; set; }

        [JsonPropertyName("_links")]
        public AttachmentLinks _links { get; set; }

        private IDictionary<string, object> _additionalProperties;

        [JsonExtensionData]
        public IDictionary<string, object> AdditionalProperties
        {
            get { return _additionalProperties ?? (_additionalProperties = new Dictionary<string, object>()); }
            set { _additionalProperties = value; }
        }

    }

    [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "14.0.7.0 (NJsonSchema v11.0.0.0 (Newtonsoft.Json v13.0.0.0))")]
    public partial class AttachmentBulk
    {
        /// <summary>
        /// ID of the attachment.
        /// </summary>

        [JsonPropertyName("id")]
        public string Id { get; set; }

        [JsonPropertyName("status")]
        [JsonConverter(typeof(JsonStringEnumConverter))]
        public ContentStatus Status { get; set; }

        /// <summary>
        /// Title of the comment.
        /// </summary>

        [JsonPropertyName("title")]
        public string Title { get; set; }

        /// <summary>
        /// Date and time when the attachment was created. In format "YYYY-MM-DDTHH:mm:ss.sssZ".
        /// </summary>

        [JsonPropertyName("createdAt")]
        public System.DateTimeOffset CreatedAt { get; set; }

        /// <summary>
        /// ID of the containing page.
        /// <br/>
        /// <br/>Note: This is only returned if the attachment has a container that is a page.
        /// </summary>

        [JsonPropertyName("pageId")]
        public string PageId { get; set; }

        /// <summary>
        /// ID of the containing blog post.
        /// <br/>
        /// <br/>Note: This is only returned if the attachment has a container that is a blog post.
        /// </summary>

        [JsonPropertyName("blogPostId")]
        public string BlogPostId { get; set; }

        /// <summary>
        /// ID of the containing custom content.
        /// <br/>
        /// <br/>Note: This is only returned if the attachment has a container that is custom content.
        /// </summary>

        [JsonPropertyName("customContentId")]
        public string CustomContentId { get; set; }

        /// <summary>
        /// Media Type for the attachment.
        /// </summary>

        [JsonPropertyName("mediaType")]
        public string MediaType { get; set; }

        /// <summary>
        /// Media Type description for the attachment.
        /// </summary>

        [JsonPropertyName("mediaTypeDescription")]
        public string MediaTypeDescription { get; set; }

        /// <summary>
        /// Comment for the attachment.
        /// </summary>

        [JsonPropertyName("comment")]
        public string Comment { get; set; }

        /// <summary>
        /// File ID of the attachment. This is the ID referenced in `atlas_doc_format` bodies and is distinct from the attachment ID.
        /// </summary>

        [JsonPropertyName("fileId")]
        public string FileId { get; set; }

        /// <summary>
        /// File size of the attachment.
        /// </summary>

        [JsonPropertyName("fileSize")]
        public long FileSize { get; set; }

        /// <summary>
        /// WebUI link of the attachment.
        /// </summary>

        [JsonPropertyName("webuiLink")]
        public string WebuiLink { get; set; }

        /// <summary>
        /// Download link of the attachment.
        /// </summary>

        [JsonPropertyName("downloadLink")]
        public string DownloadLink { get; set; }

        [JsonPropertyName("version")]
        public Version Version { get; set; }

        [JsonPropertyName("_links")]
        public AttachmentLinks _links { get; set; }

        private IDictionary<string, object> _additionalProperties;

        [JsonExtensionData]
        public IDictionary<string, object> AdditionalProperties
        {
            get { return _additionalProperties ?? (_additionalProperties = new Dictionary<string, object>()); }
            set { _additionalProperties = value; }
        }

    }

    [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "14.0.7.0 (NJsonSchema v11.0.0.0 (Newtonsoft.Json v13.0.0.0))")]
    public partial class BlogPostSingle
    {
        /// <summary>
        /// ID of the blog post.
        /// </summary>

        [JsonPropertyName("id")]
        public string Id { get; set; }

        [JsonPropertyName("status")]
        [JsonConverter(typeof(JsonStringEnumConverter))]
        public BlogPostContentStatus Status { get; set; }

        /// <summary>
        /// Title of the blog post.
        /// </summary>

        [JsonPropertyName("title")]
        public string Title { get; set; }

        /// <summary>
        /// ID of the space the blog post is in.
        /// </summary>

        [JsonPropertyName("spaceId")]
        public string SpaceId { get; set; }

        /// <summary>
        /// The account ID of the user who created this blog post originally.
        /// </summary>

        [JsonPropertyName("authorId")]
        public string AuthorId { get; set; }

        /// <summary>
        /// Date and time when the blog post was created. In format "YYYY-MM-DDTHH:mm:ss.sssZ".
        /// </summary>

        [JsonPropertyName("createdAt")]
        public System.DateTimeOffset CreatedAt { get; set; }

        [JsonPropertyName("version")]
        public Version Version { get; set; }

        [JsonPropertyName("body")]
        public BodySingle Body { get; set; }

        [JsonPropertyName("labels")]
        public Labels2 Labels { get; set; }

        [JsonPropertyName("properties")]
        public Properties2 Properties { get; set; }

        [JsonPropertyName("operations")]
        public Operations2 Operations { get; set; }

        [JsonPropertyName("likes")]
        public Likes Likes { get; set; }

        [JsonPropertyName("versions")]
        public Versions2 Versions { get; set; }

        /// <summary>
        /// Whether the blog post has been favorited by the current user.
        /// </summary>

        [JsonPropertyName("isFavoritedByCurrentUser")]
        public bool IsFavoritedByCurrentUser { get; set; }

        [JsonPropertyName("_links")]
        public AbstractPageLinks _links { get; set; }

        private IDictionary<string, object> _additionalProperties;

        [JsonExtensionData]
        public IDictionary<string, object> AdditionalProperties
        {
            get { return _additionalProperties ?? (_additionalProperties = new Dictionary<string, object>()); }
            set { _additionalProperties = value; }
        }

    }

    [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "14.0.7.0 (NJsonSchema v11.0.0.0 (Newtonsoft.Json v13.0.0.0))")]
    public partial class BlogPostBulk
    {
        /// <summary>
        /// ID of the blog post.
        /// </summary>

        [JsonPropertyName("id")]
        public string Id { get; set; }

        [JsonPropertyName("status")]
        [JsonConverter(typeof(JsonStringEnumConverter))]
        public BlogPostContentStatus Status { get; set; }

        /// <summary>
        /// Title of the blog post.
        /// </summary>

        [JsonPropertyName("title")]
        public string Title { get; set; }

        /// <summary>
        /// ID of the space the blog post is in.
        /// </summary>

        [JsonPropertyName("spaceId")]
        public string SpaceId { get; set; }

        /// <summary>
        /// The account ID of the user who created this blog post originally.
        /// </summary>

        [JsonPropertyName("authorId")]
        public string AuthorId { get; set; }

        /// <summary>
        /// Date and time when the blog post was created. In format "YYYY-MM-DDTHH:mm:ss.sssZ".
        /// </summary>

        [JsonPropertyName("createdAt")]
        public System.DateTimeOffset CreatedAt { get; set; }

        [JsonPropertyName("version")]
        public Version Version { get; set; }

        [JsonPropertyName("body")]
        public BodyBulk Body { get; set; }

        [JsonPropertyName("_links")]
        public AbstractPageLinks _links { get; set; }

        private IDictionary<string, object> _additionalProperties;

        [JsonExtensionData]
        public IDictionary<string, object> AdditionalProperties
        {
            get { return _additionalProperties ?? (_additionalProperties = new Dictionary<string, object>()); }
            set { _additionalProperties = value; }
        }

    }

    /// <summary>
    /// Contains fields for each representation type requested.
    /// </summary>
    [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "14.0.7.0 (NJsonSchema v11.0.0.0 (Newtonsoft.Json v13.0.0.0))")]
    public partial class TaskBodySingle
    {

        [JsonPropertyName("storage")]
        public BodyType Storage { get; set; }

        [JsonPropertyName("atlas_doc_format")]
        public BodyType Atlas_doc_format { get; set; }

        private IDictionary<string, object> _additionalProperties;

        [JsonExtensionData]
        public IDictionary<string, object> AdditionalProperties
        {
            get { return _additionalProperties ?? (_additionalProperties = new Dictionary<string, object>()); }
            set { _additionalProperties = value; }
        }

    }

    /// <summary>
    /// Contains fields for each representation type requested.
    /// </summary>
    [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "14.0.7.0 (NJsonSchema v11.0.0.0 (Newtonsoft.Json v13.0.0.0))")]
    public partial class BodySingle
    {

        [JsonPropertyName("storage")]
        public BodyType Storage { get; set; }

        [JsonPropertyName("atlas_doc_format")]
        public BodyType Atlas_doc_format { get; set; }

        [JsonPropertyName("view")]
        public BodyType View { get; set; }

        private IDictionary<string, object> _additionalProperties;

        [JsonExtensionData]
        public IDictionary<string, object> AdditionalProperties
        {
            get { return _additionalProperties ?? (_additionalProperties = new Dictionary<string, object>()); }
            set { _additionalProperties = value; }
        }

    }

    /// <summary>
    /// Contains fields for each representation type requested.
    /// </summary>
    [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "14.0.7.0 (NJsonSchema v11.0.0.0 (Newtonsoft.Json v13.0.0.0))")]
    public partial class BodyBulk
    {

        [JsonPropertyName("storage")]
        public BodyType Storage { get; set; }

        [JsonPropertyName("atlas_doc_format")]
        public BodyType Atlas_doc_format { get; set; }

        private IDictionary<string, object> _additionalProperties;

        [JsonExtensionData]
        public IDictionary<string, object> AdditionalProperties
        {
            get { return _additionalProperties ?? (_additionalProperties = new Dictionary<string, object>()); }
            set { _additionalProperties = value; }
        }

    }

    [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "14.0.7.0 (NJsonSchema v11.0.0.0 (Newtonsoft.Json v13.0.0.0))")]
    public partial class BodyType
    {
        /// <summary>
        /// Type of content representation used for the value field.
        /// </summary>

        [JsonPropertyName("representation")]
        public string Representation { get; set; }

        /// <summary>
        /// Body of the content, in the format found in the representation field.
        /// </summary>

        [JsonPropertyName("value")]
        public string Value { get; set; }

        private IDictionary<string, object> _additionalProperties;

        [JsonExtensionData]
        public IDictionary<string, object> AdditionalProperties
        {
            get { return _additionalProperties ?? (_additionalProperties = new Dictionary<string, object>()); }
            set { _additionalProperties = value; }
        }

    }

    /// <summary>
    /// The primary formats a body can be represented as. A subset of BodyRepresentation. These formats are the only allowed formats in certain use cases.
    /// </summary>
    [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "14.0.7.0 (NJsonSchema v11.0.0.0 (Newtonsoft.Json v13.0.0.0))")]
    public enum PrimaryBodyRepresentation
    {

        [System.Runtime.Serialization.EnumMember(Value = @"storage")]
        Storage = 0,

        [System.Runtime.Serialization.EnumMember(Value = @"atlas_doc_format")]
        Atlas_doc_format = 1,

    }

    /// <summary>
    /// The primary formats a body can be represented as. A subset of BodyRepresentation. These formats are the only allowed formats in certain use cases.
    /// </summary>
    [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "14.0.7.0 (NJsonSchema v11.0.0.0 (Newtonsoft.Json v13.0.0.0))")]
    public enum PrimaryBodyRepresentationSingle
    {

        [System.Runtime.Serialization.EnumMember(Value = @"storage")]
        Storage = 0,

        [System.Runtime.Serialization.EnumMember(Value = @"atlas_doc_format")]
        Atlas_doc_format = 1,

        [System.Runtime.Serialization.EnumMember(Value = @"view")]
        View = 2,

        [System.Runtime.Serialization.EnumMember(Value = @"export_view")]
        Export_view = 3,

        [System.Runtime.Serialization.EnumMember(Value = @"anonymous_export_view")]
        Anonymous_export_view = 4,

        [System.Runtime.Serialization.EnumMember(Value = @"styled_view")]
        Styled_view = 5,

        [System.Runtime.Serialization.EnumMember(Value = @"editor")]
        Editor = 6,

    }

    /// <summary>
    /// The formats a custom content body can be represented as. A subset of BodyRepresentation.
    /// </summary>
    [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "14.0.7.0 (NJsonSchema v11.0.0.0 (Newtonsoft.Json v13.0.0.0))")]
    public enum CustomContentBodyRepresentation
    {

        [System.Runtime.Serialization.EnumMember(Value = @"raw")]
        Raw = 0,

        [System.Runtime.Serialization.EnumMember(Value = @"storage")]
        Storage = 1,

        [System.Runtime.Serialization.EnumMember(Value = @"atlas_doc_format")]
        Atlas_doc_format = 2,

    }

    /// <summary>
    /// The formats a custom content body can be represented as. A subset of BodyRepresentation.
    /// </summary>
    [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "14.0.7.0 (NJsonSchema v11.0.0.0 (Newtonsoft.Json v13.0.0.0))")]
    public enum CustomContentBodyRepresentationSingle
    {

        [System.Runtime.Serialization.EnumMember(Value = @"raw")]
        Raw = 0,

        [System.Runtime.Serialization.EnumMember(Value = @"storage")]
        Storage = 1,

        [System.Runtime.Serialization.EnumMember(Value = @"atlas_doc_format")]
        Atlas_doc_format = 2,

        [System.Runtime.Serialization.EnumMember(Value = @"view")]
        View = 3,

        [System.Runtime.Serialization.EnumMember(Value = @"export_view")]
        Export_view = 4,

        [System.Runtime.Serialization.EnumMember(Value = @"anonymous_export_view")]
        Anonymous_export_view = 5,

    }

    /// <summary>
    /// The formats a space description can be represented as. A subset of BodyRepresentation.
    /// </summary>
    [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "14.0.7.0 (NJsonSchema v11.0.0.0 (Newtonsoft.Json v13.0.0.0))")]
    public enum SpaceDescriptionBodyRepresentation
    {

        [System.Runtime.Serialization.EnumMember(Value = @"plain")]
        Plain = 0,

        [System.Runtime.Serialization.EnumMember(Value = @"view")]
        View = 1,

    }

    [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "14.0.7.0 (NJsonSchema v11.0.0.0 (Newtonsoft.Json v13.0.0.0))")]
    public partial class ContentIdToContentTypeResponse
    {
        /// <summary>
        /// JSON object containing all requested content ids as keys and their associated content types as the values.
        /// <br/>Duplicate content ids in the request will be returned under a single key in the response. For built-in content
        /// <br/>types, the enumerations are as specified. Custom content ids will be mapped to their associated type.
        /// </summary>

        [JsonPropertyName("results")]
        public IDictionary<string, Anonymous12> Results { get; set; }

        private IDictionary<string, object> _additionalProperties;

        [JsonExtensionData]
        public IDictionary<string, object> AdditionalProperties
        {
            get { return _additionalProperties ?? (_additionalProperties = new Dictionary<string, object>()); }
            set { _additionalProperties = value; }
        }

    }

    /// <summary>
    /// The status of the content.
    /// </summary>
    [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "14.0.7.0 (NJsonSchema v11.0.0.0 (Newtonsoft.Json v13.0.0.0))")]
    public enum ContentStatus
    {

        [System.Runtime.Serialization.EnumMember(Value = @"current")]
        Current = 0,

        [System.Runtime.Serialization.EnumMember(Value = @"draft")]
        Draft = 1,

        [System.Runtime.Serialization.EnumMember(Value = @"archived")]
        Archived = 2,

        [System.Runtime.Serialization.EnumMember(Value = @"historical")]
        Historical = 3,

        [System.Runtime.Serialization.EnumMember(Value = @"trashed")]
        Trashed = 4,

        [System.Runtime.Serialization.EnumMember(Value = @"deleted")]
        Deleted = 5,

        [System.Runtime.Serialization.EnumMember(Value = @"any")]
        Any = 6,

    }

    /// <summary>
    /// The status of the content.
    /// </summary>
    [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "14.0.7.0 (NJsonSchema v11.0.0.0 (Newtonsoft.Json v13.0.0.0))")]
    public enum BlogPostContentStatus
    {

        [System.Runtime.Serialization.EnumMember(Value = @"current")]
        Current = 0,

        [System.Runtime.Serialization.EnumMember(Value = @"draft")]
        Draft = 1,

        [System.Runtime.Serialization.EnumMember(Value = @"historical")]
        Historical = 2,

        [System.Runtime.Serialization.EnumMember(Value = @"trashed")]
        Trashed = 3,

        [System.Runtime.Serialization.EnumMember(Value = @"deleted")]
        Deleted = 4,

        [System.Runtime.Serialization.EnumMember(Value = @"any")]
        Any = 5,

    }

    /// <summary>
    /// The status of the content.
    /// </summary>
    [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "14.0.7.0 (NJsonSchema v11.0.0.0 (Newtonsoft.Json v13.0.0.0))")]
    public enum OnlyArchivedAndCurrentContentStatus
    {

        [System.Runtime.Serialization.EnumMember(Value = @"current")]
        Current = 0,

        [System.Runtime.Serialization.EnumMember(Value = @"archived")]
        Archived = 1,

    }

    [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "14.0.7.0 (NJsonSchema v11.0.0.0 (Newtonsoft.Json v13.0.0.0))")]
    public partial class ContentProperty
    {
        /// <summary>
        /// ID of the property
        /// </summary>

        [JsonPropertyName("id")]
        public string Id { get; set; }

        /// <summary>
        /// Key of the property
        /// </summary>

        [JsonPropertyName("key")]
        public string Key { get; set; }

        /// <summary>
        /// Value of the property. Must be a valid JSON value.
        /// </summary>

        [JsonPropertyName("value")]
        public object Value { get; set; }

        [JsonPropertyName("version")]
        public Version Version { get; set; }

        private IDictionary<string, object> _additionalProperties;

        [JsonExtensionData]
        public IDictionary<string, object> AdditionalProperties
        {
            get { return _additionalProperties ?? (_additionalProperties = new Dictionary<string, object>()); }
            set { _additionalProperties = value; }
        }

    }

    [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "14.0.7.0 (NJsonSchema v11.0.0.0 (Newtonsoft.Json v13.0.0.0))")]
    public partial class ContentPropertyCreateRequest
    {
        /// <summary>
        /// Key of the content property
        /// </summary>

        [JsonPropertyName("key")]
        public string Key { get; set; }

        /// <summary>
        /// Value of the content property.
        /// </summary>

        [JsonPropertyName("value")]
        public object Value { get; set; }

        private IDictionary<string, object> _additionalProperties;

        [JsonExtensionData]
        public IDictionary<string, object> AdditionalProperties
        {
            get { return _additionalProperties ?? (_additionalProperties = new Dictionary<string, object>()); }
            set { _additionalProperties = value; }
        }

    }

    [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "14.0.7.0 (NJsonSchema v11.0.0.0 (Newtonsoft.Json v13.0.0.0))")]
    public partial class ContentPropertyUpdateRequest
    {
        /// <summary>
        /// Key of the content property
        /// </summary>

        [JsonPropertyName("key")]
        public string Key { get; set; }

        /// <summary>
        /// Value of the content property.
        /// </summary>

        [JsonPropertyName("value")]
        public object Value { get; set; }

        /// <summary>
        /// New version number and associated message
        /// </summary>

        [JsonPropertyName("version")]
        public Version2 Version { get; set; }

        private IDictionary<string, object> _additionalProperties;

        [JsonExtensionData]
        public IDictionary<string, object> AdditionalProperties
        {
            get { return _additionalProperties ?? (_additionalProperties = new Dictionary<string, object>()); }
            set { _additionalProperties = value; }
        }

    }

    [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "14.0.7.0 (NJsonSchema v11.0.0.0 (Newtonsoft.Json v13.0.0.0))")]
    public partial class CustomContentSingle
    {
        /// <summary>
        /// ID of the custom content.
        /// </summary>

        [JsonPropertyName("id")]
        public string Id { get; set; }

        /// <summary>
        /// The type of custom content.
        /// </summary>

        [JsonPropertyName("type")]
        public string Type { get; set; }

        [JsonPropertyName("status")]
        [JsonConverter(typeof(JsonStringEnumConverter))]
        public ContentStatus Status { get; set; }

        /// <summary>
        /// Title of the custom content.
        /// </summary>

        [JsonPropertyName("title")]
        public string Title { get; set; }

        /// <summary>
        /// ID of the space the custom content is in.
        /// <br/>
        /// <br/>Note: This is always returned, regardless of if the custom content has a container that is a space.
        /// </summary>

        [JsonPropertyName("spaceId")]
        public string SpaceId { get; set; }

        /// <summary>
        /// ID of the containing page.
        /// <br/>
        /// <br/>Note: This is only returned if the custom content has a container that is a page.
        /// </summary>

        [JsonPropertyName("pageId")]
        public string PageId { get; set; }

        /// <summary>
        /// ID of the containing blog post.
        /// <br/>
        /// <br/>Note: This is only returned if the custom content has a container that is a blog post.
        /// </summary>

        [JsonPropertyName("blogPostId")]
        public string BlogPostId { get; set; }

        /// <summary>
        /// ID of the containing custom content.
        /// <br/>
        /// <br/>Note: This is only returned if the custom content has a container that is custom content.
        /// </summary>

        [JsonPropertyName("customContentId")]
        public string CustomContentId { get; set; }

        /// <summary>
        /// The account ID of the user who created this custom content originally.
        /// </summary>

        [JsonPropertyName("authorId")]
        public string AuthorId { get; set; }

        /// <summary>
        /// Date and time when the custom content was created. In format "YYYY-MM-DDTHH:mm:ss.sssZ".
        /// </summary>

        [JsonPropertyName("createdAt")]
        public System.DateTimeOffset CreatedAt { get; set; }

        [JsonPropertyName("version")]
        public Version Version { get; set; }

        [JsonPropertyName("labels")]
        public Labels3 Labels { get; set; }

        [JsonPropertyName("properties")]
        public Properties3 Properties { get; set; }

        [JsonPropertyName("operations")]
        public Operations3 Operations { get; set; }

        [JsonPropertyName("versions")]
        public Versions3 Versions { get; set; }

        [JsonPropertyName("body")]
        public CustomContentBodySingle Body { get; set; }

        [JsonPropertyName("_links")]
        public CustomContentLinks _links { get; set; }

        private IDictionary<string, object> _additionalProperties;

        [JsonExtensionData]
        public IDictionary<string, object> AdditionalProperties
        {
            get { return _additionalProperties ?? (_additionalProperties = new Dictionary<string, object>()); }
            set { _additionalProperties = value; }
        }

    }

    [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "14.0.7.0 (NJsonSchema v11.0.0.0 (Newtonsoft.Json v13.0.0.0))")]
    public partial class CustomContentBulk
    {
        /// <summary>
        /// ID of the custom content.
        /// </summary>

        [JsonPropertyName("id")]
        public string Id { get; set; }

        /// <summary>
        /// The type of custom content.
        /// </summary>

        [JsonPropertyName("type")]
        public string Type { get; set; }

        [JsonPropertyName("status")]
        [JsonConverter(typeof(JsonStringEnumConverter))]
        public ContentStatus Status { get; set; }

        /// <summary>
        /// Title of the custom content.
        /// </summary>

        [JsonPropertyName("title")]
        public string Title { get; set; }

        /// <summary>
        /// ID of the space the custom content is in.
        /// <br/>
        /// <br/>Note: This is always returned, regardless of if the custom content has a container that is a space.
        /// </summary>

        [JsonPropertyName("spaceId")]
        public string SpaceId { get; set; }

        /// <summary>
        /// ID of the containing page.
        /// <br/>
        /// <br/>Note: This is only returned if the custom content has a container that is a page.
        /// </summary>

        [JsonPropertyName("pageId")]
        public string PageId { get; set; }

        /// <summary>
        /// ID of the containing blog post.
        /// <br/>
        /// <br/>Note: This is only returned if the custom content has a container that is a blog post.
        /// </summary>

        [JsonPropertyName("blogPostId")]
        public string BlogPostId { get; set; }

        /// <summary>
        /// ID of the containing custom content.
        /// <br/>
        /// <br/>Note: This is only returned if the custom content has a container that is custom content.
        /// </summary>

        [JsonPropertyName("customContentId")]
        public string CustomContentId { get; set; }

        /// <summary>
        /// The account ID of the user who created this custom content originally.
        /// </summary>

        [JsonPropertyName("authorId")]
        public string AuthorId { get; set; }

        /// <summary>
        /// Date and time when the custom content was created. In format "YYYY-MM-DDTHH:mm:ss.sssZ".
        /// </summary>

        [JsonPropertyName("createdAt")]
        public System.DateTimeOffset CreatedAt { get; set; }

        [JsonPropertyName("version")]
        public Version Version { get; set; }

        [JsonPropertyName("body")]
        public CustomContentBodyBulk Body { get; set; }

        [JsonPropertyName("_links")]
        public CustomContentLinks _links { get; set; }

        private IDictionary<string, object> _additionalProperties;

        [JsonExtensionData]
        public IDictionary<string, object> AdditionalProperties
        {
            get { return _additionalProperties ?? (_additionalProperties = new Dictionary<string, object>()); }
            set { _additionalProperties = value; }
        }

    }

    /// <summary>
    /// Contains fields for each representation type requested.
    /// </summary>
    [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "14.0.7.0 (NJsonSchema v11.0.0.0 (Newtonsoft.Json v13.0.0.0))")]
    public partial class CustomContentBodySingle
    {

        [JsonPropertyName("raw")]
        public BodyType Raw { get; set; }

        [JsonPropertyName("storage")]
        public BodyType Storage { get; set; }

        [JsonPropertyName("atlas_doc_format")]
        public BodyType Atlas_doc_format { get; set; }

        [JsonPropertyName("view")]
        public BodyType View { get; set; }

        private IDictionary<string, object> _additionalProperties;

        [JsonExtensionData]
        public IDictionary<string, object> AdditionalProperties
        {
            get { return _additionalProperties ?? (_additionalProperties = new Dictionary<string, object>()); }
            set { _additionalProperties = value; }
        }

    }

    /// <summary>
    /// Contains fields for each representation type requested.
    /// </summary>
    [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "14.0.7.0 (NJsonSchema v11.0.0.0 (Newtonsoft.Json v13.0.0.0))")]
    public partial class CustomContentBodyBulk
    {

        [JsonPropertyName("raw")]
        public BodyType Raw { get; set; }

        [JsonPropertyName("storage")]
        public BodyType Storage { get; set; }

        [JsonPropertyName("atlas_doc_format")]
        public BodyType Atlas_doc_format { get; set; }

        private IDictionary<string, object> _additionalProperties;

        [JsonExtensionData]
        public IDictionary<string, object> AdditionalProperties
        {
            get { return _additionalProperties ?? (_additionalProperties = new Dictionary<string, object>()); }
            set { _additionalProperties = value; }
        }

    }

    [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "14.0.7.0 (NJsonSchema v11.0.0.0 (Newtonsoft.Json v13.0.0.0))")]
    public partial class DetailedVersion
    {
        /// <summary>
        /// The current version number.
        /// </summary>

        [JsonPropertyName("number")]
        public int Number { get; set; }

        /// <summary>
        /// The account ID of the user who created this version.
        /// </summary>

        [JsonPropertyName("authorId")]
        public string AuthorId { get; set; }

        /// <summary>
        /// Message associated with the current version.
        /// </summary>

        [JsonPropertyName("message")]
        public string Message { get; set; }

        /// <summary>
        /// Date and time when the version was created. In format "YYYY-MM-DDTHH:mm:ss.sssZ".
        /// </summary>

        [JsonPropertyName("createdAt")]
        public System.DateTimeOffset CreatedAt { get; set; }

        /// <summary>
        /// Describes if this version is a minor version. Email notifications and activity stream updates are not created for minor versions.
        /// </summary>

        [JsonPropertyName("minorEdit")]
        public bool MinorEdit { get; set; }

        /// <summary>
        /// Describes if the content type is modified in this version (e.g. page to blog)
        /// </summary>

        [JsonPropertyName("contentTypeModified")]
        public bool ContentTypeModified { get; set; }

        /// <summary>
        /// The account IDs of users that collaborated on this version.
        /// </summary>

        [JsonPropertyName("collaborators")]
        public ICollection<string> Collaborators { get; set; }

        /// <summary>
        /// The version number of the version prior to this current content update.
        /// </summary>

        [JsonPropertyName("prevVersion")]
        public int PrevVersion { get; set; }

        /// <summary>
        /// The version number of the version after this current content update.
        /// </summary>

        [JsonPropertyName("nextVersion")]
        public int NextVersion { get; set; }

        private IDictionary<string, object> _additionalProperties;

        [JsonExtensionData]
        public IDictionary<string, object> AdditionalProperties
        {
            get { return _additionalProperties ?? (_additionalProperties = new Dictionary<string, object>()); }
            set { _additionalProperties = value; }
        }

    }

    [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "14.0.7.0 (NJsonSchema v11.0.0.0 (Newtonsoft.Json v13.0.0.0))")]
    public partial class Label
    {
        /// <summary>
        /// ID of the label.
        /// </summary>

        [JsonPropertyName("id")]
        public string Id { get; set; }

        /// <summary>
        /// Name of the label.
        /// </summary>

        [JsonPropertyName("name")]
        public string Name { get; set; }

        /// <summary>
        /// Prefix of the label.
        /// </summary>

        [JsonPropertyName("prefix")]
        public string Prefix { get; set; }

        private IDictionary<string, object> _additionalProperties;

        [JsonExtensionData]
        public IDictionary<string, object> AdditionalProperties
        {
            get { return _additionalProperties ?? (_additionalProperties = new Dictionary<string, object>()); }
            set { _additionalProperties = value; }
        }

    }

    [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "14.0.7.0 (NJsonSchema v11.0.0.0 (Newtonsoft.Json v13.0.0.0))")]
    public partial class Like
    {
        /// <summary>
        /// Account ID.
        /// </summary>

        [JsonPropertyName("accountId")]
        public string AccountId { get; set; }

        private IDictionary<string, object> _additionalProperties;

        [JsonExtensionData]
        public IDictionary<string, object> AdditionalProperties
        {
            get { return _additionalProperties ?? (_additionalProperties = new Dictionary<string, object>()); }
            set { _additionalProperties = value; }
        }

    }

    [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "14.0.7.0 (NJsonSchema v11.0.0.0 (Newtonsoft.Json v13.0.0.0))")]
    public partial class Operation
    {
        /// <summary>
        /// The type of operation.
        /// </summary>

        [JsonPropertyName("operation")]
        public string Operation1 { get; set; }

        /// <summary>
        /// The type of entity the operation type targets.
        /// </summary>

        [JsonPropertyName("targetType")]
        public string TargetType { get; set; }

        private IDictionary<string, object> _additionalProperties;

        [JsonExtensionData]
        public IDictionary<string, object> AdditionalProperties
        {
            get { return _additionalProperties ?? (_additionalProperties = new Dictionary<string, object>()); }
            set { _additionalProperties = value; }
        }

    }

    /// <summary>
    /// The list of operations permitted on entity.
    /// </summary>
    [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "14.0.7.0 (NJsonSchema v11.0.0.0 (Newtonsoft.Json v13.0.0.0))")]
    public partial class PermittedOperationsResponse
    {

        [JsonPropertyName("operations")]
        public ICollection<Operation> Operations { get; set; }

        private IDictionary<string, object> _additionalProperties;

        [JsonExtensionData]
        public IDictionary<string, object> AdditionalProperties
        {
            get { return _additionalProperties ?? (_additionalProperties = new Dictionary<string, object>()); }
            set { _additionalProperties = value; }
        }

    }

    [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "14.0.7.0 (NJsonSchema v11.0.0.0 (Newtonsoft.Json v13.0.0.0))")]
    public partial class PageSingle
    {
        /// <summary>
        /// ID of the page.
        /// </summary>

        [JsonPropertyName("id")]
        public string Id { get; set; }

        [JsonPropertyName("status")]
        [JsonConverter(typeof(JsonStringEnumConverter))]
        public ContentStatus Status { get; set; }

        /// <summary>
        /// Title of the page.
        /// </summary>

        [JsonPropertyName("title")]
        public string Title { get; set; }

        /// <summary>
        /// ID of the space the page is in.
        /// </summary>

        [JsonPropertyName("spaceId")]
        public string SpaceId { get; set; }

        /// <summary>
        /// ID of the parent page, or null if there is no parent page.
        /// </summary>

        [JsonPropertyName("parentId")]
        public string ParentId { get; set; }

        [JsonPropertyName("parentType")]
        [JsonConverter(typeof(JsonStringEnumConverter))]
        public ParentContentType ParentType { get; set; }

        /// <summary>
        /// Position of child page within the given parent page tree.
        /// </summary>

        [JsonPropertyName("position")]
        public int? Position { get; set; }

        /// <summary>
        /// The account ID of the user who created this page originally.
        /// </summary>

        [JsonPropertyName("authorId")]
        public string AuthorId { get; set; }

        /// <summary>
        /// The account ID of the user who owns this page.
        /// </summary>

        [JsonPropertyName("ownerId")]
        public string OwnerId { get; set; }

        /// <summary>
        /// The account ID of the user who owned this page previously, or null if there is no previous owner.
        /// </summary>

        [JsonPropertyName("lastOwnerId")]
        public string LastOwnerId { get; set; }

        /// <summary>
        /// Date and time when the page was created. In format "YYYY-MM-DDTHH:mm:ss.sssZ".
        /// </summary>

        [JsonPropertyName("createdAt")]
        public System.DateTimeOffset CreatedAt { get; set; }

        [JsonPropertyName("version")]
        public Version Version { get; set; }

        [JsonPropertyName("body")]
        public BodySingle Body { get; set; }

        [JsonPropertyName("labels")]
        public Labels4 Labels { get; set; }

        [JsonPropertyName("properties")]
        public Properties4 Properties { get; set; }

        [JsonPropertyName("operations")]
        public Operations4 Operations { get; set; }

        [JsonPropertyName("likes")]
        public Likes2 Likes { get; set; }

        [JsonPropertyName("versions")]
        public Versions4 Versions { get; set; }

        /// <summary>
        /// Whether the page has been favorited by the current user.
        /// </summary>

        [JsonPropertyName("isFavoritedByCurrentUser")]
        public bool IsFavoritedByCurrentUser { get; set; }

        [JsonPropertyName("_links")]
        public AbstractPageLinks _links { get; set; }

        private IDictionary<string, object> _additionalProperties;

        [JsonExtensionData]
        public IDictionary<string, object> AdditionalProperties
        {
            get { return _additionalProperties ?? (_additionalProperties = new Dictionary<string, object>()); }
            set { _additionalProperties = value; }
        }

    }

    [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "14.0.7.0 (NJsonSchema v11.0.0.0 (Newtonsoft.Json v13.0.0.0))")]
    public partial class PageBulk
    {
        /// <summary>
        /// ID of the page.
        /// </summary>

        [JsonPropertyName("id")]
        public string Id { get; set; }

        [JsonPropertyName("status")]
        [JsonConverter(typeof(JsonStringEnumConverter))]
        public ContentStatus Status { get; set; }

        /// <summary>
        /// Title of the page.
        /// </summary>

        [JsonPropertyName("title")]
        public string Title { get; set; }

        /// <summary>
        /// ID of the space the page is in.
        /// </summary>

        [JsonPropertyName("spaceId")]
        public string SpaceId { get; set; }

        /// <summary>
        /// ID of the parent page, or null if there is no parent page.
        /// </summary>

        [JsonPropertyName("parentId")]
        public string ParentId { get; set; }

        [JsonPropertyName("parentType")]
        [JsonConverter(typeof(JsonStringEnumConverter))]
        public ParentContentType ParentType { get; set; }

        /// <summary>
        /// Position of child page within the given parent page tree.
        /// </summary>

        [JsonPropertyName("position")]
        public int? Position { get; set; }

        /// <summary>
        /// The account ID of the user who created this page originally.
        /// </summary>

        [JsonPropertyName("authorId")]
        public string AuthorId { get; set; }

        /// <summary>
        /// The account ID of the user who owns this page.
        /// </summary>

        [JsonPropertyName("ownerId")]
        public string OwnerId { get; set; }

        /// <summary>
        /// The account ID of the user who owned this page previously, or null if there is no previous owner.
        /// </summary>

        [JsonPropertyName("lastOwnerId")]
        public string LastOwnerId { get; set; }

        /// <summary>
        /// Date and time when the page was created. In format "YYYY-MM-DDTHH:mm:ss.sssZ".
        /// </summary>

        [JsonPropertyName("createdAt")]
        public System.DateTimeOffset CreatedAt { get; set; }

        [JsonPropertyName("version")]
        public Version Version { get; set; }

        [JsonPropertyName("body")]
        public BodyBulk Body { get; set; }

        [JsonPropertyName("_links")]
        public AbstractPageLinks _links { get; set; }

        private IDictionary<string, object> _additionalProperties;

        [JsonExtensionData]
        public IDictionary<string, object> AdditionalProperties
        {
            get { return _additionalProperties ?? (_additionalProperties = new Dictionary<string, object>()); }
            set { _additionalProperties = value; }
        }

    }

    /// <summary>
    /// Content type of the parent, or null if there is no parent.
    /// </summary>
    [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "14.0.7.0 (NJsonSchema v11.0.0.0 (Newtonsoft.Json v13.0.0.0))")]
    public enum ParentContentType
    {

        [System.Runtime.Serialization.EnumMember(Value = @"page")]
        Page = 0,

        [System.Runtime.Serialization.EnumMember(Value = @"whiteboard")]
        Whiteboard = 1,

        [System.Runtime.Serialization.EnumMember(Value = @"database")]
        Database = 2,

        [System.Runtime.Serialization.EnumMember(Value = @"embed")]
        Embed = 3,

    }

    [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "14.0.7.0 (NJsonSchema v11.0.0.0 (Newtonsoft.Json v13.0.0.0))")]
    public partial class PageBodyWrite
    {
        /// <summary>
        /// Type of content representation used for the value field.
        /// </summary>

        [JsonPropertyName("representation")]
        [JsonConverter(typeof(JsonStringEnumConverter))]
        public PageBodyWriteRepresentation Representation { get; set; }

        /// <summary>
        /// Body of the page, in the format found in the representation field.
        /// </summary>

        [JsonPropertyName("value")]
        public string Value { get; set; }

        private IDictionary<string, object> _additionalProperties;

        [JsonExtensionData]
        public IDictionary<string, object> AdditionalProperties
        {
            get { return _additionalProperties ?? (_additionalProperties = new Dictionary<string, object>()); }
            set { _additionalProperties = value; }
        }

    }

    /// <summary>
    /// Body of the page. Only one body format should be specified as the property
    /// <br/>for this object, e.g. `storage`.
    /// </summary>
    [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "14.0.7.0 (NJsonSchema v11.0.0.0 (Newtonsoft.Json v13.0.0.0))")]
    public partial class PageNestedBodyWrite
    {

        [JsonPropertyName("storage")]
        public PageBodyWrite Storage { get; set; }

        [JsonPropertyName("atlas_doc_format")]
        public PageBodyWrite Atlas_doc_format { get; set; }

        [JsonPropertyName("wiki")]
        public PageBodyWrite Wiki { get; set; }

        private IDictionary<string, object> _additionalProperties;

        [JsonExtensionData]
        public IDictionary<string, object> AdditionalProperties
        {
            get { return _additionalProperties ?? (_additionalProperties = new Dictionary<string, object>()); }
            set { _additionalProperties = value; }
        }

    }

    [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "14.0.7.0 (NJsonSchema v11.0.0.0 (Newtonsoft.Json v13.0.0.0))")]
    public partial class BlogPostBodyWrite
    {
        /// <summary>
        /// Type of content representation used for the value field.
        /// </summary>

        [JsonPropertyName("representation")]
        [JsonConverter(typeof(JsonStringEnumConverter))]
        public BlogPostBodyWriteRepresentation Representation { get; set; }

        /// <summary>
        /// Body of the blog post, in the format found in the representation field.
        /// </summary>

        [JsonPropertyName("value")]
        public string Value { get; set; }

        private IDictionary<string, object> _additionalProperties;

        [JsonExtensionData]
        public IDictionary<string, object> AdditionalProperties
        {
            get { return _additionalProperties ?? (_additionalProperties = new Dictionary<string, object>()); }
            set { _additionalProperties = value; }
        }

    }

    /// <summary>
    /// Body of the blog post. Only one body format should be specified as the property
    /// <br/>for this object, e.g. `storage`.
    /// </summary>
    [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "14.0.7.0 (NJsonSchema v11.0.0.0 (Newtonsoft.Json v13.0.0.0))")]
    public partial class BlogPostNestedBodyWrite
    {

        [JsonPropertyName("storage")]
        public BlogPostBodyWrite Storage { get; set; }

        [JsonPropertyName("atlas_doc_format")]
        public BlogPostBodyWrite Atlas_doc_format { get; set; }

        [JsonPropertyName("wiki")]
        public BlogPostBodyWrite Wiki { get; set; }

        private IDictionary<string, object> _additionalProperties;

        [JsonExtensionData]
        public IDictionary<string, object> AdditionalProperties
        {
            get { return _additionalProperties ?? (_additionalProperties = new Dictionary<string, object>()); }
            set { _additionalProperties = value; }
        }

    }

    [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "14.0.7.0 (NJsonSchema v11.0.0.0 (Newtonsoft.Json v13.0.0.0))")]
    public partial class CommentBodyWrite
    {
        /// <summary>
        /// Type of content representation used for the value field.
        /// </summary>

        [JsonPropertyName("representation")]
        [JsonConverter(typeof(JsonStringEnumConverter))]
        public CommentBodyWriteRepresentation Representation { get; set; }

        /// <summary>
        /// Body of the comment, in the format found in the representation field.
        /// </summary>

        [JsonPropertyName("value")]
        public string Value { get; set; }

        private IDictionary<string, object> _additionalProperties;

        [JsonExtensionData]
        public IDictionary<string, object> AdditionalProperties
        {
            get { return _additionalProperties ?? (_additionalProperties = new Dictionary<string, object>()); }
            set { _additionalProperties = value; }
        }

    }

    /// <summary>
    /// Body of the comment. Only one body format should be specified as the property
    /// <br/>for this object, e.g. `storage`.
    /// </summary>
    [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "14.0.7.0 (NJsonSchema v11.0.0.0 (Newtonsoft.Json v13.0.0.0))")]
    public partial class CommentNestedBodyWrite
    {

        [JsonPropertyName("storage")]
        public CommentBodyWrite Storage { get; set; }

        [JsonPropertyName("atlas_doc_format")]
        public CommentBodyWrite Atlas_doc_format { get; set; }

        [JsonPropertyName("wiki")]
        public CommentBodyWrite Wiki { get; set; }

        private IDictionary<string, object> _additionalProperties;

        [JsonExtensionData]
        public IDictionary<string, object> AdditionalProperties
        {
            get { return _additionalProperties ?? (_additionalProperties = new Dictionary<string, object>()); }
            set { _additionalProperties = value; }
        }

    }

    [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "14.0.7.0 (NJsonSchema v11.0.0.0 (Newtonsoft.Json v13.0.0.0))")]
    public partial class CustomContentBodyWrite
    {
        /// <summary>
        /// Type of content representation used for the value field.
        /// </summary>

        [JsonPropertyName("representation")]
        [JsonConverter(typeof(JsonStringEnumConverter))]
        public CustomContentBodyWriteRepresentation Representation { get; set; }

        /// <summary>
        /// Body of the custom content, in the format found in the representation field.
        /// </summary>

        [JsonPropertyName("value")]
        public string Value { get; set; }

        private IDictionary<string, object> _additionalProperties;

        [JsonExtensionData]
        public IDictionary<string, object> AdditionalProperties
        {
            get { return _additionalProperties ?? (_additionalProperties = new Dictionary<string, object>()); }
            set { _additionalProperties = value; }
        }

    }

    /// <summary>
    /// Body of the custom content. Only one body format should be specified as the property
    /// <br/>for this object, e.g. `storage`.
    /// </summary>
    [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "14.0.7.0 (NJsonSchema v11.0.0.0 (Newtonsoft.Json v13.0.0.0))")]
    public partial class CustomContentNestedBodyWrite
    {

        [JsonPropertyName("storage")]
        public CustomContentBodyWrite Storage { get; set; }

        [JsonPropertyName("atlas_doc_format")]
        public CustomContentBodyWrite Atlas_doc_format { get; set; }

        [JsonPropertyName("raw")]
        public CustomContentBodyWrite Raw { get; set; }

        private IDictionary<string, object> _additionalProperties;

        [JsonExtensionData]
        public IDictionary<string, object> AdditionalProperties
        {
            get { return _additionalProperties ?? (_additionalProperties = new Dictionary<string, object>()); }
            set { _additionalProperties = value; }
        }

    }

    [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "14.0.7.0 (NJsonSchema v11.0.0.0 (Newtonsoft.Json v13.0.0.0))")]
    public partial class ChildPage
    {
        /// <summary>
        /// ID of the page.
        /// </summary>

        [JsonPropertyName("id")]
        public string Id { get; set; }

        [JsonPropertyName("status")]
        [JsonConverter(typeof(JsonStringEnumConverter))]
        public OnlyArchivedAndCurrentContentStatus Status { get; set; }

        /// <summary>
        /// Title of the page.
        /// </summary>

        [JsonPropertyName("title")]
        public string Title { get; set; }

        /// <summary>
        /// ID of the space the page is in.
        /// </summary>

        [JsonPropertyName("spaceId")]
        public string SpaceId { get; set; }

        /// <summary>
        /// Position of child page within the given parent page tree.
        /// </summary>

        [JsonPropertyName("childPosition")]
        public int? ChildPosition { get; set; }

        private IDictionary<string, object> _additionalProperties;

        [JsonExtensionData]
        public IDictionary<string, object> AdditionalProperties
        {
            get { return _additionalProperties ?? (_additionalProperties = new Dictionary<string, object>()); }
            set { _additionalProperties = value; }
        }

    }

    [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "14.0.7.0 (NJsonSchema v11.0.0.0 (Newtonsoft.Json v13.0.0.0))")]
    public partial class ChildCustomContent
    {
        /// <summary>
        /// ID of the child custom content.
        /// </summary>

        [JsonPropertyName("id")]
        public string Id { get; set; }

        [JsonPropertyName("status")]
        [JsonConverter(typeof(JsonStringEnumConverter))]
        public OnlyArchivedAndCurrentContentStatus Status { get; set; }

        /// <summary>
        /// Title of the custom content.
        /// </summary>

        [JsonPropertyName("title")]
        public string Title { get; set; }

        /// <summary>
        /// Custom content type.
        /// </summary>

        [JsonPropertyName("type")]
        public string Type { get; set; }

        /// <summary>
        /// ID of the space the custom content is in.
        /// </summary>

        [JsonPropertyName("spaceId")]
        public string SpaceId { get; set; }

        private IDictionary<string, object> _additionalProperties;

        [JsonExtensionData]
        public IDictionary<string, object> AdditionalProperties
        {
            get { return _additionalProperties ?? (_additionalProperties = new Dictionary<string, object>()); }
            set { _additionalProperties = value; }
        }

    }

    [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "14.0.7.0 (NJsonSchema v11.0.0.0 (Newtonsoft.Json v13.0.0.0))")]
    public partial class WhiteboardSingle
    {
        /// <summary>
        /// ID of the whiteboard.
        /// </summary>

        [JsonPropertyName("id")]
        public string Id { get; set; }

        /// <summary>
        /// The content type of the object.
        /// </summary>

        [JsonPropertyName("type")]
        public string Type { get; set; }

        [JsonPropertyName("status")]
        [JsonConverter(typeof(JsonStringEnumConverter))]
        public ContentStatus Status { get; set; }

        /// <summary>
        /// Title of the whiteboard.
        /// </summary>

        [JsonPropertyName("title")]
        public string Title { get; set; }

        /// <summary>
        /// ID of the parent content, or null if there is no parent content.
        /// </summary>

        [JsonPropertyName("parentId")]
        public string ParentId { get; set; }

        [JsonPropertyName("parentType")]
        [JsonConverter(typeof(JsonStringEnumConverter))]
        public ParentContentType ParentType { get; set; }

        /// <summary>
        /// Position of the whiteboard within the given parent page tree.
        /// </summary>

        [JsonPropertyName("position")]
        public int? Position { get; set; }

        /// <summary>
        /// The account ID of the user who created this whiteboard originally.
        /// </summary>

        [JsonPropertyName("authorId")]
        public string AuthorId { get; set; }

        /// <summary>
        /// The account ID of the user who owns this whiteboard.
        /// </summary>

        [JsonPropertyName("ownerId")]
        public string OwnerId { get; set; }

        /// <summary>
        /// Date and time when the whiteboard was created. In format "YYYY-MM-DDTHH:mm:ss.sssZ".
        /// </summary>

        [JsonPropertyName("createdAt")]
        public System.DateTimeOffset CreatedAt { get; set; }

        [JsonPropertyName("version")]
        public Version Version { get; set; }

        [JsonPropertyName("_links")]
        public WhiteboardLinks _links { get; set; }

        private IDictionary<string, object> _additionalProperties;

        [JsonExtensionData]
        public IDictionary<string, object> AdditionalProperties
        {
            get { return _additionalProperties ?? (_additionalProperties = new Dictionary<string, object>()); }
            set { _additionalProperties = value; }
        }

    }

    [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "14.0.7.0 (NJsonSchema v11.0.0.0 (Newtonsoft.Json v13.0.0.0))")]
    public partial class DatabaseSingle
    {
        /// <summary>
        /// ID of the database.
        /// </summary>

        [JsonPropertyName("id")]
        public string Id { get; set; }

        /// <summary>
        /// The content type of the object.
        /// </summary>

        [JsonPropertyName("type")]
        public string Type { get; set; }

        [JsonPropertyName("status")]
        [JsonConverter(typeof(JsonStringEnumConverter))]
        public ContentStatus Status { get; set; }

        /// <summary>
        /// Title of the database.
        /// </summary>

        [JsonPropertyName("title")]
        public string Title { get; set; }

        /// <summary>
        /// ID of the parent content, or null if there is no parent content.
        /// </summary>

        [JsonPropertyName("parentId")]
        public string ParentId { get; set; }

        [JsonPropertyName("parentType")]
        [JsonConverter(typeof(JsonStringEnumConverter))]
        public ParentContentType ParentType { get; set; }

        /// <summary>
        /// Position of the database within the given parent page tree.
        /// </summary>

        [JsonPropertyName("position")]
        public int? Position { get; set; }

        /// <summary>
        /// The account ID of the user who created this database originally.
        /// </summary>

        [JsonPropertyName("authorId")]
        public string AuthorId { get; set; }

        /// <summary>
        /// The account ID of the user who owns this database.
        /// </summary>

        [JsonPropertyName("ownerId")]
        public string OwnerId { get; set; }

        /// <summary>
        /// Date and time when the database was created. In format "YYYY-MM-DDTHH:mm:ss.sssZ".
        /// </summary>

        [JsonPropertyName("createdAt")]
        public System.DateTimeOffset CreatedAt { get; set; }

        [JsonPropertyName("version")]
        public Version Version { get; set; }

        [JsonPropertyName("_links")]
        public DatabaseLinks _links { get; set; }

        private IDictionary<string, object> _additionalProperties;

        [JsonExtensionData]
        public IDictionary<string, object> AdditionalProperties
        {
            get { return _additionalProperties ?? (_additionalProperties = new Dictionary<string, object>()); }
            set { _additionalProperties = value; }
        }

    }

    [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "14.0.7.0 (NJsonSchema v11.0.0.0 (Newtonsoft.Json v13.0.0.0))")]
    public partial class SmartLinkSingle
    {
        /// <summary>
        /// ID of the Smart Link in the content tree.
        /// </summary>

        [JsonPropertyName("id")]
        public string Id { get; set; }

        /// <summary>
        /// The content type of the object.
        /// </summary>

        [JsonPropertyName("type")]
        public string Type { get; set; }

        [JsonPropertyName("status")]
        [JsonConverter(typeof(JsonStringEnumConverter))]
        public ContentStatus Status { get; set; }

        /// <summary>
        /// Title of the Smart Link in the content tree.
        /// </summary>

        [JsonPropertyName("title")]
        public string Title { get; set; }

        /// <summary>
        /// ID of the parent content, or null if there is no parent content.
        /// </summary>

        [JsonPropertyName("parentId")]
        public string ParentId { get; set; }

        [JsonPropertyName("parentType")]
        [JsonConverter(typeof(JsonStringEnumConverter))]
        public ParentContentType ParentType { get; set; }

        /// <summary>
        /// Position of the Smart Link within the given parent page tree.
        /// </summary>

        [JsonPropertyName("position")]
        public int? Position { get; set; }

        /// <summary>
        /// The account ID of the user who created this Smart Link in the content tree originally.
        /// </summary>

        [JsonPropertyName("authorId")]
        public string AuthorId { get; set; }

        /// <summary>
        /// The account ID of the user who owns this Smart Link in the content tree.
        /// </summary>

        [JsonPropertyName("ownerId")]
        public string OwnerId { get; set; }

        /// <summary>
        /// Date and time when the Smart Link in the content tree was created. In format "YYYY-MM-DDTHH:mm:ss.sssZ".
        /// </summary>

        [JsonPropertyName("createdAt")]
        public System.DateTimeOffset CreatedAt { get; set; }

        [JsonPropertyName("version")]
        public Version Version { get; set; }

        [JsonPropertyName("_links")]
        public SmartLinkLinks _links { get; set; }

        private IDictionary<string, object> _additionalProperties;

        [JsonExtensionData]
        public IDictionary<string, object> AdditionalProperties
        {
            get { return _additionalProperties ?? (_additionalProperties = new Dictionary<string, object>()); }
            set { _additionalProperties = value; }
        }

    }

    [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "14.0.7.0 (NJsonSchema v11.0.0.0 (Newtonsoft.Json v13.0.0.0))")]
    public partial class Ancestor
    {
        /// <summary>
        /// ID of the ancestor
        /// </summary>

        [JsonPropertyName("id")]
        public string Id { get; set; }

        [JsonPropertyName("type")]
        [JsonConverter(typeof(JsonStringEnumConverter))]
        public AncestorType Type { get; set; }

        private IDictionary<string, object> _additionalProperties;

        [JsonExtensionData]
        public IDictionary<string, object> AdditionalProperties
        {
            get { return _additionalProperties ?? (_additionalProperties = new Dictionary<string, object>()); }
            set { _additionalProperties = value; }
        }

    }

    /// <summary>
    /// The type of ancestor.
    /// </summary>
    [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "14.0.7.0 (NJsonSchema v11.0.0.0 (Newtonsoft.Json v13.0.0.0))")]
    public enum AncestorType
    {

        [System.Runtime.Serialization.EnumMember(Value = @"page")]
        Page = 0,

        [System.Runtime.Serialization.EnumMember(Value = @"whiteboard")]
        Whiteboard = 1,

        [System.Runtime.Serialization.EnumMember(Value = @"database")]
        Database = 2,

        [System.Runtime.Serialization.EnumMember(Value = @"embed")]
        Embed = 3,

    }

    [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "14.0.7.0 (NJsonSchema v11.0.0.0 (Newtonsoft.Json v13.0.0.0))")]
    public partial class SpaceSingle
    {
        /// <summary>
        /// ID of the space.
        /// </summary>

        [JsonPropertyName("id")]
        public string Id { get; set; }

        /// <summary>
        /// Key of the space.
        /// </summary>

        [JsonPropertyName("key")]
        public string Key { get; set; }

        /// <summary>
        /// Name of the space.
        /// </summary>

        [JsonPropertyName("name")]
        public string Name { get; set; }

        [JsonPropertyName("type")]
        [JsonConverter(typeof(JsonStringEnumConverter))]
        public SpaceType Type { get; set; }

        [JsonPropertyName("status")]
        [JsonConverter(typeof(JsonStringEnumConverter))]
        public SpaceStatus Status { get; set; }

        /// <summary>
        /// The account ID of the user who created this space originally.
        /// </summary>

        [JsonPropertyName("authorId")]
        public string AuthorId { get; set; }

        /// <summary>
        /// Date and time when the space was created. In format "YYYY-MM-DDTHH:mm:ss.sssZ".
        /// </summary>

        [JsonPropertyName("createdAt")]
        public System.DateTimeOffset CreatedAt { get; set; }

        /// <summary>
        /// ID of the space's homepage.
        /// </summary>

        [JsonPropertyName("homepageId")]
        public string HomepageId { get; set; }

        [JsonPropertyName("description")]
        public SpaceDescription Description { get; set; }

        [JsonPropertyName("icon")]
        public SpaceIcon Icon { get; set; }

        [JsonPropertyName("labels")]
        public Labels5 Labels { get; set; }

        [JsonPropertyName("properties")]
        public Properties5 Properties { get; set; }

        [JsonPropertyName("operations")]
        public Operations5 Operations { get; set; }

        [JsonPropertyName("permissions")]
        public Permissions Permissions { get; set; }

        [JsonPropertyName("_links")]
        public SpaceLinks _links { get; set; }

        private IDictionary<string, object> _additionalProperties;

        [JsonExtensionData]
        public IDictionary<string, object> AdditionalProperties
        {
            get { return _additionalProperties ?? (_additionalProperties = new Dictionary<string, object>()); }
            set { _additionalProperties = value; }
        }

    }

    [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "14.0.7.0 (NJsonSchema v11.0.0.0 (Newtonsoft.Json v13.0.0.0))")]
    public partial class SpaceBulk
    {
        /// <summary>
        /// ID of the space.
        /// </summary>

        [JsonPropertyName("id")]
        public string Id { get; set; }

        /// <summary>
        /// Key of the space.
        /// </summary>

        [JsonPropertyName("key")]
        public string Key { get; set; }

        /// <summary>
        /// Name of the space.
        /// </summary>

        [JsonPropertyName("name")]
        public string Name { get; set; }

        [JsonPropertyName("type")]
        [JsonConverter(typeof(JsonStringEnumConverter))]
        public SpaceType Type { get; set; }

        [JsonPropertyName("status")]
        [JsonConverter(typeof(JsonStringEnumConverter))]
        public SpaceStatus Status { get; set; }

        /// <summary>
        /// The account ID of the user who created this space originally.
        /// </summary>

        [JsonPropertyName("authorId")]
        public string AuthorId { get; set; }

        /// <summary>
        /// Date and time when the space was created. In format "YYYY-MM-DDTHH:mm:ss.sssZ".
        /// </summary>

        [JsonPropertyName("createdAt")]
        public System.DateTimeOffset CreatedAt { get; set; }

        /// <summary>
        /// ID of the space's homepage.
        /// </summary>

        [JsonPropertyName("homepageId")]
        public string HomepageId { get; set; }

        [JsonPropertyName("description")]
        public SpaceDescription Description { get; set; }

        [JsonPropertyName("icon")]
        public SpaceIcon Icon { get; set; }

        [JsonPropertyName("_links")]
        public SpaceLinks _links { get; set; }

        private IDictionary<string, object> _additionalProperties;

        [JsonExtensionData]
        public IDictionary<string, object> AdditionalProperties
        {
            get { return _additionalProperties ?? (_additionalProperties = new Dictionary<string, object>()); }
            set { _additionalProperties = value; }
        }

    }

    /// <summary>
    /// Contains fields for each representation type requested.
    /// </summary>
    [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "14.0.7.0 (NJsonSchema v11.0.0.0 (Newtonsoft.Json v13.0.0.0))")]
    public partial class SpaceDescription
    {

        [JsonPropertyName("plain")]
        public BodyType Plain { get; set; }

        [JsonPropertyName("view")]
        public BodyType View { get; set; }

        private IDictionary<string, object> _additionalProperties;

        [JsonExtensionData]
        public IDictionary<string, object> AdditionalProperties
        {
            get { return _additionalProperties ?? (_additionalProperties = new Dictionary<string, object>()); }
            set { _additionalProperties = value; }
        }

    }

    /// <summary>
    /// The icon of the space
    /// </summary>
    [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "14.0.7.0 (NJsonSchema v11.0.0.0 (Newtonsoft.Json v13.0.0.0))")]
    public partial class SpaceIcon
    {
        /// <summary>
        /// The path (relative to base URL) at which the space's icon can be retrieved. The format should be like `/wiki/download/...` or `/wiki/aa-avatar/...`
        /// </summary>

        [JsonPropertyName("path")]
        public string Path { get; set; }

        /// <summary>
        /// The path (relative to base URL) that can be used to retrieve a link to download the space icon. 3LO apps should use this link instead of the value provided
        /// <br/>in the `path` property to retrieve the icon.
        /// <br/>
        /// <br/>Currently this field is only returned for `global` spaces and not `personal` spaces.
        /// <br/>
        /// </summary>

        [JsonPropertyName("apiDownloadLink")]
        public string ApiDownloadLink { get; set; }

        private IDictionary<string, object> _additionalProperties;

        [JsonExtensionData]
        public IDictionary<string, object> AdditionalProperties
        {
            get { return _additionalProperties ?? (_additionalProperties = new Dictionary<string, object>()); }
            set { _additionalProperties = value; }
        }

    }

    [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "14.0.7.0 (NJsonSchema v11.0.0.0 (Newtonsoft.Json v13.0.0.0))")]
    public partial class SpacePermission
    {
        /// <summary>
        /// ID of the space permission.
        /// </summary>

        [JsonPropertyName("id")]
        public string Id { get; set; }

        /// <summary>
        /// The entity the space permissions corresponds to.
        /// </summary>

        [JsonPropertyName("principal")]
        public Principal Principal { get; set; }

        /// <summary>
        /// The operation the space permission corresponds to.
        /// </summary>

        [JsonPropertyName("operation")]
        public Operation2 Operation { get; set; }

        private IDictionary<string, object> _additionalProperties;

        [JsonExtensionData]
        public IDictionary<string, object> AdditionalProperties
        {
            get { return _additionalProperties ?? (_additionalProperties = new Dictionary<string, object>()); }
            set { _additionalProperties = value; }
        }

    }

    [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "14.0.7.0 (NJsonSchema v11.0.0.0 (Newtonsoft.Json v13.0.0.0))")]
    public partial class SpaceProperty
    {
        /// <summary>
        /// ID of the space property.
        /// </summary>

        [JsonPropertyName("id")]
        public string Id { get; set; }

        /// <summary>
        /// Key of the space property.
        /// </summary>

        [JsonPropertyName("key")]
        public string Key { get; set; }

        /// <summary>
        /// Value of the space property.
        /// </summary>

        [JsonPropertyName("value")]
        public object Value { get; set; }

        /// <summary>
        /// RFC3339 compliant date time at which the property was created.
        /// </summary>

        [JsonPropertyName("createdAt")]
        public System.DateTimeOffset CreatedAt { get; set; }

        /// <summary>
        /// Atlassian account ID of the user that created the space property.
        /// </summary>

        [JsonPropertyName("createdBy")]
        public string CreatedBy { get; set; }

        [JsonPropertyName("version")]
        public Version3 Version { get; set; }

        private IDictionary<string, object> _additionalProperties;

        [JsonExtensionData]
        public IDictionary<string, object> AdditionalProperties
        {
            get { return _additionalProperties ?? (_additionalProperties = new Dictionary<string, object>()); }
            set { _additionalProperties = value; }
        }

    }

    [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "14.0.7.0 (NJsonSchema v11.0.0.0 (Newtonsoft.Json v13.0.0.0))")]
    public partial class SpacePropertyCreateRequest
    {
        /// <summary>
        /// Key of the space property
        /// </summary>

        [JsonPropertyName("key")]
        public string Key { get; set; }

        /// <summary>
        /// Value of the space property.
        /// </summary>

        [JsonPropertyName("value")]
        public object Value { get; set; }

        private IDictionary<string, object> _additionalProperties;

        [JsonExtensionData]
        public IDictionary<string, object> AdditionalProperties
        {
            get { return _additionalProperties ?? (_additionalProperties = new Dictionary<string, object>()); }
            set { _additionalProperties = value; }
        }

    }

    [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "14.0.7.0 (NJsonSchema v11.0.0.0 (Newtonsoft.Json v13.0.0.0))")]
    public partial class SpacePropertyUpdateRequest
    {
        /// <summary>
        /// Key of the space property
        /// </summary>

        [JsonPropertyName("key")]
        public string Key { get; set; }

        /// <summary>
        /// Value of the space property.
        /// </summary>

        [JsonPropertyName("value")]
        public object Value { get; set; }

        /// <summary>
        /// New version number and associated message
        /// </summary>

        [JsonPropertyName("version")]
        public Version4 Version { get; set; }

        private IDictionary<string, object> _additionalProperties;

        [JsonExtensionData]
        public IDictionary<string, object> AdditionalProperties
        {
            get { return _additionalProperties ?? (_additionalProperties = new Dictionary<string, object>()); }
            set { _additionalProperties = value; }
        }

    }

    /// <summary>
    /// The type of space.
    /// </summary>
    [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "14.0.7.0 (NJsonSchema v11.0.0.0 (Newtonsoft.Json v13.0.0.0))")]
    public enum SpaceType
    {

        [System.Runtime.Serialization.EnumMember(Value = @"global")]
        Global = 0,

        [System.Runtime.Serialization.EnumMember(Value = @"personal")]
        Personal = 1,

    }

    /// <summary>
    /// The status of the space.
    /// </summary>
    [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "14.0.7.0 (NJsonSchema v11.0.0.0 (Newtonsoft.Json v13.0.0.0))")]
    public enum SpaceStatus
    {

        [System.Runtime.Serialization.EnumMember(Value = @"current")]
        Current = 0,

        [System.Runtime.Serialization.EnumMember(Value = @"archived")]
        Archived = 1,

    }

    [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "14.0.7.0 (NJsonSchema v11.0.0.0 (Newtonsoft.Json v13.0.0.0))")]
    public partial class Task
    {
        /// <summary>
        /// ID of the task.
        /// </summary>

        [JsonPropertyName("id")]
        public string Id { get; set; }

        /// <summary>
        /// Local ID of the task. This ID is local to the corresponding page or blog post.
        /// </summary>

        [JsonPropertyName("localId")]
        public string LocalId { get; set; }

        /// <summary>
        /// ID of the space the task is in.
        /// </summary>

        [JsonPropertyName("spaceId")]
        public string SpaceId { get; set; }

        /// <summary>
        /// ID of the page the task is in.
        /// </summary>

        [JsonPropertyName("pageId")]
        public string PageId { get; set; }

        /// <summary>
        /// ID of the blog post the task is in.
        /// </summary>

        [JsonPropertyName("blogPostId")]
        public string BlogPostId { get; set; }

        /// <summary>
        /// Status of the task.
        /// </summary>

        [JsonPropertyName("status")]
        [JsonConverter(typeof(JsonStringEnumConverter))]
        public TaskStatus Status { get; set; }

        [JsonPropertyName("body")]
        public TaskBodySingle Body { get; set; }

        /// <summary>
        /// Account ID of the user who created this task.
        /// </summary>

        [JsonPropertyName("createdBy")]
        public string CreatedBy { get; set; }

        /// <summary>
        /// Account ID of the user to whom this task is assigned.
        /// </summary>

        [JsonPropertyName("assignedTo")]
        public string AssignedTo { get; set; }

        /// <summary>
        /// Account ID of the user who completed this task.
        /// </summary>

        [JsonPropertyName("completedBy")]
        public string CompletedBy { get; set; }

        /// <summary>
        /// Date and time when the task was created. In format "YYYY-MM-DDTHH:mm:ss.sssZ".
        /// </summary>

        [JsonPropertyName("createdAt")]
        public System.DateTimeOffset CreatedAt { get; set; }

        /// <summary>
        /// Date and time when the task was updated. In format "YYYY-MM-DDTHH:mm:ss.sssZ".
        /// </summary>

        [JsonPropertyName("updatedAt")]
        public System.DateTimeOffset UpdatedAt { get; set; }

        /// <summary>
        /// Date and time when the task is due. In format "YYYY-MM-DDTHH:mm:ss.sssZ".
        /// </summary>

        [JsonPropertyName("dueAt")]
        public System.DateTimeOffset DueAt { get; set; }

        /// <summary>
        /// Date and time when the task was completed. In format "YYYY-MM-DDTHH:mm:ss.sssZ".
        /// </summary>

        [JsonPropertyName("completedAt")]
        public System.DateTimeOffset CompletedAt { get; set; }

        private IDictionary<string, object> _additionalProperties;

        [JsonExtensionData]
        public IDictionary<string, object> AdditionalProperties
        {
            get { return _additionalProperties ?? (_additionalProperties = new Dictionary<string, object>()); }
            set { _additionalProperties = value; }
        }

    }

    [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "14.0.7.0 (NJsonSchema v11.0.0.0 (Newtonsoft.Json v13.0.0.0))")]
    public partial class Version
    {
        /// <summary>
        /// Date and time when the version was created. In format "YYYY-MM-DDTHH:mm:ss.sssZ".
        /// </summary>

        [JsonPropertyName("createdAt")]
        public System.DateTimeOffset CreatedAt { get; set; }

        /// <summary>
        /// Message associated with the current version.
        /// </summary>

        [JsonPropertyName("message")]
        public string Message { get; set; }

        /// <summary>
        /// The version number.
        /// </summary>

        [JsonPropertyName("number")]
        public int Number { get; set; }

        /// <summary>
        /// Describes if this version is a minor version. Email notifications and activity stream updates are not created for minor versions.
        /// </summary>

        [JsonPropertyName("minorEdit")]
        public bool MinorEdit { get; set; }

        /// <summary>
        /// The account ID of the user who created this version.
        /// </summary>

        [JsonPropertyName("authorId")]
        public string AuthorId { get; set; }

        private IDictionary<string, object> _additionalProperties;

        [JsonExtensionData]
        public IDictionary<string, object> AdditionalProperties
        {
            get { return _additionalProperties ?? (_additionalProperties = new Dictionary<string, object>()); }
            set { _additionalProperties = value; }
        }

    }

    [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "14.0.7.0 (NJsonSchema v11.0.0.0 (Newtonsoft.Json v13.0.0.0))")]
    public partial class AttachmentVersion
    {
        /// <summary>
        /// Date and time when the version was created. In format "YYYY-MM-DDTHH:mm:ss.sssZ".
        /// </summary>

        [JsonPropertyName("createdAt")]
        public System.DateTimeOffset CreatedAt { get; set; }

        /// <summary>
        /// Message associated with the current version.
        /// </summary>

        [JsonPropertyName("message")]
        public string Message { get; set; }

        /// <summary>
        /// The version number.
        /// </summary>

        [JsonPropertyName("number")]
        public int Number { get; set; }

        /// <summary>
        /// Describes if this version is a minor version. Email notifications and activity stream updates are not created for minor versions.
        /// </summary>

        [JsonPropertyName("minorEdit")]
        public bool MinorEdit { get; set; }

        /// <summary>
        /// The account ID of the user who created this version.
        /// </summary>

        [JsonPropertyName("authorId")]
        public string AuthorId { get; set; }

        [JsonPropertyName("attachment")]
        public VersionedEntity Attachment { get; set; }

        private IDictionary<string, object> _additionalProperties;

        [JsonExtensionData]
        public IDictionary<string, object> AdditionalProperties
        {
            get { return _additionalProperties ?? (_additionalProperties = new Dictionary<string, object>()); }
            set { _additionalProperties = value; }
        }

    }

    [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "14.0.7.0 (NJsonSchema v11.0.0.0 (Newtonsoft.Json v13.0.0.0))")]
    public partial class BlogPostVersion
    {
        /// <summary>
        /// Date and time when the version was created. In format "YYYY-MM-DDTHH:mm:ss.sssZ".
        /// </summary>

        [JsonPropertyName("createdAt")]
        public System.DateTimeOffset CreatedAt { get; set; }

        /// <summary>
        /// Message associated with the current version.
        /// </summary>

        [JsonPropertyName("message")]
        public string Message { get; set; }

        /// <summary>
        /// The version number.
        /// </summary>

        [JsonPropertyName("number")]
        public int Number { get; set; }

        /// <summary>
        /// Describes if this version is a minor version. Email notifications and activity stream updates are not created for minor versions.
        /// </summary>

        [JsonPropertyName("minorEdit")]
        public bool MinorEdit { get; set; }

        /// <summary>
        /// The account ID of the user who created this version.
        /// </summary>

        [JsonPropertyName("authorId")]
        public string AuthorId { get; set; }

        [JsonPropertyName("blogpost")]
        public VersionedEntity Blogpost { get; set; }

        private IDictionary<string, object> _additionalProperties;

        [JsonExtensionData]
        public IDictionary<string, object> AdditionalProperties
        {
            get { return _additionalProperties ?? (_additionalProperties = new Dictionary<string, object>()); }
            set { _additionalProperties = value; }
        }

    }

    [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "14.0.7.0 (NJsonSchema v11.0.0.0 (Newtonsoft.Json v13.0.0.0))")]
    public partial class PageVersion
    {
        /// <summary>
        /// Date and time when the version was created. In format "YYYY-MM-DDTHH:mm:ss.sssZ".
        /// </summary>

        [JsonPropertyName("createdAt")]
        public System.DateTimeOffset CreatedAt { get; set; }

        /// <summary>
        /// Message associated with the current version.
        /// </summary>

        [JsonPropertyName("message")]
        public string Message { get; set; }

        /// <summary>
        /// The version number.
        /// </summary>

        [JsonPropertyName("number")]
        public int Number { get; set; }

        /// <summary>
        /// Describes if this version is a minor version. Email notifications and activity stream updates are not created for minor versions.
        /// </summary>

        [JsonPropertyName("minorEdit")]
        public bool MinorEdit { get; set; }

        /// <summary>
        /// The account ID of the user who created this version.
        /// </summary>

        [JsonPropertyName("authorId")]
        public string AuthorId { get; set; }

        [JsonPropertyName("page")]
        public VersionedEntity Page { get; set; }

        private IDictionary<string, object> _additionalProperties;

        [JsonExtensionData]
        public IDictionary<string, object> AdditionalProperties
        {
            get { return _additionalProperties ?? (_additionalProperties = new Dictionary<string, object>()); }
            set { _additionalProperties = value; }
        }

    }

    [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "14.0.7.0 (NJsonSchema v11.0.0.0 (Newtonsoft.Json v13.0.0.0))")]
    public partial class CustomContentVersion
    {
        /// <summary>
        /// Date and time when the version was created. In format "YYYY-MM-DDTHH:mm:ss.sssZ".
        /// </summary>

        [JsonPropertyName("createdAt")]
        public System.DateTimeOffset CreatedAt { get; set; }

        /// <summary>
        /// Message associated with the current version.
        /// </summary>

        [JsonPropertyName("message")]
        public string Message { get; set; }

        /// <summary>
        /// The version number.
        /// </summary>

        [JsonPropertyName("number")]
        public int Number { get; set; }

        /// <summary>
        /// Describes if this version is a minor version. Email notifications and activity stream updates are not created for minor versions.
        /// </summary>

        [JsonPropertyName("minorEdit")]
        public bool MinorEdit { get; set; }

        /// <summary>
        /// The account ID of the user who created this version.
        /// </summary>

        [JsonPropertyName("authorId")]
        public string AuthorId { get; set; }

        [JsonPropertyName("custom")]
        public VersionedEntity Custom { get; set; }

        private IDictionary<string, object> _additionalProperties;

        [JsonExtensionData]
        public IDictionary<string, object> AdditionalProperties
        {
            get { return _additionalProperties ?? (_additionalProperties = new Dictionary<string, object>()); }
            set { _additionalProperties = value; }
        }

    }

    [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "14.0.7.0 (NJsonSchema v11.0.0.0 (Newtonsoft.Json v13.0.0.0))")]
    public partial class CommentVersion
    {
        /// <summary>
        /// Date and time when the version was created. In format "YYYY-MM-DDTHH:mm:ss.sssZ".
        /// </summary>

        [JsonPropertyName("createdAt")]
        public System.DateTimeOffset CreatedAt { get; set; }

        /// <summary>
        /// Message associated with the current version.
        /// </summary>

        [JsonPropertyName("message")]
        public string Message { get; set; }

        /// <summary>
        /// The version number.
        /// </summary>

        [JsonPropertyName("number")]
        public int Number { get; set; }

        /// <summary>
        /// Describes if this version is a minor version. Email notifications and activity stream updates are not created for minor versions.
        /// </summary>

        [JsonPropertyName("minorEdit")]
        public bool MinorEdit { get; set; }

        /// <summary>
        /// The account ID of the user who created this version.
        /// </summary>

        [JsonPropertyName("authorId")]
        public string AuthorId { get; set; }

        [JsonPropertyName("comment")]
        public VersionedEntity Comment { get; set; }

        private IDictionary<string, object> _additionalProperties;

        [JsonExtensionData]
        public IDictionary<string, object> AdditionalProperties
        {
            get { return _additionalProperties ?? (_additionalProperties = new Dictionary<string, object>()); }
            set { _additionalProperties = value; }
        }

    }

    [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "14.0.7.0 (NJsonSchema v11.0.0.0 (Newtonsoft.Json v13.0.0.0))")]
    public partial class VersionedEntity
    {
        /// <summary>
        /// Title of the entity.
        /// </summary>

        [JsonPropertyName("title")]
        public string Title { get; set; }

        /// <summary>
        /// ID of the entity.
        /// </summary>

        [JsonPropertyName("id")]
        public string Id { get; set; }

        [JsonPropertyName("body")]
        public BodyBulk Body { get; set; }

        private IDictionary<string, object> _additionalProperties;

        [JsonExtensionData]
        public IDictionary<string, object> AdditionalProperties
        {
            get { return _additionalProperties ?? (_additionalProperties = new Dictionary<string, object>()); }
            set { _additionalProperties = value; }
        }

    }

    /// <summary>
    /// The sort fields for attachments. The default sort direction is ascending. To sort in descending order, append a `-` character before the sort field. For example, `fieldName` or `-fieldName`.
    /// </summary>
    [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "14.0.7.0 (NJsonSchema v11.0.0.0 (Newtonsoft.Json v13.0.0.0))")]
    public enum AttachmentSortOrder
    {

        [System.Runtime.Serialization.EnumMember(Value = @"created-date")]
        CreatedDate = 0,

        [System.Runtime.Serialization.EnumMember(Value = @"-created-date")]
        MinuscreatedDate = 1,

        [System.Runtime.Serialization.EnumMember(Value = @"modified-date")]
        ModifiedDate = 2,

        [System.Runtime.Serialization.EnumMember(Value = @"-modified-date")]
        MinusmodifiedDate = 3,

    }

    /// <summary>
    /// The sort fields for blog posts. The default sort direction is ascending. To sort in descending order, append a `-` character before the sort field. For example, `fieldName` or `-fieldName`.
    /// </summary>
    [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "14.0.7.0 (NJsonSchema v11.0.0.0 (Newtonsoft.Json v13.0.0.0))")]
    public enum BlogPostSortOrder
    {

        [System.Runtime.Serialization.EnumMember(Value = @"id")]
        Id = 0,

        [System.Runtime.Serialization.EnumMember(Value = @"-id")]
        Minusid = 1,

        [System.Runtime.Serialization.EnumMember(Value = @"created-date")]
        CreatedDate = 2,

        [System.Runtime.Serialization.EnumMember(Value = @"-created-date")]
        MinuscreatedDate = 3,

        [System.Runtime.Serialization.EnumMember(Value = @"modified-date")]
        ModifiedDate = 4,

        [System.Runtime.Serialization.EnumMember(Value = @"-modified-date")]
        MinusmodifiedDate = 5,

    }

    /// <summary>
    /// The sort fields for comments. The default sort direction is ascending. To sort in descending order, append a `-` character before the sort field. For example, `fieldName` or `-fieldName`.
    /// </summary>
    [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "14.0.7.0 (NJsonSchema v11.0.0.0 (Newtonsoft.Json v13.0.0.0))")]
    public enum CommentSortOrder
    {

        [System.Runtime.Serialization.EnumMember(Value = @"created-date")]
        CreatedDate = 0,

        [System.Runtime.Serialization.EnumMember(Value = @"-created-date")]
        MinuscreatedDate = 1,

        [System.Runtime.Serialization.EnumMember(Value = @"modified-date")]
        ModifiedDate = 2,

        [System.Runtime.Serialization.EnumMember(Value = @"-modified-date")]
        MinusmodifiedDate = 3,

    }

    /// <summary>
    /// The sort fields for content properties. The default sort direction is ascending. To sort in descending order, append a `-` character before the sort field. For example, `fieldName` or `-fieldName`.
    /// </summary>
    [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "14.0.7.0 (NJsonSchema v11.0.0.0 (Newtonsoft.Json v13.0.0.0))")]
    public enum ContentPropertySortOrder
    {

        [System.Runtime.Serialization.EnumMember(Value = @"key")]
        Key = 0,

        [System.Runtime.Serialization.EnumMember(Value = @"-key")]
        Minuskey = 1,

    }

    /// <summary>
    /// The sort fields for labels. The default sort direction is ascending. To sort in descending order, append a `-` character before the sort field. For example, `fieldName` or `-fieldName`.
    /// </summary>
    [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "14.0.7.0 (NJsonSchema v11.0.0.0 (Newtonsoft.Json v13.0.0.0))")]
    public enum LabelSortOrder
    {

        [System.Runtime.Serialization.EnumMember(Value = @"created-date")]
        CreatedDate = 0,

        [System.Runtime.Serialization.EnumMember(Value = @"-created-date")]
        MinuscreatedDate = 1,

        [System.Runtime.Serialization.EnumMember(Value = @"id")]
        Id = 2,

        [System.Runtime.Serialization.EnumMember(Value = @"-id")]
        Minusid = 3,

        [System.Runtime.Serialization.EnumMember(Value = @"name")]
        Name = 4,

        [System.Runtime.Serialization.EnumMember(Value = @"-name")]
        Minusname = 5,

    }

    /// <summary>
    /// The sort fields for child pages. The default sort direction is ascending by child-position. To sort in descending order, append a `-` character before the sort field. For example, `fieldName` or `-fieldName`.
    /// </summary>
    [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "14.0.7.0 (NJsonSchema v11.0.0.0 (Newtonsoft.Json v13.0.0.0))")]
    public enum ChildPageSortOrder
    {

        [System.Runtime.Serialization.EnumMember(Value = @"created-date")]
        CreatedDate = 0,

        [System.Runtime.Serialization.EnumMember(Value = @"-created-date")]
        MinuscreatedDate = 1,

        [System.Runtime.Serialization.EnumMember(Value = @"id")]
        Id = 2,

        [System.Runtime.Serialization.EnumMember(Value = @"-id")]
        Minusid = 3,

        [System.Runtime.Serialization.EnumMember(Value = @"child-position")]
        ChildPosition = 4,

        [System.Runtime.Serialization.EnumMember(Value = @"-child-position")]
        MinuschildPosition = 5,

        [System.Runtime.Serialization.EnumMember(Value = @"modified-date")]
        ModifiedDate = 6,

        [System.Runtime.Serialization.EnumMember(Value = @"-modified-date")]
        MinusmodifiedDate = 7,

    }

    /// <summary>
    /// The sort fields for child custom content. The default sort direction is ascending by id. To sort in descending order, append a `-` character before the sort field. For example, `fieldName` or `-fieldName`.
    /// </summary>
    [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "14.0.7.0 (NJsonSchema v11.0.0.0 (Newtonsoft.Json v13.0.0.0))")]
    public enum ChildCustomContentSortOrder
    {

        [System.Runtime.Serialization.EnumMember(Value = @"created-date")]
        CreatedDate = 0,

        [System.Runtime.Serialization.EnumMember(Value = @"-created-date")]
        MinuscreatedDate = 1,

        [System.Runtime.Serialization.EnumMember(Value = @"id")]
        Id = 2,

        [System.Runtime.Serialization.EnumMember(Value = @"-id")]
        Minusid = 3,

        [System.Runtime.Serialization.EnumMember(Value = @"modified-date")]
        ModifiedDate = 4,

        [System.Runtime.Serialization.EnumMember(Value = @"-modified-date")]
        MinusmodifiedDate = 5,

    }

    /// <summary>
    /// The sort fields for custom content. The default sort direction is ascending. To sort in descending order, append a `-` character before the sort field. For example, `fieldName` or `-fieldName`.
    /// </summary>
    [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "14.0.7.0 (NJsonSchema v11.0.0.0 (Newtonsoft.Json v13.0.0.0))")]
    public enum CustomContentSortOrder
    {

        [System.Runtime.Serialization.EnumMember(Value = @"id")]
        Id = 0,

        [System.Runtime.Serialization.EnumMember(Value = @"-id")]
        Minusid = 1,

        [System.Runtime.Serialization.EnumMember(Value = @"created-date")]
        CreatedDate = 2,

        [System.Runtime.Serialization.EnumMember(Value = @"-created-date")]
        MinuscreatedDate = 3,

        [System.Runtime.Serialization.EnumMember(Value = @"modified-date")]
        ModifiedDate = 4,

        [System.Runtime.Serialization.EnumMember(Value = @"-modified-date")]
        MinusmodifiedDate = 5,

        [System.Runtime.Serialization.EnumMember(Value = @"title")]
        Title = 6,

        [System.Runtime.Serialization.EnumMember(Value = @"-title")]
        Minustitle = 7,

    }

    /// <summary>
    /// The sort fields for pages. The default sort direction is ascending. To sort in descending order, append a `-` character before the sort field. For example, `fieldName` or `-fieldName`.
    /// </summary>
    [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "14.0.7.0 (NJsonSchema v11.0.0.0 (Newtonsoft.Json v13.0.0.0))")]
    public enum PageSortOrder
    {

        [System.Runtime.Serialization.EnumMember(Value = @"id")]
        Id = 0,

        [System.Runtime.Serialization.EnumMember(Value = @"-id")]
        Minusid = 1,

        [System.Runtime.Serialization.EnumMember(Value = @"created-date")]
        CreatedDate = 2,

        [System.Runtime.Serialization.EnumMember(Value = @"-created-date")]
        MinuscreatedDate = 3,

        [System.Runtime.Serialization.EnumMember(Value = @"modified-date")]
        ModifiedDate = 4,

        [System.Runtime.Serialization.EnumMember(Value = @"-modified-date")]
        MinusmodifiedDate = 5,

        [System.Runtime.Serialization.EnumMember(Value = @"title")]
        Title = 6,

        [System.Runtime.Serialization.EnumMember(Value = @"-title")]
        Minustitle = 7,

    }

    /// <summary>
    /// The sort fields for spaces. The default sort direction is ascending. To sort in descending order, append a `-` character before the sort field. For example, `fieldName` or `-fieldName`.
    /// </summary>
    [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "14.0.7.0 (NJsonSchema v11.0.0.0 (Newtonsoft.Json v13.0.0.0))")]
    public enum SpaceSortOrder
    {

        [System.Runtime.Serialization.EnumMember(Value = @"id")]
        Id = 0,

        [System.Runtime.Serialization.EnumMember(Value = @"-id")]
        Minusid = 1,

        [System.Runtime.Serialization.EnumMember(Value = @"key")]
        Key = 2,

        [System.Runtime.Serialization.EnumMember(Value = @"-key")]
        Minuskey = 3,

        [System.Runtime.Serialization.EnumMember(Value = @"name")]
        Name = 4,

        [System.Runtime.Serialization.EnumMember(Value = @"-name")]
        Minusname = 5,

    }

    /// <summary>
    /// The sort fields for versions. The default sort direction is ascending. To sort in descending order, append a `-` character before the sort field. For example, `fieldName` or `-fieldName`.
    /// </summary>
    [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "14.0.7.0 (NJsonSchema v11.0.0.0 (Newtonsoft.Json v13.0.0.0))")]
    public enum VersionSortOrder
    {

        [System.Runtime.Serialization.EnumMember(Value = @"modified-date")]
        ModifiedDate = 0,

        [System.Runtime.Serialization.EnumMember(Value = @"-modified-date")]
        MinusmodifiedDate = 1,

    }

    /// <summary>
    /// Inline comment resolution status
    /// </summary>
    [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "14.0.7.0 (NJsonSchema v11.0.0.0 (Newtonsoft.Json v13.0.0.0))")]
    public enum InlineCommentResolutionStatus
    {

        [System.Runtime.Serialization.EnumMember(Value = @"open")]
        Open = 0,

        [System.Runtime.Serialization.EnumMember(Value = @"reopened")]
        Reopened = 1,

        [System.Runtime.Serialization.EnumMember(Value = @"resolved")]
        Resolved = 2,

        [System.Runtime.Serialization.EnumMember(Value = @"dangling")]
        Dangling = 3,

    }

    [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "14.0.7.0 (NJsonSchema v11.0.0.0 (Newtonsoft.Json v13.0.0.0))")]
    public partial class InlineCommentProperties
    {
        /// <summary>
        /// Property value used to reference the highlighted element in DOM.
        /// </summary>

        [JsonPropertyName("inlineMarkerRef")]
        public string InlineMarkerRef { get; set; }

        /// <summary>
        /// Text that is highlighted.
        /// </summary>

        [JsonPropertyName("inlineOriginalSelection")]
        public string InlineOriginalSelection { get; set; }

        private IDictionary<string, object> _additionalProperties;

        [JsonExtensionData]
        public IDictionary<string, object> AdditionalProperties
        {
            get { return _additionalProperties ?? (_additionalProperties = new Dictionary<string, object>()); }
            set { _additionalProperties = value; }
        }

    }

    [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "14.0.7.0 (NJsonSchema v11.0.0.0 (Newtonsoft.Json v13.0.0.0))")]
    public partial class PageCommentModel
    {
        /// <summary>
        /// ID of the comment.
        /// </summary>

        [JsonPropertyName("id")]
        public string Id { get; set; }

        [JsonPropertyName("status")]
        [JsonConverter(typeof(JsonStringEnumConverter))]
        public ContentStatus Status { get; set; }

        /// <summary>
        /// Title of the comment.
        /// </summary>

        [JsonPropertyName("title")]
        public string Title { get; set; }

        /// <summary>
        /// ID of the page the comment is in.
        /// </summary>

        [JsonPropertyName("pageId")]
        public string PageId { get; set; }

        [JsonPropertyName("version")]
        public Version Version { get; set; }

        [JsonPropertyName("body")]
        public BodyBulk Body { get; set; }

        [JsonPropertyName("_links")]
        public CommentLinks _links { get; set; }

        private IDictionary<string, object> _additionalProperties;

        [JsonExtensionData]
        public IDictionary<string, object> AdditionalProperties
        {
            get { return _additionalProperties ?? (_additionalProperties = new Dictionary<string, object>()); }
            set { _additionalProperties = value; }
        }

    }

    [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "14.0.7.0 (NJsonSchema v11.0.0.0 (Newtonsoft.Json v13.0.0.0))")]
    public partial class PageInlineCommentModel
    {
        /// <summary>
        /// ID of the comment.
        /// </summary>

        [JsonPropertyName("id")]
        public string Id { get; set; }

        [JsonPropertyName("status")]
        [JsonConverter(typeof(JsonStringEnumConverter))]
        public ContentStatus Status { get; set; }

        /// <summary>
        /// Title of the comment.
        /// </summary>

        [JsonPropertyName("title")]
        public string Title { get; set; }

        /// <summary>
        /// ID of the page the comment is in.
        /// </summary>

        [JsonPropertyName("pageId")]
        public string PageId { get; set; }

        [JsonPropertyName("version")]
        public Version Version { get; set; }

        [JsonPropertyName("body")]
        public BodyBulk Body { get; set; }

        [JsonPropertyName("resolutionStatus")]
        [JsonConverter(typeof(JsonStringEnumConverter))]
        public InlineCommentResolutionStatus ResolutionStatus { get; set; }

        [JsonPropertyName("properties")]
        public InlineCommentProperties Properties { get; set; }

        [JsonPropertyName("_links")]
        public CommentLinks _links { get; set; }

        private IDictionary<string, object> _additionalProperties;

        [JsonExtensionData]
        public IDictionary<string, object> AdditionalProperties
        {
            get { return _additionalProperties ?? (_additionalProperties = new Dictionary<string, object>()); }
            set { _additionalProperties = value; }
        }

    }

    [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "14.0.7.0 (NJsonSchema v11.0.0.0 (Newtonsoft.Json v13.0.0.0))")]
    public partial class BlogPostCommentModel
    {
        /// <summary>
        /// ID of the comment.
        /// </summary>

        [JsonPropertyName("id")]
        public string Id { get; set; }

        [JsonPropertyName("status")]
        [JsonConverter(typeof(JsonStringEnumConverter))]
        public ContentStatus Status { get; set; }

        /// <summary>
        /// Title of the comment.
        /// </summary>

        [JsonPropertyName("title")]
        public string Title { get; set; }

        /// <summary>
        /// ID of the blog post the comment is in.
        /// </summary>

        [JsonPropertyName("blogPostId")]
        public string BlogPostId { get; set; }

        [JsonPropertyName("version")]
        public Version Version { get; set; }

        [JsonPropertyName("body")]
        public BodyBulk Body { get; set; }

        [JsonPropertyName("_links")]
        public CommentLinks _links { get; set; }

        private IDictionary<string, object> _additionalProperties;

        [JsonExtensionData]
        public IDictionary<string, object> AdditionalProperties
        {
            get { return _additionalProperties ?? (_additionalProperties = new Dictionary<string, object>()); }
            set { _additionalProperties = value; }
        }

    }

    [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "14.0.7.0 (NJsonSchema v11.0.0.0 (Newtonsoft.Json v13.0.0.0))")]
    public partial class BlogPostInlineCommentModel
    {
        /// <summary>
        /// ID of the comment.
        /// </summary>

        [JsonPropertyName("id")]
        public string Id { get; set; }

        [JsonPropertyName("status")]
        [JsonConverter(typeof(JsonStringEnumConverter))]
        public ContentStatus Status { get; set; }

        /// <summary>
        /// Title of the comment.
        /// </summary>

        [JsonPropertyName("title")]
        public string Title { get; set; }

        /// <summary>
        /// ID of the blog post the comment is in.
        /// </summary>

        [JsonPropertyName("blogPostId")]
        public string BlogPostId { get; set; }

        [JsonPropertyName("version")]
        public Version Version { get; set; }

        [JsonPropertyName("body")]
        public BodyBulk Body { get; set; }

        [JsonPropertyName("resolutionStatus")]
        [JsonConverter(typeof(JsonStringEnumConverter))]
        public InlineCommentResolutionStatus ResolutionStatus { get; set; }

        [JsonPropertyName("properties")]
        public InlineCommentProperties Properties { get; set; }

        [JsonPropertyName("_links")]
        public CommentLinks _links { get; set; }

        private IDictionary<string, object> _additionalProperties;

        [JsonExtensionData]
        public IDictionary<string, object> AdditionalProperties
        {
            get { return _additionalProperties ?? (_additionalProperties = new Dictionary<string, object>()); }
            set { _additionalProperties = value; }
        }

    }

    [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "14.0.7.0 (NJsonSchema v11.0.0.0 (Newtonsoft.Json v13.0.0.0))")]
    public partial class ChildrenCommentModel
    {
        /// <summary>
        /// ID of the comment.
        /// </summary>

        [JsonPropertyName("id")]
        public string Id { get; set; }

        [JsonPropertyName("status")]
        [JsonConverter(typeof(JsonStringEnumConverter))]
        public ContentStatus Status { get; set; }

        /// <summary>
        /// Title of the comment.
        /// </summary>

        [JsonPropertyName("title")]
        public string Title { get; set; }

        /// <summary>
        /// ID of the parent comment the child comment is in.
        /// </summary>

        [JsonPropertyName("parentCommentId")]
        public string ParentCommentId { get; set; }

        [JsonPropertyName("version")]
        public Version Version { get; set; }

        [JsonPropertyName("body")]
        public BodyBulk Body { get; set; }

        [JsonPropertyName("_links")]
        public CommentLinks _links { get; set; }

        private IDictionary<string, object> _additionalProperties;

        [JsonExtensionData]
        public IDictionary<string, object> AdditionalProperties
        {
            get { return _additionalProperties ?? (_additionalProperties = new Dictionary<string, object>()); }
            set { _additionalProperties = value; }
        }

    }

    [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "14.0.7.0 (NJsonSchema v11.0.0.0 (Newtonsoft.Json v13.0.0.0))")]
    public partial class InlineCommentChildrenModel
    {
        /// <summary>
        /// ID of the comment.
        /// </summary>

        [JsonPropertyName("id")]
        public string Id { get; set; }

        [JsonPropertyName("status")]
        [JsonConverter(typeof(JsonStringEnumConverter))]
        public ContentStatus Status { get; set; }

        /// <summary>
        /// Title of the comment.
        /// </summary>

        [JsonPropertyName("title")]
        public string Title { get; set; }

        /// <summary>
        /// ID of the parent comment the child comment is in.
        /// </summary>

        [JsonPropertyName("parentCommentId")]
        public string ParentCommentId { get; set; }

        [JsonPropertyName("version")]
        public Version Version { get; set; }

        [JsonPropertyName("body")]
        public BodyBulk Body { get; set; }

        [JsonPropertyName("resolutionStatus")]
        [JsonConverter(typeof(JsonStringEnumConverter))]
        public InlineCommentResolutionStatus ResolutionStatus { get; set; }

        [JsonPropertyName("properties")]
        public InlineCommentProperties Properties { get; set; }

        [JsonPropertyName("_links")]
        public CommentLinks _links { get; set; }

        private IDictionary<string, object> _additionalProperties;

        [JsonExtensionData]
        public IDictionary<string, object> AdditionalProperties
        {
            get { return _additionalProperties ?? (_additionalProperties = new Dictionary<string, object>()); }
            set { _additionalProperties = value; }
        }

    }

    [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "14.0.7.0 (NJsonSchema v11.0.0.0 (Newtonsoft.Json v13.0.0.0))")]
    public partial class AttachmentCommentModel
    {
        /// <summary>
        /// ID of the comment.
        /// </summary>

        [JsonPropertyName("id")]
        public string Id { get; set; }

        [JsonPropertyName("status")]
        [JsonConverter(typeof(JsonStringEnumConverter))]
        public ContentStatus Status { get; set; }

        /// <summary>
        /// Title of the comment.
        /// </summary>

        [JsonPropertyName("title")]
        public string Title { get; set; }

        /// <summary>
        /// ID of the attachment containing the comment.
        /// </summary>

        [JsonPropertyName("attachmentId")]
        public string AttachmentId { get; set; }

        [JsonPropertyName("version")]
        public Version Version { get; set; }

        [JsonPropertyName("body")]
        public BodySingle Body { get; set; }

        [JsonPropertyName("_links")]
        public CommentLinks _links { get; set; }

        private IDictionary<string, object> _additionalProperties;

        [JsonExtensionData]
        public IDictionary<string, object> AdditionalProperties
        {
            get { return _additionalProperties ?? (_additionalProperties = new Dictionary<string, object>()); }
            set { _additionalProperties = value; }
        }

    }

    [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "14.0.7.0 (NJsonSchema v11.0.0.0 (Newtonsoft.Json v13.0.0.0))")]
    public partial class CustomContentCommentModel
    {
        /// <summary>
        /// ID of the comment.
        /// </summary>

        [JsonPropertyName("id")]
        public string Id { get; set; }

        [JsonPropertyName("status")]
        [JsonConverter(typeof(JsonStringEnumConverter))]
        public ContentStatus Status { get; set; }

        /// <summary>
        /// Title of the comment.
        /// </summary>

        [JsonPropertyName("title")]
        public string Title { get; set; }

        /// <summary>
        /// ID of the custom content containing the comment.
        /// </summary>

        [JsonPropertyName("customContentId")]
        public string CustomContentId { get; set; }

        [JsonPropertyName("version")]
        public Version Version { get; set; }

        [JsonPropertyName("body")]
        public BodySingle Body { get; set; }

        [JsonPropertyName("_links")]
        public CommentLinks _links { get; set; }

        private IDictionary<string, object> _additionalProperties;

        [JsonExtensionData]
        public IDictionary<string, object> AdditionalProperties
        {
            get { return _additionalProperties ?? (_additionalProperties = new Dictionary<string, object>()); }
            set { _additionalProperties = value; }
        }

    }

    [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "14.0.7.0 (NJsonSchema v11.0.0.0 (Newtonsoft.Json v13.0.0.0))")]
    public partial class FooterCommentModel
    {
        /// <summary>
        /// ID of the comment.
        /// </summary>

        [JsonPropertyName("id")]
        public string Id { get; set; }

        [JsonPropertyName("status")]
        [JsonConverter(typeof(JsonStringEnumConverter))]
        public ContentStatus Status { get; set; }

        /// <summary>
        /// Title of the comment.
        /// </summary>

        [JsonPropertyName("title")]
        public string Title { get; set; }

        /// <summary>
        /// ID of the blog post containing the comment if the comment is on a blog post.
        /// </summary>

        [JsonPropertyName("blogPostId")]
        public string BlogPostId { get; set; }

        /// <summary>
        /// ID of the page containing the comment if the comment is on a page.
        /// </summary>

        [JsonPropertyName("pageId")]
        public string PageId { get; set; }

        /// <summary>
        /// ID of the attachment containing the comment if the comment is on an attachment.
        /// </summary>

        [JsonPropertyName("attachmentId")]
        public string AttachmentId { get; set; }

        /// <summary>
        /// ID of the custom content containing the comment if the comment is on a custom content.
        /// </summary>

        [JsonPropertyName("customContentId")]
        public string CustomContentId { get; set; }

        /// <summary>
        /// ID of the parent comment if the comment is a reply.
        /// </summary>

        [JsonPropertyName("parentCommentId")]
        public string ParentCommentId { get; set; }

        [JsonPropertyName("version")]
        public Version Version { get; set; }

        [JsonPropertyName("properties")]
        public Properties6 Properties { get; set; }

        [JsonPropertyName("operations")]
        public Operations6 Operations { get; set; }

        [JsonPropertyName("likes")]
        public Likes3 Likes { get; set; }

        [JsonPropertyName("versions")]
        public Versions5 Versions { get; set; }

        [JsonPropertyName("body")]
        public BodySingle Body { get; set; }

        [JsonPropertyName("_links")]
        public CommentLinks _links { get; set; }

        private IDictionary<string, object> _additionalProperties;

        [JsonExtensionData]
        public IDictionary<string, object> AdditionalProperties
        {
            get { return _additionalProperties ?? (_additionalProperties = new Dictionary<string, object>()); }
            set { _additionalProperties = value; }
        }

    }

    [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "14.0.7.0 (NJsonSchema v11.0.0.0 (Newtonsoft.Json v13.0.0.0))")]
    public partial class InlineCommentModel
    {
        /// <summary>
        /// ID of the comment.
        /// </summary>

        [JsonPropertyName("id")]
        public string Id { get; set; }

        [JsonPropertyName("status")]
        [JsonConverter(typeof(JsonStringEnumConverter))]
        public ContentStatus Status { get; set; }

        /// <summary>
        /// Title of the comment.
        /// </summary>

        [JsonPropertyName("title")]
        public string Title { get; set; }

        /// <summary>
        /// ID of the blog post containing the comment if the comment is on a blog post.
        /// </summary>

        [JsonPropertyName("blogPostId")]
        public string BlogPostId { get; set; }

        /// <summary>
        /// ID of the page containing the comment if the comment is on a page.
        /// </summary>

        [JsonPropertyName("pageId")]
        public string PageId { get; set; }

        /// <summary>
        /// ID of the parent comment if the comment is a reply.
        /// </summary>

        [JsonPropertyName("parentCommentId")]
        public string ParentCommentId { get; set; }

        [JsonPropertyName("version")]
        public Version Version { get; set; }

        [JsonPropertyName("body")]
        public BodySingle Body { get; set; }

        /// <summary>
        /// Atlassian Account ID of last person who modified the resolve state of the comment. Null until comment is resolved or reopened.
        /// </summary>

        [JsonPropertyName("resolutionLastModifierId")]
        public string ResolutionLastModifierId { get; set; }

        /// <summary>
        /// Timestamp of the last modification to the comment's resolution status. Null until comment is resolved or reopened.
        /// </summary>

        [JsonPropertyName("resolutionLastModifiedAt")]
        public System.DateTimeOffset ResolutionLastModifiedAt { get; set; }

        [JsonPropertyName("resolutionStatus")]
        [JsonConverter(typeof(JsonStringEnumConverter))]
        public InlineCommentResolutionStatus ResolutionStatus { get; set; }

        [JsonPropertyName("properties")]
        public Properties7 Properties { get; set; }

        [JsonPropertyName("operations")]
        public Operations7 Operations { get; set; }

        [JsonPropertyName("likes")]
        public Likes4 Likes { get; set; }

        [JsonPropertyName("versions")]
        public Versions6 Versions { get; set; }

        [JsonPropertyName("_links")]
        public CommentLinks _links { get; set; }

        private IDictionary<string, object> _additionalProperties;

        [JsonExtensionData]
        public IDictionary<string, object> AdditionalProperties
        {
            get { return _additionalProperties ?? (_additionalProperties = new Dictionary<string, object>()); }
            set { _additionalProperties = value; }
        }

    }

    [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "14.0.7.0 (NJsonSchema v11.0.0.0 (Newtonsoft.Json v13.0.0.0))")]
    public partial class CreateFooterCommentModel
    {
        /// <summary>
        /// ID of the containing blog post, if intending to create a top level footer comment. Do not provide if creating a reply.
        /// </summary>

        [JsonPropertyName("blogPostId")]
        public string BlogPostId { get; set; }

        /// <summary>
        /// ID of the containing page, if intending to create a top level footer comment. Do not provide if creating a reply.
        /// </summary>

        [JsonPropertyName("pageId")]
        public string PageId { get; set; }

        /// <summary>
        /// ID of the parent comment, if intending to create a reply. Do not provide if creating a top level comment.
        /// </summary>

        [JsonPropertyName("parentCommentId")]
        public string ParentCommentId { get; set; }

        /// <summary>
        /// ID of the attachment, if intending to create a comment against an attachment.
        /// </summary>

        [JsonPropertyName("attachmentId")]
        public string AttachmentId { get; set; }

        /// <summary>
        /// ID of the custom content, if intending to create a comment against a custom content.
        /// </summary>

        [JsonPropertyName("customContentId")]
        public string CustomContentId { get; set; }

        [JsonPropertyName("body")]
        public CommentBodyWrite Body { get; set; }

        private IDictionary<string, object> _additionalProperties;

        [JsonExtensionData]
        public IDictionary<string, object> AdditionalProperties
        {
            get { return _additionalProperties ?? (_additionalProperties = new Dictionary<string, object>()); }
            set { _additionalProperties = value; }
        }

    }

    [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "14.0.7.0 (NJsonSchema v11.0.0.0 (Newtonsoft.Json v13.0.0.0))")]
    public partial class CreateInlineCommentModel
    {
        /// <summary>
        /// ID of the containing blog post, if intending to create a top level footer comment. Do not provide if creating a reply.
        /// </summary>

        [JsonPropertyName("blogPostId")]
        public string BlogPostId { get; set; }

        /// <summary>
        /// ID of the containing page, if intending to create a top level footer comment. Do not provide if creating a reply.
        /// </summary>

        [JsonPropertyName("pageId")]
        public string PageId { get; set; }

        /// <summary>
        /// ID of the parent comment, if intending to create a reply. Do not provide if creating a top level comment.
        /// </summary>

        [JsonPropertyName("parentCommentId")]
        public string ParentCommentId { get; set; }

        [JsonPropertyName("body")]
        public CommentBodyWrite Body { get; set; }

        /// <summary>
        /// Object describing the text to highlight on the page/blog post. Only applicable for top level inline comments (not replies) and required in that case.
        /// </summary>

        [JsonPropertyName("inlineCommentProperties")]
        public InlineCommentProperties2 InlineCommentProperties { get; set; }

        private IDictionary<string, object> _additionalProperties;

        [JsonExtensionData]
        public IDictionary<string, object> AdditionalProperties
        {
            get { return _additionalProperties ?? (_additionalProperties = new Dictionary<string, object>()); }
            set { _additionalProperties = value; }
        }

    }

    [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "14.0.7.0 (NJsonSchema v11.0.0.0 (Newtonsoft.Json v13.0.0.0))")]
    public partial class UpdateFooterCommentModel
    {

        [JsonPropertyName("version")]
        public Version5 Version { get; set; }

        [JsonPropertyName("body")]
        public CommentBodyWrite Body { get; set; }

        private IDictionary<string, object> _additionalProperties;

        [JsonExtensionData]
        public IDictionary<string, object> AdditionalProperties
        {
            get { return _additionalProperties ?? (_additionalProperties = new Dictionary<string, object>()); }
            set { _additionalProperties = value; }
        }

    }

    [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "14.0.7.0 (NJsonSchema v11.0.0.0 (Newtonsoft.Json v13.0.0.0))")]
    public partial class UpdateInlineCommentModel
    {

        [JsonPropertyName("version")]
        public Version6 Version { get; set; }

        [JsonPropertyName("body")]
        public CommentBodyWrite Body { get; set; }

        /// <summary>
        /// Resolved state of the comment. Set to true to resolve the comment, set to false to reopen it. If
        /// <br/>matching the existing state (i.e. true -&gt; resolved or false -&gt; open/reopened) , no change will occur. A dangling
        /// <br/>comment cannot be updated.
        /// </summary>

        [JsonPropertyName("resolved")]
        public bool Resolved { get; set; }

        private IDictionary<string, object> _additionalProperties;

        [JsonExtensionData]
        public IDictionary<string, object> AdditionalProperties
        {
            get { return _additionalProperties ?? (_additionalProperties = new Dictionary<string, object>()); }
            set { _additionalProperties = value; }
        }

    }

    [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "14.0.7.0 (NJsonSchema v11.0.0.0 (Newtonsoft.Json v13.0.0.0))")]
    public partial class AbstractPageLinks
    {
        /// <summary>
        /// Web UI link of the content.
        /// </summary>

        [JsonPropertyName("webui")]
        public string Webui { get; set; }

        /// <summary>
        /// Edit UI link of the content.
        /// </summary>

        [JsonPropertyName("editui")]
        public string Editui { get; set; }

        /// <summary>
        /// Web UI link of the content.
        /// </summary>

        [JsonPropertyName("tinyui")]
        public string Tinyui { get; set; }

        private IDictionary<string, object> _additionalProperties;

        [JsonExtensionData]
        public IDictionary<string, object> AdditionalProperties
        {
            get { return _additionalProperties ?? (_additionalProperties = new Dictionary<string, object>()); }
            set { _additionalProperties = value; }
        }

    }

    [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "14.0.7.0 (NJsonSchema v11.0.0.0 (Newtonsoft.Json v13.0.0.0))")]
    public partial class AttachmentLinks
    {
        /// <summary>
        /// Web UI link of the content.
        /// </summary>

        [JsonPropertyName("webui")]
        public string Webui { get; set; }

        /// <summary>
        /// Download link of the content.
        /// </summary>

        [JsonPropertyName("download")]
        public string Download { get; set; }

        private IDictionary<string, object> _additionalProperties;

        [JsonExtensionData]
        public IDictionary<string, object> AdditionalProperties
        {
            get { return _additionalProperties ?? (_additionalProperties = new Dictionary<string, object>()); }
            set { _additionalProperties = value; }
        }

    }

    [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "14.0.7.0 (NJsonSchema v11.0.0.0 (Newtonsoft.Json v13.0.0.0))")]
    public partial class CustomContentLinks
    {
        /// <summary>
        /// Web UI link of the content.
        /// </summary>

        [JsonPropertyName("webui")]
        public string Webui { get; set; }

        private IDictionary<string, object> _additionalProperties;

        [JsonExtensionData]
        public IDictionary<string, object> AdditionalProperties
        {
            get { return _additionalProperties ?? (_additionalProperties = new Dictionary<string, object>()); }
            set { _additionalProperties = value; }
        }

    }

    [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "14.0.7.0 (NJsonSchema v11.0.0.0 (Newtonsoft.Json v13.0.0.0))")]
    public partial class CommentLinks
    {
        /// <summary>
        /// Web UI link of the content.
        /// </summary>

        [JsonPropertyName("webui")]
        public string Webui { get; set; }

        private IDictionary<string, object> _additionalProperties;

        [JsonExtensionData]
        public IDictionary<string, object> AdditionalProperties
        {
            get { return _additionalProperties ?? (_additionalProperties = new Dictionary<string, object>()); }
            set { _additionalProperties = value; }
        }

    }

    [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "14.0.7.0 (NJsonSchema v11.0.0.0 (Newtonsoft.Json v13.0.0.0))")]
    public partial class DatabaseLinks
    {
        /// <summary>
        /// Web UI link of the content.
        /// </summary>

        [JsonPropertyName("webui")]
        public string Webui { get; set; }

        private IDictionary<string, object> _additionalProperties;

        [JsonExtensionData]
        public IDictionary<string, object> AdditionalProperties
        {
            get { return _additionalProperties ?? (_additionalProperties = new Dictionary<string, object>()); }
            set { _additionalProperties = value; }
        }

    }

    [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "14.0.7.0 (NJsonSchema v11.0.0.0 (Newtonsoft.Json v13.0.0.0))")]
    public partial class SmartLinkLinks
    {
        /// <summary>
        /// Web UI link of the content.
        /// </summary>

        [JsonPropertyName("webui")]
        public string Webui { get; set; }

        private IDictionary<string, object> _additionalProperties;

        [JsonExtensionData]
        public IDictionary<string, object> AdditionalProperties
        {
            get { return _additionalProperties ?? (_additionalProperties = new Dictionary<string, object>()); }
            set { _additionalProperties = value; }
        }

    }

    [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "14.0.7.0 (NJsonSchema v11.0.0.0 (Newtonsoft.Json v13.0.0.0))")]
    public partial class SpaceLinks
    {
        /// <summary>
        /// Web UI link of the space.
        /// </summary>

        [JsonPropertyName("webui")]
        public string Webui { get; set; }

        private IDictionary<string, object> _additionalProperties;

        [JsonExtensionData]
        public IDictionary<string, object> AdditionalProperties
        {
            get { return _additionalProperties ?? (_additionalProperties = new Dictionary<string, object>()); }
            set { _additionalProperties = value; }
        }

    }

    [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "14.0.7.0 (NJsonSchema v11.0.0.0 (Newtonsoft.Json v13.0.0.0))")]
    public partial class WhiteboardLinks
    {
        /// <summary>
        /// Web UI link of the content.
        /// </summary>

        [JsonPropertyName("webui")]
        public string Webui { get; set; }

        /// <summary>
        /// Edit UI link of the content.
        /// </summary>

        [JsonPropertyName("editui")]
        public string Editui { get; set; }

        private IDictionary<string, object> _additionalProperties;

        [JsonExtensionData]
        public IDictionary<string, object> AdditionalProperties
        {
            get { return _additionalProperties ?? (_additionalProperties = new Dictionary<string, object>()); }
            set { _additionalProperties = value; }
        }

    }

    /// <summary>
    /// Details about data policies.
    /// </summary>
    [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "14.0.7.0 (NJsonSchema v11.0.0.0 (Newtonsoft.Json v13.0.0.0))")]
    public partial class DataPolicyMetadata
    {
        /// <summary>
        /// Whether the workspace contains any content blocked for (inaccessible to) the requesting client application.
        /// </summary>

        [JsonPropertyName("anyContentBlocked")]
        public bool AnyContentBlocked { get; set; }

    }

    [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "14.0.7.0 (NJsonSchema v11.0.0.0 (Newtonsoft.Json v13.0.0.0))")]
    public partial class DataPolicySpace
    {
        /// <summary>
        /// ID of the space.
        /// </summary>

        [JsonPropertyName("id")]
        public string Id { get; set; }

        /// <summary>
        /// Key of the space.
        /// </summary>

        [JsonPropertyName("key")]
        public string Key { get; set; }

        /// <summary>
        /// Name of the space.
        /// </summary>

        [JsonPropertyName("name")]
        public string Name { get; set; }

        [JsonPropertyName("description")]
        public SpaceDescription Description { get; set; }

        [JsonPropertyName("dataPolicy")]
        public DataPolicy DataPolicy { get; set; }

        [JsonPropertyName("icon")]
        public SpaceIcon Icon { get; set; }

        [JsonPropertyName("_links")]
        public SpaceLinks _links { get; set; }

        private IDictionary<string, object> _additionalProperties;

        [JsonExtensionData]
        public IDictionary<string, object> AdditionalProperties
        {
            get { return _additionalProperties ?? (_additionalProperties = new Dictionary<string, object>()); }
            set { _additionalProperties = value; }
        }

    }

    [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "14.0.7.0 (NJsonSchema v11.0.0.0 (Newtonsoft.Json v13.0.0.0))")]
    public partial class OptionalFieldMeta
    {
        /// <summary>
        /// Indicates if there are more available results that can be fetched.
        /// </summary>

        [JsonPropertyName("hasMore")]
        public bool HasMore { get; set; }

        /// <summary>
        /// A token that can be used in the query parameter of the endpoint returned in the `_links` property to retrieve the next set of results.
        /// </summary>

        [JsonPropertyName("cursor")]
        public string Cursor { get; set; }

        private IDictionary<string, object> _additionalProperties;

        [JsonExtensionData]
        public IDictionary<string, object> AdditionalProperties
        {
            get { return _additionalProperties ?? (_additionalProperties = new Dictionary<string, object>()); }
            set { _additionalProperties = value; }
        }

    }

    [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "14.0.7.0 (NJsonSchema v11.0.0.0 (Newtonsoft.Json v13.0.0.0))")]
    public partial class OptionalFieldLinks
    {
        /// <summary>
        /// A relative URL that can be used to fetch results beyond what this include parameter retrieves.
        /// </summary>

        [JsonPropertyName("self")]
        public string Self { get; set; }

        private IDictionary<string, object> _additionalProperties;

        [JsonExtensionData]
        public IDictionary<string, object> AdditionalProperties
        {
            get { return _additionalProperties ?? (_additionalProperties = new Dictionary<string, object>()); }
            set { _additionalProperties = value; }
        }

    }

    [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "14.0.7.0 (NJsonSchema v11.0.0.0 (Newtonsoft.Json v13.0.0.0))")]
    public partial class MultiEntityLinks
    {
        /// <summary>
        /// Used for pagination. Contains the relative URL for the next set of results, using a cursor query parameter.
        /// <br/>This property will not be present if there is no additional data available.
        /// </summary>

        [JsonPropertyName("next")]
        public string Next { get; set; }

        /// <summary>
        /// Base url of the Confluence site.
        /// </summary>

        [JsonPropertyName("base")]
        public string Base { get; set; }

        private IDictionary<string, object> _additionalProperties;

        [JsonExtensionData]
        public IDictionary<string, object> AdditionalProperties
        {
            get { return _additionalProperties ?? (_additionalProperties = new Dictionary<string, object>()); }
            set { _additionalProperties = value; }
        }

    }

    /// <summary>
    /// A unit of [data classification](https://support.atlassian.com/security-and-access-policies/docs/what-is-data-classification/) defined by an organiation. 
    /// <br/>A classification level may be associated with specific storage and handling requirements or expectations.
    /// </summary>
    [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "14.0.7.0 (NJsonSchema v11.0.0.0 (Newtonsoft.Json v13.0.0.0))")]
    public partial class ClassificationLevel
    {
        /// <summary>
        /// The ID of the classification level.
        /// </summary>

        [JsonPropertyName("id")]
        public string Id { get; set; }

        /// <summary>
        /// The status of the classification level.
        /// </summary>

        [JsonPropertyName("status")]
        [JsonConverter(typeof(JsonStringEnumConverter))]
        public ClassificationLevelStatus Status { get; set; }

        /// <summary>
        /// The order of the classification level object.
        /// </summary>

        [JsonPropertyName("order")]
        public double Order { get; set; }

        /// <summary>
        /// The name of the classification level object.
        /// </summary>

        [JsonPropertyName("name")]
        public string Name { get; set; }

        /// <summary>
        /// The description of the classification level object.
        /// </summary>

        [JsonPropertyName("description")]
        public string Description { get; set; }

        /// <summary>
        /// The guideline of the classification level object.
        /// </summary>

        [JsonPropertyName("guideline")]
        public string Guideline { get; set; }

        /// <summary>
        /// The color of the classification level object.
        /// </summary>

        [JsonPropertyName("color")]
        [JsonConverter(typeof(JsonStringEnumConverter))]
        public ClassificationLevelColor Color { get; set; }

        private IDictionary<string, object> _additionalProperties;

        [JsonExtensionData]
        public IDictionary<string, object> AdditionalProperties
        {
            get { return _additionalProperties ?? (_additionalProperties = new Dictionary<string, object>()); }
            set { _additionalProperties = value; }
        }

    }

    [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "14.0.7.0 (NJsonSchema v11.0.0.0 (Newtonsoft.Json v13.0.0.0))")]
    public enum ClassificationLevelColor
    {

        [System.Runtime.Serialization.EnumMember(Value = @"RED")]
        RED = 0,

        [System.Runtime.Serialization.EnumMember(Value = @"RED_BOLD")]
        RED_BOLD = 1,

        [System.Runtime.Serialization.EnumMember(Value = @"ORANGE")]
        ORANGE = 2,

        [System.Runtime.Serialization.EnumMember(Value = @"YELLOW")]
        YELLOW = 3,

        [System.Runtime.Serialization.EnumMember(Value = @"GREEN")]
        GREEN = 4,

        [System.Runtime.Serialization.EnumMember(Value = @"BLUE")]
        BLUE = 5,

        [System.Runtime.Serialization.EnumMember(Value = @"NAVY")]
        NAVY = 6,

        [System.Runtime.Serialization.EnumMember(Value = @"TEAL")]
        TEAL = 7,

        [System.Runtime.Serialization.EnumMember(Value = @"PURPLE")]
        PURPLE = 8,

        [System.Runtime.Serialization.EnumMember(Value = @"GREY")]
        GREY = 9,

        [System.Runtime.Serialization.EnumMember(Value = @"LIME")]
        LIME = 10,

    }

    [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "14.0.7.0 (NJsonSchema v11.0.0.0 (Newtonsoft.Json v13.0.0.0))")]
    public enum ClassificationLevelStatus
    {

        [System.Runtime.Serialization.EnumMember(Value = @"DRAFT")]
        DRAFT = 0,

        [System.Runtime.Serialization.EnumMember(Value = @"PUBLISHED")]
        PUBLISHED = 1,

        [System.Runtime.Serialization.EnumMember(Value = @"ARCHIVED")]
        ARCHIVED = 2,

    }

    [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "14.0.7.0 (NJsonSchema v11.0.0.0 (Newtonsoft.Json v13.0.0.0))")]
    public enum Anonymous
    {

        [System.Runtime.Serialization.EnumMember(Value = @"current")]
        Current = 0,

        [System.Runtime.Serialization.EnumMember(Value = @"archived")]
        Archived = 1,

        [System.Runtime.Serialization.EnumMember(Value = @"trashed")]
        Trashed = 2,

    }

    [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "14.0.7.0 (NJsonSchema v11.0.0.0 (Newtonsoft.Json v13.0.0.0))")]
    public enum Prefix
    {

        [System.Runtime.Serialization.EnumMember(Value = @"my")]
        My = 0,

        [System.Runtime.Serialization.EnumMember(Value = @"team")]
        Team = 1,

        [System.Runtime.Serialization.EnumMember(Value = @"global")]
        Global = 2,

        [System.Runtime.Serialization.EnumMember(Value = @"system")]
        System = 3,

    }

    [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "14.0.7.0 (NJsonSchema v11.0.0.0 (Newtonsoft.Json v13.0.0.0))")]
    public enum Anonymous2
    {

        [System.Runtime.Serialization.EnumMember(Value = @"current")]
        Current = 0,

        [System.Runtime.Serialization.EnumMember(Value = @"deleted")]
        Deleted = 1,

        [System.Runtime.Serialization.EnumMember(Value = @"trashed")]
        Trashed = 2,

    }

    [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "14.0.7.0 (NJsonSchema v11.0.0.0 (Newtonsoft.Json v13.0.0.0))")]
    public enum Anonymous3
    {

        [System.Runtime.Serialization.EnumMember(Value = @"current")]
        Current = 0,

        [System.Runtime.Serialization.EnumMember(Value = @"archived")]
        Archived = 1,

        [System.Runtime.Serialization.EnumMember(Value = @"trashed")]
        Trashed = 2,

    }

    [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "14.0.7.0 (NJsonSchema v11.0.0.0 (Newtonsoft.Json v13.0.0.0))")]
    public enum Prefix2
    {

        [System.Runtime.Serialization.EnumMember(Value = @"my")]
        My = 0,

        [System.Runtime.Serialization.EnumMember(Value = @"team")]
        Team = 1,

        [System.Runtime.Serialization.EnumMember(Value = @"global")]
        Global = 2,

        [System.Runtime.Serialization.EnumMember(Value = @"system")]
        System = 3,

    }

    [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "14.0.7.0 (NJsonSchema v11.0.0.0 (Newtonsoft.Json v13.0.0.0))")]
    public enum Anonymous4
    {

        [System.Runtime.Serialization.EnumMember(Value = @"current")]
        Current = 0,

        [System.Runtime.Serialization.EnumMember(Value = @"archived")]
        Archived = 1,

        [System.Runtime.Serialization.EnumMember(Value = @"trashed")]
        Trashed = 2,

    }

    [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "14.0.7.0 (NJsonSchema v11.0.0.0 (Newtonsoft.Json v13.0.0.0))")]
    public enum Prefix3
    {

        [System.Runtime.Serialization.EnumMember(Value = @"my")]
        My = 0,

        [System.Runtime.Serialization.EnumMember(Value = @"team")]
        Team = 1,

        [System.Runtime.Serialization.EnumMember(Value = @"global")]
        Global = 2,

        [System.Runtime.Serialization.EnumMember(Value = @"system")]
        System = 3,

    }

    [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "14.0.7.0 (NJsonSchema v11.0.0.0 (Newtonsoft.Json v13.0.0.0))")]
    public enum Anonymous5
    {

        [System.Runtime.Serialization.EnumMember(Value = @"current")]
        Current = 0,

        [System.Runtime.Serialization.EnumMember(Value = @"archived")]
        Archived = 1,

        [System.Runtime.Serialization.EnumMember(Value = @"deleted")]
        Deleted = 2,

        [System.Runtime.Serialization.EnumMember(Value = @"trashed")]
        Trashed = 3,

    }

    [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "14.0.7.0 (NJsonSchema v11.0.0.0 (Newtonsoft.Json v13.0.0.0))")]
    public enum Anonymous6
    {

        [System.Runtime.Serialization.EnumMember(Value = @"current")]
        Current = 0,

        [System.Runtime.Serialization.EnumMember(Value = @"archived")]
        Archived = 1,

        [System.Runtime.Serialization.EnumMember(Value = @"trashed")]
        Trashed = 2,

    }

    [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "14.0.7.0 (NJsonSchema v11.0.0.0 (Newtonsoft.Json v13.0.0.0))")]
    public enum Prefix4
    {

        [System.Runtime.Serialization.EnumMember(Value = @"my")]
        My = 0,

        [System.Runtime.Serialization.EnumMember(Value = @"team")]
        Team = 1,

        [System.Runtime.Serialization.EnumMember(Value = @"global")]
        Global = 2,

        [System.Runtime.Serialization.EnumMember(Value = @"system")]
        System = 3,

    }

    [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "14.0.7.0 (NJsonSchema v11.0.0.0 (Newtonsoft.Json v13.0.0.0))")]
    public enum Type
    {

        [System.Runtime.Serialization.EnumMember(Value = @"global")]
        Global = 0,

        [System.Runtime.Serialization.EnumMember(Value = @"personal")]
        Personal = 1,

    }

    [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "14.0.7.0 (NJsonSchema v11.0.0.0 (Newtonsoft.Json v13.0.0.0))")]
    public enum Status
    {

        [System.Runtime.Serialization.EnumMember(Value = @"current")]
        Current = 0,

        [System.Runtime.Serialization.EnumMember(Value = @"archived")]
        Archived = 1,

    }

    [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "14.0.7.0 (NJsonSchema v11.0.0.0 (Newtonsoft.Json v13.0.0.0))")]
    public enum Anonymous7
    {

        [System.Runtime.Serialization.EnumMember(Value = @"current")]
        Current = 0,

        [System.Runtime.Serialization.EnumMember(Value = @"deleted")]
        Deleted = 1,

        [System.Runtime.Serialization.EnumMember(Value = @"trashed")]
        Trashed = 2,

    }

    [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "14.0.7.0 (NJsonSchema v11.0.0.0 (Newtonsoft.Json v13.0.0.0))")]
    public enum Prefix5
    {

        [System.Runtime.Serialization.EnumMember(Value = @"my")]
        My = 0,

        [System.Runtime.Serialization.EnumMember(Value = @"team")]
        Team = 1,

    }

    [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "14.0.7.0 (NJsonSchema v11.0.0.0 (Newtonsoft.Json v13.0.0.0))")]
    public enum Prefix6
    {

        [System.Runtime.Serialization.EnumMember(Value = @"my")]
        My = 0,

        [System.Runtime.Serialization.EnumMember(Value = @"team")]
        Team = 1,

    }

    [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "14.0.7.0 (NJsonSchema v11.0.0.0 (Newtonsoft.Json v13.0.0.0))")]
    public enum Depth
    {

        [System.Runtime.Serialization.EnumMember(Value = @"all")]
        All = 0,

        [System.Runtime.Serialization.EnumMember(Value = @"root")]
        Root = 1,

    }

    [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "14.0.7.0 (NJsonSchema v11.0.0.0 (Newtonsoft.Json v13.0.0.0))")]
    public enum Anonymous8
    {

        [System.Runtime.Serialization.EnumMember(Value = @"current")]
        Current = 0,

        [System.Runtime.Serialization.EnumMember(Value = @"archived")]
        Archived = 1,

        [System.Runtime.Serialization.EnumMember(Value = @"deleted")]
        Deleted = 2,

        [System.Runtime.Serialization.EnumMember(Value = @"trashed")]
        Trashed = 3,

    }

    [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "14.0.7.0 (NJsonSchema v11.0.0.0 (Newtonsoft.Json v13.0.0.0))")]
    public partial class Body : UpdateFooterCommentModel
    {

        [JsonPropertyName("_links")]
        public _links _links { get; set; }

    }

    [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "14.0.7.0 (NJsonSchema v11.0.0.0 (Newtonsoft.Json v13.0.0.0))")]
    public enum Status2
    {

        [System.Runtime.Serialization.EnumMember(Value = @"complete")]
        Complete = 0,

        [System.Runtime.Serialization.EnumMember(Value = @"incomplete")]
        Incomplete = 1,

    }

    [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "14.0.7.0 (NJsonSchema v11.0.0.0 (Newtonsoft.Json v13.0.0.0))")]
    public enum Status3
    {

        [System.Runtime.Serialization.EnumMember(Value = @"current")]
        Current = 0,

        [System.Runtime.Serialization.EnumMember(Value = @"draft")]
        Draft = 1,

        [System.Runtime.Serialization.EnumMember(Value = @"archived")]
        Archived = 2,

    }

    [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "14.0.7.0 (NJsonSchema v11.0.0.0 (Newtonsoft.Json v13.0.0.0))")]
    public enum Status4
    {

        [System.Runtime.Serialization.EnumMember(Value = @"current")]
        Current = 0,

        [System.Runtime.Serialization.EnumMember(Value = @"draft")]
        Draft = 1,

        [System.Runtime.Serialization.EnumMember(Value = @"archived")]
        Archived = 2,

    }

    [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "14.0.7.0 (NJsonSchema v11.0.0.0 (Newtonsoft.Json v13.0.0.0))")]
    public partial class Response
    {

        [JsonPropertyName("results")]
        public ICollection<AttachmentBulk> Results { get; set; }

        [JsonPropertyName("_links")]
        public MultiEntityLinks _links { get; set; }

        private IDictionary<string, object> _additionalProperties;

        [JsonExtensionData]
        public IDictionary<string, object> AdditionalProperties
        {
            get { return _additionalProperties ?? (_additionalProperties = new Dictionary<string, object>()); }
            set { _additionalProperties = value; }
        }

    }

    [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "14.0.7.0 (NJsonSchema v11.0.0.0 (Newtonsoft.Json v13.0.0.0))")]
    public partial class Response2 : AttachmentSingle
    {

        [JsonPropertyName("_links")]
        public _links2 _links { get; set; }

    }

    [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "14.0.7.0 (NJsonSchema v11.0.0.0 (Newtonsoft.Json v13.0.0.0))")]
    public partial class Response3
    {

        [JsonPropertyName("results")]
        public ICollection<Label> Results { get; set; }

        [JsonPropertyName("_links")]
        public MultiEntityLinks _links { get; set; }

        private IDictionary<string, object> _additionalProperties;

        [JsonExtensionData]
        public IDictionary<string, object> AdditionalProperties
        {
            get { return _additionalProperties ?? (_additionalProperties = new Dictionary<string, object>()); }
            set { _additionalProperties = value; }
        }

    }

    [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "14.0.7.0 (NJsonSchema v11.0.0.0 (Newtonsoft.Json v13.0.0.0))")]
    public partial class Response4
    {

        [JsonPropertyName("results")]
        public ICollection<ContentProperty> Results { get; set; }

        [JsonPropertyName("_links")]
        public MultiEntityLinks _links { get; set; }

        private IDictionary<string, object> _additionalProperties;

        [JsonExtensionData]
        public IDictionary<string, object> AdditionalProperties
        {
            get { return _additionalProperties ?? (_additionalProperties = new Dictionary<string, object>()); }
            set { _additionalProperties = value; }
        }

    }

    [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "14.0.7.0 (NJsonSchema v11.0.0.0 (Newtonsoft.Json v13.0.0.0))")]
    public partial class Response5
    {

        [JsonPropertyName("results")]
        public ICollection<AttachmentVersion> Results { get; set; }

        [JsonPropertyName("_links")]
        public MultiEntityLinks _links { get; set; }

        private IDictionary<string, object> _additionalProperties;

        [JsonExtensionData]
        public IDictionary<string, object> AdditionalProperties
        {
            get { return _additionalProperties ?? (_additionalProperties = new Dictionary<string, object>()); }
            set { _additionalProperties = value; }
        }

    }

    [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "14.0.7.0 (NJsonSchema v11.0.0.0 (Newtonsoft.Json v13.0.0.0))")]
    public partial class Response6
    {

        [JsonPropertyName("results")]
        public ICollection<AttachmentCommentModel> Results { get; set; }

        [JsonPropertyName("_links")]
        public MultiEntityLinks _links { get; set; }

        private IDictionary<string, object> _additionalProperties;

        [JsonExtensionData]
        public IDictionary<string, object> AdditionalProperties
        {
            get { return _additionalProperties ?? (_additionalProperties = new Dictionary<string, object>()); }
            set { _additionalProperties = value; }
        }

    }

    [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "14.0.7.0 (NJsonSchema v11.0.0.0 (Newtonsoft.Json v13.0.0.0))")]
    public partial class Response7
    {

        [JsonPropertyName("results")]
        public ICollection<BlogPostBulk> Results { get; set; }

        [JsonPropertyName("_links")]
        public MultiEntityLinks _links { get; set; }

        private IDictionary<string, object> _additionalProperties;

        [JsonExtensionData]
        public IDictionary<string, object> AdditionalProperties
        {
            get { return _additionalProperties ?? (_additionalProperties = new Dictionary<string, object>()); }
            set { _additionalProperties = value; }
        }

    }

    [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "14.0.7.0 (NJsonSchema v11.0.0.0 (Newtonsoft.Json v13.0.0.0))")]
    public partial class Response8 : BlogPostSingle
    {

        [JsonPropertyName("_links")]
        public _links3 _links { get; set; }

    }

    [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "14.0.7.0 (NJsonSchema v11.0.0.0 (Newtonsoft.Json v13.0.0.0))")]
    public partial class Response9 : BlogPostSingle
    {

        [JsonPropertyName("_links")]
        public _links4 _links { get; set; }

    }

    [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "14.0.7.0 (NJsonSchema v11.0.0.0 (Newtonsoft.Json v13.0.0.0))")]
    public partial class Response10 : BlogPostSingle
    {

        [JsonPropertyName("_links")]
        public _links5 _links { get; set; }

    }

    [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "14.0.7.0 (NJsonSchema v11.0.0.0 (Newtonsoft.Json v13.0.0.0))")]
    public partial class Response11
    {

        [JsonPropertyName("results")]
        public ICollection<AttachmentBulk> Results { get; set; }

        [JsonPropertyName("_links")]
        public MultiEntityLinks _links { get; set; }

        private IDictionary<string, object> _additionalProperties;

        [JsonExtensionData]
        public IDictionary<string, object> AdditionalProperties
        {
            get { return _additionalProperties ?? (_additionalProperties = new Dictionary<string, object>()); }
            set { _additionalProperties = value; }
        }

    }

    [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "14.0.7.0 (NJsonSchema v11.0.0.0 (Newtonsoft.Json v13.0.0.0))")]
    public partial class Response12
    {

        [JsonPropertyName("results")]
        public ICollection<CustomContentBulk> Results { get; set; }

        [JsonPropertyName("_links")]
        public MultiEntityLinks _links { get; set; }

        private IDictionary<string, object> _additionalProperties;

        [JsonExtensionData]
        public IDictionary<string, object> AdditionalProperties
        {
            get { return _additionalProperties ?? (_additionalProperties = new Dictionary<string, object>()); }
            set { _additionalProperties = value; }
        }

    }

    [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "14.0.7.0 (NJsonSchema v11.0.0.0 (Newtonsoft.Json v13.0.0.0))")]
    public partial class Response13
    {

        [JsonPropertyName("results")]
        public ICollection<Label> Results { get; set; }

        [JsonPropertyName("_links")]
        public MultiEntityLinks _links { get; set; }

        private IDictionary<string, object> _additionalProperties;

        [JsonExtensionData]
        public IDictionary<string, object> AdditionalProperties
        {
            get { return _additionalProperties ?? (_additionalProperties = new Dictionary<string, object>()); }
            set { _additionalProperties = value; }
        }

    }

    [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "14.0.7.0 (NJsonSchema v11.0.0.0 (Newtonsoft.Json v13.0.0.0))")]
    public partial class Integer
    {
        /// <summary>
        /// The count number
        /// </summary>

        [JsonPropertyName("count")]
        public long Count { get; set; }

        private IDictionary<string, object> _additionalProperties;

        [JsonExtensionData]
        public IDictionary<string, object> AdditionalProperties
        {
            get { return _additionalProperties ?? (_additionalProperties = new Dictionary<string, object>()); }
            set { _additionalProperties = value; }
        }

    }

    [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "14.0.7.0 (NJsonSchema v11.0.0.0 (Newtonsoft.Json v13.0.0.0))")]
    public partial class Response14
    {

        [JsonPropertyName("results")]
        public ICollection<Like> Results { get; set; }

        [JsonPropertyName("_links")]
        public MultiEntityLinks _links { get; set; }

        private IDictionary<string, object> _additionalProperties;

        [JsonExtensionData]
        public IDictionary<string, object> AdditionalProperties
        {
            get { return _additionalProperties ?? (_additionalProperties = new Dictionary<string, object>()); }
            set { _additionalProperties = value; }
        }

    }

    [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "14.0.7.0 (NJsonSchema v11.0.0.0 (Newtonsoft.Json v13.0.0.0))")]
    public partial class Response15
    {

        [JsonPropertyName("results")]
        public ICollection<ContentProperty> Results { get; set; }

        [JsonPropertyName("_links")]
        public MultiEntityLinks _links { get; set; }

        private IDictionary<string, object> _additionalProperties;

        [JsonExtensionData]
        public IDictionary<string, object> AdditionalProperties
        {
            get { return _additionalProperties ?? (_additionalProperties = new Dictionary<string, object>()); }
            set { _additionalProperties = value; }
        }

    }

    [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "14.0.7.0 (NJsonSchema v11.0.0.0 (Newtonsoft.Json v13.0.0.0))")]
    public partial class Response16
    {

        [JsonPropertyName("results")]
        public ICollection<BlogPostVersion> Results { get; set; }

        [JsonPropertyName("_links")]
        public MultiEntityLinks _links { get; set; }

        private IDictionary<string, object> _additionalProperties;

        [JsonExtensionData]
        public IDictionary<string, object> AdditionalProperties
        {
            get { return _additionalProperties ?? (_additionalProperties = new Dictionary<string, object>()); }
            set { _additionalProperties = value; }
        }

    }

    [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "14.0.7.0 (NJsonSchema v11.0.0.0 (Newtonsoft.Json v13.0.0.0))")]
    public partial class Response17
    {

        [JsonPropertyName("results")]
        public ICollection<CustomContentBulk> Results { get; set; }

        [JsonPropertyName("_links")]
        public MultiEntityLinks _links { get; set; }

        private IDictionary<string, object> _additionalProperties;

        [JsonExtensionData]
        public IDictionary<string, object> AdditionalProperties
        {
            get { return _additionalProperties ?? (_additionalProperties = new Dictionary<string, object>()); }
            set { _additionalProperties = value; }
        }

    }

    [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "14.0.7.0 (NJsonSchema v11.0.0.0 (Newtonsoft.Json v13.0.0.0))")]
    public partial class Response18 : CustomContentSingle
    {

        [JsonPropertyName("_links")]
        public _links6 _links { get; set; }

    }

    [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "14.0.7.0 (NJsonSchema v11.0.0.0 (Newtonsoft.Json v13.0.0.0))")]
    public partial class Response19 : CustomContentSingle
    {

        [JsonPropertyName("_links")]
        public _links7 _links { get; set; }

    }

    [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "14.0.7.0 (NJsonSchema v11.0.0.0 (Newtonsoft.Json v13.0.0.0))")]
    public partial class Response20 : CustomContentSingle
    {

        [JsonPropertyName("_links")]
        public _links8 _links { get; set; }

    }

    [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "14.0.7.0 (NJsonSchema v11.0.0.0 (Newtonsoft.Json v13.0.0.0))")]
    public partial class Response21
    {

        [JsonPropertyName("results")]
        public ICollection<AttachmentBulk> Results { get; set; }

        [JsonPropertyName("_links")]
        public MultiEntityLinks _links { get; set; }

        private IDictionary<string, object> _additionalProperties;

        [JsonExtensionData]
        public IDictionary<string, object> AdditionalProperties
        {
            get { return _additionalProperties ?? (_additionalProperties = new Dictionary<string, object>()); }
            set { _additionalProperties = value; }
        }

    }

    [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "14.0.7.0 (NJsonSchema v11.0.0.0 (Newtonsoft.Json v13.0.0.0))")]
    public partial class Response22
    {

        [JsonPropertyName("results")]
        public ICollection<CustomContentCommentModel> Results { get; set; }

        [JsonPropertyName("_links")]
        public MultiEntityLinks _links { get; set; }

        private IDictionary<string, object> _additionalProperties;

        [JsonExtensionData]
        public IDictionary<string, object> AdditionalProperties
        {
            get { return _additionalProperties ?? (_additionalProperties = new Dictionary<string, object>()); }
            set { _additionalProperties = value; }
        }

    }

    [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "14.0.7.0 (NJsonSchema v11.0.0.0 (Newtonsoft.Json v13.0.0.0))")]
    public partial class Response23
    {

        [JsonPropertyName("results")]
        public ICollection<Label> Results { get; set; }

        [JsonPropertyName("_links")]
        public MultiEntityLinks _links { get; set; }

        private IDictionary<string, object> _additionalProperties;

        [JsonExtensionData]
        public IDictionary<string, object> AdditionalProperties
        {
            get { return _additionalProperties ?? (_additionalProperties = new Dictionary<string, object>()); }
            set { _additionalProperties = value; }
        }

    }

    [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "14.0.7.0 (NJsonSchema v11.0.0.0 (Newtonsoft.Json v13.0.0.0))")]
    public partial class Response24
    {

        [JsonPropertyName("results")]
        public ICollection<ContentProperty> Results { get; set; }

        [JsonPropertyName("_links")]
        public MultiEntityLinks _links { get; set; }

        private IDictionary<string, object> _additionalProperties;

        [JsonExtensionData]
        public IDictionary<string, object> AdditionalProperties
        {
            get { return _additionalProperties ?? (_additionalProperties = new Dictionary<string, object>()); }
            set { _additionalProperties = value; }
        }

    }

    [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "14.0.7.0 (NJsonSchema v11.0.0.0 (Newtonsoft.Json v13.0.0.0))")]
    public partial class Response25
    {

        [JsonPropertyName("results")]
        public ICollection<Label> Results { get; set; }

        [JsonPropertyName("_links")]
        public MultiEntityLinks _links { get; set; }

        private IDictionary<string, object> _additionalProperties;

        [JsonExtensionData]
        public IDictionary<string, object> AdditionalProperties
        {
            get { return _additionalProperties ?? (_additionalProperties = new Dictionary<string, object>()); }
            set { _additionalProperties = value; }
        }

    }

    [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "14.0.7.0 (NJsonSchema v11.0.0.0 (Newtonsoft.Json v13.0.0.0))")]
    public partial class Response26
    {

        [JsonPropertyName("results")]
        public ICollection<AttachmentBulk> Results { get; set; }

        [JsonPropertyName("_links")]
        public MultiEntityLinks _links { get; set; }

        private IDictionary<string, object> _additionalProperties;

        [JsonExtensionData]
        public IDictionary<string, object> AdditionalProperties
        {
            get { return _additionalProperties ?? (_additionalProperties = new Dictionary<string, object>()); }
            set { _additionalProperties = value; }
        }

    }

    [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "14.0.7.0 (NJsonSchema v11.0.0.0 (Newtonsoft.Json v13.0.0.0))")]
    public partial class Response27
    {

        [JsonPropertyName("results")]
        public ICollection<BlogPostBulk> Results { get; set; }

        [JsonPropertyName("_links")]
        public MultiEntityLinks _links { get; set; }

        private IDictionary<string, object> _additionalProperties;

        [JsonExtensionData]
        public IDictionary<string, object> AdditionalProperties
        {
            get { return _additionalProperties ?? (_additionalProperties = new Dictionary<string, object>()); }
            set { _additionalProperties = value; }
        }

    }

    [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "14.0.7.0 (NJsonSchema v11.0.0.0 (Newtonsoft.Json v13.0.0.0))")]
    public partial class Response28
    {

        [JsonPropertyName("results")]
        public ICollection<PageBulk> Results { get; set; }

        [JsonPropertyName("_links")]
        public MultiEntityLinks _links { get; set; }

        private IDictionary<string, object> _additionalProperties;

        [JsonExtensionData]
        public IDictionary<string, object> AdditionalProperties
        {
            get { return _additionalProperties ?? (_additionalProperties = new Dictionary<string, object>()); }
            set { _additionalProperties = value; }
        }

    }

    [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "14.0.7.0 (NJsonSchema v11.0.0.0 (Newtonsoft.Json v13.0.0.0))")]
    public partial class Response29
    {

        [JsonPropertyName("results")]
        public ICollection<PageBulk> Results { get; set; }

        [JsonPropertyName("_links")]
        public MultiEntityLinks _links { get; set; }

        private IDictionary<string, object> _additionalProperties;

        [JsonExtensionData]
        public IDictionary<string, object> AdditionalProperties
        {
            get { return _additionalProperties ?? (_additionalProperties = new Dictionary<string, object>()); }
            set { _additionalProperties = value; }
        }

    }

    [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "14.0.7.0 (NJsonSchema v11.0.0.0 (Newtonsoft.Json v13.0.0.0))")]
    public partial class Response30 : PageSingle
    {

        [JsonPropertyName("_links")]
        public _links9 _links { get; set; }

    }

    [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "14.0.7.0 (NJsonSchema v11.0.0.0 (Newtonsoft.Json v13.0.0.0))")]
    public partial class Response31 : PageSingle
    {

        [JsonPropertyName("_links")]
        public _links10 _links { get; set; }

    }

    [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "14.0.7.0 (NJsonSchema v11.0.0.0 (Newtonsoft.Json v13.0.0.0))")]
    public partial class Response32 : PageSingle
    {

        [JsonPropertyName("_links")]
        public _links11 _links { get; set; }

    }

    [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "14.0.7.0 (NJsonSchema v11.0.0.0 (Newtonsoft.Json v13.0.0.0))")]
    public partial class Response33
    {

        [JsonPropertyName("results")]
        public ICollection<AttachmentBulk> Results { get; set; }

        [JsonPropertyName("_links")]
        public MultiEntityLinks _links { get; set; }

        private IDictionary<string, object> _additionalProperties;

        [JsonExtensionData]
        public IDictionary<string, object> AdditionalProperties
        {
            get { return _additionalProperties ?? (_additionalProperties = new Dictionary<string, object>()); }
            set { _additionalProperties = value; }
        }

    }

    [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "14.0.7.0 (NJsonSchema v11.0.0.0 (Newtonsoft.Json v13.0.0.0))")]
    public partial class Response34
    {

        [JsonPropertyName("results")]
        public ICollection<CustomContentBulk> Results { get; set; }

        [JsonPropertyName("_links")]
        public MultiEntityLinks _links { get; set; }

        private IDictionary<string, object> _additionalProperties;

        [JsonExtensionData]
        public IDictionary<string, object> AdditionalProperties
        {
            get { return _additionalProperties ?? (_additionalProperties = new Dictionary<string, object>()); }
            set { _additionalProperties = value; }
        }

    }

    [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "14.0.7.0 (NJsonSchema v11.0.0.0 (Newtonsoft.Json v13.0.0.0))")]
    public partial class Response35
    {

        [JsonPropertyName("results")]
        public ICollection<Label> Results { get; set; }

        [JsonPropertyName("_links")]
        public MultiEntityLinks _links { get; set; }

        private IDictionary<string, object> _additionalProperties;

        [JsonExtensionData]
        public IDictionary<string, object> AdditionalProperties
        {
            get { return _additionalProperties ?? (_additionalProperties = new Dictionary<string, object>()); }
            set { _additionalProperties = value; }
        }

    }

    [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "14.0.7.0 (NJsonSchema v11.0.0.0 (Newtonsoft.Json v13.0.0.0))")]
    public partial class Anonymous9
    {
        /// <summary>
        /// The count number
        /// </summary>

        [JsonPropertyName("count")]
        public long Count { get; set; }

        private IDictionary<string, object> _additionalProperties;

        [JsonExtensionData]
        public IDictionary<string, object> AdditionalProperties
        {
            get { return _additionalProperties ?? (_additionalProperties = new Dictionary<string, object>()); }
            set { _additionalProperties = value; }
        }

    }

    [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "14.0.7.0 (NJsonSchema v11.0.0.0 (Newtonsoft.Json v13.0.0.0))")]
    public partial class Response36
    {

        [JsonPropertyName("results")]
        public ICollection<Like> Results { get; set; }

        [JsonPropertyName("_links")]
        public MultiEntityLinks _links { get; set; }

        private IDictionary<string, object> _additionalProperties;

        [JsonExtensionData]
        public IDictionary<string, object> AdditionalProperties
        {
            get { return _additionalProperties ?? (_additionalProperties = new Dictionary<string, object>()); }
            set { _additionalProperties = value; }
        }

    }

    [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "14.0.7.0 (NJsonSchema v11.0.0.0 (Newtonsoft.Json v13.0.0.0))")]
    public partial class Response37
    {

        [JsonPropertyName("results")]
        public ICollection<ContentProperty> Results { get; set; }

        [JsonPropertyName("_links")]
        public MultiEntityLinks _links { get; set; }

        private IDictionary<string, object> _additionalProperties;

        [JsonExtensionData]
        public IDictionary<string, object> AdditionalProperties
        {
            get { return _additionalProperties ?? (_additionalProperties = new Dictionary<string, object>()); }
            set { _additionalProperties = value; }
        }

    }

    [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "14.0.7.0 (NJsonSchema v11.0.0.0 (Newtonsoft.Json v13.0.0.0))")]
    public partial class Response38
    {

        [JsonPropertyName("results")]
        public ICollection<PageVersion> Results { get; set; }

        [JsonPropertyName("_links")]
        public MultiEntityLinks _links { get; set; }

        private IDictionary<string, object> _additionalProperties;

        [JsonExtensionData]
        public IDictionary<string, object> AdditionalProperties
        {
            get { return _additionalProperties ?? (_additionalProperties = new Dictionary<string, object>()); }
            set { _additionalProperties = value; }
        }

    }

    [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "14.0.7.0 (NJsonSchema v11.0.0.0 (Newtonsoft.Json v13.0.0.0))")]
    public partial class Response39 : WhiteboardSingle
    {

        [JsonPropertyName("_links")]
        public _links12 _links { get; set; }

    }

    [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "14.0.7.0 (NJsonSchema v11.0.0.0 (Newtonsoft.Json v13.0.0.0))")]
    public partial class Response40 : WhiteboardSingle
    {

        [JsonPropertyName("_links")]
        public _links13 _links { get; set; }

    }

    [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "14.0.7.0 (NJsonSchema v11.0.0.0 (Newtonsoft.Json v13.0.0.0))")]
    public partial class Response41
    {

        [JsonPropertyName("results")]
        public ICollection<ContentProperty> Results { get; set; }

        [JsonPropertyName("_links")]
        public MultiEntityLinks _links { get; set; }

        private IDictionary<string, object> _additionalProperties;

        [JsonExtensionData]
        public IDictionary<string, object> AdditionalProperties
        {
            get { return _additionalProperties ?? (_additionalProperties = new Dictionary<string, object>()); }
            set { _additionalProperties = value; }
        }

    }

    [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "14.0.7.0 (NJsonSchema v11.0.0.0 (Newtonsoft.Json v13.0.0.0))")]
    public partial class Response42
    {

        [JsonPropertyName("results")]
        public ICollection<Ancestor> Results { get; set; }

        private IDictionary<string, object> _additionalProperties;

        [JsonExtensionData]
        public IDictionary<string, object> AdditionalProperties
        {
            get { return _additionalProperties ?? (_additionalProperties = new Dictionary<string, object>()); }
            set { _additionalProperties = value; }
        }

    }

    [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "14.0.7.0 (NJsonSchema v11.0.0.0 (Newtonsoft.Json v13.0.0.0))")]
    public partial class Response43 : DatabaseSingle
    {

        [JsonPropertyName("_links")]
        public _links14 _links { get; set; }

    }

    [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "14.0.7.0 (NJsonSchema v11.0.0.0 (Newtonsoft.Json v13.0.0.0))")]
    public partial class Response44 : DatabaseSingle
    {

        [JsonPropertyName("_links")]
        public _links15 _links { get; set; }

    }

    [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "14.0.7.0 (NJsonSchema v11.0.0.0 (Newtonsoft.Json v13.0.0.0))")]
    public partial class Response45
    {

        [JsonPropertyName("results")]
        public ICollection<ContentProperty> Results { get; set; }

        [JsonPropertyName("_links")]
        public MultiEntityLinks _links { get; set; }

        private IDictionary<string, object> _additionalProperties;

        [JsonExtensionData]
        public IDictionary<string, object> AdditionalProperties
        {
            get { return _additionalProperties ?? (_additionalProperties = new Dictionary<string, object>()); }
            set { _additionalProperties = value; }
        }

    }

    [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "14.0.7.0 (NJsonSchema v11.0.0.0 (Newtonsoft.Json v13.0.0.0))")]
    public partial class Response46
    {

        [JsonPropertyName("results")]
        public ICollection<Ancestor> Results { get; set; }

        private IDictionary<string, object> _additionalProperties;

        [JsonExtensionData]
        public IDictionary<string, object> AdditionalProperties
        {
            get { return _additionalProperties ?? (_additionalProperties = new Dictionary<string, object>()); }
            set { _additionalProperties = value; }
        }

    }

    [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "14.0.7.0 (NJsonSchema v11.0.0.0 (Newtonsoft.Json v13.0.0.0))")]
    public partial class Response47 : SmartLinkSingle
    {

        [JsonPropertyName("_links")]
        public _links16 _links { get; set; }

    }

    [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "14.0.7.0 (NJsonSchema v11.0.0.0 (Newtonsoft.Json v13.0.0.0))")]
    public partial class Response48 : SmartLinkSingle
    {

        [JsonPropertyName("_links")]
        public _links17 _links { get; set; }

    }

    [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "14.0.7.0 (NJsonSchema v11.0.0.0 (Newtonsoft.Json v13.0.0.0))")]
    public partial class Response49
    {

        [JsonPropertyName("results")]
        public ICollection<ContentProperty> Results { get; set; }

        [JsonPropertyName("_links")]
        public MultiEntityLinks _links { get; set; }

        private IDictionary<string, object> _additionalProperties;

        [JsonExtensionData]
        public IDictionary<string, object> AdditionalProperties
        {
            get { return _additionalProperties ?? (_additionalProperties = new Dictionary<string, object>()); }
            set { _additionalProperties = value; }
        }

    }

    [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "14.0.7.0 (NJsonSchema v11.0.0.0 (Newtonsoft.Json v13.0.0.0))")]
    public partial class Response50
    {

        [JsonPropertyName("results")]
        public ICollection<Ancestor> Results { get; set; }

        private IDictionary<string, object> _additionalProperties;

        [JsonExtensionData]
        public IDictionary<string, object> AdditionalProperties
        {
            get { return _additionalProperties ?? (_additionalProperties = new Dictionary<string, object>()); }
            set { _additionalProperties = value; }
        }

    }

    [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "14.0.7.0 (NJsonSchema v11.0.0.0 (Newtonsoft.Json v13.0.0.0))")]
    public partial class Response51
    {

        [JsonPropertyName("results")]
        public ICollection<CustomContentVersion> Results { get; set; }

        [JsonPropertyName("_links")]
        public MultiEntityLinks _links { get; set; }

        private IDictionary<string, object> _additionalProperties;

        [JsonExtensionData]
        public IDictionary<string, object> AdditionalProperties
        {
            get { return _additionalProperties ?? (_additionalProperties = new Dictionary<string, object>()); }
            set { _additionalProperties = value; }
        }

    }

    [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "14.0.7.0 (NJsonSchema v11.0.0.0 (Newtonsoft.Json v13.0.0.0))")]
    public partial class Response52
    {

        [JsonPropertyName("results")]
        public ICollection<SpaceBulk> Results { get; set; }

        [JsonPropertyName("_links")]
        public MultiEntityLinks _links { get; set; }

        private IDictionary<string, object> _additionalProperties;

        [JsonExtensionData]
        public IDictionary<string, object> AdditionalProperties
        {
            get { return _additionalProperties ?? (_additionalProperties = new Dictionary<string, object>()); }
            set { _additionalProperties = value; }
        }

    }

    [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "14.0.7.0 (NJsonSchema v11.0.0.0 (Newtonsoft.Json v13.0.0.0))")]
    public partial class Response53 : SpaceSingle
    {

        [JsonPropertyName("_links")]
        public _links18 _links { get; set; }

    }

    [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "14.0.7.0 (NJsonSchema v11.0.0.0 (Newtonsoft.Json v13.0.0.0))")]
    public partial class Response54
    {

        [JsonPropertyName("results")]
        public ICollection<BlogPostBulk> Results { get; set; }

        [JsonPropertyName("_links")]
        public MultiEntityLinks _links { get; set; }

        private IDictionary<string, object> _additionalProperties;

        [JsonExtensionData]
        public IDictionary<string, object> AdditionalProperties
        {
            get { return _additionalProperties ?? (_additionalProperties = new Dictionary<string, object>()); }
            set { _additionalProperties = value; }
        }

    }

    [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "14.0.7.0 (NJsonSchema v11.0.0.0 (Newtonsoft.Json v13.0.0.0))")]
    public partial class Response55
    {

        [JsonPropertyName("results")]
        public ICollection<Label> Results { get; set; }

        [JsonPropertyName("_links")]
        public MultiEntityLinks _links { get; set; }

        private IDictionary<string, object> _additionalProperties;

        [JsonExtensionData]
        public IDictionary<string, object> AdditionalProperties
        {
            get { return _additionalProperties ?? (_additionalProperties = new Dictionary<string, object>()); }
            set { _additionalProperties = value; }
        }

    }

    [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "14.0.7.0 (NJsonSchema v11.0.0.0 (Newtonsoft.Json v13.0.0.0))")]
    public partial class Response56
    {

        [JsonPropertyName("results")]
        public ICollection<Label> Results { get; set; }

        [JsonPropertyName("_links")]
        public MultiEntityLinks _links { get; set; }

        private IDictionary<string, object> _additionalProperties;

        [JsonExtensionData]
        public IDictionary<string, object> AdditionalProperties
        {
            get { return _additionalProperties ?? (_additionalProperties = new Dictionary<string, object>()); }
            set { _additionalProperties = value; }
        }

    }

    [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "14.0.7.0 (NJsonSchema v11.0.0.0 (Newtonsoft.Json v13.0.0.0))")]
    public partial class Response57
    {

        [JsonPropertyName("results")]
        public ICollection<CustomContentBulk> Results { get; set; }

        [JsonPropertyName("_links")]
        public MultiEntityLinks _links { get; set; }

        private IDictionary<string, object> _additionalProperties;

        [JsonExtensionData]
        public IDictionary<string, object> AdditionalProperties
        {
            get { return _additionalProperties ?? (_additionalProperties = new Dictionary<string, object>()); }
            set { _additionalProperties = value; }
        }

    }

    [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "14.0.7.0 (NJsonSchema v11.0.0.0 (Newtonsoft.Json v13.0.0.0))")]
    public partial class Response58
    {

        [JsonPropertyName("results")]
        public ICollection<PageBulk> Results { get; set; }

        [JsonPropertyName("_links")]
        public MultiEntityLinks _links { get; set; }

        private IDictionary<string, object> _additionalProperties;

        [JsonExtensionData]
        public IDictionary<string, object> AdditionalProperties
        {
            get { return _additionalProperties ?? (_additionalProperties = new Dictionary<string, object>()); }
            set { _additionalProperties = value; }
        }

    }

    [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "14.0.7.0 (NJsonSchema v11.0.0.0 (Newtonsoft.Json v13.0.0.0))")]
    public partial class Response59
    {

        [JsonPropertyName("results")]
        public ICollection<SpaceProperty> Results { get; set; }

        [JsonPropertyName("_links")]
        public MultiEntityLinks _links { get; set; }

        private IDictionary<string, object> _additionalProperties;

        [JsonExtensionData]
        public IDictionary<string, object> AdditionalProperties
        {
            get { return _additionalProperties ?? (_additionalProperties = new Dictionary<string, object>()); }
            set { _additionalProperties = value; }
        }

    }

    [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "14.0.7.0 (NJsonSchema v11.0.0.0 (Newtonsoft.Json v13.0.0.0))")]
    public partial class Response60
    {

        [JsonPropertyName("results")]
        public ICollection<SpacePermission> Results { get; set; }

        [JsonPropertyName("_links")]
        public MultiEntityLinks _links { get; set; }

        private IDictionary<string, object> _additionalProperties;

        [JsonExtensionData]
        public IDictionary<string, object> AdditionalProperties
        {
            get { return _additionalProperties ?? (_additionalProperties = new Dictionary<string, object>()); }
            set { _additionalProperties = value; }
        }

    }

    [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "14.0.7.0 (NJsonSchema v11.0.0.0 (Newtonsoft.Json v13.0.0.0))")]
    public partial class Response61
    {

        [JsonPropertyName("results")]
        public ICollection<PageCommentModel> Results { get; set; }

        [JsonPropertyName("_links")]
        public MultiEntityLinks _links { get; set; }

        private IDictionary<string, object> _additionalProperties;

        [JsonExtensionData]
        public IDictionary<string, object> AdditionalProperties
        {
            get { return _additionalProperties ?? (_additionalProperties = new Dictionary<string, object>()); }
            set { _additionalProperties = value; }
        }

    }

    [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "14.0.7.0 (NJsonSchema v11.0.0.0 (Newtonsoft.Json v13.0.0.0))")]
    public partial class Response62
    {

        [JsonPropertyName("results")]
        public ICollection<PageInlineCommentModel> Results { get; set; }

        [JsonPropertyName("_links")]
        public MultiEntityLinks _links { get; set; }

        private IDictionary<string, object> _additionalProperties;

        [JsonExtensionData]
        public IDictionary<string, object> AdditionalProperties
        {
            get { return _additionalProperties ?? (_additionalProperties = new Dictionary<string, object>()); }
            set { _additionalProperties = value; }
        }

    }

    [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "14.0.7.0 (NJsonSchema v11.0.0.0 (Newtonsoft.Json v13.0.0.0))")]
    public partial class Response63
    {

        [JsonPropertyName("results")]
        public ICollection<BlogPostCommentModel> Results { get; set; }

        [JsonPropertyName("_links")]
        public MultiEntityLinks _links { get; set; }

        private IDictionary<string, object> _additionalProperties;

        [JsonExtensionData]
        public IDictionary<string, object> AdditionalProperties
        {
            get { return _additionalProperties ?? (_additionalProperties = new Dictionary<string, object>()); }
            set { _additionalProperties = value; }
        }

    }

    [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "14.0.7.0 (NJsonSchema v11.0.0.0 (Newtonsoft.Json v13.0.0.0))")]
    public partial class Response64
    {

        [JsonPropertyName("results")]
        public ICollection<BlogPostInlineCommentModel> Results { get; set; }

        [JsonPropertyName("_links")]
        public MultiEntityLinks _links { get; set; }

        private IDictionary<string, object> _additionalProperties;

        [JsonExtensionData]
        public IDictionary<string, object> AdditionalProperties
        {
            get { return _additionalProperties ?? (_additionalProperties = new Dictionary<string, object>()); }
            set { _additionalProperties = value; }
        }

    }

    [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "14.0.7.0 (NJsonSchema v11.0.0.0 (Newtonsoft.Json v13.0.0.0))")]
    public partial class Response65
    {

        [JsonPropertyName("results")]
        public ICollection<FooterCommentModel> Results { get; set; }

        [JsonPropertyName("_links")]
        public MultiEntityLinks _links { get; set; }

        private IDictionary<string, object> _additionalProperties;

        [JsonExtensionData]
        public IDictionary<string, object> AdditionalProperties
        {
            get { return _additionalProperties ?? (_additionalProperties = new Dictionary<string, object>()); }
            set { _additionalProperties = value; }
        }

    }

    [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "14.0.7.0 (NJsonSchema v11.0.0.0 (Newtonsoft.Json v13.0.0.0))")]
    public partial class Response66 : FooterCommentModel
    {

        [JsonPropertyName("_links")]
        public _links19 _links { get; set; }

    }

    [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "14.0.7.0 (NJsonSchema v11.0.0.0 (Newtonsoft.Json v13.0.0.0))")]
    public partial class Response67 : FooterCommentModel
    {

        [JsonPropertyName("_links")]
        public _links20 _links { get; set; }

    }

    [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "14.0.7.0 (NJsonSchema v11.0.0.0 (Newtonsoft.Json v13.0.0.0))")]
    public partial class Response68
    {

        [JsonPropertyName("results")]
        public ICollection<ChildrenCommentModel> Results { get; set; }

        [JsonPropertyName("_links")]
        public MultiEntityLinks _links { get; set; }

        private IDictionary<string, object> _additionalProperties;

        [JsonExtensionData]
        public IDictionary<string, object> AdditionalProperties
        {
            get { return _additionalProperties ?? (_additionalProperties = new Dictionary<string, object>()); }
            set { _additionalProperties = value; }
        }

    }

    [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "14.0.7.0 (NJsonSchema v11.0.0.0 (Newtonsoft.Json v13.0.0.0))")]
    public partial class Anonymous10
    {
        /// <summary>
        /// The count number
        /// </summary>

        [JsonPropertyName("count")]
        public long Count { get; set; }

        private IDictionary<string, object> _additionalProperties;

        [JsonExtensionData]
        public IDictionary<string, object> AdditionalProperties
        {
            get { return _additionalProperties ?? (_additionalProperties = new Dictionary<string, object>()); }
            set { _additionalProperties = value; }
        }

    }

    [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "14.0.7.0 (NJsonSchema v11.0.0.0 (Newtonsoft.Json v13.0.0.0))")]
    public partial class Response69
    {

        [JsonPropertyName("results")]
        public ICollection<Like> Results { get; set; }

        [JsonPropertyName("_links")]
        public MultiEntityLinks _links { get; set; }

        private IDictionary<string, object> _additionalProperties;

        [JsonExtensionData]
        public IDictionary<string, object> AdditionalProperties
        {
            get { return _additionalProperties ?? (_additionalProperties = new Dictionary<string, object>()); }
            set { _additionalProperties = value; }
        }

    }

    [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "14.0.7.0 (NJsonSchema v11.0.0.0 (Newtonsoft.Json v13.0.0.0))")]
    public partial class Response70
    {

        [JsonPropertyName("results")]
        public ICollection<CommentVersion> Results { get; set; }

        [JsonPropertyName("_links")]
        public MultiEntityLinks _links { get; set; }

        private IDictionary<string, object> _additionalProperties;

        [JsonExtensionData]
        public IDictionary<string, object> AdditionalProperties
        {
            get { return _additionalProperties ?? (_additionalProperties = new Dictionary<string, object>()); }
            set { _additionalProperties = value; }
        }

    }

    [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "14.0.7.0 (NJsonSchema v11.0.0.0 (Newtonsoft.Json v13.0.0.0))")]
    public partial class Response71
    {

        [JsonPropertyName("results")]
        public ICollection<InlineCommentModel> Results { get; set; }

        [JsonPropertyName("_links")]
        public MultiEntityLinks _links { get; set; }

        private IDictionary<string, object> _additionalProperties;

        [JsonExtensionData]
        public IDictionary<string, object> AdditionalProperties
        {
            get { return _additionalProperties ?? (_additionalProperties = new Dictionary<string, object>()); }
            set { _additionalProperties = value; }
        }

    }

    [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "14.0.7.0 (NJsonSchema v11.0.0.0 (Newtonsoft.Json v13.0.0.0))")]
    public partial class Response72 : InlineCommentModel
    {

        [JsonPropertyName("_links")]
        public _links21 _links { get; set; }

    }

    [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "14.0.7.0 (NJsonSchema v11.0.0.0 (Newtonsoft.Json v13.0.0.0))")]
    public partial class Response73 : InlineCommentModel
    {

        [JsonPropertyName("_links")]
        public _links22 _links { get; set; }

    }

    [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "14.0.7.0 (NJsonSchema v11.0.0.0 (Newtonsoft.Json v13.0.0.0))")]
    public partial class Response74 : InlineCommentModel
    {

        [JsonPropertyName("_links")]
        public _links23 _links { get; set; }

    }

    [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "14.0.7.0 (NJsonSchema v11.0.0.0 (Newtonsoft.Json v13.0.0.0))")]
    public partial class Response75
    {

        [JsonPropertyName("results")]
        public ICollection<InlineCommentChildrenModel> Results { get; set; }

        [JsonPropertyName("_links")]
        public MultiEntityLinks _links { get; set; }

        private IDictionary<string, object> _additionalProperties;

        [JsonExtensionData]
        public IDictionary<string, object> AdditionalProperties
        {
            get { return _additionalProperties ?? (_additionalProperties = new Dictionary<string, object>()); }
            set { _additionalProperties = value; }
        }

    }

    [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "14.0.7.0 (NJsonSchema v11.0.0.0 (Newtonsoft.Json v13.0.0.0))")]
    public partial class Anonymous11
    {
        /// <summary>
        /// The count number
        /// </summary>

        [JsonPropertyName("count")]
        public long Count { get; set; }

        private IDictionary<string, object> _additionalProperties;

        [JsonExtensionData]
        public IDictionary<string, object> AdditionalProperties
        {
            get { return _additionalProperties ?? (_additionalProperties = new Dictionary<string, object>()); }
            set { _additionalProperties = value; }
        }

    }

    [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "14.0.7.0 (NJsonSchema v11.0.0.0 (Newtonsoft.Json v13.0.0.0))")]
    public partial class Response76
    {

        [JsonPropertyName("results")]
        public ICollection<Like> Results { get; set; }

        [JsonPropertyName("_links")]
        public MultiEntityLinks _links { get; set; }

        private IDictionary<string, object> _additionalProperties;

        [JsonExtensionData]
        public IDictionary<string, object> AdditionalProperties
        {
            get { return _additionalProperties ?? (_additionalProperties = new Dictionary<string, object>()); }
            set { _additionalProperties = value; }
        }

    }

    [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "14.0.7.0 (NJsonSchema v11.0.0.0 (Newtonsoft.Json v13.0.0.0))")]
    public partial class Response77
    {

        [JsonPropertyName("results")]
        public ICollection<CommentVersion> Results { get; set; }

        [JsonPropertyName("_links")]
        public MultiEntityLinks _links { get; set; }

        private IDictionary<string, object> _additionalProperties;

        [JsonExtensionData]
        public IDictionary<string, object> AdditionalProperties
        {
            get { return _additionalProperties ?? (_additionalProperties = new Dictionary<string, object>()); }
            set { _additionalProperties = value; }
        }

    }

    [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "14.0.7.0 (NJsonSchema v11.0.0.0 (Newtonsoft.Json v13.0.0.0))")]
    public partial class Response78
    {

        [JsonPropertyName("results")]
        public ICollection<ContentProperty> Results { get; set; }

        [JsonPropertyName("_links")]
        public MultiEntityLinks _links { get; set; }

        private IDictionary<string, object> _additionalProperties;

        [JsonExtensionData]
        public IDictionary<string, object> AdditionalProperties
        {
            get { return _additionalProperties ?? (_additionalProperties = new Dictionary<string, object>()); }
            set { _additionalProperties = value; }
        }

    }

    [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "14.0.7.0 (NJsonSchema v11.0.0.0 (Newtonsoft.Json v13.0.0.0))")]
    public partial class Response79
    {

        [JsonPropertyName("results")]
        public ICollection<Task> Results { get; set; }

        [JsonPropertyName("_links")]
        public MultiEntityLinks _links { get; set; }

        private IDictionary<string, object> _additionalProperties;

        [JsonExtensionData]
        public IDictionary<string, object> AdditionalProperties
        {
            get { return _additionalProperties ?? (_additionalProperties = new Dictionary<string, object>()); }
            set { _additionalProperties = value; }
        }

    }

    [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "14.0.7.0 (NJsonSchema v11.0.0.0 (Newtonsoft.Json v13.0.0.0))")]
    public partial class Response80
    {

        [JsonPropertyName("results")]
        public ICollection<ChildPage> Results { get; set; }

        [JsonPropertyName("_links")]
        public MultiEntityLinks _links { get; set; }

        private IDictionary<string, object> _additionalProperties;

        [JsonExtensionData]
        public IDictionary<string, object> AdditionalProperties
        {
            get { return _additionalProperties ?? (_additionalProperties = new Dictionary<string, object>()); }
            set { _additionalProperties = value; }
        }

    }

    [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "14.0.7.0 (NJsonSchema v11.0.0.0 (Newtonsoft.Json v13.0.0.0))")]
    public partial class Response81
    {

        [JsonPropertyName("results")]
        public ICollection<ChildCustomContent> Results { get; set; }

        [JsonPropertyName("_links")]
        public MultiEntityLinks _links { get; set; }

        private IDictionary<string, object> _additionalProperties;

        [JsonExtensionData]
        public IDictionary<string, object> AdditionalProperties
        {
            get { return _additionalProperties ?? (_additionalProperties = new Dictionary<string, object>()); }
            set { _additionalProperties = value; }
        }

    }

    [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "14.0.7.0 (NJsonSchema v11.0.0.0 (Newtonsoft.Json v13.0.0.0))")]
    public partial class Response82
    {

        [JsonPropertyName("results")]
        public ICollection<Ancestor> Results { get; set; }

        [JsonPropertyName("_links")]
        public MultiEntityLinks _links { get; set; }

        private IDictionary<string, object> _additionalProperties;

        [JsonExtensionData]
        public IDictionary<string, object> AdditionalProperties
        {
            get { return _additionalProperties ?? (_additionalProperties = new Dictionary<string, object>()); }
            set { _additionalProperties = value; }
        }

    }

    [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "14.0.7.0 (NJsonSchema v11.0.0.0 (Newtonsoft.Json v13.0.0.0))")]
    public partial class Response83
    {
        /// <summary>
        /// List of emails that do not have access to site.
        /// </summary>

        [JsonPropertyName("emailsWithoutAccess")]
        public ICollection<string> EmailsWithoutAccess { get; set; }

        /// <summary>
        /// List of invalid emails provided in the request.
        /// </summary>

        [JsonPropertyName("invalidEmails")]
        public ICollection<string> InvalidEmails { get; set; }

        private IDictionary<string, object> _additionalProperties;

        [JsonExtensionData]
        public IDictionary<string, object> AdditionalProperties
        {
            get { return _additionalProperties ?? (_additionalProperties = new Dictionary<string, object>()); }
            set { _additionalProperties = value; }
        }

    }

    [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "14.0.7.0 (NJsonSchema v11.0.0.0 (Newtonsoft.Json v13.0.0.0))")]
    public partial class Response84
    {

        [JsonPropertyName("results")]
        public ICollection<DataPolicySpace> Results { get; set; }

        [JsonPropertyName("_links")]
        public MultiEntityLinks _links { get; set; }

        private IDictionary<string, object> _additionalProperties;

        [JsonExtensionData]
        public IDictionary<string, object> AdditionalProperties
        {
            get { return _additionalProperties ?? (_additionalProperties = new Dictionary<string, object>()); }
            set { _additionalProperties = value; }
        }

    }

    [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "14.0.7.0 (NJsonSchema v11.0.0.0 (Newtonsoft.Json v13.0.0.0))")]
    public partial class Labels
    {

        [JsonPropertyName("results")]
        public ICollection<Label> Results { get; set; }

        [JsonPropertyName("meta")]
        public OptionalFieldMeta Meta { get; set; }

        [JsonPropertyName("_links")]
        public OptionalFieldLinks _links { get; set; }

        private IDictionary<string, object> _additionalProperties;

        [JsonExtensionData]
        public IDictionary<string, object> AdditionalProperties
        {
            get { return _additionalProperties ?? (_additionalProperties = new Dictionary<string, object>()); }
            set { _additionalProperties = value; }
        }

    }

    [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "14.0.7.0 (NJsonSchema v11.0.0.0 (Newtonsoft.Json v13.0.0.0))")]
    public partial class Properties
    {

        [JsonPropertyName("results")]
        public ICollection<ContentProperty> Results { get; set; }

        [JsonPropertyName("meta")]
        public OptionalFieldMeta Meta { get; set; }

        [JsonPropertyName("_links")]
        public OptionalFieldLinks _links { get; set; }

        private IDictionary<string, object> _additionalProperties;

        [JsonExtensionData]
        public IDictionary<string, object> AdditionalProperties
        {
            get { return _additionalProperties ?? (_additionalProperties = new Dictionary<string, object>()); }
            set { _additionalProperties = value; }
        }

    }

    [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "14.0.7.0 (NJsonSchema v11.0.0.0 (Newtonsoft.Json v13.0.0.0))")]
    public partial class Operations
    {

        [JsonPropertyName("results")]
        public ICollection<Operation> Results { get; set; }

        [JsonPropertyName("meta")]
        public OptionalFieldMeta Meta { get; set; }

        [JsonPropertyName("_links")]
        public OptionalFieldLinks _links { get; set; }

        private IDictionary<string, object> _additionalProperties;

        [JsonExtensionData]
        public IDictionary<string, object> AdditionalProperties
        {
            get { return _additionalProperties ?? (_additionalProperties = new Dictionary<string, object>()); }
            set { _additionalProperties = value; }
        }

    }

    [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "14.0.7.0 (NJsonSchema v11.0.0.0 (Newtonsoft.Json v13.0.0.0))")]
    public partial class Versions
    {

        [JsonPropertyName("results")]
        public ICollection<Version> Results { get; set; }

        [JsonPropertyName("meta")]
        public OptionalFieldMeta Meta { get; set; }

        [JsonPropertyName("_links")]
        public OptionalFieldLinks _links { get; set; }

        private IDictionary<string, object> _additionalProperties;

        [JsonExtensionData]
        public IDictionary<string, object> AdditionalProperties
        {
            get { return _additionalProperties ?? (_additionalProperties = new Dictionary<string, object>()); }
            set { _additionalProperties = value; }
        }

    }

    [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "14.0.7.0 (NJsonSchema v11.0.0.0 (Newtonsoft.Json v13.0.0.0))")]
    public partial class Labels2
    {

        [JsonPropertyName("results")]
        public ICollection<Label> Results { get; set; }

        [JsonPropertyName("meta")]
        public OptionalFieldMeta Meta { get; set; }

        [JsonPropertyName("_links")]
        public OptionalFieldLinks _links { get; set; }

        private IDictionary<string, object> _additionalProperties;

        [JsonExtensionData]
        public IDictionary<string, object> AdditionalProperties
        {
            get { return _additionalProperties ?? (_additionalProperties = new Dictionary<string, object>()); }
            set { _additionalProperties = value; }
        }

    }

    [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "14.0.7.0 (NJsonSchema v11.0.0.0 (Newtonsoft.Json v13.0.0.0))")]
    public partial class Properties2
    {

        [JsonPropertyName("results")]
        public ICollection<ContentProperty> Results { get; set; }

        [JsonPropertyName("meta")]
        public OptionalFieldMeta Meta { get; set; }

        [JsonPropertyName("_links")]
        public OptionalFieldLinks _links { get; set; }

        private IDictionary<string, object> _additionalProperties;

        [JsonExtensionData]
        public IDictionary<string, object> AdditionalProperties
        {
            get { return _additionalProperties ?? (_additionalProperties = new Dictionary<string, object>()); }
            set { _additionalProperties = value; }
        }

    }

    [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "14.0.7.0 (NJsonSchema v11.0.0.0 (Newtonsoft.Json v13.0.0.0))")]
    public partial class Operations2
    {

        [JsonPropertyName("results")]
        public ICollection<Operation> Results { get; set; }

        [JsonPropertyName("meta")]
        public OptionalFieldMeta Meta { get; set; }

        [JsonPropertyName("_links")]
        public OptionalFieldLinks _links { get; set; }

        private IDictionary<string, object> _additionalProperties;

        [JsonExtensionData]
        public IDictionary<string, object> AdditionalProperties
        {
            get { return _additionalProperties ?? (_additionalProperties = new Dictionary<string, object>()); }
            set { _additionalProperties = value; }
        }

    }

    [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "14.0.7.0 (NJsonSchema v11.0.0.0 (Newtonsoft.Json v13.0.0.0))")]
    public partial class Likes
    {

        [JsonPropertyName("results")]
        public ICollection<Like> Results { get; set; }

        [JsonPropertyName("meta")]
        public OptionalFieldMeta Meta { get; set; }

        [JsonPropertyName("_links")]
        public OptionalFieldLinks _links { get; set; }

        private IDictionary<string, object> _additionalProperties;

        [JsonExtensionData]
        public IDictionary<string, object> AdditionalProperties
        {
            get { return _additionalProperties ?? (_additionalProperties = new Dictionary<string, object>()); }
            set { _additionalProperties = value; }
        }

    }

    [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "14.0.7.0 (NJsonSchema v11.0.0.0 (Newtonsoft.Json v13.0.0.0))")]
    public partial class Versions2
    {

        [JsonPropertyName("results")]
        public ICollection<Version> Results { get; set; }

        [JsonPropertyName("meta")]
        public OptionalFieldMeta Meta { get; set; }

        [JsonPropertyName("_links")]
        public OptionalFieldLinks _links { get; set; }

        private IDictionary<string, object> _additionalProperties;

        [JsonExtensionData]
        public IDictionary<string, object> AdditionalProperties
        {
            get { return _additionalProperties ?? (_additionalProperties = new Dictionary<string, object>()); }
            set { _additionalProperties = value; }
        }

    }

    [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "14.0.7.0 (NJsonSchema v11.0.0.0 (Newtonsoft.Json v13.0.0.0))")]
    public partial class Anonymous12
    {

        private IDictionary<string, object> _additionalProperties;

        [JsonExtensionData]
        public IDictionary<string, object> AdditionalProperties
        {
            get { return _additionalProperties ?? (_additionalProperties = new Dictionary<string, object>()); }
            set { _additionalProperties = value; }
        }

    }

    [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "14.0.7.0 (NJsonSchema v11.0.0.0 (Newtonsoft.Json v13.0.0.0))")]
    public partial class Version2
    {
        /// <summary>
        /// Version number of the new version. Should be 1 more than the current version number.
        /// </summary>

        [JsonPropertyName("number")]
        public int Number { get; set; }

        /// <summary>
        /// Message to be associated with the new version.
        /// </summary>

        [JsonPropertyName("message")]
        public string Message { get; set; }

        private IDictionary<string, object> _additionalProperties;

        [JsonExtensionData]
        public IDictionary<string, object> AdditionalProperties
        {
            get { return _additionalProperties ?? (_additionalProperties = new Dictionary<string, object>()); }
            set { _additionalProperties = value; }
        }

    }

    [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "14.0.7.0 (NJsonSchema v11.0.0.0 (Newtonsoft.Json v13.0.0.0))")]
    public partial class Labels3
    {

        [JsonPropertyName("results")]
        public ICollection<Label> Results { get; set; }

        [JsonPropertyName("meta")]
        public OptionalFieldMeta Meta { get; set; }

        [JsonPropertyName("_links")]
        public OptionalFieldLinks _links { get; set; }

        private IDictionary<string, object> _additionalProperties;

        [JsonExtensionData]
        public IDictionary<string, object> AdditionalProperties
        {
            get { return _additionalProperties ?? (_additionalProperties = new Dictionary<string, object>()); }
            set { _additionalProperties = value; }
        }

    }

    [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "14.0.7.0 (NJsonSchema v11.0.0.0 (Newtonsoft.Json v13.0.0.0))")]
    public partial class Properties3
    {

        [JsonPropertyName("results")]
        public ICollection<ContentProperty> Results { get; set; }

        [JsonPropertyName("meta")]
        public OptionalFieldMeta Meta { get; set; }

        [JsonPropertyName("_links")]
        public OptionalFieldLinks _links { get; set; }

        private IDictionary<string, object> _additionalProperties;

        [JsonExtensionData]
        public IDictionary<string, object> AdditionalProperties
        {
            get { return _additionalProperties ?? (_additionalProperties = new Dictionary<string, object>()); }
            set { _additionalProperties = value; }
        }

    }

    [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "14.0.7.0 (NJsonSchema v11.0.0.0 (Newtonsoft.Json v13.0.0.0))")]
    public partial class Operations3
    {

        [JsonPropertyName("results")]
        public ICollection<Operation> Results { get; set; }

        [JsonPropertyName("meta")]
        public OptionalFieldMeta Meta { get; set; }

        [JsonPropertyName("_links")]
        public OptionalFieldLinks _links { get; set; }

        private IDictionary<string, object> _additionalProperties;

        [JsonExtensionData]
        public IDictionary<string, object> AdditionalProperties
        {
            get { return _additionalProperties ?? (_additionalProperties = new Dictionary<string, object>()); }
            set { _additionalProperties = value; }
        }

    }

    [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "14.0.7.0 (NJsonSchema v11.0.0.0 (Newtonsoft.Json v13.0.0.0))")]
    public partial class Versions3
    {

        [JsonPropertyName("results")]
        public ICollection<Version> Results { get; set; }

        [JsonPropertyName("meta")]
        public OptionalFieldMeta Meta { get; set; }

        [JsonPropertyName("_links")]
        public OptionalFieldLinks _links { get; set; }

        private IDictionary<string, object> _additionalProperties;

        [JsonExtensionData]
        public IDictionary<string, object> AdditionalProperties
        {
            get { return _additionalProperties ?? (_additionalProperties = new Dictionary<string, object>()); }
            set { _additionalProperties = value; }
        }

    }

    [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "14.0.7.0 (NJsonSchema v11.0.0.0 (Newtonsoft.Json v13.0.0.0))")]
    public partial class Labels4
    {

        [JsonPropertyName("results")]
        public ICollection<Label> Results { get; set; }

        [JsonPropertyName("meta")]
        public OptionalFieldMeta Meta { get; set; }

        [JsonPropertyName("_links")]
        public OptionalFieldLinks _links { get; set; }

        private IDictionary<string, object> _additionalProperties;

        [JsonExtensionData]
        public IDictionary<string, object> AdditionalProperties
        {
            get { return _additionalProperties ?? (_additionalProperties = new Dictionary<string, object>()); }
            set { _additionalProperties = value; }
        }

    }

    [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "14.0.7.0 (NJsonSchema v11.0.0.0 (Newtonsoft.Json v13.0.0.0))")]
    public partial class Properties4
    {

        [JsonPropertyName("results")]
        public ICollection<ContentProperty> Results { get; set; }

        [JsonPropertyName("meta")]
        public OptionalFieldMeta Meta { get; set; }

        [JsonPropertyName("_links")]
        public OptionalFieldLinks _links { get; set; }

        private IDictionary<string, object> _additionalProperties;

        [JsonExtensionData]
        public IDictionary<string, object> AdditionalProperties
        {
            get { return _additionalProperties ?? (_additionalProperties = new Dictionary<string, object>()); }
            set { _additionalProperties = value; }
        }

    }

    [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "14.0.7.0 (NJsonSchema v11.0.0.0 (Newtonsoft.Json v13.0.0.0))")]
    public partial class Operations4
    {

        [JsonPropertyName("results")]
        public ICollection<Operation> Results { get; set; }

        [JsonPropertyName("meta")]
        public OptionalFieldMeta Meta { get; set; }

        [JsonPropertyName("_links")]
        public OptionalFieldLinks _links { get; set; }

        private IDictionary<string, object> _additionalProperties;

        [JsonExtensionData]
        public IDictionary<string, object> AdditionalProperties
        {
            get { return _additionalProperties ?? (_additionalProperties = new Dictionary<string, object>()); }
            set { _additionalProperties = value; }
        }

    }

    [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "14.0.7.0 (NJsonSchema v11.0.0.0 (Newtonsoft.Json v13.0.0.0))")]
    public partial class Likes2
    {

        [JsonPropertyName("results")]
        public ICollection<Like> Results { get; set; }

        [JsonPropertyName("meta")]
        public OptionalFieldMeta Meta { get; set; }

        [JsonPropertyName("_links")]
        public OptionalFieldLinks _links { get; set; }

        private IDictionary<string, object> _additionalProperties;

        [JsonExtensionData]
        public IDictionary<string, object> AdditionalProperties
        {
            get { return _additionalProperties ?? (_additionalProperties = new Dictionary<string, object>()); }
            set { _additionalProperties = value; }
        }

    }

    [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "14.0.7.0 (NJsonSchema v11.0.0.0 (Newtonsoft.Json v13.0.0.0))")]
    public partial class Versions4
    {

        [JsonPropertyName("results")]
        public ICollection<Version> Results { get; set; }

        [JsonPropertyName("meta")]
        public OptionalFieldMeta Meta { get; set; }

        [JsonPropertyName("_links")]
        public OptionalFieldLinks _links { get; set; }

        private IDictionary<string, object> _additionalProperties;

        [JsonExtensionData]
        public IDictionary<string, object> AdditionalProperties
        {
            get { return _additionalProperties ?? (_additionalProperties = new Dictionary<string, object>()); }
            set { _additionalProperties = value; }
        }

    }

    [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "14.0.7.0 (NJsonSchema v11.0.0.0 (Newtonsoft.Json v13.0.0.0))")]
    public enum PageBodyWriteRepresentation
    {

        [System.Runtime.Serialization.EnumMember(Value = @"storage")]
        Storage = 0,

        [System.Runtime.Serialization.EnumMember(Value = @"atlas_doc_format")]
        Atlas_doc_format = 1,

        [System.Runtime.Serialization.EnumMember(Value = @"wiki")]
        Wiki = 2,

    }

    [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "14.0.7.0 (NJsonSchema v11.0.0.0 (Newtonsoft.Json v13.0.0.0))")]
    public enum BlogPostBodyWriteRepresentation
    {

        [System.Runtime.Serialization.EnumMember(Value = @"storage")]
        Storage = 0,

        [System.Runtime.Serialization.EnumMember(Value = @"atlas_doc_format")]
        Atlas_doc_format = 1,

        [System.Runtime.Serialization.EnumMember(Value = @"wiki")]
        Wiki = 2,

    }

    [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "14.0.7.0 (NJsonSchema v11.0.0.0 (Newtonsoft.Json v13.0.0.0))")]
    public enum CommentBodyWriteRepresentation
    {

        [System.Runtime.Serialization.EnumMember(Value = @"storage")]
        Storage = 0,

        [System.Runtime.Serialization.EnumMember(Value = @"atlas_doc_format")]
        Atlas_doc_format = 1,

        [System.Runtime.Serialization.EnumMember(Value = @"wiki")]
        Wiki = 2,

    }

    [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "14.0.7.0 (NJsonSchema v11.0.0.0 (Newtonsoft.Json v13.0.0.0))")]
    public enum CustomContentBodyWriteRepresentation
    {

        [System.Runtime.Serialization.EnumMember(Value = @"storage")]
        Storage = 0,

        [System.Runtime.Serialization.EnumMember(Value = @"atlas_doc_format")]
        Atlas_doc_format = 1,

        [System.Runtime.Serialization.EnumMember(Value = @"raw")]
        Raw = 2,

    }

    [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "14.0.7.0 (NJsonSchema v11.0.0.0 (Newtonsoft.Json v13.0.0.0))")]
    public partial class Labels5
    {

        [JsonPropertyName("results")]
        public ICollection<Label> Results { get; set; }

        [JsonPropertyName("meta")]
        public OptionalFieldMeta Meta { get; set; }

        [JsonPropertyName("_links")]
        public OptionalFieldLinks _links { get; set; }

        private IDictionary<string, object> _additionalProperties;

        [JsonExtensionData]
        public IDictionary<string, object> AdditionalProperties
        {
            get { return _additionalProperties ?? (_additionalProperties = new Dictionary<string, object>()); }
            set { _additionalProperties = value; }
        }

    }

    [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "14.0.7.0 (NJsonSchema v11.0.0.0 (Newtonsoft.Json v13.0.0.0))")]
    public partial class Properties5
    {

        [JsonPropertyName("results")]
        public ICollection<SpaceProperty> Results { get; set; }

        [JsonPropertyName("meta")]
        public OptionalFieldMeta Meta { get; set; }

        [JsonPropertyName("_links")]
        public OptionalFieldLinks _links { get; set; }

        private IDictionary<string, object> _additionalProperties;

        [JsonExtensionData]
        public IDictionary<string, object> AdditionalProperties
        {
            get { return _additionalProperties ?? (_additionalProperties = new Dictionary<string, object>()); }
            set { _additionalProperties = value; }
        }

    }

    [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "14.0.7.0 (NJsonSchema v11.0.0.0 (Newtonsoft.Json v13.0.0.0))")]
    public partial class Operations5
    {

        [JsonPropertyName("results")]
        public ICollection<Operation> Results { get; set; }

        [JsonPropertyName("meta")]
        public OptionalFieldMeta Meta { get; set; }

        [JsonPropertyName("_links")]
        public OptionalFieldLinks _links { get; set; }

        private IDictionary<string, object> _additionalProperties;

        [JsonExtensionData]
        public IDictionary<string, object> AdditionalProperties
        {
            get { return _additionalProperties ?? (_additionalProperties = new Dictionary<string, object>()); }
            set { _additionalProperties = value; }
        }

    }

    [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "14.0.7.0 (NJsonSchema v11.0.0.0 (Newtonsoft.Json v13.0.0.0))")]
    public partial class Permissions
    {

        [JsonPropertyName("results")]
        public ICollection<SpacePermission> Results { get; set; }

        [JsonPropertyName("meta")]
        public OptionalFieldMeta Meta { get; set; }

        [JsonPropertyName("_links")]
        public OptionalFieldLinks _links { get; set; }

        private IDictionary<string, object> _additionalProperties;

        [JsonExtensionData]
        public IDictionary<string, object> AdditionalProperties
        {
            get { return _additionalProperties ?? (_additionalProperties = new Dictionary<string, object>()); }
            set { _additionalProperties = value; }
        }

    }

    [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "14.0.7.0 (NJsonSchema v11.0.0.0 (Newtonsoft.Json v13.0.0.0))")]
    public partial class Principal
    {

        [JsonPropertyName("type")]
        [JsonConverter(typeof(JsonStringEnumConverter))]
        public PrincipalType Type { get; set; }

        /// <summary>
        /// ID of the entity.
        /// </summary>

        [JsonPropertyName("id")]
        public string Id { get; set; }

        private IDictionary<string, object> _additionalProperties;

        [JsonExtensionData]
        public IDictionary<string, object> AdditionalProperties
        {
            get { return _additionalProperties ?? (_additionalProperties = new Dictionary<string, object>()); }
            set { _additionalProperties = value; }
        }

    }

    [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "14.0.7.0 (NJsonSchema v11.0.0.0 (Newtonsoft.Json v13.0.0.0))")]
    public partial class Operation2
    {
        /// <summary>
        /// The type of operation.
        /// </summary>

        [JsonPropertyName("key")]
        [JsonConverter(typeof(JsonStringEnumConverter))]
        public Operation2Key Key { get; set; }

        /// <summary>
        /// The type of entity the operation type targets.
        /// </summary>

        [JsonPropertyName("targetType")]
        [JsonConverter(typeof(JsonStringEnumConverter))]
        public Operation2TargetType TargetType { get; set; }

        private IDictionary<string, object> _additionalProperties;

        [JsonExtensionData]
        public IDictionary<string, object> AdditionalProperties
        {
            get { return _additionalProperties ?? (_additionalProperties = new Dictionary<string, object>()); }
            set { _additionalProperties = value; }
        }

    }

    [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "14.0.7.0 (NJsonSchema v11.0.0.0 (Newtonsoft.Json v13.0.0.0))")]
    public partial class Version3
    {
        /// <summary>
        /// RFC3339 compliant date time at which the property's current version was created.
        /// </summary>

        [JsonPropertyName("createdAt")]
        public System.DateTimeOffset CreatedAt { get; set; }

        /// <summary>
        /// Atlassian account ID of the user that created the space property's current version.
        /// </summary>

        [JsonPropertyName("createdBy")]
        public string CreatedBy { get; set; }

        /// <summary>
        /// Message associated with the current version.
        /// </summary>

        [JsonPropertyName("message")]
        public string Message { get; set; }

        /// <summary>
        /// The space property's current version number.
        /// </summary>

        [JsonPropertyName("number")]
        public int Number { get; set; }

        private IDictionary<string, object> _additionalProperties;

        [JsonExtensionData]
        public IDictionary<string, object> AdditionalProperties
        {
            get { return _additionalProperties ?? (_additionalProperties = new Dictionary<string, object>()); }
            set { _additionalProperties = value; }
        }

    }

    [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "14.0.7.0 (NJsonSchema v11.0.0.0 (Newtonsoft.Json v13.0.0.0))")]
    public partial class Version4
    {
        /// <summary>
        /// Version number of the new version. Should be 1 more than the current version number.
        /// </summary>

        [JsonPropertyName("number")]
        public int Number { get; set; }

        /// <summary>
        /// Message to be associated with the new version.
        /// </summary>

        [JsonPropertyName("message")]
        public string Message { get; set; }

        private IDictionary<string, object> _additionalProperties;

        [JsonExtensionData]
        public IDictionary<string, object> AdditionalProperties
        {
            get { return _additionalProperties ?? (_additionalProperties = new Dictionary<string, object>()); }
            set { _additionalProperties = value; }
        }

    }

    [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "14.0.7.0 (NJsonSchema v11.0.0.0 (Newtonsoft.Json v13.0.0.0))")]
    public enum TaskStatus
    {

        [System.Runtime.Serialization.EnumMember(Value = @"complete")]
        Complete = 0,

        [System.Runtime.Serialization.EnumMember(Value = @"incomplete")]
        Incomplete = 1,

    }

    [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "14.0.7.0 (NJsonSchema v11.0.0.0 (Newtonsoft.Json v13.0.0.0))")]
    public partial class Properties6
    {

        [JsonPropertyName("results")]
        public ICollection<ContentProperty> Results { get; set; }

        [JsonPropertyName("meta")]
        public OptionalFieldMeta Meta { get; set; }

        [JsonPropertyName("_links")]
        public OptionalFieldLinks _links { get; set; }

        private IDictionary<string, object> _additionalProperties;

        [JsonExtensionData]
        public IDictionary<string, object> AdditionalProperties
        {
            get { return _additionalProperties ?? (_additionalProperties = new Dictionary<string, object>()); }
            set { _additionalProperties = value; }
        }

    }

    [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "14.0.7.0 (NJsonSchema v11.0.0.0 (Newtonsoft.Json v13.0.0.0))")]
    public partial class Operations6
    {

        [JsonPropertyName("results")]
        public ICollection<Operation> Results { get; set; }

        [JsonPropertyName("meta")]
        public OptionalFieldMeta Meta { get; set; }

        [JsonPropertyName("_links")]
        public OptionalFieldLinks _links { get; set; }

        private IDictionary<string, object> _additionalProperties;

        [JsonExtensionData]
        public IDictionary<string, object> AdditionalProperties
        {
            get { return _additionalProperties ?? (_additionalProperties = new Dictionary<string, object>()); }
            set { _additionalProperties = value; }
        }

    }

    [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "14.0.7.0 (NJsonSchema v11.0.0.0 (Newtonsoft.Json v13.0.0.0))")]
    public partial class Likes3
    {

        [JsonPropertyName("results")]
        public ICollection<Like> Results { get; set; }

        [JsonPropertyName("meta")]
        public OptionalFieldMeta Meta { get; set; }

        [JsonPropertyName("_links")]
        public OptionalFieldLinks _links { get; set; }

        private IDictionary<string, object> _additionalProperties;

        [JsonExtensionData]
        public IDictionary<string, object> AdditionalProperties
        {
            get { return _additionalProperties ?? (_additionalProperties = new Dictionary<string, object>()); }
            set { _additionalProperties = value; }
        }

    }

    [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "14.0.7.0 (NJsonSchema v11.0.0.0 (Newtonsoft.Json v13.0.0.0))")]
    public partial class Versions5
    {

        [JsonPropertyName("results")]
        public ICollection<Version> Results { get; set; }

        [JsonPropertyName("meta")]
        public OptionalFieldMeta Meta { get; set; }

        [JsonPropertyName("_links")]
        public OptionalFieldLinks _links { get; set; }

        private IDictionary<string, object> _additionalProperties;

        [JsonExtensionData]
        public IDictionary<string, object> AdditionalProperties
        {
            get { return _additionalProperties ?? (_additionalProperties = new Dictionary<string, object>()); }
            set { _additionalProperties = value; }
        }

    }

    [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "14.0.7.0 (NJsonSchema v11.0.0.0 (Newtonsoft.Json v13.0.0.0))")]
    public partial class Properties7
    {

        [JsonPropertyName("results")]
        public ICollection<ContentProperty> Results { get; set; }

        [JsonPropertyName("meta")]
        public OptionalFieldMeta Meta { get; set; }

        [JsonPropertyName("_links")]
        public OptionalFieldLinks _links { get; set; }

        /// <summary>
        /// Property value used to reference the highlighted element in DOM.
        /// </summary>

        [JsonPropertyName("inlineMarkerRef")]
        public string InlineMarkerRef { get; set; }

        /// <summary>
        /// Text that is highlighted.
        /// </summary>

        [JsonPropertyName("inlineOriginalSelection")]
        public string InlineOriginalSelection { get; set; }

        private IDictionary<string, object> _additionalProperties;

        [JsonExtensionData]
        public IDictionary<string, object> AdditionalProperties
        {
            get { return _additionalProperties ?? (_additionalProperties = new Dictionary<string, object>()); }
            set { _additionalProperties = value; }
        }

    }

    [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "14.0.7.0 (NJsonSchema v11.0.0.0 (Newtonsoft.Json v13.0.0.0))")]
    public partial class Operations7
    {

        [JsonPropertyName("results")]
        public ICollection<Operation> Results { get; set; }

        [JsonPropertyName("meta")]
        public OptionalFieldMeta Meta { get; set; }

        [JsonPropertyName("_links")]
        public OptionalFieldLinks _links { get; set; }

        private IDictionary<string, object> _additionalProperties;

        [JsonExtensionData]
        public IDictionary<string, object> AdditionalProperties
        {
            get { return _additionalProperties ?? (_additionalProperties = new Dictionary<string, object>()); }
            set { _additionalProperties = value; }
        }

    }

    [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "14.0.7.0 (NJsonSchema v11.0.0.0 (Newtonsoft.Json v13.0.0.0))")]
    public partial class Likes4
    {

        [JsonPropertyName("results")]
        public ICollection<Like> Results { get; set; }

        [JsonPropertyName("meta")]
        public OptionalFieldMeta Meta { get; set; }

        [JsonPropertyName("_links")]
        public OptionalFieldLinks _links { get; set; }

        private IDictionary<string, object> _additionalProperties;

        [JsonExtensionData]
        public IDictionary<string, object> AdditionalProperties
        {
            get { return _additionalProperties ?? (_additionalProperties = new Dictionary<string, object>()); }
            set { _additionalProperties = value; }
        }

    }

    [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "14.0.7.0 (NJsonSchema v11.0.0.0 (Newtonsoft.Json v13.0.0.0))")]
    public partial class Versions6
    {

        [JsonPropertyName("results")]
        public ICollection<Version> Results { get; set; }

        [JsonPropertyName("meta")]
        public OptionalFieldMeta Meta { get; set; }

        [JsonPropertyName("_links")]
        public OptionalFieldLinks _links { get; set; }

        private IDictionary<string, object> _additionalProperties;

        [JsonExtensionData]
        public IDictionary<string, object> AdditionalProperties
        {
            get { return _additionalProperties ?? (_additionalProperties = new Dictionary<string, object>()); }
            set { _additionalProperties = value; }
        }

    }

    [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "14.0.7.0 (NJsonSchema v11.0.0.0 (Newtonsoft.Json v13.0.0.0))")]
    public partial class InlineCommentProperties2
    {
        /// <summary>
        /// The text to highlight
        /// </summary>

        [JsonPropertyName("textSelection")]
        public string TextSelection { get; set; }

        /// <summary>
        /// The number of matches for the selected text on the page (should be strictly greater than textSelectionMatchIndex)
        /// </summary>

        [JsonPropertyName("textSelectionMatchCount")]
        public int TextSelectionMatchCount { get; set; }

        /// <summary>
        /// The match index to highlight. This is zero-based. E.g. if you have 3 occurrences of "hello world" on a page 
        /// <br/>and you want to highlight the second occurrence, you should pass 1 for textSelectionMatchIndex and 3 for textSelectionMatchCount.
        /// </summary>

        [JsonPropertyName("textSelectionMatchIndex")]
        public int TextSelectionMatchIndex { get; set; }

        private IDictionary<string, object> _additionalProperties;

        [JsonExtensionData]
        public IDictionary<string, object> AdditionalProperties
        {
            get { return _additionalProperties ?? (_additionalProperties = new Dictionary<string, object>()); }
            set { _additionalProperties = value; }
        }

    }

    [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "14.0.7.0 (NJsonSchema v11.0.0.0 (Newtonsoft.Json v13.0.0.0))")]
    public partial class Version5
    {
        /// <summary>
        /// Number of new version. Should be 1 higher than current version of the comment.
        /// </summary>

        [JsonPropertyName("number")]
        public int Number { get; set; }

        /// <summary>
        /// Optional message store for the new version.
        /// </summary>

        [JsonPropertyName("message")]
        public string Message { get; set; }

        private IDictionary<string, object> _additionalProperties;

        [JsonExtensionData]
        public IDictionary<string, object> AdditionalProperties
        {
            get { return _additionalProperties ?? (_additionalProperties = new Dictionary<string, object>()); }
            set { _additionalProperties = value; }
        }

    }

    [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "14.0.7.0 (NJsonSchema v11.0.0.0 (Newtonsoft.Json v13.0.0.0))")]
    public partial class Version6
    {
        /// <summary>
        /// Number of new version. Should be 1 higher than current version of the comment.
        /// </summary>

        [JsonPropertyName("number")]
        public int Number { get; set; }

        /// <summary>
        /// Optional message store for the new version.
        /// </summary>

        [JsonPropertyName("message")]
        public string Message { get; set; }

        private IDictionary<string, object> _additionalProperties;

        [JsonExtensionData]
        public IDictionary<string, object> AdditionalProperties
        {
            get { return _additionalProperties ?? (_additionalProperties = new Dictionary<string, object>()); }
            set { _additionalProperties = value; }
        }

    }

    [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "14.0.7.0 (NJsonSchema v11.0.0.0 (Newtonsoft.Json v13.0.0.0))")]
    public partial class DataPolicy
    {
        /// <summary>
        /// Whether the space contains any content blocked for (inaccessible to) the requesting client application.
        /// </summary>

        [JsonPropertyName("anyContentBlocked")]
        public bool AnyContentBlocked { get; set; }

        private IDictionary<string, object> _additionalProperties;

        [JsonExtensionData]
        public IDictionary<string, object> AdditionalProperties
        {
            get { return _additionalProperties ?? (_additionalProperties = new Dictionary<string, object>()); }
            set { _additionalProperties = value; }
        }

    }

    [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "14.0.7.0 (NJsonSchema v11.0.0.0 (Newtonsoft.Json v13.0.0.0))")]
    public partial class _links
    {
        /// <summary>
        /// Base url of the Confluence site.
        /// </summary>

        [JsonPropertyName("base")]
        public string Base { get; set; }

        private IDictionary<string, object> _additionalProperties;

        [JsonExtensionData]
        public IDictionary<string, object> AdditionalProperties
        {
            get { return _additionalProperties ?? (_additionalProperties = new Dictionary<string, object>()); }
            set { _additionalProperties = value; }
        }

    }

    [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "14.0.7.0 (NJsonSchema v11.0.0.0 (Newtonsoft.Json v13.0.0.0))")]
    public partial class _links2
    {
        /// <summary>
        /// Base url of the Confluence site.
        /// </summary>

        [JsonPropertyName("base")]
        public string Base { get; set; }

        private IDictionary<string, object> _additionalProperties;

        [JsonExtensionData]
        public IDictionary<string, object> AdditionalProperties
        {
            get { return _additionalProperties ?? (_additionalProperties = new Dictionary<string, object>()); }
            set { _additionalProperties = value; }
        }

    }

    [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "14.0.7.0 (NJsonSchema v11.0.0.0 (Newtonsoft.Json v13.0.0.0))")]
    public partial class _links3
    {
        /// <summary>
        /// Base url of the Confluence site.
        /// </summary>

        [JsonPropertyName("base")]
        public string Base { get; set; }

        private IDictionary<string, object> _additionalProperties;

        [JsonExtensionData]
        public IDictionary<string, object> AdditionalProperties
        {
            get { return _additionalProperties ?? (_additionalProperties = new Dictionary<string, object>()); }
            set { _additionalProperties = value; }
        }

    }

    [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "14.0.7.0 (NJsonSchema v11.0.0.0 (Newtonsoft.Json v13.0.0.0))")]
    public partial class _links4
    {
        /// <summary>
        /// Base url of the Confluence site.
        /// </summary>

        [JsonPropertyName("base")]
        public string Base { get; set; }

        private IDictionary<string, object> _additionalProperties;

        [JsonExtensionData]
        public IDictionary<string, object> AdditionalProperties
        {
            get { return _additionalProperties ?? (_additionalProperties = new Dictionary<string, object>()); }
            set { _additionalProperties = value; }
        }

    }

    [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "14.0.7.0 (NJsonSchema v11.0.0.0 (Newtonsoft.Json v13.0.0.0))")]
    public partial class _links5
    {
        /// <summary>
        /// Base url of the Confluence site.
        /// </summary>

        [JsonPropertyName("base")]
        public string Base { get; set; }

        private IDictionary<string, object> _additionalProperties;

        [JsonExtensionData]
        public IDictionary<string, object> AdditionalProperties
        {
            get { return _additionalProperties ?? (_additionalProperties = new Dictionary<string, object>()); }
            set { _additionalProperties = value; }
        }

    }

    [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "14.0.7.0 (NJsonSchema v11.0.0.0 (Newtonsoft.Json v13.0.0.0))")]
    public partial class _links6
    {
        /// <summary>
        /// Base url of the Confluence site.
        /// </summary>

        [JsonPropertyName("base")]
        public string Base { get; set; }

        private IDictionary<string, object> _additionalProperties;

        [JsonExtensionData]
        public IDictionary<string, object> AdditionalProperties
        {
            get { return _additionalProperties ?? (_additionalProperties = new Dictionary<string, object>()); }
            set { _additionalProperties = value; }
        }

    }

    [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "14.0.7.0 (NJsonSchema v11.0.0.0 (Newtonsoft.Json v13.0.0.0))")]
    public partial class _links7
    {
        /// <summary>
        /// Base url of the Confluence site.
        /// </summary>

        [JsonPropertyName("base")]
        public string Base { get; set; }

        private IDictionary<string, object> _additionalProperties;

        [JsonExtensionData]
        public IDictionary<string, object> AdditionalProperties
        {
            get { return _additionalProperties ?? (_additionalProperties = new Dictionary<string, object>()); }
            set { _additionalProperties = value; }
        }

    }

    [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "14.0.7.0 (NJsonSchema v11.0.0.0 (Newtonsoft.Json v13.0.0.0))")]
    public partial class _links8
    {
        /// <summary>
        /// Base url of the Confluence site.
        /// </summary>

        [JsonPropertyName("base")]
        public string Base { get; set; }

        private IDictionary<string, object> _additionalProperties;

        [JsonExtensionData]
        public IDictionary<string, object> AdditionalProperties
        {
            get { return _additionalProperties ?? (_additionalProperties = new Dictionary<string, object>()); }
            set { _additionalProperties = value; }
        }

    }

    [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "14.0.7.0 (NJsonSchema v11.0.0.0 (Newtonsoft.Json v13.0.0.0))")]
    public partial class _links9
    {
        /// <summary>
        /// Base url of the Confluence site.
        /// </summary>

        [JsonPropertyName("base")]
        public string Base { get; set; }

        private IDictionary<string, object> _additionalProperties;

        [JsonExtensionData]
        public IDictionary<string, object> AdditionalProperties
        {
            get { return _additionalProperties ?? (_additionalProperties = new Dictionary<string, object>()); }
            set { _additionalProperties = value; }
        }

    }

    [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "14.0.7.0 (NJsonSchema v11.0.0.0 (Newtonsoft.Json v13.0.0.0))")]
    public partial class _links10
    {
        /// <summary>
        /// Base url of the Confluence site.
        /// </summary>

        [JsonPropertyName("base")]
        public string Base { get; set; }

        private IDictionary<string, object> _additionalProperties;

        [JsonExtensionData]
        public IDictionary<string, object> AdditionalProperties
        {
            get { return _additionalProperties ?? (_additionalProperties = new Dictionary<string, object>()); }
            set { _additionalProperties = value; }
        }

    }

    [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "14.0.7.0 (NJsonSchema v11.0.0.0 (Newtonsoft.Json v13.0.0.0))")]
    public partial class _links11
    {
        /// <summary>
        /// Base url of the Confluence site.
        /// </summary>

        [JsonPropertyName("base")]
        public string Base { get; set; }

        private IDictionary<string, object> _additionalProperties;

        [JsonExtensionData]
        public IDictionary<string, object> AdditionalProperties
        {
            get { return _additionalProperties ?? (_additionalProperties = new Dictionary<string, object>()); }
            set { _additionalProperties = value; }
        }

    }

    [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "14.0.7.0 (NJsonSchema v11.0.0.0 (Newtonsoft.Json v13.0.0.0))")]
    public partial class _links12
    {
        /// <summary>
        /// Base url of the Confluence site.
        /// </summary>

        [JsonPropertyName("base")]
        public string Base { get; set; }

        private IDictionary<string, object> _additionalProperties;

        [JsonExtensionData]
        public IDictionary<string, object> AdditionalProperties
        {
            get { return _additionalProperties ?? (_additionalProperties = new Dictionary<string, object>()); }
            set { _additionalProperties = value; }
        }

    }

    [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "14.0.7.0 (NJsonSchema v11.0.0.0 (Newtonsoft.Json v13.0.0.0))")]
    public partial class _links13
    {
        /// <summary>
        /// Base url of the Confluence site.
        /// </summary>

        [JsonPropertyName("base")]
        public string Base { get; set; }

        private IDictionary<string, object> _additionalProperties;

        [JsonExtensionData]
        public IDictionary<string, object> AdditionalProperties
        {
            get { return _additionalProperties ?? (_additionalProperties = new Dictionary<string, object>()); }
            set { _additionalProperties = value; }
        }

    }

    [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "14.0.7.0 (NJsonSchema v11.0.0.0 (Newtonsoft.Json v13.0.0.0))")]
    public partial class _links14
    {
        /// <summary>
        /// Base url of the Confluence site.
        /// </summary>

        [JsonPropertyName("base")]
        public string Base { get; set; }

        private IDictionary<string, object> _additionalProperties;

        [JsonExtensionData]
        public IDictionary<string, object> AdditionalProperties
        {
            get { return _additionalProperties ?? (_additionalProperties = new Dictionary<string, object>()); }
            set { _additionalProperties = value; }
        }

    }

    [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "14.0.7.0 (NJsonSchema v11.0.0.0 (Newtonsoft.Json v13.0.0.0))")]
    public partial class _links15
    {
        /// <summary>
        /// Base url of the Confluence site.
        /// </summary>

        [JsonPropertyName("base")]
        public string Base { get; set; }

        private IDictionary<string, object> _additionalProperties;

        [JsonExtensionData]
        public IDictionary<string, object> AdditionalProperties
        {
            get { return _additionalProperties ?? (_additionalProperties = new Dictionary<string, object>()); }
            set { _additionalProperties = value; }
        }

    }

    [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "14.0.7.0 (NJsonSchema v11.0.0.0 (Newtonsoft.Json v13.0.0.0))")]
    public partial class _links16
    {
        /// <summary>
        /// Base url of the Confluence site.
        /// </summary>

        [JsonPropertyName("base")]
        public string Base { get; set; }

        private IDictionary<string, object> _additionalProperties;

        [JsonExtensionData]
        public IDictionary<string, object> AdditionalProperties
        {
            get { return _additionalProperties ?? (_additionalProperties = new Dictionary<string, object>()); }
            set { _additionalProperties = value; }
        }

    }

    [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "14.0.7.0 (NJsonSchema v11.0.0.0 (Newtonsoft.Json v13.0.0.0))")]
    public partial class _links17
    {
        /// <summary>
        /// Base url of the Confluence site.
        /// </summary>

        [JsonPropertyName("base")]
        public string Base { get; set; }

        private IDictionary<string, object> _additionalProperties;

        [JsonExtensionData]
        public IDictionary<string, object> AdditionalProperties
        {
            get { return _additionalProperties ?? (_additionalProperties = new Dictionary<string, object>()); }
            set { _additionalProperties = value; }
        }

    }

    [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "14.0.7.0 (NJsonSchema v11.0.0.0 (Newtonsoft.Json v13.0.0.0))")]
    public partial class _links18
    {
        /// <summary>
        /// Base url of the Confluence site.
        /// </summary>

        [JsonPropertyName("base")]
        public string Base { get; set; }

        private IDictionary<string, object> _additionalProperties;

        [JsonExtensionData]
        public IDictionary<string, object> AdditionalProperties
        {
            get { return _additionalProperties ?? (_additionalProperties = new Dictionary<string, object>()); }
            set { _additionalProperties = value; }
        }

    }

    [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "14.0.7.0 (NJsonSchema v11.0.0.0 (Newtonsoft.Json v13.0.0.0))")]
    public partial class _links19
    {
        /// <summary>
        /// Base url of the Confluence site.
        /// </summary>

        [JsonPropertyName("base")]
        public string Base { get; set; }

        private IDictionary<string, object> _additionalProperties;

        [JsonExtensionData]
        public IDictionary<string, object> AdditionalProperties
        {
            get { return _additionalProperties ?? (_additionalProperties = new Dictionary<string, object>()); }
            set { _additionalProperties = value; }
        }

    }

    [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "14.0.7.0 (NJsonSchema v11.0.0.0 (Newtonsoft.Json v13.0.0.0))")]
    public partial class _links20
    {
        /// <summary>
        /// Base url of the Confluence site.
        /// </summary>

        [JsonPropertyName("base")]
        public string Base { get; set; }

        private IDictionary<string, object> _additionalProperties;

        [JsonExtensionData]
        public IDictionary<string, object> AdditionalProperties
        {
            get { return _additionalProperties ?? (_additionalProperties = new Dictionary<string, object>()); }
            set { _additionalProperties = value; }
        }

    }

    [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "14.0.7.0 (NJsonSchema v11.0.0.0 (Newtonsoft.Json v13.0.0.0))")]
    public partial class _links21
    {
        /// <summary>
        /// Base url of the Confluence site.
        /// </summary>

        [JsonPropertyName("base")]
        public string Base { get; set; }

        private IDictionary<string, object> _additionalProperties;

        [JsonExtensionData]
        public IDictionary<string, object> AdditionalProperties
        {
            get { return _additionalProperties ?? (_additionalProperties = new Dictionary<string, object>()); }
            set { _additionalProperties = value; }
        }

    }

    [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "14.0.7.0 (NJsonSchema v11.0.0.0 (Newtonsoft.Json v13.0.0.0))")]
    public partial class _links22
    {
        /// <summary>
        /// Base url of the Confluence site.
        /// </summary>

        [JsonPropertyName("base")]
        public string Base { get; set; }

        private IDictionary<string, object> _additionalProperties;

        [JsonExtensionData]
        public IDictionary<string, object> AdditionalProperties
        {
            get { return _additionalProperties ?? (_additionalProperties = new Dictionary<string, object>()); }
            set { _additionalProperties = value; }
        }

    }

    [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "14.0.7.0 (NJsonSchema v11.0.0.0 (Newtonsoft.Json v13.0.0.0))")]
    public partial class _links23
    {
        /// <summary>
        /// Base url of the Confluence site.
        /// </summary>

        [JsonPropertyName("base")]
        public string Base { get; set; }

        private IDictionary<string, object> _additionalProperties;

        [JsonExtensionData]
        public IDictionary<string, object> AdditionalProperties
        {
            get { return _additionalProperties ?? (_additionalProperties = new Dictionary<string, object>()); }
            set { _additionalProperties = value; }
        }

    }

    [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "14.0.7.0 (NJsonSchema v11.0.0.0 (Newtonsoft.Json v13.0.0.0))")]
    public enum PrincipalType
    {

        [System.Runtime.Serialization.EnumMember(Value = @"user")]
        User = 0,

        [System.Runtime.Serialization.EnumMember(Value = @"group")]
        Group = 1,

        [System.Runtime.Serialization.EnumMember(Value = @"role")]
        Role = 2,

    }

    [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "14.0.7.0 (NJsonSchema v11.0.0.0 (Newtonsoft.Json v13.0.0.0))")]
    public enum Operation2Key
    {

        [System.Runtime.Serialization.EnumMember(Value = @"use")]
        Use = 0,

        [System.Runtime.Serialization.EnumMember(Value = @"create")]
        Create = 1,

        [System.Runtime.Serialization.EnumMember(Value = @"read")]
        Read = 2,

        [System.Runtime.Serialization.EnumMember(Value = @"update")]
        Update = 3,

        [System.Runtime.Serialization.EnumMember(Value = @"delete")]
        Delete = 4,

        [System.Runtime.Serialization.EnumMember(Value = @"copy")]
        Copy = 5,

        [System.Runtime.Serialization.EnumMember(Value = @"move")]
        Move = 6,

        [System.Runtime.Serialization.EnumMember(Value = @"export")]
        Export = 7,

        [System.Runtime.Serialization.EnumMember(Value = @"purge")]
        Purge = 8,

        [System.Runtime.Serialization.EnumMember(Value = @"purge_version")]
        Purge_version = 9,

        [System.Runtime.Serialization.EnumMember(Value = @"administer")]
        Administer = 10,

        [System.Runtime.Serialization.EnumMember(Value = @"restore")]
        Restore = 11,

        [System.Runtime.Serialization.EnumMember(Value = @"create_space")]
        Create_space = 12,

        [System.Runtime.Serialization.EnumMember(Value = @"restrict_content")]
        Restrict_content = 13,

        [System.Runtime.Serialization.EnumMember(Value = @"archive")]
        Archive = 14,

    }

    [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "14.0.7.0 (NJsonSchema v11.0.0.0 (Newtonsoft.Json v13.0.0.0))")]
    public enum Operation2TargetType
    {

        [System.Runtime.Serialization.EnumMember(Value = @"page")]
        Page = 0,

        [System.Runtime.Serialization.EnumMember(Value = @"blogpost")]
        Blogpost = 1,

        [System.Runtime.Serialization.EnumMember(Value = @"comment")]
        Comment = 2,

        [System.Runtime.Serialization.EnumMember(Value = @"attachment")]
        Attachment = 3,

        [System.Runtime.Serialization.EnumMember(Value = @"whiteboard")]
        Whiteboard = 4,

        [System.Runtime.Serialization.EnumMember(Value = @"database")]
        Database = 5,

        [System.Runtime.Serialization.EnumMember(Value = @"embed")]
        Embed = 6,

        [System.Runtime.Serialization.EnumMember(Value = @"space")]
        Space = 7,

        [System.Runtime.Serialization.EnumMember(Value = @"application")]
        Application = 8,

        [System.Runtime.Serialization.EnumMember(Value = @"userProfile")]
        UserProfile = 9,

    }


}

#pragma warning restore  108
#pragma warning restore  114
#pragma warning restore  472
#pragma warning restore  612
#pragma warning restore 1573
#pragma warning restore 1591
#pragma warning restore 8073
#pragma warning restore 3016
#pragma warning restore 8603
#pragma warning restore 8604
#pragma warning restore 8625
#nullable enable
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