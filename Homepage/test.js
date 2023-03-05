const sliderImages = document.querySelectorAll('.slider-image');

window.addEventListener('scroll', () => {
  sliderImages.forEach(image => {
    const slideInAt = (window.scrollY + window.innerHeight) - image.offsetHeight / 2;
    const imageBottom = image.offsetTop + image.offsetHeight;
    const isHalfShown = slideInAt > image.offsetTop;
    const isNotScrolledPast = window.scrollY < imageBottom;

    if (isHalfShown && isNotScrolledPast) {
      image.classList.add('active');
    } else {
      image.classList.remove('active');
    }
  });
});