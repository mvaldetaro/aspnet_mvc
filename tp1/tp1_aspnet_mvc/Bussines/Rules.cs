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
        
        private static List<Pessoa> DataToBussinessModel(List<Data.Model.Pessoa> data)
        {
            List<Pessoa> pessoas = new List<Pessoa>();

            foreach (Data.Model.Pessoa pessoa in data)
            {
                Pessoa p = new Pessoa();
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
