﻿using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Data;
using System.Windows.Media;

namespace Kurs_WPF_MVVM_20190214.View
{
    public class BoolToBrushConverter : IValueConverter
    {
        public Brush KolorDlaFalszu { get; set; } = Brushes.Black;
        public Brush KolorDlaPrawdy { get; set; } = Brushes.Gray;

        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            bool bvalue = (bool)value;
            return !bvalue ? KolorDlaFalszu : KolorDlaPrawdy;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }

    public class PriorytetZadaniaToString : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            Model.Zadanie.PriorytetZadania priorytetZadania = (Model.Zadanie.PriorytetZadania)value;
            return Model.Zadanie.OpisPriorytetu(priorytetZadania);
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            string opisPriorytetu = (value as string).ToLower();
            return Model.Zadanie.ParsujOpisPriorytetu(opisPriorytetu);
        }
    }

    public class PriorytetZadaniaToBrush : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            Model.Zadanie.PriorytetZadania priorytetZadania = (Model.Zadanie.PriorytetZadania)value;
            switch (priorytetZadania)
            {
                case Model.Zadanie.PriorytetZadania.MniejWazne:
                    return Brushes.Olive;
                case Model.Zadanie.PriorytetZadania.Wazne:
                    return Brushes.Orange;
                case Model.Zadanie.PriorytetZadania.Krytyczne:
                    return Brushes.OrangeRed;
                default:
                    throw new Exception("Nierozpoznany priorytet zadania");
            }
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }

    public class BoolToTextDecorationConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            bool bvalue = (bool)value;
            return bvalue ? TextDecorations.Strikethrough : null;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }

    public class ZadanieConverter : IMultiValueConverter
    {
        PriorytetZadaniaToString pzts = new PriorytetZadaniaToString();

        public object Convert(object[] values, Type targetType, object parameter, CultureInfo culture)
        {
            string opis = (string)values[0];
            DateTime terminUtworzenia = DateTime.Now;
            DateTime? planowanyTerminRealizacji = (DateTime?)values[1];
            Model.Zadanie.PriorytetZadania priorytet = (Model.Zadanie.PriorytetZadania)pzts.ConvertBack(values[2], typeof(Model.Zadanie.PriorytetZadania), null, CultureInfo.CurrentCulture);
            if (!string.IsNullOrWhiteSpace(opis) && planowanyTerminRealizacji.HasValue)
            {
                return new ViewModel.ZadanieViewModel(opis, terminUtworzenia, planowanyTerminRealizacji.Value, priorytet, false);
            }
            else
            {
                return null;
            }
        }

        public object[] ConvertBack(object value, Type[] targetTypes, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
