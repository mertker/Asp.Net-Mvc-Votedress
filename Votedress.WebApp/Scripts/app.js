

var app = angular.module("myApp", ["checklist-model", 'ngSanitize']);

var bahsedilenList = [];


app.controller('GlobalCtrl', ['$scope', '$http', 'dataShare', function ($scope, $http, dataShare) {
    var chat = $.connection.messanger;

    $scope.Fisilda = function (user) {

        var kontrol5 = 0;

        $("#sohbet_penceresi_ac").click();


        $.ajax({

            method: "POST",
            url: "/OzelSohbet/WhisperEkle",
            data: { alanId: user.id },
            beforeSend: function () {

                $('[id]').each(function () {

                    if (this.id == "whisper_" + user.id || this.id == "arkadas_" + user.id) {
                        kontrol5 = 1;
                        return;
                    }
                });

                if (kontrol5 == 0) {
                    $("#fisildamalar ul").append('<li class="media" id="whisper_' + user.id + '"  data-event="mesaj_yaz" data-id="' + user.id + '"><img class= "img_media_object" src = "' + user.ProfileImage + '" alt = "..." > <div class="media-body" style="padding-top:9px;position:relative;" data-event="mesaj_yaz" data-id="' + user.id + '"> <a href="javascript:;" class="name2_in" style="font-size:20px" dropdown-toggle"="" data-toggle="dropdown" data-hover="dropdown" data-delay="1000" data-close-others="true" aria-expanded="true">' + user.Name + " " + user.SurName + '</a> <span class="badge badge-success" style="margin-left:200px;margin-top:-40px" id="gorulmemis_mesaj_sayisi_' + user.id + '">0</span> <ul class="dropdown-menu" role="menu" style="top:59%;margin-left:0px"><li><a href="#"><i class="icon-bell"></i> Fısılda</a></li><li><a href="#" data-event="arkadas_ekle" data-id="' + user.id + '"><i class="icon-user"></i> Arkadaş Ekle</a></li> <li><a href="#" data-event="engelle" data-id="' + user.id + '"><i class="icon-shield"></i> Engelle</a></li><li><a href="#" data-event="fisiltiyi_sil" data-id="' + user.id + '"> <i class="icon-shield"></i> Fısıltıyı Sil</a> </li><li><a href="#" data-event="profili_gor" data-id="' + user.id + '"><i class="icon-bag"></i> Profili Gör</a></li> </ul></div></li >');
                }



            }
        }).done(function (d) {

        });

        $.ajax({

            method: "POST",
            url: "/OzelSohbet/MesajlariGetir",
            data: { alanId: user.id },
            beforeSend: function () {

                $("#quick_sidebar_tab_1").addClass("page-quick-sidebar-content-item-shown");

                $("#row1").removeClass("ozel_sohbet_kaydir_saga");
                $("#row2").removeClass("ozel_sohbet_kaydir_saga");

                $("#row1").addClass("ozel_sohbet_kaydir_sola");
                $("#row2").addClass("ozel_sohbet_kaydir_sola");


            }
        }).done(function (d) {

            $("#messageArea").empty();
            $("#messageArea").attr("data-id", user.id)

            var buton = $("#ozelMesaj_gonder");
            buton.attr("data-id", user.id);

            var kontrol = 0;

            $('[id]').each(function () {

                if (this.id == "gorulmemis_mesaj_" + user.id) {
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

                $("#gorulmemis_mesaj_sayisi_" + bilgi).text("0");


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

            $("#messageArea").scrollTop(scrollTo_int + 1000);

            $("#ozelMesaj_input").focus();


        }).fail(function (d) {
            alert("Bir hata olustu")
        }).always(function () {

        })

        $("#quick_sidebar_tab_1").addClass("page-quick-sidebar-content-item-shown");

        $("#row1").removeClass("ozel_sohbet_kaydir_saga");
        $("#row2").removeClass("ozel_sohbet_kaydir_saga");

        $("#row1").addClass("ozel_sohbet_kaydir_sola");
        $("#row2").addClass("ozel_sohbet_kaydir_sola");
    }
    $scope.ArkadasEkle = function (user) {

        $.ajax({

            method: "POST",
            url: "/Profile/ArkadasEkle",
            data: { userId: user.id },
            beforeSend: function () {

            }
        }).done(function (d) {

            chat.server.addFriend(user.id);

        });



    };
    $scope.Engelle = function (user, voteId) {

        $.ajax({

            method: "POST",
            url: "/OzelSohbet/KullaniciEngelle",
            data: { engellenenKullaniciId: user.id },
            beforeSend: function () {
            }
        }).done(function (d) {

            $.notify("Kullanıcı başarıyla engellendi", "success");

            chat.server.oylamalardanMesajlariniSil(user.id, voteId);

        }).fail(function (d) {
            alert("Bir hata olustu")
        }).always(function () {

        });


    };

    //Sepet

    $scope.Sepetim = modelSepetim;
    $scope.ToplamTutar = 0;

    for (var i = 0; i < $scope.Sepetim.length; i++) {
        $scope.ToplamTutar = $scope.ToplamTutar + ($scope.Sepetim[i].Count * $scope.Sepetim[i].ProductPrice);
    }
    console.log($scope.Sepetim);

    $scope.SepettenSil = function (sepetId) {

        $.ajax({

            method: "POST",
            url: "/Gardrop/SepettenSil",
            data: { sepetId: sepetId },
            beforeSend: function () {

            }
        }).done(function (d) {

            dataShare.sendData(d, "sepetSilAna");

            $scope.ToplamTutar = 0;

            for (var i = 0; i < $scope.Sepetim.length; i++) {
                if ($scope.Sepetim[i].id == d) {
                    $scope.Sepetim.splice(i, 1);
                    for (var i = 0; i < $scope.Sepetim.length; i++) {
                        $scope.ToplamTutar = $scope.ToplamTutar + ($scope.Sepetim[i].Count * $scope.Sepetim[i].ProductPrice);
                    }
                    $scope.$apply();
                    break;
                }
            }

        });

    }

    $scope.$on('sepetEkle', function () {

        var varmi = false;

        var gelenData = dataShare.getData();
        $scope.ToplamTutar = $scope.ToplamTutar + (gelenData.ProductPrice * gelenData.Count);


        for (var i = 0; i < $scope.Sepetim.length; i++) {
            if ($scope.Sepetim[i].id == gelenData.id) {
                $scope.Sepetim[i].Count = gelenData.Count;
                $scope.$apply();
                varmi = true;
                break;
            }
        }

        if (varmi == false) {
            $scope.Sepetim.push(gelenData);
            $scope.$apply();
        }

    });
    $scope.$on('sepetSil', function () {

        var gelenData = dataShare.getData();
        $scope.SepettenSil(gelenData);



    });



}]);

app.controller('OylamaCtrl', ['$scope', 'viewModel', '$http', 'dataShare', "$compile", function ($scope, viewModel, $http, dataShare, $compile) {

    var chat = $.connection.messanger;
    $scope.viewModel;
    $scope.Chattekiler = [];//{ id: null, kullaniciAdSoyad: null, profilResmi: null }
    $scope.kullaniciResmi = kullaniciResmi;
    $scope.CurrentVoteProduct = 0;
    $scope.CurrentVoteImage = 0;
    $scope.OylamaResimleri = [];

    $scope.adet = 1;

    $scope.Magazalar = [];

    var eskiOylamaId = null;

    if (viewModel != null) {

        $scope.viewModel = viewModel;


        for (var t = 0; t < viewModel.Chattekiler.length; t++) {

            $scope.Chattekiler.push({ id: viewModel.Chattekiler[t].id, kullaniciAdSoyad: viewModel.Chattekiler[t].Name + " " + viewModel.Chattekiler[t].SurName, profilResmi: viewModel.Chattekiler[t].ProfileImage });

        }

        for (var i = 0; i < $scope.viewModel.OylamaUrunleri.length; i++) {
            for (var j = 0; j < $scope.viewModel.OylamaUrunleri[i].OylamaResimleri.length; j++) {
                $scope.OylamaResimleri.push($scope.viewModel.OylamaUrunleri[i].OylamaResimleri[j]);
            }
        }

        //var varMi;
        //for (var i = 0; i < $scope.viewModel.OylamaUrunleri.length; i++) {

        //    varMi = functiontofindIndexByKeyValue($scope.Magazalar, "MagazaGuid", $scope.viewModel.OylamaUrunleri[i].UrunSahibi.MagazaGuid)
        //    if (varMi == null) {
        //        $scope.Magazalar.push($scope.viewModel.OylamaUrunleri[i].UrunSahibi);
        //    }
        //}


        $scope.magaza = $scope.viewModel.OylamaUrunleri[0].UrunSahibi;

        

   

        console.log($scope.viewModel);
        console.log($scope.Magazalar);

    }
    else {
        $("#mainDiv").remove();
    }

    $scope.sola = function () {
        $scope.CurrentVoteImage--;

        if ($scope.CurrentVoteImage <= 0) {

            $scope.CurrentVoteImage = $scope.OylamaResimleri.length - 1;
        }

        $("#myCarousel").carousel($scope.CurrentVoteImage);

        var sayac = 0;
        var kontrol = 0;

        for (var i = 0; i < $scope.viewModel.OylamaUrunleri.length; i++) {
            for (var j = 0; j < $scope.viewModel.OylamaUrunleri[i].OylamaResimleri.length; j++) {

                if (sayac == $scope.CurrentVoteImage) {

                    $scope.CurrentVoteProduct = i;
                    kontrol = 1;
                    break;
                }

                sayac++;
            }
            if (kontrol == 1) {
                break;
            }
        }

    }

    $scope.saga = function () {

        $scope.CurrentVoteImage++;

        if ($scope.CurrentVoteImage == $scope.OylamaResimleri.length) {

            $scope.CurrentVoteImage = 0;
        }

        $("#myCarousel").carousel($scope.CurrentVoteImage);

        var sayac = 0;
        var kontrol = 0;

        for (var i = 0; i < $scope.viewModel.OylamaUrunleri.length; i++) {
            for (var j = 0; j < $scope.viewModel.OylamaUrunleri[i].OylamaResimleri.length; j++) {

                if (sayac == $scope.CurrentVoteImage) {

                    $scope.CurrentVoteProduct = i;
                    kontrol = 1;
                    break;
                }

                sayac++;
            }
            if (kontrol == 1) {
                break;
            }
        }
    }

    $scope.ChangeCurrentVoteProduct = function (index, kacResimVar) {

        $scope.CurrentVoteProduct = index;
        $scope.CurrentVoteImage = index * kacResimVar;
        $("#myCarousel").carousel($scope.CurrentVoteImage);

        $scope.magaza = $scope.viewModel.OylamaUrunleri[index].UrunSahibi;
    }






    $scope.boyutRenkleri = null;
    $scope.boyutId = 0;
    $scope.UrunDetayGetir = function (urunId) {

        $scope.productDetail = true;

        var data = {
            UrunID: urunId
        }

        var config = {
            method: 'GET',
            url: '/Gardrop/UrunDetayiGetir',
            params: data,
            data: { projectStatus: ["ON"] },
            headers: {
                'Content-Type': 'application/json; charset=utf-8'
            }
        }

        $http(config).then(function (response) {

            console.log(response.data);
            $scope.urun = response.data.urun;


            console.log($scope.urun);

            $scope.productDetail = false;


            $scope.boyutSecildi(0);


        }, function (error) {
            console.log(error, 'can not get data.');
        })

    }

    $scope.boyutSecildi = function (boyutId) {

        $scope.boyutRenkleri = $scope.urun.detail[boyutId].productColors;
        $scope.renkSecildi(0);
        $scope.boyutId = boyutId;
    }
    $scope.renkSecildi = function (renkId) {

        sepetIcerigi = { productId: $scope.urun.id, productSize: $scope.urun.detail[$scope.boyutId].productSize, productColorId: $scope.urun.detail[$scope.boyutId].productColors[renkId].id, productCount: $scope.adet };
        $scope.productImageGallery = $scope.urun.detail[$scope.boyutId].productColors[renkId].productImageGallery;


    }


    $scope.AdetAzalt = function () {

        if ($scope.adet > 0) {
            $scope.adet--;
        }

        sepetIcerigi.productCount = $scope.adet;

    }
    $scope.AdetArttir = function () {
        $scope.adet++;

        sepetIcerigi.productCount = $scope.adet;
    }



    $scope.SepeteEkle = function () {

        sepetIcerigi.productCount = $scope.adet;

        $.ajax({

            method: "POST",
            url: "/Gardrop/SepeteEkle",
            data: { sepetIcerigi: sepetIcerigi },
            beforeSend: function () {

            }
        }).done(function (d) {

            $.notify("Sepete ekleme başarılı.", "success");
            dataShare.sendData(d, "sepetEkle");

        });

    }





    var et_konumlari = [];
    var bahsedilenler = [];
    var son_et_konumu = -1;
    $scope.OylamaMesaj = "";
    $scope.aranan = "xxxxxxxxxxxxxxxxxxxxx";

    $scope.ete_basildimi = function () {

        var donen = eteBasildi({ mesaj: $scope.OylamaMesaj, son_et_konumu: son_et_konumu, et_konumlari: et_konumlari });

        et_konumlari = donen.icerik.et_konumlari;
        son_et_konumu = donen.icerik.son_et_konumu;
        $scope.aranan = donen.icerik.aranan;

    }

    console.log(viewModel.Chattekiler);
    $scope.bahset = function (bahsedilen) {

        bahsedilenler.push({ id: bahsedilenler.length + 1, konum: son_et_konumu, kim: bahsedilen });

        var donen = bahsedildi({ bahsedilenler: bahsedilenler, mesaj: $scope.OylamaMesaj, son_et_konumu: son_et_konumu, et_konumlari: et_konumlari });

        et_konumlari = donen.icerik.et_konumlari;
        son_et_konumu = donen.icerik.son_et_konumu;
        $scope.OylamaMesaj = donen.icerik.mesaj;

        $scope.aranan = "xxxxxxxxxxxxxxxxxxxxxxxxx";

    }
    $('#chatMesajAlani').on('keydown', function (e) {
        var ids = $(this).find('[id]'),
            self = $(this);
        setTimeout(function () {
            ids.each(function () {
                if (!self.find('#' + this.id).length) {
                    var gorelim = $(this).attr("data-id");
                    for (var i = 0; i < bahsedilenler.length; i++) {
                        if (bahsedilenler[i].id == gorelim) {
                            bahsedilenler.splice(i, i + 1);
                        }
                    }
                }
            });
        });
    });

    $scope.birkere = 0;
    $scope.ChatScrollPosition = function () {

        if ($scope.birkere != 2) {
            var oylamaScroll = $("#testDiv_" + $scope.viewModel.id);
            var scrollTo_int = oylamaScroll.prop('scrollHeight');
            oylamaScroll.scrollTop(scrollTo_int + 1000);

            $scope.birkere++;
        }
    }


    chat.client.ChateBiriBaglandi = function (baglanan) {

        var kontrol = 0;
        for (var i = 0; i < $scope.viewModel.Chattekiler.length; i++) {

            if ($scope.viewModel.Chattekiler[i].id == baglanan.id) {
                kontrol = 1;
                break;
            }

        }
        if (kontrol == 0) {
            $scope.viewModel.Chattekiler.push(baglanan);
            console.log($scope.viewModel.Chattekiler);
        }


    }
    chat.client.OylamaMesajGonder = function (mesajModel) {

        var oylamaScroll = $("#testDiv_" + $scope.viewModel.id);
        var scrollPosition = oylamaScroll.scrollTop();
        var scrollTo_int = oylamaScroll.prop('scrollHeight');
        var fark = scrollTo_int - scrollPosition;
        if (fark <= 683) {

            $scope.viewModel.OylamaMesajlari.push(mesajModel);
            $scope.$apply();

            $("#testDiv_" + $scope.viewModel.id).scrollTop(scrollTo_int + 1000);
        }
        else {
            $scope.viewModel.OylamaMesajlari.push(mesajModel);
            $scope.$apply();
        }



    }
    chat.client.OylamadanMesalariSil = function (userId, voteId) {


        for (var i = 0; i < $scope.viewModel.OylamaMesajlari.length; i++) {

            if ($scope.viewModel.OylamaMesajlari[i].MesajSahibi.id == userId) {
                $scope.viewModel.OylamaMesajlari.splice(i, 1);
                i--;
            }

        }

        $scope.$apply();
    }

    $.connection.hub.start().done(function () {
        chat.server.oylamaChatineKatil($scope.viewModel.SessionUserId, $scope.viewModel.id);

        $scope.oyla = function () {

            var OylamaUrunuId = 0;
            var sayac = 0;
            var kontrol = 0;

            for (var i = 0; i < $scope.viewModel.OylamaUrunleri.length; i++) {
                for (var j = 0; j < $scope.viewModel.OylamaUrunleri[i].OylamaResimleri.length; j++) {

                    if (sayac == $scope.CurrentVoteImage) {

                        OylamaUrunuId = $scope.viewModel.OylamaUrunleri[i].id
                        kontrol = 1;
                        break;
                    }

                    sayac++;
                }
                if (kontrol == 1) {
                    break;
                }
            }

            $http({
                method: 'POST',
                url: '/Oylama/Oyla',  /*You URL to post*/
                data: { id: OylamaUrunuId }  /*You data object/class to post*/
            }).then(function successCallback(response) {

                alert(response.data.Message);
                if (response.data.IsSuccess == true) {

                    chat.server.oylamaChatindenAyril($scope.viewModel.SessionUserId, $scope.viewModel.id);
                    chat.server.oyVerildi($scope.viewModel.id, OylamaUrunuId, $scope.viewModel.OylamaSahibi.id);


                    if (response.data.YeniOylama != null) {

                        $scope.viewModel = response.data.YeniOylama;
                        $scope.OylamaResimleri = [];

                        $scope.CurrentVoteImage = 0;
                        $scope.CurrentVoteProduct = 0;

                        for (var i = 0; i < $scope.viewModel.OylamaUrunleri.length; i++) {
                            for (var j = 0; j < $scope.viewModel.OylamaUrunleri[i].OylamaResimleri.length; j++) {
                                $scope.OylamaResimleri.push($scope.viewModel.OylamaUrunleri[i].OylamaResimleri[j]);
                            }
                        }

                        chat.server.oylamaChatineKatil($scope.viewModel.SessionUserId, $scope.viewModel.id);


                    }
                    else {

                        $("#mainDiv").remove();

                        $scope.viewModel = null;
                    }

                }

            }, function errorCallback(response) {
                console.log(response);
                alert(response.data.Message);
            });

        }
        $scope.OylamaMesajGonder = function () {

            if ($scope.OylamaMesaj != "" && $scope.OylamaMesaj != null) {

                var temiz_bahsedilenler = [];

                for (var i = 0; i < bahsedilenler.length; i++) {
                    temiz_bahsedilenler.push(bahsedilenler[i].kim);
                }

                chat.server.oylamaMesajGonder($scope.viewModel.OylamaSahibi.id, $scope.viewModel.id, $scope.viewModel.SessionUserId, $scope.OylamaMesaj, temiz_bahsedilenler);
                bahsedilenler = [];
                $scope.OylamaMesaj = null;
                $("#chatMesajAlani").focus();
            }
        }

    }).fail(function () {

    });
}]);

app.controller('BahsedenlerCtrl', ['$scope', 'viewModel2', '$http', 'dataShare', function ($scope, viewModel2, $http, dataShare) {

    var chat = $.connection.messanger;
    $scope.BahsedilgimYerler = viewModel2.reverse();

    //$scope.$on('data_shared', function () {
    //    var gelenData = dataShare.getData();
    //    $scope.BahsedilgimYerler.push(gelenData);
    //    $scope.$apply();
    //});



    chat.client.SizdenBahsedildi = function (response) {

        $scope.BahsedilgimYerler.unshift(response);
        $scope.$apply();

    }

}]);


app.controller('ArkadaslikIstekleriCtrl', ['$scope', '$http', function ($scope, $http) {

    var chat = $.connection.messanger;

    $scope.arkadaslikIstekleri = modelArkadaslikIstekleri;
    $scope.ArkadaslikIstegiKabulEt = function (arkadaslikIstegi) {

        $.ajax({

            method: "POST",
            url: "/Profile/ArkadaslikIstegiKabulEt",
            data: { userId: arkadaslikIstegi.UserId },
            beforeSend: function () {

            }
        }).done(function (d) {

            chat.server.arkadaslikIstegiKabulEdildi(arkadaslikIstegi.UserId);

            var index = $scope.arkadaslikIstekleri.indexOf(arkadaslikIstegi);
            if (index != -1) {
                $scope.arkadaslikIstekleri.splice(index, 1);
                $scope.$apply();
            }

        });

    }
    chat.client.ArkadasIstegiVar = function (arkadasIstegi) {

        $scope.arkadaslikIstekleri.push(arkadasIstegi);
        $scope.$apply();

    }
    chat.client.ArkadaslikIstegiKabulEdilenKisininDurumu = function (arkadasIstegi, durum) {

        if ($("#whisper_" + arkadasIstegi.UserId) != undefined) {
            $("#whisper_" + arkadasIstegi.UserId).remove();
        }

        if (durum == true)//Online
        {
            $("#cevrim_iciDiv ul").append('<li class="media" id="arkadas_' + arkadasIstegi.UserId + '"  data-event="mesaj_yaz" data-id="' + arkadasIstegi.UserId + '"><img class= "img_media_object" src = "' + arkadasIstegi.UserProfileImage + '" alt = "..." > <div class="media-body" style="padding-top:9px;position:relative;" data-event="mesaj_yaz" data-id="' + arkadasIstegi.UserId + '"> <a href="javascript:;" class="name2_in" style="font-size:20px" dropdown-toggle"="" data-toggle="dropdown" data-hover="dropdown" data-delay="1000" data-close-others="true" aria-expanded="true">' + arkadasIstegi.UserNameSurname + '</a> <span class="badge badge-success" style="margin-left:200px;margin-top:-40px" id="gorulmemis_mesaj_sayisi_' + arkadasIstegi.UserId + '">0</span> <ul class="dropdown-menu" role="menu" style="top:59%;margin-left:0px"><li><a href="#" data-event="mesaj_yaz" data-id="' + arkadasIstegi.UserId + '"><i class="icon-bell"></i> Mesaj Yaz</a></li><li><a href="#" data-event="profili_gor" data-id="' + arkadasIstegi.UserId + '"><i class="icon-bag"></i> Profili Gör</a></li> </ul></div></li >');

        }
        else {
            $("#cevrim_disiDiv ul").append('<li class="media" id="arkadas_' + arkadasIstegi.UserId + '"  data-event="mesaj_yaz" data-id="' + arkadasIstegi.UserId + '"><img class= "img_media_object" src = "' + arkadasIstegi.UserProfileImage + '" alt = "..." > <div class="media-body" style="padding-top:9px;position:relative;" data-event="mesaj_yaz" data-id="' + arkadasIstegi.UserId + '"> <a href="javascript:;" class="name2_in" style="font-size:20px" dropdown-toggle"="" data-toggle="dropdown" data-hover="dropdown" data-delay="1000" data-close-others="true" aria-expanded="true">' + arkadasIstegi.UserNameSurname + '</a> <span class="badge badge-success" style="margin-left:200px;margin-top:-40px" id="gorulmemis_mesaj_sayisi_' + arkadasIstegi.UserId + '">0</span> <ul class="dropdown-menu" role="menu" style="top:59%;margin-left:0px"><li><a href="#" data-event="mesaj_yaz" data-id="' + arkadasIstegi.UserId + '"><i class="icon-bell"></i> Mesaj Yaz</a></li><li><a href="#" data-event="profili_gor" data-id="' + arkadasIstegi.UserId + '"><i class="icon-bag"></i> Profili Gör</a></li> </ul></div></li >');

        }



    }


}])

var scopeHolder;
app.controller('KurumsalKaydolCtrl', ['$scope', '$http', 'dataShare', '$compile', function ($scope, $http, dataShare, $compile) {


    $scope.Sehirler;

    $http.get("/Account/SehirleriGetir")
        .then(function (response) {
            $scope.Sehirler = response.data.Sehirler;

            console.log(response.data);
        });


    $scope.TekrarCompileEt = function (id, html) {
        var e = angular.element(document.getElementById(id));
        e.html(html);
        $compile(e.contents())($scope);

    }



    $scope.SehirSecildi = function () {

        if ($scope.selected != null) {

            var CityID = $scope.selected.CityID

            var config = {
                headers: {
                    'Content-Type': 'application/x-www-form-urlencoded;charset=utf-8;'
                }
            }

            $http({
                url: '/Account/IlceleriGetir',
                method: "POST",
                data: { CityID: CityID }
            }).then(function onSuccess(response) {
                // Handle success
                $scope.Ilceler = response.data.Ilceler;

                console.log($scope.Ilceler);
            }).catch(function onError(response) {
                // Handle error
                console.log(response);
            });

        }
        else {

        }
    };
    $scope.IlceSecildi = function () {

        if ($scope.selected2 != null) {

            var CountyID = $scope.selected2.CountyID

            var config = {
                headers: {
                    'Content-Type': 'application/x-www-form-urlencoded;charset=utf-8;'
                }
            }

            $http({
                url: '/Account/MahalleleriGetir',
                method: "POST",
                data: { CountyID: CountyID }
            }).then(function onSuccess(response) {
                // Handle success
                $scope.Mahalleler = response.data.Mahalleler;

                console.log($scope.Mahalleler);
            }).catch(function onError(response) {
                // Handle error
                console.log(response);
            });

        }
        else {

        }
    };



    scopeHolder = $scope.TekrarCompileEt;

}]);


app.controller('MagazalarCtrl', ['$scope', '$http', 'sessionId', 'dataShare', function ($scope, $http, sessionId, dataShare) {

    var chat = $.connection.messanger;

    $scope.disabled = false;
    $scope.disabled2 = true;
    $scope.disabled3 = true;
    $scope.disabled4 = false;

    $scope.selected = null;
    $scope.selected2 = null;
    $scope.selected3 = null;
    $scope.selected4 = null;



    $scope.page = 1;

    $scope.Magazalar = [];
    $scope.MagalazariGetir = function () {

        var cityId = 0;
        var countyId = 0;
        var neighborhoodId = 0;
        var franchiseId = 0;

        if ($scope.selected != null) {
            cityId = $scope.selected.CityID;
        }
        if ($scope.selected2 != null) {
            countyId = $scope.selected2.CountyID;
        }
        if ($scope.selected3 != null) {
            neighborhoodId = $scope.selected3.NeighborhoodID;
        }
        if ($scope.selected4 != null) {
            franchiseId = $scope.selected4.id;
        }

        var data = {
            page: $scope.page,
            CityID: cityId,
            CountyID: countyId,
            NeighborhoodID: neighborhoodId,
            FranchiseID: franchiseId
        }

        var config = {
            method: 'GET',
            url: '/Gardrop/MagazalariGetir',
            params: data,
            data: { projectStatus: ["ON"] },
            headers: {
                'Content-Type': 'application/json; charset=utf-8'
            }
        }

        $http(config).then(function (response) {
            for (var i = 0; i < response.data.length; i++) {
                $scope.Magazalar.push(response.data[i]);
            }

        }, function (error) {
            console.log(error, 'can not get data.');
        })


    };


    $scope.MagalazariGetir();
    $scope.DahaFazlaYukle = function () {

        $scope.page++;
        $scope.MagalazariGetir();

    };

    $scope.Sehirler;
    $scope.Franchiseler;

    $http.get("/Account/SehirleriGetir")
        .then(function (response) {
            $scope.Sehirler = response.data.Sehirler;

            $scope.Sehirler.splice(0, 0, { CityID: 0, CityName: "Tümü" });
            $scope.selected = $scope.Sehirler[0];

            console.log(response.data);
        });

    $http.get("/Gardrop/FranchiseleriGetir")
        .then(function (response) {
            $scope.Franchiseler = response.data;

            if ($scope.Franchiseler != undefined) {
                $scope.Franchiseler.splice(0, 0, { id: 0, FranchiseName: "Tümü" });
                $scope.selected4 = $scope.Franchiseler[0];
            }


            console.log(response.data);
        });

    $scope.SehirSecildi = function () {

        if ($scope.selected != null) {

            if ($scope.selected.CityID == 0) {
                $scope.Mahalleler.splice(0, 0, { NeighborhoodID: 0, NeighborhoodName: "Tümü" });
                $scope.selected3 = $scope.Mahalleler[0];
                $scope.disabled3 = true;
            }


            var CityID = $scope.selected.CityID

            var config = {
                headers: {
                    'Content-Type': 'application/x-www-form-urlencoded;charset=utf-8;'
                }
            }

            $http({
                url: '/Account/IlceleriGetir',
                method: "POST",
                data: { CityID: CityID }
            }).then(function onSuccess(response) {
                // Handle success
                $scope.Ilceler = response.data.Ilceler;

                $scope.Ilceler.splice(0, 0, { CountyID: 0, CountyName: "Tümü" });
                $scope.selected2 = $scope.Ilceler[0];

                if ($scope.selected.CityID != 0) {
                    $scope.disabled2 = false;
                }
                else {
                    $scope.disabled2 = true;
                }


                console.log($scope.Ilceler);
            }).catch(function onError(response) {
                // Handle error
                console.log(response);
            });

        }
        else {

        }
    };
    $scope.IlceSecildi = function () {

        if ($scope.selected2 != null) {

            var CountyID = $scope.selected2.CountyID

            var config = {
                headers: {
                    'Content-Type': 'application/x-www-form-urlencoded;charset=utf-8;'
                }
            }

            $http({
                url: '/Account/MahalleleriGetir',
                method: "POST",
                data: { CountyID: CountyID }
            }).then(function onSuccess(response) {
                // Handle success
                $scope.Mahalleler = response.data.Mahalleler;

                $scope.Mahalleler.splice(0, 0, { NeighborhoodID: 0, NeighborhoodName: "Tümü" });
                $scope.selected3 = $scope.Mahalleler[0];

                if ($scope.selected2.CountyID != 0) {
                    $scope.disabled3 = false;
                }
                else {
                    $scope.disabled3 = true;
                }

                console.log($scope.Mahalleler);
            }).catch(function onError(response) {
                // Handle error
                console.log(response);
            });

        }
        else {

        }
    };


    chat.client.BiriMagazayaGirdi = function (magazaId) {

        for (var i = 0; i < $scope.Magazalar.length; i++) {

            if ($scope.Magazalar[i].MagazaGuid == magazaId) {
                $scope.Magazalar[i].MagazadakilerSayisi++;
                $scope.$apply();
                break;
            }
        }
    };
    chat.client.BiriMagazadanCikti = function (magazaId) {

        for (var i = 0; i < $scope.Magazalar.length; i++) {

            if ($scope.Magazalar[i].MagazaGuid == magazaId) {
                $scope.Magazalar[i].MagazadakilerSayisi--;
                $scope.$apply();
            }

        }

    }


    $scope.filtrele = function () {

        $scope.page = 1;

        var cityId = 0;
        var countyId = 0;
        var neighborhoodId = 0;
        var franchiseId = 0;

        if ($scope.selected != null) {
            cityId = $scope.selected.CityID;
        }
        if ($scope.selected2 != null) {
            countyId = $scope.selected2.CountyID;
        }
        if ($scope.selected3 != null) {
            neighborhoodId = $scope.selected3.NeighborhoodID;
        }
        if ($scope.selected4 != null) {
            franchiseId = $scope.selected4.id;
        }

        var data = {
            page: $scope.page,
            CityID: cityId,
            CountyID: countyId,
            NeighborhoodID: neighborhoodId,
            FranchiseID: franchiseId
        }

        var config = {
            method: 'GET',
            url: '/Gardrop/MagazalariGetir',
            params: data,
            data: { projectStatus: ["ON"] },
            headers: {
                'Content-Type': 'application/json; charset=utf-8'
            }
        }

        $http(config).then(function (response) {
            console.log(response);
            $scope.Magazalar = response.data;

        }, function (error) {
            console.log(error, 'can not get data.');
        })

    }
    $scope.MagazayaGit = function (magaza) {
        window.location.href = "/Gardrop/Magaza?id=" + magaza.MagazaGuid;

    };
    $.connection.hub.start().done(function () {
        chat.server.gardrobaKatil();
    }).fail(function () {

    });

}]);

app.controller('MagazaCtrl', ['$scope', '$http', 'magazaModel', 'dataShare', function ($scope, $http, magazaModel, dataShare) {

    var chat = $.connection.messanger;

    $scope.urunler = magazaModel.urunler;
    $scope.magazaAdi = magazaModel.magazaAdi;
    $scope.magazaId = magazaModel.magazaId;
    $scope.kategoriler = magazaModel.kategoriler;
    $scope.renkler = renkler;

    $scope.adet = 1;
    var sepetIcerigi = null;

    $scope.enDusukFiyat = null;
    $scope.enYuksekFiyat = null;

    $scope.page = 1;

    $scope.secilenKategoriler = {
        kategoriler: null
    };

    $scope.secilenRenkler = {
        renkler: null
    };


    $scope.urunAra = function () {

        $scope.products = true;

        var data = {
            page: $scope.page,
            magazaId: $scope.magazaId,
            renkId: $scope.secilenRenkler.renkler,
            kategoriId: $scope.secilenKategoriler.kategoriler,
            enDusukFiyat: $scope.enDusukFiyat,
            enYuksekFiyat: $scope.enYuksekFiyat,
        }

        var config = {
            method: 'GET',
            url: '/Gardrop/UrunFiltrele',
            params: data,
            data: { projectStatus: ["ON"] },
            headers: {
                'Content-Type': 'application/json; charset=utf-8'
            }
        }

        $http(config).then(function (response) {

            $scope.urunler = response.data.urunler;

            $scope.products = false;
            console.log(response.data);

        }, function (error) {
            console.log(error, 'can not get data.');
        })

    };

    console.log(magazaModel);

    $scope.top = 25;


    $scope.boyutRenkleri = null;
    $scope.boyutId = 0;
    $scope.UrunDetayGetir = function (urunId) {

        $scope.productDetail = true;

        var data = {
            UrunID: urunId
        }

        var config = {
            method: 'GET',
            url: '/Gardrop/UrunDetayiGetir',
            params: data,
            data: { projectStatus: ["ON"] },
            headers: {
                'Content-Type': 'application/json; charset=utf-8'
            }
        }

        $http(config).then(function (response) {

            console.log(response.data);
            $scope.urun = response.data.urun;


            console.log($scope.urun);

            $scope.productDetail = false;


            $scope.boyutSecildi(0);


        }, function (error) {
            console.log(error, 'can not get data.');
        })

    }


    $scope.boyutSecildi = function (boyutId) {

        $scope.boyutRenkleri = $scope.urun.detail[boyutId].productColors;
        $scope.boyutId = boyutId;
        $scope.renkSecildi(0);

    }
    $scope.renkSecildi = function (renkId) {

        sepetIcerigi = { productId: $scope.urun.id, productSize: $scope.urun.detail[$scope.boyutId].productSize, productColorId: $scope.urun.detail[$scope.boyutId].productColors[renkId].id, productCount: $scope.adet };
        $scope.productImageGallery = $scope.urun.detail[$scope.boyutId].productColors[renkId].productImageGallery;

        console.log(sepetIcerigi);
    }


    $scope.AdetAzalt = function () {

        if ($scope.adet > 0) {
            $scope.adet--;
        }

        sepetIcerigi.productCount = $scope.adet;

    }
    $scope.AdetArttir = function () {
        $scope.adet++;

        sepetIcerigi.productCount = $scope.adet;
    }

    $scope.SepeteEkle = function () {

        sepetIcerigi.productCount = $scope.adet;

        $.ajax({

            method: "POST",
            url: "/Gardrop/SepeteEkle",
            data: { sepetIcerigi: sepetIcerigi },
            beforeSend: function () {

            }
        }).done(function (d) {

            $.notify("Sepete ekleme başarılı.", "success");

            dataShare.sendData(d, "sepetEkle");

        });

    }



}]);

app.controller('UrunDetayiCtrl', ['$scope', '$http', 'urunDetayModel', 'dataShare', function ($scope, $http, urunDetayModel, dataShare) {
    var chat = $.connection.messanger;

    $scope.adet = 1;
    var sepetIcerigi = null;

    $scope.urun = urunDetayModel.urun;

    console.log($scope.urun);


    $scope.commentCount = $scope.urun.comments.length - 5;


    $scope.commentReplyCounts = [];
    $scope.begendigimYorumlar = [];
    $scope.yorumYazmaYeri = [];


    $scope.yorumYapanlar = []; //{ id: null, kullaniciAdSoyad: null, profilResmi: null };
    var kontrol = 0;

    for (var i = 0; i < $scope.urun.comments.length; i++) {

        kontrol = 0;

        for (var k = 0; k < $scope.yorumYapanlar.length; k++) {

            if ($scope.urun.comments[i].commentOwnerId == $scope.yorumYapanlar[k].id) {
                kontrol = 1;
                break;
            }

        }

        if (kontrol == 0) {
            $scope.yorumYapanlar.push({ id: $scope.urun.comments[i].commentOwnerId, kullaniciAdSoyad: $scope.urun.comments[i].commentOwnerFullName, profilResmi: $scope.urun.comments[i].commentOwnerProfilImage });
        }


        for (var t = 0; t < $scope.urun.comments[i].commentReplies.length; t++) {
            kontrol = 0;
            for (var z = 0; z < $scope.yorumYapanlar.length; z++) {
                if ($scope.urun.comments[i].commentReplies[t].commentOwnerId == $scope.yorumYapanlar[z].id) {
                    kontrol = 1;
                    break;
                }
            }

            if (kontrol == 0) {
                $scope.yorumYapanlar.push({ id: $scope.urun.comments[i].commentReplies[t].commentOwnerId, kullaniciAdSoyad: $scope.urun.comments[i].commentReplies[t].commentOwnerFullName, profilResmi: $scope.urun.comments[i].commentReplies[t].commentOwnerProfilImage });
            }
        }
    }


    function begendiklerimiBul() {


        var kontrol = 0;
        var yorumBegenenId;
        for (var i = 0; i < $scope.urun.comments.length; i++) {

            kontrol = 0;
            $scope.begendigimCevaplar = [];
            $scope.commentReplyCounts.push($scope.urun.comments[i].commentReplies.length);
            $scope.yorumYazmaYeri.push({ acikmi: false, icerik: { bahsedilenler: [], mesaj: "", son_et_konumu: -1, et_konumlari: [], aranan: "xxxxxxxxxxxxxxxxxx" } });

            for (var z = 0; z < $scope.urun.comments[i].commentLikes.length; z++) {

                yorumBegenenId = $scope.urun.comments[i].commentLikes[z].LikedId;

                if (yorumBegenenId == kullanici_id) {
                    $scope.begendigimYorumlar.push({ commentId: $scope.urun.comments[i].commentId, deger: true, cevap: [] });
                    kontrol = 1;
                    break;
                }
            }

            if (kontrol == 0) {
                $scope.begendigimYorumlar.push({ commentId: $scope.urun.comments[i].commentId, deger: false, cevap: [] });
            }



            for (var t = 0; t < $scope.urun.comments[i].commentReplies.length; t++) {

                kontrol = 0;

                for (var n = 0; n < $scope.urun.comments[i].commentReplies[t].commentLikes.length; n++) {

                    yorumBegenenId = $scope.urun.comments[i].commentReplies[t].commentLikes[n].LikedId;

                    if (yorumBegenenId == kullanici_id) {
                        $scope.begendigimYorumlar[i].cevap.push({ commentId: $scope.urun.comments[i].commentReplies[t].commentId, deger: true });
                        kontrol = 1;
                        break;
                    }
                }

                if (kontrol == 0) {
                    $scope.begendigimYorumlar[i].cevap.push({ commentId: $scope.urun.comments[i].commentReplies[t].commentId, deger: false });
                }
            }
        }
    }
    begendiklerimiBul();
    console.log($scope.begendigimYorumlar);



    $scope.boyutSecildi = function (boyutId) {

        $scope.boyutRenkleri = $scope.urun.detail[boyutId].productColors;
        $scope.boyutId = boyutId;
        $scope.renkSecildi(0);

    }
    $scope.renkSecildi = function (renkId) {

        sepetIcerigi = { productId: $scope.urun.id, productSize: $scope.urun.detail[$scope.boyutId].productSize, productColorId: $scope.urun.detail[$scope.boyutId].productColors[renkId].id, productCount: $scope.adet };
        $scope.productImageGallery = $scope.urun.detail[$scope.boyutId].productColors[renkId].productImageGallery;

        console.log(sepetIcerigi);
    }

    $scope.boyutSecildi(0);


    $scope.AdetAzalt = function () {

        if ($scope.adet > 0) {
            $scope.adet--;
        }

        sepetIcerigi.productCount = $scope.adet;

    }
    $scope.AdetArttir = function () {
        $scope.adet++;

        sepetIcerigi.productCount = $scope.adet;
    }

    $scope.SepeteEkle = function () {

        sepetIcerigi.productCount = $scope.adet;

        $.ajax({

            method: "POST",
            url: "/Gardrop/SepeteEkle",
            data: { sepetIcerigi: sepetIcerigi },
            beforeSend: function () {

            }
        }).done(function (d) {

            $.notify("Sepete ekleme başarılı.", "success");

            dataShare.sendData(d, "sepetEkle");

        });

    }


    $scope.oncekiYorumlariGetir = function () {

        var kontrol = $scope.commentCount - 5;
        if (kontrol == 0) {
            $scope.commentCount = kontrol;
        }
        else if (kontrol < 0) {
            $scope.commentCount = 0;
        }
        else {
            $scope.commentCount -= 5;
        }



    }
    $scope.oncekiYanitlariGetir = function (index) {

        var kontrol = $scope.commentReplyCounts[index] - 5;
        if (kontrol == 0) {
            $scope.commentReplyCounts[index] = kontrol;
        }
        else if (kontrol < 0) {
            $scope.commentReplyCounts[index] = 0;
        }
        else {
            $scope.commentReplyCounts[index] -= 5;
        }

        $scope.yorumYazmaYeri[index].acikmi = true;
    }



    var et_konumlari = [];
    $scope.bahsedilenler = [];
    var son_et_konumu = -1;
    $scope.arananYorum = "xxxxxxxxxxxxxxxxxxxxx";
    $scope.urunYorumYazmaYeriEteBasildimi = function () {
        var donen = eteBasildi({ mesaj: $scope.urunYorumYazmaYeri, son_et_konumu: son_et_konumu, et_konumlari: et_konumlari });

        et_konumlari = donen.icerik.et_konumlari;
        son_et_konumu = donen.icerik.son_et_konumu;
        $scope.arananYorum = donen.icerik.aranan;

    }
    $scope.bahsetUrunYorumYeri = function (bahsedilen, index) {


        $scope.bahsedilenler.push({ id: $scope.bahsedilenler.length + 1, konum: son_et_konumu, kim: bahsedilen });

        var donen = bahsedildi({ bahsedilenler: $scope.bahsedilenler, mesaj: $scope.urunYorumYazmaYeri, son_et_konumu: son_et_konumu, et_konumlari: et_konumlari });

        et_konumlari = donen.icerik.et_konumlari;
        son_et_konumu = donen.icerik.son_et_konumu;
        $scope.urunYorumYazmaYeri = donen.icerik.mesaj;

        $scope.arananYorum = "xxxxxxxxxxxxxxxxxxxxxxxxx";

    }


    $scope.ete_basildimi = function (index) {

        var donen = eteBasildi({ mesaj: $scope.yorumYazmaYeri[index].icerik.mesaj, son_et_konumu: $scope.yorumYazmaYeri[index].icerik.son_et_konumu, et_konumlari: $scope.yorumYazmaYeri[index].icerik.et_konumlari });

        $scope.yorumYazmaYeri[index].icerik.et_konumlari = donen.icerik.et_konumlari;
        $scope.yorumYazmaYeri[index].icerik.son_et_konumu = donen.icerik.son_et_konumu;
        $scope.yorumYazmaYeri[index].icerik.aranan = donen.icerik.aranan;


    }
    $scope.bahset = function (bahsedilen, index) {

        $scope.yorumYazmaYeri[index].icerik.bahsedilenler.push({ id: $scope.yorumYazmaYeri[index].icerik.bahsedilenler.length + 1, konum: $scope.yorumYazmaYeri[index].icerik.son_et_konumu, kim: bahsedilen });

        var donen = bahsedildi({ bahsedilenler: $scope.yorumYazmaYeri[index].icerik.bahsedilenler, mesaj: $scope.yorumYazmaYeri[index].icerik.mesaj, son_et_konumu: $scope.yorumYazmaYeri[index].icerik.son_et_konumu, et_konumlari: $scope.yorumYazmaYeri[index].icerik.et_konumlari, index: index });

        $scope.yorumYazmaYeri[index].icerik.et_konumlari = donen.icerik.et_konumlari;
        $scope.yorumYazmaYeri[index].icerik.son_et_konumu = donen.icerik.son_et_konumu;
        $scope.yorumYazmaYeri[index].icerik.mesaj = donen.icerik.mesaj;
        $scope.yorumYazmaYeri[index].icerik.aranan = "xxxxxxxxxxxxxxxxxxxxxxx";

    }

    $scope.anaYorumaBahset = function (bahsedilen, index) {

        var mesajLenght = 0;

        if ($scope.yorumYazmaYeri[index].icerik.mesaj != "") {
            mesajLenght = decodeEntities($scope.yorumYazmaYeri[index].icerik.mesaj).length;
        }

        $scope.yorumYazmaYeri[index].icerik.bahsedilenler.push({ id: $scope.yorumYazmaYeri[index].icerik.bahsedilenler.length + 1, konum: mesajLenght, kim: bahsedilen });

        var donen = bahsedildi({ bahsedilenler: $scope.yorumYazmaYeri[index].icerik.bahsedilenler, mesaj: $scope.yorumYazmaYeri[index].icerik.mesaj + '&nbsp;@', son_et_konumu: mesajLenght, et_konumlari: $scope.yorumYazmaYeri[index].icerik.et_konumlari, index: index });

        $scope.yorumYazmaYeri[index].icerik.et_konumlari = donen.icerik.et_konumlari;
        $scope.yorumYazmaYeri[index].icerik.son_et_konumu = donen.icerik.son_et_konumu;
        $scope.yorumYazmaYeri[index].icerik.mesaj = donen.icerik.mesaj;
        $scope.yorumYazmaYeri[index].icerik.aranan = "xxxxxxxxxxxxxxxxxxxxxxx";


    }


    $('.keydownClass').on('keydown', function (e) {
        var ids = $(this).find('[id]'),
            self = $(this);
        setTimeout(function () {
            ids.each(function () {
                if (!self.find('#' + this.id).length) {
                    var gorelim = $(this).attr("data-id");
                    for (var i = 0; i < $scope.bahsedilenler.length; i++) {

                        if ($scope.bahsedilenler[i].id == gorelim) {

                            $scope.bahsedilenler.splice(i, i + 1);

                        }

                    }
                }
            });
        });
    });
    $("body").on("keydown", ".keydownClass2", function () {
        var ids = $(this).find('[id]'),
            self = $(this);
        setTimeout(function () {
            ids.each(function () {
                if (!self.find('#' + this.id).length) {
                    var gorelim = $(this).attr("data-id");
                    var index = $(this).attr("data-index");
                    for (var i = 0; i < $scope.yorumYazmaYeri[index].icerik.bahsedilenler.length; i++) {
                        if (gorelim == $scope.yorumYazmaYeri[index].icerik.bahsedilenler[i].id) {
                            $scope.yorumYazmaYeri[index].icerik.bahsedilenler.splice(i, i + 1);
                        }
                    }
                }
            });
        });
    });


    $scope.anaYorumuYanitla = function (index) {

        if ($scope.yorumYazmaYeri[index].acikmi == false) {
            $scope.oncekiYanitlariGetir(index);
        }

    }

    $scope.top = 25;

    $scope.boyutRenkleri = null;
    $scope.boyutId = 0;

    $scope.boyutSecildi = function (boyutId) {

        $scope.boyutRenkleri = $scope.urun.detail[boyutId].productColors;
        $scope.boyutId = boyutId;
        $scope.renkSecildi(0);

    }
    $scope.renkSecildi = function (renkId) {

        $scope.productImageGallery = $scope.urun.detail[$scope.boyutId].productColors[renkId].productImageGallery;

    }

    $scope.boyutSecildi(0);


    chat.client.uruneYorumYapildi = function (commentId, kullanici_id, yorumYapanFullName, yorumYapanProfilResmi, yorum, yorumTarihi) {


        $scope.urun.comments.push({ commentId: commentId, comment: yorum, commentDate: yorumTarihi, commentLikes: [], commentOwnerFullName: yorumYapanFullName, commentOwnerId: kullanici_id, commentOwnerProfilImage: yorumYapanProfilResmi, commentReplies: [] })
        $scope.commentCount++;
        $scope.begendigimYorumlar.push({ commentId: commentId, deger: false, cevap: [] });
        $scope.yorumYazmaYeri.push({ acikmi: false, icerik: { bahsedilenler: [], mesaj: "", son_et_konumu: -1, et_konumlari: [], aranan: "xxxxxxxxxxxxxxxxxx" } });

        $scope.commentReplyCounts.push(0);

        $scope.$apply();

    }
    chat.client.UrunYorumunaCevapYapildi = function (commentId, hangiYorum, kullanici_id, yorumYapanFullName, yorumYapanProfilResmi, yorum, yorumTarihi) {
        for (var i = 0; i < $scope.urun.comments.length; i++) {

            if ($scope.urun.comments[i].commentId == hangiYorum) {
                $scope.urun.comments[i].commentReplies.push({ commentId: commentId, comment: yorum, commentDate: yorumTarihi, commentLikes: [], commentOwnerFullName: yorumYapanFullName, commentOwnerId: kullanici_id, commentOwnerProfilImage: yorumYapanProfilResmi })
                $scope.begendigimYorumlar[i].cevap.push({ commentId: commentId, deger: false });
                $scope.commentReplyCounts[i]++;

                $scope.$apply();
                break;
            }
        }
    }


    chat.client.BiriAnaYorumuBegendi = function (begenenId, begenenTamAdi, yorumId) {

        for (var i = 0; i < $scope.urun.comments.length; i++) {

            if (yorumId == $scope.urun.comments[i].commentId) {

                $scope.urun.comments[i].commentLikes.push({ LikedFullName: begenenTamAdi, LikedId: begenenId });
                $scope.$apply();

            }

        }

    }
    chat.client.BiriAnaYorumuBegenmektenVazgecti = function (vazgecenId, yorumId) {
        for (var i = 0; i < $scope.urun.comments.length; i++) {

            if (yorumId == $scope.urun.comments[i].commentId) {

                for (var j = 0; j < $scope.urun.comments[i].commentLikes.length; j++) {

                    if ($scope.urun.comments[i].commentLikes[j].LikedId == vazgecenId) {

                        $scope.urun.comments[i].commentLikes.splice(j, 1);
                        $scope.$apply();
                    }

                }
            }
        }
    }


    chat.client.BiriAnaYorumCevabiniBegendi = function (begenenId, begenenTamAdi, anaYorumId, cevapYorumId) {

        for (var i = 0; i < $scope.urun.comments.length; i++) {

            if (anaYorumId == $scope.urun.comments[i].commentId) {

                for (var j = 0; j < $scope.urun.comments[i].commentReplies.length; j++) {

                    if (cevapYorumId == $scope.urun.comments[i].commentReplies[j].commentId) {

                        $scope.urun.comments[i].commentReplies[j].commentLikes.push({ LikedFullName: begenenTamAdi, LikedId: begenenId });
                        $scope.$apply();

                    }
                }
            }

        }
    }
    chat.client.BiriAnaYorumCevabiniBegenmektenVazgecti = function (vazgecenId, anaYorumId, cevapYorumId) {

        var kontrol = 0;

        for (var i = 0; i < $scope.urun.comments.length; i++) {

            if (anaYorumId == $scope.urun.comments[i].commentId) {

                for (var j = 0; j < $scope.urun.comments[i].commentReplies.length; j++) {

                    if (cevapYorumId == $scope.urun.comments[i].commentReplies[j].commentId) {

                        for (var t = 0; t < $scope.urun.comments[i].commentReplies[j].commentLikes.length; t++) {

                            if ($scope.urun.comments[i].commentReplies[j].commentLikes[t].LikedId == vazgecenId) {

                                $scope.urun.comments[i].commentReplies[j].commentLikes.splice(t, 1);

                                kontrol = 1;

                                break;
                            }
                        }
                    }

                    if (kontrol == 1) {
                        break;
                    }
                }
                if (kontrol == 1) {
                    break;
                }
            }
        }

        $scope.$apply();
    }

    $.connection.hub.start().done(function () {

        chat.server.uruneKatil($scope.urun.id);

        $scope.uruneYorumYap = function () {

            var sadeBahsedilenler = []

            for (var i = 0; i < $scope.bahsedilenler.length; i++) {

                sadeBahsedilenler.push($scope.bahsedilenler[i].kim.id);
            }

            chat.server.uruneYorumYap($scope.urun.id, kullanici_id, $scope.urunYorumYazmaYeri, sadeBahsedilenler);


            $scope.bahsedilenler = [];
            $scope.urunYorumYazmaYeri = "";


        }
        $scope.urunYorumunaCevapYap = function (hangiYorum, index) {

            var sadeBahsedilenler = []

            for (var i = 0; i < $scope.yorumYazmaYeri[index].icerik.bahsedilenler.length; i++) {

                sadeBahsedilenler.push($scope.yorumYazmaYeri[index].icerik.bahsedilenler[i].kim.id);
            }


            chat.server.urunYorumunaCevapYap($scope.urun.id, hangiYorum, kullanici_id, $scope.yorumYazmaYeri[index].icerik.mesaj, sadeBahsedilenler);
            $scope.yorumYazmaYeri[index].icerik.mesaj = "";

        }


        $scope.urunAnaYorumCevabiniBegenmektenVazgec = function (yorum, yorumCevap) {

            var kontrol = 0;

            for (var i = 0; i < $scope.begendigimYorumlar.length; i++) {

                if (yorum.commentId == $scope.begendigimYorumlar[i].commentId) {

                    for (var j = 0; j < $scope.begendigimYorumlar[i].cevap.length; j++) {

                        if ($scope.begendigimYorumlar[i].cevap[j].commentId == yorumCevap.commentId) {
                            $scope.begendigimYorumlar[i].cevap[j].deger = false;

                            kontrol = 1;
                            chat.server.urunAnaYorumCevabiniBegenmektenVazgec(kullanici_id, yorum.commentId, yorumCevap.commentId, $scope.urun.id);
                            break;
                        }
                    }
                }

                if (kontrol == 1) {
                    break;
                }
            }

        }
        $scope.urunAnaYorumCevabiniBegen = function (yorum, yorumCevap) {

            var kontrol = 0;

            for (var i = 0; i < $scope.begendigimYorumlar.length; i++) {

                if (yorum.commentId == $scope.begendigimYorumlar[i].commentId) {

                    for (var j = 0; j < $scope.begendigimYorumlar[i].cevap.length; j++) {

                        if ($scope.begendigimYorumlar[i].cevap[j].commentId == yorumCevap.commentId) {
                            $scope.begendigimYorumlar[i].cevap[j].deger = true;

                            kontrol = 1;
                            chat.server.urunAnaYorumCevabiniBegen(kullanici_id, yorum.commentId, yorumCevap.commentId, $scope.urun.id);
                            break;
                        }
                    }
                }

                if (kontrol == 1) {
                    break;
                }
            }
        }


        $scope.anaYorumuBegenmektenVazgec = function (yorum) {

            for (var i = 0; i < $scope.begendigimYorumlar.length; i++) {

                if (yorum.commentId == $scope.begendigimYorumlar[i].commentId) {


                    $scope.begendigimYorumlar[i].deger = false;
                    chat.server.urunAnaYorumBegenmektenVazgec(kullanici_id, yorum.commentId, $scope.urun.id);

                    break;
                }
            }
        }
        $scope.anaYorumuBegen = function (yorum) {

            for (var i = 0; i < $scope.begendigimYorumlar.length; i++) {

                if (yorum.commentId == $scope.begendigimYorumlar[i].commentId) {

                    $scope.begendigimYorumlar[i].deger = true;
                    chat.server.urunAnaYorumBegen(kullanici_id, yorum.commentId, $scope.urun.id);

                    break;
                }
            }

        }

    }).fail(function () {

    });

}]);

app.controller('ProfileCtrl', ['$scope', '$http', '$compile', function ($scope, $http, $compile) {
    var chat = $.connection.messanger;

    $scope.loading = false;
    $scope.profilBilgilerim = profilBilgilerim;
    console.log($scope.profilBilgilerim);

    $scope.AnaSayfa = function () {

        $scope.loading = true;
        $("#profile").html("");

        $http.get("/Profile/Index")
            .then(function (response) {
                $("#profile").html(response.data.PartialView);

                $scope.loading = false;

                $scope.active = "anasayfa";

                $compile($("#profile").contents())($scope);

            });
    }


    $scope.ArkadaslarSayfasi = function () {

        $scope.loading = true;
        $("#profile").html("");

        $http.get("/Profile/ArkadaslariGetir")
            .then(function (response) {
                $("#profile").html(response.data.PartialView);

                $scope.loading = false;

                $scope.active = "arkadaslar";

                $compile($("#profile").contents())($scope);

            });
    }
    $scope.SepetSayfasi = function () {

        $scope.loading = true;
        $("#profile").html("");

        $http.get("/Profile/SepetimiGetir")
            .then(function (response) {
                $("#profile").html(response.data.PartialView);

                $scope.loading = false;

                $scope.active = "sepet";

                $compile($("#profile").contents())($scope);

            });
    }
    $scope.SiparislerSayfasi = function () {

        $scope.loading = true;
        $("#profile").html("");

        $http.get("/Profile/SiparislerimiGetir")
            .then(function (response) {
                $("#profile").html(response.data.PartialView);

                $scope.loading = false;

                $scope.active = "siparisler";

                $compile($("#profile").contents())($scope);

            });
    }
    $scope.AyarlarSayfasi = function () {
        $scope.loading = true;
        $("#profile").html("");

        $http.get("/Profile/Ayarlar")
            .then(function (response) {
                $("#profile").html(response.data.PartialView);

                $scope.loading = false;

                $scope.active = "ayarlar";

                $compile($("#profile").contents())($scope);

            });
    }



    $scope.active = $scope.profilBilgilerim.sekme;

    if ($scope.profilBilgilerim.sekme == "arkadaslar") {
        $scope.ArkadaslarSayfasi();
    }
    else if ($scope.profilBilgilerim.sekme == "siparisler") {
        $scope.SiparislerSayfasi();
    }
    else if ($scope.profilBilgilerim.sekme == "sepet") {
        $scope.SepetSayfasi();
    }





}]);


app.controller('PaylasimlarimCtrl', ['$scope', '$http', function ($scope, $http) {
    var chat = $.connection.messanger;


    console.log(paylasimlarimModel);

}]);


app.controller('ArkadaslarimCtrl', ['$scope', '$http', '$compile', function ($scope, $http, $compile) {

    var chat = $.connection.messanger;
    //ng-repeat="n in [] | range:(friendsCount | number:0)"

    //if($scope.friends.length<=5)
    //{
    //    $scope.friendsCount = 1;
    //}
    //else
    //{
    //    $scope.friendsCount = $scope.friends.length/5;

    //}


    $(document).on('click', '.notifyjs-foo-base .no', function () {
        //programmatically trigger propogating hide event
        $(this).trigger('notify-hide');
    });
    $scope.evet = function (friendId) {

        $(this).trigger('notify-hide');

        $("#arkadas2_" + friendId).notify(
            'Siliniyor...',
            { position: "bottom right", autoHide: false, clickToHide: false, className: "info" }
        );


        var config = {
            method: 'Post',
            url: '/Profile/ArkadasSil',
            params: { SilinecekArkadasId: friendId },
            data: { projectStatus: ["ON"] },
            headers: {
                'Content-Type': 'application/json; charset=utf-8'
            }
        }



        $http(config).then(function (response) {

            if (response.data.IsSuccess = true) {
                $(".notifyjs-bootstrap-info").trigger('notify-hide');

                $("#arkadas2_" + friendId).notify(
                    'Silme Başarılı',
                    { position: "bottom right", autoHide: true, autoHideDelay: 3000, clickToHide: true, className: "success" }
                );

                var myVar = setTimeout(myTimer, 3100);
                function myTimer() {

                    for (var i = 0; i < $scope.friends.length; i++) {

                        if ($scope.friends[i].friendId == friendId) {
                            $scope.friends.splice(i, 1);
                            $scope.$apply();
                            break;
                        }

                    }

                }

                $("#arkadas_" + friendId).remove();//Çevrim içi çevrim dışı yerden silmek için
                chat.server.deleteFriend(friendId);
            }

        }, function (error) {
            console.log(error, 'can not get data.');
        })

        //hide notification

    };


    $scope.friends = arkadaslarimModel.friends;

    $scope.ArkadasSil = function (adSoyad, arkadasId) {




        $.notify.addStyle('foo', {
            html:
                "<div id='notify_" + arkadasId + "'>" +
                "<div class='clearfix'>" +
                "<div class='title' data-notify-html='title'/>" +
                "<div class='buttons'>" +
                "<button class='no'>Vazgeç</button>" +
                "<button class='yes' data-notify-text='button' ng-click=evet('" + arkadasId + "')></button>" +
                "</div>" +
                "</div>" +
                "</div>"
        });


        var h5 = $("<h5 style='color:black;font-weight:700;'/>").append("<span style='color:red'>" + adSoyad + "</span> silmek istediginize emin misiniz?")

        $("#arkadas2_" + arkadasId).notify({
            title: h5,
            button: 'Evet !'
        }, {
                position: "bottom right",
                style: 'foo',
                autoHide: false,
                clickToHide: false
            });


        $compile("#notify_" + arkadasId)($scope);
    }

}]);
app.controller('SepetimCtrl', ['$scope', '$http', '$compile', 'dataShare', function ($scope, $http, $compile, dataShare) {
    var chat = $.connection.messanger;

    if (sepetimModel != null) {

        $scope.Carts = sepetimModel.carts;

        if ($scope.Carts.length == 0 || $scope.Carts == null) {

            $scope.SepetBos = false;

        }
        else {

            $scope.SepetBos = true;
        }

        $scope.ToplamTutar = 0;

        for (var i = 0; i < $scope.Carts.length; i++) {

            $scope.ToplamTutar = $scope.ToplamTutar + ($scope.Carts[i].ProductPrice * $scope.Carts[i].Count);

        }

        $scope.SepetAdediDegisti = function (cartDetailId, productCount) {

            if (productCount != "") {

                $.ajax({

                    method: "POST",
                    url: "/Profile/SepetiGuncelle",
                    data: { cartDetailId: cartDetailId, count: productCount },
                    beforeSend: function () {
                    }
                }).done(function (d) {
                    $.notify("Sepet başarıyla güncellendi", "success");
                    $scope.ToplamTutar = 0;
                    for (var i = 0; i < $scope.Carts.length; i++) {
                        $scope.ToplamTutar = $scope.ToplamTutar + ($scope.Carts[i].ProductPrice * $scope.Carts[i].Count);
                    }
                    $scope.$apply();

                    dataShare.sendData(d, "sepetEkle");

                }).fail(function (d) {
                    alert("Bir hata olustu")
                }).always(function () {

                });
            }

        }

        $scope.SepettenSil = function (cartDetailId) {

            dataShare.sendData(cartDetailId, "sepetSil");

            $scope.ToplamTutar = 0;

            for (var i = 0; i < $scope.Carts.length; i++) {
                if ($scope.Carts[i].id == cartDetailId) {
                    $scope.Carts.splice(i, 1);
                    for (var i = 0; i < $scope.Carts.length; i++) {
                        $scope.ToplamTutar = $scope.ToplamTutar + ($scope.Carts[i].Count * $scope.Carts[i].ProductPrice);

                    }

                    if ($scope.Carts.length == 0) {
                        $scope.SepetBos = false;
                    }

                    $scope.$apply();
                    break;
                }
            }
        }

        $scope.$on('sepetSilAna', function () {

            var gelenData = dataShare.getData();
            $scope.SepettenSil(gelenData);

        });
    }
    else {

        $scope.SepetBos = false;
    }

}]);


app.controller('OylamalarimCtrl', ['$scope', '$http', function ($scope, $http) {

    var chat = $.connection.messanger;
    $scope.Chattekiler = [];//{ id: null, kullaniciAdSoyad: null, profilResmi: null }
    $scope.kullaniciResmi = kullaniciResmi;

    $scope.suankiOylamam;
    $scope.suankiOylamamSayi;


    if (oylamalarimModel != null) {


        $scope.Vote = oylamalarimModel.vote_Sade;
        $scope.Oylamalarim = oylamalarimModel.oylamalarimModels;
        $scope.suankiOylamam = $scope.Vote.id;
        $scope.suankiOylamamSayi = $scope.Oylamalarim.length;

        console.log(oylamalarimModel);

        for (var t = 0; t < $scope.Vote.Chattekiler.length; t++) {
            $scope.Chattekiler.push({ id: $scope.Vote.Chattekiler[t].id, kullaniciAdSoyad: $scope.Vote.Chattekiler[t].Name + " " + $scope.Vote.Chattekiler[t].SurName, profilResmi: $scope.Vote.Chattekiler[t].ProfileImage });
        }

    }
    else {
        $("#mainDiv").remove();
    }


    $scope.OylamaMesajGonder = function () {

        if ($scope.OylamaMesaj != "" && $scope.OylamaMesaj != null) {


            var temiz_bahsedilenler = [];

            for (var i = 0; i < bahsedilenler.length; i++) {
                temiz_bahsedilenler.push(bahsedilenler[i].kim);
            }

            chat.server.oylamaMesajGonder($scope.Vote.OylamaSahibi.id, $scope.Vote.id, $scope.Vote.SessionUserId, $scope.OylamaMesaj, temiz_bahsedilenler);
            bahsedilenler = [];
            $scope.OylamaMesaj = null;
            $("#chatMesajAlani").focus();
        }
    }

    var et_konumlari = [];
    var bahsedilenler = [];
    var son_et_konumu = -1;
    $scope.OylamaMesaj = "";
    $scope.aranan = "xxxxxxxxxxxxxxxxxxxxx";

    $scope.ete_basildimi = function () {

        var donen = eteBasildi({ mesaj: $scope.OylamaMesaj, son_et_konumu: son_et_konumu, et_konumlari: et_konumlari });

        et_konumlari = donen.icerik.et_konumlari;
        son_et_konumu = donen.icerik.son_et_konumu;
        $scope.aranan = donen.icerik.aranan;

    }
    $scope.bahset = function (bahsedilen) {

        bahsedilenler.push({ id: bahsedilenler.length + 1, konum: son_et_konumu, kim: bahsedilen });

        var donen = bahsedildi({ bahsedilenler: bahsedilenler, mesaj: $scope.OylamaMesaj, son_et_konumu: son_et_konumu, et_konumlari: et_konumlari });

        et_konumlari = donen.icerik.et_konumlari;
        son_et_konumu = donen.icerik.son_et_konumu;
        $scope.OylamaMesaj = donen.icerik.mesaj;

        $scope.aranan = "xxxxxxxxxxxxxxxxxxxxxxxxx";

    }
    $('#chatMesajAlani').on('keydown', function (e) {
        var ids = $(this).find('[id]'),
            self = $(this);
        setTimeout(function () {
            ids.each(function () {
                if (!self.find('#' + this.id).length) {
                    var gorelim = $(this).attr("data-id");
                    for (var i = 0; i < bahsedilenler.length; i++) {
                        if (bahsedilenler[i].id == gorelim) {
                            bahsedilenler.splice(i, i + 1);
                        }
                    }
                }
            });
        });
    });

    var oylamaScroll = $("#testDiv_" + $scope.Vote.id);
    var scrollTo_int = oylamaScroll.prop('scrollHeight');
    oylamaScroll.scrollTop(scrollTo_int + 1000);


    $scope.birkere = 0;
    $scope.ChatScrollPosition = function () {

        if ($scope.birkere != 2) {
            var oylamaScroll = $("#testDiv_" + $scope.Vote.id);
            var scrollTo_int = oylamaScroll.prop('scrollHeight');
            oylamaScroll.scrollTop(scrollTo_int + 1000);

            $scope.birkere++;
        }
    }



    chat.client.OylamanizaOyVerildi = function (oylamaId, voteProductId) {

        if ($scope.suankiOylamam == oylamaId) {

            for (var i = 0; i < $scope.Vote.OylamaUrunleri.length; i++) {

                if ($scope.Vote.OylamaUrunleri[i].id == voteProductId) {

                    $scope.Vote.OylamaUrunleri[i].VoteCount++;
                    $scope.$apply();

                    return;
                }
            }

        }

    }
    chat.client.ChateBiriBaglandi = function (baglanan) {

        var kontrol = 0;
        for (var i = 0; i < $scope.viewModel.Chattekiler.length; i++) {

            if ($scope.viewModel.Chattekiler[i].id == baglanan.id) {
                kontrol = 1;
                break;
            }

        }
        if (kontrol == 0) {
            $scope.viewModel.Chattekiler.push(baglanan);
            console.log($scope.viewModel.Chattekiler);
            $scope.$apply();
        }


    }
    chat.client.OylamaMesajGonder = function (mesajModel) {

        var oylamaScroll = $("#testDiv_" + $scope.Vote.id);
        var scrollPosition = oylamaScroll.scrollTop();
        var scrollTo_int = oylamaScroll.prop('scrollHeight');
        var fark = scrollTo_int - scrollPosition;
        if (fark <= 683) {

            $scope.Vote.OylamaMesajlari.push(mesajModel);
            $scope.$apply();

            $("#testDiv_" + $scope.Vote.id).scrollTop(scrollTo_int + 1000);
        }
        else {
            $scope.Vote.OylamaMesajlari.push(mesajModel);
            $scope.$apply();
        }

    }
    chat.client.OylamadanMesalariSil = function (userId, voteId) {

        console.log($scope.Vote);

        for (var i = 0; i < $scope.Vote.OylamaMesajlari.length; i++) {

            if ($scope.Vote.OylamaMesajlari[i].MesajSahibi.id == userId) {
                $scope.Vote.OylamaMesajlari.splice(i, 1);
                i--;
            }

        }

        $scope.$apply();
    }


    $.connection.hub.start().done(function () {
        chat.server.oylamaChatineKatil($scope.Vote.SessionUserId, $scope.Vote.id);

        $scope.OylamaDegis = function (oylamaId, index) {


            $.ajax({

                method: "POST",
                url: "/Oylama/OylamamiGetir",
                data: { oylamaId: oylamaId },
                beforeSend: function () {
                }
            }).done(function (d) {


                chat.server.oylamaChatindenAyril($scope.Vote.SessionUserId, $scope.Vote.id);

                $scope.Vote = d;
                $scope.suankiOylamam = $scope.Vote.id;
                $scope.suankiOylamamSayi = $scope.Oylamalarim.length - index;
                $scope.$apply();

                chat.server.oylamaChatineKatil($scope.Vote.SessionUserId, $scope.Vote.id);




            }).fail(function (d) {
                alert("Bir hata olustu")
            }).always(function () {

            });
        }


    }).fail(function () {

    });
}])



app.controller('CheckoutCtrl', ['$scope', '$http', function ($scope, $http) {


    if (odemeYeriModel != null) {
        if (odemeYeriModel.carts.length != 0) {
            $scope.SepetBos = true;
            $scope.Carts = odemeYeriModel.carts;
            $scope.Adresses = odemeYeriModel.adresses;
            $scope.SepetToplami = 0;

            for (var i = 0; i < $scope.Carts.length; i++) {
                $scope.SepetToplami = $scope.SepetToplami + ($scope.Carts[i].Count * $scope.Carts[i].ProductPrice);
            }

            $scope.InputlariDoldur = function (adress) {

                $scope.adresTitle = adress.AdresBasligi;
                $scope.adress = adress.Adres;
                $("#mahalleAdi").text(adress.Mahalle);
                $("#ilceAdi").text(adress.Ilce);
                $("#sehirAdi").text(adress.Sehir);
                $scope.phoneNumber = adress.TelefonNumarasi;
                $scope.email = adress.Email;
                $scope.name = adress.Isim;
                $scope.surName = adress.Soyisim;

            }


            $scope.seciliAdres;

            if ($scope.Adresses.length == 0) {

                $scope.seciliAdres = 0;
            }
            else {
                $scope.seciliAdres = $scope.Adresses[0].id;
                $scope.InputlariDoldur($scope.Adresses[0]);
            }




            $scope.OdemeyiTamamla = function () {
                var yeniAdres = null;

                if ($scope.seciliAdres == 0) {

                    yeniAdres = {

                        id: $scope.seciliAdres,
                        AdresBasligi: $scope.adresTitle,
                        Adres: $scope.adress,
                        Mahalle: $scope.selected3.NeighborhoodID,
                        Ilce: $scope.selected2.CountyID,
                        Sehir: $scope.selected.CityID,
                        TelefonNumarasi: $scope.phoneNumber,
                        Email: $scope.email,
                        Isim: $scope.name,
                        Soyisim: $scope.surName
                    };
                }
                else {


                    yeniAdres = {

                        id: $scope.seciliAdres,
                    };

                }


                $.ajax({

                    method: "POST",
                    url: "/Gardrop/OdemeyiTamamla",
                    data: { newAdress: yeniAdres },
                    beforeSend: function () {
                    }
                }).done(function (d) {

                    $.notify("Siparişiniz başarıyla gerçekleştirildi. Yönlendiriliyorsunuz.", "success");
                    setTimeout(function () { window.location.href = "/Profile/Index?sekme=siparisler" }, 1000);

                }).fail(function (d) {
                    alert("Bir hata olustu")
                }).always(function () {

                });

            }

            $scope.AdresSec = function (id) {

                if (id == 0) {

                    var yeniAdres = {

                        id: 0,
                        AdresBasligi: "",
                        Adres: "",
                        Mahalle: "-- Mahalle Seç --",
                        Ilce: "-- İlçe Seç --",
                        Sehir: "-- Sehir Seç --",
                        TelefonNumarasi: "",
                        Email: "",
                        Isim: "",
                        Soyisim: ""
                    };

                    $scope.seciliAdres = id;
                    $scope.InputlariDoldur(yeniAdres);
                    return;

                }


                for (var i = 0; i < $scope.Adresses.length; i++) {

                    if ($scope.Adresses[i].id == id) {

                        $scope.seciliAdres = $scope.Adresses[i].id;
                        $scope.InputlariDoldur($scope.Adresses[i]);
                        break;
                    }

                }
            }

        }
    }
    else {
        $scope.SepetBos = false;
    }

    $scope.Sehirler;

    $http.get("/Account/SehirleriGetir")
        .then(function (response) {
            $scope.Sehirler = response.data.Sehirler;

            console.log(response.data);
        });

    $scope.SehirSecildi = function () {

        if ($scope.selected != null) {

            var CityID = $scope.selected.CityID

            var config = {
                headers: {
                    'Content-Type': 'application/x-www-form-urlencoded;charset=utf-8;'
                }
            }

            $http({
                url: '/Account/IlceleriGetir',
                method: "POST",
                data: { CityID: CityID }
            }).then(function onSuccess(response) {
                // Handle success
                $scope.Ilceler = response.data.Ilceler;

                console.log($scope.Ilceler);
            }).catch(function onError(response) {
                // Handle error
                console.log(response);
            });

        }
        else {

        }
    };
    $scope.IlceSecildi = function () {

        if ($scope.selected2 != null) {

            var CountyID = $scope.selected2.CountyID

            var config = {
                headers: {
                    'Content-Type': 'application/x-www-form-urlencoded;charset=utf-8;'
                }
            }

            $http({
                url: '/Account/MahalleleriGetir',
                method: "POST",
                data: { CountyID: CountyID }
            }).then(function onSuccess(response) {
                // Handle success
                $scope.Mahalleler = response.data.Mahalleler;

                console.log($scope.Mahalleler);
            }).catch(function onError(response) {
                // Handle error
                console.log(response);
            });

        }
        else {

        }
    };

}]);



var eteBasildi = function (icerik) {
    var aranan = "xxxxxxxxxxxxxxxxxxxxxxx";
    var yeni_string = decodeEntities(icerik.mesaj);
    var kontrol_boslugu = new String("");

    var deneme = yeni_string.substring(yeni_string.length - 1, yeni_string.length);

    if (deneme == "@") {
        if (yeni_string.length > 2) {

            kontrol_boslugu = yeni_string[yeni_string.length - 2];

            if (kontrol_boslugu == " ") {
                icerik.son_et_konumu = yeni_string.length - 1;
                icerik.et_konumlari.push(yeni_string.length - 1);
            }
        } else {
            icerik.son_et_konumu = yeni_string.length - 1;
            icerik.et_konumlari.push(yeni_string.length - 1);
        }
    }


    if (icerik.son_et_konumu != -1) {
        if (yeni_string.length < icerik.son_et_konumu) {
            icerik.et_konumlari.splice(icerik.et_konumlari.length - 1, icerik.et_konumlari.length);
            if (icerik.et_konumlari.length != 0) {
                icerik.son_et_konumu = icerik.et_konumlari[icerik.et_konumlari.length - 1];
            } else {
                icerik.son_et_konumu = -1;
            }
        } else {
            aranan = yeni_string.substring(icerik.son_et_konumu + 1, yeni_string.length);
            if (aranan == "") {
                aranan = "xxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxx";
            }
        }
    }

    return { icerik: { aranan: aranan, son_et_konumu: icerik.son_et_konumu, et_konumlari: icerik.et_konumlari } };
};
var bahsedildi = function (icerik) {

    var bosluk = "";
    var mesaj = decodeEntities(icerik.mesaj);
    var aranan = "xxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxx";

    var i_kaldigimyer = 0;
    var yeni_mesaj = "";
    for (var j = 0; j < icerik.bahsedilenler.length; j++) {

        if (mesaj.length != 0) {
            for (var i = i_kaldigimyer; i < mesaj.length; i++) {

                if (j == icerik.bahsedilenler.length - 1) {
                    bosluk = "&nbsp";
                }
                else {
                    bosluk = "";
                }

                if (i == icerik.bahsedilenler[j].konum) {
                    yeni_mesaj = yeni_mesaj + '<span style="background-color:yellow" contenteditable="false" id="bahsedilen_' + j + '" data-index="' + icerik.index + '"  data-id="' + icerik.bahsedilenler[j].id + '">' + icerik.bahsedilenler[j].kim.kullaniciAdSoyad + '</span>' + bosluk + '';
                    i_kaldigimyer = i + icerik.bahsedilenler[j].kim.kullaniciAdSoyad.length;
                    break;
                }
                else {
                    yeni_mesaj = yeni_mesaj + mesaj[i];
                }

            }
        }
        else {
            yeni_mesaj = '<span style="background-color:yellow" contenteditable="false" id="bahsedilen_' + j + '" data-index="' + icerik.index + '"  data-id="' + icerik.bahsedilenler[j].id + '">' + icerik.bahsedilenler[j].kim.kullaniciAdSoyad + '</span>&nbsp;';
        }
    }

    icerik.et_konumlari.splice(icerik.et_konumlari.length - 1, icerik.et_konumlari.length);
    if (icerik.et_konumlari.length != 0) {
        icerik.son_et_konumu = icerik.et_konumlari[icerik.et_konumlari.length - 1];
    }
    else {
        icerik.son_et_konumu = -1;
    }


    return { icerik: { mesaj: yeni_mesaj, son_et_konumu: icerik.son_et_konumu, et_konumlari: icerik.et_konumlari } };

}






var decodeEntities = (function () {
    // this prevents any overhead from creating the object each time
    var element = document.createElement('div');

    function decodeHTMLEntities(str) {
        if (str && typeof str === 'string') {
            // strip script/html tags
            str = str.replace(/<script[^>]*>([\S\s]*?)<\/script>/gmi, '');
            str = str.replace(/<\/?\w(?:[^"'>]|"[^"]*"|'[^']*')*>/gmi, '');
            element.innerHTML = str;
            str = element.textContent;
            element.textContent = '';
        }

        return str;
    }

    return decodeHTMLEntities;
})();

app.directive('contenteditable', function () { //chat alanına yazı yazılınca ng change çalışsın diye
    return {
        require: 'ngModel',
        restrict: 'A',
        link: function (scope, elm, attr, ngModel) {

            function updateViewValue() {
                ngModel.$setViewValue(this.innerHTML);
            }

            //Or bind it to any other events
            elm.on('keyup', updateViewValue);

            scope.$on('$destroy', function () {
                elm.off('keyup', updateViewValue);
            });

            ngModel.$render = function () {
                elm.html(ngModel.$viewValue);
            }

        }
    }
});

app.filter('trustAsHtml', ['$sce', function ($sce) {
    return function (text) {
        return $sce.trustAsHtml(text);
    };
}]);

app.filter('trustAsHtmlBahsedilme', function () {
    return function (text) {

        var yeni_string = decodeEntities(text);

        return yeni_string.substring(0, 27) + "...";
    };
});

app.factory('dataShare', function ($rootScope) {
    var service = {};
    service.data = false;
    service.sendData = function (data, dataName) {
        this.data = data;
        $rootScope.$broadcast(dataName);
    };
    service.getData = function () {
        return this.data;
    };
    return service;
});

Array.prototype.insert = function (index, item) {
    this.splice(index, 0, item);
};

app.filter("mydate", function () {
    var re = /\/Date\(([0-9]*)\)\//;
    return function (x) {
        var m = x.match(re);
        if (m) return new Date(parseInt(m[1]));
        else return x;
    };
});




var renkler = [
    { id: 0, renk: "Beyaz" },
    { id: 1, renk: "Siyah" },
    { id: 2, renk: "Yeşil" },
    { id: 3, renk: "Kırmızı" },
    { id: 4, renk: "Sarı" }
]

angular.module('checklist-model', [])
    .directive('checklistModel', ['$parse', '$compile', function ($parse, $compile) {
        // contains
        function contains(arr, item, comparator) {
            if (angular.isArray(arr)) {
                for (var i = arr.length; i--;) {
                    if (comparator(arr[i], item)) {
                        return true;
                    }
                }
            }
            return false;
        }

        // add
        function add(arr, item, comparator) {
            arr = angular.isArray(arr) ? arr : [];
            if (!contains(arr, item, comparator)) {
                arr.push(item);
            }
            return arr;
        }

        // remove
        function remove(arr, item, comparator) {
            if (angular.isArray(arr)) {
                for (var i = arr.length; i--;) {
                    if (comparator(arr[i], item)) {
                        arr.splice(i, 1);
                        break;
                    }
                }
            }
            return arr;
        }

        // http://stackoverflow.com/a/19228302/1458162
        function postLinkFn(scope, elem, attrs) {
            // exclude recursion, but still keep the model
            var checklistModel = attrs.checklistModel;
            attrs.$set("checklistModel", null);
            // compile with `ng-model` pointing to `checked`
            $compile(elem)(scope);
            attrs.$set("checklistModel", checklistModel);

            // getter / setter for original model
            var getter = $parse(checklistModel);
            var setter = getter.assign;
            var checklistChange = $parse(attrs.checklistChange);
            var checklistBeforeChange = $parse(attrs.checklistBeforeChange);

            // value added to list
            var value = attrs.checklistValue ? $parse(attrs.checklistValue)(scope.$parent) : attrs.value;


            var comparator = angular.equals;

            if (attrs.hasOwnProperty('checklistComparator')) {
                if (attrs.checklistComparator[0] == '.') {
                    var comparatorExpression = attrs.checklistComparator.substring(1);
                    comparator = function (a, b) {
                        return a[comparatorExpression] === b[comparatorExpression];
                    };

                } else {
                    comparator = $parse(attrs.checklistComparator)(scope.$parent);
                }
            }

            // watch UI checked change
            scope.$watch(attrs.ngModel, function (newValue, oldValue) {
                if (newValue === oldValue) {
                    return;
                }

                if (checklistBeforeChange && (checklistBeforeChange(scope) === false)) {
                    scope[attrs.ngModel] = contains(getter(scope.$parent), value, comparator);
                    return;
                }

                setValueInChecklistModel(value, newValue);

                if (checklistChange) {
                    checklistChange(scope);
                }
            });

            function setValueInChecklistModel(value, checked) {
                var current = getter(scope.$parent);
                if (angular.isFunction(setter)) {
                    if (checked === true) {
                        setter(scope.$parent, add(current, value, comparator));
                    } else {
                        setter(scope.$parent, remove(current, value, comparator));
                    }
                }

            }

            // declare one function to be used for both $watch functions
            function setChecked(newArr, oldArr) {
                if (checklistBeforeChange && (checklistBeforeChange(scope) === false)) {
                    setValueInChecklistModel(value, scope[attrs.ngModel]);
                    return;
                }
                scope[attrs.ngModel] = contains(newArr, value, comparator);
            }

            // watch original model change
            // use the faster $watchCollection method if it's available
            if (angular.isFunction(scope.$parent.$watchCollection)) {
                scope.$parent.$watchCollection(checklistModel, setChecked);
            } else {
                scope.$parent.$watch(checklistModel, setChecked, true);
            }
        }

        return {
            restrict: 'A',
            priority: 1000,
            terminal: true,
            scope: true,
            compile: function (tElement, tAttrs) {
                if ((tElement[0].tagName !== 'INPUT' || tAttrs.type !== 'checkbox') && (tElement[0].tagName !== 'MD-CHECKBOX') && (!tAttrs.btnCheckbox)) {
                    throw 'checklist-model should be applied to `input[type="checkbox"]` or `md-checkbox`.';
                }

                if (!tAttrs.checklistValue && !tAttrs.value) {
                    throw 'You should provide `value` or `checklist-value`.';
                }

                // by default ngModel is 'checked', so we set it if not specified
                if (!tAttrs.ngModel) {
                    // local scope var storing individual checkbox model
                    tAttrs.$set("ngModel", "checked");
                }

                return postLinkFn;
            }
        };
    }]);
app.filter('search', function () {
    return function (list, query, fields) {

        if (!query) {
            return list;
        }

        query = query.toLowerCase().split(' ');

        if (!angular.isArray(fields)) {
            fields = [fields.toString()];
        }

        return list.filter(function (item) {
            return query.every(function (needle) {
                return fields.some(function (field) {
                    var content = item[field] != null ? item[field] : '';

                    if (!angular.isString(content)) {
                        content = '' + content;
                    }

                    return content.toLowerCase().indexOf(needle) > -1;
                });
            });
        });
    };
});

app.filter('range', function () {
    return function (input, total) {
        total = parseInt(total);
        for (var i = 0; i < total; i++)
            input.push(i);
        return input;
    };
});



function functiontofindIndexByKeyValue(arraytosearch, key, valuetosearch) {

    for (var i = 0; i < arraytosearch.length; i++) {

        if (arraytosearch[i][key] == valuetosearch) {
            return i;
        }
    }
    return null;
}