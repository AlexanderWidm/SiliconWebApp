document.addEventListener('DOMContentLoaded', function () {
    let forms = document.querySelectorAll('form');

    forms.forEach(form => {
        let inputs = form.querySelectorAll('input');

        inputs.forEach(input => {
            if (input.dataset.val === 'true') {
                input.addEventListener('keyup', (e) => {
                    switch (e.target.type) {
                        case 'text':
                            textValidation(e, e.target.dataset.valMinlengthMin)
                            break
                        case 'email':
                            emailValidation(e)
                            break
                        case 'password':
                            passwordValidation(e)
                            break
                        case 'tel':
                            phoneValidation(e)
                            break
                    }
                })
            }
        })
    });
});

const handleValidationOutput = (isValid, e, text = "") => {
    let span = document.querySelector(`[data-valmsg-for="${e.target.name}"]`)

    if (isValid) {
        e.target.classList.remove('input-validation-error')
        span.classList.remove('field-validation-error')
        span.classList.add('field-valid')
        span.innerHTML = ""

    } else {
        e.target.classList.add('input-validation-error')
        span.classList.add('field-validation-error')
        span.classList.remove('field-valid')
        span.innerHTML = text
    }
}



const textValidation = (e, minLength = 1) => {
    if (e.target.value.length > 0)
        handleValidationOutput(e.target.value.length >= minLength, e, e.target.dataset.valMinlength)
    else
        handleValidationOutput(false, e, e.target.dataset.valRequired)
}

const emailValidation = (e) => {
    const regEx = /^[a-zA-Z0-9.!#$%&'*+/=?^_`{|}~-]+@[a-zA-Z0-9](?:[a-zA-Z0-9-]{0,61}[a-zA-Z0-9])?(?:\.[a-zA-Z0-9](?:[a-zA-Z0-9-]{0,61}[a-zA-Z0-9])?)*\.[a-zA-Z]{2,}$/

    if (e.target.value.length > 0)
        handleValidationOutput(regEx.test(e.target.value), e, e.target.dataset.valRegex)
    else
        handleValidationOutput(false, e, e.target.dataset.valRequired)
}

const passwordValidation = (e) => {
    const passwordRegEx = /^(?=.*[0-9])(?=.*[a-z])(?=.*[A-Z])(?=.*[\W_])(?!.*\s).{8,}$/
    let isValidPassword = passwordRegEx.test(e.target.value)
    handleValidationOutput(isValidPassword, e, e.target.dataset.valRegex)

    if (e.target.name === 'ConfirmPassword') {
        let passwordInputSelector = e.target.dataset.valEqualtoOther
        let passwordInput = document.querySelector(passwordInputSelector)
        let isMatch = e.target.value === passwordInput.value
        handleValidationOutput(isMatch, e, "Passwords do not match")
    }


}

const phoneValidation = (e) => {

    const regEx = /^[\+]?[(]?[0-9]{3}[)]?[-\s\.]?[0-9]{3}[-\s\.]?[0-9]{4,6}$/

    if (e.target.value.length > 0)
        handleValidOutput(regEx.test(e.target.value), e, e.target.dataset.valRegex)
    else
        handleValidOutput(false, e, e.target.dataset.valRequired)

}

//(function () {
//    let forms = document.querySelectorAll('form');
//    if (forms.length > 0) {
//        let inputs = forms[0].querySelectorAll('input');

//        inputs.forEach(input => {
//            if (input.dataset.val === 'true') {
//                input.addEventListener('keyup', (e) => {
//                    switch (e.target.type) {
//                        case 'text':
//                            textValidation(e, e.target.dataset.valMinlengthMin);
//                            break;
//                        case 'email':
//                            emailValidation(e);
//                            break;
//                        case 'password':
//                            passwordValidation(e);
//                            break;
//                    }
//                });
//            }
//        });
//    }

//    function handleValidationOutput(isValid, e, text = "") {
//        let span = document.querySelector(`[data-valmsg-for="${e.target.name}"]`);

//        if (isValid) {
//            e.target.classList.remove('input-validation-error');
//            span.classList.remove('field-validation-error');
//            span.classList.add('field-valid');
//            span.innerHTML = "";
//        } else {
//            e.target.classList.add('input-validation-error');
//            span.classList.add('field-validation-error');
//            span.classList.remove('field-valid');
//            span.innerHTML = text;
//        }
//    }

//    function textValidation(e, minLength = 1) {
//        if (e.target.value.length > 0)
//            handleValidationOutput(e.target.value.length >= minLength, e, e.target.dataset.valMinlength);
//        else
//            handleValidationOutput(false, e, e.target.dataset.valRequired);
//    }

//    function emailValidation(e) {
//        const regEx = /^[a-zA-Z0-9.!#$%&'*+/=?^_`{|}~-]+@[a-zA-Z0-9](?:[a-zA-Z0-9-]{0,61}[a-zA-Z0-9])?(?:\.[a-zA-Z0-9](?:[a-zA-Z0-9-]{0,61}[a-zA-Z0-9])?)*\.[a-zA-Z]{2,}$/;

//        if (e.target.value.length > 0)
//            handleValidationOutput(regEx.test(e.target.value), e, e.target.dataset.valRegex);
//        else
//            handleValidationOutput(false, e, e.target.dataset.valRequired);
//    }

//    function passwordValidation(e) {
//        const passwordRegEx = /^(?=.*[0-9])(?=.*[a-z])(?=.*[A-Z])(?=.*[\W_])(?!.*\s).{8,}$/;
//        let isValidPassword = passwordRegEx.test(e.target.value);
//        handleValidationOutput(isValidPassword, e, e.target.dataset.valRegex);

//        if (e.target.name === 'ConfirmPassword') {
//            let passwordInputSelector = e.target.dataset.valEqualtoOther;
//            let passwordInput = document.querySelector(passwordInputSelector);
//            let isMatch = e.target.value === passwordInput.value;
//            handleValidationOutput(isMatch, e, "Passwords do not match");
//        }
//    }
//})();
