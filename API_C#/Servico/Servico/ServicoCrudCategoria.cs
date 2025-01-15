using Domain.Entity;
using Loja;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infraestrutura.Servico
{
    public class ServicoCrudCategoria
    {
        private readonly LojaDbContext context;

        // Injeção de dependência para o DbContext
        public ServicoCrudCategoria(LojaDbContext dbContext)
        {
            context = dbContext;
        } 

        public List<Categoria> ObterCategoria()
        {
            string sql = "SELECT * FROM Categoria"; 

            List<Categoria> listaCategoria = context.Categoria
                                                  .FromSqlRaw(sql)  
                                                  .ToList();

            return listaCategoria;
        }


        public void AdicionarCategoria(Categoria categoria)
        {
            context.Categoria.Add(categoria); 
            context.SaveChanges();        
        }

        public Categoria ObterCategoriaPorId(int id)
        {
            return context.Categoria.Find(id);
        }

        public void RemoverCategoria(Categoria categoria)
        {
            if (categoria != null)
            {
                context.Categoria.Remove(categoria);
                context.SaveChanges(); // Confirma a exclusão no banco
            }
        }
    }
}
