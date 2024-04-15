function showMessage() {
    event.preventDefault();  
    try {
        var messageElement = document.getElementById('message')
        messageElement.style.display = 'block'


        setTimeout(function () {
            messageElement.style.opacity = 0;
 
            setTimeout(function () {
                messageElement.style.display = 'none';
                messageElement.style.opacity = 1; 
            }, 1000); 
        }, 3000);
    }
    catch { }
}