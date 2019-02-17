using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Kurs_WPF_MVVM_20190214.Interfejsy;
using Kurs_WPF_MVVM_20190214.Model;

namespace Kurs_WPF_MVVM_20190214.Dane
{
    public class DbZadaniaUslugi : InterfaceZadania
    {
        public void Add(Zadanie zadanie)
        {
            throw new NotImplementedException();
        }

        public ObservableCollection<Zadanie> Get()
        {
            throw new NotImplementedException();
        }

        public Zadanie Get(int id)
        {
            throw new NotImplementedException();
        }

        public void Remove(int id)
        {
            throw new NotImplementedException();
        }

        public void Update(Zadanie zadanie)
        {
            throw new NotImplementedException();
        }
    }
}
