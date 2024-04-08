document.addEventListener('DOMContentLoaded', function () {
        initMap()
})

function initMap() {
    try {
        const options = {
            center: { lat: 37.73418426513672, lng: -122.4065170288086 },
            zoom: 16
        };

        map = new google.maps.Map(document.getElementById("map"), options);
    } catch { }
}