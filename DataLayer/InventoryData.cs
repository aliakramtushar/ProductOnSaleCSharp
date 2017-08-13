using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entities;
using Framework;

namespace DataLayer
{
    public class InventoryData
    {
        DataAccess _da = new DataAccess();
        public void Insert(Product _product)
        {
            string insertCommand = "INSERT INTO Product_Details (Product_Name, Catagory, Stocked, Buy_Price, Sell_Price) " +
                                   "VALUES (@Name,@Catagory,@Quantity,@BuyPrice,@SellPrice)";
            SqlCommand command = new SqlCommand(insertCommand);
            SqlParameter nameParameter = new SqlParameter("@Name", SqlDbType.NVarChar, 50);
            nameParameter.Value = _product.name;
            SqlParameter CatagoryParameter = new SqlParameter("@Catagory", SqlDbType.NVarChar, 50);
            CatagoryParameter.Value = _product.catagory;
            SqlParameter quantityParameter = new SqlParameter("@Quantity", SqlDbType.Int);
            quantityParameter.Value = _product.quantities;
            SqlParameter buyPriceParameter = new SqlParameter("@BuyPrice", SqlDbType.Float);
            buyPriceParameter.Value = _product.sell_price;
            SqlParameter sellPriceParameter = new SqlParameter("@SellPrice", SqlDbType.Float);
            sellPriceParameter.Value = _product.totalprice;
            command.Parameters.Add(nameParameter);
            command.Parameters.Add(CatagoryParameter);
            command.Parameters.Add(quantityParameter);
            command.Parameters.Add(buyPriceParameter);
            command.Parameters.Add(sellPriceParameter);

            _da.InventoryExecute(command);
        }

        public void Delete(Product _product)
        {
            string insertCommand = "DELETE Product_Details " +
                                   "WHERE Product_Id = @ID";
            SqlCommand command = new SqlCommand(insertCommand);
            SqlParameter idParameter = new SqlParameter("@ID", SqlDbType.Int);
            idParameter.Value = _product.id;

            command.Parameters.Add(idParameter);

            _da.InventoryExecute(command);
        }

        public void Update(Product _product)
        {
            string insertCommand = "UPDATE Product_Details SET Product_Name = @Name, Catagory = @Catagory, Stocked = @Quantity, Buy_Price = @BuyPrice, Sell_Price = @Sellprice " +
                                   "WHERE Product_Id = @ID";
            SqlCommand command = new SqlCommand(insertCommand);
            SqlParameter idParameter = new SqlParameter("@ID", SqlDbType.Int);
            idParameter.Value = _product.id;
            SqlParameter nameParameter = new SqlParameter("@Name", SqlDbType.NVarChar, 50);
            nameParameter.Value = _product.name;
            SqlParameter CatagoryParameter = new SqlParameter("@Catagory", SqlDbType.NVarChar, 50);
            CatagoryParameter.Value = _product.catagory;
            SqlParameter quantityParameter = new SqlParameter("@Quantity", SqlDbType.Int);
            quantityParameter.Value = _product.quantities;
            SqlParameter buyPriceParameter = new SqlParameter("@BuyPrice", SqlDbType.Float);
            buyPriceParameter.Value = _product.sell_price;
            SqlParameter sellPriceParameter = new SqlParameter("@SellPrice", SqlDbType.Float);
            sellPriceParameter.Value = _product.totalprice;
            //command.Parameters.Add(idParameter);
            command.Parameters.Add(nameParameter);
            command.Parameters.Add(CatagoryParameter);
            command.Parameters.Add(quantityParameter);
            command.Parameters.Add(buyPriceParameter);
            command.Parameters.Add(sellPriceParameter);

            _da.InventoryExecute(command);
        }

    }
}
