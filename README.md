# Zoho API V2 Client

This library allows connecting to the Zoho CRM API v2 and requesting the most important entities from there.
* Leads
* Accounts
* Contacts
* Deals

Instead of other library it is using the new version 2 OAuth based API.

## Getting Started

At the begining you need to generate your API access tokens. The easiest way is by following the manual of Zoho: https://www.zoho.com/crm/help/api/v2/#oauth-request

The API client is available as a nuget package and can easily be installed from there.

Creating the client by specifying the secrets you received in the step before:
```
ZohoClient client = new ZohoClient(new Uri("https://accounts.zoho.eu/"), "%ClientId%", "%ClientSecret%", "%RefreshToken%");

```

### Configuring Retry Behavior

You can customize the retry behavior for rate-limited API calls and token refresh operations:

```csharp
// Configure custom retry settings: 5 retries with 3 second base delay
ZohoClient client = new ZohoClient(
    new Uri("https://accounts.zoho.eu/"), 
    "%ClientId%", 
    "%ClientSecret%", 
    "%RefreshToken%",
    asyncTaskTimeout: 5000,      // Default timeout for async operations
    logger: myLogger,             // Optional ILogger instance
    maxRetries: 5,                // Number of retry attempts (default: 3)
    retryDelayBaseMs: 3000        // Base delay in ms, multiplied by attempt number (default: 5000)
);
```

The retry logic uses exponential backoff: first retry after `retryDelayBaseMs`, second after `retryDelayBaseMs * 2`, etc.
For example, with default settings (3 retries, 5000ms base delay):
- 1st retry: 5 seconds delay
- 2nd retry: 10 seconds delay  
- 3rd retry: 15 seconds delay

### Retrieving Objects

Retrieve a list or a single item:
```
Result<Contact> result = client.Contacts.List();
Result<Contact> result2 = client.Contacts.Get("106140000000120145");
```

Adding a new item:
```
client.Contacts.Add(new Connectors.Zoho.Model.Contact() { FirstName="Test" });
```

## Versioning

We use [SemVer](http://semver.org/) for versioning. For the versions available, see the [tags on this repository](https://github.com/your/project/tags). 

## Release Notes

### 3.0.12
- Features: Add configurable retry logic with exponential backoff for token refresh and API operations to handle rate limits gracefully.
- Features: Consumers can now customize retry count (default: 3) and backoff delay (default: 5000ms) via constructor parameters.
- Features: Improve test suite with intelligent pagination checks using MoreRecords metadata before attempting to load page 2.
- Features: Optimize test performance by sharing ZohoClient and token across all tests using AssemblyInitialize, reducing unnecessary API calls.
- Bug fixes: Fix token refresh failing when rate limited - now automatically retries with configurable delays.

### 3.0.11
- Features: Update Libraries

### 3.0.10
- Features: Add Products module and related lists.
- Bug fixes: None.

### 3.0.9
- Features: Add new `Visible Note` field to `Recurrings`.
- Bug fixes: None.

### 3.0.7 (public token handling)
- Features: Update libraries.
- Bug fixes: Improve `ExpiryIn` handling in token (public).

### 3.0.7 (protected token handling)
- Features: Update libraries.
- Bug fixes: Improve `ExpiryIn` handling in token (protected).

### 3.0.6
- Features: Update libraries.
- Bug fixes: Fix date field handling.

### 3.0.5
- Features: Add rename field in `Recurring` to `Terminated`.
- Bug fixes: None.

### 3.0.4
- Features: Add `RmaProject` (`Recurring`).
- Bug fixes: None.

### 3.0.3
- Features: Add `Reference` field (`Recurring`).
- Bug fixes: None.

### 3.0.2
- Features: Add `Recurrings` and update `RestSharp`.
- Bug fixes: None.

### 3.0.1
- Features: None.
- Bug fixes: Throw exception on invalid token.

### 3.0.0
- Features: Change to .NET 8 and update libraries.
- Bug fixes: None.

### 2.0.6
- Features: None.
- Bug fixes: Fix `employee` null handling.

### 2.0.4
- Features: Change `ResourcePlan` employee field to new picklist `Preferred_Employee`.
- Bug fixes: None.

### 2.0.3
- Features: None.
- Bug fixes: Fix `resourceplan`.

### 2.0.2
- Features: Add new custom module `ResourcePlan`.
- Bug fixes: None.

### 2.0.1
- Features: Stable release with new libraries and added support for async usage.
- Bug fixes: None.

### 2.0.0-alpha
- Features: Use `RestSharp 107` and `JSONNet 13`.
- Bug fixes: None.

### 1.0.12
- Features: Add new fields (`SignedNDA`) to accounts.
- Bug fixes: None.

### 1.0.11
- Features: None.
- Bug fixes: Fix handling when `Amount` is null.

### 1.0.10
- Features: Add new fields to accounts.
- Bug fixes: None.

### 1.0.9
- Features: Add trigger properties so workflows are triggered on add or update.
- Bug fixes: None.

### 1.0.7
- Features: Improve access token caching and reliability.
- Bug fixes: None.

### 1.0.6
- Features: Allow specifying the access token if already available (helpful for stateless systems like Azure Functions).
- Bug fixes: None.

### 1.0.5
- Features: Make `ShouldSerialize` methods virtual to allow override.
- Bug fixes: None.

### 1.0.4
- Features: Update `RestSharp` and `JSON.NET`.
- Bug fixes: None.

### 1.0.3
- Features: Add `Unknown` enum value fallback when API value is not available in enum.
- Bug fixes: Fix enum value conversion.

### 1.0.2
- Features: None.
- Bug fixes: Fix enum value for lead source.

### 1.0.1
- Features: None.
- Bug fixes: Fix enum value for account rating.

### 1.0.0
- Features: First version.
- Bug fixes: None.

## Release documentation

Every release must include a new entry in the `PackageReleaseNotes` field of the `.csproj` and describe the same changes in this README so users can see what was updated without unpacking the package.

## Authors

* **Thomas Kurth** - *Initial work* 

## License

This project is licensed under the MIT License - see the [LICENSE.md](LICENSE.md) file for details

