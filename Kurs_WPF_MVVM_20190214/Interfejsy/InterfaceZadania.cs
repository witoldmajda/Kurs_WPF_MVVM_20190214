using Kurs_WPF_MVVM_20190214.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kurs_WPF_MVVM_20190214.Interfejsy
{
    public interface InterfaceZadania
    {
        void Add(Zadanie zadanie);

        void Update(Zadanie zadanie);

        void Remove(int id);

        ObservableCollection<Zadanie> Get();

        Zadanie Get(int id);

        
    }
}
