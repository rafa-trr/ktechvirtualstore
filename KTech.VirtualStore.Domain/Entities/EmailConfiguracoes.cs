namespace KTech.VirtualStore.Domain.Entities
{
    public class EmailConfiguracoes
    {
        public string Destinatario = "pedido@ktech.com.br";
        public bool EscreverArquivo = false;
        public string PastaArquivo = @"c:\envioemail";
        public string Remetente = "ktech@ktech.com.br";
        public int ServidorPorta = 587;
        public string ServidorSmtp = "smtp.ktech.com.br";
        public bool UsarSsl = false;
        public string Usuario = "ktech";
    }
}