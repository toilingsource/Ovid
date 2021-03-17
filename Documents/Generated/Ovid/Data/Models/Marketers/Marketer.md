
Class Description for <strong>Marketer</strong><hr/>
<table>
<tr><td> Namespace </td><td> Ovid.Data.Models.Marketers </td></tr>
<tr><td> Class Name </td><td> Marketer </td></tr>
<tr><td> DLL </td><td> Ovid.Data, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null </td></tr>
<tr><td> Base Type </td><td> Ovid.Data.Models.Common.AuditableBase`1[Ovid.Data.Models.Marketers.Marketer] </td></tr>
<table>

<h4>Class Properties</h4>
<hr/>
<table style="width:100%;">
<tr>
<th>Property</th>
<th>Type</th>
<th style="width:40%">Summary</th>
</tr>
<tr>
<td>MarketerId</td>
<td>String</td>
<td>Marketer Id</td>
</tr>
<tr>
<td>Name</td>
<td>String</td>
<td>Manufacture Name</td>
</tr>
<tr>
<td>Logo</td>
<td>String</td>
<td>Logo</td>
</tr>
<tr>
<td>WebSite</td>
<td>String</td>
<td>Main Web Url</td>
</tr>
<tr>
<td>SupportUrl</td>
<td>String</td>
<td>Support Url</td>
</tr>
<tr>
<td>Description</td>
<td>String</td>
<td>Description</td>
</tr>
<tr>
<td>ContactEmail</td>
<td>String</td>
<td>Contact Email</td>
</tr>
<tr>
<td>SupportPhone</td>
<td>String</td>
<td>Support Phone</td>
</tr>
<tr>
<td>UserId</td>
<td>String</td>
<td>Record Creted By</td>
</tr>
<tr>
<td>SponsoredProducts</td>
<td>ICollection[[SponsoredProduct](Documents/Generated/Ovid/Data/Models/Products/SponsoredProduct.md)]</td>
<td>Products Nav</td>
</tr>
<tr>
<td>Advertisments</td>
<td>ICollection[[Advertisment](Documents/Generated/Ovid/Data/Models/Advertising/Advertisment.md)]</td>
<td>Adds Nav</td>
</tr>
</table>


```mermaid
classDiagram
	Marketer <-- UserAccount
	UserAccount <-- AccountType
	UserAccount <-- Ocupation
	UserAccount <-- Salalary
	class Marketer{
		+String MarketerId
		+String Name
		+String Logo
		+String WebSite
		+String SupportUrl
		+String Description
		+String ContactEmail
		+String SupportPhone
		+String UserId
		+UserAccount User
		+ICollection`1 SponsoredProducts
		+ICollection`1 Advertisments
	}
	class UserAccount{
		+String AccountId
		+String UserId
		+String TypeId
		+AccountType AccountType
		+String DisplayName
		+DateTime DateOfBirth
		+String LastLoginIp
		+String Country
		+String Province
		+String City
		+String PostalCode
		+Int64 OcupationId
		+Ocupation Ocupation
		+Int64 SalaryId
		+Salalary Salalary
		+String Avatar
		+Int64 ReputationPoints
		+ICollection`1 UserPosts
		+ICollection`1 PostImages
		+ICollection`1 Ratings
		+ICollection`1 SocialFeeds
		+ICollection`1 Advertisments
		+ICollection`1 Intrests
		+ICollection`1 Followers
		+ICollection`1 Followed
		+ICollection`1 Campaigns
		+ICollection`1 Marketers
		+ICollection`1 UserAddClicks
		+ICollection`1 CampaignClicks
		+ICollection`1 CampaignItemClicks
		+ICollection`1 ProductClicks
		 +GetDataHas() String
	}
	class AccountType{
		+String AccontTypeId
		+String Name
		+String Description
		+ICollection`1 UserAccounts
	}
	class Ocupation{
		+Int64 OcupationId
		+String Name
		+ICollection`1 UserAccounts
	}
	class Salalary{
		+Int64 SalaryId
		+Decimal StartRange
		+Decimal EndRange
		+ICollection`1 UserAccounts
	}
```


