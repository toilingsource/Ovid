
Class Description for <strong>IntrestList</strong><hr/>
<table>
<tr><td> Namespace </td><td> Ovid.Data.Models.Common </td></tr>
<tr><td> Class Name </td><td> IntrestList </td></tr>
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
<td>IntrestId</td>
<td>Int64</td>
<td>Record Id</td>
</tr>
<tr>
<td>UserIntrests</td>
<td>ICollection[[UserIntrest](Documents/Generated/Ovid/Data/Models/Accounts/UserIntrest.md)]</td>
<td>User Intrest Nav</td>
</tr>
</table>


```mermaid
classDiagram
	class IntrestList{
		+Int64 IntrestId
		+String Intrest
		+ICollection`1 UserIntrests
	}
```


