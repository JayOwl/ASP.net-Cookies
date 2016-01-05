using System;
using System.Collections.Generic;

using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ColorPersistanceExample
{
    public partial class ColorPersistance : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            // When the page is being rendered, check if the Cookie exists, if so set the DropDown choice and the background
            if (!IsPostBack && Request.Cookies.Get("Color") != null)
            {
                // The cookie was found, get the value
                var color = Request.Cookies.Get("Color").Value;

                // Select the appropriate Dropdown item
                Color.SelectedIndex = Color.Items.IndexOf(Color.Items.FindByValue(color));

                // Set the background
                body.Style["background"] = color;
            }
        }

        protected void ApplyPattern_Click(object sender, EventArgs e)
        {
            // A color was selected, so create a Cookie that will persist the value
            HttpCookie colorCookie = new HttpCookie("Color", Color.SelectedValue);

            // Add the cookie to the Response
            Response.SetCookie(colorCookie);

            // Explicitly reset the page
            Response.Redirect(Request.Path);
        }
    }
}