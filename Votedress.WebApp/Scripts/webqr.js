// QRCODE reader Copyright 2011 Lazar Laszlo
// http://www.webqr.com

var gCtx = null;
var gCanvas = null;
var c=0;
var stype=0;
var gUM=false;
var webkit=false;
var moz=false;
var v=null;

var imghtml='<div id="qrfile"><canvas id="out-canvas" width="470" height="352"></canvas>'+
    '<div id="imghelp">drag and drop a QRCode here'+
	'<br>or select a file'+
	'<input type="file" onchange="handleFiles(this.files)"/>'+
	'</div>'+
'</div>';

var vidhtml = '<video id="v" autoplay></video>';

function dragenter(e) {
  e.stopPropagation();
  e.preventDefault();
}

function dragover(e) {
  e.stopPropagation();
  e.preventDefault();
}
function drop(e) {
  e.stopPropagation();
  e.preventDefault();

  var dt = e.dataTransfer;
  var files = dt.files;
  if(files.length>0)
  {
	handleFiles(files);
  }
  else
  if(dt.getData('URL'))
  {
	qrcode.decode(dt.getData('URL'));
  }
}

function handleFiles(f)
{
	var o=[];
	
	for(var i =0;i<f.length;i++)
	{
        var reader = new FileReader();
        reader.onload = (function(theFile) {
        return function(e) {
            gCtx.clearRect(0, 0, gCanvas.width, gCanvas.height);

			qrcode.decode(e.target.result);
        };
        })(f[i]);
        reader.readAsDataURL(f[i]);	
    }
}

function initCanvas(w,h)
{
    gCanvas = document.getElementById("canvas");
    gCanvas.style.width = w + "px";
    gCanvas.style.height = h + "px";
    gCanvas.width = w;
    gCanvas.height = h;
    gCtx = gCanvas.getContext("2d");
    gCtx.clearRect(0, 0, w, h);
}


function captureToCanvas() {
    if(stype!=1)
        return;
    if(gUM)
    {
        try{
            gCtx.drawImage(v,0,0);
            try{
                qrcode.decode();
            }
            catch(e){       
                console.log(e);
                setTimeout(captureToCanvas, 20);
            };
        }
        catch(e){       
                console.log(e);
                setTimeout(captureToCanvas, 20);
        };
    }
}

function htmlEntities(str) {
    return String(str).replace(/&/g, '&amp;').replace(/</g, '&lt;').replace(/>/g, '&gt;').replace(/"/g, '&quot;');
}

var karekodlar = new Array(4);


var okunan;
var urunIdGlobal;
function read(a)
{
    var string = a,
        arr = string.split('|'),
        i;

    $("#kareKodOkuma").modal("hide");


    $.ajax({

        method: "POST",
        url: "/Gardrop/UrunBilgisiGetir",
        data: { id: arr[0] },
        beforeSend: function () {
        }
    }).done(function (d) {

        if (d.IsSuccess) {

            var categoryHtml = "";

            for (var i = 0; i < d.urunBilgisi.productCategory.length; i++) {

                categoryHtml = categoryHtml + '<p class="product-drisc"> ' + d.urunBilgisi.productCategory[i].productCategoryName + '</p>';

            }

            var urunhtml = '<div class="col-md-12">' +
                '<div class="product-box hover-circle text-center">' +
                '<div class="product-item">' +
                '<figure><img src="'+d.urunBilgisi.productImage+'" class="img-responsive" alt="product"></figure>' +
                '<h3 class="product-title">' + d.urunBilgisi.productName+'</h3>' +
                '<h4 class="product-price">Fiyat : ' + d.urunBilgisi.productPrice+' ₺</h4>' +
                '<p class="product-drisc">' + d.urunBilgisi.productDescription + '</p>' + categoryHtml +
                '<br />' +
                '</div>' +
                '</div>' +
                '</div>';


            $("#" + okunan).addClass("hidden");
            $("#" + okunan + "_Urun").append(urunhtml);

        }


    }).fail(function (d) {
        alert("Bir hata olustu")
    }).always(function () {

    });




    var audio = new Audio('/Content/beep.ogg');
    audio.play();


    //$("#qrcode").css("display", "none");
    //$("#barkod_okundumu_" + rengidegistir).css("color", "green");
    //$("#barkod_okundumu_" + rengidegistir).attr("data-durum", "okundu");



    //document.getElementById("mapo").innerHTML = "<b><u>Mã PO:</u> " + arr[0] + "</b>";
    $("#mapo1").append('<input id="urun_' + urunIdGlobal + '" name="urun_' + urunIdGlobal + '" value="' + arr[0] + '">');
    //karekodlar[rengidegistir] = arr[0];



    
}	

function isCanvasSupported(){
  var elem = document.createElement('canvas');
  return !!(elem.getContext && elem.getContext('2d'));
}
var myStream;
function success(stream) {
    v.src = window.URL.createObjectURL(stream);
    gUM=true;
    setTimeout(captureToCanvas, 20);
    myStream = stream;
}
function stop()	{
   var track = myStream.getTracks()[0];  // if only one media track
// ...
track.stop();
}

function error(error) {
    gUM=false;
    return;
}

function load(id, urunId)
{
	if(isCanvasSupported() && window.File && window.FileReader)
    {
        $("#kareKodOkuma").modal();

        urunIdGlobal = urunId;
        okunan = id;

	    $("#qrcode").css("display", "");
		initCanvas(800, 600);
		qrcode.callback = read;
		document.getElementById("mainbody").style.display="inline";
        setwebcam();
        // Custom video filters
        //    var iFilter = 0;
        //    var filters = [
        //        'grayscale',
        //        'sepia',
        //        'blur',
        //        'brightness',
        //        'contrast',
        //        'hue-rotate',
        //        'hue-rotate2',
        //        'hue-rotate3',
        //        'saturate',
        //        'invert',
        //        'none'
        //    ];
        // v.className = '';
        // canvas.className = '';
        // // var effect = filters[iFilter++ % filters.length]; // Loop through the filters.
        // // if (effect) {
        //     v.classList.add('invert');
        //     canvas.classList.add('invert');
	}
	else
	{
		document.getElementById("mainbody").style.display="inline";
		document.getElementById("mainbody").innerHTML='<p id="mp1">QR code scanner for HTML5 capable browsers</p><br>'+
        '<br><p id="mp2">sorry your browser is not supported</p><br><br>'+
        '<p id="mp1">try <a href="http://www.mozilla.com/firefox"><img src="firefox.png"/></a> or <a href="http://chrome.google.com"><img src="chrome_logo.gif"/></a> or <a href="http://www.opera.com"><img src="Opera-logo.png"/></a></p>';
	}
}

function setwebcam()
{
    document.getElementById("mapo").innerHTML="";
    document.getElementById("mact").innerHTML="";
	document.getElementById("soluong").innerHTML="";
    if(stype==1)
    {
        setTimeout(captureToCanvas, 20);    
        return;
    }
    
    var n=navigator;
    document.getElementById("outdiv").innerHTML = vidhtml;
    v=document.getElementById("v");

    if(n.getUserMedia)
        n.getUserMedia({video: true, audio: false}, success, error);
    else
    if(n.mediaDevices.getUserMedia)
        n.mediaDevices.getUserMedia({video: { facingMode: "environment"} , audio: false})
            .then(success)
            .catch(error);
    else
    if(n.webkitGetUserMedia)
    {
        webkit=true;
        n.webkitGetUserMedia({video:true, audio: false}, success, error);
    }
    else
    if(n.mozGetUserMedia)
    {
        moz=true;
        n.mozGetUserMedia({video: true, audio: false}, success, error);
    }
   

        
    // }x
    //document.getElementById("qrimg").src="qrimg2.png";
    //document.getElementById("webcamimg").src="webcam.png";
    document.getElementById("qrimg").style.opacity=0.2;
    document.getElementById("webcamimg").style.opacity=1.0;

    stype=1;
    setTimeout(captureToCanvas, 20);
}
function setimg()
{
	document.getElementById("result").innerHTML="";
    if(stype==2)
        return;
    document.getElementById("outdiv").innerHTML = imghtml;
    //document.getElementById("qrimg").src="qrimg.png";
    //document.getElementById("webcamimg").src="webcam2.png";
    document.getElementById("qrimg").style.opacity=1.0;
    document.getElementById("webcamimg").style.opacity=0.2;
    var qrfile = document.getElementById("qrfile");
    qrfile.addEventListener("dragenter", dragenter, false);  
    qrfile.addEventListener("dragover", dragover, false);  
    qrfile.addEventListener("drop", drop, false);
    stype=2;
}
