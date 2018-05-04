using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;
using System.ServiceModel;
using PersistenciaContexto.Contrato;


namespace Questionario.Negocio.Entidade
{
    [DataContract]
    public class Questao : IIdentificavel
    {
        [DataMember]
        public int ID { get; set; }
        [DataMember]
        public string Resposta { get; set; }
    }
}
