﻿using System;
using System.Collections.Generic;
using System.Text;

namespace ConsultarCEP.Servico.Modelo
{
    public class Endereco
    {
        public string Cep { get; set; }
        public string Logradouro { get; set; }
        public string Complemento { get; set; }
        public string Bairro { get; set; }
        public string Localidade { get; set; }
        public string Uf { get; set; }
        public string Uniade { get; set; }
        public string Gia { get; set; }
    }
}
