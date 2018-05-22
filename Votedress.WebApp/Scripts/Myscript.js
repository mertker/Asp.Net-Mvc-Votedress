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

   
    $('.gallery-img').Am2_SimpleSlider();
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

    var kontrol = 0;
    var silinecek;
   
    $(document).on("click", '.mert', function () {

        if (this.files[0] == null) {
            silinecek = $(this).attr("data-id");
            kontrol = 0;
        }
        else {
            rengidegistir=silinecek;
            silinecek = $(this).attr("data-id");
            kontrol = 1;
        }

    })

    var file;
    $(document).on("change", '.mert', function () {

        file = this.files[0];
        var readImg = new FileReader();


        if (file && file.type.match('image/*')) {
            readImg.readAsDataURL(file);
        } else {

            $("#kaldigim_yer_" + silinecek).remove();
            karekodlar[silinecek] = null;
            console.log(karekodlar);
            $("#urun_" + silinecek).remove();    
        }

        readImg.onload = function (e) {

            if (kontrol != 1) {
                $("#resimler").append('<div id="kaldigim_yer_' + silinecek + '" class="col-md-3" ><div id="sil_' + silinecek + '"><img src="' + e.target.result + '" alt id="image_' + silinecek + '" height="20" width="20" /> <canvas id="canvas_' + silinecek + '"  ></canvas><div><p><strong>Döndür: </strong>  <input type="radio" id="resetImage_' + silinecek + '" name="group_' + silinecek + '"  checked value="elleme">Varsayılan <br> <input style="margin-left: 60px;" type="radio" id="rotate90_' + silinecek + '" name="group_' + silinecek + '" value="90">90° <br><input style="margin-left: 60px;" type="radio" id="rotate180_' + silinecek + '" name="group_' + silinecek + '"  value="180">180°<br><input style="margin-left: 60px;" type="radio" id="rotate270_' + silinecek + '" name="group_' + silinecek + '"  value="270">270° </p></div><div class="row" ><div class="col-md-10" id="urunler"><div class="col-md-2"><p style="text-aling:center;">ÜRÜN</p><a onclick="load(' + silinecek + ');"><i  id="barkod_okundumu_' + silinecek + '" class="fa fa-home" style="font-size:60px;" aria-hidden="true" data-durum="okunmadi"></i></a></div></div><div class="col-md-2" style="margin-top:23%"><i class="fa fa-plus" aria-hidden="true" style="font-size:30px" id="urun_ekle" data-id="' + silinecek + '"></i></div></div></div><div class="row"  style="padding-left:13%"><label>Ürün Açıklaması</label><textarea name="urun_aciklamasi_'+silinecek+'"></textarea></div>');
                window.setTimeout(function () { deneme(silinecek); }, 0);
            }
            else {
                $("#sil_" + silinecek).remove();
                $("#kaldigim_yer_" + silinecek).append('<div id="sil_' + silinecek + '"><img src="' + e.target.result + '" alt id="image_' + silinecek + '" height="20" width="20" /> <canvas id="canvas_' + silinecek + '"  ></canvas><div><p><strong>Döndür: </strong>  <input type="radio" id="resetImage_' + silinecek + '" name="group_' + silinecek + '" checked value="elleme">Varsayılan <br> <input style="margin-left: 60px;" type="radio" id="rotate90_' + silinecek + '" name="group_' + silinecek + '" value="90">90° <br><input style="margin-left: 60px;" type="radio" id="rotate180_' + silinecek + '" name="group_' + silinecek + '"  value="180">180°<br><input style="margin-left: 60px;" type="radio" id="rotate270_' + silinecek + '" name="group_' + silinecek + '"  value="270">270° </p></div><div class="row" id="urunler"><div class="col-md-10" id="urunler"><p style="text-aling:center;">ÜRÜN</p><a onclick="load(' + silinecek + ');"><i id="barkod_okundumu_' + silinecek + '" class="fa fa-home" style="font-size:60px" aria-hidden="true" data-durum"okunmadi"></i></a></div><div class="col-md-2" style="margin-top:23%"><i class="fa fa-plus" aria-hidden="true" style="font-size:30px"></i></div></div></div><div class="row" style="padding-left=13%;" ><label>Ürün Açıklaması</label><textarea name="urun_aciklamasi_' + silinecek + '"></textarea></div>');
                window.setTimeout(function () { deneme(silinecek); }, 0);
            }
        }

    });


  

   
    
    $(document).on("click", '#urun_ekle', function () {


        alert("Şuan her resim için bir ürün eklenebiliyor");
        //var data= $(this).attr("data-id");

        //$("#urunler").append('<div class="col-md-2"><p style="text-aling:center;">ÜRÜN</p><a onclick="load(' + data + ');"><i  id="barkod_okundumu_' + silinecek + '" class="fa fa-home" style="font-size:60px;" aria-hidden="true" data-durum="okunmadi"></i></a></div>');

    });
});

function deneme(k) {

    var img = null, canvas = null;

    $(document).ready(function () {
        //  Initialize image and canvas

        img = document.getElementById(k + '_Image');
        canvas = document.getElementById(k + '_Canvas');

        if (!canvas || !canvas.getContext) {
            canvas.parentNode.removeChild(canvas);
        } else {
            img.style.position = 'absolute';
            img.style.visibility = 'hidden';
        }

        rotateImage(0);

        //  Handle clicks for control links
        $('#resetImage_' + k).click(function () { rotateImage(0); });
        $('#rotate90_' + k).click(function () { rotateImage(90); });
        $('#rotate180_' + k).click(function () { rotateImage(180); });
        $('#rotate270_' + k).click(function () { rotateImage(270); });
    });

    function rotateImage(degree) {

        if (canvas) {

            var cContext = canvas.getContext('2d');
            var newWidth = 300;
            var newHeight = 300;

            var cw = newWidth, ch = newHeight, cx = 0, cy = 0;
            //   Calculate new canvas size and x/y coorditates for image
            switch (degree) {
                case 90:
                    cw = newHeight;
                    ch = newWidth;
                    cy = newHeight * (-1);
                    break;
                case 180:
                    cx = newWidth * (-1);
                    cy = newHeight * (-1);
                    break;
                case 270:
                    cw = newHeight;
                    ch = newWidth;
                    cx = newWidth * (-1);
                    break;
            }

            //  Rotate image            
            canvas.setAttribute('width', newWidth);
            canvas.setAttribute('height', newHeight);
            cContext.rotate(degree * Math.PI / 180);

            cContext.drawImage(img, cx, cy, newWidth, newHeight);


        } else {
            //  Use DXImageTransform.Microsoft.BasicImage filter for MSIE
            switch (degree) {
                case 0: img.style.filter = 'progid:DXImageTransform.Microsoft.BasicImage(rotation=0)'; break;
                case 90: img.style.filter = 'progid:DXImageTransform.Microsoft.BasicImage(rotation=1)'; break;
                case 180: img.style.filter = 'progid:DXImageTransform.Microsoft.BasicImage(rotation=2)'; break;
                case 270: img.style.filter = 'progid:DXImageTransform.Microsoft.BasicImage(rotation=3)'; break;
            }
        }
    }

}


var kacinci = 2;
function res_yuk_alani() {

    if (kacinci <= 4) {
        var div = document.createElement("DIV");
        div.setAttribute("class", "row");
        document.getElementById("yukleme_alani").appendChild(div);

        var div2 = document.createElement("DIV");
        div2.setAttribute("class", "col-md-2");
        div.appendChild(div2);

        var div3 = document.createElement("DIV");
        div3.setAttribute("class", "col-md-8");
        div.appendChild(div3);

        var div4 = document.createElement("DIV");
        div4.setAttribute("class", "col-md-2");
        div.appendChild(div4);


        var div5 = document.createElement("DIV");
        div5.setAttribute("class", "row");
        div3.appendChild(div5);

        var div6 = document.createElement("DIV");
        div6.setAttribute("class", "col-md-2");
        div5.appendChild(div6);

        var div7 = document.createElement("DIV");
        div7.setAttribute("class", "col-md-1");
        div5.appendChild(div7);

        var div8 = document.createElement("DIV");
        div8.setAttribute("class", "col-md-2");
        div5.appendChild(div8);

        var div9 = document.createElement("DIV");
        div9.setAttribute("class", "col-md-7");
        div5.appendChild(div9);

        var p = document.createElement("P");
        var sayi = document.createTextNode(kacinci + ".Kiyafet");

        div8.appendChild(p);
        p.appendChild(sayi);

        var input = document.createElement("input");
        input.setAttribute("class", "mert")
        input.setAttribute("data-id", kacinci - 1)
        input.setAttribute("type", "file");
        input.setAttribute("name", "resim-" + kacinci + "");
        input.setAttribute("accept", "image/*");

        div9.appendChild(input);

        if (kacinci == 4) {
            $("#yer_ac").remove();
        }

        kacinci = kacinci + 1;
    }
    else {
        alert("4 Oylama hakkınız doldu")
    }



}
