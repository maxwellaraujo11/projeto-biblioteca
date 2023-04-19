using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace Biblioteca.Models
{
    public class UsuarioService
    {
         public void Inserir(Usuario u)
        {
            using(BibliotecaContext bc = new BibliotecaContext())
            {
                bc.Usuarios.Add(u);
                bc.SaveChanges();
            }
        }


         public ICollection<Usuario> ListarTodos(FiltrosUsuarios filtro = null)
        {
            using(BibliotecaContext bc = new BibliotecaContext())
            {
                IQueryable<Livro> query;
                
                if(filtro != null)
                {
                    //definindo dinamicamente a filtragem
                    switch(filtro.TipoFiltro)
                    {
                        case "Login":
                            query = bc.Usuarios.Where(u => u.Login.Contains(filtro.Filtro));
                        break;

                        case "Senha":
                            query = bc.Usuarios.Where(u => u.Senha.Contains(filtro.Filtro));
                        break;

                        default:
                            query = bc.Usuario;
                        break;
                    }
                }
                else
                {
                    // caso filtro não tenha sido informado
                    query = bc.Usuarios;
                }
                
                //ordenação padrão
                return query.OrderBy(u => u.Login).ToList();
            }
        }

    }
}