document.getElementById('provincia').addEventListener('change', function () {
    var provinciaSeleccionada = this.value;

    // Realizar solicitud AJAX para obtener clínicas filtradas
    fetch('/Home/ObtenerClinicasPorProvincia', {
        method: 'POST',
        headers: {
            'Content-Type': 'application/json'
        },
        body: JSON.stringify({ Provincia: provinciaSeleccionada })
    })
        .then(response => response.json())
        .then(data => {
            console.log('Clínicas filtradas:', data); // Agrega esta línea para ver las clínicas en la consola

            var clinicasDropdown = document.getElementById('clinicas');
            clinicasDropdown.innerHTML = "";

            // Agregar las clínicas filtradas al elemento select
            data.forEach(function (clinica) {
                var option = document.createElement('option');
                option.value = clinica.Nombre;
                option.text = clinica.Nombre;
                clinicasDropdown.appendChild(option);
            });
        })
        .catch(error => console.error('Error:', error));
});