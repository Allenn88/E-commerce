using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Services;


namespace E_commerce.Components
{
    public partial class Details : System.Web.UI.Page
    {
        private string connectionString;
        private SqlConnection conn;
        private string ProductId;

        public Details()
        {
            connectionString = ConfigurationManager.ConnectionStrings["EcommerceCaffe"].ToString();
            conn = new SqlConnection(connectionString);
        }
         protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.QueryString["product"] == null)
            {
                Response.Redirect("Home.aspx");
            }
            ProductId = Request.QueryString["product"].ToString();

            BtnCarrello.HRef = "Carrello.aspx?product=" + ProductId;

            try
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand($@"
                    SELECT *
                    FROM Prodotti
                    WHERE IDProdotto = {ProductId}", conn);
                SqlDataReader dataReader = cmd.ExecuteReader();

                if (dataReader.HasRows)
                {
                    
                    dataReader.Read();
                    TtlName.InnerText = dataReader["Marca"].ToString();
                    LblCategory.InnerText = dataReader["Miscela"].ToString();
                    ImgProduct.Src = dataReader["Foto"].ToString();
                    ParContent.InnerHtml = dataReader["Descrizione"].ToString();
                }
                else
                {
                    Response.Redirect("NotFound.aspx"); 
                   
                }
            }
            catch (Exception ex)
            {
                Response.Write(ex.ToString());
            }
            finally { conn.Close(); }

        }
        protected void BtnAdd_Click(object sender, EventArgs e)
        {
            string productId = Request.QueryString["product"];
            Prodotto prodotto = FetchProductDetails(productId);

            List<Prodotto> carrello;

            if (Session["Carrello"] == null)
            {
                carrello = new List<Prodotto>();
            }
            else
            {
                carrello = Session["Carrello"] as List<Prodotto>;
            }

            carrello.Add(prodotto);

            Session["Carrello"] = carrello;
        }

    public Prodotto FetchProductDetails(string productId)
        {
            Prodotto prodotto = null;

            try
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand($@"
            SELECT *
            FROM Prodotti
            WHERE IDProdotto = {productId}", conn);

                using (SqlDataReader dataReader = cmd.ExecuteReader())
                {
                    if (dataReader.HasRows)
                    {
                        dataReader.Read();
                        prodotto = new Prodotto
                        {
                            IDProdotto = dataReader["IDProdotto"].ToString(),
                            Marca = dataReader["Marca"].ToString(),
                            Miscela = dataReader["Miscela"].ToString(),
                            Foto = dataReader["Foto"].ToString(),
                            Descrizione = dataReader["Descrizione"].ToString(),
                            Prezzo = Convert.ToDecimal(dataReader["Prezzo"])
                        };
                    }
                }
            }
            catch (Exception ex)
            {
                Response.Write(ex.ToString());
            }
            finally
            {
                conn.Close();
            }

            return prodotto;
        }   

        public class Prodotto
        {
            public string IDProdotto { get; set; }
            public string Marca { get; set; }
            public string Miscela { get; set; }
            public string Foto { get; set; }
            public string Descrizione { get; set; }
            public decimal Prezzo { get; set; }

           
  }
    }
}