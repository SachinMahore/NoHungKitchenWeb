$(window).scroll(function(){
    var sticky = $('.sticky'),
        scroll = $(window).scrollTop();
  
    if (scroll >= 100) sticky.addClass('fixedHeader');
    else sticky.removeClass('fixedHeader');
  });

  $(document).ready(function (){
      $(".toggleButton").click(function (){
          $(".mobile_menus ul").toggleClass("mobile_menusToggle")
      });
  });

  $(document).ready(function (){
    $("#closedMenes").click(function (){
        $(".mobile_menus ul").toggleClass("mobile_menusToggle")
    });
});


  