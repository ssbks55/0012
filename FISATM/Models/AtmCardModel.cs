using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;


namespace FISATM.Models
{
    public class AtmCardModel
    {
        [Required(ErrorMessage = "Invalid card number.")]
        public int CardNumber { get; set; }

        public CardDetail GetCardDetail(int cardNumber)
        {

            // Create the connection.
            using (SqlConnection connection = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString))
            {

                try
                {
                    connection.Open();
                    DataTable dt = new DataTable();
                    string sqlText = "Select * from carddetails where cardnumber = " + cardNumber;


                    SqlCommand cmd = new SqlCommand(sqlText, connection);
                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    da.Fill(dt);


                    List<CardDetail> studentDetails = new List<CardDetail>();
                    studentDetails = DatatableToModelConverter.ConvertDataTable<CardDetail>(dt);
                    return studentDetails.First();
                }
                catch (Exception ex)
                {

                }
                finally
                {
                    connection.Close();
                }

            }

            return new CardDetail();
        }

    }

    public class CardDetail
    {
        public int Id { get; set; }
        public int CardNumber { get; set; }
        public bool IsActivated { get; set; }
    }
}