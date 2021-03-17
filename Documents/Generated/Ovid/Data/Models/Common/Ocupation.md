
Class Description for <strong>Ocupation</strong><hr/>
<table>
<tr><td> Namespace </td><td> Ovid.Data.Models.Common </td></tr>
<tr><td> Class Name </td><td> Ocupation </td></tr>
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
<td>OcupationId</td>
<td>Int64</td>
<td>Record Id</td>
</tr>
<tr>
<td>Name</td>
<td>String</td>
<td>Ocumaption Name</td>
</tr>
<tr>
<td>UserAccounts</td>
<td>ICollection[[UserAccount](Documents/Generated/Ovid/Data/Models/Accounts/UserAccount.md)]</td>
<td>User account Nav</td>
</tr>
</table>


```mermaid
classDiagram
	class Ocupation{
		+Int64 OcupationId
		+String Name
		+ICollection`1 UserAccounts
	}
```


