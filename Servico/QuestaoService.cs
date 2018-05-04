using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.ServiceModel.Activation;
using System.Text;
using Questionario.Negocio.Contratos;
using Questionario.Negocio.Entidade;
using Questionario.Negocio.Delegacao;

namespace Servico
{
    [AspNetCompatibilityRequirements(RequirementsMode=AspNetCompatibilityRequirementsMode.Allowed)]
    [ServiceBehavior(InstanceContextMode = InstanceContextMode.Single)]
    public class QuestoesService : IQuestoesService
    {
        
        private BDQuestao bDQuestao = new BDQuestao();

        public Questao Atualiza(Questao questao)
        {
            if(bDQuestao.QuestaoPe.Pesquisa(questao.ID) == null)
            {
                WebOperationContext.Current.OutgoingResponse.SetStatusAsNotFound();
                return null;
            }
            return bDQuestao.QuestaoPe.Atualiza(questao);


        }

        public Questao Questao(string questaoId)
        {
            return  bDQuestao.QuestaoPe.Pesquisa(int.Parse(questaoId));
        }

        public List<Questao> Questoes()
        {
            return bDQuestao.QuestaoPe.Lista().ToList<Questao>();
        }
    }
}
