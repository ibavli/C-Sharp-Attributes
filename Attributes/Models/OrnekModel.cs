using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Attributes.Models
{
    /*
    Attribute Nedir ?
        Programın çalışma zamanı esnasında, üyelerin(metodlar, sınıflar vb.) davranışlarını değiştirebileceğimiz sınıflar diyebiliriz. Attribute sınıflarını aslında bir öğelere bir metadata olarak düşünebiliriz. Yani öğelere attribute tanımlıyoruz ve öğeler hakkındaki yardımcı bilgilere sahip olabiliyoruz ve bunlara göre programımızın akışını değiştirebiliyoruz. Ama burada not etmeniz gereken önemli birşey var; Attribute’lar öğelerin işleyişini değiştirmez, siz attribute’ları kullanarak programınızın akışını değiştirirsiniz. K
     */
    public class Kisi
    {
        public int Id { get; set; }

        [Required]//Zorunluluk Kontrolü
        [DisplayName("İsim bilgisi")]//Başlık tanımlaması
        public string Ad { get; set; }

        [DisplayName("Soyisim bilgisi")]//Başlık tanımlaması
        public string Soyad { get; set; }

        [DisplayName("TC kimlik bilgisi")]//Başlık tanımlaması
        [Editable(false)]//Düzenlenemez olarak işaretledik
        public string TCKimlikNo { get; set; }

        //Min ile Max değer arası
        [Range(0, 18, ErrorMessage = "Değer 0 ile 18 arasında olabilir !")]
        public int Yas { get; set; }


        //DisplayFormat : Modeldeki değerin View'da hangi formatta görüntüleneceğini DisplayFormat ile belirliyoruz.
        //DisplayFormat Attribute'unun bazı parametreleri;
        //DataFormatString : Değerin hangi formatta görüntüleneceğini belirtir.
        //ApplyFormatInEditMode : Modelin Edit View'ında da aynı formatın geçerli olup olmamasını tanımlar.
        //ConvertEmptyStringToNull : Boş string ifadesinin null olarak alınıp alınmaması tanımlar.
        //NullDisplayText : Değer null ise sayfada ne görüneceğini bilgisini tanımlar.
        [DisplayFormat(DataFormatString = "{0:dd.MM.yyyy}")]
        public DateTime DogumTarihi { get; set; }


        [DataType(DataType.Password)]
        public string Parola { get; set; }

        [EmailAddress()]
        public string EPosta { get; set; }


        //Sadece 8 karakter uzunluğunda olacağını kabul edelim
        [MinLength(8, ErrorMessage = "8 Karakter uzunluğunda olmalıdır !")]
        [MaxLength(8)]
        public string UyeNumarasi { get; set; }


        //Compare : Değerleri Karşılaştırma
        [DisplayName("Şifreniz")]
        [DataType(DataType.Password)]
        public string Sifre { get; set; }

        [DisplayName("Şifreniz (Tekrar)")]
        [DataType(DataType.Password)]
        [Compare("Sifre", ErrorMessage = "Şifre ve Şifre Tekrar alanları aynı olmalı !")]
        public string SifreTekrar { get; set; }


        [RegularExpression(@"^(0 (\d{3}) (\d{3}) (\d{2}) (\d{2}))$", ErrorMessage = "0 500 500 50 50 formatında olmalı")]
        public string TelefonNumarasi { get; set; }
    }
}