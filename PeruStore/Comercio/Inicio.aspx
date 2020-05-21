<%@ Page Title="" Language="C#" MasterPageFile="~/HomePage.Master" AutoEventWireup="true" CodeBehind="Inicio.aspx.cs" Inherits="PeruStore.Comercio.Inicio" %>

<%@ Register Src="~/Controles/Inicio/ucProductoLista.ascx" TagPrefix="uc1" TagName="ucProductoLista" %>
<%@ Register Src="~/Controles/Inicio/ucOfertaSemanal.ascx" TagPrefix="uc1" TagName="ucOfertaSemanal" %>
<%@ Register Src="~/Controles/Inicio/ucComprarPorCategoria.ascx" TagPrefix="uc1" TagName="ucComprarPorCategoria" %>
<%@ Register Src="~/Controles/Inicio/ucUltimosBlogs.ascx" TagPrefix="uc1" TagName="ucUltimosBlogs" %>
<%@ Register Src="~/Controles/Inicio/ucMarcas.ascx" TagPrefix="uc1" TagName="ucMarcas" %>
<%@ Register Src="~/Controles/Inicio/ucProductosPorSeccion.ascx" TagPrefix="uc1" TagName="ucProductosPorSeccion" %>
<%@ Register Src="~/Controles/Inicio/ucBannerCentral.ascx" TagPrefix="uc1" TagName="ucBannerCentral" %>
<%@ Register Src="~/Controles/Inicio/ucBeneficios.ascx" TagPrefix="uc1" TagName="ucBeneficios" %>








<asp:Content ID="Content2" ContentPlaceHolderID="head" runat="server">
   <script src="../Controles/Inicio/js/listaproducto.js"></script>
</asp:Content>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
  
    <div class="main-container">
        <div id="content">
            <div class="module sohomepage-slider ">
                <div class="yt-content-slider"  data-rtl="yes" data-autoplay="no" data-autoheight="no" data-delay="4" data-speed="0.6" data-margin="0" data-items_column0="1" data-items_column1="1" data-items_column2="1"  data-items_column3="1" data-items_column4="1" data-arrows="no" data-pagination="yes" data-lazyload="yes" data-loop="no" data-hoverpause="yes">
                    <div class="yt-content-slide">
                        <a href="#"><img src="/Template/image/catalog/slideshow/home2/slide-1.jpg" alt="slider1" class="img-responsive"></a>
                    </div>
                    <div class="yt-content-slide">
                        <a href="#"><img src="/Template/image/catalog/slideshow/home2/slide-2.jpg" alt="slider2" class="img-responsive"></a>
                    </div>
                    <div class="yt-content-slide">
                        <a href="#"><img src="/Template/image/catalog/slideshow/home2/slide-3.jpg" alt="slider3" class="img-responsive"></a>
                    </div>
                </div>
            
                <div class="loadeding"></div>   
            </div>

            <div class="container">

              <%--Beneficios--%>
                <uc1:ucBeneficios runat="server" id="ucBeneficios" />

              <%--comprar por categoria--%>
                <uc1:ucComprarPorCategoria runat="server" id="ucComprarPorCategoria" />

                <div class="banners banners1">
                    <div class="banner">
                        <a href="#">
                            <img src="/Template/image/catalog/banners/id2-banner1.jpg" alt="image">
                        </a>
                    </div>
                </div>

                <div class="row">
                    <uc1:ucOfertaSemanal runat="server" id="ucOfertaSemanal" />
                  <uc1:ucProductoLista runat="server" ID="ucProductoLista" />
                </div>

               <%-- Banner Central--%>
                <uc1:ucBannerCentral runat="server" ID="ucBannerCentral" />
               
               <%--Productos Por Sección--%>
               <uc1:ucProductosPorSeccion runat="server" ID="ucProductosPorSeccion" />
                     
                <%--Marcas--%>
                <uc1:ucMarcas runat="server" id="ucMarcas" />

                <%--Ultimos Blogs--%>
                 <uc1:ucUltimosBlogs runat="server" ID="ucUltimosBlogs" />
            </div>
        </div>
    </div>
    
</asp:Content>
