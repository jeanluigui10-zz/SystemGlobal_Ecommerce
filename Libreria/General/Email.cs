using System;
using System.Net;
using System.Net.Mail;

namespace Libreria.General
{
    public class Email
    {
        public static bool Enviar(CredencialesSMTPEmail credenciales, String destinatario, String asunto, String mensaje)
        {
            try
            {
                CredencialesSMTPEmail server = new CredencialesSMTPEmail();
                server.EmailFrom = String.Empty;//"danielbrdls@gmail.com";
                server.SMTP = String.Empty;//"email-smtp.sa-east-1.amazonaws.com";
                server.Puerto = 25;
                server.password = String.Empty;//"BEG9rNVLJvWTQEGyVNP+FUjsI2mCOOr+/k0Qij7GdNkh";
                server.Username = String.Empty;//"AKIA5XB6CEA3TPPCE2XQ";
                server.NombreComercio = "DennishStore";

                destinatario = "jeanlesterpl@gmail.com";
                asunto = "test";
                mensaje = "esto es un mensaje de test";

                if (server != null)
                {
                    #region Instancia MailMessage
                    MailMessage mailmensaje = new MailMessage();
                    mailmensaje.To.Add(new MailAddress(destinatario));
                    mailmensaje.From = new MailAddress(server.EmailFrom, String.Concat(server.NombreComercio, " Notification"));
                    mailmensaje.Subject = asunto;
                    mailmensaje.Body = mensaje;
                    mailmensaje.IsBodyHtml = true;
                    mailmensaje.Priority = MailPriority.Normal;
                    #endregion

                    #region Instancia SMTP
                    SmtpClient smtp = new SmtpClient();
                    smtp.Host = server.SMTP; //El servidor anfrition que enviara el correo electrónico.
                    smtp.Port = server.Puerto;
                    smtp.EnableSsl = server.Puerto == 25 ? true : false;
                    smtp.UseDefaultCredentials = false;
                    //smtp.Credentials = new NetworkCredential(credenciales.Username, Encriptador.Desencriptar(credenciales.password)); 
                    smtp.Credentials = new NetworkCredential(server.Username, server.password);
                    #endregion

                    smtp.Send(mailmensaje);
                    mailmensaje.Dispose();
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception ex)
            {
                return false;
            }
        }


        public class CredencialesSMTPEmail
        {
            public String EmailFrom { get; set; }
            public String SMTP { get; set; }
            public Int32 Puerto { get; set; }
            public String Username { get; set; }
            public String password { get; set; }
            public String NombreComercio { get; set; }
        }
    }
}
