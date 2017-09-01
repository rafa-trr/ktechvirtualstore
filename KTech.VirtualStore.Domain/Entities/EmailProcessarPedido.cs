using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Net.Mail;

namespace KTech.VirtualStore.Domain.Entities
{
    public class EmailPedido
    {
        private readonly EmailConfiguracoes _emailConfiguracoes;

        public EmailPedido(EmailConfiguracoes emailConfiguracoes)
        {
            _emailConfiguracoes = emailConfiguracoes;
        }

        public void ProcessarPedido(Carrinho carrinho, Pedido pedido)
        {
            using(var smtpClient = new SmtpClient())
            {
                smtpClient.EnableSsl = _emailConfiguracoes.UsarSsl;
                smtpClient.Host = _emailConfiguracoes.ServidorSmtp;
                smtpClient.Port = _emailConfiguracoes.ServidorPorta;
                smtpClient.UseDefaultCredentials = false;
                smtpClient.Credentials = new NetworkCredential(_emailConfiguracoes.Usuario, _emailConfiguracoes.ServidorSmtp);

                if(_emailConfiguracoes.EscreverArquivo)
                {
                    smtpClient.DeliveryMethod = SmtpDeliveryMethod.SpecifiedPickupDirectory;
                    smtpClient.PickupDirectoryLocation = _emailConfiguracoes.PastaArquivo;
                    smtpClient.EnableSsl = false;
                }

                StringBuilder sbBody = new StringBuilder()
                    .AppendLine("Novo Pedido:")
                    .AppendLine("-------")
                    .AppendLine("Itens");

                foreach(var item in carrinho.ItensCarrinho)
                {
                    var subtotal = item.Produto.Preco * item.Quantidade;
                    sbBody.AppendFormat("{0} x {1} (subtotal: {2:c}", item.Quantidade, item.Produto.Nome, subtotal);
                }

                sbBody.AppendFormat("Valor total do pedido: {0:c}", carrinho.ObterValorTotal())
                    .AppendLine("----------------------")
                    .AppendLine("Enviar para:")
                    .AppendLine(pedido.NomeCliente)
                    .AppendLine(pedido.Email)
                    .AppendLine(pedido.Endereco ?? "")
                    .AppendLine(pedido.Cidade ?? "")
                    .AppendLine(pedido.Complemento ?? "")
                    .AppendLine("---------------------")
                    .AppendFormat("Para presente?: {0}", pedido.EmbrulhaPresente ? "Sim" : "Não");

                MailMessage mailMessage = new MailMessage(_emailConfiguracoes.Remetente, 
                    _emailConfiguracoes.Destinatario, "Novo pedido", sbBody.ToString());

                if (_emailConfiguracoes.EscreverArquivo)
                {
                    mailMessage.BodyEncoding = Encoding.GetEncoding("ISO-8859-1");
                }

                smtpClient.Send(mailMessage);
            }
        }
    }
}
