using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using RestaurantApp.Models;

namespace RestaurantApp.Controllers.api
{
    public class TableController : ApiController
    {
        static string stringConnection = "Data Source=SHIMONSAMAY;Initial Catalog=RestaurantDB;Integrated Security=True;Pooling=False";
        
        public IHttpActionResult Get()
        {
            try
            {
                return Ok(getAllTables(stringConnection));
            }
            catch(SqlException x)
            {
                return BadRequest(x.Message);
            }
            catch (Exception x)
            {
                return BadRequest(x.Message);
            }
        }

        
        public IHttpActionResult Get(int id)
        {
            try
            {
                return Ok(GetTable(id , stringConnection));
            }
            catch (SqlException x)
            {
                return BadRequest(x.Message);
            }
            catch (Exception x)
            {
                return BadRequest(x.Message);
            }
        }

        
        public IHttpActionResult Post([FromBody]ResTable value)
        {
            try
            {
                addTable(stringConnection, value);
                return Ok(getAllTables(stringConnection));
            }
            catch (SqlException x)
            {
                return BadRequest(x.Message);
            }
            catch (Exception x)
            {
                return BadRequest(x.Message);
            }

        }

       
        public IHttpActionResult Put(int id, [FromBody] ResTable value)
        {
            try
            {
                updateTables( stringConnection , value , id );
                return Ok(getAllTables(stringConnection));
            }
            catch (SqlException x)
            {
                return BadRequest(x.Message);
            }
            catch (Exception x)
            {
                return BadRequest(x.Message);
            }
        }

        
        public IHttpActionResult Delete(int id)
        {
            try
            {
                deleteTable(id,stringConnection);
                return Ok(getAllTables(stringConnection));
            }
            catch (SqlException x)
            {
                return BadRequest(x.Message);
            }
            catch (Exception x)
            {
                return BadRequest(x.Message);
            }
        }








         List<ResTable> getAllTables(string connection)
        {
            List<ResTable> tablesList = new List<ResTable>();
            using(SqlConnection DBconnection = new SqlConnection(connection))
            {
                DBconnection.Open();
                string query = "SELECT * FROM ResTables";
                SqlCommand command = new SqlCommand(query, DBconnection);
                SqlDataReader Data = command.ExecuteReader();
                if (Data.HasRows)
                {
                    while (Data.Read())
                    {
                        tablesList.Add(new ResTable(Data.GetInt32(0), Data.GetInt32(1), Data.GetInt32(2), Data.GetBoolean(3), Data.GetInt32(4)));
                        
                    }
                        DBconnection.Close();
                        return tablesList;

                }
                       return tablesList;
            }

        }

         ResTable GetTable (int id , string connection)
        {
            ResTable table = new ResTable();
            using(SqlConnection DBconnection = new SqlConnection(connection))
            {
                DBconnection.Open();
                string query = $@"SELECT * FROM ResTables Where Id = {id}";
                SqlCommand command = new SqlCommand(query,DBconnection);
                SqlDataReader Data = command.ExecuteReader();
                if (Data.HasRows)
                {
                    while (Data.Read())
                    {
                        table = new ResTable(Data.GetInt32(0), Data.GetInt32(1), Data.GetInt32(2), Data.GetBoolean(3), Data.GetInt32(4));
                    }
                    DBconnection.Close();
                    return table;
                }
                return table;
            }
        }

         void addTable (string connection , ResTable table)
        {
            using (SqlConnection DBconnection = new SqlConnection( connection))
            {
                DBconnection.Open ();
                string query = $@"INSERT INTO ResTables (TableNumber , TableSize , IsAvalabile , Seats)
                               VALUES ({table.TableNumber}, {table.TableSize},'{table.IsAvalabile}',{table.Seats})";
                SqlCommand command = new SqlCommand(query, DBconnection);
                command.ExecuteNonQuery();
                DBconnection.Close();
            }
        }

         void updateTables (string connection, ResTable table , int id)
        {
            using(SqlConnection DBconnection = new SqlConnection(connection))
            {
                DBconnection.Open();
                string query = $@"UPDATE ResTables
                                  SET TableNumber = {table.TableNumber} ,
                                      TableSize = {table.TableSize} ,
                                      IsAvalabile = '{table.IsAvalabile}' , 
                                      Seats = {table.Seats}
                                   WHERE Id = {id} ";
                SqlCommand command = new SqlCommand(query,DBconnection);
                command.ExecuteNonQuery ();
                DBconnection.Close();
            }
        }

         void deleteTable (int id, string connection)
        {
            using(SqlConnection DBconnection = new SqlConnection(connection))
            {
                DBconnection.Open();
                string query = $@"DELETE FROM ResTables WHERE Id = {id}";
                SqlCommand command = new SqlCommand(query, DBconnection);
                command.ExecuteNonQuery ();
                DBconnection.Close ();
            }
        }










    }
}
