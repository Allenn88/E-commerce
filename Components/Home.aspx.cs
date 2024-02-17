using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace E_commerce.Components
{
    public partial class Home : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string connectionString = ConfigurationManager.ConnectionStrings["EcommerceCaffe"].ToString();
            SqlConnection conn = new SqlConnection(connectionString);

            try
            {
                conn.Open();              
                SqlCommand cmd = new SqlCommand("SELECT * FROM Prodotti", conn);
                SqlDataReader dataReader = cmd.ExecuteReader();
                string htmlContent = "";
                if (dataReader.HasRows)
                {
                    while (dataReader.Read())
                    {
                        htmlContent += $@"<div class=""col"">
                <div class=""card h-100"">
                  <img src=""{dataReader["Foto"]}"" class=""card-img-top"" alt=""{dataReader["Marca"]}"">
                  <div class=""card-body"">
                    <h5 class=""card-title"">{$"{dataReader["Marca"]} {dataReader["Miscela"]}"}</h5>
                    <p class=""card-text"">{dataReader["Prezzo"]}</p>
                    <a href=""Details.aspx?product={dataReader["IDProdotto"]}"" class=""btn btn-primary"">Dettagli</a>
                  </div>
                </div>
            </div>";
                    }
                }   
                RowCards.InnerHtml = htmlContent;
            }
            catch (Exception ex)
            {
                Response.Write($"Errore: {ex.Message}");
            }
            finally
            {
                if (conn.State == ConnectionState.Open)
                {
                    conn.Close();
                }
            }

        }
    }
}