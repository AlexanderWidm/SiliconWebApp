document.addEventListener('DOMContentLoaded', function () {
    try {
        const featuresLink = document.getElementById('featuresLink');


        if (featuresLink) {
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
        }


        const isHomePage = window.location.pathname === '/';

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
    } catch (error) {
        console.error("An error occurred:", error);
    }
});