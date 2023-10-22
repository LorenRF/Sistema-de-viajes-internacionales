const home = document.getElementById('home');
var op = 'json';
const resultsContainer = document.getElementById('list');
const urlParams = new URLSearchParams(window.location.search);
const encodedData = urlParams.get('codigo');

document.addEventListener('DOMContentLoaded', function () {
  if (!encodedData) {
    console.error('Sesión no iniciada');
  } else {
    mostrarReservaciones();

    // Agregar event listener a los elementos de radio para capturar el cambio de selección
    const opciones = document.getElementsByName('formato');
    opciones.forEach(opcion => {
      opcion.addEventListener('change', function () {
        // Actualizar la variable 'op' con la opción seleccionada
        op = this.value;
        resultsContainer.innerHTML  =  `<li> No tiene reservaciones en este formato.</li>`     
        mostrarReservaciones();
      });
    });
  }

  home.addEventListener('click', function () {
    window.location.href = `./Index.html?codigo=${encodeURIComponent(encodedData)}`;
  });
});

function mostrarReservaciones() {
  const apiUrl = `https://localhost:7160/get-user-Bookings?id=${encodedData}&formato=${op}`;

  fetch(apiUrl)
    .then(response => {
      if (!response.ok) {
        throw new Error('La solicitud no fue exitosa');
      }
      return response.json();
    })
    .then(data => {
      // Verificar si la respuesta es un arreglo con al menos un objeto
      if (Array.isArray(data) && data.length > 0) {
        const ReservacionesListItems = data.map(reservacion => {
          // Verificar el tipo de reservación en función de la opción seleccionada
          if (op === 'json') {
            // Construir la cadena de plantilla para formato JSON
            if (reservacion.hasOwnProperty('vuelo')) {
              const vuelo = `Horario: ${reservacion.vuelo.horario}, Código: ${reservacion.vuelo.codigo}, Destino: ${reservacion.vuelo.destino}, Asiento: ${reservacion.vuelo.asiento}`;
              const user = `Correo: ${reservacion.user.correo}, Nombre de usuario: ${reservacion.user.userName}, ID: ${reservacion.user.iD}`;
              return `<li>${'"vuelo":'}${vuelo}<br>${'"user":'}${user}</li>`;
            } else if (reservacion.hasOwnProperty('hotel')) {
              const hotel = `Ubicación: ${reservacion.hotel.ubicacion}, Habitación: ${reservacion.hotel.habitacion}, Estrellas: ${reservacion.hotel.estrellas}, ID: ${reservacion.hotel.id}`;
              const user = `Correo: ${reservacion.user.correo}, Nombre de usuario: ${reservacion.user.userName}, Contraseña: ${reservacion.user.password}, ID: ${reservacion.user.iD}`;
              return `<li>${'"hotel":'}${hotel}<br>${'"user":'}${user}</li>`;
            } else if (reservacion.hasOwnProperty('transporte')) {
              const transporte = `Marca: ${reservacion.transporte.marca}, Año: ${reservacion.transporte.año}, Color: ${reservacion.transporte.color}, Modelo: ${reservacion.transporte.modelo}, ID: ${reservacion.transporte.id}`;
              const user = `Correo: ${reservacion.user.correo}, Nombre de usuario: ${reservacion.user.userName}, Contraseña: ${reservacion.user.password}, ID: ${reservacion.user.iD}`;
              return `<li>${'"Transporte":'}${transporte}<br>${'"user":'}${user}</li>`;
            } else {
              return `<li>Error: Tipo de reservación desconocido</li>`;
            }
          } else if (op === 'txt') {
            // Construir la cadena de plantilla para formato JSON
            if (reservacion.hasOwnProperty('vuelo')) {
              const vuelo = `Horario: ${reservacion.vuelo.horario}, Código: ${reservacion.vuelo.codigo}, Destino: ${reservacion.vuelo.destino}, Asiento: ${reservacion.vuelo.asiento}`;
              const user = `Correo: ${reservacion.user.correo}, Nombre de usuario: ${reservacion.user.userName}, ID: ${reservacion.user.iD}`;
              return `<li>${'"vuelo":'}${vuelo}<br>${'"user":'}${user}</li>`;
            } else if (reservacion.hasOwnProperty('hotel')) {
              const hotel = `Ubicación: ${reservacion.hotel.ubicacion}, Habitación: ${reservacion.hotel.habitacion}, Estrellas: ${reservacion.hotel.estrellas}, ID: ${reservacion.hotel.id}`;
              const user = `Correo: ${reservacion.user.correo}, Nombre de usuario: ${reservacion.user.userName}, Contraseña: ${reservacion.user.password}, ID: ${reservacion.user.iD}`;
              return `<li>${'"hotel":'}${hotel}<br>${'"user":'}${user}</li>`;
            } else if (reservacion.hasOwnProperty('transporte')) {
              const transporte = `Marca: ${reservacion.transporte.marca}, Año: ${reservacion.transporte.año}, Color: ${reservacion.transporte.color}, Modelo: ${reservacion.transporte.modelo}, ID: ${reservacion.transporte.id}`;
              const user = `Correo: ${reservacion.user.correo}, Nombre de usuario: ${reservacion.user.userName}, Contraseña: ${reservacion.user.password}, ID: ${reservacion.user.iD}`;
              return `<li>${'"Transporte":'}${transporte}<br>${'"user":'}${user}</li>`;
            } else {
              return `<li>Error: Tipo de reservación desconocido</li>`;
            }
          } else if (op === 'excel') {
            // Construir la cadena de plantilla para formato JSON
            if (reservacion.hasOwnProperty('vuelo')) {
              const vuelo = `Horario: ${reservacion.vuelo.horario}, Código: ${reservacion.vuelo.codigo}, Destino: ${reservacion.vuelo.destino}, Asiento: ${reservacion.vuelo.asiento}`;
              const user = `Correo: ${reservacion.user.correo}, Nombre de usuario: ${reservacion.user.userName}, ID: ${reservacion.user.iD}`;
              return `<li>${'"vuelo":'}${vuelo}<br>${'"user":'}${user}</li>`;
            } else if (reservacion.hasOwnProperty('hotel')) {
              const hotel = `Ubicación: ${reservacion.hotel.ubicacion}, Habitación: ${reservacion.hotel.habitacion}, Estrellas: ${reservacion.hotel.estrellas}, ID: ${reservacion.hotel.id}`;
              const user = `Correo: ${reservacion.user.correo}, Nombre de usuario: ${reservacion.user.userName}, Contraseña: ${reservacion.user.password}, ID: ${reservacion.user.iD}`;
              return `<li>${'"hotel":'}${hotel}<br>${'"user":'}${user}</li>`;
            } else if (reservacion.hasOwnProperty('transporte')) {
              const transporte = `Marca: ${reservacion.transporte.marca}, Año: ${reservacion.transporte.año}, Color: ${reservacion.transporte.color}, Modelo: ${reservacion.transporte.modelo}, ID: ${reservacion.transporte.id}`;
              const user = `Correo: ${reservacion.user.correo}, Nombre de usuario: ${reservacion.user.userName}, Contraseña: ${reservacion.user.password}, ID: ${reservacion.user.iD}`;
              return `<li>${'"Transporte":'}${transporte}<br>${'"user":'}${user}</li>`;
            } else {
              return `<li>Error: Tipo de reservación desconocido</li>`;
            }
          }
        }).join('');

        // Se actualiza el contenido de la lista de resultados
        resultsContainer.innerHTML = ReservacionesListItems;
      } else {
        console.log('La respuesta no contiene la lista de reservaciones');
      }
    })
    .catch(error => {
      console.error('Error al obtener los datos:', error);
    });
}
