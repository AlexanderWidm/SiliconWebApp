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
catch { }