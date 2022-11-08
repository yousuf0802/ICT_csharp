using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MetalappsAutomation 
{
 public class Metalapps           
 {
  
   public SqlConnection SqlCon{ get; set;}
  
   DBHandler db = new DBHandler();
  
  public void AddSalesDetails(SalesDetails sd)
  {
   SqlCon=db.GetConnection();
   
   SqlCon.Open();
   
   SqlCommand cmd = new SqlCommand("insert into SalesDetails values(@Sales_id,@Customer_name,@Noof_units,@Net_amount)",SqlCon);
   cmd.Parameters.AddWithValue("@Sales_id",sd.SalesId);
   cmd.Parameters.AddWithValue("@Customer_name", sd.CustomerName);
   cmd.Parameters.AddWithValue("@Noof_units", sd.NoOfUnits);
   cmd.Parameters.AddWithValue("@Net_amount", sd.NetAmount);
   cmd.ExecuteNonQuery();


   SqlCon.Close();
  }

  public void CalculateNetAmount(SalesDetails details)
  {
   int units = details.NoOfUnits;
   

   if (units <= 5)
    details.NetAmount = 75350 * units;
   else if (units > 5 && units <= 10)
    details.NetAmount = 75350 * units * 0.98;
   else if(units> 10 && units<= 15)
    details.NetAmount = 75350 * units * 0.95;
   else if (units> 15 && units<= 20)
    details.NetAmount = 75350 * units * 0.92;
   else if (units >20)
    details.NetAmount = 75350 * units * 0.90;
            
            
  }
  
  
 }
}