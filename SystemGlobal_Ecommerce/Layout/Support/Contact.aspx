<%@ Page Title="" Language="C#" MasterPageFile="~/HomePage.Master" AutoEventWireup="true" CodeBehind="Contact.aspx.cs" Inherits="SystemGlobal_Ecommerce.Layout.Support.Contact" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    
<script type="text/javascript" src="https://maps.googleapis.com/maps/api/js?sensor=false"></script>    
<script src="js/map-init.js"></script>
    <script src="../../Files/js/map-init.js"></script>
    <script src="../../Files/external/panelmenu/panelmenu.js"></script>

    <script src="../../Files/external/form/jquery.form-init.js"></script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

<div id="loader-wrapper">
	 <div class="loading-content">
				<div class="loading-dots">
					<i></i>
					<i></i>
					<i></i>
					<i></i>
				</div>
			</div>
</div>

	<!-- stuck nav -->
	<div class="tt-stuck-nav">
		<div class="container">
			<div class="tt-header-row ">
				<div class="tt-stuck-parent-menu"></div>
				<div class="tt-stuck-parent-search tt-parent-box"></div>
				<div class="tt-stuck-parent-cart tt-parent-box"></div>
				<div class="tt-stuck-parent-account tt-parent-box"></div>
				<div class="tt-stuck-parent-multi tt-parent-box"></div>
			</div>
		</div>
	</div>

<div class="tt-breadcrumb">
	<div class="container">
		<ul>
			<li><a href="/Index.aspx">Canastón</a></li>
			<li>Contáctanos</li>
		</ul>
	</div>
</div>
<div id="tt-pageContent">
	<div class="container-indent">
		<div class="container">
			<div class="contact-map">
				<div id="map"></div>
			</div>
		</div>
	</div>
	<div class="container-indent">
		<div class="container container-fluid-custom-mobile-padding">
			<div class="tt-contact02-col-list">
				<div class="row">
					<div class="col-sm-12 col-md-4 ml-sm-auto mr-sm-auto">
						<div class="tt-contact-info">
							<i class="tt-icon icon-f-93"></i>
							<h6 class="tt-title">TENEMOS UN CHAT!</h6>
							<address>
								+777 2345 7885:<br>
								+777 2345 7886
							</address>
						</div>
					</div>
					<div class="col-sm-6 col-md-4">
						<div class="tt-contact-info">
							<i class="tt-icon icon-f-24"></i>
							<h6 class="tt-title">VISITA NUESTRA UBICACIÓN</h6>
							<address>
								Actualmente no esta disponible por el covid-19<br>
							<%--	Madisonville KY 4783,<br>
								United States of America--%>
							</address>
						</div>
					</div>
					<div class="col-sm-6 col-md-4">
						<div class="tt-contact-info">
							<i class="tt-icon icon-f-92"></i>
							<h6 class="tt-title">HORARIO DE ATENCIÓN</h6>
							<address>
								7 Days a week<br>
								from 10 AM to 6 PM
							</address>
						</div>
					</div>
				</div>
			</div>
		</div>
	</div>
	<div class="container-indent">
		<div class="container container-fluid-custom-mobile-padding">
			<div id="contactform" class="contact-form form-default" method="post" novalidate="novalidate" action="#">
				<div class="row">
					<div class="col-md-6">
						<div class="form-group">
							<input type="text" name="name" class="form-control" id="inputName" placeholder="Your Name (required)">
						</div>
						<div class="form-group">
							<input type="text" name="email" class="form-control" id="inputEmail" placeholder="Your Email (required)">
						</div>
						<div class="form-group">
							<input type="text" name="subject" class="form-control" id="inputSubject" placeholder="Subject">
						</div>
					</div>
					<div class="col-md-6">
						<div class="form-group">
							<textarea  name="message" class="form-control" rows="7" placeholder="Your Message"  id="textareaMessage"></textarea>
						</div>
					</div>
				</div>
				<div class="text-center">
					<button type="submit" class="btn">SEND MESSAGE</button>
				</div>
			</div>
		</div>
	</div>
</div>


</asp:Content>
