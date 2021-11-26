using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using TP04_WEBAPI.Models;

namespace TP04_WEBAPI.Controllers
{
    public class LivrosController : ApiController
    {
        static readonly ILivroRepositorio repositorio = new LivroRepositorio();
        public IEnumerable<Livro> GetAllLivros()
        {
            return repositorio.GetAll();
        }
        public Livro GetLivro(int id)
        {
            Livro item = repositorio.Get(id);
            if (item == null)
            {
                throw new HttpResponseException(HttpStatusCode.NotFound);
            }
            return item;
        }
        public IEnumerable<Livro> GetLivrosPorAutor(string autor)
        {
            return repositorio.GetAll().Where(
                p => string.Equals(p.Autor, autor, StringComparison.OrdinalIgnoreCase));
        }
        public HttpResponseMessage PostLivro(Livro item)
        {
            item = repositorio.Add(item);
            var response = Request.CreateResponse<Livro>(HttpStatusCode.Created, item);
            string uri = Url.Link("DefaultApi", new { id = item.Id });
            response.Headers.Location = new Uri(uri);
            return response;
        }
        public void PutLivro(int id, Livro produto)
        {
            produto.Id = id;
            if (!repositorio.Update(produto))
            {
                throw new HttpResponseException(HttpStatusCode.NotFound);
            }
        }
        public void DeleteLivro(int id)
        {
            Livro item = repositorio.Get(id);
            if (item == null)
            {
                throw new HttpResponseException(HttpStatusCode.NotFound);
            }
            repositorio.Remove(id);
        }
    }
}