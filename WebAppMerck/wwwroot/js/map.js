function initMap() {

    fetch('/Home/GetBingMapsApiKey')
        .then(response => response.json())
        .then(data => {
            map = new Microsoft.Maps.Map('#mapContainer', {
                credentials: data.apiKey
            });


            fetch('/Home/ObtenerClinicas')
                .then(response => {
                    if (!response.ok) {
                        throw new Error('La solicitud no fue exitosa: ' + response.status);
                    }
                    return response.json();
                })
                .then(clinicasData => {
                    clinicasData.forEach(ubicacion => {
                        agregarMarcador(map, ubicacion.latitud, ubicacion.longitud, ubicacion.titulo);
                    });
                })
                .catch(error => console.error('Error al obtener las ubicaciones:', error));


        })
        .catch(error => console.error('Error al obtener la clave de Bing Maps:', error));
}

function agregarMarcador(map, latitud, longitud, titulo) {
    var location = new Microsoft.Maps.Location(latitud, longitud);
    var pushpin = new Microsoft.Maps.Pushpin(location, { title: titulo });
    map.entities.push(pushpin);
}

document.addEventListener('DOMContentLoaded', function () {
    initMap();
});