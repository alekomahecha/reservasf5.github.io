<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Registro.aspx.cs" Inherits="ReservaCanchasF5.Pages.Persona.Registro" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
     <div id="price" class="section secondary-section">
            <div class="container">                
                <div class="price-table row-fluid">  
                    <div class="span3">                        
                    </div>
                    <div class="span6 price-column">
                        <h3>Registro</h3>
                       
                        <ul class="list">
                            <li><asp:TextBox class="span12" placeholder="* Tipo Identificacion" ID="txtTipoIden" runat="server"></asp:TextBox></li>
                            <li><asp:TextBox class="span12" placeholder="* Número Identificación" ID="txtNumIde" runat="server"></asp:TextBox></li>
                            <li><asp:TextBox class="span12" placeholder="* Nombre" ID="txtNombre" runat="server"></asp:TextBox></li>
                            <li><asp:TextBox class="span12" placeholder="* Apellido" ID="txtApellido" runat="server"></asp:TextBox></li>
                            <li><asp:TextBox class="span12" placeholder="* Telefono" ID="txtTelefono" TextMode="Phone" runat="server"></asp:TextBox></li>
                            <li><asp:TextBox class="span12" placeholder="* Correo" ID="txtCorreo" TextMode="Email" runat="server"></asp:TextBox></li>
                            <li><asp:TextBox class="span12" placeholder="* Tu Usuario" ID="txtUsuario" runat="server"></asp:TextBox></li>
                            <li><asp:TextBox class="span12" TextMode="Password" placeholder="* Tu Constraseña" ID="txtContrasena" runat="server"></asp:TextBox></li>
                        </ul>
                        <asp:Button class="button button-ps" ID="btnGuardar" runat="server" Text="Guardar" OnClick="btnGuardar_Click" />                        
                        <br /> 
                        <asp:Label ID="lblTexto" runat="server" Text="Datos Incorrectos o incompletos Intente Nuevamente " Visible="false" BackColor="White" ForeColor="Red"></asp:Label>
                    </div>
                    <div class="span4">                        
                    </div>
                </div>                
            </div>
        </div>
</asp:Content>
