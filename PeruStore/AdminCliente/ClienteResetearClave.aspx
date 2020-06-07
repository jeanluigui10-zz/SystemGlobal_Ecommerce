<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ClienteResetearClave.aspx.cs" Inherits="PeruStore.AdminCliente.ClienteResetearClave" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title></title>
    <link href="../Template/css/bootstrap/css/bootstrap.min.css" rel="stylesheet" />
    <link href="../Template/js/jquery-ui/jquery-ui.min.css" rel="stylesheet" />
     <script type="text/javascript" src="/Template/js/jquery-2.2.4.min.js"></script>
    <style type="text/css">
        .Contenedor {
            width: 360px;
            padding: 8% 0 0;
            margin: auto;
        }

        div.center {
            text-align: center;
        }
    </style>
    
</head>

<body>
    <div class="Contenedor">
        <div class="account-border">
            <div class="row">
                <div class="col-sm-12 col-md-10 col-lg-12">
                    <div id="divMensaje"></div>
                    <div class="well">
                        <h4><i class="fa fa-file-text-o" aria-hidden="true"></i>Recuperar acceso</h4>
                        <div class="form-group">
                            <label class="control-label " for="input-password">Ingrese nuevo Password</label>
                            <input type="password" id="txtContrasenha" name="password" placeholder="Password" class="form-control" />
                        </div>
                        <div class="form-group">
                            <label class="control-label " for="input-password">Confirmar Password</label>
                            <input type="password" id="txtContrasenhaConfirmacion" name="password" placeholder="Password" class="form-control" />
                        </div>
                        <div class="center">
                            <input type="button" id="btnResetear" value="Resetear" class="btn btn-primary" />
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
    <script src="../src/js/Base.js"></script>
    <script src="js/ClienteResetearClave.js"></script>
</body>
</html>
