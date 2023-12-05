function initMap() {
    map = new Microsoft.Maps.Map('#mapContainer', {
        credentials: 'key'
    });


    agregarMarcador(map, -34.6007, -58.3871, 'Viamonte 1432');
    agregarMarcador(map, -34.5806, -58.4302, 'Humboldt 2263');
    agregarMarcador(map, -34.5788, -58.4600, 'Av.Forest 1166');
    agregarMarcador(map, -38.0028, -57.5507, 'San Luis 2176');
    agregarMarcador(map, -34.7197, -58.2562, 'Alvear 514');
    agregarMarcador(map, -34.5974, -58.3971, 'Marcelo T. de Alvear 2084');

    agregarMarcador(map, -34.5965, -58.4003, 'M. T de Alvear 2259');
    agregarMarcador(map, -34.6062, -58.4256, 'Perón 4190');
    agregarMarcador(map, -34.5965, -58.3796, 'Marcelo T. de Alvear 878');
    agregarMarcador(map, -34.5842, -58.4124, 'Juncal 3490');
    agregarMarcador(map, -34.5983, -58.4179, 'Bulnes 1104');
    agregarMarcador(map, -34.5571, -58.4476, 'Av del Libertador 5962');





    map.setView({ zoom: 12, center: new Microsoft.Maps.Location(-34.6083, -58.3712) });
    map.setOptions({ mapTypeId: Microsoft.Maps.MapTypeId.road });


    Microsoft.Maps.Events.addHandler(map, 'click', function (e) {
        console.log('Clic en el mapa:', e.location);
    });
}

function agregarMarcador(map, latitud, longitud, titulo) {
    var location = new Microsoft.Maps.Location(latitud, longitud);
    var pushpin = new Microsoft.Maps.Pushpin(location, { title: titulo });
    map.entities.push(pushpin);
}


document.addEventListener('DOMContentLoaded', function () {
    initMap();
});