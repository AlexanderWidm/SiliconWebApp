// Get the theme preference from localStorage
const currentTheme = localStorage.getItem('theme');

// Get the error image element
const errorImage = document.getElementById('error-image');

// Check the theme preference and set the image source accordingly
if (currentTheme === 'dark') {
    errorImage.src = '/images/logos/404-dark.svg';
} else {
    errorImage.src = '/images/logos/404.svg';
}