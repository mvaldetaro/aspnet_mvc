using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Web.ViewModel;
using Bussines.Model;

namespace Web.Lib
{
    public class Helper
    {
        public static List<Amigo> ToViewModel(List<Pessoa> data)
        {
            List<Amigo> pessoas = new List<Amigo>();

            foreach (Pessoa pessoa in data)
            {
                Amigo p = new Amigo();
                p.Nome = pessoa.Nome;
                p.Sobrenome = pessoa.Sobrenome;
                p.Email = pessoa.Email;
                p.DtAniversario = pessoa.DtAniversario;

                pessoas.Add(p);
            }
            return pessoas;
        }
    }
}