using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Text;

namespace DropDownListColors
{
    public partial class _Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //call the javascript function to keep the color of the dropdownlist
            //se invoca la funcion en javascript que mantiene el color del dropdownlist.
            StringBuilder drpSetColors = new StringBuilder();
            drpSetColors.Append("<script>");
            drpSetColors.Append("drpSetColors('DrpProduct', 'Red', 'color', '" + hfValuesSelectForColor.Value + "','|');");
            drpSetColors.Append("</script>");
            //For Visual 2008 with Ajax we use ScriptManager not clientScript.
            //ScriptManager.RegisterStartupScript(this.Page, this.Page.GetType(), "drpColor", drpSetColors.ToString(), false);
            this.Page.ClientScript.RegisterStartupScript(this.Page.GetType(), "drpColor", drpSetColors.ToString());

            //this view is just to create a datatable to fill the dropdownlist for the first time and to know which item were saved
            //in "real life" you would fill the dropdownlist and the color of the list, with such a storeprocedure.
            //esta vista solo crea un datatable para llenar por primera vez el dropdownlist y para saber cuales item fueron salvados.
            //en la "vida real" se llenaria el dropdownlist y los colores de la lista con por ejemplo un procedimiento almacenado
            if (ViewState["vsTable"] == null)
            {
                DataTable dt = new DataTable();
                // Define the columns of the table.
                dt.Columns.Add(new DataColumn("Text", typeof(String)));
                dt.Columns.Add(new DataColumn("Value", typeof(String)));
                dt.Columns.Add(new DataColumn("IsSave", typeof(String)));
                DataRow dr = dt.NewRow();
                dr["Text"] = "Select";
                dr["Value"] = "0";
                dr["IsSave"] = "0";
                DataRow dr1 = dt.NewRow();
                dr1["Text"] = "Product1";
                dr1["Value"] = "1";
                dr1["IsSave"] = "0";
                DataRow dr2 = dt.NewRow();
                dr2["Text"] = "Product2";
                dr2["Value"] = "2";
                dr2["IsSave"] = "0";
                DataRow dr3 = dt.NewRow();
                dr3["Text"] = "Product3";
                dr3["Value"] = "3";
                dr3["IsSave"] = "0";
                DataRow dr4 = dt.NewRow();
                dr4["Text"] = "Product4";
                dr4["Value"] = "4";
                dr4["IsSave"] = "0";
                dt.Rows.InsertAt(dr,0);
                dt.Rows.InsertAt(dr1,1);
                dt.Rows.InsertAt(dr2,2);
                dt.Rows.InsertAt(dr3,3);
                dt.Rows.InsertAt(dr4, 4);
                ViewState["vsTable"] = dt;
            }

            if (!this.IsPostBack)
            {
                //fill out the list
                //llena la lista
                DataTable dt = (DataTable)ViewState["vsTable"];
                this.drpProduct.DataSource = dt;
                this.drpProduct.DataBind();
                this.drpProductCopy.DataSource = dt;
                this.drpProductCopy.DataBind();
            }
        }

        protected void btnDoPostBack_Click(object sender, EventArgs e)
        {
            //do nothing.
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            //update datatable which is the datasource of drpProduct
            //Actualizo datatable que es la fuente de drpProduct
            DataTable dt = (DataTable)ViewState["vsTable"];
            DataRow[] dr = dt.Select("Value = " + drpProduct.SelectedItem.Value);
            int drIndex = dt.Rows.IndexOf(dr[0]);
            dt.Rows[drIndex]["IsSave"] = "1";
            ViewState["vsTable"] = dt;

            //hfValuesSelectForColor contains the string with the indexes of the listitem color of the dropdowlist
            //hfValuesSelectForColor contiene la cadena con los indices de los listitem coloreados del dropdownlist 
            hfValuesSelectForColor.Value = "";
            //search for the items to be colored and add to hfValuesSelectForColor
            //busco los elementos que deben colorearse y los agrego a hfValuesSelectForColor
            DataRow[] drColors = dt.Select("IsSave = 1");
            for (int i = 0; i < drColors.Length; i++)
            {
                int index = drpProduct.Items.IndexOf(drpProduct.Items.FindByValue(drColors[i]["Value"].ToString()));
                drpProduct.Items[index].Attributes.Add("style", "color: red");
                drpProductCopy.Items[index].Attributes.Add("style", "background-Color: red");
                drpProductCopy.SelectedIndex = index;
                if (hfValuesSelectForColor.Value == "")
                    hfValuesSelectForColor.Value = index.ToString();
                else
                    hfValuesSelectForColor.Value = hfValuesSelectForColor.Value + "|" + index;
            }

        }
    }
}