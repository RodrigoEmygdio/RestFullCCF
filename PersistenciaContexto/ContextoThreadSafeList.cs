using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.Concurrent;
using PersistenciaContexto.Contrato;

namespace PersistenciaContexto.TreadSafeList
{
    public abstract class ContextoPE<T> where T: IIdentificavel
    {
        protected BlockingCollection<T> itens = new BlockingCollection<T>();

        public abstract T Atualiza(T item);

        public  T Inclui(T item)
        {
            var ultimoItem = itens.LastOrDefault();
            if(ultimoItem == null)
            {
                item.ID = 1;
            }
            else
            {
                item.ID = ultimoItem.ID + 1;
            }
            itens.Add(item);
            return item;
        }

        public bool Deleta(int itemId)
        {
            var item = Pesquisa(itemId);
            try
            {
                if (item == null)
                {
                    return false;
                }
                itens.TryTake(out item);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public virtual IList<T> Lista()
        {
            return itens.ToList();
        }

        public virtual T Pesquisa(int id)
        {
            return itens.Where(item => item.ID == id).FirstOrDefault();
        }

    }
}
