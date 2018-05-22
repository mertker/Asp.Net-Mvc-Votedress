using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Votedress.Entities.VeritabaniModellerim;

namespace Votedress.DataAccessLayer.EntityFramework
{
    public class BitirmeInitializer : CreateDatabaseIfNotExists<DatabaseContext>
    {
        protected override void Seed(DatabaseContext context)
        {

            List<Color> renkler = new List<Color>();

            Color beyaz = new Color()
            {
                id = 0,
                ColorName = "Beyaz",
                ColorCode = "#ffffff"
            };

            renkler.Add(beyaz);
            context.Colors.Add(beyaz);


            Color siyah = new Color()
            {
                id = 1,
                ColorName = "Siyah",
                ColorCode = "#000000"
            };

            renkler.Add(siyah);
            context.Colors.Add(siyah);

            Color yesil = new Color()
            {
                id = 2,
                ColorName = "Yeşil",
                ColorCode = "#008000"
            };

            renkler.Add(yesil);
            context.Colors.Add(yesil);

            Color kirmizi = new Color()
            {
                id = 3,
                ColorName = "Kirmizi",
                ColorCode = "#ff0000"
            };

            renkler.Add(kirmizi);
            context.Colors.Add(kirmizi);

            Color sari = new Color()
            {
                id = 4,
                ColorName = "Sarı",
                ColorCode = "#ffff00"
            };

            renkler.Add(sari);
            context.Colors.Add(sari);

            Color mavi = new Color()
            {
                id = 5,
                ColorName = "Mavi",
                ColorCode = "#1414ef"
            };

            renkler.Add(mavi);
            context.Colors.Add(mavi);


            Color kahverengi = new Color()
            {
                id = 6,
                ColorName = "Kahverengi",
                ColorCode = "#9e2929"
            };

            renkler.Add(kahverengi);
            context.Colors.Add(kahverengi);

            Color mor = new Color()
            {
                id = 7,
                ColorName = "Mor",
                ColorCode = "#860186"
            };

            renkler.Add(mor);
            context.Colors.Add(mor);


            List<Il> iller = new List<Il>()
            {
                new Il() {Name="Adana",Ilceler= new List<Ilce>() {
                            new Ilce() { Name = "Adana Merkez" },
                            new Ilce() { Name = "Çukurova" },
                            new Ilce() { Name = "Karaisalı" },
                            new Ilce() { Name = "Sarıçam" },
                            new Ilce() { Name = "Seyhan" },
                            new Ilce() { Name = "Yüreğir " },
                            new Ilce() { Name = "Aladağ" },
                            new Ilce() { Name = "Ceyhan" },
                            new Ilce() { Name = "Feke" },
                            new Ilce() { Name = "İmamoğlu" },
                            new Ilce() { Name = "Karataş" },
                            new Ilce() { Name = "Kozan" },
                            new Ilce() {  Name = "Pozantı" },
                            }
                         },
                new Il() {Name="Adıyaman",Ilceler= new List<Ilce>() {
                            new Ilce() { Name = "Adana Merkez" },
                            new Ilce() { Name = "Çukurova" },
                            new Ilce() { Name = "Karaisalı" },
                            new Ilce() { Name = "Sarıçam" },
                            new Ilce() { Name = "Seyhan" },
                            new Ilce() { Name = "Yüreğir " },
                            new Ilce() { Name = "Aladağ" },
                            new Ilce() { Name = "Ceyhan" },
                            new Ilce() { Name = "Feke" },
                            new Ilce() { Name = "İmamoğlu" },
                            new Ilce() { Name = "Karataş" },
                            new Ilce() { Name = "Kozan" },
                            new Ilce() {  Name = "Pozantı" },
                            }
                         },
                new Il() {Name="Afyon",Ilceler= new List<Ilce>() {
                            new Ilce() { Name = "Adana Merkez" },
                            new Ilce() { Name = "Çukurova" },
                            new Ilce() { Name = "Karaisalı" },
                            new Ilce() { Name = "Sarıçam" },
                            new Ilce() { Name = "Seyhan" },
                            new Ilce() { Name = "Yüreğir " },
                            new Ilce() { Name = "Aladağ" },
                            new Ilce() { Name = "Ceyhan" },
                            new Ilce() { Name = "Feke" },
                            new Ilce() { Name = "İmamoğlu" },
                            new Ilce() { Name = "Karataş" },
                            new Ilce() { Name = "Kozan" },
                            new Ilce() {  Name = "Pozantı" },
                            }
                         },
                new Il() {Name="Ağrı",Ilceler= new List<Ilce>() {
                            new Ilce() { Name = "Adana Merkez" },
                            new Ilce() { Name = "Çukurova" },
                            new Ilce() { Name = "Karaisalı" },
                            new Ilce() { Name = "Sarıçam" },
                            new Ilce() { Name = "Seyhan" },
                            new Ilce() { Name = "Yüreğir " },
                            new Ilce() { Name = "Aladağ" },
                            new Ilce() { Name = "Ceyhan" },
                            new Ilce() { Name = "Feke" },
                            new Ilce() { Name = "İmamoğlu" },
                            new Ilce() { Name = "Karataş" },
                            new Ilce() { Name = "Kozan" },
                            new Ilce() {  Name = "Pozantı" },
                            }
                         },
                new Il() {Name="Amasya",Ilceler= new List<Ilce>() {
                            new Ilce() { Name = "Adana Merkez" },
                            new Ilce() { Name = "Çukurova" },
                            new Ilce() { Name = "Karaisalı" },
                            new Ilce() { Name = "Sarıçam" },
                            new Ilce() { Name = "Seyhan" },
                            new Ilce() { Name = "Yüreğir " },
                            new Ilce() { Name = "Aladağ" },
                            new Ilce() { Name = "Ceyhan" },
                            new Ilce() { Name = "Feke" },
                            new Ilce() { Name = "İmamoğlu" },
                            new Ilce() { Name = "Karataş" },
                            new Ilce() { Name = "Kozan" },
                            new Ilce() {  Name = "Pozantı" },
                            }
                         },
                new Il() {Name="Ankara",Ilceler= new List<Ilce>() {
                            new Ilce() { Name = "Adana Merkez" },
                            new Ilce() { Name = "Çukurova" },
                            new Ilce() { Name = "Karaisalı" },
                            new Ilce() { Name = "Sarıçam" },
                            new Ilce() { Name = "Seyhan" },
                            new Ilce() { Name = "Yüreğir " },
                            new Ilce() { Name = "Aladağ" },
                            new Ilce() { Name = "Ceyhan" },
                            new Ilce() { Name = "Feke" },
                            new Ilce() { Name = "İmamoğlu" },
                            new Ilce() { Name = "Karataş" },
                            new Ilce() { Name = "Kozan" },
                            new Ilce() {  Name = "Pozantı" },
                            }
                         },
                new Il() {Name="Antalya",Ilceler= new List<Ilce>() {
                            new Ilce() { Name = "Adana Merkez" },
                            new Ilce() { Name = "Çukurova" },
                            new Ilce() { Name = "Karaisalı" },
                            new Ilce() { Name = "Sarıçam" },
                            new Ilce() { Name = "Seyhan" },
                            new Ilce() { Name = "Yüreğir " },
                            new Ilce() { Name = "Aladağ" },
                            new Ilce() { Name = "Ceyhan" },
                            new Ilce() { Name = "Feke" },
                            new Ilce() { Name = "İmamoğlu" },
                            new Ilce() { Name = "Karataş" },
                            new Ilce() { Name = "Kozan" },
                            new Ilce() {  Name = "Pozantı" },
                            }
                         },
                new Il() {Name="Artvin",Ilceler= new List<Ilce>() {
                            new Ilce() { Name = "Adana Merkez" },
                            new Ilce() { Name = "Çukurova" },
                            new Ilce() { Name = "Karaisalı" },
                            new Ilce() { Name = "Sarıçam" },
                            new Ilce() { Name = "Seyhan" },
                            new Ilce() { Name = "Yüreğir " },
                            new Ilce() { Name = "Aladağ" },
                            new Ilce() { Name = "Ceyhan" },
                            new Ilce() { Name = "Feke" },
                            new Ilce() { Name = "İmamoğlu" },
                            new Ilce() { Name = "Karataş" },
                            new Ilce() { Name = "Kozan" },
                            new Ilce() {  Name = "Pozantı" },
                            }
                         },
                new Il() {Name="Aydın",Ilceler= new List<Ilce>() {
                            new Ilce() { Name = "Adana Merkez" },
                            new Ilce() { Name = "Çukurova" },
                            new Ilce() { Name = "Karaisalı" },
                            new Ilce() { Name = "Sarıçam" },
                            new Ilce() { Name = "Seyhan" },
                            new Ilce() { Name = "Yüreğir " },
                            new Ilce() { Name = "Aladağ" },
                            new Ilce() { Name = "Ceyhan" },
                            new Ilce() { Name = "Feke" },
                            new Ilce() { Name = "İmamoğlu" },
                            new Ilce() { Name = "Karataş" },
                            new Ilce() { Name = "Kozan" },
                            new Ilce() {  Name = "Pozantı" },
                            }
                         },
                new Il() {Name="Balıkesir",Ilceler= new List<Ilce>() {
                            new Ilce() { Name = "Adana Merkez" },
                            new Ilce() { Name = "Çukurova" },
                            new Ilce() { Name = "Karaisalı" },
                            new Ilce() { Name = "Sarıçam" },
                            new Ilce() { Name = "Seyhan" },
                            new Ilce() { Name = "Yüreğir " },
                            new Ilce() { Name = "Aladağ" },
                            new Ilce() { Name = "Ceyhan" },
                            new Ilce() { Name = "Feke" },
                            new Ilce() { Name = "İmamoğlu" },
                            new Ilce() { Name = "Karataş" },
                            new Ilce() { Name = "Kozan" },
                            new Ilce() {  Name = "Pozantı" },
                            }
                         },
                new Il() {Name="Bilecik",Ilceler= new List<Ilce>() {
                            new Ilce() { Name = "Adana Merkez" },
                            new Ilce() { Name = "Çukurova" },
                            new Ilce() { Name = "Karaisalı" },
                            new Ilce() { Name = "Sarıçam" },
                            new Ilce() { Name = "Seyhan" },
                            new Ilce() { Name = "Yüreğir " },
                            new Ilce() { Name = "Aladağ" },
                            new Ilce() { Name = "Ceyhan" },
                            new Ilce() { Name = "Feke" },
                            new Ilce() { Name = "İmamoğlu" },
                            new Ilce() { Name = "Karataş" },
                            new Ilce() { Name = "Kozan" },
                            new Ilce() {  Name = "Pozantı" },
                            }
                         },
                new Il() {Name="Bingöl",Ilceler= new List<Ilce>() {
                            new Ilce() { Name = "Adana Merkez" },
                            new Ilce() { Name = "Çukurova" },
                            new Ilce() { Name = "Karaisalı" },
                            new Ilce() { Name = "Sarıçam" },
                            new Ilce() { Name = "Seyhan" },
                            new Ilce() { Name = "Yüreğir " },
                            new Ilce() { Name = "Aladağ" },
                            new Ilce() { Name = "Ceyhan" },
                            new Ilce() { Name = "Feke" },
                            new Ilce() { Name = "İmamoğlu" },
                            new Ilce() { Name = "Karataş" },
                            new Ilce() { Name = "Kozan" },
                            new Ilce() {  Name = "Pozantı" },
                            }
                         },
                new Il() {Name="Bitlis",Ilceler= new List<Ilce>() {
                            new Ilce() { Name = "Adana Merkez" },
                            new Ilce() { Name = "Çukurova" },
                            new Ilce() { Name = "Karaisalı" },
                            new Ilce() { Name = "Sarıçam" },
                            new Ilce() { Name = "Seyhan" },
                            new Ilce() { Name = "Yüreğir " },
                            new Ilce() { Name = "Aladağ" },
                            new Ilce() { Name = "Ceyhan" },
                            new Ilce() { Name = "Feke" },
                            new Ilce() { Name = "İmamoğlu" },
                            new Ilce() { Name = "Karataş" },
                            new Ilce() { Name = "Kozan" },
                            new Ilce() {  Name = "Pozantı" },
                            }
                         },
                new Il() {Name="Bolu",Ilceler= new List<Ilce>() {
                            new Ilce() { Name = "Adana Merkez" },
                            new Ilce() { Name = "Çukurova" },
                            new Ilce() { Name = "Karaisalı" },
                            new Ilce() { Name = "Sarıçam" },
                            new Ilce() { Name = "Seyhan" },
                            new Ilce() { Name = "Yüreğir " },
                            new Ilce() { Name = "Aladağ" },
                            new Ilce() { Name = "Ceyhan" },
                            new Ilce() { Name = "Feke" },
                            new Ilce() { Name = "İmamoğlu" },
                            new Ilce() { Name = "Karataş" },
                            new Ilce() { Name = "Kozan" },
                            new Ilce() {  Name = "Pozantı" },
                            }
                         },
                new Il() {Name="Burdur",Ilceler= new List<Ilce>() {
                            new Ilce() { Name = "Adana Merkez" },
                            new Ilce() { Name = "Çukurova" },
                            new Ilce() { Name = "Karaisalı" },
                            new Ilce() { Name = "Sarıçam" },
                            new Ilce() { Name = "Seyhan" },
                            new Ilce() { Name = "Yüreğir " },
                            new Ilce() { Name = "Aladağ" },
                            new Ilce() { Name = "Ceyhan" },
                            new Ilce() { Name = "Feke" },
                            new Ilce() { Name = "İmamoğlu" },
                            new Ilce() { Name = "Karataş" },
                            new Ilce() { Name = "Kozan" },
                            new Ilce() {  Name = "Pozantı" },
                            }
                         },
                new Il() {Name="Bursa",Ilceler= new List<Ilce>() {
                            new Ilce() { Name = "Adana Merkez" },
                            new Ilce() { Name = "Çukurova" },
                            new Ilce() { Name = "Karaisalı" },
                            new Ilce() { Name = "Sarıçam" },
                            new Ilce() { Name = "Seyhan" },
                            new Ilce() { Name = "Yüreğir " },
                            new Ilce() { Name = "Aladağ" },
                            new Ilce() { Name = "Ceyhan" },
                            new Ilce() { Name = "Feke" },
                            new Ilce() { Name = "İmamoğlu" },
                            new Ilce() { Name = "Karataş" },
                            new Ilce() { Name = "Kozan" },
                            new Ilce() {  Name = "Pozantı" },
                            }
                         },
                new Il() {Name="Çanakkale",Ilceler= new List<Ilce>() {
                            new Ilce() { Name = "Adana Merkez" },
                            new Ilce() { Name = "Çukurova" },
                            new Ilce() { Name = "Karaisalı" },
                            new Ilce() { Name = "Sarıçam" },
                            new Ilce() { Name = "Seyhan" },
                            new Ilce() { Name = "Yüreğir " },
                            new Ilce() { Name = "Aladağ" },
                            new Ilce() { Name = "Ceyhan" },
                            new Ilce() { Name = "Feke" },
                            new Ilce() { Name = "İmamoğlu" },
                            new Ilce() { Name = "Karataş" },
                            new Ilce() { Name = "Kozan" },
                            new Ilce() {  Name = "Pozantı" },
                            }
                         },
                new Il() {Name="Çankırı",Ilceler= new List<Ilce>() {
                            new Ilce() { Name = "Adana Merkez" },
                            new Ilce() { Name = "Çukurova" },
                            new Ilce() { Name = "Karaisalı" },
                            new Ilce() { Name = "Sarıçam" },
                            new Ilce() { Name = "Seyhan" },
                            new Ilce() { Name = "Yüreğir " },
                            new Ilce() { Name = "Aladağ" },
                            new Ilce() { Name = "Ceyhan" },
                            new Ilce() { Name = "Feke" },
                            new Ilce() { Name = "İmamoğlu" },
                            new Ilce() { Name = "Karataş" },
                            new Ilce() { Name = "Kozan" },
                            new Ilce() {  Name = "Pozantı" },
                            }
                         },
                new Il() {Name="Çorum",Ilceler= new List<Ilce>() {
                            new Ilce() { Name = "Adana Merkez" },
                            new Ilce() { Name = "Çukurova" },
                            new Ilce() { Name = "Karaisalı" },
                            new Ilce() { Name = "Sarıçam" },
                            new Ilce() { Name = "Seyhan" },
                            new Ilce() { Name = "Yüreğir " },
                            new Ilce() { Name = "Aladağ" },
                            new Ilce() { Name = "Ceyhan" },
                            new Ilce() { Name = "Feke" },
                            new Ilce() { Name = "İmamoğlu" },
                            new Ilce() { Name = "Karataş" },
                            new Ilce() { Name = "Kozan" },
                            new Ilce() {  Name = "Pozantı" },
                            }
                         },
                new Il() {Name="Denizli",Ilceler= new List<Ilce>() {
                            new Ilce() { Name = "Adana Merkez" },
                            new Ilce() { Name = "Çukurova" },
                            new Ilce() { Name = "Karaisalı" },
                            new Ilce() { Name = "Sarıçam" },
                            new Ilce() { Name = "Seyhan" },
                            new Ilce() { Name = "Yüreğir " },
                            new Ilce() { Name = "Aladağ" },
                            new Ilce() { Name = "Ceyhan" },
                            new Ilce() { Name = "Feke" },
                            new Ilce() { Name = "İmamoğlu" },
                            new Ilce() { Name = "Karataş" },
                            new Ilce() { Name = "Kozan" },
                            new Ilce() {  Name = "Pozantı" },
                            }
                         },
                new Il() {Name="Diyarbakır",Ilceler= new List<Ilce>() {
                            new Ilce() { Name = "Adana Merkez" },
                            new Ilce() { Name = "Çukurova" },
                            new Ilce() { Name = "Karaisalı" },
                            new Ilce() { Name = "Sarıçam" },
                            new Ilce() { Name = "Seyhan" },
                            new Ilce() { Name = "Yüreğir " },
                            new Ilce() { Name = "Aladağ" },
                            new Ilce() { Name = "Ceyhan" },
                            new Ilce() { Name = "Feke" },
                            new Ilce() { Name = "İmamoğlu" },
                            new Ilce() { Name = "Karataş" },
                            new Ilce() { Name = "Kozan" },
                            new Ilce() {  Name = "Pozantı" },
                            }
                         },
                new Il() {Name="Edirne",Ilceler= new List<Ilce>() {
                            new Ilce() { Name = "Adana Merkez" },
                            new Ilce() { Name = "Çukurova" },
                            new Ilce() { Name = "Karaisalı" },
                            new Ilce() { Name = "Sarıçam" },
                            new Ilce() { Name = "Seyhan" },
                            new Ilce() { Name = "Yüreğir " },
                            new Ilce() { Name = "Aladağ" },
                            new Ilce() { Name = "Ceyhan" },
                            new Ilce() { Name = "Feke" },
                            new Ilce() { Name = "İmamoğlu" },
                            new Ilce() { Name = "Karataş" },
                            new Ilce() { Name = "Kozan" },
                            new Ilce() {  Name = "Pozantı" },
                            }
                         },
                new Il() {Name="Elazığ",Ilceler= new List<Ilce>() {
                            new Ilce() { Name = "Adana Merkez" },
                            new Ilce() { Name = "Çukurova" },
                            new Ilce() { Name = "Karaisalı" },
                            new Ilce() { Name = "Sarıçam" },
                            new Ilce() { Name = "Seyhan" },
                            new Ilce() { Name = "Yüreğir " },
                            new Ilce() { Name = "Aladağ" },
                            new Ilce() { Name = "Ceyhan" },
                            new Ilce() { Name = "Feke" },
                            new Ilce() { Name = "İmamoğlu" },
                            new Ilce() { Name = "Karataş" },
                            new Ilce() { Name = "Kozan" },
                            new Ilce() {  Name = "Pozantı" },
                            }
                         },
                new Il() {Name="Erzincan",Ilceler= new List<Ilce>() {
                            new Ilce() { Name = "Adana Merkez" },
                            new Ilce() { Name = "Çukurova" },
                            new Ilce() { Name = "Karaisalı" },
                            new Ilce() { Name = "Sarıçam" },
                            new Ilce() { Name = "Seyhan" },
                            new Ilce() { Name = "Yüreğir " },
                            new Ilce() { Name = "Aladağ" },
                            new Ilce() { Name = "Ceyhan" },
                            new Ilce() { Name = "Feke" },
                            new Ilce() { Name = "İmamoğlu" },
                            new Ilce() { Name = "Karataş" },
                            new Ilce() { Name = "Kozan" },
                            new Ilce() {  Name = "Pozantı" },
                            }
                         },
                new Il() {Name="Erzurum",Ilceler= new List<Ilce>() {
                            new Ilce() { Name = "Adana Merkez" },
                            new Ilce() { Name = "Çukurova" },
                            new Ilce() { Name = "Karaisalı" },
                            new Ilce() { Name = "Sarıçam" },
                            new Ilce() { Name = "Seyhan" },
                            new Ilce() { Name = "Yüreğir " },
                            new Ilce() { Name = "Aladağ" },
                            new Ilce() { Name = "Ceyhan" },
                            new Ilce() { Name = "Feke" },
                            new Ilce() { Name = "İmamoğlu" },
                            new Ilce() { Name = "Karataş" },
                            new Ilce() { Name = "Kozan" },
                            new Ilce() {  Name = "Pozantı" },
                            }
                         },
                new Il() {Name="Eskişehir",Ilceler= new List<Ilce>() {
                            new Ilce() { Name = "Adana Merkez" },
                            new Ilce() { Name = "Çukurova" },
                            new Ilce() { Name = "Karaisalı" },
                            new Ilce() { Name = "Sarıçam" },
                            new Ilce() { Name = "Seyhan" },
                            new Ilce() { Name = "Yüreğir " },
                            new Ilce() { Name = "Aladağ" },
                            new Ilce() { Name = "Ceyhan" },
                            new Ilce() { Name = "Feke" },
                            new Ilce() { Name = "İmamoğlu" },
                            new Ilce() { Name = "Karataş" },
                            new Ilce() { Name = "Kozan" },
                            new Ilce() {  Name = "Pozantı" },
                            }
                         },
                new Il() {Name="Gaziantep",Ilceler= new List<Ilce>() {
                            new Ilce() { Name = "Adana Merkez" },
                            new Ilce() { Name = "Çukurova" },
                            new Ilce() { Name = "Karaisalı" },
                            new Ilce() { Name = "Sarıçam" },
                            new Ilce() { Name = "Seyhan" },
                            new Ilce() { Name = "Yüreğir " },
                            new Ilce() { Name = "Aladağ" },
                            new Ilce() { Name = "Ceyhan" },
                            new Ilce() { Name = "Feke" },
                            new Ilce() { Name = "İmamoğlu" },
                            new Ilce() { Name = "Karataş" },
                            new Ilce() { Name = "Kozan" },
                            new Ilce() {  Name = "Pozantı" },
                            }
                         },
                new Il() {Name="Giresun",Ilceler= new List<Ilce>() {
                            new Ilce() { Name = "Adana Merkez" },
                            new Ilce() { Name = "Çukurova" },
                            new Ilce() { Name = "Karaisalı" },
                            new Ilce() { Name = "Sarıçam" },
                            new Ilce() { Name = "Seyhan" },
                            new Ilce() { Name = "Yüreğir " },
                            new Ilce() { Name = "Aladağ" },
                            new Ilce() { Name = "Ceyhan" },
                            new Ilce() { Name = "Feke" },
                            new Ilce() { Name = "İmamoğlu" },
                            new Ilce() { Name = "Karataş" },
                            new Ilce() { Name = "Kozan" },
                            new Ilce() {  Name = "Pozantı" },
                            }
                         },
                new Il() {Name="Gümüşhane",Ilceler= new List<Ilce>() {
                            new Ilce() { Name = "Adana Merkez" },
                            new Ilce() { Name = "Çukurova" },
                            new Ilce() { Name = "Karaisalı" },
                            new Ilce() { Name = "Sarıçam" },
                            new Ilce() { Name = "Seyhan" },
                            new Ilce() { Name = "Yüreğir " },
                            new Ilce() { Name = "Aladağ" },
                            new Ilce() { Name = "Ceyhan" },
                            new Ilce() { Name = "Feke" },
                            new Ilce() { Name = "İmamoğlu" },
                            new Ilce() { Name = "Karataş" },
                            new Ilce() { Name = "Kozan" },
                            new Ilce() {  Name = "Pozantı" },
                            }
                         },
                new Il() {Name="Hakkari",Ilceler= new List<Ilce>() {
                            new Ilce() { Name = "Adana Merkez" },
                            new Ilce() { Name = "Çukurova" },
                            new Ilce() { Name = "Karaisalı" },
                            new Ilce() { Name = "Sarıçam" },
                            new Ilce() { Name = "Seyhan" },
                            new Ilce() { Name = "Yüreğir " },
                            new Ilce() { Name = "Aladağ" },
                            new Ilce() { Name = "Ceyhan" },
                            new Ilce() { Name = "Feke" },
                            new Ilce() { Name = "İmamoğlu" },
                            new Ilce() { Name = "Karataş" },
                            new Ilce() { Name = "Kozan" },
                            new Ilce() {  Name = "Pozantı" },
                            }
                         },
                new Il() {Name="Hatay",Ilceler= new List<Ilce>() {
                            new Ilce() { Name = "Adana Merkez" },
                            new Ilce() { Name = "Çukurova" },
                            new Ilce() { Name = "Karaisalı" },
                            new Ilce() { Name = "Sarıçam" },
                            new Ilce() { Name = "Seyhan" },
                            new Ilce() { Name = "Yüreğir " },
                            new Ilce() { Name = "Aladağ" },
                            new Ilce() { Name = "Ceyhan" },
                            new Ilce() { Name = "Feke" },
                            new Ilce() { Name = "İmamoğlu" },
                            new Ilce() { Name = "Karataş" },
                            new Ilce() { Name = "Kozan" },
                            new Ilce() {  Name = "Pozantı" },
                            }
                         },
                new Il() {Name="Isparta",Ilceler= new List<Ilce>() {
                            new Ilce() { Name = "Adana Merkez" },
                            new Ilce() { Name = "Çukurova" },
                            new Ilce() { Name = "Karaisalı" },
                            new Ilce() { Name = "Sarıçam" },
                            new Ilce() { Name = "Seyhan" },
                            new Ilce() { Name = "Yüreğir " },
                            new Ilce() { Name = "Aladağ" },
                            new Ilce() { Name = "Ceyhan" },
                            new Ilce() { Name = "Feke" },
                            new Ilce() { Name = "İmamoğlu" },
                            new Ilce() { Name = "Karataş" },
                            new Ilce() { Name = "Kozan" },
                            new Ilce() {  Name = "Pozantı" },
                            }
                         },
                new Il() {Name="Mersin",Ilceler= new List<Ilce>() {
                            new Ilce() { Name = "Adana Merkez" },
                            new Ilce() { Name = "Çukurova" },
                            new Ilce() { Name = "Karaisalı" },
                            new Ilce() { Name = "Sarıçam" },
                            new Ilce() { Name = "Seyhan" },
                            new Ilce() { Name = "Yüreğir " },
                            new Ilce() { Name = "Aladağ" },
                            new Ilce() { Name = "Ceyhan" },
                            new Ilce() { Name = "Feke" },
                            new Ilce() { Name = "İmamoğlu" },
                            new Ilce() { Name = "Karataş" },
                            new Ilce() { Name = "Kozan" },
                            new Ilce() {  Name = "Pozantı" },
                            }
                         },
                new Il() {Name="İstanbul",Ilceler= new List<Ilce>() {
                            new Ilce() { Name = "Adana Merkez" },
                            new Ilce() { Name = "Çukurova" },
                            new Ilce() { Name = "Karaisalı" },
                            new Ilce() { Name = "Sarıçam" },
                            new Ilce() { Name = "Seyhan" },
                            new Ilce() { Name = "Yüreğir " },
                            new Ilce() { Name = "Aladağ" },
                            new Ilce() { Name = "Ceyhan" },
                            new Ilce() { Name = "Feke" },
                            new Ilce() { Name = "İmamoğlu" },
                            new Ilce() { Name = "Karataş" },
                            new Ilce() { Name = "Kozan" },
                            new Ilce() {  Name = "Pozantı" },
                            }
                         },
                new Il() {Name="İzmir",Ilceler= new List<Ilce>() {
                            new Ilce() { Name = "Adana Merkez" },
                            new Ilce() { Name = "Çukurova" },
                            new Ilce() { Name = "Karaisalı" },
                            new Ilce() { Name = "Sarıçam" },
                            new Ilce() { Name = "Seyhan" },
                            new Ilce() { Name = "Yüreğir " },
                            new Ilce() { Name = "Aladağ" },
                            new Ilce() { Name = "Ceyhan" },
                            new Ilce() { Name = "Feke" },
                            new Ilce() { Name = "İmamoğlu" },
                            new Ilce() { Name = "Karataş" },
                            new Ilce() { Name = "Kozan" },
                            new Ilce() {  Name = "Pozantı" },
                            }
                         },
                new Il() {Name="Kars",Ilceler= new List<Ilce>() {
                            new Ilce() { Name = "Adana Merkez" },
                            new Ilce() { Name = "Çukurova" },
                            new Ilce() { Name = "Karaisalı" },
                            new Ilce() { Name = "Sarıçam" },
                            new Ilce() { Name = "Seyhan" },
                            new Ilce() { Name = "Yüreğir " },
                            new Ilce() { Name = "Aladağ" },
                            new Ilce() { Name = "Ceyhan" },
                            new Ilce() { Name = "Feke" },
                            new Ilce() { Name = "İmamoğlu" },
                            new Ilce() { Name = "Karataş" },
                            new Ilce() { Name = "Kozan" },
                            new Ilce() {  Name = "Pozantı" },
                            }
                         },
                new Il() {Name="Kastamonu",Ilceler= new List<Ilce>() {
                            new Ilce() { Name = "Adana Merkez" },
                            new Ilce() { Name = "Çukurova" },
                            new Ilce() { Name = "Karaisalı" },
                            new Ilce() { Name = "Sarıçam" },
                            new Ilce() { Name = "Seyhan" },
                            new Ilce() { Name = "Yüreğir " },
                            new Ilce() { Name = "Aladağ" },
                            new Ilce() { Name = "Ceyhan" },
                            new Ilce() { Name = "Feke" },
                            new Ilce() { Name = "İmamoğlu" },
                            new Ilce() { Name = "Karataş" },
                            new Ilce() { Name = "Kozan" },
                            new Ilce() {  Name = "Pozantı" },
                            }
                         },
                new Il() {Name="Kayseri",Ilceler= new List<Ilce>() {
                            new Ilce() { Name = "Adana Merkez" },
                            new Ilce() { Name = "Çukurova" },
                            new Ilce() { Name = "Karaisalı" },
                            new Ilce() { Name = "Sarıçam" },
                            new Ilce() { Name = "Seyhan" },
                            new Ilce() { Name = "Yüreğir " },
                            new Ilce() { Name = "Aladağ" },
                            new Ilce() { Name = "Ceyhan" },
                            new Ilce() { Name = "Feke" },
                            new Ilce() { Name = "İmamoğlu" },
                            new Ilce() { Name = "Karataş" },
                            new Ilce() { Name = "Kozan" },
                            new Ilce() {  Name = "Pozantı" },
                            }
                         },
                new Il() {Name="Kırklareli",Ilceler= new List<Ilce>() {
                            new Ilce() { Name = "Adana Merkez" },
                            new Ilce() { Name = "Çukurova" },
                            new Ilce() { Name = "Karaisalı" },
                            new Ilce() { Name = "Sarıçam" },
                            new Ilce() { Name = "Seyhan" },
                            new Ilce() { Name = "Yüreğir " },
                            new Ilce() { Name = "Aladağ" },
                            new Ilce() { Name = "Ceyhan" },
                            new Ilce() { Name = "Feke" },
                            new Ilce() { Name = "İmamoğlu" },
                            new Ilce() { Name = "Karataş" },
                            new Ilce() { Name = "Kozan" },
                            new Ilce() {  Name = "Pozantı" },
                            }
                         },
                new Il() {Name="Kırşehir",Ilceler= new List<Ilce>() {
                            new Ilce() { Name = "Adana Merkez" },
                            new Ilce() { Name = "Çukurova" },
                            new Ilce() { Name = "Karaisalı" },
                            new Ilce() { Name = "Sarıçam" },
                            new Ilce() { Name = "Seyhan" },
                            new Ilce() { Name = "Yüreğir " },
                            new Ilce() { Name = "Aladağ" },
                            new Ilce() { Name = "Ceyhan" },
                            new Ilce() { Name = "Feke" },
                            new Ilce() { Name = "İmamoğlu" },
                            new Ilce() { Name = "Karataş" },
                            new Ilce() { Name = "Kozan" },
                            new Ilce() {  Name = "Pozantı" },
                            }
                         },
                new Il() {Name="Kocaeli",Ilceler= new List<Ilce>() {
                            new Ilce() { Name = "Adana Merkez" },
                            new Ilce() { Name = "Çukurova" },
                            new Ilce() { Name = "Karaisalı" },
                            new Ilce() { Name = "Sarıçam" },
                            new Ilce() { Name = "Seyhan" },
                            new Ilce() { Name = "Yüreğir " },
                            new Ilce() { Name = "Aladağ" },
                            new Ilce() { Name = "Ceyhan" },
                            new Ilce() { Name = "Feke" },
                            new Ilce() { Name = "İmamoğlu" },
                            new Ilce() { Name = "Karataş" },
                            new Ilce() { Name = "Kozan" },
                            new Ilce() {  Name = "Pozantı" },
                            }
                         },
                new Il() {Name="Konya",Ilceler= new List<Ilce>() {
                            new Ilce() { Name = "Adana Merkez" },
                            new Ilce() { Name = "Çukurova" },
                            new Ilce() { Name = "Karaisalı" },
                            new Ilce() { Name = "Sarıçam" },
                            new Ilce() { Name = "Seyhan" },
                            new Ilce() { Name = "Yüreğir " },
                            new Ilce() { Name = "Aladağ" },
                            new Ilce() { Name = "Ceyhan" },
                            new Ilce() { Name = "Feke" },
                            new Ilce() { Name = "İmamoğlu" },
                            new Ilce() { Name = "Karataş" },
                            new Ilce() { Name = "Kozan" },
                            new Ilce() {  Name = "Pozantı" },
                            }
                         },
                new Il() {Name="Kütahya",Ilceler= new List<Ilce>() {
                            new Ilce() { Name = "Adana Merkez" },
                            new Ilce() { Name = "Çukurova" },
                            new Ilce() { Name = "Karaisalı" },
                            new Ilce() { Name = "Sarıçam" },
                            new Ilce() { Name = "Seyhan" },
                            new Ilce() { Name = "Yüreğir " },
                            new Ilce() { Name = "Aladağ" },
                            new Ilce() { Name = "Ceyhan" },
                            new Ilce() { Name = "Feke" },
                            new Ilce() { Name = "İmamoğlu" },
                            new Ilce() { Name = "Karataş" },
                            new Ilce() { Name = "Kozan" },
                            new Ilce() {  Name = "Pozantı" },
                            }
                         },
                new Il() {Name="Malatya",Ilceler= new List<Ilce>() {
                            new Ilce() { Name = "Adana Merkez" },
                            new Ilce() { Name = "Çukurova" },
                            new Ilce() { Name = "Karaisalı" },
                            new Ilce() { Name = "Sarıçam" },
                            new Ilce() { Name = "Seyhan" },
                            new Ilce() { Name = "Yüreğir " },
                            new Ilce() { Name = "Aladağ" },
                            new Ilce() { Name = "Ceyhan" },
                            new Ilce() { Name = "Feke" },
                            new Ilce() { Name = "İmamoğlu" },
                            new Ilce() { Name = "Karataş" },
                            new Ilce() { Name = "Kozan" },
                            new Ilce() {  Name = "Pozantı" },
                            }
                         },
                new Il() {Name="Manisa",Ilceler= new List<Ilce>() {
                            new Ilce() { Name = "Adana Merkez" },
                            new Ilce() { Name = "Çukurova" },
                            new Ilce() { Name = "Karaisalı" },
                            new Ilce() { Name = "Sarıçam" },
                            new Ilce() { Name = "Seyhan" },
                            new Ilce() { Name = "Yüreğir " },
                            new Ilce() { Name = "Aladağ" },
                            new Ilce() { Name = "Ceyhan" },
                            new Ilce() { Name = "Feke" },
                            new Ilce() { Name = "İmamoğlu" },
                            new Ilce() { Name = "Karataş" },
                            new Ilce() { Name = "Kozan" },
                            new Ilce() {  Name = "Pozantı" },
                            }
                         },
                new Il() {Name="Kahramanmaraş",Ilceler= new List<Ilce>() {
                            new Ilce() { Name = "Adana Merkez" },
                            new Ilce() { Name = "Çukurova" },
                            new Ilce() { Name = "Karaisalı" },
                            new Ilce() { Name = "Sarıçam" },
                            new Ilce() { Name = "Seyhan" },
                            new Ilce() { Name = "Yüreğir " },
                            new Ilce() { Name = "Aladağ" },
                            new Ilce() { Name = "Ceyhan" },
                            new Ilce() { Name = "Feke" },
                            new Ilce() { Name = "İmamoğlu" },
                            new Ilce() { Name = "Karataş" },
                            new Ilce() { Name = "Kozan" },
                            new Ilce() {  Name = "Pozantı" },
                            }
                         },
                new Il() {Name="Mardin",Ilceler= new List<Ilce>() {
                            new Ilce() { Name = "Adana Merkez" },
                            new Ilce() { Name = "Çukurova" },
                            new Ilce() { Name = "Karaisalı" },
                            new Ilce() { Name = "Sarıçam" },
                            new Ilce() { Name = "Seyhan" },
                            new Ilce() { Name = "Yüreğir " },
                            new Ilce() { Name = "Aladağ" },
                            new Ilce() { Name = "Ceyhan" },
                            new Ilce() { Name = "Feke" },
                            new Ilce() { Name = "İmamoğlu" },
                            new Ilce() { Name = "Karataş" },
                            new Ilce() { Name = "Kozan" },
                            new Ilce() {  Name = "Pozantı" },
                            }
                         },
                new Il() {Name="Muğla",Ilceler= new List<Ilce>() {
                            new Ilce() { Name = "Adana Merkez" },
                            new Ilce() { Name = "Çukurova" },
                            new Ilce() { Name = "Karaisalı" },
                            new Ilce() { Name = "Sarıçam" },
                            new Ilce() { Name = "Seyhan" },
                            new Ilce() { Name = "Yüreğir " },
                            new Ilce() { Name = "Aladağ" },
                            new Ilce() { Name = "Ceyhan" },
                            new Ilce() { Name = "Feke" },
                            new Ilce() { Name = "İmamoğlu" },
                            new Ilce() { Name = "Karataş" },
                            new Ilce() { Name = "Kozan" },
                            new Ilce() {  Name = "Pozantı" },
                            }
                         },
                new Il() {Name="Muş",Ilceler= new List<Ilce>() {
                            new Ilce() { Name = "Adana Merkez" },
                            new Ilce() { Name = "Çukurova" },
                            new Ilce() { Name = "Karaisalı" },
                            new Ilce() { Name = "Sarıçam" },
                            new Ilce() { Name = "Seyhan" },
                            new Ilce() { Name = "Yüreğir " },
                            new Ilce() { Name = "Aladağ" },
                            new Ilce() { Name = "Ceyhan" },
                            new Ilce() { Name = "Feke" },
                            new Ilce() { Name = "İmamoğlu" },
                            new Ilce() { Name = "Karataş" },
                            new Ilce() { Name = "Kozan" },
                            new Ilce() {  Name = "Pozantı" },
                            }
                         },
                new Il() {Name="Nevşehir",Ilceler= new List<Ilce>() {
                            new Ilce() { Name = "Adana Merkez" },
                            new Ilce() { Name = "Çukurova" },
                            new Ilce() { Name = "Karaisalı" },
                            new Ilce() { Name = "Sarıçam" },
                            new Ilce() { Name = "Seyhan" },
                            new Ilce() { Name = "Yüreğir " },
                            new Ilce() { Name = "Aladağ" },
                            new Ilce() { Name = "Ceyhan" },
                            new Ilce() { Name = "Feke" },
                            new Ilce() { Name = "İmamoğlu" },
                            new Ilce() { Name = "Karataş" },
                            new Ilce() { Name = "Kozan" },
                            new Ilce() {  Name = "Pozantı" },
                            }
                         },
                new Il() {Name="Niğde",Ilceler= new List<Ilce>() {
                            new Ilce() { Name = "Adana Merkez" },
                            new Ilce() { Name = "Çukurova" },
                            new Ilce() { Name = "Karaisalı" },
                            new Ilce() { Name = "Sarıçam" },
                            new Ilce() { Name = "Seyhan" },
                            new Ilce() { Name = "Yüreğir " },
                            new Ilce() { Name = "Aladağ" },
                            new Ilce() { Name = "Ceyhan" },
                            new Ilce() { Name = "Feke" },
                            new Ilce() { Name = "İmamoğlu" },
                            new Ilce() { Name = "Karataş" },
                            new Ilce() { Name = "Kozan" },
                            new Ilce() {  Name = "Pozantı" },
                            }
                         },
                new Il() {Name="Ordu",Ilceler= new List<Ilce>() {
                            new Ilce() { Name = "Adana Merkez" },
                            new Ilce() { Name = "Çukurova" },
                            new Ilce() { Name = "Karaisalı" },
                            new Ilce() { Name = "Sarıçam" },
                            new Ilce() { Name = "Seyhan" },
                            new Ilce() { Name = "Yüreğir " },
                            new Ilce() { Name = "Aladağ" },
                            new Ilce() { Name = "Ceyhan" },
                            new Ilce() { Name = "Feke" },
                            new Ilce() { Name = "İmamoğlu" },
                            new Ilce() { Name = "Karataş" },
                            new Ilce() { Name = "Kozan" },
                            new Ilce() {  Name = "Pozantı" },
                            }
                         },
                new Il() {Name="Rize",Ilceler= new List<Ilce>() {
                            new Ilce() { Name = "Adana Merkez" },
                            new Ilce() { Name = "Çukurova" },
                            new Ilce() { Name = "Karaisalı" },
                            new Ilce() { Name = "Sarıçam" },
                            new Ilce() { Name = "Seyhan" },
                            new Ilce() { Name = "Yüreğir " },
                            new Ilce() { Name = "Aladağ" },
                            new Ilce() { Name = "Ceyhan" },
                            new Ilce() { Name = "Feke" },
                            new Ilce() { Name = "İmamoğlu" },
                            new Ilce() { Name = "Karataş" },
                            new Ilce() { Name = "Kozan" },
                            new Ilce() {  Name = "Pozantı" },
                            }
                         },
                new Il() {Name="Sakarya",Ilceler= new List<Ilce>() {
                            new Ilce() { Name = "Adana Merkez" },
                            new Ilce() { Name = "Çukurova" },
                            new Ilce() { Name = "Karaisalı" },
                            new Ilce() { Name = "Sarıçam" },
                            new Ilce() { Name = "Seyhan" },
                            new Ilce() { Name = "Yüreğir " },
                            new Ilce() { Name = "Aladağ" },
                            new Ilce() { Name = "Ceyhan" },
                            new Ilce() { Name = "Feke" },
                            new Ilce() { Name = "İmamoğlu" },
                            new Ilce() { Name = "Karataş" },
                            new Ilce() { Name = "Kozan" },
                            new Ilce() {  Name = "Pozantı" },
                            }
                         },
                new Il() {Name="Samsun",Ilceler= new List<Ilce>() {
                            new Ilce() { Name = "Adana Merkez" },
                            new Ilce() { Name = "Çukurova" },
                            new Ilce() { Name = "Karaisalı" },
                            new Ilce() { Name = "Sarıçam" },
                            new Ilce() { Name = "Seyhan" },
                            new Ilce() { Name = "Yüreğir " },
                            new Ilce() { Name = "Aladağ" },
                            new Ilce() { Name = "Ceyhan" },
                            new Ilce() { Name = "Feke" },
                            new Ilce() { Name = "İmamoğlu" },
                            new Ilce() { Name = "Karataş" },
                            new Ilce() { Name = "Kozan" },
                            new Ilce() {  Name = "Pozantı" },
                            }
                         },
                new Il() {Name="Siirt",Ilceler= new List<Ilce>() {
                            new Ilce() { Name = "Adana Merkez" },
                            new Ilce() { Name = "Çukurova" },
                            new Ilce() { Name = "Karaisalı" },
                            new Ilce() { Name = "Sarıçam" },
                            new Ilce() { Name = "Seyhan" },
                            new Ilce() { Name = "Yüreğir " },
                            new Ilce() { Name = "Aladağ" },
                            new Ilce() { Name = "Ceyhan" },
                            new Ilce() { Name = "Feke" },
                            new Ilce() { Name = "İmamoğlu" },
                            new Ilce() { Name = "Karataş" },
                            new Ilce() { Name = "Kozan" },
                            new Ilce() {  Name = "Pozantı" },
                            }
                         },
                new Il() {Name="Sinop",Ilceler= new List<Ilce>() {
                            new Ilce() { Name = "Adana Merkez" },
                            new Ilce() { Name = "Çukurova" },
                            new Ilce() { Name = "Karaisalı" },
                            new Ilce() { Name = "Sarıçam" },
                            new Ilce() { Name = "Seyhan" },
                            new Ilce() { Name = "Yüreğir " },
                            new Ilce() { Name = "Aladağ" },
                            new Ilce() { Name = "Ceyhan" },
                            new Ilce() { Name = "Feke" },
                            new Ilce() { Name = "İmamoğlu" },
                            new Ilce() { Name = "Karataş" },
                            new Ilce() { Name = "Kozan" },
                            new Ilce() {  Name = "Pozantı" },
                            }
                         },
                new Il() {Name="Sivas",Ilceler= new List<Ilce>() {
                            new Ilce() { Name = "Adana Merkez" },
                            new Ilce() { Name = "Çukurova" },
                            new Ilce() { Name = "Karaisalı" },
                            new Ilce() { Name = "Sarıçam" },
                            new Ilce() { Name = "Seyhan" },
                            new Ilce() { Name = "Yüreğir " },
                            new Ilce() { Name = "Aladağ" },
                            new Ilce() { Name = "Ceyhan" },
                            new Ilce() { Name = "Feke" },
                            new Ilce() { Name = "İmamoğlu" },
                            new Ilce() { Name = "Karataş" },
                            new Ilce() { Name = "Kozan" },
                            new Ilce() {  Name = "Pozantı" },
                            }
                         },
                new Il() {Name="Tekirdağ",Ilceler= new List<Ilce>() {
                            new Ilce() { Name = "Adana Merkez" },
                            new Ilce() { Name = "Çukurova" },
                            new Ilce() { Name = "Karaisalı" },
                            new Ilce() { Name = "Sarıçam" },
                            new Ilce() { Name = "Seyhan" },
                            new Ilce() { Name = "Yüreğir " },
                            new Ilce() { Name = "Aladağ" },
                            new Ilce() { Name = "Ceyhan" },
                            new Ilce() { Name = "Feke" },
                            new Ilce() { Name = "İmamoğlu" },
                            new Ilce() { Name = "Karataş" },
                            new Ilce() { Name = "Kozan" },
                            new Ilce() {  Name = "Pozantı" },
                            }
                         },
                new Il() {Name="Tokat",Ilceler= new List<Ilce>() {
                            new Ilce() { Name = "Adana Merkez" },
                            new Ilce() { Name = "Çukurova" },
                            new Ilce() { Name = "Karaisalı" },
                            new Ilce() { Name = "Sarıçam" },
                            new Ilce() { Name = "Seyhan" },
                            new Ilce() { Name = "Yüreğir " },
                            new Ilce() { Name = "Aladağ" },
                            new Ilce() { Name = "Ceyhan" },
                            new Ilce() { Name = "Feke" },
                            new Ilce() { Name = "İmamoğlu" },
                            new Ilce() { Name = "Karataş" },
                            new Ilce() { Name = "Kozan" },
                            new Ilce() {  Name = "Pozantı" },
                            }
                         },
                new Il() {Name="Trabzon",Ilceler= new List<Ilce>() {
                            new Ilce() { Name = "Adana Merkez" },
                            new Ilce() { Name = "Çukurova" },
                            new Ilce() { Name = "Karaisalı" },
                            new Ilce() { Name = "Sarıçam" },
                            new Ilce() { Name = "Seyhan" },
                            new Ilce() { Name = "Yüreğir " },
                            new Ilce() { Name = "Aladağ" },
                            new Ilce() { Name = "Ceyhan" },
                            new Ilce() { Name = "Feke" },
                            new Ilce() { Name = "İmamoğlu" },
                            new Ilce() { Name = "Karataş" },
                            new Ilce() { Name = "Kozan" },
                            new Ilce() {  Name = "Pozantı" },
                            }
                         },
                new Il() {Name="Tunceli",Ilceler= new List<Ilce>() {
                            new Ilce() { Name = "Adana Merkez" },
                            new Ilce() { Name = "Çukurova" },
                            new Ilce() { Name = "Karaisalı" },
                            new Ilce() { Name = "Sarıçam" },
                            new Ilce() { Name = "Seyhan" },
                            new Ilce() { Name = "Yüreğir " },
                            new Ilce() { Name = "Aladağ" },
                            new Ilce() { Name = "Ceyhan" },
                            new Ilce() { Name = "Feke" },
                            new Ilce() { Name = "İmamoğlu" },
                            new Ilce() { Name = "Karataş" },
                            new Ilce() { Name = "Kozan" },
                            new Ilce() {  Name = "Pozantı" },
                            }
                         },
                new Il() {Name="Şanlıurfa",Ilceler= new List<Ilce>() {
                            new Ilce() { Name = "Adana Merkez" },
                            new Ilce() { Name = "Çukurova" },
                            new Ilce() { Name = "Karaisalı" },
                            new Ilce() { Name = "Sarıçam" },
                            new Ilce() { Name = "Seyhan" },
                            new Ilce() { Name = "Yüreğir " },
                            new Ilce() { Name = "Aladağ" },
                            new Ilce() { Name = "Ceyhan" },
                            new Ilce() { Name = "Feke" },
                            new Ilce() { Name = "İmamoğlu" },
                            new Ilce() { Name = "Karataş" },
                            new Ilce() { Name = "Kozan" },
                            new Ilce() {  Name = "Pozantı" },
                            }
                         },
                new Il() {Name="Uşak",Ilceler= new List<Ilce>() {
                            new Ilce() { Name = "Adana Merkez" },
                            new Ilce() { Name = "Çukurova" },
                            new Ilce() { Name = "Karaisalı" },
                            new Ilce() { Name = "Sarıçam" },
                            new Ilce() { Name = "Seyhan" },
                            new Ilce() { Name = "Yüreğir " },
                            new Ilce() { Name = "Aladağ" },
                            new Ilce() { Name = "Ceyhan" },
                            new Ilce() { Name = "Feke" },
                            new Ilce() { Name = "İmamoğlu" },
                            new Ilce() { Name = "Karataş" },
                            new Ilce() { Name = "Kozan" },
                            new Ilce() {  Name = "Pozantı" },
                            }
                         },
                new Il() {Name="Van",Ilceler= new List<Ilce>() {
                            new Ilce() { Name = "Adana Merkez" },
                            new Ilce() { Name = "Çukurova" },
                            new Ilce() { Name = "Karaisalı" },
                            new Ilce() { Name = "Sarıçam" },
                            new Ilce() { Name = "Seyhan" },
                            new Ilce() { Name = "Yüreğir " },
                            new Ilce() { Name = "Aladağ" },
                            new Ilce() { Name = "Ceyhan" },
                            new Ilce() { Name = "Feke" },
                            new Ilce() { Name = "İmamoğlu" },
                            new Ilce() { Name = "Karataş" },
                            new Ilce() { Name = "Kozan" },
                            new Ilce() {  Name = "Pozantı" },
                            }
                         },
                new Il() {Name="Yozgat",Ilceler= new List<Ilce>() {
                            new Ilce() { Name = "Adana Merkez" },
                            new Ilce() { Name = "Çukurova" },
                            new Ilce() { Name = "Karaisalı" },
                            new Ilce() { Name = "Sarıçam" },
                            new Ilce() { Name = "Seyhan" },
                            new Ilce() { Name = "Yüreğir " },
                            new Ilce() { Name = "Aladağ" },
                            new Ilce() { Name = "Ceyhan" },
                            new Ilce() { Name = "Feke" },
                            new Ilce() { Name = "İmamoğlu" },
                            new Ilce() { Name = "Karataş" },
                            new Ilce() { Name = "Kozan" },
                            new Ilce() {  Name = "Pozantı" },
                            }
                         },
                new Il() {Name="Zonguldak",Ilceler= new List<Ilce>() {
                            new Ilce() { Name = "Adana Merkez" },
                            new Ilce() { Name = "Çukurova" },
                            new Ilce() { Name = "Karaisalı" },
                            new Ilce() { Name = "Sarıçam" },
                            new Ilce() { Name = "Seyhan" },
                            new Ilce() { Name = "Yüreğir " },
                            new Ilce() { Name = "Aladağ" },
                            new Ilce() { Name = "Ceyhan" },
                            new Ilce() { Name = "Feke" },
                            new Ilce() { Name = "İmamoğlu" },
                            new Ilce() { Name = "Karataş" },
                            new Ilce() { Name = "Kozan" },
                            new Ilce() {  Name = "Pozantı" },
                            }
                         },
                new Il() {Name="Aksaray",Ilceler= new List<Ilce>() {
                            new Ilce() { Name = "Adana Merkez" },
                            new Ilce() { Name = "Çukurova" },
                            new Ilce() { Name = "Karaisalı" },
                            new Ilce() { Name = "Sarıçam" },
                            new Ilce() { Name = "Seyhan" },
                            new Ilce() { Name = "Yüreğir " },
                            new Ilce() { Name = "Aladağ" },
                            new Ilce() { Name = "Ceyhan" },
                            new Ilce() { Name = "Feke" },
                            new Ilce() { Name = "İmamoğlu" },
                            new Ilce() { Name = "Karataş" },
                            new Ilce() { Name = "Kozan" },
                            new Ilce() {  Name = "Pozantı" },
                            }
                         },
                new Il() {Name="Bayburt",Ilceler= new List<Ilce>() {
                            new Ilce() { Name = "Adana Merkez" },
                            new Ilce() { Name = "Çukurova" },
                            new Ilce() { Name = "Karaisalı" },
                            new Ilce() { Name = "Sarıçam" },
                            new Ilce() { Name = "Seyhan" },
                            new Ilce() { Name = "Yüreğir " },
                            new Ilce() { Name = "Aladağ" },
                            new Ilce() { Name = "Ceyhan" },
                            new Ilce() { Name = "Feke" },
                            new Ilce() { Name = "İmamoğlu" },
                            new Ilce() { Name = "Karataş" },
                            new Ilce() { Name = "Kozan" },
                            new Ilce() {  Name = "Pozantı" },
                            }
                         },
                new Il() {Name="Karaman",Ilceler= new List<Ilce>() {
                            new Ilce() { Name = "Adana Merkez" },
                            new Ilce() { Name = "Çukurova" },
                            new Ilce() { Name = "Karaisalı" },
                            new Ilce() { Name = "Sarıçam" },
                            new Ilce() { Name = "Seyhan" },
                            new Ilce() { Name = "Yüreğir " },
                            new Ilce() { Name = "Aladağ" },
                            new Ilce() { Name = "Ceyhan" },
                            new Ilce() { Name = "Feke" },
                            new Ilce() { Name = "İmamoğlu" },
                            new Ilce() { Name = "Karataş" },
                            new Ilce() { Name = "Kozan" },
                            new Ilce() {  Name = "Pozantı" },
                            }
                         },
                new Il() {Name="Kırıkkale",Ilceler= new List<Ilce>() {
                            new Ilce() { Name = "Adana Merkez" },
                            new Ilce() { Name = "Çukurova" },
                            new Ilce() { Name = "Karaisalı" },
                            new Ilce() { Name = "Sarıçam" },
                            new Ilce() { Name = "Seyhan" },
                            new Ilce() { Name = "Yüreğir " },
                            new Ilce() { Name = "Aladağ" },
                            new Ilce() { Name = "Ceyhan" },
                            new Ilce() { Name = "Feke" },
                            new Ilce() { Name = "İmamoğlu" },
                            new Ilce() { Name = "Karataş" },
                            new Ilce() { Name = "Kozan" },
                            new Ilce() {  Name = "Pozantı" },
                            }
                         },
                new Il() {Name="Batman",Ilceler= new List<Ilce>() {
                            new Ilce() { Name = "Adana Merkez" },
                            new Ilce() { Name = "Çukurova" },
                            new Ilce() { Name = "Karaisalı" },
                            new Ilce() { Name = "Sarıçam" },
                            new Ilce() { Name = "Seyhan" },
                            new Ilce() { Name = "Yüreğir " },
                            new Ilce() { Name = "Aladağ" },
                            new Ilce() { Name = "Ceyhan" },
                            new Ilce() { Name = "Feke" },
                            new Ilce() { Name = "İmamoğlu" },
                            new Ilce() { Name = "Karataş" },
                            new Ilce() { Name = "Kozan" },
                            new Ilce() {  Name = "Pozantı" },
                            }
                         },
                new Il() {Name="Şırnak",Ilceler= new List<Ilce>() {
                            new Ilce() { Name = "Adana Merkez" },
                            new Ilce() { Name = "Çukurova" },
                            new Ilce() { Name = "Karaisalı" },
                            new Ilce() { Name = "Sarıçam" },
                            new Ilce() { Name = "Seyhan" },
                            new Ilce() { Name = "Yüreğir " },
                            new Ilce() { Name = "Aladağ" },
                            new Ilce() { Name = "Ceyhan" },
                            new Ilce() { Name = "Feke" },
                            new Ilce() { Name = "İmamoğlu" },
                            new Ilce() { Name = "Karataş" },
                            new Ilce() { Name = "Kozan" },
                            new Ilce() {  Name = "Pozantı" },
                            }
                         },
                new Il() {Name="Bartın",Ilceler= new List<Ilce>() {
                            new Ilce() { Name = "Adana Merkez" },
                            new Ilce() { Name = "Çukurova" },
                            new Ilce() { Name = "Karaisalı" },
                            new Ilce() { Name = "Sarıçam" },
                            new Ilce() { Name = "Seyhan" },
                            new Ilce() { Name = "Yüreğir " },
                            new Ilce() { Name = "Aladağ" },
                            new Ilce() { Name = "Ceyhan" },
                            new Ilce() { Name = "Feke" },
                            new Ilce() { Name = "İmamoğlu" },
                            new Ilce() { Name = "Karataş" },
                            new Ilce() { Name = "Kozan" },
                            new Ilce() {  Name = "Pozantı" },
                            }
                         },
                new Il() {Name="Ardahan",Ilceler= new List<Ilce>() {
                            new Ilce() { Name = "Adana Merkez" },
                            new Ilce() { Name = "Çukurova" },
                            new Ilce() { Name = "Karaisalı" },
                            new Ilce() { Name = "Sarıçam" },
                            new Ilce() { Name = "Seyhan" },
                            new Ilce() { Name = "Yüreğir " },
                            new Ilce() { Name = "Aladağ" },
                            new Ilce() { Name = "Ceyhan" },
                            new Ilce() { Name = "Feke" },
                            new Ilce() { Name = "İmamoğlu" },
                            new Ilce() { Name = "Karataş" },
                            new Ilce() { Name = "Kozan" },
                            new Ilce() {  Name = "Pozantı" },
                            }
                         },
                new Il() {Name="Iğdır",Ilceler= new List<Ilce>() {
                            new Ilce() { Name = "Adana Merkez" },
                            new Ilce() { Name = "Çukurova" },
                            new Ilce() { Name = "Karaisalı" },
                            new Ilce() { Name = "Sarıçam" },
                            new Ilce() { Name = "Seyhan" },
                            new Ilce() { Name = "Yüreğir " },
                            new Ilce() { Name = "Aladağ" },
                            new Ilce() { Name = "Ceyhan" },
                            new Ilce() { Name = "Feke" },
                            new Ilce() { Name = "İmamoğlu" },
                            new Ilce() { Name = "Karataş" },
                            new Ilce() { Name = "Kozan" },
                            new Ilce() {  Name = "Pozantı" },
                            }
                         },
                new Il() {Name="Yalova",Ilceler= new List<Ilce>() {
                            new Ilce() { Name = "Adana Merkez" },
                            new Ilce() { Name = "Çukurova" },
                            new Ilce() { Name = "Karaisalı" },
                            new Ilce() { Name = "Sarıçam" },
                            new Ilce() { Name = "Seyhan" },
                            new Ilce() { Name = "Yüreğir " },
                            new Ilce() { Name = "Aladağ" },
                            new Ilce() { Name = "Ceyhan" },
                            new Ilce() { Name = "Feke" },
                            new Ilce() { Name = "İmamoğlu" },
                            new Ilce() { Name = "Karataş" },
                            new Ilce() { Name = "Kozan" },
                            new Ilce() {  Name = "Pozantı" },
                            }
                         },
                new Il() {Name="Karabük",Ilceler= new List<Ilce>() {
                            new Ilce() { Name = "Adana Merkez" },
                            new Ilce() { Name = "Çukurova" },
                            new Ilce() { Name = "Karaisalı" },
                            new Ilce() { Name = "Sarıçam" },
                            new Ilce() { Name = "Seyhan" },
                            new Ilce() { Name = "Yüreğir " },
                            new Ilce() { Name = "Aladağ" },
                            new Ilce() { Name = "Ceyhan" },
                            new Ilce() { Name = "Feke" },
                            new Ilce() { Name = "İmamoğlu" },
                            new Ilce() { Name = "Karataş" },
                            new Ilce() { Name = "Kozan" },
                            new Ilce() {  Name = "Pozantı" },
                            }
                         },
                new Il() {Name="Kilis",Ilceler= new List<Ilce>() {
                            new Ilce() { Name = "Adana Merkez" },
                            new Ilce() { Name = "Çukurova" },
                            new Ilce() { Name = "Karaisalı" },
                            new Ilce() { Name = "Sarıçam" },
                            new Ilce() { Name = "Seyhan" },
                            new Ilce() { Name = "Yüreğir " },
                            new Ilce() { Name = "Aladağ" },
                            new Ilce() { Name = "Ceyhan" },
                            new Ilce() { Name = "Feke" },
                            new Ilce() { Name = "İmamoğlu" },
                            new Ilce() { Name = "Karataş" },
                            new Ilce() { Name = "Kozan" },
                            new Ilce() {  Name = "Pozantı" },
                            }
                         },
                 new Il() {Name="Osmaniye",Ilceler= new List<Ilce>() {
                            new Ilce() { Name = "Adana Merkez" },
                            new Ilce() { Name = "Çukurova" },
                            new Ilce() { Name = "Karaisalı" },
                            new Ilce() { Name = "Sarıçam" },
                            new Ilce() { Name = "Seyhan" },
                            new Ilce() { Name = "Yüreğir " },
                            new Ilce() { Name = "Aladağ" },
                            new Ilce() { Name = "Ceyhan" },
                            new Ilce() { Name = "Feke" },
                            new Ilce() { Name = "İmamoğlu" },
                            new Ilce() { Name = "Karataş" },
                            new Ilce() { Name = "Kozan" },
                            new Ilce() {  Name = "Pozantı" },
                            }
                         },
                  new Il() {Name="Düzce",Ilceler= new List<Ilce>() {
                            new Ilce() { Name = "Adana Merkez" },
                            new Ilce() { Name = "Çukurova" },
                            new Ilce() { Name = "Karaisalı" },
                            new Ilce() { Name = "Sarıçam" },
                            new Ilce() { Name = "Seyhan" },
                            new Ilce() { Name = "Yüreğir " },
                            new Ilce() { Name = "Aladağ" },
                            new Ilce() { Name = "Ceyhan" },
                            new Ilce() { Name = "Feke" },
                            new Ilce() { Name = "İmamoğlu" },
                            new Ilce() { Name = "Karataş" },
                            new Ilce() { Name = "Kozan" },
                            new Ilce() {  Name = "Pozantı" },
                            }
                         },

            };


            string[] ilceIcleri = { "Adıyaman", "Merkez", "Besni", "Çelikhan", "Gerger" };
            string[] mahalleler = { "mahalle1", "mahalle2", "mahalle3", "mahalle4", "mahalle5" };

            string[] bolgeler = { "Akdeniz", "Ege", "Marmara", "Karadeniz", "İç Anadolu","Doğu Anadolu","Güneydoğu Anadolu"};


            int sayac = 1;
            int sayac2 = 1;
            int sayac3 = 1;

            for (int i = 0; i < 10; i++)
            {
                City il = new City()
                {
                    CityID = i + 1,
                    CountryID = 212,
                    CityName = iller[i].Name,
                    PlateNo = i + 1,
                    PhoneCode = 322,
                    RegionName = bolgeler[FakeData.NumberData.GetNumber(0,bolgeler.Count())]

                };
                context.Cities.Add(il);

                for (int j = 0; j < iller[i].Ilceler.Count; j++)
                {
                    County ilce = new County()
                    {
                        CountyID = sayac2,
                        City = il,
                        CountyName = iller[i].Ilceler[j].Name,
                    };
                    context.Counties.Add(ilce);

                    for (int t = 0; t < 5; t++)
                    {

                        Area il_area = new Area()
                        {
                            AreaID = sayac,
                            County = ilce,
                            AreaName = ilceIcleri[t]
                        };
                        context.Areas.Add(il_area);

                        for (int z = 0; z < 5; z++)
                        {
                            Neighborhood mah = new Neighborhood()
                            {
                                Area = il_area,
                                NeighborhoodID = sayac3,
                                NeighborhoodName = mahalleler[z],
                                ZipCode = "01720"
                            };
                            context.Neighborhoods.Add(mah);

                            sayac3++;
                        }


                        sayac++;
                        context.SaveChanges();
                    }


                    sayac2++;

                }


            }

            List<City> veriTabaniSehirler = context.Cities.ToList();



            // Kurumsal kullanici  seri

            for (int franchiseIndex = 0; franchiseIndex < 2; franchiseIndex++)
            {



                Franchise franchise = new Franchise()
                {
                    FranchiseName = FakeData.NameData.GetCompanyName(),
                    FranchiseLogo = "/Content/img/franchiseLogo.png",
                    IsActivated = true,
                    CreateDate = FakeData.DateTimeData.GetDatetime(DateTime.Now.AddYears(-1), DateTime.Now)

                };


                for (int kurumsalKullaniciIndex = 0; kurumsalKullaniciIndex < 2; kurumsalKullaniciIndex++)
                {

                    if (franchiseIndex == 0 && kurumsalKullaniciIndex==0)
                    {
                        VotedressUser kurumsalKullanici = new VotedressUser()
                        {
                            id = Guid.NewGuid(),
                            Email = "kurumsal@hotmail.com",
                            ActivateGuid = Guid.NewGuid(),
                            Password = "123123",
                            IsActive = true,
                            Franchise = franchise,
                            CreateDate = FakeData.DateTimeData.GetDatetime(DateTime.Now.AddYears(-1), DateTime.Now),
                            Role = "kurumsal",
                            SocialName = "votedress",
                            OnlineCount = 0,
                            SocialId = null,
                            ProfileImage = "/Content/img/magazaLogo.png",

                        };

                        context.VotedressUsers.Add(kurumsalKullanici);

                        City randomCity = veriTabaniSehirler[FakeData.NumberData.GetNumber(0, veriTabaniSehirler.Count)];
                        County randomCounty = randomCity.Counties[FakeData.NumberData.GetNumber(0, randomCity.Counties.Count)];
                        Area randomArea = randomCounty.Areas[FakeData.NumberData.GetNumber(0, randomCounty.Areas.Count)];
                        Neighborhood randomNeighborhood = randomArea.Neighborhoods[FakeData.NumberData.GetNumber(0, randomArea.Neighborhoods.Count)];

                        UserDetail kurumsalKullaniciDetail = new UserDetail()
                        {
                            UserId = kurumsalKullanici.id,
                            Birthday = FakeData.DateTimeData.GetDatetime(DateTime.Now.AddYears(-80), DateTime.Now.AddYears(-15)),
                            County = randomCounty,
                            Name = FakeData.NameData.GetFirstName(),
                            SurName = FakeData.NameData.GetSurname(),
                            City = randomCity,
                            Sex = "erkek",
                            CommencialTitle = FakeData.NameData.GetFirstName(),
                            CompanyName = FakeData.NameData.GetCompanyName(),
                            AdressDetail = FakeData.PlaceData.GetAddress(),
                            LandPhone = FakeData.PhoneNumberData.GetPhoneNumber(),
                            PhoneNumber = FakeData.PhoneNumberData.GetPhoneNumber(),
                            Neighborhood = randomNeighborhood
                        };

                        context.UserDetail.Add(kurumsalKullaniciDetail);

                        List<Category> kategoriler = new List<Category>();

                        for (int collectionIndex = 0; collectionIndex < 5; collectionIndex++)
                        {
                            Category kategori = new Category()
                            {
                                id = Guid.NewGuid(),
                                User = kurumsalKullanici,
                                CategoryName = FakeData.NameData.GetFullName(),
                                Description = FakeData.TextData.GetSentences(3),
                                CreateDate = FakeData.DateTimeData.GetDatetime(DateTime.Now.AddYears(-1), DateTime.Now)

                            };
                            context.Categories.Add(kategori);

                            kategoriler.Add(kategori);
                        }

                        for (int urunIndex = 0; urunIndex < 30; urunIndex++)
                        {
                            Product urun = new Product()
                            {
                                id = Guid.NewGuid(),
                                Price = FakeData.NumberData.GetNumber(20, 200),
                                Cost = FakeData.NumberData.GetNumber(10, 150),
                                IsForSale = true,
                                LongDescription = FakeData.TextData.GetSentences(5),
                                ModifiedDate = FakeData.DateTimeData.GetDatetime(DateTime.Now.AddYears(-1), DateTime.Now),
                                ProductImage = "/Content/img/Product.jpg",
                                ProductName = FakeData.NameData.GetFullName(),
                                ShortDescription = FakeData.TextData.GetSentences(2),
                                UploadDate = DateTime.Now,
                                User = kurumsalKullanici,
                            };

                            context.Products.Add(urun);


                            for (int n = 0; n < 2; n++)
                            {
                                int random = FakeData.NumberData.GetNumber(0, kategoriler.Count);
                                ProductCategory productCategory = new ProductCategory()
                                {
                                    Product = urun,
                                    Category = kategoriler[random]
                                };

                                context.ProductCategories.Add(productCategory);
                            }

                            context.SaveChanges();

                            for (int p = 0; p < 5; p++)
                            {
                                ProductSize productSize = new ProductSize();

                                switch (p)
                                {
                                    case 0:
                                        productSize.Product = urun;
                                        productSize.Size = "S";
                                        break;
                                    case 1:
                                        productSize.Product = urun;
                                        productSize.Size = "M";
                                        break;
                                    case 2:
                                        productSize.Product = urun;
                                        productSize.Size = "L";
                                        break;
                                    case 3:
                                        productSize.Product = urun;
                                        productSize.Size = "XL";
                                        break;
                                    case 4:
                                        productSize.Product = urun;
                                        productSize.Size = "XXL";
                                        break;
                                }

                                context.ProductSizes.Add(productSize);


                                for (int w = 0; w < 3; w++)
                                {

                                    ProductColor productColor = new ProductColor()
                                    {
                                        ProductSize = productSize,
                                        StockCount = FakeData.NumberData.GetNumber(10, 100),
                                    };
                                    context.ProductColors.Add(productColor);

                                    for (int z = 0; z < 2; z++)
                                    {
                                        int random = FakeData.NumberData.GetNumber(0, 8);
                                        ProductColorDetail productColorDetail = new ProductColorDetail()
                                        {
                                            ProductColor = productColor,
                                            Color = renkler[random],
                                        };

                                        context.ProductColorDetails.Add(productColorDetail);
                                    }

                                    for (int q = 0; q < 3; q++)
                                    {
                                        ProductImageGallery imageGallery = new ProductImageGallery()
                                        {
                                            ProductColor = productColor,
                                            ImagePath = "/Content/img/Product.jpg",

                                        };

                                        context.ProductImageGallery.Add(imageGallery);
                                    }
                                }
                            }
                        }
                    }
                    else
                    {
                        VotedressUser kurumsalKullanici2 = new VotedressUser()
                        {
                            id = Guid.NewGuid(),
                            Email = FakeData.NetworkData.GetEmail(),
                            ActivateGuid = Guid.NewGuid(),
                            Password = "123123",
                            IsActive = true,
                            Franchise = franchise,
                            CreateDate = FakeData.DateTimeData.GetDatetime(DateTime.Now.AddYears(-1), DateTime.Now),
                            Role = "kurumsal",
                            SocialName = "votedress",
                            OnlineCount = 0,
                            SocialId = null,
                            ProfileImage = "/Content/img/magazaLogo.png",

                        };

                        context.VotedressUsers.Add(kurumsalKullanici2);

                        City randomCity = veriTabaniSehirler[FakeData.NumberData.GetNumber(0, veriTabaniSehirler.Count)];
                        County randomCounty = randomCity.Counties[FakeData.NumberData.GetNumber(0, randomCity.Counties.Count)];
                        Area randomArea = randomCounty.Areas[FakeData.NumberData.GetNumber(0, randomCounty.Areas.Count)];
                        Neighborhood randomNeighborhood = randomArea.Neighborhoods[FakeData.NumberData.GetNumber(0, randomArea.Neighborhoods.Count)];

                        UserDetail kurumsalKullaniciDetail2 = new UserDetail()
                        {
                            UserId = kurumsalKullanici2.id,
                            Birthday = FakeData.DateTimeData.GetDatetime(DateTime.Now.AddYears(-80), DateTime.Now.AddYears(-15)),
                            County = randomCounty,
                            Name = FakeData.NameData.GetFirstName(),
                            SurName = FakeData.NameData.GetSurname(),
                            City = randomCity,
                            Sex = "erkek",
                            CommencialTitle = FakeData.NameData.GetFirstName(),
                            CompanyName = FakeData.NameData.GetCompanyName(),
                            AdressDetail = FakeData.PlaceData.GetAddress(),
                            LandPhone = FakeData.PhoneNumberData.GetPhoneNumber(),
                            PhoneNumber = FakeData.PhoneNumberData.GetPhoneNumber(),
                            Neighborhood = randomNeighborhood
                        };

                        context.UserDetail.Add(kurumsalKullaniciDetail2);



                        List<Category> kategoriler = new List<Category>();

                        for (int collectionIndex = 0; collectionIndex < 0; collectionIndex++)
                        {
                            Category kategori = new Category()
                            {
                                id = Guid.NewGuid(),
                                User = kurumsalKullanici2,
                                CategoryName = FakeData.NameData.GetFullName(),
                                Description = FakeData.TextData.GetSentences(3),
                                CreateDate = FakeData.DateTimeData.GetDatetime(DateTime.Now.AddYears(-1), DateTime.Now)

                            };
                            context.Categories.Add(kategori);

                            kategoriler.Add(kategori);
                        }

                        for (int urunIndex = 0; urunIndex < 0; urunIndex++)
                        {
                            Product urun = new Product()
                            {
                                id = Guid.NewGuid(),
                                Cost = FakeData.NumberData.GetNumber(10, 150),
                                Price = FakeData.NumberData.GetNumber(20, 1000),
                                IsForSale = true,
                                LongDescription = FakeData.TextData.GetSentences(5),
                                ModifiedDate = FakeData.DateTimeData.GetDatetime(DateTime.Now.AddYears(-1), DateTime.Now),
                                ProductImage = "/Content/img/Product.jpg",
                                ProductName = FakeData.NameData.GetFullName(),
                                ShortDescription = FakeData.TextData.GetSentences(2),
                                UploadDate = DateTime.Now,
                                User = kurumsalKullanici2,
                            };

                            context.Products.Add(urun);


                            for (int n = 0; n < 2; n++)
                            {
                                int random = FakeData.NumberData.GetNumber(0, kategoriler.Count);
                                ProductCategory productCategory = new ProductCategory()
                                {
                                    Product = urun,
                                    Category = kategoriler[random]
                                };

                                context.ProductCategories.Add(productCategory);
                            }
                            context.SaveChanges();

                            for (int p = 0; p < 5; p++)
                            {
                                ProductSize productSize = new ProductSize();

                                switch (p)
                                {
                                    case 0:
                                        productSize.Product = urun;
                                        productSize.Size = "S";
                                        break;
                                    case 1:
                                        productSize.Product = urun;
                                        productSize.Size = "M";
                                        break;
                                    case 2:
                                        productSize.Product = urun;
                                        productSize.Size = "L";
                                        break;
                                    case 3:
                                        productSize.Product = urun;
                                        productSize.Size = "XL";
                                        break;
                                    case 4:
                                        productSize.Product = urun;
                                        productSize.Size = "XXL";
                                        break;
                                }

                                context.ProductSizes.Add(productSize);


                                for (int w = 0; w < 3; w++)
                                {

                                    ProductColor productColor = new ProductColor()
                                    {
                                        ProductSize = productSize,
                                        StockCount = FakeData.NumberData.GetNumber(10, 100),
                                    };
                                    context.ProductColors.Add(productColor);

                                    for (int z = 0; z < 2; z++)
                                    {
                                        int random = FakeData.NumberData.GetNumber(0, 5);
                                        ProductColorDetail productColorDetail = new ProductColorDetail()
                                        {
                                            ProductColor = productColor,
                                            Color = renkler[random],
                                        };

                                        context.ProductColorDetails.Add(productColorDetail);
                                    }

                                    for (int q = 0; q < 3; q++)
                                    {
                                        ProductImageGallery imageGallery = new ProductImageGallery()
                                        {
                                            ProductColor = productColor,
                                            ImagePath = "/Content/img/Product.jpg",

                                        };

                                        context.ProductImageGallery.Add(imageGallery);
                                    }
                                }
                            }


                        }
                    }
                }
            }



            //Bireysel kullanici Örnek

            List<Product> products = context.Products.ToList();

            VotedressUser bireyselKullaniciOrnek = new VotedressUser()
            {
                id=Guid.NewGuid(),
                SocialId = null,
                Email = "erdem.keskin@hotmail.com ",
                Password = "123123",
                Role = "bireysel",
                IsActive = true,
                ActivateGuid = Guid.NewGuid(),
                ProfileImage = "/Content/img/erdemprofil.png",
                SocialName = "votedress",
                CreateDate = FakeData.DateTimeData.GetDatetime(DateTime.Now.AddYears(-1), DateTime.Now)
            };

            context.VotedressUsers.Add(bireyselKullaniciOrnek);
            context.SaveChanges();

            City randomCity3 = veriTabaniSehirler[FakeData.NumberData.GetNumber(0, veriTabaniSehirler.Count)];
            County randomCounty3 = randomCity3.Counties[FakeData.NumberData.GetNumber(0, randomCity3.Counties.Count)];
            Area randomArea3 = randomCounty3.Areas[FakeData.NumberData.GetNumber(0, randomCounty3.Areas.Count)];
            Neighborhood randomNeighborhood3 = randomArea3.Neighborhoods[FakeData.NumberData.GetNumber(0, randomArea3.Neighborhoods.Count)];



            UserDetail bireyselKullaniciOrnekDetay = new UserDetail()
            {
                UserId = bireyselKullaniciOrnek.id,
                Birthday = FakeData.DateTimeData.GetDatetime(DateTime.Now.AddYears(-80), DateTime.Now.AddYears(-15)),
                County = randomCounty3,
                Name = "Erdem",
                SurName = "KESKİN",
                City = randomCity3,
                Sex = "erkek",
                Neighborhood = randomNeighborhood3
            };

            context.UserDetail.Add(bireyselKullaniciOrnekDetay);

            City city = context.Cities.Where(x => x.CityID == 1).FirstOrDefault();

            UserAdress userAdress1 = new UserAdress()
            {
             
                User= bireyselKullaniciOrnek,
                Email= bireyselKullaniciOrnek.Email,
                Adress=FakeData.PlaceData.GetAddress(),
                AdressTitle=FakeData.NameData.GetFullName(),
                Name=FakeData.NameData.GetFirstName(),
                PhoneNumber=FakeData.PhoneNumberData.GetPhoneNumber(),
                SurName=FakeData.NameData.GetSurname(),
                City=city,
                County= city.Counties[0],
                Neighborhood= city.Counties[0].Areas[0].Neighborhoods[0]

            };

            context.UserAdresses.Add(userAdress1);


            VotedressUser bireyselKullaniciOrnek2 = new VotedressUser()
            {
                SocialId = null,
                Email = "zekeriya.dadas@hotmail.com    ",
                Password = "123123",
                Role = "bireysel",
                IsActive = true,
                ActivateGuid = Guid.NewGuid(),
                ProfileImage = "/Content/img/zekeriyaprofil.jpg",
                SocialName = "votedress",
                CreateDate = FakeData.DateTimeData.GetDatetime(DateTime.Now.AddYears(-1), DateTime.Now)
            };

            context.VotedressUsers.Add(bireyselKullaniciOrnek2);
            context.SaveChanges();

            City randomCity2 = veriTabaniSehirler[FakeData.NumberData.GetNumber(0, veriTabaniSehirler.Count)];
            County randomCounty2 = randomCity2.Counties[FakeData.NumberData.GetNumber(0, randomCity2.Counties.Count)];
            Area randomArea2 = randomCounty2.Areas[FakeData.NumberData.GetNumber(0, randomCounty2.Areas.Count)];
            Neighborhood randomNeighborhood2 = randomArea2.Neighborhoods[FakeData.NumberData.GetNumber(0, randomArea2.Neighborhoods.Count)];

            UserDetail bireyselKullaniciOrnekDetay2 = new UserDetail()
            {
                UserId = bireyselKullaniciOrnek2.id,
                Birthday = FakeData.DateTimeData.GetDatetime(DateTime.Now.AddYears(-80), DateTime.Now.AddYears(-15)),
                County = randomCounty2,
                Name = "Zekeriya",
                SurName = "DADAŞ",
                City = randomCity2,
                Sex = "erkek",
                Neighborhood = randomNeighborhood2
            };

            context.UserDetail.Add(bireyselKullaniciOrnekDetay2);


            UserAdress userAdress2 = new UserAdress()
            {

                User = bireyselKullaniciOrnek2,
                Email = bireyselKullaniciOrnek.Email,
                Adress = FakeData.PlaceData.GetAddress(),
                AdressTitle = FakeData.NameData.GetFullName(),
                Name = FakeData.NameData.GetFirstName(),
                PhoneNumber = FakeData.PhoneNumberData.GetPhoneNumber(),
                SurName = FakeData.NameData.GetSurname(),
                City = city,
                County = city.Counties[0],
                Neighborhood = city.Counties[0].Areas[0].Neighborhoods[0]

            };

            context.UserAdresses.Add(userAdress2);

            Friend arkadas = new Friend()
            {
                User = bireyselKullaniciOrnek,
                MyFriend = bireyselKullaniciOrnek2,
                ArkadaslikTarihi = DateTime.Now,
                Durum = true


            };

            context.Friends.Add(arkadas);
            context.SaveChanges();

            Friend arkadas2 = new Friend()
            {
                User = bireyselKullaniciOrnek2,
                MyFriend = bireyselKullaniciOrnek,
                ArkadaslikTarihi = DateTime.Now,
                Durum = true

            };

            context.Friends.Add(arkadas2);
            context.SaveChanges();


            List<Friend> arkdaslar = context.Friends.Where(x => x.User.id == bireyselKullaniciOrnek.id).ToList();
            PrivateMessage mesaj = null;

            for (int i = 0; i < arkdaslar.Count; i++)
            {
                for (int j = 0; j < 3; j++)
                {

                    mesaj = new PrivateMessage()
                    {
                        User = bireyselKullaniciOrnek,
                        AlanId = arkdaslar[i].MyFriend,
                        GorulmeDurumu = true,
                        GöndermeTarihi = DateTime.Now,
                        Message = FakeData.TextData.GetSentences(2)

                    };

                    context.PrivateMessages.Add(mesaj);
                    context.SaveChanges();

                    mesaj = new PrivateMessage()
                    {
                        User = arkdaslar[i].MyFriend,
                        AlanId = bireyselKullaniciOrnek,
                        GorulmeDurumu = true,
                        GöndermeTarihi = DateTime.Now,
                        Message = FakeData.TextData.GetSentences(2)

                    };

                    context.PrivateMessages.Add(mesaj);
                    context.SaveChanges();
                }
            }

            for (int i = 0; i < 5; i++)
            {
                Collection koleksiyon = new Collection()
                {
                    id = Guid.NewGuid(),
                    CreateDate = DateTime.Now,
                    CollectionName = FakeData.NameData.GetFullName(),
                    Description = FakeData.TextData.GetSentences(2),
                    User = bireyselKullaniciOrnek
                };

                context.Collections.Add(koleksiyon);

                for (int j = 0; j < 5; j++)
                {
                    ProductCollection prodcutCollection = new ProductCollection()
                    {
                        Collection = koleksiyon,
                        Product = products[FakeData.NumberData.GetNumber(0, products.Count)],
                    };

                    context.ProductCollections.Add(prodcutCollection);
                }
            }

            context.SaveChanges();

            //Bireysel kullanici Serii

            for (int i = 0; i < 1000; i++)
            {
                City randomCity = veriTabaniSehirler[FakeData.NumberData.GetNumber(0, veriTabaniSehirler.Count)];
                County randomCounty = randomCity.Counties[FakeData.NumberData.GetNumber(0, randomCity.Counties.Count)];
                Area randomArea = randomCounty.Areas[FakeData.NumberData.GetNumber(0, randomCounty.Areas.Count)];
                Neighborhood randomNeighborhood = randomArea.Neighborhoods[FakeData.NumberData.GetNumber(0, randomArea.Neighborhoods.Count)];

                VotedressUser bireyselKullanici = new VotedressUser()
                {
                    SocialId = null,
                    Email = FakeData.NetworkData.GetEmail(),
                    Password = "123123",
                    Role = "bireysel",
                    IsActive = true,
                    ActivateGuid = Guid.NewGuid(),
                    ProfileImage = "/Content/img/profil_resmi.png",
                    SocialName = "votedress",
                    CreateDate = FakeData.DateTimeData.GetDatetime(DateTime.Now.AddYears(-1), DateTime.Now)
                };


                context.VotedressUsers.Add(bireyselKullanici);
                context.SaveChanges();


                UserDetail bireyselKullaniciDetay = new UserDetail()
                {

                    UserId = bireyselKullanici.id,
                    Birthday = FakeData.DateTimeData.GetDatetime(DateTime.Now.AddYears(-80), DateTime.Now.AddYears(-15)),
                    County = randomCounty,
                    Name = FakeData.NameData.GetFirstName(),
                    SurName = FakeData.NameData.GetSurname(),
                    City = randomCity,
                    Sex = (i % 2 == 0) ? "erkek" : "kadın",
                    Neighborhood = randomNeighborhood,


                };

                context.UserDetail.Add(bireyselKullaniciDetay);

                int countyIndex = FakeData.NumberData.GetNumber(0, randomCity.Counties.Count - 1);
                int areaIndex= FakeData.NumberData.GetNumber(0, randomCity.Counties[countyIndex].Areas.Count - 1);

                UserAdress userAdress3 = new UserAdress()
                {
                    User = bireyselKullanici,
                    Email = bireyselKullanici.Email,
                    Adress = FakeData.PlaceData.GetAddress(),
                    AdressTitle = FakeData.NameData.GetFullName(),
                    Name = FakeData.NameData.GetFirstName(),
                    PhoneNumber = FakeData.PhoneNumberData.GetPhoneNumber(),
                    SurName = FakeData.NameData.GetSurname(),
                    City = randomCity,
                    County = randomCity.Counties[countyIndex],
                    Neighborhood = randomCity.Counties[countyIndex].Areas[areaIndex].Neighborhoods[areaIndex]
                };
                context.UserAdresses.Add(userAdress3);

                context.SaveChanges();

                for (int t = 0; t < 2; t++)
                {
                    Collection koleksiyon = new Collection()
                    {
                        id = Guid.NewGuid(),
                        CreateDate = DateTime.Now,
                        CollectionName = FakeData.NameData.GetFullName(),
                        Description = FakeData.TextData.GetSentences(2),
                        User = bireyselKullanici
                    };

                    context.Collections.Add(koleksiyon);

                    for (int j = 0; j < 2; j++)
                    {
                        ProductCollection prodcutCollection = new ProductCollection()
                        {
                            Collection = koleksiyon,
                            Product = products[FakeData.NumberData.GetNumber(0, products.Count)],
                        };

                        context.ProductCollections.Add(prodcutCollection);
                    }
                }


                bool arkDurum = FakeData.BooleanData.GetBoolean();

                Friend arkadas3 = new Friend()
                {
                    User = bireyselKullanici,
                    MyFriend = bireyselKullanici,
                    ArkadaslikTarihi = DateTime.Now,
                    Durum = arkDurum

                };

                context.Friends.Add(arkadas3);
                context.SaveChanges();


            }

            context.SaveChanges();

            List<VotedressUser> oylamaBaslatacaklar = context.VotedressUsers.Where(x => x.Role == "bireysel").Take(3).ToList();

            for (int m = 0; m < oylamaBaslatacaklar.Count; m++)
            {
                Vote oylama = new Vote()
                {
                    id = Guid.NewGuid(),
                    Counter = 0,
                    FinishTime = FakeData.DateTimeData.GetDatetime(DateTime.Now.AddYears(+1), DateTime.Now.AddDays(+1)),
                    PaylasimaAcikmi = true,
                    ProfilGorunsunMu = true,
                    StartTime = DateTime.Now,
                    TypeOfVote = "genel",
                    VoteLink = Guid.Empty,
                    User = oylamaBaslatacaklar[m]
                };

                context.Votes.Add(oylama);


                for (int l = 0; l < 3; l++)
                {
                    VoteProduct voteProduct = new VoteProduct()
                    {

                        Product = products[FakeData.NumberData.GetNumber(0, products.Count)],
                        Vote = oylama,
                        VoteCount = FakeData.NumberData.GetNumber(50, 10000),                        

                    };
                    context.VoteProduct.Add(voteProduct);

                    for (int k = 0; k < 2; k++)
                    {
                        VoteImage oylamaResmi = new VoteImage()
                        {
                            ImageNo = k + 1,
                            Aciklama = FakeData.TextData.GetSentences(1),
                            VoteProduct = voteProduct,
                            ImagePath = "/Content/img/4b90ffac-1ad2-e711-851d-80fa5b102e43_bc040459-cd97-47ef-aedf-bc177ab069f6_1.jpg",

                        };

                        context.VoteImages.Add(oylamaResmi);
                        context.SaveChanges();
                    }
                }

                context.SaveChanges();
            
            }

            // paylaşim yorum like       

            List<Vote> votes = context.Votes.ToList();
            List<Collection> collections = context.Collections.ToList();
            List<VotedressUser> users = context.VotedressUsers.Where(x => x.Role == "bireysel").ToList();
            List<Vote> vote = context.Votes.ToList();

            string[] socials = { "facebook", "instagram", "twitter", "votedress" };



            for (int k = 0; k < 0; k++)
            {

                for (int i = 0; i < 0; i++)
                {

                    ProductComment productComment = new ProductComment()
                    {
                        Product = products[FakeData.NumberData.GetNumber(0, products.Count)],
                        CommentDate = DateTime.Now,
                        Comment = "yorum " + i + " " + FakeData.TextData.GetSentences(3),
                        VotedressUser = users[k],
                    };

                    context.ProductComments.Add(productComment);

                    for (int z = 0; z < 3; z++)
                    {
                        ProductCommentLike productCommentLike = new ProductCommentLike()
                        {
                            LikeDate = DateTime.Now,
                            VotedressUser = users[z],
                            ProductComment = productComment,
                        };

                        context.ProductCommentLike.Add(productCommentLike);

                    }

                    for (int t = 0; t < 5; t++)
                    {
                        ProductCommentReply productCommentReply = new ProductCommentReply()
                        {
                            ProdutComment = productComment,
                            Comment = "cevap " + i + " " + FakeData.TextData.GetSentences(2),
                            CommentDate = DateTime.Now,
                            VotedressUser = users[FakeData.NumberData.GetNumber(0, users.Count)],
                        };

                        context.ProductCommentReplies.Add(productCommentReply);


                        for (int z = 0; z < 3; z++)
                        {
                            ProductCommentReplyLike productCommentReplyLike = new ProductCommentReplyLike()
                            {
                                LikeDate = DateTime.Now,
                                VotedressUser = users[users.Count - 1 - z],
                                ProductCommentReply = productCommentReply,
                            };

                            context.ProductCommentReplyLikes.Add(productCommentReplyLike);

                        }
                    }
                }
            }

            context.SaveChanges();

            string[] share = { "vote", "product", "collection" };

            for (int i = 0; i <0; i++)//Paylaşım tablosuna test verileri eklendi
            {
                for (int j = 0; j < 2; j++)
                {

                    SocialShare socialShare = new SocialShare()
                    {
                        id = Guid.NewGuid(),
                        VotedressUser = users[i],
                        ShareDate = DateTime.Now,
                        SocialName = socials[FakeData.NumberData.GetNumber(0, 4)],

                    };

                    switch (FakeData.NumberData.GetNumber(0, 3))
                    {
                        case 0:
                            socialShare.ShareName = share[0];
                            socialShare.Vote = vote[FakeData.NumberData.GetNumber(0, vote.Count)];
                            break;
                        case 1:
                            socialShare.ShareName = share[1];
                            socialShare.Product = products[FakeData.NumberData.GetNumber(0, products.Count)];
                            break;
                        case 2:
                            socialShare.ShareName = share[2];
                            socialShare.Collection = collections[FakeData.NumberData.GetNumber(0, collections.Count)];
                            break;
                    }

                    context.SocialShares.Add(socialShare);
                }
            }
            context.SaveChanges();


            ArrayList list = new ArrayList();
            ArrayList sizes = new ArrayList();

            float sayiiii = (users.Count + 1) / 3;

            int kullaniciSayi = 1000;


            for (int i = 0; i <0 /*kullaniciSayi*/; i++)
            {

                Cart cart = new Cart()
                {
                    User = users[i]
                };

                context.Carts.Add(cart);


                for (int j = 0; j < FakeData.NumberData.GetNumber(1, 6); j++)
                {

                    Random rnd = new Random();

                    int deger = rnd.Next(products.Count); // 0-sayi arasında rasgele sayı
                    if (list.IndexOf(deger) == -1)
                    {

                        int size = rnd.Next(products[deger].ProductSize.Count);

                        if (sizes.IndexOf(size) == -1)
                        {
                            CartDetail cartDetail = new CartDetail()
                            {
                                Cart = cart,
                                Product = products[deger],
                                AddToCartDate=DateTime.Now,
                                ProductCount = FakeData.NumberData.GetNumber(1, 4),
                                Size = products[deger].ProductSize[size].Size,
                                ProductColorId = products[deger].ProductSize[size].ProductColor[FakeData.NumberData.GetNumber(0, products[deger].ProductSize[size].ProductColor.Count)].id,

                            };

                            context.CartDetails.Add(cartDetail);

                            list.Add(size);
                            list.Add(deger);
                        }
                        else
                            j--;

                    }
                    else
                    {
                        j--;
                    }

                }

                list.Clear();
            }

            //Siparis

            for (int i = 0; i < 1000; i++)
            {
                VotedressUser userrrr = users[FakeData.NumberData.GetNumber(0, 999)];

                Order order = new Order()
                {

                    OrderDate = DateTime.Now,
                    User = userrrr,
                    UserAdress= userrrr.UserAdresses[0]
                };

                context.Orders.Add(order);


                for (int j = 0; j < FakeData.NumberData.GetNumber(1, 6); j++)
                {

                    Random rnd = new Random();

                    int deger = rnd.Next(products.Count); // 0-sayi arasında rasgele sayı
                    if (list.IndexOf(deger) == -1)
                    {

                        int size = rnd.Next(products[deger].ProductSize.Count);

                        if (sizes.IndexOf(size) == -1)
                        {
                            OrderDetail orderDetail = new OrderDetail()
                            {
                                Order = order,
                                Product = products[deger],
                                ProductCount = FakeData.NumberData.GetNumber(1, 4),
                                Size = products[deger].ProductSize[size].Size,
                                ProductColorId = products[deger].ProductSize[size].ProductColor[FakeData.NumberData.GetNumber(0, products[deger].ProductSize[size].ProductColor.Count)].id,

                            };

                            context.OrderDetails.Add(orderDetail);

                            list.Add(size);
                            list.Add(deger);
                        }
                        else
                            j--;

                    }
                    else
                    {
                        j--;
                    }

                }

                list.Clear();
            }


            context.SaveChanges();
        }
    }


    public class Il
    {

        public int id { get; set; }

        public string Name { get; set; }
        public List<Ilce> Ilceler { get; set; }

        public Il()
        {
            Ilceler = new List<Ilce>();

        }
    }

    public class Ilce
    {

        public int id { get; set; }

        public string Name { get; set; }
    }
}
