using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.UI.WebControls;
using static E_commerce.Components.Details;

namespace E_commerce.Components
{
    public partial class Carrello : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
               
               
               var carrello = Session["Carrello"] as List<Details.Prodotto>;


                if (carrello != null)
                {
                   
                    RptCarrello.DataSource = carrello;
                    RptCarrello.DataBind();
                    UpdateCartTotal();
                }
            }
        }
        protected void BtnDelete_Click(object sender, EventArgs e)
        {
            Button btnDelete = (Button)sender;
            string productId = btnDelete.CommandArgument;

            List<Details.Prodotto> carrello = Session["Carrello"] as List<Details.Prodotto>;

            if (carrello != null)
            {
                Details.Prodotto prodottoToRemove = carrello.Find(p => p.IDProdotto == productId);
                carrello.Remove(prodottoToRemove);
                Session["Carrello"] = carrello;
                RptCarrello.DataSource = carrello;
                RptCarrello.DataBind();
                UpdateCartTotal();
            }
        }
        private void UpdateCartTotal()
        {
            decimal total = CalculateTotal();
            LblTotale.Text = total.ToString("C");
        }

        private decimal CalculateTotal()
        {
            List<Details.Prodotto> carrello = Session["Carrello"] as List<Details.Prodotto>;

            if (carrello != null && carrello.Count > 0)
            {
                decimal total = carrello.Sum(p => p.Prezzo);
                return total;
            }

            return 0.00m;
        }
    }
}
