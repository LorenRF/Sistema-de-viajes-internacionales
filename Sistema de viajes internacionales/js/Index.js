
var viajesElement = document.querySelector('.Viajes');
var hotelesElement = document.querySelector('.Hoteles');
var vehiculosElement = document.querySelector('.Vehiculos');
var textElement = document.getElementById('text-content');
const urlParams = new URLSearchParams(window.location.search);
const encodedData = urlParams.get('codigo');
    var registrar1 = document.getElementById('book1');
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
          registrar1.textContent = "Reservaciones";
        } else {
          console.error('Error: No se pudo obtener el texto del botón')
          
        }
      })
      .catch(error => {
        console.error('Error al obtener los datos de la API:', error);
      });
    }
  });
  


viajesElement.addEventListener('mouseenter', function() {
  fadeOutText("¡Explora el mundo con nuestras reservaciones de vuelos! En LarimalTravel, te ofrecemos una experiencia de viaje inolvidable. Descubre destinos exóticos, sumérgete en nuevas culturas y crea recuerdos duraderos. Con una amplia selección de aerolíneas y horarios flexibles, planificar tu próximo viaje es sencillo.  ");
});

hotelesElement.addEventListener('mouseenter', function() {
  fadeOutText("¡Haz de tus vacaciones una experiencia inolvidable con nuestras reservaciones de hotel! En LarimalTravel, te brindamos una amplia variedad de opciones de alojamiento para que encuentres el lugar perfecto que se ajuste a tus necesidades y preferencias. ");
});

vehiculosElement.addEventListener('mouseenter', function() {
  fadeOutText("¿Estás buscando una forma cómoda y conveniente de moverte durante tu viaje? ¡No busques más! Nuestro servicio de alquiler de vehículos de transporte terrestre te ofrece la libertad de explorar a tu propio ritmo. ");
});

function fadeOutText(newText) {
  textElement.classList.add('fade-out');
  setTimeout(function() {
    textElement.textContent = newText;
    textElement.classList.remove('fade-out');
  }, 500);
}

/////HEADER
window.addEventListener('scroll', function() {
  var header = document.querySelector('.header');
  var scrollPosition = window.scrollY;

  if (scrollPosition > 100) {
    header.classList.add('fixed');
  } else {
    header.classList.remove('fixed');
  }
});




//redireccion a otro link
document.addEventListener('DOMContentLoaded', function() {
  const viajesDiv = document.getElementById('Viajes');
  const hotelesDiv = document.getElementById('Hoteles');
  const vehiculosDiv = document.getElementById('Vehiculos');
  const registrar = document.getElementById('book');
  const urlParams = new URLSearchParams(window.location.search);
  const encodedData = urlParams.get('codigo');

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
      window.location.href = `./Reservaciones.html?codigo=${encodeURIComponent(encodedData)}`;
    }
  });

  registrar1.addEventListener('click', function() {
    if (!encodedData) {
      console.error('Sesión no iniciada');
      window.location.href = './SignIn.html';
    } else {
      window.location.href = `./Reservaciones.html?codigo=${encodeURIComponent(encodedData)}`;
    }
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

  // Botón de registro

});


