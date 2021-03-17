
Class Description for <strong>ProductCategory</strong><hr/>
<table>
<tr><td> Namespace </td><td> Ovid.Data.Models.Products </td></tr>
<tr><td> Class Name </td><td> ProductCategory </td></tr>
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
<td>CategoryId</td>
<td>Int64</td>
<td>Record Id</td>
</tr>
<tr>
<td>Name</td>
<td>String</td>
<td>Catehory Names</td>
</tr>
<tr>
<td>Icon</td>
<td>String</td>
<td>Icon</td>
</tr>
<tr>
<td>Products</td>
<td>ICollection[[SponsoredProduct](Documents/Generated/Ovid/Data/Models/Products/SponsoredProduct.md)]</td>
<td>Product Nav</td>
</tr>
</table>


```mermaid
classDiagram
	class ProductCategory{
		+Int64 CategoryId
		+String Name
		+String Icon
		+ICollection`1 Products
	}
```


