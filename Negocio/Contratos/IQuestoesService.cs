using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ServiceModel;
using System.ServiceModel.Web;
using Questionario.Negocio.Entidade;


namespace Questionario.Negocio.Contratos
{
    [ServiceContract]
    public interface IQuestoesService
    {
        [WebGet(UriTemplate = "Questoes", ResponseFormat=WebMessageFormat.Json)]
        [OperationContract]
        List<Questao> Questoes();
    }
}
