document.addEventListener('DOMContentLoaded', function () {
    const featuresLink = document.getElementById('featuresLink');

    featuresLink.addEventListener('click', function (e) {
  
        if (window.location.pathname === '/') {
     
            e.preventDefault();

         
            const section = document.querySelector('#toolSection');
            if (section) {
                section.scrollIntoView({
                    behavior: 'smooth'
                });
            }
        } 
    });


    if (window.location.hash) {
        const sectionToScrollTo = document.querySelector(window.location.hash);
        if (sectionToScrollTo) {
            setTimeout(() => {
                sectionToScrollTo.scrollIntoView({
                    behavior: 'smooth'
                });
            }, 0); 
        }
    }
});