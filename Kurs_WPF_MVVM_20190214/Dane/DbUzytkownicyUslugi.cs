using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Kurs_WPF_MVVM_20190214.Interfejsy;
using Kurs_WPF_MVVM_20190214.Model;
using Kurs_WPF_MVVM_20190214.ViewModel;

namespace Kurs_WPF_MVVM_20190214.Dane
{
    public class DbUzytkownicyUslugi : InterfaceUzytkownicy
    {
        private readonly Model1 context;

        public DbUzytkownicyUslugi(Model1 context)
        {
            this.context = new Model1();
            //umożliwia śledzenie zapytań do bazy danych
            context.Database.Log = Console.WriteLine;
        }

        public void Add(Uzytkownik uzytkownik)
        {
            context.Uzytkownicy.Add(uzytkownik);

            context.SaveChanges();
        }

        public ObservableCollection<Uzytkownik> Get()
        {
            return context.Uzytkownicy.ToList();
        }

        public Uzytkownik Get(int id)
        {
            var uzytkownik = context.Uzytkownicy.Single(u => u.Id == id);

            return uzytkownik;
        }

        public Uzytkownik Get(string name)
        {
            return context.Uzytkownicy.Single(u => u.Nazwisko == name);
        }

        public void Remove(int id)
        {
            var uzytkownik = Get(id);

            context.Uzytkownicy.Remove(uzytkownik);

            context.SaveChanges();
        }

        public void Update(Uzytkownik uzytkownik)
        {
            context.Entry(uzytkownik).State = System.Data.Entity.EntityState.Modified; // zmieniamy stan produktu w nowym kontekście na Modified aby context poznał przekazany element

            context.SaveChanges();
        }
    }
}
