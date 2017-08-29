using KTech.VirtualStore.Domain.Entities;

namespace KTech.VirtualStore.Web.Models
{
    public class CarrinhoViewModel
    {
        public Carrinho Carrinho { get; set; }

        public string ReturnUrl { get; set; }
    }
}