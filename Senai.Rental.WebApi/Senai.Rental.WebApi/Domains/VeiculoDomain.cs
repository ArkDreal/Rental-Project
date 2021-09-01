using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Senai.Rental.WebApi.Domains
{
    public class VeiculoDomain
    {
        public int idVeiculo { get; set; }

        public EmpresaDomain idEmpresa { get; set; }

        public ModeloDomain idModelo { get; set; }

        public string placaVeiculo { get; set; }
    }
}
