let swiper = new Swiper(".mySwiper", {
  slidesPerView: "auto",
  autoplay: {
    delay: 2000,
  },
  spaceBetween: 30,
  pagination: {
    el: ".swiper-pagination",
    clickable: true,
  },
});

var swiperVideo = new Swiper(".mySwiperVideo", {
  pagination: {
    el: ".swiper-pagination",
    type: "fraction",
  },
  navigation: {
    nextEl: ".swiper-button-next",
    prevEl: ".swiper-button-prev",
  },
  spaceBetween: 30,
});
