
Class Description for <strong>Followed</strong><hr/>
<table>
<tr><td> Namespace </td><td> Ovid.Data.Models.Accounts </td></tr>
<tr><td> Class Name </td><td> Followed </td></tr>
<tr><td> DLL </td><td> Ovid.Data, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null </td></tr>
<tr><td> Base Type </td><td> System.Object </td></tr>
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
<td>UserIntrestId</td>
<td>Int64</td>
<td>Intrest Id</td>
</tr>
<tr>
<td>AccountId</td>
<td>String</td>
<td>Account</td>
</tr>
<tr>
<td>IntrestId</td>
<td>Int64</td>
<td>Intrest</td>
</tr>
</table>


```mermaid
classDiagram
	UserIntrest <-- UserAccount
	UserIntrest <-- IntrestList
	UserAccount <-- AccountType
	UserAccount <-- Ocupation
	UserAccount <-- Salalary
	class UserIntrest{
		+Int64 UserIntrestId
		+String AccountId
		+UserAccount User
		+Int64 IntrestId
		+IntrestList Intrest
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
	class IntrestList{
		+Int64 IntrestId
		+String Intrest
		+ICollection`1 UserIntrests
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


