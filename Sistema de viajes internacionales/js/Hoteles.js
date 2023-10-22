const viajesDiv = document.getElementById('Vuelos');
const hotelesDiv = document.getElementById('Hoteles');
const vehiculosDiv = document.getElementById('Transportes');
const homeDiv = document.getElementById('home');
const registrar = document.getElementById('book');
const urlParams = new URLSearchParams(window.location.search);
const encodedData = urlParams.get('codigo');
//redireccion a otro link
document.addEventListener('DOMContentLoaded', function() {


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
    window.location.href = `./Reservaciones.html?codigo=${encodeURIComponent(encodedData)}`;  }
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
////boton
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
        userName = data;
        registrar.textContent ="Reservaciones";
      } else {
        console.error('Error: No se pudo obtener el texto del botón')
        
      }
    })
    .catch(error => {
      console.error('Error al obtener los datos de la API:', error);
    });
  }  
  
});


document.addEventListener('DOMContentLoaded', function() {
  const resultsContainer = document.getElementById('images');

    // Se realiza la solicitud a la API utilizando fetch
    fetch(`https://localhost:7160/api/Hoteles/get-hotel-by-location?destino=all`)
      .then(response => response.json())
      .then(data => {
        if (Array.isArray(data) && data.length > 0) {
          const Hoteles = data;
        
          // Se crea una lista de elementos <li> con los resultados de hoteles
          const HotelesListItems = Hoteles.map(Hotel => {
            const imageUrl = getImageUrlFromId(Hotel.id);
            return `
              <li>
                <img src="${imageUrl}" alt="Hotel Image">
                <p>Ubicacion: ${Hotel.ubicacion}</p>
                <p>Estrellas: ${Hotel.estrellas}</p>
              </li>
            `;
          }).join('');

          // Se actualiza el contenido de la lista de resultados
          resultsContainer.innerHTML = HotelesListItems;
        
          // Agregar evento de clic a cada elemento <li>
          const liElements = resultsContainer.getElementsByTagName('li');
          for (let i = 0; i < liElements.length; i++) {
            const li = liElements[i];
            li.addEventListener('click', function() {
              const selectedData = Hoteles[i];

              if (!encodedData) {
                console.error('Sesión no iniciada');
                // Construir los datos a pasar en la URL solo con el elemento seleccionado
                url = `./ReservacionHotel.HTML?data=${encodeURIComponent(JSON.stringify(selectedData))}`;
              } else {
                url = `./ReservacionHotel.HTML?data=${encodeURIComponent(JSON.stringify(selectedData))}&codigo=${encodeURIComponent(encodedData)}`;
              }
              window.location.href = url;
            });
          }
    } else {
      // Si no se encontraron  vehiculos en la respuesta de la API
      console.error('Error: No se encontraron  vehiculos en la respuesta de la API');
    }
  })
  .catch(error => {
    console.error('Error al obtener los  vehiculos:', error);
  });
});


///API
document.addEventListener('DOMContentLoaded', function() {
  const searchInput = document.getElementById('search-input');
  const resultsContainer = document.getElementById('images');
  const searchButton = document.getElementById('button');
  
  searchButton.addEventListener('click', function(event) {  
    const urlParams = new URLSearchParams(window.location.search);
    const encodedData = urlParams.get('codigo');
    resultsContainer.innerHTML = "";
    let url = "";
    event.preventDefault(); // Evita que se envíe el formulario al hacer clic en el botón
  
    const userInput = searchInput.value.trim();
  
    if (userInput === '') {
      // Si el campo de entrada está vacío, se borra la lista de resultados
      resultsContainer.innerHTML = '';
      return;
    }
  
    let apiUrl;
  
    if (!isNaN(userInput)) {
      // Si el valor introducido es un número, utilizar la URL con el parámetro 'id'
      apiUrl = `https://localhost:7160/api/Hoteles/get-hotel-by-ID?id=${userInput}`;
    } else {
      // Si el valor introducido no es un número, utilizar la URL con el parámetro 'destino'
      const encodedDestino = encodeURIComponent(userInput);
      apiUrl = `https://localhost:7160/api/Hoteles/get-hotel-by-location?destino=${encodedDestino}`;
    }
  
    // Se realiza la solicitud a la API utilizando fetch
    fetch(apiUrl)
      .then(response => response.json())
      .then(data => {
        if (Array.isArray(data) && data.length > 0) {
          const Hoteles = data;
        
          // Se crea una lista de elementos <li> con los resultados de hoteles
          const HotelesListItems = Hoteles.map(hotel => {
            const imageUrl = getImageUrlFromId(hotel.id);
            return `
              <li>
                <img src="${imageUrl}" alt="Hotel Image">
                <p>Ubicacion: ${hotel.ubicacion}</p>
                <p>Estrellas: ${hotel.estrellas}</p>
              </li>
            `;
          }).join('');

          // Se actualiza el contenido de la lista de resultados
          resultsContainer.innerHTML = hotelesListItems;
        
          // Agregar evento de clic a cada elemento <li>
          const liElements = resultsContainer.getElementsByTagName('li');
          for (let i = 0; i < liElements.length; i++) {
            const li = liElements[i];
            li.addEventListener('click', function() {
              const selectedData = hoteles[i];

              if (!encodedData) {
                console.error('Sesión no iniciada');
                // Construir los datos a pasar en la URL solo con el elemento seleccionado
                url = `./ReservacionHotel.HTML?data=${encodeURIComponent(JSON.stringify(selectedData))}`;
              } else {
                url = `./ReservacionHotel.HTML?data=${encodeURIComponent(JSON.stringify(selectedData))}&codigo=${encodeURIComponent(encodedData)}`;
              }
              window.location.href = url;
            });
          }
        } else {
          // Si no se encontraron hoteles en la respuesta de la API
          console.error('Error: No se encontraron hoteles en la respuesta de la API');
        }
      })
      .catch(error => {
        console.error('Error al obtener los hoteles:', error);
      });
  });

    });
    
    function getImageUrlFromId(vehiculoId) {

        return `./IMG/Hotel/${vehiculoId}.jpg`;
      }

