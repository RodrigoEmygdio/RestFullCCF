using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Questionario.Negocio.Entidade;
using Questionario.Negocio.Persistencia;

namespace Questionario.Negocio.Delegacao
{
    public class BDQuestao
    {
        public Persistencia.Questao.QuestaoInstancia QuestaoPe = Persistencia.Questao.InstanciaQuestao();
    }
}
