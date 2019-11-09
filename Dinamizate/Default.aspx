<%@ Page Title="Login" Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="Dinamizate._Default" %>

<!DOCTYPE html>
<html lang="en">
   <head>
      <meta name="viewport" content="width=device-width, initial-scale=1" />
      <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
      <script>
          addEventListener("load", function () { setTimeout(hideURLbar, 0); }, false); function hideURLbar() { window.scrollTo(0, 1); }
      </script>
      <link href="Content/style.css" rel='stylesheet' type='text/css' media="all">
      <link href="//fonts.googleapis.com/css?family=Source+Sans+Pro:400,600,700" rel="stylesheet">
   </head>
   <body>
       <form runat="server">
      <div class="mid-class">
         <div class="art-right-w3ls">
            <h2>Inicia sesión!</h2>
              <div class="main">
                  <div class="form-left-to-w3l">
                     <asp:TextBox ID="CedulaI" type="Number" Text="0000000000" placeholder="Cedula" required="false"  runat="server"></asp:TextBox>
                  </div>
                  <div class="form-left-to-w3l ">
                     <asp:TextBox ID="ContraseñaI" type="password" Text="Contraseña" placeholder="Contraseña" required="false" runat="server"></asp:TextBox>
                     <div class="clear"></div>
                  </div>
               </div>
               <div class="clear"></div>
               <div class="btnn">
                  <asp:Button ID="Login" CssClass="btn" runat="server" Text="Ingresar" OnClick="Login_Click" />
               </div>
            <div class="w3layouts_more-buttn">
               <h3>Registrarse 
                  <a href="#content1">Aquí
                  </a>
               </h3>
            </div>
            <div id="content1" class="popup-effect">
                <div class="popup">
                    <div class="letter-w3ls">
                        <h3> Datos Personales </h3>
                        <br />
                        <table style="width: 100%;">
                          <tr>
                              <td>
                                <div class="form-left-to-w3l">
                                    <asp:TextBox ID="CedulaR" type="Number" placeholder="Cedula" CausesValidation="false" required="false" runat="server"></asp:TextBox>
                                </div>
                              </td>
                              <td>
                                <div class="form-left-to-w3l">
                                    <asp:TextBox ID="Nombre" type="text" placeholder="Nombre" CausesValidation="false" required="false" runat="server"></asp:TextBox>
                                </div>
                              </td>
                              <td>
                                <div class="form-left-to-w3l">
                                    <asp:TextBox ID="Ciudad" type="text" placeholder="Ciudad" CausesValidation="false" required="false" runat="server"></asp:TextBox>
                                </div>
                              </td>
                              <td>
                                <div class="form-left-to-w3l">
                                    <asp:TextBox ID="Direccion" type="text" placeholder="Dirección" CausesValidation="false" required="false" runat="server"></asp:TextBox>
                                </div>
                              </td>
                          </tr>
                          <tr>
                              
                              <td>
                                <div class="form-left-to-w3l margin-zero">
                                    <asp:TextBox ID="Celular" type="number" AutoCompleteType="Cellular" CausesValidation="false" placeholder="Celular" required="false" runat="server"></asp:TextBox>
                                </div>
                              </td>
                              <td>
                                <div class="form-left-to-w3l margin-zero">
                                    <asp:TextBox ID="Fijo" type="number" placeholder="Fijo" CausesValidation="false" AutoCompleteType="HomePhone" required="false" runat="server"></asp:TextBox>
                                </div>
                              </td>
                              <td>
                                <div class="form-left-to-w3l margin-zero">
                                    <asp:TextBox ID="ContraseñaR" type="password" placeholder="Contraseña" CausesValidation="false" required="false" runat="server"></asp:TextBox>
                                </div>
                              </td>
                          </tr>
                        </table>
                        <h3> Datos Familiares </h3>
                        <br />
                        <table style="width: 100%;">
                          <tr>
                              <td>
                                <div class="form-left-to-w3l">
                                    <asp:TextBox ID="CedulaF" type="number" placeholder="Cedula" CausesValidation="false" required="false" runat="server"></asp:TextBox>
                                </div>
                              </td>
                              <td>
                                <div class="form-left-to-w3l">
                                    <asp:TextBox ID="NombreF" type="text" placeholder="Nombre" CausesValidation="false" required="false" runat="server"></asp:TextBox>
                                </div>
                              </td>
                              <td>
                                <div class="form-left-to-w3l">
                                    <asp:TextBox ID="NumeroF" type="number" placeholder="Telefono" CausesValidation="false" required="false" runat="server"></asp:TextBox>
                                </div>
                              </td>
                          </tr>
                         
                        </table>
                        <div class="form-left-to-w3l">
                            <asp:TextBox ID="Parentesco" type="text" placeholder="Parentesco" CausesValidation="false" required="false" runat="server"></asp:TextBox>
                        </div>
                        <div class="btnn">
                           <asp:Button ID="SignUp" CssClass="btn" runat="server" Text="Registrarse" OnClick="SignUp_Click" />
                           <br>
                        </div>
                     <div class="clear"></div>
                  </div>
                  <a class="close" href="#">&times;</a>
               </div>
            </div>
         </div>
         <div class="art-left-w3ls">
            <h1 class="header-w3ls">
               Dinamízate!
            </h1>
         </div>
      </div>
           </form>
   </body>
</html>
