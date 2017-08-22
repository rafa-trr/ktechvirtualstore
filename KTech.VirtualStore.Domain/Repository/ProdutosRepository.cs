using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KTech.VirtualStore.Domain.Entities;
namespace KTech.VirtualStore.Domain.Repository
{
    public class ProdutosRepository
    {
        private readonly EfDbContext _context = new EfDbContext();

        public IEnumerable<Produto> Produtos
        {
            get { return _context.Produtos; }
        }
    }
}
