﻿<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="pagarMulta.aspx.cs" Inherits="Dinamizate.pagarMulta" %>

<!DOCTYPE html>
<html lang="en">

<head>
	<meta charset="utf-8">
	<meta http-equiv="X-UA-Compatible" content="IE=edge">
	<meta name="viewport" content="width=device-width, initial-scale=1">

	<title>Booking Form HTML Template</title>

	<link href="https://fonts.googleapis.com/css?family=Montserrat:400,700" rel="stylesheet">
	<link type="text/css" rel="stylesheet" href="Content/bootstrap2.min.css" />
	<link type="text/css" rel="stylesheet" href="Content/style2.css" />

	<!-- HTML5 shim and Respond.js for IE8 support of HTML5 elements and media queries -->
	<!-- WARNING: Respond.js doesn't work if you view the page via file:// -->
	<!--[if lt IE 9]>
		  <script src="https://oss.maxcdn.com/html5shiv/3.7.3/html5shiv.min.js"></script>
		  <script src="https://oss.maxcdn.com/respond/1.4.2/respond.min.js"></script>
		<![endif]-->

</head>

<body>
	<div id="booking" class="section">
		<div class="section-center">
			<div class="container">
				<div class="row">
					<div class="booking-form">
						<div class="form-header">
							<h1>Pago de multas</h1>
						</div>
						<form runat="server">
                            <div class="form-group">
								<span class="form-label">Cedula del Usuario</span>
                                <asp:TextBox ID="CedulaU" CssClass="form-control" placeholder="Cedula" OnTextChanged="CedulaU_TextChanged" type="text" runat="server"></asp:TextBox>
							</div>
                            <div class="row">
								<div class="col-sm-8">
									<div class="form-group">
								        <span class="form-label">Multa</span>
                                        <asp:DropDownList ID="R" CssClass="form-control" runat="server">
                                        </asp:DropDownList>
                                        <span class="select-arrow"></span>
							        </div>
								</div>
								<div class="col-sm-4">
                                    <span class="form-label"> </span>
									<div class="form-btn">
                                        <asp:Button ID="Actualizar" CssClass="submit-btn" runat="server" Text="Actualizar" OnClick="Actualizar_Click"/>
							        </div>
								</div>
							</div>
                            <div class="form-group">
								<span class="form-label">Causa</span>
                                <asp:TextBox ID="Causa" CssClass="form-control" ReadOnly="true" placeholder="Causa" type="text" runat="server"></asp:TextBox>
							</div>
                            <div class="form-group">
								<span class="form-label">Valor</span>
                                <asp:TextBox ID="Valor" CssClass="form-control" ReadOnly="true" placeholder="Valor" type="text" runat="server"></asp:TextBox>
							</div>
                            <div class="form-btn">
                                <asp:Button ID="Pagar" CssClass="submit-btn" runat="server" Text="Pagar" OnClick="Pagar_Click"/>
							</div>
						</form>
					</div>
				</div>
			</div>
		</div>
	</div>
</body><!-- This templates was made by Colorlib (https://colorlib.com) -->

</html>
