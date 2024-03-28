document.addEventListener('DOMContentLoaded', function () {
    const featuresLink = document.getElementById('featuresLink');

    featuresLink.addEventListener('click', function (e) {
        const isHomePage = window.location.pathname === '/';
        const toolSectionExists = document.querySelector('#toolSection');

        if (isHomePage && toolSectionExists) {

            e.preventDefault();


            toolSectionExists.scrollIntoView({
                behavior: 'smooth'
            });
        } else if (!isHomePage) {
         
            window.location.href = '/#toolSection';
        }
       
    });


    if (window.location.hash && isHomePage) {
        const hashSection = document.querySelector(window.location.hash);
        if (hashSection) {
            setTimeout(() => {
                hashSection.scrollIntoView({
                    behavior: 'smooth'
                });
            }, 100); 
        }
    }
});
