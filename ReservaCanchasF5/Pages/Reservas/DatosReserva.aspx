<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="DatosReserva.aspx.cs" Inherits="ReservaCanchasF5.Pages.Reservas.DatosReserva" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <div id="price" class="section secondary-section">
        <div class="container">
            <div class="price-table row-fluid">
                <div class="span1">
                </div>
                <div class="span10 price-column">
                    <h3>Reserva Cancha</h3>
                    <ul class="list">
                        <asp:GridView ID="gvReservas" runat="server" BackColor="White" BorderColor="#999999" BorderStyle="Solid" BorderWidth="1px" CellPadding="3" ForeColor="Black" GridLines="Vertical">
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
                    <ul class="list">
                            <div runat="server" visible="false" id="Div3" class="alert alert-danger" role="alert">Datos incorrectos o incompletos revise nuevamente</div>

                        <li>
                            <div runat="server" visible="true" id="error" class="alert alert-info" role="alert">Datos de la reserva</div>
                            <asp:TextBox class="span6" TextMode="DateTime" placeholder="* Fecha Reserva" ID="txtFechaReserva" runat="server"></asp:TextBox>
                            <asp:DropDownList class="span6" ID="dwHorasReserva" runat="server"></asp:DropDownList>
                        </li>

                        <li>
                            <div runat="server" visible="true" id="Div1" class="alert alert-info" role="alert">Datos Cliente</div>
                            <asp:TextBox class="span4" placeholder="* Número Identificación" ID="txtNumIde" runat="server" OnTextChanged="txtNumIde_TextChanged" AutoPostBack="true"></asp:TextBox>
                            <asp:TextBox class="span4" Enabled="false" placeholder="* Tipo Identificacion" ID="txtTipoIden" runat="server"></asp:TextBox>
                            <asp:TextBox class="span4" Enabled="false" placeholder="* Nombre" ID="txtNombre" runat="server"></asp:TextBox>
                        </li>
                        <li>
                            <asp:TextBox class="span4" Enabled="false" placeholder="* Apellido" ID="txtApellido" runat="server"></asp:TextBox>
                            <asp:TextBox class="span4" Enabled="false" placeholder="* Telefono" ID="txtTelefono" TextMode="Phone" runat="server"></asp:TextBox>
                            <asp:TextBox class="span4" Enabled="false" placeholder="* Correo" ID="txtCorreo" TextMode="Email" runat="server"></asp:TextBox>
                        </li>
                        <li>
                            <div runat="server" visible="true" id="Div2" class="alert alert-info" role="alert">Datos Pago</div>
                            <asp:DropDownList class="span4" ID="dwTipoPago" runat="server">
                                <asp:ListItem>Efectivo</asp:ListItem>
                                <asp:ListItem>Transferencia</asp:ListItem>
                                <asp:ListItem>PSE</asp:ListItem>
                                <asp:ListItem>Nequi</asp:ListItem>
                            </asp:DropDownList>
                            <asp:DropDownList class="span4" ID="dwValorChange" runat="server">
                                <asp:ListItem>Abono</asp:ListItem>
                                <asp:ListItem>Pago Total</asp:ListItem>                                
                            </asp:DropDownList>
                            <asp:TextBox class="span4" Enabled="false" placeholder="* valor Pago" ID="txtValorPago" runat="server"></asp:TextBox>
                        </li>                       
                    </ul>
                    <asp:Button class="button button-ps" ID="btnReserva" runat="server" Text="Reservar" />
                </div>
                <div class="span2">
                </div>
            </div>
        </div>
    </div>

</asp:Content>
