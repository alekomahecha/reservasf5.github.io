<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Contactenos.aspx.cs" Inherits="ReservaCanchasF5.Pages.Contactenos" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div id="price" class="section secondary-section">
            <div class="container">                
                <div class="price-table row-fluid">  
                    <div class="span3">                        
                    </div>
                    <div class="span6 price-column">
                        <h3>Contactenos</h3>
                       
                        <ul class="list">
                            <li><asp:TextBox class="span12" TextMode="Email" placeholder="* Tu Correo" ID="txtCorreo" runat="server" Width="343px"></asp:TextBox></li>
                            <li><asp:TextBox class="span12" TextMode="MultiLine" placeholder="* Tu Mensaje" ID="txtMensaje" runat="server" Height="181px" Width="348px"></asp:TextBox></li>
                                                    </ul>
                        <asp:Button class="button button-ps" ID="btnEnviar" runat="server" Text="Enviar Mensaje"/>
                        <br />
                        <br />   
                        <asp:Label ID="Label2" runat="server" Text="Datos Incorrectos o incompletos Intente Nuevamente " Visible="false" BackColor="White" ForeColor="Red"></asp:Label>
                    </div>
                    <div class="span4">                        
                    </div>
                </div>                
            </div>
        </div>
</asp:Content>
