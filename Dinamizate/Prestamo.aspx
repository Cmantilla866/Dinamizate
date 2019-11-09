<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Prestamo.aspx.cs" Inherits="Dinamizate.Prestamo" %>

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
							<h1>Prestamo</h1>
						</div>
						<form runat="server">
                            <div class="row">
								<div class="col-sm-8">
									<div class="form-group">
								        <span class="form-label">Reserva</span>
                                        <asp:DropDownList ID="R" CssClass="form-control" runat="server">
                                        </asp:DropDownList>
                                        <span class="select-arrow"></span>
							        </div>
								</div>
								<div class="col-sm-4">
                                    <span class="form-label">  </span>
									<div class="form-btn">
                                        <asp:Button ID="Actualizar" CssClass="submit-btn" runat="server" Text="Actualizar" OnClick="Actualizar_Click"/>
							        </div>
								</div>
							</div>
							<div class="row">
								<div class="col-sm-5">
									<div class="form-group">
										<span class="form-label">Fecha Del Prestamo</span>
                                        <asp:TextBox ID="FechaPrestamo" CssClass="form-control" type="text" ReadOnly="true" placeholder="dd/mm/aaaa" runat="server"></asp:TextBox>
									</div>
								</div>
								<div class="col-sm-7">
									<div class="row">
										<div class="col-sm-6">
											<div class="form-group">
												<span class="form-label">Hora</span>
                                                <asp:DropDownList ID="HoraPrestamo" CssClass="form-control" runat="server">
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
												<asp:DropDownList ID="MinutoPrestamo" CssClass="form-control" runat="server">
                                                    <asp:ListItem>0</asp:ListItem>
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
								<div class="col-sm-5">
									<div class="form-group">
										<span class="form-label">Fecha Estimada de Retorno</span>
                                        <asp:TextBox ID="FechaEstimada" CssClass="form-control" type="date" runat="server"></asp:TextBox>
									</div>
								</div>
								<div class="col-sm-7">
									<div class="row">
										<div class="col-sm-6">
											<div class="form-group">
												<span class="form-label">Hora</span>
                                                <asp:DropDownList ID="HoraEstimada" CssClass="form-control" runat="server">
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
												<asp:DropDownList ID="MinutoEstimado" CssClass="form-control" runat="server">
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
                            <div class="form-group">
								<span class="form-label">Observaciones</span>
                                <asp:TextBox ID="Observaciones" CssClass="form-control" type="text" runat="server"></asp:TextBox>
							</div>
							<div class="form-btn">
                                <asp:Button ID="Prestar" CssClass="submit-btn" runat="server" Text="Prestar" OnClick="Prestar_Click"/>
							</div>
						</form>
					</div>
				</div>
			</div>
		</div>
	</div>
</body><!-- This templates was made by Colorlib (https://colorlib.com) -->

</html>