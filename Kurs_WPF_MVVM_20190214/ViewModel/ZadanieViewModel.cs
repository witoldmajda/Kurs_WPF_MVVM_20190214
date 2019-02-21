using Kurs_WPF_MVVM_20190214.Dane;
using Kurs_WPF_MVVM_20190214.Interfejsy;
using Kurs_WPF_MVVM_20190214.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Kurs_WPF_MVVM_20190214.ViewModel
{
    public class ZadanieViewModel : BaseViewModel
    {

        private ICollection<Zadanie> _listaZadan;

        public ICollection<Zadanie> ListaZadan
        {
            get { return _listaZadan; }
            set
            {
                _listaZadan = value;
                OnPropertyChanged();
            }
        }


        //private void Load()
        //{
        //    ListaZadan = dbZadaniaUslugi.Get();
        //}

        private Model.Zadanie model;

        //public ZadanieViewModel()
        //    :this(new DbZadaniaUslugi())
        //{
        //    Load();
        //}

        public ZadanieViewModel(string opis, DateTime dataUtworzenia, DateTime planowanyTerminRealizacji, Model.Zadanie.PriorytetZadania priorytetZadania, bool czyZrealizowane)
        {
            model = new Model.Zadanie(opis, dataUtworzenia, planowanyTerminRealizacji, priorytetZadania, czyZrealizowane);
        }

        public ZadanieViewModel(Model.Zadanie zadanie)
        {
            this.model = zadanie;
        }

        //public ZadanieViewModel(InterfaceZadania dbZadaniaUslugi)
        //{
        //    this.dbZadaniaUslugi = dbZadaniaUslugi;
        //}

        public string Opis
        {
            get { return model.Opis; }
        }

        public Model.Zadanie.PriorytetZadania Priorytet
        {
            get
            {
                return model.Priorytet;
            }
        }

        public DateTime DataUtworzenia
        {
            get
            {
                return model.DataUtworzenia;
            }
        }

        public DateTime PlanowanyTerminRealizacji
        {
            get
            {
                return model.PlanowanyTerminRealizacji;
            }
        }

        public bool CzyZrealizowane
        {
            get
            {
                return model.CzyZrealizowane;
            }
        }

        public bool CzyZadaniePozostajeNieZrealizowanePoZadanymTerminie
        {
            get
            {
                return !CzyZrealizowane && DateTime.Now > PlanowanyTerminRealizacji;
            }
        }

        public Model.Zadanie GetModel()
        {
            return model;
        }

        //public event PropertyChangedEventHandler PropertyChanged;

        //private void OnPropertyChanged(params string[] nazwyWlasnosci)
        //{
        //    if (PropertyChanged != null)
        //    {
        //        foreach (string nazwaWlasnosci in nazwyWlasnosci)
        //            PropertyChanged(this, new PropertyChangedEventArgs(nazwaWlasnosci));
        //    }
        //}

        ICommand oznaczJakoZrealizowane;

        public ICommand OznaczJakoZrealizowane
        {
            get
            {
                if (oznaczJakoZrealizowane == null)
                    oznaczJakoZrealizowane = new RelayCommand(
                        o =>
                        {
                            model.CzyZrealizowane = true;
                            //OnPropertyChanged(nameof(CzyZrealizowane), nameof(CzyZadaniePozostajeNieZrealizowanePoZadanymTerminie));
                            OnPropertyChanged(nameof(CzyZrealizowane));
                        },
                        o =>
                        {
                            return !model.CzyZrealizowane;
                        }
                        );
                return oznaczJakoZrealizowane;
            }
        }

        ICommand oznaczJakoNierealizowane = null;
        //private readonly InterfaceZadania dbZadaniaUslugi;

        public ICommand OznaczJakoNiezrealizowane
        {
            get
            {
                if (oznaczJakoNierealizowane == null)
                    oznaczJakoNierealizowane = new RelayCommand(
                        o =>
                        {
                            model.CzyZrealizowane = false;
                            //OnPropertyChanged(nameof(CzyZrealizowane), nameof(CzyZadaniePozostajeNieZrealizowanePoZadanymTerminie));
                            OnPropertyChanged(nameof(CzyZrealizowane));
                        },
                        o =>
                        {
                            return model.CzyZrealizowane;
                        }
                        );
                return oznaczJakoNierealizowane;
            }
        }
    }
}
