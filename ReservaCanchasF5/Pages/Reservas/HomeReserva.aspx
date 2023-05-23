<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="HomeReserva.aspx.cs" Inherits="ReservaCanchasF5.Pages.Reservas.HomeReserva" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

 <div id="price" class="section secondary-section">
            <div class="container">                
                <div class="price-table row-fluid">  
                    <div class="span1">                        
                    </div>
                    <div class="span10 price-column">
                        <h3>Buscar ubicación cancha</h3>
                       
                        <ul class="list">
                            <li><asp:TextBox class="span12" placeholder="* Ingresa Ubicación" ID="txtUbicacion" runat="server"></asp:TextBox></li>                           
                        </ul>  
                        <ul class="list">
                          <asp:GridView ID="gvUbicaciones" runat="server" BackColor="White" BorderColor="#999999" BorderStyle="Solid" BorderWidth="1px" CellPadding="3" ForeColor="Black" GridLines="Vertical">
                              <AlternatingRowStyle BackColor="#CCCCCC" />
                              <FooterStyle BackColor="#CCCCCC" />
                              <HeaderStyle BackColor="Black" Font-Bold="True" ForeColor="White" />
                              <PagerStyle BackColor="#999999" ForeColor="Black" HorizontalAlign="Center" />
                              <SelectedRowStyle BackColor="#000099" Font-Bold="True" ForeColor="White" />
                              <SortedAscendingCellStyle BackColor="#F1F1F1" />
                              <SortedAscendingHeaderStyle BackColor="#808080" />
                              <SortedDescendingCellStyle BackColor="#CAC9C9" />
                              <SortedDescendingHeaderStyle BackColor="#383838" />
                            </asp:GridView>
                        </ul>
                    </div>
                    <div class="span2">                        
                    </div>
                </div>                
            </div>
        </div>


</asp:Content>
