using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TP04_WEBAPI.Models
{
    public class LivroRepositorio : ILivroRepositorio
    {   
            private List<Livro> livros = new List<Livro>();
            private int _nextId = 1;

            public LivroRepositorio()
            {
                Add(new Livro { Nome = "Orgulho e Preconceito", Autor = "Jane Austen", Preco = 44.59M });
                Add(new Livro { Nome = "Dom Quixote de la Mancha", Autor = "Miguel de Cervantes", Preco = 35.75M });
                Add(new Livro { Nome = "Dom Casmurro", Autor = "Machado de Assis", Preco = 53.90M });
                Add(new Livro { Nome = "O Conde de Monte Cristo", Autor = "Alexandre Dumas", Preco = 23.99M });
                Add(new Livro { Nome = "Cem Anos de Solidão", Autor = "Gabriel García Márquez", Preco = 66.50M });
                Add(new Livro { Nome = "Eu, Robô", Autor = "Isaac Asimov", Preco = 54.25M });
            }

            public Livro Add(Livro item)
            {
                if (item == null)
                {
                    throw new ArgumentNullException("item");
                }
                item.Id = _nextId++;
                livros.Add(item);
                return item;
            }

            public Livro Get(int id)
            {
                return livros.Find(p => p.Id == id);
            }

            public IEnumerable<Livro> GetAll()
            {
                return livros;
            }

            public void Remove(int id)
            {
                livros.RemoveAll(p => p.Id == id);
            }

            public bool Update(Livro item)
            {
                if (item == null)
                {
                    throw new ArgumentNullException("item");
                }

                int index = livros.FindIndex(p => p.Id == item.Id);

                if (index == -1)
                {
                    return false;
                }
                livros.RemoveAt(index);
                livros.Add(item);
                return true;
            }
        }
    
}
