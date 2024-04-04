document.addEventListener("DOMContentLoaded", () => {
    let btnMobile = document.querySelector('.btn-mobile');
    let nav = document.querySelector('nav');
    let featuresLink = document.getElementById('featuresLink');
    let icon = btnMobile.querySelector('i');


    function toggleMenuIcon() {
        if (icon.classList.contains('fa-bars')) {
            icon.classList.remove('fa-bars');
            icon.classList.add('fa-times');
        } else {
            icon.classList.remove('fa-times');
            icon.classList.add('fa-bars');
        }

        btnMobile.classList.toggle('active');
        btnMobile.classList.toggle('collapsed');
    }


    btnMobile.addEventListener('click', () => {
        nav.classList.toggle('active');
        toggleMenuIcon(); 
    });


    window.addEventListener('resize', () => {
        if (nav.classList.contains('active')) {
            nav.classList.remove('active');
       
            icon.classList.remove('fa-times');
            icon.classList.add('fa-bars');
   
            btnMobile.classList.remove('active');
            btnMobile.classList.remove('collapsed');
        }
    });


    featuresLink.addEventListener('click', () => {
        if (nav.classList.contains('active')) {
            nav.classList.remove('active');

            if (icon.classList.contains('fa-times')) {
                toggleMenuIcon();
            }
        }
    });
});

document.addEventListener("DOMContentLoaded", function () {

    var featuresLink = document.getElementById('featuresLink');


    function toggleHamburgerMenu() {

        var navMenu = document.querySelector('nav');
        if (navMenu.classList.contains('active')) {
            navMenu.classList.remove('active');
        }
    }


    featuresLink.addEventListener('click', function () {
        toggleHamburgerMenu();
    });
});