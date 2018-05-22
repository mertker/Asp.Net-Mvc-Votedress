

$(function () {

    var chat = $.connection.messanger;
    chat.client.deneme = function (sonuc) {

        alert(sonuc);
    }


    chat.client.OnlineOlunamadi = function () {
        alert("online olunamadı gardaş hakkını helal et");
    }

    chat.client.ZatenOnlineydiniz = function () {

    }

    chat.client.BirisiOnlineOldu = function (kullanici_id) {

        var name = "#arkadas_" + kullanici_id
        var name2 = "arkadas_" + kullanici_id

        var cln = $(name).clone();

        $('[id]').each(function () {

            if (this.id == name2) {
                $(this).remove();
            }
        });

        $("#cevrim_iciDiv ul:first").append(cln);
    }

    chat.client.BirisiOfflineOldu = function (kullanici_id) {

        var name = "#arkadas_" + kullanici_id
        var name2 = "arkadas_" + kullanici_id

        var cln = $(name).clone();

        $('[id]').each(function () {

            if (this.id == name2) {
                $(this).remove();
            }
        });

        $("#cevrim_disiDiv ul:first").append(cln);
    }

    chat.client.Engelli = function () {
        $.notify("Malesef mesajınız gönderilemedi. Mesajlaşmada engel var", "error");
    }

    chat.client.MesajGonderilemedi = function () {
        alert("MesajGonderilemedi ");
    }

    chat.client.sendMessage_karsiya = function (gonderen_id, mesaj, gonderme_tarihi, adSoyad, profilResmi, mesaj_id) {

        var kontrol = 0;
        var kontrol2 = 0;
        $('[id]').each(function () {

            if (this.id == "messageArea" && $(this).attr("data-id") == gonderen_id) {
                kontrol = 1;

                chat.server.mesajGoruldu(mesaj_id);

                $(this).append('<div class="post_in2"><img class="avatar2_in" alt="" src="' + profilResmi + '"> <div class="message2_in">  <span class="arrow2_in"></span> <a href="javascript:;" class="name2_in">' + adSoyad + '</a><span class="datetime2_in" style="margin-right:5px;">' + gonderme_tarihi + '</span><span class="message_body_in">' + mesaj + '</span> </div></div> ')

                var oylamaScroll = $("#messageArea");
                var scrollPosition = oylamaScroll.scrollTop();
                var scrollTo_int = oylamaScroll.prop('scrollHeight');
                var degisken = scrollTo_int - scrollPosition;
                if (degisken <= 880) {
                    $("#messageArea").scrollTop(scrollPosition + 1000);
                }

            }


        });

        if (kontrol == 0) {
            var name = "gorulmemis_mesaj_" + gonderen_id;

            $('[id]').each(function () {

                if (this.id == name) {
                    $(this).remove();

                    kontrol2 = 1;

                }
            });


            var kirpilmis_mesaj = "";

            if (mesaj.Length > 30) {
                kirpilmis_mesaj = mesaj.substring(0, 30);
            }
            else {
                kirpilmis_mesaj = mesaj;
            }

            $('#gorulmemis_mesajlar').append('<li id="gorulmemis_mesaj_' + gonderen_id + '" data-id="' + gonderen_id + '"> <a href="#"> <span class="photo"><img src="' + profilResmi + '" class="img-circle" alt=""> </span>  <span class="subject"> <span class="from">' + adSoyad + '</span> </span><span class="time" style="font-size:11px">' + gonderme_tarihi + '</span><span class="message" style="font-size:15px">' + kirpilmis_mesaj + '</span></a></li>');




            if (kontrol2 == 0) {
                var gorulmemis_mesaj_sayisi = $("#gorulmemis_mesajlar1").text();
                var x = parseInt(gorulmemis_mesaj_sayisi) + 1;
                $("#gorulmemis_mesajlar1").text(x.toString());

                var gorulmemis_mesaj_sayisi2 = $("#gorulmemis_mesajlar2").text();
                var x2 = parseInt(gorulmemis_mesaj_sayisi2) + 1;
                $("#gorulmemis_mesajlar2").text(x2.toString());
            }


            var kontrol12 = 0;
            var kontrol11 = 0;

            $('[id]').each(function () {

                if (this.id == "whisper_" + gonderen_id) {
                    kontrol12 = 1;
                }

                if (this.id == "arkadas_" + gonderen_id) {
                    kontrol11 = 1;
                }
            });

            if (kontrol12 == 0 && kontrol11 == 0) {
                $("#fisildamalar ul:first").append('<li class="media" id="whisper_' + gonderen_id + '"  data-event="mesaj_yaz" data-id="' + gonderen_id + '"><img class= "img_media_object" src = "' + profilResmi + '" alt = "..." > <div class="media-body" style="padding-top:9px;position:relative;" data-event="mesaj_yaz" data-id="' + gonderen_id + '"> <a href="javascript:;" class="name2_in" style="font-size:20px" dropdown-toggle"="" data-toggle="dropdown" data-hover="dropdown" data-delay="1000" data-close-others="true" aria-expanded="true">' + adSoyad + '</a> <span class="badge badge-success" style="margin-left:200px;margin-top:-40px" id="gorulmemis_mesaj_sayisi_' + gonderen_id + '">1</span> <ul class="dropdown-menu" role="menu" style="top:59%;margin-left:0px"><li><a href="#" data-event="mesaj_yaz" data-id="' + gonderen_id + '"><i class="icon-bell"></i> Fısılda</a></li><li><a href="#" data-event="arkadas_ekle" data-id="' + gonderen_id + '"><i class="icon-user" ></i> Arkadaş Ekle</a></li> <li><a href="#" data-event="engelle" data-id="' + gonderen_id + '"><i class="icon-shield"></i> Engelle</a></li><li><a href="#" data-event="fisiltiyi_sil" data-id="' + gonderen_id + '"> <i class="icon-shield"></i> Fısıltıyı Sil</a> </li><li><a href="#" data-event="profili_gor" data-id="' + gonderen_id + '"><i class="icon-bag"></i> Profili Gör</a></li> </ul></div></li >');
                $.ajax({

                    method: "POST",
                    url: "/OzelSohbet/FisiltiyiAktiflestir",
                    data: { fisiltiSahibiId: gonderen_id },
                    beforeSend: function () {


                    }
                }).done(function (d) {


                }).fail(function (d) {
                    alert("Bir hata olustu")
                }).always(function () {

                });


            }
            else {
                var name2 = "#gorulmemis_mesaj_sayisi_" + gonderen_id;
                var gorulmemis_mesaj_sayisi3 = $(name2).text();
                var x3 = parseInt(gorulmemis_mesaj_sayisi3) + 1;
                $(name2).text(x3.toString());
            }




        }

    }

    chat.client.sendMessage_kendime = function (gonderen_id, mesaj, gonderme_tarihi, adSoyad, profilResmi) {

        $('#messageArea').append('<div class="post_out2"><img class="avatar2_out" alt="" src="' + profilResmi + '"> <div class="message2_out">  <span class="arrow2_out"></span><span class="datetime2_out" style="margin-right:5px;">' + gonderme_tarihi + '</span> <a href="javascript:;" class="name2_out">' + adSoyad + '</a><span class="message_body_out">' + mesaj + '</span> </div></div> ')
        var oylamaScroll = $("#messageArea");
        var scrollPosition = oylamaScroll.scrollTop();
        var scrollTo_int = oylamaScroll.prop('scrollHeight');
        var degisken = scrollTo_int - scrollPosition;
        if (degisken <= 880) {
            $("#messageArea").scrollTop(scrollPosition + 1000);
        }

    }

    chat.client.ArkadaslikdanCikarildiniz = function (cikaranId) {

        if ($("#arkadas_" + cikaranId) != undefined) {
            $("#arkadas_" + cikaranId).remove();
        }
        if ($("#arkadas2_" + cikaranId) != undefined) {
            $("#arkadas2_" + cikaranId).remove();
        }
    }

    chat.client.ArkadaslikIsteginizKabulEdildi = function (kabulEden) {



        if ($("#whisper_" + kabulEden.UserId) != undefined) {
            $("#whisper_" + kabulEden.UserId).remove();
        }


        $("#cevrim_iciDiv ul").append('<li class="media" id="arkadas_' + kabulEden.UserId + '"  data-event="mesaj_yaz" data-id="' + kabulEden.UserId + '"><img class= "img_media_object" src = "' + kabulEden.UserProfileImage + '" alt = "..." > <div class="media-body" style="padding-top:9px;position:relative;" data-event="mesaj_yaz" data-id="' + kabulEden.UserId + '"> <a href="javascript:;" class="name2_in" style="font-size:20px" dropdown-toggle"="" data-toggle="dropdown" data-hover="dropdown" data-delay="1000" data-close-others="true" aria-expanded="true">' + kabulEden.UserNameSurname + '</a> <span class="badge badge-success" style="margin-left:200px;margin-top:-40px" id="gorulmemis_mesaj_sayisi_' + kabulEden.UserId + '">0</span> <ul class="dropdown-menu" role="menu" style="top:59%;margin-left:0px"><li><a href="#" data-event="mesaj_yaz" data-id="' + kabulEden.UserId + '"><i class="icon-bell"></i> Mesaj Yaz</a></li><li><a href="#" data-event="profili_gor" data-id="' + kabulEden.UserId + '"><i class="icon-bag"></i> Profili Gör</a></li> </ul></div></li >');

    }


    $(document).on("click", ".media", function (e) {

        var neye_tiklandi = $(e.target).attr("data-event");
        var bilgi = $(e.target).attr("data-id");

        var buton = $("#ozelMesaj_gonder");
        buton.attr("data-id", bilgi);

        if (neye_tiklandi == "mesaj_yaz") {
            $.ajax({

                method: "POST",
                url: "/OzelSohbet/MesajlariGetir",
                data: { alanId: bilgi },
                beforeSend: function () {

                    $("#quick_sidebar_tab_1").addClass("page-quick-sidebar-content-item-shown");

                    $("#row1").removeClass("ozel_sohbet_kaydir_saga");
                    $("#row2").removeClass("ozel_sohbet_kaydir_saga");

                    $("#row1").addClass("ozel_sohbet_kaydir_sola");
                    $("#row2").addClass("ozel_sohbet_kaydir_sola");




                }
            }).done(function (d) {

                $("#messageArea").empty();
                $("#messageArea").attr("data-id", bilgi)

                var kontrol = 0;

                $('[id]').each(function () {

                    if (this.id == "gorulmemis_mesaj_" + bilgi) {
                        kontrol = 1;
                        $(this).remove();
                    }
                });

                if (kontrol == 1) {
                    var gorulmemis_mesaj_sayisi = $("#gorulmemis_mesajlar1").text();
                    var x = parseInt(gorulmemis_mesaj_sayisi) - 1;
                    $("#gorulmemis_mesajlar1").text(x.toString());

                    var gorulmemis_mesaj_sayisi2 = $("#gorulmemis_mesajlar2").text();
                    var x2 = parseInt(gorulmemis_mesaj_sayisi2) - 1;
                    $("#gorulmemis_mesajlar2").text(x2.toString());

                    $("#sohbetAlani #gorulmemis_mesaj_sayisi_" + bilgi).text("0");


                }

                for (var i = 0; i < d.length; i++) {
                    if (d[i].Sahip == true) {
                        $("#messageArea").append('<div class="post_out2"><img class="avatar2_out" alt="" src="' + d[i].ProfilImage + '">    <div class="message2_out"> <span class="arrow2_out"></span><span class="datetime2_out" style="margin-right:5px;">' + d[i].GonderilmeTarihi + '</span><a href="javascript:;" class="name2_out">' + d[i].adSoyad + '</a><span class="message_body_out"> ' + d[i].Message + ' </span> </div></div>');

                    }
                    else {
                        $("#messageArea").append('<div class="post_in2"><img class="avatar2_in" alt="" src="' + d[i].ProfilImage + '">    <div class="message2_in"> <span class="arrow2_in"></span><a href="javascript:;" class="name2_in">' + d[i].adSoyad + '</a><span class="datetime2_in" style="margin-right:5px;">' + d[i].GonderilmeTarihi + '</span><span class="message_body_in"> ' + d[i].Message + ' </span> </div></div>');
                    }

                }
                var oylamaScroll = $("#messageArea");
                var scrollTo_int = oylamaScroll.prop('scrollHeight');

                oylamaScroll.scrollTop(scrollTo_int + 1000);

                $("#ozelMesaj_input").focus();


            }).fail(function (d) {
                alert("Bir hata olustu")
            }).always(function () {

            })
        }
        else if (neye_tiklandi == "fisiltiyi_sil") {

            $.ajax({

                method: "POST",
                url: "/OzelSohbet/FisiltiSil",
                data: { fisiltiSahibiId: bilgi },
                beforeSend: function () {


                }
            }).done(function (d) {

                $("#whisper_" + bilgi).remove();
                $("#messageArea").attr("data-id", "");
                $.notify("Fısıltı Başarıyla silindi", "success");


            }).fail(function (d) {
                alert("Bir hata olustu")
            }).always(function () {

            });


        }
        else if (neye_tiklandi == "engelle") {

            $.ajax({

                method: "POST",
                url: "/OzelSohbet/KullaniciEngelle",
                data: { engellenenKullaniciId: bilgi },
                beforeSend: function () {
                }
            }).done(function (d) {

                $.notify("Kullanıcı başarıyla engellendi", "success");

            }).fail(function (d) {
                alert("Bir hata olustu")
            }).always(function () {

            });

        }
        else if (neye_tiklandi == "arkadas_ekle") {

            $.ajax({

                method: "POST",
                url: "/Profile/ArkadasEkle",
                data: { userId: bilgi },
                beforeSend: function () {

                }
            }).done(function (d) {

                chat.server.addFriend(bilgi);

            });
        }
        else if (neye_tiklandi == "profil_gor") {
            alert("profil gör");
        }




    });


    $("#sohbet_penceresi_kapa").click(function () {

        $("#messageArea").attr("data-id", null);

        $("#row1").addClass("ozel_sohbet_kaydir_saga");
        $("#row2").addClass("ozel_sohbet_kaydir_saga");

        $("#quick_sidebar_tab_1").removeClass("page-quick-sidebar-content-item-shown");

        $("#row1").removeClass("ozel_sohbet_kaydir_sola");
        $("#row2").removeClass("ozel_sohbet_kaydir_sola");



    });


    $(document).on("click", ".page-quick-sidebar-back-to-list", function () {

        $("#row1").addClass("ozel_sohbet_kaydir_saga");
        $("#row2").addClass("ozel_sohbet_kaydir_saga");

        $("#quick_sidebar_tab_1").removeClass("page-quick-sidebar-content-item-shown");

        $("#row1").removeClass("ozel_sohbet_kaydir_sola");
        $("#row2").removeClass("ozel_sohbet_kaydir_sola");

        $("#messageArea").attr("data-id", "");

    })

    $(document).on("click", "#gorulmemis_mesajlar li", function () {

        var element = document.getElementById('quick_sidebar_tab_1');
        var kim_id = $(this).attr("data-id");

        if (hasClass(element, 'page-quick-sidebar-content-item-shown') == false) {
            document.getElementById('sohbet_penceresi_ac').click();

            $('[id]').each(function () {

                if (this.id == "arkadas_" + kim_id) {
                    document.getElementById('arkadas_' + kim_id).click();
                    return;
                }
                else if (this.id == "whisper_" + kim_id) {
                    document.getElementById('whisper_' + kim_id).click();
                    return;
                }
            });



        }
        else {

            document.getElementById('arkadas_' + kim_id).click();
        }

    });

    $('#Cikis').click(function () {
        window.location.href = "/Account/LogOut";
    });


    function hasClass(element, cls) {
        return (' ' + element.className + ' ').indexOf(' ' + cls + ' ') > -1;
    }

})



//$.ajax({

//    method: "POST",
//    url: "/OzelSohbet/MesajlariGetir",
//    data: { alanId: bilgi },
//    beforeSend: function () {


//    }
//}).done(function (d) {




//}).fail(function (d) {
//    alert("Bir hata olustu")
//}).always(function () {

//})