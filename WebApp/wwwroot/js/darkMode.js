function toggleTheme() {
    const body = document.body;
    const currentTheme = body.getAttribute('data-theme');
    const logoImage = document.querySelector('.logo img');
    const errorImage = document.getElementById('error-image');
    try {
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
    } catch { }
}

document.addEventListener('DOMContentLoaded', (event) => {
    const savedTheme = localStorage.getItem('theme');
    const logoImage = document.querySelector('.logo img');
    const errorImage = document.getElementById('error-image'); 

    document.body.setAttribute('data-theme', savedTheme ? savedTheme : 'light');
    try {
        if (savedTheme === 'dark') {
            document.getElementById('theme-switch-mode').checked = true;

            logoImage.src = '/images/logos/silicon-logo-dark.svg';
            errorImage.src = '/images/logos/404-dark.svg';

        } else {

            logoImage.src = '/images/logos/silicon-logo.svg';
            errorImage.src = '/images/logos/404.svg';
        }
    } catch { }
});



document.getElementById('theme-switch-mode').addEventListener('change', toggleTheme);


