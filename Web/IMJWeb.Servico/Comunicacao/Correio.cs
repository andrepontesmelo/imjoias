using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net.Mail;
using System.Web;
using IMJWeb.Dominio;

namespace IMJWeb.Servico.Comunicacao
{
    public class Correio
    {
        public const string Remetente = "Indústria Mineira de Joias <sistema-web@imjoias.com.br>";
#if DEBUG
        private const string Destinatario = "juliomelo@imjoias.com.br";
#else
        private const string Destinatario = "{0}@imjoias.com.br";
#endif
        private const string Usuario = "sistema-web@imjoias.com.br";
        private const string Senha = "2hjkl34zp5";
        private const bool Criptografado = true;
        private const string Host = "smtp.gmail.com";
        private const int Porta = 587;

        public enum Categoria
        {
            Cadastro,
            Pedido,
            Duvida,
            Sugestao,
            Reclamacao,
            TrocaDevolucao
        }

        /// <summary>
        /// Envia uma mensagem pelo correio.
        /// </summary>
        /// <param name="categoria">Categoria da mensagem</param>
        /// <param name="dados">Dados do formulário</param>
        public void Enviar(Categoria categoria, IDictionary<string, string> dados)
        {
            string nome = ExtrairNome(dados);
            MailMessage email = new MailMessage(Remetente, string.Format(Destinatario, categoria.ToString().ToLower()))
            {
                Body = GerarTabela(dados),
                IsBodyHtml = true,
                Subject = GerarAssunto(categoria)
            };

            if (nome != null)
            {
                email.From = new MailAddress(Remetente, nome);
                email.Subject += " de " + nome;
            }

            bool emailPreenchido = false;

            if (dados.ContainsKey("E-Mail:") && !string.IsNullOrEmpty(dados["E-Mail:"]))
            {
                try
                {
                    if (nome != null)
                        email.ReplyTo = new MailAddress(dados["E-Mail:"], nome);
                    else
                        email.ReplyTo = new MailAddress(dados["E-Mail:"]);

                    emailPreenchido = true;
                }
                catch (FormatException)
                { }
            }

            if (!emailPreenchido)
            {
                if (dados.ContainsKey("E-Mail Pessoal:") && !string.IsNullOrEmpty(dados["E-Mail Pessoal:"]))
                {
                    try
                    {
                        if (nome != null)
                            email.ReplyTo = new MailAddress(dados["E-Mail Pessoal:"], nome);
                        else
                            email.ReplyTo = new MailAddress(dados["E-Mail Pessoal:"]);
                    }
                    catch (FormatException)
                    { }
                }
            }

#if DEBUG
            email.Subject += " [DEBUG]";
#endif

            var cliente = CriarCliente();

            cliente.Send(email);

            EnviarConfirmacaoRecebimento(categoria, email, dados);
        }

        /// <summary>
        /// Encaminha confirmação de envio de email.
        /// </summary>
        /// <param name="categoria">Categoria.</param>
        /// <param name="email">E-mail enviado</param>
        private void EnviarConfirmacaoRecebimento(Categoria categoria, MailMessage email, IDictionary<string, string> dados)
        {
            MailMessage recibo = new MailMessage()
            {
                From = new MailAddress(Remetente),
                Subject = "Recebimento de mensagem",
                IsBodyHtml = true,
                ReplyTo = email.To.First()
            };

            if (dados.ContainsKey("E-Mail:") && !string.IsNullOrEmpty(dados["E-Mail:"]))
            {
                string nome;

                if (!dados.TryGetValue("Razão Social:", out nome))
                    nome = dados["Nome:"];

                try
                {
                    if (nome != null)
                        recibo.To.Add(new MailAddress(dados["E-Mail:"], nome));
                    else
                        recibo.To.Add(new MailAddress(dados["E-Mail:"]));
                }
                catch
                { }
            }

            if (dados.ContainsKey("E-Mail Pessoal:") && !string.IsNullOrEmpty(dados["E-Mail Pessoal:"]))
            {
                try
                {
                    string nome = dados["Nome:"];

                    if (nome != null)
                        recibo.To.Add(new MailAddress(dados["E-Mail Pessoal:"], nome));
                    else
                        recibo.To.Add(new MailAddress(dados["E-Mail Pessoal:"]));
                }
                catch
                { }
            }

            recibo.Body = string.Format("<p>Prezado(a) {0},</p>", dados["Nome:"] ?? "cliente");

            if (categoria != Categoria.Cadastro)
            {
                recibo.Body += "<p>Esta é uma mensagem automática apenas para informá-lo(a) de que seu formul&aacute;rio foi encaminhado para nossos atendentes e, logo que poss&iacute;vel, entraremos em contato por e-mail ou por telefone.</p>";
                recibo.Body += "<p>Ind&uacute;stria Mineira de Joias</p>";
                recibo.Body += "<br/><br/><p>Dados do formul&aacute;rio:</p>";
                recibo.Body += email.Body;
            }
            else
            {
                recibo.Body += "<p>Esta é uma mensagem automática apenas para informá-lo(a) de que seu formul&aacute;rio de cadastro foi encaminhado para nossos atendentes.</p>";
                recibo.Body += "<p>O usuário e a senha para acesso ao cat&aacute;logo ser&atilde;o liberados por e-mail apenas ap&oacute;s <strong>aprova&ccedil;&atilde;o da empresa</strong>, ainda a ser realizada.</p>";
                recibo.Body += "<p>Logo que poss&iacute;vel, entraremos em contato por e-mail ou por telefone, para verificarmos a possibilidade da visita de nosso representante.</p>";
                recibo.Body += "<p>Ind&uacute;stria Mineira de Joias</p>";
            }

            var cliente = CriarCliente();
            cliente.Send(recibo);
        }

        /// <summary>
        /// Extrai o nome do usuário.
        /// </summary>
        private static string ExtrairNome(IDictionary<string, string> dados)
        {
            if (dados.ContainsKey("Nome:") && !string.IsNullOrEmpty(dados["Nome:"]))
                return dados["Nome:"];

            else if (dados.ContainsKey("Razão Social:") && !string.IsNullOrEmpty(dados["Razão Social:"]))
                return dados["Razão Social:"];

            else
                return null;
        }

        /// <summary>
        /// Define o assunto de uma mensagem a partir da categoria.
        /// </summary>
        /// <param name="categoria">Categoria da mensagem</param>
        /// <returns>Assunto</returns>
        private string GerarAssunto(Categoria categoria)
        {
            switch (categoria)
            {
                case Categoria.Cadastro:
                    return "[IMJWeb] Requisição de cadastro";
                    
                case Categoria.Duvida:
                    return "[IMJWeb] Dúvida";

                case Categoria.Pedido:
                    return "[IMJWeb] Pedido";

                case Categoria.Reclamacao:
                    return "[IMJWeb] Reclamação";

                case Categoria.Sugestao:
                    return "[IMJWeb] Sugestão";

                case Categoria.TrocaDevolucao:
                    return "[IMJWeb] Troca/Devolução";

                default:
                    return "[IMJWeb]";
            }
        }

        /// <summary>
        /// Gera uma tabela a partir de um dicionário de dados.
        /// </summary>
        /// <param name="dados">Dicionário de dados</param>
        /// <returns>Tabela em HTML</returns>
        private string GerarTabela(IDictionary<string, string> dados)
        {
            StringBuilder html = new StringBuilder("<table><tr><th>Campo</th><th>Resposta</th></tr>");

            foreach (KeyValuePair<string, string> par in dados)
                html.AppendFormat("<tr><th align='right'>{0}</th><td>{1}</td></tr>", HttpUtility.HtmlEncode(par.Key), HttpUtility.HtmlEncode(par.Value));

            html.Append("</table>");

            return html.ToString();
        }

        /// <summary>
        /// Cria um cliente de SMTP.
        /// </summary>
        /// <returns>Cliente de SMTP.</returns>
        private SmtpClient CriarCliente()
        {
            SmtpClient cliente = new SmtpClient(Host, Porta)
            {
                EnableSsl = Criptografado,
                DeliveryMethod = SmtpDeliveryMethod.Network,
                Credentials = new System.Net.NetworkCredential(Usuario, Senha)
            };

            return cliente;
        }

        /// <summary>
        /// Envia e-mail com redefinição de senha.
        /// </summary>
        /// <param name="usuario">Usuário cuja senha será enviada.</param>
        /// <param name="senha">Nova senha do usuário.</param>
        internal void EnviarRedefinicaoSenha(IUsuario usuario, string senha)
        {
            MailMessage email = new MailMessage(Remetente, usuario.EMail)
            {
                Body = string.Format("Prezado(a) {0},\n\nVocê está recebendo sua nova senha para acesso ao catálogo da Indústria Mineira de Joias.  Para acessá-lo, navegue até http://www.imjoias.com.br/ e preencha os seguintes campos:\n\nLogin: {1}\nSenha: {2}\n\nRecomendamos que a senha seja alterada após o primeiro uso.\n\nEm caso de dúvidas, entre em contato com nossos atendentes por meio do e-mail duvida@imjoias.com.br.\n\n\n\nIndústria Mineira de Joias\nRua Pouso Alegre, 546 - Floresta | Belo Horizonte | MG | Brasil | +55 (31) 3057.7555\n\n(Mensagem gerada automaticamente pelo sistema)",
                    usuario.Nome, usuario.Login, senha),
                IsBodyHtml = false,
                Subject = "Redefinição de senha para acesso ao catálogo da Indústria Mineira de Joias"
            };
            var cliente = CriarCliente();

            cliente.Send(email);
        }

        internal void EnviarCriacaoUsuario(IUsuario usuario, string senha)
        {
            MailMessage email = new MailMessage(Remetente, usuario.EMail)
            {
                Body = string.Format("Prezado(a) {0},\n\nVocê está recebendo a sua senha de acesso ao catálogo da Indústria Mineira de Joias.  Para acessá-lo, navegue até http://www.imjoias.com.br/ e preencha os seguintes campos:\n\nLogin: {1}\nSenha: {2}\n\nRecomendamos que a senha seja alterada após o primeiro uso.\n\nEm caso de dúvidas, entre em contato com nossos atendentes por meio do e-mail duvida@imjoias.com.br.\n\n\n\nIndústria Mineira de Joias\nRua Pouso Alegre, 546 - Floresta | Belo Horizonte | MG | Brasil | +55 (31) 3057.7555\n\n(Mensagem gerada automaticamente pelo sistema)",
                    usuario.Nome, usuario.Login, senha),
                IsBodyHtml = false,
                Subject = "Senha para acesso ao catálogo da Indústria Mineira de Joias"
            };
            var cliente = CriarCliente();

            cliente.Send(email);
        }

        public void Enviar(Exception ex)
        {
            StringBuilder sb = new StringBuilder();

            if (HttpContext.Current != null)
            {
                try
                {
                    sb.AppendFormat("URL: {0}", HttpContext.Current.Request.Url);
                    sb.AppendLine();
                    sb.AppendFormat("Referrer: {0}", HttpContext.Current.Request.UrlReferrer);
                    sb.AppendLine();
                    sb.AppendFormat("IP: {0} ({1})", HttpContext.Current.Request.UserHostAddress, HttpContext.Current.Request.UserHostName);
                    sb.AppendLine();
                    sb.AppendFormat("Navegador: {0}", HttpContext.Current.Request.UserAgent);
                    sb.AppendLine();
                }
                catch
                {
                }
            }

            sb.AppendFormat("Data e hora: {0:dd/MM/yyyy HH:mm:ss}", DateTime.Now);
            sb.AppendLine();
            sb.AppendLine();
            sb.Append(ex.ToString());

            MailMessage email = new MailMessage(Remetente, "juliomelo@imjoias.com.br")
            {
                Body = sb.ToString(),
                IsBodyHtml = false,
                Subject = "Exceção - " + ex.Message
            };
            var cliente = CriarCliente();

#if !DEBUG
            cliente.Send(email);
#endif
        }
    }
}
