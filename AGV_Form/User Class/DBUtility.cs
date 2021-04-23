using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AGV_Form
{
    class DBUtility
    {
        public static dynamic GetDataFromDB<T>(string tableName)
        {
            List<Node> listNode = new List<Node>();
            DataTable table = new DataTable();
            string connectionStr = @"Data Source=DESKTOP-TN7L9R8\PERFECT;
                                    Initial Catalog=AGV_Datasource;Integrated Security=True";
            using (SqlConnection connection = new SqlConnection(connectionStr))
            {
                //SqlComnection
                connection.Open();

                //SqlCommand
                SqlCommand command = connection.CreateCommand();
                command.CommandText = "select * from " + tableName;

                //SqlAdapter
                SqlDataAdapter adapter = new SqlDataAdapter(command);

                //Get data
                table.Clear();
                adapter.Fill(table);
                connection.Close();
            }

            // Store DataTable into a List
            // Note: listNode[i].ID = i so instead of using ID, use i 
            // (because of the order of the rows in table)
            listNode = (from DataRow dr in table.Rows
                        select new Node()
                        {
                            ID = Convert.ToInt32(dr["Node"]),
                            X = Convert.ToInt32(dr["pos_X"]),
                            Y = Convert.ToInt32(dr["pos_Y"]),
                            AdjacentNode = (dr["AdjacentNode"].ToString()).
                                            Split(new char[] { ';', ' ' }, StringSplitOptions.RemoveEmptyEntries),
                            LocationCode = dr["LocationCode"].ToString()
                        }).ToList();

            if (typeof(T) == typeof(DataTable)) return table;
            else if (typeof(T) == typeof(List<Node>)) return listNode;
            else return null;
        }
    }
}

