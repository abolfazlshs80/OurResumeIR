// lightGallery(document.querySelector("#lightgallery"), {
//   mode: "lg-fade",
//   cssEasing: "cubic-bezier(0.25, 0, 0.25, 1)",
// });

let elements = document.getElementsByClassName("image_gallery");
for (let item of elements) {
  lightGallery(item, {
    share: false,
    mode: "lg-fade",
    cssEasing: "cubic-bezier(0.25, 0, 0.25, 1)",
  });
}
