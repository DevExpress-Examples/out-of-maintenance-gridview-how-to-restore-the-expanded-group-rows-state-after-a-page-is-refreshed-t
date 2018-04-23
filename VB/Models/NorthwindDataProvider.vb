Imports System.Data
Imports System.Data.SqlClient
Imports System.Web.Configuration

Public Class NorthwindDataProvider
	Public Shared Function GetOrders() As Object
		Dim connection As New SqlConnection(WebConfigurationManager.ConnectionStrings("NorthwindConnectionString").ConnectionString)
		Dim selectCommand As New SqlCommand("SELECT [OrderID], [CustomerID], [EmployeeID], [OrderDate], [RequiredDate], [ShippedDate] FROM [Orders]")
		Dim da As New SqlDataAdapter(selectCommand)
		Dim ds As New DataSet()

		selectCommand.Connection = connection
		da.Fill(ds, "Orders")

		Return ds.Tables(0)
	End Function
End Class