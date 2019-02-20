using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kurs_WPF_MVVM_20190214.Model
{
    [Table("Uzytkownicy")]
    public class Uzytkownik
    {
        public Uzytkownik(int id, string imie, string nazwisko)
        {
            //Id = id;
            Imie = "Witek";
            Nazwisko = "Majda";
        }

        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public int Id { get; set; }
        public string Imie { get; set; }
        public string Nazwisko { get; set; }
    }
}
