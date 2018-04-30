using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Data;
using Bussines.Model;
using System.Web;

namespace Bussines
{
    public class Rules
    {

        public static Repository repository = new Repository();

        public static List<Pessoa> UsersList()
        {
            
            return DataToBussinessModel(repository.GetUsers());
        }

        public static void WriteCookie(string value)
        {
            var cookie = new HttpCookie("CookieIDs", value);
            HttpContext.Current.Response.Cookies.Set(cookie);
        }

        public static string ReadCookie(string name)
        {
            if (HttpContext.Current.Response.Cookies.AllKeys.Contains(name))
            {
                var cookie = HttpContext.Current.Response.Cookies[name];
                return cookie.Value;
            }

            if (HttpContext.Current.Request.Cookies.AllKeys.Contains(name))
            {
                var cookie = HttpContext.Current.Request.Cookies[name];
                return cookie.Value;
            }

            return null;
        }


        private static List<Pessoa> DataToBussinessModel(List<Data.Model.Pessoa> data)
        {
            List<Pessoa> pessoas = new List<Pessoa>();

            foreach (Data.Model.Pessoa pessoa in data)
            {
                Pessoa p = new Pessoa();
                p.PessoaID = pessoa.PessoaID;
                p.Nome = pessoa.Nome;
                p.Sobrenome = pessoa.Sobrenome;
                p.Email = pessoa.Email;
                p.DtAniversario = (DateTime)pessoa.DtAniversario;

                pessoas.Add(p);
            }
            return pessoas;
        }
    }
}
