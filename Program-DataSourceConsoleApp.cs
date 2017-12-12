using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;

namespace DataSourceConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            string connString = "Data Source=(local); Initial Catalog=VivekTest; Integrated Security=true";
            SqlConnection con = new SqlConnection(connString);

            string query = "SELECT * FROM dbo.Student;";

            SqlCommand comm = new SqlCommand(query, con);
            con.Open();
            SqlDataReader reader = comm.ExecuteReader();

            while(reader.Read())
            {
                Console.WriteLine(reader[0] + " " + reader[1] + " " + reader[2]);
            }

            Console.ReadLine();
            reader.Close();

            DataTable schemaTable;
            SqlDataReader myReader;

            myReader = comm.ExecuteReader(CommandBehavior.KeyInfo);
            schemaTable = myReader.GetSchemaTable();

            foreach(DataRow myField in schemaTable.Rows)
            {
                foreach(DataColumn myProperty in schemaTable.Columns)
                {
                    Console.WriteLine(myProperty.ColumnName + " = " + myField[myProperty].ToString());
                    //Console.ReadLine();
                }
                Console.WriteLine();

            }
            Console.ReadLine();
            myReader.Close();
            con.Close();
        }
    }
}
