using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Study_Mosh_CSharp_intermediate
{
    public static class Sec5_Ex1to2
    {
        public static void Start()
        {
            SqlConnection sqlCon = new SqlConnection("a sql connection string");
            DbCommand command = new DbCommand(sqlCon);
            command.Execute("SELECT * from hr.employees");

            Console.WriteLine();

            OracleConnection oracleCon = new OracleConnection("an oracle connection string");
            command = new DbCommand(oracleCon);
            command.Execute("SELECT * from hr.employees");
        }
    }

    internal abstract class DbConnection
    {
        public string ConnectionString { get; set; }
        public int Timeout { get; set; }

        public DbConnection(string connectionString)
        {
            if (String.IsNullOrWhiteSpace(connectionString)) throw new ArgumentNullException("connectionString", "connectionString can't be null, empty or a white space");

            ConnectionString = connectionString;
        }

        public abstract void OpenConnection();
        public abstract void CloseConnection();
    }

    internal class SqlConnection : DbConnection
    {
        public SqlConnection(string connectionString) : base(connectionString) 
        {
            // Specific SqlConnection constructor logic goes here...
        }

        public override void CloseConnection()
        {
            Console.WriteLine("SQL database connection closed.");
        }

        public override void OpenConnection()
        {
            Console.WriteLine($"SQL database connection opened ({ConnectionString}).");
        }
    }

    internal class OracleConnection : DbConnection
    {
        public OracleConnection(string connectionString) : base(connectionString)
        {
            // Specific OracleConnection constructor logic goes here...
        }

        public override void CloseConnection()
        {
            Console.WriteLine("Oracle database connection closed.");
        }

        public override void OpenConnection()
        {
            Console.WriteLine($"Oracle database connection opened ({ConnectionString})");
        }
    }

    internal class DbCommand
    {
        public DbConnection DbCon { get; set; }

        public DbCommand(DbConnection dbCon)
        {
            if (dbCon.Equals(null)) throw new ArgumentNullException("dbcon", "dbcon cannot be a null or invalid value");

            this.DbCon = dbCon;
        }

        public void Execute(string instruction)
        {
            DbCon.OpenConnection();
            Console.WriteLine($"Executing instruction: {instruction}");
            DbCon.CloseConnection();
        }
    }
}
