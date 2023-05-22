<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="SobreNosotros.aspx.cs" Inherits="ReservaCanchasF5.Pages.SobreNosotros" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="section primary-section" id="service">
            <div class="container">
                <!-- Start title section -->
                <div class="title">
                    <h1>¿Que hacemos Nostros?</h1>
                    <!-- Section's title goes here -->
                    <p>Centralizamos y gestionamos las canchas de futbol 5, donde damos mejor acceso a los clientes para reservar sus canchas y gestionarlas.</p>
                    <!--Simple description for section goes here. -->
                </div>
                <div class="row-fluid">
                    <div class="span4">
                        <div class="centered service">
                            <div class="circle-border zoom-in">
                                <img class="img-circle" src="../images/Service1.png" alt="service 1">
                            </div>
                            <h3>Comercios</h3>
                            <p>Gestión y control para las canchas F5.</p>
                        </div>
                    </div>
                    <div class="span4">
                        <div class="centered service">
                            <div class="circle-border zoom-in">
                                <img class="img-circle" src="../images/Service2.png" alt="service 2" />
                            </div>
                            <h3>Costos</h3>
                            <p>Control de Costos de reservas de canchas de F5 a la mano</p>
                        </div>
                    </div>
                    <div class="span4">
                        <div class="centered service">
                            <div class="circle-border zoom-in">
                                <img class="img-circle" src="../images/Service3.png" alt="service 3">
                            </div>
                            <h3>Reservas</h3>
                            <p>Sin esperas o sin respuesta reserve en tiempo real.</p>
                        </div>
                    </div>
                </div>
            </div>
        </div>
</asp:Content>
