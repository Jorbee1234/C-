using Domain.Entity;
using Microsoft.EntityFrameworkCore;

namespace Loja
{
    public class ServicoCrudUsuario
    {
        private readonly LojaDbContext context;

        // Injeção de dependência para o DbContext
        public ServicoCrudUsuario(LojaDbContext dbContext)
        {
            context = dbContext;
        }

        public List<Usuario> ObterUsuario()
        {
            string sql = "SELECT * FROM Usuario"; // Sua consulta SQL

            // Usando FromSqlRaw para mapear o resultado para o tipo Usuario
            List<Usuario> listaUsuarios = context.Usuario
                                                  .FromSqlRaw(sql)  // Executa o SQL
                                                  .ToList();

            return listaUsuarios;
        }

        // Método para adicionar um novo usuário
        public void AdicionarUsuario(Usuario usuario)
        {
            context.Usuario.Add(usuario); // Adiciona o usuário no contexto
            context.SaveChanges();        // Salva as alterações no banco
        }

        public Usuario ObterUsuarioPorId(int id)
        {
            return context.Usuario.Find(id);
        }

        public void RemoverUsuario(Usuario usuario)
        {
            if (usuario != null)
            {
                context.Usuario.Remove(usuario);
                context.SaveChanges(); // Confirma a exclusão no banco
            }
        }
    }
}
