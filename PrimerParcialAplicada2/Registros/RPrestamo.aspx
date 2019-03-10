<%@ Page Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="RPrestamo.aspx.cs" Inherits="PrimerParcialAplicada2.Registros.RPrestamo" %>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <div class="panel" style="background-color: black">
        <div class="panel-heading" style="font-family: 'Segoe UI', Tahoma, Geneva, Verdana, sans-serif; font-size: medium; color: white">Registro de Prestamos</div>
    </div>

    <div class="panel-body">
        <div class="form-horizontal col-md-12" role="form">
            <div class="form-group">
                <label for="PrestamoIdTextBox" class="col-md-3 control-label input-sm" style="font-size: large">Prestamo Id</label>
                <div class="col-md-1 col-sm-2 col-xs-4">
                    <asp:TextBox ID="PrestamoIdTextBox" runat="server" placeholder="0" class="form-control input-sm" Style="font-size: large" TextMode="Number"></asp:TextBox>
                </div>
                <div class="col-md-1 col-sm-2 col-xs-4">
                    <%--OnClick="BuscarButton_Click"--%>
                    <asp:Button ID="BuscarButton" runat="server" Text="Buscar" class="btn btn-info btn-sm" />
                </div>
            </div>
            <div class="form-group">
                <label for="CuentaIdDropDownList" class="col-md-3 control-label input-sm" style="font-size: large">Cuenta</label>
                <div class="col-md-1">
                    <asp:DropDownList ID="CuentaIdDropDownList" runat="server" Class="form-control input-sm" Style="font-size: large">
                    </asp:DropDownList>
                </div>
            </div>


            <div class="form-group">
                <label for="CapitalTextBox" class="col-md-3 control-label input-sm" style="font-size: large">Capital</label>
                <div class="col-md-8">
                    <asp:TextBox ID="CapitalTextBox" runat="server" class="form-control input-sm" Style="font-size: large" TextMode="Number"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="ValidaCapital" runat="server" ErrorMessage="El campo &quot;Capital&quot; esta vacio" ControlToValidate="CapitalTextBox" ForeColor="Red" Display="Dynamic" ToolTip="Campo Capital es obligatorio" ValidationGroup="Guardar">*</asp:RequiredFieldValidator>
                </div>
            </div>
            <div class="form-group">
                <label for="InteresTextBox" class="col-md-3 control-label input-sm" style="font-size: large">Interes anual</label>
                <div class="col-md-1">
                    <asp:TextBox ID="InteresTextBox" runat="server" class="form-control input-sm" Style="font-size: large" TextMode="Number"></asp:TextBox>
                </div>
                <asp:RequiredFieldValidator ID="ValidaInteres" runat="server" ErrorMessage="El campo &quot;Interes anual&quot; esta vacio" ControlToValidate="InteresTextBox" ForeColor="Red" Display="Dynamic" ToolTip="Campo Interes obligatorio" ValidationGroup="Guardar">*</asp:RequiredFieldValidator>
                <label>&#37;</label>
            </div>

            <div class="form-group">
                <label for="TiempoMesesTextBox" class="col-md-3 control-label input-sm" style="font-size: large">Tiempo en meses</label>
                <div class="col-md-1">
                    <asp:TextBox ID="TiempoMesesTextBox" runat="server" class="form-control input-sm" Style="font-size: large" TextMode="Number"></asp:TextBox>
                </div>
                <%-- Probar el color al fallar validacion--%>
                <asp:RequiredFieldValidator ID="ValidaMeses" runat="server" ErrorMessage="El campo &quot;Tiempo en meses&quot; esta vacio" ControlToValidate="TiempoMesesTextBox" ForeColor="Red" Display="Dynamic" ToolTip="Campo tiempo en meses obligatorio" ValidationGroup="Guardar" BorderColor="Red">*</asp:RequiredFieldValidator>
                <asp:Button ID="CalcularButton" runat="server" Text="Calcular" Class="btn btn-default btn" />
            </div>
<%--            agregar el gridview--%>
          <div class="form-group">
              <asp:GridView ID="GridView1" runat="server"></asp:GridView>
          </div> 

            <div class="form-group">
                <div class="col-md-8">
                    <asp:TextBox ID="FechaTextBox" TextMode="Date" runat="server" class="form-control input-sm" Style="font-size: large" Visible="false"></asp:TextBox>
                </div>
            </div>
            <div class="panel">
                <div class="text-center">
                    <%--<div class="form-group">
                        <asp:Button ID="NuevoButton" runat="server" Text="Nuevo" class="btn btn-primary btn-md" OnClick="NuevoButton_Click" />
                        <asp:Button ID="GuardarButton" runat="server" Text="Guardar" class="btn btn-success btn-md" ValidationGroup="Guardar" OnClick="GuardarButton_Click" />
                        <asp:Button ID="EliminarButton" runat="server" Text="Eliminar" class="btn btn-danger btn-md" OnClick="EliminarButton_Click" />
                    </div>--%>
                </div>
            </div>

        </div>
    </div>

</asp:Content>
