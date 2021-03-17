
Class Description for <strong>Campaign</strong><hr/>
<table>
<tr><td> Namespace </td><td> Ovid.Data.Models.Campaigns </td></tr>
<tr><td> Class Name </td><td> Campaign </td></tr>
<tr><td> DLL </td><td> Ovid.Data, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null </td></tr>
<tr><td> Base Type </td><td> Ovid.Data.Models.Common.AuditableBase`1[Ovid.Data.Models.Campaigns.Campaign] </td></tr>
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
<td>CampaignId</td>
<td>String</td>
<td>Campaign Id</td>
</tr>
<tr>
<td>TypeId</td>
<td>Int64</td>
<td>Campaign Type Id</td>
</tr>
<tr>
<td>CampaignType</td>
<td>[CampaignType](Documents/Generated/Ovid/Data/Models/Campaigns/CampaignType.md)</td>
<td>Campaign Type Name</td>
</tr>
<tr>
<td>AccountId</td>
<td>String</td>
<td>Account Id</td>
</tr>
<tr>
<td>StartDate</td>
<td>DateTime</td>
<td>Campaign Starts</td>
</tr>
<tr>
<td>EndDate</td>
<td>DateTime</td>
<td>Campaign Ends</td>
</tr>
<tr>
<td>Graphic</td>
<td>String</td>
<td>Banner Image</td>
</tr>
<tr>
<td>Width</td>
<td>Int32</td>
<td>Banner Width</td>
</tr>
<tr>
<td>Height</td>
<td>Int32</td>
<td>Banner Height</td>
</tr>
<tr>
<td>Clicks</td>
<td>Int64</td>
<td>Banner Clicks</td>
</tr>
<tr>
<td>Impressions</td>
<td>Int64</td>
<td>Banner Impressions</td>
</tr>
<tr>
<td>Items</td>
<td>ICollection[[CampaignItem](Documents/Generated/Ovid/Data/Models/Campaigns/CampaignItem.md)]</td>
<td>Items Nav</td>
</tr>
<tr>
<td>UserClicks</td>
<td>ICollection[[UserCampaignClick](Documents/Generated/Ovid/Data/Models/Campaigns/UserCampaignClick.md)]</td>
<td>User Clicks Nav</td>
</tr>
</table>


```mermaid
classDiagram
	Campaign <-- CampaignType
	Campaign <-- UserAccount
	UserAccount <-- AccountType
	UserAccount <-- Ocupation
	UserAccount <-- Salalary
	class Campaign{
		+String CampaignId
		+Int64 TypeId
		+CampaignType CampaignType
		+String AccountId
		+UserAccount User
		+DateTime StartDate
		+DateTime EndDate
		+String Graphic
		+Int32 Width
		+Int32 Height
		+Int64 Clicks
		+Int64 Impressions
		+ICollection`1 Items
		+ICollection`1 UserClicks
	}
	class CampaignType{
		+Int64 TypeId
		+String Name
		+String Description
		+ICollection`1 Campaigns
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


