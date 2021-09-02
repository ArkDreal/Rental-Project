using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Senai.Rental.WebApi.Domains
{
    public class AluguelDomain 
    {
        public int idAluguel { get; set; }

        public ClienteDomain Cliente { get; set; }

        public VeiculoDomain Veiculo { get; set; }

        public DateTime dataInicio{ get; set; }

        public DateTime dataFim{ get; set; }
    }
}
