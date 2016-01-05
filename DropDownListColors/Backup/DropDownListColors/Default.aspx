<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="DropDownListColors._Default" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>DropDownListColor</title>
    <script language="javascript" type="text/javascript">
    <!--
    
        //DESCRIPCION ENGLISH: Keep the colors of a dropdownlist during postback
        //DrpName: Name of the dropdownlist who need to keep the colors during postback
        //Color: Color to apply in the dropdownlist
        //StyleType: Style to apply in the dropdownlist COLOR or BACKGROUND-COLOR
        //indicesForSplit: string with the list of index of the items of the dropdownlist who has color
        //SeparatorSplit: A char to disjoin the items of the string indicesParaSplit
        
        //DESCRIPCION ESPAÑOL: mantiene los colores de la lista en el postback
        //DrpName: Nombre del dropdownlist que debe mantener los colores en el postback
        //Color: color a aplicar en el dropdownlist
        //StyleType: Style a aplicar en el dropdownlist COLOR or BACKGROUND-COLOR
        //indicesForSplit: cadena con los indices de los elementos del dropdownlist que tienen color
        //SeparatorSplit: Char, Separador de elementos de la cadena indicesParaSplit
        //function drpSetColors(NombreDrp, color, tipoStyle, indicesParaSplit, SeparadorSplit) 
        function drpSetColors(DrpName, Color, StyleType, indicesForSplit, SeparatorSplit) 
        {
            if (document.getElementById(DrpName) != null) {
                var indices = indicesForSplit.split(SeparatorSplit);
                if (indices[0] == "")
                    return;
                for (j = 0; j < indices.length; j++) {
                    if (StyleType.toUpperCase() == "COLOR")
                        document.getElementById(DrpName).options[indices[j]].style.color = Color;
                    else if (StyleType.toUpperCase() == "BACKGROUND-COLOR")
                        document.getElementById(DrpName).options[indices[j]].style.backgroundColor = Color;
                }

            }
        }
    -->
    </script>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <table>
            <tr style="background-color:Silver">
                <td style="height: 24px"><asp:Label ID="Label3" runat="server" Text="Product:"></asp:Label></td>
                <td style="height: 24px">
                    <asp:DropDownList ID="drpProduct" runat="server" DataTextField="Text" DataValueField="Value">
                    </asp:DropDownList>
                </td>
                <td style="height: 24px">
                    El color rojo de los productos ya salvados se mantiene en el postback.<br />
                    The red color in Products just saved stay during postback</td>
            </tr>
            <tr style="background-color:Silver">
                <td><asp:Label ID="Label2" runat="server" Text="Copy Product"></asp:Label></td>
                <td><asp:DropDownList ID="drpProductCopy" runat="server" DataTextField="Text" DataValueField="Value">
                    </asp:DropDownList></td>
                <td>
                    El color rojo de los productos ya salvados no se mantiene en el postback.<br />
                    The red color in Products just saved doesn't stay during postback</td>
            </tr>
            <tr>
                <td colspan="2">
                    <asp:Button ID="btnSave" runat="server" Text="Do postback and Save Product" OnClick="btnSave_Click" />
                    <asp:Button ID="btnDoPostBack" runat="server" Text="DoNothing Just Postback" OnClick="btnDoPostBack_Click" />&nbsp;
                    <asp:HiddenField ID="hfValuesSelectForColor" runat="server" />
                </td>
            </tr>
        </table>
        </div>
    </form>
</body>
</html>
