
Class Description for <strong>CampaignItem</strong><hr/>
<table>
<tr><td> Namespace </td><td> Ovid.Data.Models.Campaigns </td></tr>
<tr><td> Class Name </td><td> CampaignItem </td></tr>
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
<td>CampItemId</td>
<td>Int64</td>
<td>Record Id</td>
</tr>
<tr>
<td>CampaignId</td>
<td>String</td>
<td>Campaign</td>
</tr>
<tr>
<td>ProductId</td>
<td>String</td>
<td>Product</td>
</tr>
<tr>
<td>SalePrice</td>
<td>Decimal</td>
<td>Sale Price</td>
</tr>
<tr>
<td>RegularPrice</td>
<td>Decimal</td>
<td>Reqular Price</td>
</tr>
<tr>
<td>SalesText</td>
<td>String</td>
<td>Sale tag line or text (optional)</td>
</tr>
<tr>
<td>CampaignLink</td>
<td>String</td>
<td>Affiliate Link</td>
</tr>
<tr>
<td>Clicks</td>
<td>Int64</td>
<td>Affiliiate Link Clicks</td>
</tr>
<tr>
<td>ItemClicks</td>
<td>ICollection[[UserCampaignItemClick](Documents/Generated/Ovid/Data/Models/Campaigns/UserCampaignItemClick.md)]</td>
<td>Campaign Item Nav</td>
</tr>
</table>


```mermaid
classDiagram
	CampaignItem <-- Campaign
	CampaignItem <-- SponsoredProduct
	Campaign <-- CampaignType
	Campaign <-- UserAccount
	SponsoredProduct <-- Marketer
	SponsoredProduct <-- ProductCategory
	UserAccount <-- AccountType
	UserAccount <-- Ocupation
	UserAccount <-- Salalary
	Marketer <-- UserAccount
	class CampaignItem{
		+Int64 CampItemId
		+String CampaignId
		+Campaign Campaign
		+String ProductId
		+SponsoredProduct Product
		+Decimal SalePrice
		+Decimal RegularPrice
		+String SalesText
		+String CampaignLink
		+Int64 Clicks
		+ICollection`1 ItemClicks
	}
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
	class SponsoredProduct{
		+String ProductId
		+String MarkerterId
		+Marketer Marketer
		+Int64 CategoryId
		+ProductCategory Category
		+String Name
		+String ProductLink
		+String Description
		+String Infromation
		+Decimal Price
		+Decimal InfulencePrice
		+Int64 NumberSold
		+String KeyWords
		+ICollection`1 Images
		+ICollection`1 ProductClicks
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
	class ProductCategory{
		+Int64 CategoryId
		+String Name
		+String Icon
		+ICollection`1 Products
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


