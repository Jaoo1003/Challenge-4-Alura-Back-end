using Challenge_4_Users.Models;
using MailKit.Net.Smtp;
using MimeKit;

namespace Challenge_4_Users.Services {
    public class EmailService {

        IConfiguration _configuration;

        public EmailService(IConfiguration configuration) {
            _configuration = configuration;
        }

        public void EmailSend(string[] destinatario, string assunto, int usuarioId, string code) {
            Mensagem mensagem = new Mensagem(destinatario, assunto, usuarioId, code);
            var emailMessage = EmailForm(mensagem);
            Send(emailMessage);
        }

        private void Send(MimeMessage emailMessage) {
            using (SmtpClient client = new SmtpClient()) {
                try {
                    client.Connect(_configuration.GetValue<string>("EmailSettings:SmtpServer"),
                        _configuration.GetValue<int>("EmailSettings:Port"),
                        MailKit.Security.SecureSocketOptions.StartTlsWhenAvailable);
                    client.AuthenticationMechanisms.Remove("XOUATH2");
                    client.Authenticate(_configuration.GetValue<string>("EmailSettings:From"),
                        _configuration.GetValue<string>("EmailSettings:Password"));
                    client.Send(emailMessage);
                }
                catch {
                    throw;
                }
                finally {
                    client.Disconnect(true);
                    client.Dispose();
                }
            }
        }

        private MimeMessage EmailForm(Mensagem mensagem) {
            var emailMessage = new MimeMessage();
            emailMessage.From.Add(new MailboxAddress("", _configuration.GetValue<string>("EmailSettings:From")));
            emailMessage.To.AddRange(mensagem.Destinatario);
            emailMessage.Subject = mensagem.Assunto;
            emailMessage.Body = new TextPart(MimeKit.Text.TextFormat.Text) {
                Text = mensagem.Conteudo
            };

            return emailMessage;
        }
    }
}
