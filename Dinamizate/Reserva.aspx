<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Reserva.aspx.cs" Inherits="Dinamizate.Reserva" %>

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
							<h1>Reserva una bicicleta</h1>
						</div>
						<form runat="server">
							<div class="row">
                                <div class="col-sm-3">
									<div class="form-group">
										<span class="form-label">Bicicleta</span>
                                        <asp:DropDownList ID="Bicicleta" CssClass="form-control" runat="server"></asp:DropDownList>
									</div>
								</div>
								<div class="col-sm-4">
									<div class="form-group">
										<span class="form-label">Fecha De la Reserva</span>
                                        <asp:TextBox ID="Fecha" CssClass="form-control" type="date" runat="server"></asp:TextBox>
									</div>
								</div>
								<div class="col-sm-5">
									<div class="row">
										<div class="col-sm-6">
											<div class="form-group">
												<span class="form-label">Hora</span>
                                                <asp:DropDownList ID="Hora" CssClass="form-control" runat="server">
                                                    <asp:ListItem>6</asp:ListItem>
                                                    <asp:ListItem>7</asp:ListItem>
                                                    <asp:ListItem>8</asp:ListItem>
                                                    <asp:ListItem>9</asp:ListItem>
                                                    <asp:ListItem>10</asp:ListItem>
                                                    <asp:ListItem>11</asp:ListItem>
                                                    <asp:ListItem>12</asp:ListItem>
                                                    <asp:ListItem>13</asp:ListItem>
                                                    <asp:ListItem>14</asp:ListItem>
                                                    <asp:ListItem>15</asp:ListItem>
                                                    <asp:ListItem>16</asp:ListItem>
                                                    <asp:ListItem>17</asp:ListItem>
                                                    <asp:ListItem>18</asp:ListItem>
                                                    <asp:ListItem>19</asp:ListItem>
                                                </asp:DropDownList>
												<span class="select-arrow"></span>
											</div>
										</div>
										<div class="col-sm-6">
											<div class="form-group">
												<span class="form-label">Minuto</span>
												<asp:DropDownList ID="Minuto" CssClass="form-control" runat="server">
                                                    <asp:ListItem>00</asp:ListItem>
                                                    <asp:ListItem>05</asp:ListItem>
                                                    <asp:ListItem>10</asp:ListItem>
                                                    <asp:ListItem>15</asp:ListItem>
                                                    <asp:ListItem>25</asp:ListItem>
                                                    <asp:ListItem>30</asp:ListItem>
                                                    <asp:ListItem>40</asp:ListItem>
                                                    <asp:ListItem>45</asp:ListItem>
                                                    <asp:ListItem>50</asp:ListItem>
                                                    <asp:ListItem>55</asp:ListItem>
                                                </asp:DropDownList>
												<span class="select-arrow"></span>
											</div>
										</div>
									</div>
								</div>
							</div>
                            <div class="row">
								<div class="col-sm-8">
									<div class="form-btn">
                                        <asp:Button ID="Reservar" CssClass="submit-btn" runat="server" Text="Reservar" OnClick="Reservar_Click"/>
							        </div>
								</div>
								<div class="col-sm-4">
                                    <div class="form-btn">
                                        <asp:Button ID="Salir" CssClass="submit-btn" runat="server" Text="Salir" OnClick="Salir_Click1"/>
							        </div>
								</div>
                            </div>
							
						</form>
					</div>
				</div>
			</div>
		</div>
	</div>
    
</body><!-- This templates was made by Colorlib (https://colorlib.com) -->

</html>