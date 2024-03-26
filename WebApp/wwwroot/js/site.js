document.addEventListener("DOMContentLoaded", ()=> {
    let btnMobile = document.querySelector('.btn-mobile')
    let nav = document.querySelector('nav')

    btnMobile.addEventListener('click', () => {
        btnMobile.classList.toggle('active')
        btnMobile.classList.toggle('collapsed')

        nav.classList.toggle('active')
    })

    window.addEventListener('resize', () => {
        btnMobile.classList.remove('active')
        btnMobile.classList.remove('collapsed')

        nav.classList.remove('active')
    })
})

document.addEventListener("DOMContentLoaded", () => {
    let btnMobile = document.querySelector('.btn-mobile');
    let icon = btnMobile.querySelector('i');

    btnMobile.addEventListener('click', () => {
        if (icon.classList.contains('fa-bars')) {
            icon.classList.remove('fa-bars');
            icon.classList.add('fa-times');
        } else {
            icon.classList.remove('fa-times');
            icon.classList.add('fa-bars');
        }
    });
});

const emailInput = document.getElementById('mail-letter');
const mailIcon = document.getElementById('mail-icon');

try {
    emailInput.addEventListener('input', () => {

        if (emailInput.value.length > 0) {
            mailIcon.style.display = 'none';
        }
        else {
            mailIcon.style.display = 'inline';
        }
    });

    function focusOnFullName() {
        document.getElementById('fullNameInput').focus();
    };
}
catch {

}


function initMap() {
    const options = {
        center: { lat: 37.73418426513672, lng: -122.4065170288086 },
        zoom: 16
    };

    map = new google.maps.Map(document.getElementById("map"), options);
}


function toggleTheme() {
    const body = document.body;
    const currentTheme = body.getAttribute('data-theme');
    const logoImage = document.querySelector('.logo img');

    if (currentTheme === 'dark') {
        body.setAttribute('data-theme', 'light');
        localStorage.setItem('theme', 'light');
      
        logoImage.src = '/images/logos/silicon-logo.svg';
    } else {
        body.setAttribute('data-theme', 'dark');
        localStorage.setItem('theme', 'dark');

        logoImage.src = '/images/logos/silicon-logo-dark.svg';
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
