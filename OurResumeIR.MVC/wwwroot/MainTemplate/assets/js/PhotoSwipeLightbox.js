// Include Lightbox
import PhotoSwipeLightbox from "/assets/node_modules/photoswipe/dist/photoswipe-lightbox.esm.js";

const lightbox = new PhotoSwipeLightbox({
  // may select multiple "galleries"
  gallery: "#gallery--getting-started",

  // Elements within gallery (slides)
  children: "a",

  // setup PhotoSwipe Core dynamic import
    pswpModule: () => import("/assets/node_modules/photoswipe/dist/photoswipe.esm.js"),
});
lightbox.init();
