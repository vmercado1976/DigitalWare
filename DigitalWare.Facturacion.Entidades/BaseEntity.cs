using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DigitalWare.Facturacion.Entidades
{
    public class BaseEntity
    {
        private int _Id;
        public int Id { get => _Id; set => _Id = value; }
    }
}
