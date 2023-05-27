<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="MiCuenta.aspx.cs" Inherits="ReservaCanchasF5.Pages.Persona.MiCuenta" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div id="price" class="section secondary-section">
        <div class="container">
            <div class="price-table row-fluid">
                <div class="span3">
                </div>
                <div class="span6 price-column">
                    <h3>Actualiza tu perfil</h3>
                    <ul class="list">
                        <div runat="server" visible="false" id="error" class="alert alert-danger" role="alert">Datos incorrectos o incompletos revise nuevamente</div>
                        <li>
                            <asp:DropDownList class="span4" ID="dwTipoIdentificacion" runat="server">
                                <asp:ListItem>Cedula</asp:ListItem>
                                <asp:ListItem>NIT</asp:ListItem>
                                <asp:ListItem>Tarjeta Identidad</asp:ListItem>
                                <asp:ListItem>Cedula Extrajeria</asp:ListItem>
                            </asp:DropDownList></li>
                        <li>
                            <asp:TextBox class="span12" placeholder="* Número Identificación" ID="txtNumeroIden" runat="server"></asp:TextBox></li>
                        <li>
                            <asp:TextBox class="span12" placeholder="* Nombre" ID="txtNombre" runat="server"></asp:TextBox></li>
                        <li>
                            <asp:TextBox class="span12" placeholder="* Apellido" ID="txtApellido" runat="server"></asp:TextBox></li>
                        <li>
                            <asp:TextBox class="span12" placeholder="* Telefono" ID="txtTelefono" TextMode="Phone" runat="server"></asp:TextBox></li>
                        <li>
                            <asp:TextBox class="span12" placeholder="* Correo" ID="txtCorreo" TextMode="Email" runat="server"></asp:TextBox></li>
                        <li>
                            <asp:TextBox class="span12" placeholder="* Tu Usuario" Enabled="false" ID="txtUsuario" runat="server"></asp:TextBox></li>
                        <li>
                            <asp:TextBox class="span12" TextMode="Password" placeholder="* Tu Constraseña" ID="txtContrasena" runat="server"></asp:TextBox></li>
                    </ul>
                    <asp:Button class="button button-ps" ID="btnGuardar" runat="server" Text="Modificar" OnClick="btnGuardar_Click" />
                    <asp:Button class="button button-ps" ID="btnInactivar" runat="server" Text="Inactivar Cuenta" OnClick="btnInactivar_Click" />
                    <br />

                </div>
                <div class="span4">
                </div>
            </div>
        </div>
    </div>


</asp:Content>
