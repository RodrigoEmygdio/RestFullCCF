using System;
using System.Collections.Concurrent;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Questionario.Negocio.Entidade;
using PersistenciaContexto.TreadSafeList;

namespace Questionario.Negocio.Persistencia
{
    public class Questao
    {
        private static QuestaoInstancia instancia;

        private Questao() { }

        public static QuestaoInstancia InstanciaQuestao()
        {
            if(instancia == null)
            {
                instancia = new QuestaoInstancia();
                
            }
            return instancia;
        }

        public  class QuestaoInstancia: ContextoPE<Negocio.Entidade.Questao>
        {

            public QuestaoInstancia() {
                Inclui(new Negocio.Entidade.Questao() { Resposta = "A" });
                Inclui(new Negocio.Entidade.Questao() { Resposta = "B" });
            }

            public override Entidade.Questao Atualiza(Entidade.Questao questao)
            {
                var questaoSalva = Pesquisa(questao.ID);
                if (questaoSalva == null)
                {
                    return null;
                }
                questaoSalva.Resposta = questao.Resposta;
                return questaoSalva;
            }
        }
    }
}
