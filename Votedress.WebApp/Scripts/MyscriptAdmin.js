$(document).ready(function () {




    $("#sepet").hover(function () {

        $("#sepet2").addClass("open");
    });

    $("#sepet2").mouseleave(function () {
        $('#sepet2').removeClass("open");
    });



    $("#takip_edilenler").hover(function () {

        $("#takip_edilenler2").addClass("open");
    });

    $("#takip_edilenler2").mouseleave(function () {
        $('#takip_edilenler2').removeClass("open");
    });



    $("#mesajlar").hover(function () {

        $("#mesajlar2").addClass("open");
    });

    $("#mesajlar2").mouseleave(function () {
        $('#mesajlar2').removeClass("open");
    });



    $("#bahsedildiginiz_oylamalar").hover(function () {

        $("#bahsedildiginiz_oylamalar2").addClass("open");
    });

    $("#bahsedildiginiz_oylamalar2").mouseleave(function () {
        $('#bahsedildiginiz_oylamalar2').removeClass("open");
    });


    $("#arkadaslik_istekleri").hover(function () {

        $("#arkadaslik_istekleri2").addClass("open");
    });

    $("#arkadaslik_istekleri2").mouseleave(function () {
        $('#arkadaslik_istekleri2').removeClass("open");
    });




    $("#myCarousel").carousel({ interval: false });

    // Enable Carousel Controls
    $(".left").click(function () {
        $("#myCarousel").carousel("prev");
    });
    $(".right").click(function () {
        $("#myCarousel").carousel("next");
    });


    var ac_kapa = 0;
    $("#on_gosterim_yorumlari_ac").click(function () {

        if (ac_kapa == 0) {
            $("#on_gosterim_yorumlar").hide();
            ac_kapa = 1;
        }
        else {
            $("#on_gosterim_yorumlar").show();
            ac_kapa = 0;
        }


    });





    //$("#UrunListele").click(function () {

    //    $("#Urunler").addClass("start active open");
    //    $("#AnaSayfa").removeClass("start active open");
    //    $("#loader").fadeIn();

    //    $.ajax({
    //        method: "GET",
    //        url: "/Admin/UrunleriGetir",
    //        beforeSend: function () {

    //        }
    //    }).done(function (d) {

    //        $("#icerik").html(d);
    //        $("#loader").fadeOut();

    //    }).fail(function (d) {
    //        alert("Bir hata olustu")
    //    }).always(function () {

    //    })

    //});

    $('.collapse').collapse();
    $('.panel-heading h4 a input[type=checkbox]').on('click', function (e) {
        e.stopPropagation();
    })
    $('#collapseS').on('show.bs.collapse', function (e) {
        if (!$('.panel-heading h4 a input[type=checkbox]').is(':checked')) {
            return false;
        }
    });
    $('#collapseM').on('show.bs.collapse', function (e) {
        if (!$('.panel-heading h4 a input[type=checkbox]').is(':checked')) {
            return false;
        }
    });
    $('#collapseL').on('show.bs.collapse', function (e) {
        if (!$('.panel-heading h4 a input[type=checkbox]').is(':checked')) {
            return false;
        }
    });
    $('#collapseXLL').on('show.bs.collapse', function (e) {
        if (!$('.panel-heading h4 a input[type=checkbox]').is(':checked')) {
            return false;
        }
    });
    $('#collapseXLL').on('show.bs.collapse', function (e) {
        if (!$('.panel-heading h4 a input[type=checkbox]').is(':checked')) {
            return false;
        }
    });


});


var SbedenRenkKombinasyonuAdeti = 1;
var MbedenRenkKombinasyonuAdeti = 1;
var LbedenRenkKombinasyonuAdeti = 1;
var XLbedenRenkKombinasyonuAdeti = 1;
var XXLbedenRenkKombinasyonuAdeti = 1;


var bendenRenkNolari =
    [
        { renkYeri: "renkSecenekleriS_0", sayac: 1 },
        { renkYeri: "renkSecenekleriM_0", sayac: 1 },
        { renkYeri: "renkSecenekleriL_0", sayac: 1 },
        { renkYeri: "renkSecenekleriXL_0", sayac: 1 },
        { renkYeri: "renkSecenekleriXXL_0", sayac: 1 }
    ];


function renkEkle(nereyeEklencek, urunIcerigiIndex, bedenRenkleriIndex) {

    var colorInputHtml = "";

    for (var i = 0; i < bendenRenkNolari.length; i++) {

        if (bendenRenkNolari[i].renkYeri == nereyeEklencek) {
            colorInputHtml = '<input type="color" value="#ffffff" name="urun_bilgileri.urunIcerigi[' + urunIcerigiIndex + '].BedenRenkleri[' + bedenRenkleriIndex + '].renkleri[' + bendenRenkNolari[i].sayac + ']">';
            bendenRenkNolari[i].sayac++;
            $("#" + nereyeEklencek).append(colorInputHtml);
            return;

        }

    }



}

function renkKombinasyonuEkle(nereyeEklenecek, urunIcerigiIndex) {

    var renkKombinasyonlariHtml = ""
    var renkSecenekleri = "";

    if (nereyeEklenecek == "SrenkKombinasyonlari") {

        renkSecenekleriAraya = "'renkSecenekleriS_" + SbedenRenkKombinasyonuAdeti + "'";
        renkSecenekleri = "renkSecenekleriS_" + SbedenRenkKombinasyonuAdeti;

        var kacinci = SbedenRenkKombinasyonuAdeti + 1;

        var resimYerleriHtml = "";

        for (var i = 0; i < 3; i++) {

            resimYerleriHtml = resimYerleriHtml +
                '<div class="col-md-12">' +
                '<div class="fileinput fileinput-new" data-provides="fileinput">' +
                '<div class="fileinput-new thumbnail" style="width: 200px; height: 150px;">' +
                ' <img src="http://www.placehold.it/200x150/EFEFEF/AAAAAA&amp;text=no+image" alt="" />' +
                '</div>' +
                '<div class="fileinput-preview fileinput-exists thumbnail" style="max-width: 200px; max-height: 150px;"> </div>' +
                ' <div>' +
                '<span class="btn default btn-file">' +
                '  <span class="fileinput-new"> Select image </span>' +
                '  <span class="fileinput-exists"> Change </span>' +
                '  <input type="file" name="urun_bilgileri.urunIcerigi[0].BedenRenkleri[' + SbedenRenkKombinasyonuAdeti + '].urunResimleri[' + i + ']">' +
                ' </span>' +
                '<a href="javascript:;" class="btn red fileinput-exists" data-dismiss="fileinput"> Remove </a>' +
                '  </div>' +
                ' </div > ' +
                '  </div > ';

        }


        renkKombinasyonlariHtml =
            '<div class="col-md-4" style="height:850px;" >' +
            '<h3 style="text-align:center;">' + kacinci + '. Renk Kombinasyonu</h3>' +
            '<a onclick="renkEkle(' + renkSecenekleriAraya + ',0,' + SbedenRenkKombinasyonuAdeti + ')">' +
            '<h1 style="text-align:center;margin-bottom:0px"><i class="fa fa-plus" style="font-size:25px;"></i></h1>' +
            '<h4 style="text-align:center;margin-top:0px">Renk Ekle</h4>' +
            '</a>' +
            '<div class="row" id="' + renkSecenekleri + '">' +
            '<input type="color" value="#ff0000" name="urun_bilgileri.urunIcerigi[0].BedenRenkleri[' + SbedenRenkKombinasyonuAdeti + '].renkleri[0]">' +
            '</div>' +
            '<div class="row">' +
            '<h6>Stok Adeti</h6>' +
            '<input name="urun_bilgileri.urunIcerigi[0].BedenRenkleri[' + SbedenRenkKombinasyonuAdeti + '].stokAdeti">' +
            '</div>' +
            '<div class="row">' +
            '<h4 style="font-size:15px;padding-left:15px">Ürün Galerisi</h4>' +
            resimYerleriHtml +
            '</div > ';

        SbedenRenkKombinasyonuAdeti++;
    }
    else if (nereyeEklenecek == "MrenkKombinasyonlari") {

        renkSecenekleriAraya = "'renkSecenekleriM_" + MbedenRenkKombinasyonuAdeti + "'";
        renkSecenekleri = "renkSecenekleriM_" + MbedenRenkKombinasyonuAdeti;

        var kacinci = MbedenRenkKombinasyonuAdeti + 1;

        var resimYerleriHtml = "";

        for (var i = 0; i < 3; i++) {

            resimYerleriHtml = resimYerleriHtml +
                '<div class="col-md-12">' +
                '<div class="fileinput fileinput-new" data-provides="fileinput">' +
                '<div class="fileinput-new thumbnail" style="width: 200px; height: 150px;">' +
                ' <img src="http://www.placehold.it/200x150/EFEFEF/AAAAAA&amp;text=no+image" alt="" />' +
                '</div>' +
                '<div class="fileinput-preview fileinput-exists thumbnail" style="max-width: 200px; max-height: 150px;"> </div>' +
                ' <div>' +
                '<span class="btn default btn-file">' +
                '  <span class="fileinput-new"> Select image </span>' +
                '  <span class="fileinput-exists"> Change </span>' +
                '  <input type="file" name="urun_bilgileri.urunIcerigi[1].BedenRenkleri[' + MbedenRenkKombinasyonuAdeti + '].urunResimleri[' + i + ']">' +
                ' </span>' +
                '<a href="javascript:;" class="btn red fileinput-exists" data-dismiss="fileinput"> Remove </a>' +
                '  </div>' +
                ' </div > ' +
                '  </div > ';

        }

        renkKombinasyonlariHtml =
            '<div class="col-md-4" style="height:850px;" >' +
            '<h3 style="text-align:center;">' + kacinci + '. Renk Kombinasyonu</h3>' +
            '<a onclick="renkEkle(' + renkSecenekleriAraya + ',1,' + MbedenRenkKombinasyonuAdeti + ')">' +
            '<h1 style="text-align:center;margin-bottom:0px"><i class="fa fa-plus" style="font-size:25px;"></i></h1>' +
            '<h4 style="text-align:center;margin-top:0px">Renk Ekle</h4>' +
            '</a>' +
            '<div class="row" id="' + renkSecenekleri + '">' +
            '<input type="color" value="#ff0000" name="urun_bilgileri.urunIcerigi[1].BedenRenkleri[' + MbedenRenkKombinasyonuAdeti + '].renkleri[0]">' +
            '</div>' +
            '<div class="row">' +
            '<h6>Stok Adeti</h6>' +
            '<input name="urun_bilgileri.urunIcerigi[1].BedenRenkleri[' + MbedenRenkKombinasyonuAdeti + '].stokAdeti">' +
            '</div>' +
            '<div class="row">' +
            '<h4 style="font-size:15px;padding-left:15px">Ürün Galerisi</h4>' +
            resimYerleriHtml +
            '</div > ';


        MbedenRenkKombinasyonuAdeti++;

    }
    else if (nereyeEklenecek == "LrenkKombinasyonlari") {


        renkSecenekleriAraya = "'renkSecenekleriL_" + LbedenRenkKombinasyonuAdeti + "'";
        renkSecenekleri = "renkSecenekleriL_" + LbedenRenkKombinasyonuAdeti;

        var kacinci = LbedenRenkKombinasyonuAdeti + 1;
        var resimYerleriHtml = "";


        for (var i = 0; i < 3; i++) {

            resimYerleriHtml = resimYerleriHtml +
                '<div class="col-md-12">' +
                '<div class="fileinput fileinput-new" data-provides="fileinput">' +
                '<div class="fileinput-new thumbnail" style="width: 200px; height: 150px;">' +
                ' <img src="http://www.placehold.it/200x150/EFEFEF/AAAAAA&amp;text=no+image" alt="" />' +
                '</div>' +
                '<div class="fileinput-preview fileinput-exists thumbnail" style="max-width: 200px; max-height: 150px;"> </div>' +
                ' <div>' +
                '<span class="btn default btn-file">' +
                '  <span class="fileinput-new"> Select image </span>' +
                '  <span class="fileinput-exists"> Change </span>' +
                '  <input type="file" name="urun_bilgileri.urunIcerigi[2].BedenRenkleri[' + LbedenRenkKombinasyonuAdeti + '].urunResimleri[' + i + ']">' +
                ' </span>' +
                '<a href="javascript:;" class="btn red fileinput-exists" data-dismiss="fileinput"> Remove </a>' +
                '  </div>' +
                ' </div > ' +
                '  </div > ';

        }

        renkKombinasyonlariHtml =
            '<div class="col-md-4" style="height:850px;" >' +
            '<h3 style="text-align:center;">' + kacinci + '. Renk Kombinasyonu</h3>' +
            '<a onclick="renkEkle(' + renkSecenekleriAraya + ',2,' + LbedenRenkKombinasyonuAdeti + ')">' +
            '<h1 style="text-align:center;margin-bottom:0px"><i class="fa fa-plus" style="font-size:25px;"></i></h1>' +
            '<h4 style="text-align:center;margin-top:0px">Renk Ekle</h4>' +
            '</a>' +
            '<div class="row" id="' + renkSecenekleri + '">' +
            '<input type="color" value="#ff0000" name="urun_bilgileri.urunIcerigi[2].BedenRenkleri[' + LbedenRenkKombinasyonuAdeti + '].renkleri[0]">' +
            '</div>' +
            '<div class="row">' +
            '<h6>Stok Adeti</h6>' +
            '<input name="urun_bilgileri.urunIcerigi[2].BedenRenkleri[' + LbedenRenkKombinasyonuAdeti + '].stokAdeti">' +
            '</div>' +
            '<div class="row">' +
            '<h4 style="font-size:15px;padding-left:15px">Ürün Galerisi</h4>' +
            resimYerleriHtml +
            '</div > ';
        LbedenRenkKombinasyonuAdeti++;
    }
    else if (nereyeEklenecek == "XLrenkKombinasyonlari") {
        renkSecenekleriAraya = "'renkSecenekleriXL_" + XLbedenRenkKombinasyonuAdeti + "'";
        renkSecenekleri = "renkSecenekleriXL_" + XLbedenRenkKombinasyonuAdeti;

        var kacinci = XLbedenRenkKombinasyonuAdeti + 1;
        var resimYerleriHtml = "";
        for (var i = 0; i < 3; i++) {

            resimYerleriHtml = resimYerleriHtml +
                '<div class="col-md-12">' +
                '<div class="fileinput fileinput-new" data-provides="fileinput">' +
                '<div class="fileinput-new thumbnail" style="width: 200px; height: 150px;">' +
                ' <img src="http://www.placehold.it/200x150/EFEFEF/AAAAAA&amp;text=no+image" alt="" />' +
                '</div>' +
                '<div class="fileinput-preview fileinput-exists thumbnail" style="max-width: 200px; max-height: 150px;"> </div>' +
                ' <div>' +
                '<span class="btn default btn-file">' +
                '  <span class="fileinput-new"> Select image </span>' +
                '  <span class="fileinput-exists"> Change </span>' +
                '  <input type="file" name="urun_bilgileri.urunIcerigi[3].BedenRenkleri[' + XLbedenRenkKombinasyonuAdeti + '].urunResimleri[' + i + ']">' +
                ' </span>' +
                '<a href="javascript:;" class="btn red fileinput-exists" data-dismiss="fileinput"> Remove </a>' +
                '  </div>' +
                ' </div > ' +
                '  </div > ';

        }

        renkKombinasyonlariHtml =
            '<div class="col-md-4" style="height:850px;" >' +
            '<h3 style="text-align:center;">' + kacinci + '. Renk Kombinasyonu</h3>' +
            '<a onclick="renkEkle(' + renkSecenekleriAraya + ',3,' + XLbedenRenkKombinasyonuAdeti + ')">' +
            '<h1 style="text-align:center;margin-bottom:0px"><i class="fa fa-plus" style="font-size:25px;"></i></h1>' +
            '<h4 style="text-align:center;margin-top:0px">Renk Ekle</h4>' +
            '</a>' +
            '<div class="row" id="' + renkSecenekleri + '">' +
            '<input type="color" value="#ff0000" name="urun_bilgileri.urunIcerigi[3].BedenRenkleri[' + XLbedenRenkKombinasyonuAdeti + '].renkleri[0]">' +
            '</div>' +
            '<div class="row">' +
            '<h6>Stok Adeti</h6>' +
            '<input name="urun_bilgileri.urunIcerigi[3].BedenRenkleri[' + XLbedenRenkKombinasyonuAdeti + '].stokAdeti">' +
            '</div>' +
            '<div class="row">' +
            '<h4 style="font-size:15px;padding-left:15px">Ürün Galerisi</h4>' +
            resimYerleriHtml +
            '</div > ';
        XLbedenRenkKombinasyonuAdeti++;
    }
    else if (nereyeEklenecek == "XXLrenkKombinasyonlari") {
        renkSecenekleriAraya = "'renkSecenekleriXXL_" + XXLbedenRenkKombinasyonuAdeti + "'";
        renkSecenekleri = "renkSecenekleriXXL_" + XXLbedenRenkKombinasyonuAdeti;

        var kacinci = XXLbedenRenkKombinasyonuAdeti + 1;
        var resimYerleriHtml = "";

        for (var i = 0; i < 3; i++) {

            resimYerleriHtml = resimYerleriHtml +
                '<div class="col-md-12">' +
                '<div class="fileinput fileinput-new" data-provides="fileinput">' +
                '<div class="fileinput-new thumbnail" style="width: 200px; height: 150px;">' +
                ' <img src="http://www.placehold.it/200x150/EFEFEF/AAAAAA&amp;text=no+image" alt="" />' +
                '</div>' +
                '<div class="fileinput-preview fileinput-exists thumbnail" style="max-width: 200px; max-height: 150px;"> </div>' +
                ' <div>' +
                '<span class="btn default btn-file">' +
                '  <span class="fileinput-new"> Select image </span>' +
                '  <span class="fileinput-exists"> Change </span>' +
                '  <input type="file" name="urun_bilgileri.urunIcerigi[4].BedenRenkleri[' + XXLbedenRenkKombinasyonuAdeti + '].urunResimleri[' + i + ']">' +
                ' </span>' +
                '<a href="javascript:;" class="btn red fileinput-exists" data-dismiss="fileinput"> Remove </a>' +
                '  </div>' +
                ' </div > ' +
                '  </div > ';

        }

        renkKombinasyonlariHtml =
            '<div class="col-md-4" style="height:850px;" >' +
            '<h3 style="text-align:center;">' + kacinci + '. Renk Kombinasyonu</h3>' +
            '<a onclick="renkEkle(' + renkSecenekleriAraya + ',4,' + XXLbedenRenkKombinasyonuAdeti + ')">' +
            '<h1 style="text-align:center;margin-bottom:0px"><i class="fa fa-plus" style="font-size:25px;"></i></h1>' +
            '<h4 style="text-align:center;margin-top:0px">Renk Ekle</h4>' +
            '</a>' +
            '<div class="row" id="' + renkSecenekleri + '">' +
            '<input type="color" value="#ff0000" name="urun_bilgileri.urunIcerigi[4].BedenRenkleri[' + XXLbedenRenkKombinasyonuAdeti + '].renkleri[0]">' +
            '</div>' +
            '<div class="row">' +
            '<h6>Stok Adeti</h6>' +
            '<input name="urun_bilgileri.urunIcerigi[4].BedenRenkleri[' + XXLbedenRenkKombinasyonuAdeti + '].stokAdeti">' +
            '</div>' +
            '<div class="row">' +
            '<h4 style="font-size:15px;padding-left:15px">Ürün Galerisi</h4>' +
            resimYerleriHtml +
            '</div > ';
        XXLbedenRenkKombinasyonuAdeti++;
    }

    $("#" + nereyeEklenecek).append(renkKombinasyonlariHtml);

    bendenRenkNolari.push({ renkYeri: renkSecenekleri, sayac: 1 });

}


function kategoriEkle() {

    var kategoriAdi = document.getElementsByName("EkleKategoriAdi")[0].value;
    var kategoriAciklamasi = document.getElementsByName("Aciklama")[0].value;

    Veri = new Object();

    Veri.KategoriAdi = kategoriAdi;
    Veri.Aciklama = kategoriAciklamasi;

    $.ajax({
        method: "POST",
        url: "/Admin/KategoriEkle",
        data: { kategori: Veri },
        beforeSend: function () {


        }
    }).done(function (d) {

        if (d.Errors.length != 0) {
            for (var i = 0; i < d.Errors.length; i++) {
                alert(d.Errors[i].Message);
            }
        }
        else {
            alert("Kayit Başarılı");
            console.log(d);
            $("#KategoriId").append('<option value="' + d.kategori_id + '">' + d.Kategori_adi + '</option>');


            $('#basic').modal('hide');
        }


    }).fail(function (d) {
        alert("Bir hata olustu")
    }).always(function () {

    })

}