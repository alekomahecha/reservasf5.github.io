<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ConsultaHoras.aspx.cs" Inherits="ReservaCanchasF5.Pages.Canchas.ConsultaHoras" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
     <div id="price" class="section secondary-section">
        <div class="container">
            <div class="price-table row-fluid">
                <div class="span1">
                </div>
                <div class="span10 price-column">
                    <ul class="list">
                        <li>
                            <div runat="server" visible="true" id="Div3" class="alert alert-info" role="alert">Mis Horas Canchas</div>
                            <asp:GridView class="span12" ID="gvCanchas" runat="server" DataKeyNames="id" OnSelectedIndexChanged="gvCanchas_SelectedIndexChanged" AutoGenerateSelectButton="true" BackColor="White" AutoGenerateColumns="false" BorderColor="#999999" BorderStyle="Solid" BorderWidth="1px" CellPadding="3" ForeColor="Black" GridLines="Vertical">
                                <AlternatingRowStyle BackColor="#CCCCCC" />
                                <FooterStyle BackColor="#CCCCCC" />
                                <HeaderStyle BackColor="Black" Font-Bold="True" ForeColor="White" />
                                <PagerStyle BackColor="#999999" ForeColor="Black" HorizontalAlign="Center" />
                                <SelectedRowStyle BackColor="#000099" Font-Bold="True" ForeColor="White" />
                                <SortedAscendingCellStyle BackColor="#F1F1F1" />
                                <SortedAscendingHeaderStyle BackColor="#808080" />
                                <SortedDescendingCellStyle BackColor="#CAC9C9" />
                                <SortedDescendingHeaderStyle BackColor="#383838" />
                                <Columns>
                                    <asp:BoundField Visible="false" DataField="id" HeaderText="id" />
                                    <asp:BoundField DataField="nombrecancha" HeaderText="Nombre Cancha" />
                                    <asp:BoundField DataField="barrio" HeaderText="Barrio" />
                                    <asp:BoundField DataField="direccion" HeaderText="Dirección" />
                                    <asp:BoundField DataField="horainicio" HeaderText="Hora Inicio" />
                                    <asp:BoundField DataField="horafin" HeaderText="Hora Fin" />                                    
                                </Columns>
                            </asp:GridView>
                        </li>
                    </ul>
                </div>
                <div class="span2">
                </div>
            </div>
        </div>
    </div>
</asp:Content>
