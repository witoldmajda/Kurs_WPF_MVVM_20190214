using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kurs_WPF_MVVM_20190214.Model
{
    [Table("Zadania")]

    public class Zadanie
    {

        public enum PriorytetZadania : byte { MniejWazne, Wazne, Krytyczne };


        public Zadanie(string opis, DateTime dataUtworzenia, DateTime planowanyTerminRealizacji, PriorytetZadania priorytet, bool czyZrealizowane)
        {
            Opis = opis;
            DataUtworzenia = dataUtworzenia;
            PlanowanyTerminRealizacji = planowanyTerminRealizacji;
            Priorytet = priorytet;
            CzyZrealizowane = czyZrealizowane;
            Uzytkownik = new Uzytkownik { Imie = "Jan", Nazwisko = "Nazwisko" };
        }

        public Zadanie ()
        {

        }

        
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public int Id { get; set; }
        public string Opis { get; private set; }
        public DateTime DataUtworzenia { get; private set; }
        public DateTime PlanowanyTerminRealizacji { get; private set; }
        public PriorytetZadania Priorytet { get; private set; }
        public bool CzyZrealizowane { get; set; }
        public Uzytkownik Uzytkownik { get; set; }

        public override string ToString()
        {
            return Opis + ", priorytet: " + OpisPriorytetu(Priorytet) + ", data utworzenia: " + DataUtworzenia + ", planowany termin realizacji: " + PlanowanyTerminRealizacji.ToString() + ", " + (CzyZrealizowane ? "zrealizowane" : "niezrealizowane");
        }

        public static string OpisPriorytetu(PriorytetZadania priorytet)
        {
            switch (priorytet)
            {
                case PriorytetZadania.MniejWazne:
                    return "mniej wazne";
                case PriorytetZadania.Wazne:
                    return "wazne";
                case PriorytetZadania.Krytyczne:
                    return "krytyczne";
                default:
                    throw new Exception("Nierozpoznany priorytet zadania");
            }
        }

        public static PriorytetZadania ParsujOpisPriorytetu(string opisPriorytetu)
        {
            switch (opisPriorytetu)
            {
                case "mniej wazne":
                    return PriorytetZadania.MniejWazne;
                case "wazne":
                    return PriorytetZadania.Wazne;
                case "krytyczne":
                    return PriorytetZadania.Krytyczne;
                default:
                    throw new Exception("Nierozpoznany opis priorytetu");
            }
        }
    }
}
