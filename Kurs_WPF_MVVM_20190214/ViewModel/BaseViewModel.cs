﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Kurs_WPF_MVVM_20190214.ViewModel
{
    public abstract class BaseViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged([CallerMemberName]string propName = "") //pobiera atrybut kto mnie wywołał, nie trzeba podawać nazwy kontrolki która wywołała
        {
            if (PropertyChanged != null) //sprawdzamy czy jakiś obiekt słucha
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propName)); //informujemy metodę która nasłuchuje
            }
        }
    }
}
