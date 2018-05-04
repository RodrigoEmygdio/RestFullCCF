using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Activation;
using System.Text;
using Questionario.Negocio.Contratos;
using Questionario.Negocio.Entidade;
using Questionario.Negocio.Delegacao;

namespace Servico
{
    [AspNetCompatibilityRequirements(RequirementsMode=AspNetCompatibilityRequirementsMode.Allowed)]
    public class QuestoesService : IQuestoesService
    {
        public List<Questao> Questoes()
        {
            return new BDQuestao().QuestaoPe.Lista();
        }
    }
}
