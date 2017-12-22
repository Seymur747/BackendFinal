$(document).ready(function(){
    
  //MENU OPEN
  new WOW().init();
      $('.wrapper div').addClass('wow fadeIn');
      $('header div').removeClass('wow fadeIn');

      $(".offset-trigger").click(function(){
    $("#sidebar-wrapper").removeClass("dis-active");
    $("#sidebar-wrapper").addClass("online");
  });

  $(".close").click(function(){
     $("#sidebar-wrapper").removeClass("online");
     $("#sidebar-wrapper").addClass("dis-active");
  });


      //VIDEOCAROUSEL

      $('.video-list').css('height', $('.video-container').height() - 59);
    $('.video-list ul').css('height', $('.video-container').height() - 59);

    $('.video-play').on('click', function() {
        if ($("video").get(0).paused) {
            $("video").get(0).play();
        } else {
            $("video").get(0).pause();
        }
    });

    $('video').on('click', function() {
        if ($(this).get(0).paused) {
            $(this).get(0).play();
        } else {
            $(this).get(0).pause();
        }
    });

    $('.video-play').on('click', function() {
        $("video").addClass("active");
    });

    $('.vl-video1').on('click', function() {
        $("video").attr("src", "video/01.mp4");
        $(".now-playing p").html("Avtobusda sernişin sürücü ilə dava etdi <span>20:45</span>");
        $(".vc-item2, .vc-item3, .vc-item4, .vc-item5").removeClass("active");
        $(".vc-item1").addClass("active");

        var $this = $("video").removeClass('active');
        window.setTimeout(function() {
            $this.addClass('active');

            if ($("video").get(0).paused) {
                $("video").get(0).play();
            } else {
                $("video").get(0).pause();
            }

        }, 2500);
    });

    $('.vl-video2').on('click', function() {
        $("video").attr("src", "video/02.mp4");
        $(".now-playing p").html("Ünvanlı sosial yardım artılacaq <span>18:35</span>");
        $(".vc-item1, .vc-item3, .vc-item4, .vc-item5").removeClass("active");
        $(".vc-item2").addClass("active");

        var $this = $("video").removeClass('active');
        window.setTimeout(function() {
            $this.addClass('active');

            if ($("video").get(0).paused) {
                $("video").get(0).play();
            } else {
                $("video").get(0).pause();
            }

        }, 2500);
    });

    $('.vl-video3').on('click', function() {
        $("video").attr("src", "video/03.mp4");
        $(".now-playing p").html("Yeni ana olan mugennni ƏRİ VƏ ÖVLADI İLƏ- Shou biznes <span>11:20</span>");
        $(".vc-item1, .vc-item2, .vc-item4, .vc-item5").removeClass("active");
        $(".vc-item3").addClass("active");
        var $this = $("video").removeClass('active');
        window.setTimeout(function() {
            $this.addClass('active');

            if ($("video").get(0).paused) {
                $("video").get(0).play();
            } else {
                $("video").get(0).pause();
            }

        }, 2500);
    });

    $('.vl-video4').on('click', function() {
        $("video").attr("src", "video/04.mp4");
        $(".now-playing p").html("İrana gedənlər məcburi sığortalanacaqlar I Xezer Xeber <span>15:25</span>");
        $(".vc-item1, .vc-item2, .vc-item3, .vc-item5").removeClass("active");
        $(".vc-item4").addClass("active");
        var $this = $("video").removeClass('active');
        window.setTimeout(function() {
            $this.addClass('active');

            if ($("video").get(0).paused) {
                $("video").get(0).play();
            } else {
                $("video").get(0).pause();
            }

        }, 2500);
    });

    $('.vl-video4').on('click', function() {
        $("video").attr("src", "video/04.mp4");
        $(".now-playing p").html("İrana gedənlər məcburi sığortalanacaqlar I Xezer Xeber <span>15:25</span>");
        $(".vc-item1, .vc-item2, .vc-item3, .vc-item5").removeClass("active");
        $(".vc-item4").addClass("active");
        var $this = $("video").removeClass('active');
        window.setTimeout(function() {
            $this.addClass('active');

            if ($("video").get(0).paused) {
                $("video").get(0).play();
            } else {
                $("video").get(0).pause();
            }

        }, 2500);
    });


//SLIDER
    $('#owl-one').owlCarousel({
        loop:true,
        margin:30,
        dots:true,
        mouseDrag:true, 
        autoplay:true,
      items:1,
    });
    $('#owl-two').owlCarousel({
        loop:true,
        margin:10,
        mouseDrag:true,    
        autoplay:true,
        items:3,
    });
    $('#owl-three').owlCarousel({
        loop:true,
        margin:10,
        mouseDrag:true,    
        autoplay:true,
        items:1,
    });

    $('.animate').addClass('animated fadeInUp');
});


  //breaking slider
  var textArray = [
  'Ratione deserunt, facere odio, labore recusandae debitis amet consectetur',
  'Consectetur dicta cupiditate recusandae asperiores placeat quae',
  'At perferendis magnam rem tenetur, officia doloremque aspernatur ut. Nulla ',
  ];
  var sampleText = document.getElementById('dynamicText');
  var indexi = 0;

  function slideNext () {
  	indexi++;
  	sampleText.style.opacity = 0;
  	if(indexi > textArray.length - 1) {
  		indexi = 0;
  	}
  	setTimeout('slideShow()', 1000);
  }

  function slideShow () {
  	sampleText.innerHTML = textArray[indexi];
  	sampleText.style.opacity = 0.4;
  	setTimeout('slideNext()', 2000);
  }
slideShow();
