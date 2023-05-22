﻿<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="ReservaCanchasF5._Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

    <div class="text-center">

        <!-- Start home section -->
        <div id="home">
            <!-- Start cSlider -->
            <div id="da-slider" class="da-slider">
                <div class="triangle"></div>
                <!-- mask elemet use for masking background image -->
                <div class="mask"></div>
                <!-- All slides centred in container element -->
                <div class="container">
                    <!-- Start first slide -->
                    <div class="da-slide">
                        <h2 class="fittext2">Bienvenido</h2>
                        <h4>Reserva canchas F5</h4>
                        <p>Aqui encontraras todo lo necesario para administrar o reservar canchas F5 de tu selecciòn</p>
                        <div class="da-img">
                            <img src="images/Slider01.jpg" alt="image01" width="500">
                        </div>
                    </div>
                    <!-- End first slide -->
                    <!-- Start second slide -->
                    <div class="da-slide">
                        <h2>Facil de Usar</h2>
                        <h4>Desde tu celular</h4>
                        <p>Podras reservar o gestionar tus canchas futbol 5 desde tu celular con alta tecnologìa para poder resolver y reserva cada una de tus canchas o gestiòn.</p>

                        <div class="da-img">
                            <img src="images/Slider02.png" width="320" alt="image02">
                        </div>
                    </div>
                    <!-- End second slide -->
                    <!-- Start third slide -->
                    <div class="da-slide">
                        <h2>Revoluciona Tu Mercado</h2>
                        <h4>Revoluciòn</h4>
                        <p>Con nuestra ayuda podras revolucionar el mercado que maneja con un alta calidad de atenciòn y autogestion que ayudara a centrarse en mejorar aspectos de su establecimiento.</p>
                        <div class="da-img">
                            <img src="images/Slider03.png" width="320" alt="image03">
                        </div>
                    </div>
                    <!-- Start third slide -->
                    <!-- Start cSlide navigation arrows -->
                    <div class="da-arrows">
                        <span class="da-arrows-prev"></span>
                        <span class="da-arrows-next"></span>
                    </div>
                    <!-- End cSlide navigation arrows -->
                </div>
            </div>

            
            <!-- End home section -->
        </div>
    </div>

</asp:Content>
