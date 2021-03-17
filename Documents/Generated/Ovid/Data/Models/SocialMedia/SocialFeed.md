
Class Description for <strong>SocialFeed</strong><hr/>
<table>
<tr><td> Namespace </td><td> Ovid.Data.Models.SocialMedia </td></tr>
<tr><td> Class Name </td><td> SocialFeed </td></tr>
<tr><td> DLL </td><td> Ovid.Data, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null </td></tr>
<tr><td> Base Type </td><td> Ovid.Data.Models.Common.AuditableBase`1[Ovid.Data.Models.SocialMedia.SocialFeed] </td></tr>
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
<td>FeedId</td>
<td>Int64</td>
<td>Feed Id</td>
</tr>
<tr>
<td>AccountId</td>
<td>String</td>
<td>Accoutn</td>
</tr>
<tr>
<td>User</td>
<td>[UserAccount](Documents/Generated/Ovid/Data/Models/Accounts/UserAccount.md)</td>
<td>User Account nav</td>
</tr>
<tr>
<td>Provider</td>
<td>String</td>
<td>Provider</td>
</tr>
<tr>
<td>PullFeeds</td>
<td>Boolean</td>
<td>Pull Feeds</td>
</tr>
<tr>
<td>CrossPost</td>
<td>Boolean</td>
<td>Cross Post feeds from this site</td>
</tr>
<tr>
<td>Followers</td>
<td>Int64</td>
<td>Current Followers</td>
</tr>
<tr>
<td>Link</td>
<td>String</td>
<td>External Link</td>
</tr>
</table>


```mermaid
classDiagram
	SocialFeed <-- UserAccount
	UserAccount <-- AccountType
	UserAccount <-- Ocupation
	UserAccount <-- Salalary
	class SocialFeed{
		+Int64 FeedId
		+String AccountId
		+UserAccount User
		+String Provider
		+Boolean PullFeeds
		+Boolean CrossPost
		+Int64 Followers
		+String Link
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


