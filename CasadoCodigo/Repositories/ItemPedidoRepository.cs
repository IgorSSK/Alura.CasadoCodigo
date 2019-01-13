using CasaDoCodigo.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace CasadoCodigo.Repositories
{
    public interface IItemPedidoRepository
    {

    }
    public class ItemPedidoRepository : BaseRepository<Cadastro>, IItemPedidoRepository
    {
        public ItemPedidoRepository(ApplicationContext context) : base(context)
        {
        }
    }
}
