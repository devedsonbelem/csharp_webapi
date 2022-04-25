using Microsoft.EntityFrameworkCore;
using projetoCrud.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace projetoCrud.Persistence
{
    public class ProdutoContext : DbContext
    {

        public ProdutoContext(DbContextOptions<ProdutoContext> options) : base(options)
        {
        }

        public DbSet<Produto> Produtos { set; get; }

    }
}
