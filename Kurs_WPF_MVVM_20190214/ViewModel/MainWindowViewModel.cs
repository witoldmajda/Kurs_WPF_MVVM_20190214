using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kurs_WPF_MVVM_20190214.ViewModel
{
    public class MainWindowViewModel
    {
        public ObservableCollection<ZadanieViewModel> ListaZadan { get; } = new ObservableCollection<ZadanieViewModel>();
    }
}
