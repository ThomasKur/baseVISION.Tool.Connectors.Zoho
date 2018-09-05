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

### Retrieving Objects

Retrieve a list or a single item:
```
Result<Contact> result = client.Contacts.List();
Result<Contact> result2 = client.Contacts.Get("106140000000120145");
```

Adding a new item
```
client.Contacts.Add(new Connectors.Zoho.Model.Contact() { FirstName="Test" });
```

## Versioning

We use [SemVer](http://semver.org/) for versioning. For the versions available, see the [tags on this repository](https://github.com/your/project/tags). 

## Authors

* **Thomas Kurth** - *Initial work* 

## License

This project is licensed under the MIT License - see the [LICENSE.md](LICENSE.md) file for details

## Acknowledgments

* Hat tip to anyone whose code was used
* Inspiration
* etc
