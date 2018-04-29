using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Collections;
using System.Data.Entity;
using Data.Model;


namespace Data
{
    public class Repository
    {
        private db_mvc_friendsEntities db = new db_mvc_friendsEntities();

        public List<Pessoa> GetUsers()
        {
            //var pessoas = db.Pessoas.Include(p => p.PessoaID).Include(p => p.Nome).Include(p => p.Sobrenome).Include(p => p.Email).Include(p => p.DtAniversario);
            var pessoas = db.Pessoas;
            return pessoas.ToList();
        }
    }
}
