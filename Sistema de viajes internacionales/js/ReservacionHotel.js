var book = document.getElementById('btn');      
 // Obtener el parámetro 'data' de la URL
const urlParams = new URLSearchParams(window.location.search);
const encodedDatahotel = urlParams.get('data');  
var userName = ''; 
     // Decodificar el parámetro 'data'
 const decodedData = decodeURIComponent(encodedDatahotel);
 const hotel = JSON.parse(decodedData);
 const hotelListItems = `<h1>${ hotel.ubicacion}<h1> <h2>Estrellas: ${ hotel.estrellas}</h2> <h2>Habitacion: ${ hotel.habitacion}</h2> <h2>Codigo: ${ hotel.id}</h2>`;
 const codigohotel = hotel.id; // Suponiendo que solo hay un objeto de hotel en la matriz vuelos
 const codigohotelInt = parseInt(codigohotel, 10);
 const encodedData = urlParams.get('codigo');
var op;

  console.log(hotel);

 document.addEventListener('DOMContentLoaded', function() {

  console.log(codigohotelInt);

    // Obtener el elemento <div> donde se mostrarán los datos
    const resultsContainer = document.getElementById('datos');
  
    // Crear una lista de hotel como cadenas HTML
        // Actualizar el contenido del <div> con la lista de hotel
    resultsContainer.innerHTML = hotelListItems;
  });
  
  document.addEventListener('DOMContentLoaded', function() {
    const viajesDiv = document.getElementById('Vuelos');
    const hotelesDiv = document.getElementById('Hoteles');
    const vehiculosDiv = document.getElementById('Transportes');
    const registrar = document.getElementById('book');
    const urlParams = new URLSearchParams(window.location.search);
    const encodedData = urlParams.get('codigo');
    const homeDiv = document.getElementById('home');
    

    const backgroundElement = document.querySelector('.background-image');

    // Función para cambiar la URL de la imagen de fondo
    function changeBackgroundImageUrl(url) {
      backgroundElement.style.backgroundImage = `url(${url})`;
    }
    // Generar la nueva URL usando una plantilla de cadena
    const newUrl = `./IMG/Hotel/${codigohotelInt}.jpg`;
    
    // Llamar a la función para cambiar la URL de la imagen de fondo
    changeBackgroundImageUrl(newUrl);
    
    viajesDiv.addEventListener('click', function() {
      if (!encodedData) {
        console.error('Sesión no iniciada');
        window.location.href = './Vuelos.html';
      } else {
        window.location.href = `./Vuelos.html?codigo=${encodeURIComponent(encodedData)}`;
      }
    });  
    
    registrar.addEventListener('click', function() {
      if (!encodedData) {
        console.error('Sesión no iniciada');
        window.location.href = './SignIn.html';
      } else {
        window.location.href = `./Reservaciones.html?codigo=${encodeURIComponent(encodedData)}`;      }
    });
  
    hotelesDiv.addEventListener('click', function() {
      if (!encodedData) {
        console.error('Sesión no iniciada');
        window.location.href = './Hoteles.html';
      } else {
        window.location.href = `./Hoteles.html?codigo=${encodeURIComponent(encodedData)}`;
      }
    });
  
    vehiculosDiv.addEventListener('click', function() {
      if (!encodedData) {
        console.error('Sesión no iniciada');
        window.location.href = './Transportes.html';
      } else {
        window.location.href = `./Transportes.html?codigo=${encodeURIComponent(encodedData)}`;
      }
    });
    homeDiv.addEventListener('click', function() {
        if (!encodedData) {
          console.error('Sesión no iniciada');
          window.location.href = './index.html';
        } else {
          window.location.href = `./index.html?codigo=${encodeURIComponent(encodedData)}`;
        }
      });

  });

  document.addEventListener('DOMContentLoaded', function() {
    var registrar = document.getElementById('book');
    
    const urlParams = new URLSearchParams(window.location.search);
    const encodedData = urlParams.get('codigo');
    if(!encodedData) {
      console.error('sesion no iniciada');
    }

    else{
    const apiUrl = `https://localhost:7160/get-user-by-id?id=${encodedData}`;
  
    fetch(apiUrl)
      .then(response => response.json())
      .then(data => {
        if (data !== undefined) {
          registrar.textContent = "Reservaciones"; // Cambiar el texto del botón con el nombre deseado
        } else {
          console.error('Error: No se pudo obtener el texto del botón')
          
        }
      })
      .catch(error => {
        console.error('Error al obtener los datos de la API:', error);
      });
    }
  });

            // Agregar el evento de clic al botón de reservar
  book.addEventListener('click', function() {
    obtenerSeleccion();
    if (encodedData == null) {

        alert('Usted no esta registrado');
        window.location.href = "./SignIn.html";
      }
  
      else {
      const apiUrl = `https://localhost:7160/api/Hoteles/Booking?idHotel=${codigohotelInt}&idUser=${encodedData}&formato=${op}`;
      fetch(apiUrl, {
        method: 'POST',
        headers: {
          'Content-Type': 'application/json'
        }
       })
        .then(response => response.json())
        .then(data => {
          if (Array.isArray(data) && data.length > 0) {
            const reservacion = data;
            alert('Reservacion exitosa');
            url = `./index.html?codigo=${encodeURIComponent(encodedData)}`;
            window.location.href = url;
  } else {
            alert('Error en la reservacion');
          }
        })
        .catch(error => {
          console.error('Error al registrar el Reservar:', error);
        });
      }
  });


      function obtenerSeleccion() {
        var opciones = document.getElementsByName('formato');
        var seleccionado;
    
        for (var i = 0; i < opciones.length; i++) {
            if (opciones[i].checked) {
                seleccionado = opciones[i].value;
                break;
            }
        }
     
        switch (seleccionado) {
          case 'json':
              op = 'json';
              break;
          case 'txt':
              op = 'txt';
              break;
          case 'excel':
              op = 'excel';
              break;
          default:
              op = 'json';
              break;
        }
    
        console.log('Opción seleccionada:', seleccionado);
        console.log('Valor de "op":', op);
    }
    