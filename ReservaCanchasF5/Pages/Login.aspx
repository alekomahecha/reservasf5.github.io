<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="ReservaCanchasF5.Pages.Login" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
     <div id="price" class="section secondary-section">
            <div class="container">                
                <div class="price-table row-fluid">  
                    <div class="span3">                        
                    </div>
                    <div class="span6 price-column">
                        <h3>Inicia Sesión</h3>
                       
                        <ul class="list">
                            <li><asp:TextBox class="span12" placeholder="* Tu Usuario" ID="txtUsuario" runat="server"></asp:TextBox></li>
                            <li><asp:TextBox class="span12" TextMode="Password" placeholder="* Tu Constraseña" ID="txtContrasena" runat="server"></asp:TextBox></li>
                        </ul>
                        <asp:Button class="button button-ps" ID="btnIniciarSesion" runat="server" Text="Ingresar" OnClick="btnIniciarSesion_Click" />
                        <br />
                        <br />                                    
                        <asp:Label ID="Label1" runat="server" Text="No tienes Usuario Empresarial Registrate " BackColor="White" ForeColor="Black"></asp:Label><a href="Persona/Registro.aspx">Aquí</a>
                        <br /> 
                        <asp:Label ID="Label2" runat="server" Text="Datos Incorrectos o incompletos Intente Nuevamente " Visible="false" BackColor="White" ForeColor="Red"></asp:Label>
                    </div>
                    <div class="span4">                        
                    </div>
                </div>                
            </div>
        </div>
</asp:Content>
