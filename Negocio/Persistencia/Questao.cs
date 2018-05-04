using System;
using System.Collections.Concurrent;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Questionario.Negocio.Entidade;

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

        public  class QuestaoInstancia
        {
            private BlockingCollection<Negocio.Entidade.Questao> Questoes = new BlockingCollection<Negocio.Entidade.Questao>() {

                new Negocio.Entidade.Questao()
                {
                    ID = 1,
                    Resposta="A"
                },
                 new Negocio.Entidade.Questao()
                {
                    ID = 2,
                    Resposta="B"
                }
            };

            public QuestaoInstancia() { }

            public BlockingCollection<Negocio.Entidade.Questao> Lista()
            {
                return Questoes;
            }

            public void Salva(Negocio.Entidade.Questao questao)
            {
                Questoes.Add(questao);
            }

            public bool Deleta(int questaoId)
            {
                var questao = Pesquisa(questaoId);
                try
                {
                    if(questao == null)
                    {
                        return false;
                    }
                    Questoes.TryTake(out questao);
                    return true;
                }
                catch (Exception)
                {
                    return false;
                }
            }

            public Negocio.Entidade.Questao Atualiza(Negocio.Entidade.Questao questao)
            {
                var questaoSalva = Pesquisa(questao.ID);
                if(questaoSalva == null)
                {
                    return null;
                }
                questaoSalva.Resposta = questao.Resposta;
                return questaoSalva;
            }

            public Entidade.Questao Pesquisa(int questaoId)
            {
                return Questoes.Where(questaoSalva => questaoSalva.ID == questaoId).FirstOrDefault();
            }
        }
    }
}
