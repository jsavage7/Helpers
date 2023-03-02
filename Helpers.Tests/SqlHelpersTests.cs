using Helpers.Sql;
using Microsoft.Data.SqlClient;

namespace Helpers.Tests;

/*Table to test with:
 *
 *
USE [Test]
GO
SET ANSI_NULLS ON
    GO

SET QUOTED_IDENTIFIER ON
    GO

CREATE TABLE [dbo].[Table_1](
    [Test] [nvarchar](50) NULL
    ) ON [PRIMARY]
GO

 */

public class SqlHelpersTests
{
    private string ConnectionString { get; set; }
    
    public SqlHelpersTests()
    {
        ConnectionString =
            "Server=localhost;Database=Test;Integrated Security=True;Encrypt=False;";
    }
    
    [Test]
    public void TableExists()
    {
        var sqlHelpers = new SqlHelpers(ConnectionString);
        var result = sqlHelpers.TableExists("Table_1");
        Assert.True(result);
    }
    
    [Test]
    public void ColumnExists()
    {
        var sqlHelpers = new SqlHelpers(ConnectionString);
        var result = sqlHelpers.ColumnExists("Table_1", "Test");
        Assert.True(result);
    }
    
    [Test]
    public void ColumnExistsWithSchema()
    {
        var sqlHelpers = new SqlHelpers(ConnectionString);
        var result = sqlHelpers.ColumnExists("Table_1", "Test", "dbo");
        Assert.True(result);
    }
    
    [Test]
    public void GetDataSet()
    {
        var sqlHelpers = new SqlHelpers(ConnectionString);
        var result = sqlHelpers.GetDataSet("SELECT * FROM Table_1");
        Assert.True(result.Tables.Count > 0);
    }
    
    [Test]
    public void GetDataSetWithParameters()
    {
        var sqlHelpers = new SqlHelpers(ConnectionString);
        var result = sqlHelpers.GetDataSetWithParams("SELECT * FROM Table_1 WHERE Test = @test", new List<SqlParameter> { new SqlParameter("@test", "Test") });
        Assert.True(result.Tables.Count > 0);
    }
}