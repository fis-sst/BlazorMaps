window.debugPrompt = {
    showPrompt: function (message) {
        alert(message);
    }
}

window.leafletMap = {
    initializeMap: function (mapId) {
        var newMap = L.map(mapId).setView([51.505, -0.09], 13);

        L.tileLayer('https://api.mapbox.com/styles/v1/{id}/tiles/{z}/{x}/{y}?access_token={accessToken}', {
            attribution: 'Map data &copy; <a href="https://www.openstreetmap.org/">OpenStreetMap</a> contributors, <a href="https://creativecommons.org/licenses/by-sa/2.0/">CC-BY-SA</a>, Imagery © <a href="https://www.mapbox.com/">Mapbox</a>',
            maxZoom: 18,
            id: 'mapbox/streets-v11',
            tileSize: 512,
            zoomOffset: -1,
            accessToken: 'pk.eyJ1Ijoia2luZ2FmaXMiLCJhIjoiY2tmZ3Zia2hpMHNtNzJyb3VlbWQweWJsdSJ9.5SH3Hdaoi6cnlxZ5SfUL5w'
        }).addTo(newMap);
    }
};