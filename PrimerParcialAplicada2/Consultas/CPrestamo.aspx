<%@ Page Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="CPrestamo.aspx.cs" Inherits="PrimerPacialAplicada2.Consultas.CPrestamo" %>

<asp:Content ID="Content5" ContentPlaceHolderID="MainContent" runat="server">
    <div class="panel" style="background-color: black">
        <div class="panel-heading" style="font-family: 'Segoe UI', Tahoma, Geneva, Verdana, sans-serif; font-size: medium; color: white">Consulta de Prestamos</div>
    </div>
    <div class="form-group">
        <div class="col-md-4">
            <asp:DropDownList ID="FiltroDropDownList" runat="server" Class="form-control input-sm" Style="font-size: medium">
                <asp:ListItem Selected="True">Todo</asp:ListItem>
                <asp:ListItem>PrestamoId</asp:ListItem>
                <asp:ListItem>CuentaId</asp:ListItem>
            </asp:DropDownList>
        </div>
        <div class="col-md-6">
            <asp:TextBox ID="CriterioTextBox" runat="server" class="form-control input-sm" Style="font-size: medium"></asp:TextBox>
        </div>
        <div class="col-md-2">
            <asp:Button ID="BuscarButton" runat="server" Text="Buscar" class="btn btn-info btn-md" OnClick="BuscarButton_Click" />
        </div>
       <%-- <div class="col-md-6">
            <label for="DesdeTextBox" class="col-md-3 control-label input-sm" style="font-size: large">Desde</label>
            <asp:TextBox ID="DesdeTextBox" runat="server" class="form-control input-sm" Style="font-size: medium"></asp:TextBox>
        </div>
        <div class="col-md-6">
            <label for="HastaTextBox" class="col-md-3 control-label input-sm" style="font-size: large">Hasta</label>
            <asp:TextBox ID="HastaTextBox" runat="server" class="form-control input-sm" Style="font-size: medium" TextMode="DateTime"></asp:TextBox>
        </div>--%>
        <br />
        <br />
        <div>
            <asp:GridView ID="DatosGridView" runat="server" class="table table-condensed tabled-bordered table-responsive" CellPadding="6" ForeColor="#333333" GridLines="None">
                <AlternatingRowStyle BackColor="Gray" />
                <HeaderStyle BackColor="Black" Font-Bold="true" ForeColor="White" />
                <RowStyle BackColor="#EFF3FB" />
            </asp:GridView>
        </div>
        <div class="col-md-2">
            <asp:Button ID="ImprimirButton" runat="server" Text="Imprimir" class="btn btn-primary btn-lg" />
        </div>
</asp:Content>
