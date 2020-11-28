using ASPCoreWithAngular.Interfaces;
using ASPCoreWithAngular.Models;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace ASPCoreWithAngular.DataAccess
{
    public class InventoryDataAccessLayer : IInventory
    {
        private string connectionString;
        //public InventoryDataAccessLayer(IConfiguration configuration)
            public InventoryDataAccessLayer()
        {
            //connectionString = configuration["ConnectionStrings:DefaultConnection"];
            connectionString =  "Data Source = (localdb)/MSSQLLocalDB; Initial Catalog = angularDB; Integrated Security = True";
        }

        //To View all item details
        public IEnumerable<InventoryItem> GetAllItems()
        {
            try
            {
                List<InventoryItem> lstitem = new List<InventoryItem>();

                using (SqlConnection con = new SqlConnection(connectionString))
                {
                    SqlCommand cmd = new SqlCommand("spGetAllItems", con);
                    cmd.CommandType = CommandType.StoredProcedure;

                    con.Open();
                    SqlDataReader rdr = cmd.ExecuteReader();

                    while (rdr.Read())
                    {
                        InventoryItem item = new InventoryItem();

                        item.ItemId = Convert.ToInt32(rdr["ItemId"]);
                        item.Name = rdr["Name"].ToString();
                        item.Description = rdr["Description"].ToString();
                        item.Price = Convert.ToDecimal(rdr["Price"]);

                        lstitem.Add(item);
                    }
                    con.Close();
                }
                return lstitem;
            }
            catch
            {
                throw;
            }
        }

        //To Add new item record to inventory
        public int AddItem(InventoryItem item)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(connectionString))
                {
                    SqlCommand cmd = new SqlCommand("spInsertItem", con);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@Name", item.Name);
                    cmd.Parameters.AddWithValue("@Description", item.Description);
                    cmd.Parameters.AddWithValue("@Price", item.Price);

                    con.Open();
                    cmd.ExecuteNonQuery();
                    con.Close();
                }
                return 1;
            }
            catch
            {
                throw;
            }
        }
        

        //Get the details of a particular inventory item
        public InventoryItem GetItemData(int id)
        {
            try
            {
                InventoryItem item = new InventoryItem();

                using (SqlConnection con = new SqlConnection(connectionString))
                {
                    SqlCommand cmd = new SqlCommand("spGetItemDetails", con);
                    cmd.CommandType = CommandType.StoredProcedure;

                    con.Open();
                    SqlDataReader rdr = cmd.ExecuteReader();

                    while (rdr.Read())
                    {
                 
                        item.ItemId = Convert.ToInt32(rdr["ItemId"]);
                        item.Name = rdr["Name"].ToString();
                        item.Description = rdr["Description"].ToString();
                        item.Price = Convert.ToDecimal(rdr["Price"]);
                    }
                }
                return item;
            }
            catch
            {
                throw;
            }
        }

        //To Delete the record on a particular item
        public int DeleteItem(int id)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(connectionString))
                {
                    SqlCommand cmd = new SqlCommand("spDeleteItem", con);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@ItemId", id);

                    con.Open();
                    cmd.ExecuteNonQuery();
                    con.Close();
                }
                return 1;
            }
            catch
            {
                throw;
            }
        }
    }
}
