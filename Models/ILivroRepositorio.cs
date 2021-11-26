using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TP04_WEBAPI.Models
{
    interface ILivroRepositorio
    {
        IEnumerable<Livro> GetAll();
        Livro Get(int id);
        Livro Add(Livro item);
        void Remove(int id);
        bool Update(Livro item);
    }
}
