var countries = [
    //{
    //    "Country": "Afghanistan",
    //    "CountryCode": "AFG",
    //    "Region": "Asia | South & West",
    //    "Continent": "Asia",
    //    "GDP": 15936784437.22,
    //    "GDP_perCapita": 561.2,
    //    "lifeExpectancy": 59.60009756
    //},
];

var marmaraToplamGelir = 0, akdenizToplamGelir = 0, egeToplamGelir = 0, karadenizToplamGelir = 0, icAnadoluToplamGelir = 0, doguAnadoluToplamGelir = 0, guneydoguAnadoluToplamGelir = 0;


for (var i = 0; i < urunAnalizVerileri.chart1Model.length; i++) {

    countries.push(
        {
            "Country": urunAnalizVerileri.chart1Model[i].SehirAdi,
            "CountryCode": "AFG_" + i,
            "Region": urunAnalizVerileri.chart1Model[i].BolgeAdi,
            "Continent": "Asia",
            "GDP": urunAnalizVerileri.chart1Model[i].KisiSayisi,
            "GDP_perCapita": urunAnalizVerileri.chart1Model[i].Yas,
            "lifeExpectancy": urunAnalizVerileri.chart1Model[i].Gelir
        }
    )
    if (urunAnalizVerileri.chart1Model[i].BolgeAdi == "Marmara") {

        marmaraToplamGelir += urunAnalizVerileri.chart1Model[i].Gelir;
    }
    else if (urunAnalizVerileri.chart1Model[i].BolgeAdi == "Akdeniz") {
        akdenizToplamGelir += urunAnalizVerileri.chart1Model[i].Gelir;
    }
    else if (urunAnalizVerileri.chart1Model[i].BolgeAdi == "Ege") {
        egeToplamGelir += urunAnalizVerileri.chart1Model[i].Gelir;
    }
    else if (urunAnalizVerileri.chart1Model[i].BolgeAdi == "Karadeniz") {
        karadenizToplamGelir += urunAnalizVerileri.chart1Model[i].Gelir;
    }
    else if (urunAnalizVerileri.chart1Model[i].BolgeAdi == "İç Anadolu") {
        icAnadoluToplamGelir += urunAnalizVerileri.chart1Model[i].Gelir;
    }
    else if (urunAnalizVerileri.chart1Model[i].BolgeAdi == "Doğu Anadolu") {
        doguAnadoluToplamGelir += urunAnalizVerileri.chart1Model[i].Gelir;
    }
    else if (urunAnalizVerileri.chart1Model[i].BolgeAdi == "Güneydoğu Anadolu") {
        guneydoguAnadoluToplamGelir += urunAnalizVerileri.chart1Model[i].Gelir;
    }
}

//Chart 2 worldbank
//{ State: 'Marmara', freq: { beyaz: 1282, siyah: 4343, yesil: 4343, kirmizi: 213, sari: 4345, mavi: 3231, kahverengi: 6524, mor: 546 } },

var freqData = urunAnalizVerileri.chart2Model;






//Chart 3 worldbank

var dataset = [
    { category: "Ocak (K)", measure: 0.06 },
    { category: "Şubat (K)", measure: 0.08 },
    { category: "Mart (İ)", measure: 0.08 },
    { category: "Nisan (İ)", measure: 0.05 },
    { category: "Mayıs (İ)", measure: 0.06 },
    { category: "Haziran (Y)", measure: 0.04 },
    { category: "Temmuz (Y)", measure: 0.15 },
    { category: "Ağustos (Y)", measure: 0.10 },
    { category: "Eylül (SB)", measure: 0.10 },
    { category: "Ekim (SB)", measure: 0.02 },
    { category: "Kasım (SB)", measure: 0.22 },
    { category: "Aralık (K)", measure: 0.06},
]
    ;


var datasetBarChart = [
    { group: "All", category: "Erkek", measure: 10252.0864 },
    { group: "All", category: "Kadın", measure: 55213.0864},
    { group: "All", category: "Gömlek", measure: 26841.0864 },
    { group: "All", category: "Pantolon", measure: 5855.0864 },
    { group: "All", category: "Ayakkabı", measure: 54554.0201 },
    { group: "Ocak (K)", category: "Erkek", measure: 19441.5648 },
    { group: "Ocak (K)", category: "Kadın", measure: 25922.0864 },
    { group: "Ocak (K)", category: "Gömlek", measure: 9720.7824 },
    { group: "Ocak (K)", category: "Pantolon", measure: 6480.5216 },
    { group: "Ocak (K)", category: "Ayakkabı", measure: 19441.5648 },
    { group: "Şubat (K)", category: "Erkek", measure: 22913.2728 },
    { group: "Şubat (K)", category: "Kadın", measure: 7637.7576 },
    { group: "Şubat (K)", category: "Gömlek", measure: 23549.7526 },
    { group: "Şubat (K)", category: "Pantolon", measure: 1909.4394 },
    { group: "Şubat (K)", category: "Ayakkabı", measure: 7637.7576 },
    { group: "Mart (İ)", category: "Erkek", measure: 1041.5124 },
    { group: "Mart (İ)", category: "Kadın", measure: 2430.1956 },
    { group: "Mart (İ)", category: "Gömlek", measure: 15275.5152 },
    { group: "Mart (İ)", category: "Pantolon", measure: 4166.0496 },
    { group: "Mart (İ)", category: "Ayakkabı", measure: 11803.8072 },
    { group: "Nisan (İ)", category: "Erkek", measure: 7406.3104 },
    { group: "Nisan (İ)", category: "Kadın", measure: 2545.9192 },
    { group: "Nisan (İ)", category: "Gömlek", measure: 1620.1304 },
    { group: "Nisan (İ)", category: "Pantolon", measure: 8563.5464 },
    { group: "Nisan (İ)", category: "Ayakkabı", measure: 3008.8136 },
    { group: "Mayıs (İ)", category: "Erkek", measure: 7637.7576 },
    { group: "Mayıs (İ)", category: "Kadın", measure: 35411.4216 },
    { group: "Mayıs (İ)", category: "Gömlek", measure: 8332.0992 },
    { group: "Mayıs (İ)", category: "Pantolon", measure: 6249.0744 },
    { group: "Mayıs (İ)", category: "Ayakkabı", measure: 11803.8072 },
    { group: "Haziran (Y)", category: "Erkek", measure: 3182.399 },
    { group: "Haziran (Y)", category: "Kadın", measure: 867.927 },
    { group: "Haziran (Y)", category: "Gömlek", measure: 1808.18125 },
    { group: "Haziran (Y)", category: "Pantolon", measure: 795.59975 },
    { group: "Haziran (Y)", category: "Ayakkabı", measure: 578.618 },
    { group: "Temmuz (Y)", category: "Oranges", measure: 2227.6793 },
    { group: "Temmuz (Y)", category: "Apples", measure: 3442.7771 },
    { group: "Temmuz (Y)", category: "Grapes", measure: 303.77445 },
    { group: "Temmuz (Y)", category: "Figs", measure: 2328.93745 },
    { group: "Temmuz (Y)", category: "Mangos", measure: 1822.6467 },
    { group: "Ağustos (Y)", category: "Erkek", measure: 2152.399 },
    { group: "Ağustos (Y)", category: "Kadın", measure: 8545.927 },
    { group: "Ağustos (Y)", category: "Gömlek", measure: 2100.18125 },
    { group: "Ağustos (Y)", category: "Pantolon", measure: 3520.59975 },
    { group: "Ağustos (Y)", category: "Ayakkabı", measure: 2536.618 },
    { group: "Eylül (SB)", category: "Erkek", measure: 4253.399 },
    { group: "Eylül (SB)", category: "Kadın", measure: 352.927 },
    { group: "Eylül (SB)", category: "Gömlek", measure: 5210.18125 },
    { group: "Eylül (SB)", category: "Pantolon", measure: 3352.59975 },
    { group: "Eylül (SB)", category: "Ayakkabı", measure: 1022.618 },
    { group: "Ekim (SB)", category: "Erkek", measure: 1252.399 },
    { group: "Ekim (SB)", category: "Kadın", measure: 2865.927 },
    { group: "Ekim (SB)", category: "Gömlek", measure: 1742.18125 },
    { group: "Ekim (SB)", category: "Pantolon", measure: 1000.59975 },
    { group: "Ekim (SB)", category: "Ayakkabı", measure: 385.618 },
    { group: "Kasım (SB)", category: "Erkek", measure: 7856.399 },
    { group: "Kasım (SB)", category: "Kadın", measure: 384.927 },
    { group: "Kasım (SB)", category: "Gömlek", measure: 759.18125 },
    { group: "Kasım (SB)", category: "Pantolon", measure: 8425.59975 },
    { group: "Kasım (SB)", category: "Ayakkabı", measure: 153.618 },
    { group: "Aralık (K)", category: "Erkek", measure: 5455.399 },
    { group: "Aralık (K)", category: "Kadın", measure: 855.927 },
    { group: "Aralık (K)", category: "Gömlek", measure: 963.18125 },
    { group: "Aralık (K)", category: "Pantolon", measure: 2225.59975 },
    { group: "Aralık (K)", category: "Ayakkabı", measure: 4755.618 },
]
    ;






var datasetLineChart = [
    { group: "All", category: 2014, measure: 10252 },
    { group: "All", category: 2015, measure: 55213 },
    { group: "All", category: 2016, measure: 26841 },
    { group: "All", category: 2017, measure: 5855 },
    { group: "All", category: 2018, measure: 54554 },
    { group: "Ocak (K)", category: 2014, measure: 19441 },
    { group: "Ocak (K)", category: 2015, measure: 25922 },
    { group: "Ocak (K)", category: 2016, measure: 9720 },
    { group: "Ocak (K)", category: 2017, measure: 6480 },
    { group: "Ocak (K)", category: 2018, measure: 19441 },
    { group: "Şubat (K)", category: 2014, measure: 22913 },
    { group: "Şubat (K)", category: 2015, measure: 7637 },
    { group: "Şubat (K)", category: 2016, measure: 23549 },
    { group: "Şubat (K)", category: 2017, measure: 1909 },
    { group: "Şubat (K)", category: 2018, measure: 7637 },
    { group: "Mart (İ)", category: 2014, measure: 1041 },
    { group: "Mart (İ)", category: 2015, measure: 2430 },
    { group: "Mart (İ)", category: 2016, measure: 15275 },
    { group: "Mart (İ)", category: 2017, measure: 4166 },
    { group: "Mart (İ)", category: 2018, measure: 11803. },
    { group: "Nisan (İ)", category: 2014, measure: 7406 },
    { group: "Nisan (İ)", category: 2015, measure: 2545 },
    { group: "Nisan (İ)", category: 2016, measure: 1620 },
    { group: "Nisan (İ)", category: 2017, measure: 8563 },
    { group: "Nisan (İ)", category: 2018, measure: 3008 },
    { group: "Mayıs (İ)", category: 2014, measure: 7637 },
    { group: "Mayıs (İ)", category: 2015, measure: 35411 },
    { group: "Mayıs (İ)", category: 2016, measure: 8332 },
    { group: "Mayıs (İ)", category: 2017, measure: 6249 },
    { group: "Mayıs (İ)", category: 2018, measure: 11803 },
    { group: "Haziran (Y)", category: 2014, measure: 3182 },
    { group: "Haziran (Y)", category: 2015, measure: 867 },
    { group: "Haziran (Y)", category: 2016, measure: 1808 },
    { group: "Haziran (Y)", category: 2017, measure: 795 },
    { group: "Haziran (Y)", category: 2018, measure: 578 },
    { group: "Temmuz (Y)", category: 2014, measure: 2227 },
    { group: "Temmuz (Y)", category: 2015, measure: 3442 },
    { group: "Temmuz (Y)", category: 2016, measure: 303 },
    { group: "Temmuz (Y)", category: 2017, measure: 2328 },
    { group: "Temmuz (Y)", category: 2018, measure: 1822 },
    { group: "Ağustos (Y)", category: 2014, measure: 2152 },
    { group: "Ağustos (Y)", category: 2015, measure: 8545 },
    { group: "Ağustos (Y)", category: 2016, measure: 2100 },
    { group: "Ağustos (Y)", category: 2017, measure: 3520 },
    { group: "Ağustos (Y)", category: 2018, measure: 2536 },
    { group: "Eylül (SB)", category: 2014, measure: 4253 },
    { group: "Eylül (SB)", category: 2015, measure: 352 },
    { group: "Eylül (SB)", category: 2016, measure: 5210 },
    { group: "Eylül (SB)", category: 2017, measure: 3352 },
    { group: "Eylül (SB)", category: 2018, measure: 1022 },
    { group: "Ekim (SB)", category: 2014, measure: 1252 },
    { group: "Ekim (SB)", category: 2015, measure: 2865 },
    { group: "Ekim (SB)", category: 2016, measure: 1742 },
    { group: "Ekim (SB)", category: 2017, measure: 1000 },
    { group: "Ekim (SB)", category: 2018, measure: 385 },
    { group: "Kasım (SB)", category: 2014, measure: 7856 },
    { group: "Kasım (SB)", category: 2015, measure: 384 },
    { group: "Kasım (SB)", category: 2016, measure: 759 },
    { group: "Kasım (SB)", category: 2017, measure: 8425 },
    { group: "Kasım (SB)", category: 2018, measure: 153 },
    { group: "Aralık (K)", category: 2014, measure: 5455 },
    { group: "Aralık (K)", category: 2015, measure: 855 },
    { group: "Aralık (K)", category: 2016, measure: 963 },
    { group: "Aralık (K)", category: 2017, measure: 2225 },
    { group: "Aralık (K)", category: 2018, measure: 4755 },
]
    ;




