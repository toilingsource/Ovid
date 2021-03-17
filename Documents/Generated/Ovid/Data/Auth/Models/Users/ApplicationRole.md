
Class Description for <strong>ApplicationRole</strong><hr/>
<table>
<tr><td> Namespace </td><td> Ovid.Data.Auth.Models.Users </td></tr>
<tr><td> Class Name </td><td> ApplicationRole </td></tr>
<tr><td> DLL </td><td> Ovid.Data, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null </td></tr>
<tr><td> Base Type </td><td> Microsoft.AspNetCore.Identity.IdentityRole`1[System.String] </td></tr>
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
<td>Users</td>
<td>ICollection[[IdentityUserRole`1](Documents/Generated/Microsoft/AspNetCore/Identity/IdentityUserRole`1.md)]</td>
<td>Navigation property for the users in this role.</td>
</tr>
<tr>
<td>Claims</td>
<td>ICollection[[IdentityRoleClaim`1](Documents/Generated/Microsoft/AspNetCore/Identity/IdentityRoleClaim`1.md)]</td>
<td>Navigation property for claims in this role.</td>
</tr>
</table>


```mermaid
classDiagram
	class ApplicationRole{
		+ICollection`1 Users
		+ICollection`1 Claims
	}
```


