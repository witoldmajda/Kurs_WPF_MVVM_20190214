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
    public class DbZadaniaUslugi : InterfaceZadania
    {
        private readonly Model1 context;

        public DbZadaniaUslugi()
        {
            this.context = new Model1();
            context.Database.Log = Console.WriteLine;
        }

        public void Add(Zadanie zadanie)
        {
            context.Zadania.Add(zadanie);

            context.SaveChanges();
        }

        public ICollection<Zadanie> Get()
        {
            return context.Zadania.ToList();
        }

        public Zadanie Get(int id)
        {
            var zadanie = context.Zadania.Single(z => z.Id == id);

            return zadanie;
        }

        public void Remove(int id)
        {
            var zadanie = Get(id);

            context.Zadania.Remove(zadanie);

            context.SaveChanges();
        }

        public void Update(Zadanie zadanie)
        {
            context.Entry(zadanie).State = System.Data.Entity.EntityState.Modified; // zmieniamy stan produktu w nowym kontekście na Modified aby context poznał przekazany element

            context.SaveChanges();
        }
    }
}
