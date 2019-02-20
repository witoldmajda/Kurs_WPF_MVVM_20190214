using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Kurs_WPF_MVVM_20190214.Model;

namespace Kurs_WPF_MVVM_20190214.Interfejsy
{
    public interface InterfaceUzytkownicy
    {
        void Add(Uzytkownik uzytkownik);

        void Update(Uzytkownik uzytkownik);

        void Remove(int id);

        ICollection<Uzytkownik> Get();

        Uzytkownik Get(int id);

        Uzytkownik Get(string name);


    }
}
