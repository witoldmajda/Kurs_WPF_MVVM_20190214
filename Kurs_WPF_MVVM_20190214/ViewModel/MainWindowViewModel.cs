using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Kurs_WPF_MVVM_20190214.Model;

namespace Kurs_WPF_MVVM_20190214.ViewModel
{
    public class MainWindowViewModel
    {
        //przechowywanie dwóch kolekcji
        //private Model.Zadania model;

        public ObservableCollection<ZadanieViewModel> ListaZadan { get; } = new ObservableCollection<ZadanieViewModel>();

        

        private ICommand dodajZadanie;
        //public  ZadanieViewModel zadanie2;
        //zadanie2 = new ZadanieViewModel { Opis = "Picie", DataUtworzenia = DateTime.Now, PlanowanyTerminRealizacji = DateTime.Now.AddDays(3), Priorytet = Model.Zadanie.PriorytetZadania.Krytyczne, CzyZrealizowane = false };

    public MainWindowViewModel()
        {
            ListaZadan.CollectionChanged += ListaZadan_CollectionChanged;           
            
        }

        private void ListaZadan_CollectionChanged(object sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
        {
            switch (e.Action)
            {
                case NotifyCollectionChangedAction.Add:
                    ZadanieViewModel noweZadanie = (ZadanieViewModel)e.NewItems[0];
                    if (noweZadanie != null)
                    {
                        using (var database = new Model1())
                        {
                            database.Zadania.Add(noweZadanie.GetModel());
                            database.SaveChanges();
                        }
                    }                        
                            //model.DodajZadanie(noweZadanie.GetModel());
                            break;
                case NotifyCollectionChangedAction.Remove:
                    ZadanieViewModel usuwaneZadanie = (ZadanieViewModel)e.OldItems[0];
                    if (usuwaneZadanie != null)
                    {
                        using (var database = new Model1())
                        {
                            database.Zadania.Remove(usuwaneZadanie.GetModel());
                            database.SaveChanges();
                        }
                    }
                        //model.UsunZadanie(usuwaneZadanie.GetModel());
                    break;
            }
        }

        public ICommand DodajZadanie
        {
            get
            {
                if (dodajZadanie == null)
                {
                    dodajZadanie = new RelayCommand(
                        o =>
                        {
                           
                            ZadanieViewModel zadanie = o as ZadanieViewModel;
                            if (zadanie != null)
                            {
                                ListaZadan.Add(zadanie);
                            }
                        },
                        o =>
                        {
                            return (o as ZadanieViewModel) != null;
                        }
                        );
                }
                return dodajZadanie;
            }

        }

        //private void SynchonizacjaModelu(object sender, NotifyCollectionChangedEventArgs e)
        //{
        //    switch (e.Action)
        //    {
        //        case NotifyCollectionChangedAction.Add:
        //            ZadanieViewModel noweZadanie = (ZadanieViewModel)e.NewItems[0];
        //            if (noweZadanie != null)
        //                model.DodajZadanie(noweZadanie.GetModel());
        //            break;
        //        case NotifyCollectionChangedAction.Remove:
        //            ZadanieViewModel usuwaneZadanie = (ZadanieViewModel)e.OldItems[0];
        //            if (usuwaneZadanie != null)
        //                model.UsunZadanie(usuwaneZadanie.GetModel());
        //            break;
        //    }
        //}
    }
}
