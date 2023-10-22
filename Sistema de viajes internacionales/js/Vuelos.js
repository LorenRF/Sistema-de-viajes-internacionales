  const viajesDiv = document.getElementById('Viajes');
  const hotelesDiv = document.getElementById('Hoteles');
  const vehiculosDiv = document.getElementById('Transportes');
  const homeDiv = document.getElementById('home');
  const registrar = document.getElementById('book');
  const urlParams = new URLSearchParams(window.location.search);
  const encodedData = urlParams.get('codigo');
    //redireccion a otro link
document.addEventListener('DOMContentLoaded', function() {
if (!encodedData) {
      console.error('Sesión no iniciada');

    }

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
      window.location.href = `./Reservaciones.html?codigo=${encodeURIComponent(encodedData)}`;    }
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
          // Cambiar el texto del botón con el ID deseado
          registrar.textContent = "Reservaciones";
        } else {
          console.error('Error: No se pudo obtener el texto del botón')
          
        }
      })
      .catch(error => {
        console.error('Error al obtener los datos de la API:', error);
      });
    }  
    
    registrar.addEventListener('click', function() {
    if (!encodedData) {
      console.error('Sesión no iniciada');
      window.location.href = './SignIn.html';
    } else {
      window.location.href = `./SignIn.html?codigo=${encodeURIComponent(encodedData)}`;
    }
  });
  });


  document.addEventListener('DOMContentLoaded', function() {
    const resultsContainer = document.getElementById('list');
    fetch(`https://localhost:7160/api/Vuelos/get-vuelos-by-destiny?destino=all`)
    .then(response => response.json())
    .then(data => {
      if (Array.isArray(data) && data.length > 0) {
        const vuelos = data;
      
        // Se crea una lista de elementos <li> con los resultados de vuelos
        const vuelosListItems = vuelos.map(vuelo => `<li>${vuelo.destino}<br>${vuelo.horario}</li>`).join('');
      
        // Se actualiza el contenido de la lista de resultados
        resultsContainer.innerHTML = vuelosListItems;
        const liElements = resultsContainer.getElementsByTagName('li');
        for (let i = 0; i < liElements.length; i++) {
          const li = liElements[i];
          li.addEventListener('click', function () {
            const selectedData = vuelos[i];
      
            if (!encodedData) {
              console.error('Sesión no iniciada');          
            // Construir los datos a pasar en la URL solo con el elemento seleccionado
            url = `./ReservacionVuelo.HTML?data=${encodeURIComponent(JSON.stringify(selectedData))}`;
            }

           else {
             url = `./ReservacionVuelo.HTML?data=${encodeURIComponent(JSON.stringify(selectedData))}&codigo=${encodeURIComponent(encodedData)}`;
            }
            window.location.href = url;
          });
        }} else {
        // Si no se encontraron vuelos en la respuesta de la API
        console.error('Error: No se encontraron vuelos en la respuesta de la API');
      }
    })
    .catch(error => {
      console.error('Error al obtener los vuelos:', error);
    });
});


  ///API
  document.addEventListener('DOMContentLoaded', function() {
    const searchInput = document.getElementById('search-input');
    const resultsContainer = document.getElementById('list');
    const searchButton = document.getElementById('button');
    
  
    searchButton.addEventListener('click', function(event) {  
      const urlParams = new URLSearchParams(window.location.search);
      
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
        apiUrl = `https://localhost:7160/api/Vuelos/get-vuelos-by-ID?id=${userInput}`;
      } else {
        // Si el valor introducido no es un número, utilizar la URL con el parámetro 'destino'
        const encodedDestino = encodeURIComponent(userInput);
        apiUrl = `https://localhost:7160/api/Vuelos/get-vuelos-by-destiny?destino=${encodedDestino}`;
      }
  
      // Se realiza la solicitud a la API utilizando fetch
      fetch(apiUrl)
        .then(response => response.json())
        .then(data => {
          if (Array.isArray(data) && data.length > 0) {
            const vuelos = data;
          
            // Se crea una lista de elementos <li> con los resultados de vuelos
            const vuelosListItems = vuelos.map(vuelo => `<li>${vuelo.destino}<br>${vuelo.horario}</li>`).join('');
          
            // Se actualiza el contenido de la lista de resultados
            resultsContainer.innerHTML = vuelosListItems;
          
            // Agregar evento de clic a cada elemento <li>
            const liElements = resultsContainer.getElementsByTagName('li');
            for (let i = 0; i < liElements.length; i++) {
              const li = liElements[i];
              li.addEventListener('click', function () {
                const selectedData = vuelos[i];
          
                if (!encodedData) {
                  console.error('Sesión no iniciada');          
                // Construir los datos a pasar en la URL solo con el elemento seleccionado
                url = `./ReservacionVuelo.HTML?data=${encodeURIComponent(JSON.stringify(selectedData))}`;
                }

               else {
                 url = `./ReservacionVuelo.HTML?data=${encodeURIComponent(JSON.stringify(selectedData))}&codigo=${encodeURIComponent(encodedData)}`;
                }
                window.location.href = url;
              });
            }
          } else {
            // Si no se encontraron vuelos en la respuesta de la API
            console.error('Error: No se encontraron vuelos en la respuesta de la API');
          }
        })
        .catch(error => {
          console.error('Error al obtener los vuelos:', error);
        });
    });
  });
