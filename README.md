# Confluence API V2 Client Documentation
## Overview
The Confluence API V2 Client is a .NET client for the Confluence REST API v2. It allows users to interact with their Confluence instance programmatically.

## Installation
To install the Confluence API V2 Client library, you can add the package to your project using the .NET CLI or the NuGet Package Manager.

### .NET CLI:
```
dotnet add package ConfluenceApiV2Client --version 1.0.0
```

### NuGet Package Manager:
```
Install-Package ConfluenceApiV2Client -Version 1.0.0
```

### Supported .NET Versions
The library supports the following .NET versions:

* **.NET Standard 2.0**
* **.NET 6.0**
* **.NET 7.0**
* **.NET 8.0**

### Reference Libraries
The library requires the following NuGet packages:

Microsoft.Extensions.DependencyInjection (Version 8.0.0)
Refit (Version 7.0.0)
Refit.HttpClientFactory (Version 7.0.0)
These dependencies will be installed automatically when you add the ConfluenceApiV2Client package to your project.

## Usage
To use the Confluence API V2 Client, you need to authenticate with your Confluence instance using your email and API token.
Below are examples demonstrating how to retrieve spaces and pages from your Confluence instance.

#### Example: Retrieve All Spaces

> This example shows how to retrieve all spaces from your Confluence instance.
``` csharp
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using ConfluenceApiV2.Client;
using Refit;

internal class Program
{

private static HttpClient Client { get; set; } = null!;

static async Task Main(string[] args)
{
string eMail = "{your-confluence-email}";
string apiToken = "{your-confluence-api-token}";

    string auth = $"{eMail}:{apiToken}";
    string authBase64 = Convert.ToBase64String(Encoding.ASCII.GetBytes(auth));
    
    Client = RestService.CreateHttpClient("https://{your-domain}.atlassian.net/wiki/api/v2", new RefitSettings());
    Client.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Basic", authBase64);

    var allSpaces = await AllSpacesAsync();

    Console.WriteLine($"Spaces Count: {allSpaces.Count}");
    foreach (var space in allSpaces)
    {
        Console.WriteLine($"Space Name: {space.Name}, Space Key: {space.Key}");
    }
}

public static async Task<ICollection<SpaceBulk>> AllSpacesAsync()
{
var allSpaces = new List<SpaceBulk>();

    try
    {
        var spacesApi = RestService.For<ISpaceApi>(Client);
        string? cursor = null;
        do
        {
            var spacesResult = await spacesApi.GetSpacesAsync(null, null, Type.Global, null, null, null, null, null, null, null, cursor, 25, default);
            if (spacesResult.Content == null) break;
            allSpaces.AddRange(spacesResult.Content!.Results);

            var uri = new UriBuilder(Client.BaseAddress + spacesResult.Content._links.Next);
            var queryParams = System.Web.HttpUtility.ParseQueryString(uri.Query);
            cursor = queryParams.Get("cursor");
        } 
        while (!string.IsNullOrEmpty(cursor));

        return allSpaces;
    }
    catch (ApiException apiEx)
    {
        Console.WriteLine($"API Error: {apiEx.StatusCode} - {apiEx.Message}");
    }
    catch (Exception ex)
    {
        Console.WriteLine($"Error: {ex.Message}");
    }
    return allSpaces;
}
}
```

#### Example: Retrieve All Pages of Spaces

> This example shows how to retrieve all pages from the spaces in your Confluence instance.
``` csharp
public static async Task<ICollection<PageBulk>> AllPagesOfSpacesAsync(ICollection<SpaceBulk> spaces)
{

var allSpaces = spaces.ToList();
var allPages = new List<PageBulk>();

try
{
var pageApi = RestService.For<IPageApi>(Client);

    string? cursor = null;
    var ids = allSpaces.Select(s => (long)Convert.ToDouble(s.Id)).ToList();
    do
    {
        var pagesResult = await pageApi.GetPagesAsync(null, ids, null, new[] { Anonymous5.Current }, null, PrimaryBodyRepresentation.Storage, cursor, 25, default);
        if (pagesResult.Content == null) break;
        allPages.AddRange(pagesResult.Content!.Results);

        var uri = new UriBuilder(Client.BaseAddress + pagesResult.Content._links.Next);
        var queryParams = System.Web.HttpUtility.ParseQueryString(uri.Query);
        cursor = queryParams.Get("cursor");
    }
    while (!string.IsNullOrEmpty(cursor));

    return allPages;
}
catch (ApiException apiEx)
{
Console.WriteLine($"API Error: {apiEx.StatusCode} - {apiEx.Message}");
}
catch (Exception ex)
{
Console.WriteLine($"Error: {ex.Message}");
}
return allPages;
}
```

These examples demonstrate basic usage of the Confluence API V2 Client library.
Replace placeholders with your actual Confluence email, api-token, and domain.

### Additional Information
For more detailed information, refer to the [GitHub repository](https://github.com/HendrikKoelbel/ConfluenceApi).

Feel free to extend the library or create issues if you encounter any problems. The community and maintainers will be glad to help.
