using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Mail;


namespace Libreria.General
{
    public class Email
    {
        public static bool Enviar(Dictionary<String, String> credenciales, String destinatario, String asunto, String mensaje)
        {
            try
            {
                String mailFrom = credenciales["EmailFrom"];
                String SMTP = credenciales["SMTP"];
                Int32 puerto = Convert.ToInt32(credenciales["Puerto"]);
                String password = credenciales["Password"];
                String username = credenciales["UserName"];
                String comercioNombre = credenciales["ComercioNombre"];

                #region Instancia MailMessage
                MailMessage mailmensaje = new MailMessage();
                mailmensaje.To.Add(new MailAddress(destinatario));
                mailmensaje.From = new MailAddress(mailFrom, String.Concat(comercioNombre, " Notification"));
                mailmensaje.Subject = asunto;
                mailmensaje.Body = mensaje;
                mailmensaje.IsBodyHtml = true;
                mailmensaje.Priority = MailPriority.Normal;
                #endregion

                #region Instancia SMTP
                SmtpClient smtp = new SmtpClient();
                smtp.Host = SMTP; //El servidor anfrition que enviara el correo electrónico.
                smtp.Port = puerto;
                smtp.EnableSsl = puerto == 25 ? true : false;
                smtp.UseDefaultCredentials = false;
                smtp.Credentials = new NetworkCredential(username, Encriptador.Desencriptar(password));
                #endregion

                smtp.Send(mailmensaje);
                mailmensaje.Dispose();
                return true;
            }
            catch (Exception ex)
            {
                Log.Save("Error", "Email: " + ex.Message, ex.StackTrace);
                return false;
            }
        }
    }
}
