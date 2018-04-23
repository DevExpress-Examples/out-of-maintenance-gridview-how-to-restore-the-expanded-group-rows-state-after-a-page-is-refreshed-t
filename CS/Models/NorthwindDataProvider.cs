using System.Data;
using System.Data.SqlClient;
using System.Web.Configuration;

public class NorthwindDataProvider {
    public static object GetOrders() {
        SqlConnection connection = new SqlConnection(WebConfigurationManager.ConnectionStrings["NorthwindConnectionString"].ConnectionString);
        SqlCommand selectCommand = new SqlCommand("SELECT [OrderID], [CustomerID], [EmployeeID], [OrderDate], [RequiredDate], [ShippedDate] FROM [Orders]");
        SqlDataAdapter da = new SqlDataAdapter(selectCommand);
        DataSet ds = new DataSet();
        
        selectCommand.Connection = connection;
        da.Fill(ds, "Orders");

        return ds.Tables[0];
    }
}