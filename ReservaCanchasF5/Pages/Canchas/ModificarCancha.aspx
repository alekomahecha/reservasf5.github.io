<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ModificarCancha.aspx.cs" Inherits="ReservaCanchasF5.Pages.Canchas.ModificarCancha" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div id="price" class="section secondary-section">
        <div class="container">
            <div class="price-table row-fluid">
                <div class="span1">
                </div>
                <div class="span10 price-column">
                    <h3>Registro Cancha</h3>
                    <ul class="list">
                        <div runat="server" visible="false" id="error" class="alert alert-danger" role="alert">Datos incorrectos o incompletos revise nuevamente</div>
                        <li>
                            <div runat="server" visible="true" id="div" class="alert alert-info" role="alert">Datos Basicos</div>
                            <asp:TextBox class="span6" placeholder="* Nombre Canchas" ID="txtNombreCancha" runat="server"></asp:TextBox>
                            <asp:TextBox class="span6" placeholder="* Numero Canchas" ID="txtNumeroCancha" runat="server"></asp:TextBox>

                        </li>

                        <li>
                            <div runat="server" visible="true" id="Div1" class="alert alert-info" role="alert">Datos Ubicación</div>
                            <asp:TextBox class="span4" placeholder="* Dirección" ID="txtDireccion" runat="server"></asp:TextBox>
                            <asp:TextBox class="span4" placeholder="* Barrio" ID="txtBarrio" runat="server"></asp:TextBox>
                            <asp:TextBox class="span4" placeholder="* Telefono" ID="txtTelefono" runat="server"></asp:TextBox>
                        </li>
                        <li>
                            <div runat="server" visible="true" id="Div3" class="alert alert-info" role="alert">Datos Horas</div>                           
                            <div runat="server" visible="false" id="errorHoras" class="alert alert-danger" role="alert">Hora Inicio Mayor que hora fin</div>                           
                            <asp:Label ID="Label1" runat="server" Text="Hora Apertura:"></asp:Label>
                            
                            <asp:DropDownList class="span9" ID="dwHoraInicio" runat="server" AutoPostBack="true" OnSelectedIndexChanged="dwHoraInicio_SelectedIndexChanged">
                            </asp:DropDownList>      
                        </li>
                        <li>
                            <asp:Label  ID="Label2" runat="server" Text="Hora Cierre:  "></asp:Label>
                            <asp:DropDownList class="span9" AutoPostBack="true" ID="dwHoraFinal" runat="server" OnSelectedIndexChanged="dwHoraFinal_SelectedIndexChanged">
                            </asp:DropDownList>
                        </li>
                    </ul>
                    <asp:Button class="button button-ps" ID="btnCancha" runat="server" Text="Guardar" OnClick="btnCancha_Click" />
                </div>
                <div class="span2">
                </div>
            </div>
        </div>
    </div>

</asp:Content>
