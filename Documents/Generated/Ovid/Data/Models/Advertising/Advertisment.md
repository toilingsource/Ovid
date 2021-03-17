
Class Description for <strong>Advertisment</strong><hr/>
<table>
<tr><td> Namespace </td><td> Ovid.Data.Models.Advertising </td></tr>
<tr><td> Class Name </td><td> Advertisment </td></tr>
<tr><td> DLL </td><td> Ovid.Data, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null </td></tr>
<tr><td> Base Type </td><td> Ovid.Data.Models.Common.AuditableBase`1[Ovid.Data.Models.Advertising.Advertisment] </td></tr>
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
<td>AddId</td>
<td>Int64</td>
<td>Add Id</td>
</tr>
<tr>
<td>AccountId</td>
<td>String</td>
<td>Account Id</td>
</tr>
<tr>
<td>User</td>
<td>[UserAccount](Documents/Generated/Ovid/Data/Models/Accounts/UserAccount.md)</td>
<td>User Account Nav</td>
</tr>
<tr>
<td>MarketerId</td>
<td>String</td>
<td>Markerter Id</td>
</tr>
<tr>
<td>Markerter</td>
<td>[Marketer](Documents/Generated/Ovid/Data/Models/Marketers/Marketer.md)</td>
<td>Mareter Nav</td>
</tr>
<tr>
<td>AltText</td>
<td>String</td>
<td>Image Alt Text</td>
</tr>
<tr>
<td>AddData</td>
<td>String</td>
<td>Image Data</td>
</tr>
<tr>
<td>Clicks</td>
<td>Int64</td>
<td>Number of Clicks</td>
</tr>
<tr>
<td>Impressions</td>
<td>Int64</td>
<td>Number of Impressions shown</td>
</tr>
<tr>
<td>StartDate</td>
<td>DateTime</td>
<td>Start Date</td>
</tr>
<tr>
<td>EndDate</td>
<td>DateTime</td>
<td>End Date</td>
</tr>
<tr>
<td>AddClicks</td>
<td>ICollection[[UserAddClick](Documents/Generated/Ovid/Data/Models/Advertising/UserAddClick.md)]</td>
<td>Add Clicks Nav</td>
</tr>
</table>


```mermaid
classDiagram
	Advertisment <-- UserAccount
	Advertisment <-- Marketer
	UserAccount <-- AccountType
	UserAccount <-- Ocupation
	UserAccount <-- Salalary
	Marketer <-- UserAccount
	class Advertisment{
		+Int64 AddId
		+String AccountId
		+UserAccount User
		+String MarketerId
		+Marketer Markerter
		+String AltText
		+String AddData
		+Int64 Clicks
		+Int64 Impressions
		+DateTime StartDate
		+DateTime EndDate
		+ICollection`1 AddClicks
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


