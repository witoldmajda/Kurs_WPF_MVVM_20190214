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
    public class DbUzytkownicyUslugi : InterfaceUzytkownicy
    {
        public void Add(Uzytkownik uzytkownik)
        {
            throw new NotImplementedException();
        }

        public ObservableCollection<Uzytkownik> Get()
        {
            throw new NotImplementedException();
        }

        public Uzytkownik Get(int id)
        {
            throw new NotImplementedException();
        }

        public Uzytkownik Get(string name)
        {
            throw new NotImplementedException();
        }

        public void Remove(int id)
        {
            throw new NotImplementedException();
        }

        public void Update(Uzytkownik uzytkownik)
        {
            throw new NotImplementedException();
        }
    }
}
