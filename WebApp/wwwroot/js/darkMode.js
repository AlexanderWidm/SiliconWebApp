function toggleTheme() {
    const body = document.body;
    const currentTheme = body.getAttribute('data-theme');
    const logoImage = document.querySelector('.logo img');
    const errorImage = document.getElementById('error-image');

    if (currentTheme === 'dark') {
        body.setAttribute('data-theme', 'light');
        localStorage.setItem('theme', 'light');
      
        logoImage.src = '/images/logos/silicon-logo.svg';
        errorImage.src = '/images/logos/404.svg';
    } else {
        body.setAttribute('data-theme', 'dark');
        localStorage.setItem('theme', 'dark');

        logoImage.src = '/images/logos/silicon-logo-dark.svg';
        errorImage.src = '/images/logos/404-dark.svg';
    }
}

document.addEventListener('DOMContentLoaded', (event) => {
    const savedTheme = localStorage.getItem('theme');
    const logoImage = document.querySelector('.logo img');

    document.body.setAttribute('data-theme', savedTheme ? savedTheme : 'light');

    if (savedTheme === 'dark') {
        document.getElementById('theme-switch-mode').checked = true;
  
        logoImage.src = '/images/logos/silicon-logo-dark.svg';

    } else {

        logoImage.src = '/images/logos/silicon-logo.svg';
    }
});



document.getElementById('theme-switch-mode').addEventListener('change', toggleTheme);


