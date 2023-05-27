<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ConsultaReservas.aspx.cs" Inherits="ReservaCanchasF5.Pages.Reservas.ConsultaReservas" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <div id="price" class="section secondary-section">
        <div class="container">
            <div class="price-table row-fluid">
                <div class="span1">
                </div>
                <div class="span10 price-column">
                    <ul class="list">
                        <li>
                            <asp:GridView class="span12" ID="gvReservas" runat="server" BackColor="White" AutoGenerateColumns="false" BorderColor="#999999" BorderStyle="Solid" BorderWidth="1px" CellPadding="3" ForeColor="Black" GridLines="Vertical">
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
                                    <asp:BoundField DataField="fechareserva" HeaderText="Fecha Reserva" />
                                    <asp:BoundField DataField="hora" HeaderText="Hora" />
                                    <asp:BoundField DataField="precio" HeaderText="Precio" />
                                    <asp:BoundField DataField="tipopago" HeaderText="Tipo Pago" />
                                    <asp:BoundField DataField="totalvalorpago" HeaderText="Pago" />
                                    <asp:BoundField DataField="montoabono" HeaderText="Monto Abono" />
                                    <asp:BoundField DataField="nombrecancha" HeaderText="Nombre Cancha" />
                                    <asp:BoundField DataField="Nombre" HeaderText="Nombre Cliente" />                                    
                                    <asp:BoundField DataField="telefono" HeaderText="Telefono Cliente" />
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
