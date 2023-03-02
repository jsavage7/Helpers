using System.Data;
using Microsoft.Data.SqlClient;

namespace Helpers.Sql;

public class SqlHelpers
{
    private string ConnectionString { get; set; }
    
    public SqlHelpers(string connectionString)
    {
        ConnectionString = connectionString;
    }
    
    public bool TableExists(string tableName)
    {
        using var connection = new SqlConnection(ConnectionString);
        connection.Open();
        
        var cmd = new SqlCommand("SELECT COUNT(*) FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME = @tableName", connection);
        cmd.Parameters.AddWithValue("@tableName", tableName);
        
        var count = (int)cmd.ExecuteScalar();
        
        return count > 0;
    }
    
    public bool ColumnExists(string tableName, string columnName)
    {
        using var connection = new SqlConnection(ConnectionString);
        connection.Open();
        
        var cmd = new SqlCommand("SELECT COUNT(*) FROM INFORMATION_SCHEMA.COLUMNS WHERE TABLE_NAME = @tableName AND COLUMN_NAME = @columnName", connection);
        cmd.Parameters.AddWithValue("@tableName", tableName);
        cmd.Parameters.AddWithValue("@columnName", columnName);
        
        var count = (int)cmd.ExecuteScalar();
        
        return count > 0;
    }
    
    public bool ColumnExists(string tableName, string columnName, string schemaName)
    {
        using var connection = new SqlConnection(ConnectionString);
        connection.Open();
        
        var cmd = new SqlCommand("SELECT COUNT(*) FROM INFORMATION_SCHEMA.COLUMNS WHERE TABLE_NAME = @tableName AND COLUMN_NAME = @columnName AND TABLE_SCHEMA = @schemaName", connection);
        cmd.Parameters.AddWithValue("@tableName", tableName);
        cmd.Parameters.AddWithValue("@columnName", columnName);
        cmd.Parameters.AddWithValue("@schemaName", schemaName);
        
        var count = (int)cmd.ExecuteScalar();
        
        return count > 0;
    }
    
    public DataSet GetDataSet(string sql)
    {
        using var connection = new SqlConnection(ConnectionString);
        connection.Open();
        
        var cmd = new SqlCommand(sql, connection);
        var da = new SqlDataAdapter(cmd);
        var ds = new DataSet();
        
        da.Fill(ds);
        
        return ds;
    }
    
    public DataSet GetDataSetWithParams(string sql, List<SqlParameter> parameters)
    {
        using var connection = new SqlConnection(ConnectionString);
        connection.Open();
        
        var cmd = new SqlCommand(sql, connection);
        
        foreach (var parameter in parameters)
        {
            cmd.Parameters.Add(parameter);
        }
        
        var da = new SqlDataAdapter(cmd);
        var ds = new DataSet();
        
        da.Fill(ds);
        
        return ds;
    }
    
    public int ExecuteNonQuery(string sql)
    {
        using var connection = new SqlConnection(ConnectionString);
        connection.Open();
        
        var cmd = new SqlCommand(sql, connection);
        
        return cmd.ExecuteNonQuery();
    }
    
    public int ExecuteNonQueryWithParams(string sql, List<SqlParameter> parameters)
    {
        using var connection = new SqlConnection(ConnectionString);
        connection.Open();
        
        var cmd = new SqlCommand(sql, connection);
        
        foreach (var parameter in parameters)
        {
            cmd.Parameters.Add(parameter);
        }
        
        return cmd.ExecuteNonQuery();
    }
}