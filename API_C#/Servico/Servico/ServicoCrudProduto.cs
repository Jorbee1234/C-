using Domain.Entity;
using Microsoft.EntityFrameworkCore;

namespace Loja
{
    public class ServicoCrudProduto
    {
        private readonly LojaDbContext context;

        // Injeção de dependência para o DbContext
        public ServicoCrudProduto(LojaDbContext dbContext)
        {
            context = dbContext;
        }

        public List<Produto> ObterProduto()
        {
            string sql = "SELECT * FROM Produto";

            List<Produto> listaProduto = context.Produto
                                                  .FromSqlRaw(sql)
                                                  .ToList();

            return listaProduto;
        }


        public void AdicionarProduto(Produto produto)
        {
            context.Produto.Add(produto);
            context.SaveChanges();
        }

        public Produto ObterProdutoPorId(int id)
        {
            return context.Produto.Find(id);
        }

        public void RemoverProduto(Produto produto)
        {
            if (produto != null)
            {
                context.Produto.Remove(produto);
                context.SaveChanges(); // Confirma a exclusão no banco
            }
        }
    }
}
