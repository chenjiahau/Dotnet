using System.Data;
using Dapper;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;

namespace HelloWorld.Data
{
  public class DataContextDapper
  {
    private IConfiguration _config;

    public DataContextDapper(IConfiguration config)
    {
      _config = config;
    }

    public IEnumerable<T> LoadData<T>(string sql)
    {
      IDbConnection db = new SqlConnection(_config.GetConnectionString("DefaultConnection"));
      return db.Query<T>(sql);
    }

    public T LoadDataSingle<T>(string sql)
    {
      IDbConnection db = new SqlConnection(_config.GetConnectionString("DefaultConnection"));
      return db.QuerySingle<T>(sql);
    }

    public int ExecuteSql(string sql)
    {
      IDbConnection db = new SqlConnection(_config.GetConnectionString("DefaultConnection"));
      return db.Execute(sql);
    }
  }
}