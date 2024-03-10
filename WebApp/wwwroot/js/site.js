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

