﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;
using System.ServiceModel;

namespace Questionario.Negocio.Entidade
{
    [DataContract]
    public class Questao
    {
        [DataMember]
        public int ID { get; set; }
        [DataMember]
        public string Resposta { get; set; }
    }
}
