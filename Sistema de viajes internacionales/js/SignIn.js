// Evento DOMContentLoaded para el formulario de registro
document.addEventListener('DOMContentLoaded', function() {
  const usernameInput = document.getElementById('username-input');
  const emailInput = document.getElementById('email-input');
  const passwordInput = document.getElementById('password-input');
  const registerButton = document.getElementById('REGISTER');
  const homeButton = document.getElementById('home');
  var url = "";

  homeButton.addEventListener('click', function() {
    url = `./index.html`
    window.location.href = url;
  });

  registerButton.addEventListener('click', function(event) {
    event.preventDefault(); // Evitar envío del formulario al hacer clic en el botón

    const username = usernameInput.value.trim();
    const email = emailInput.value.trim();
    const password = passwordInput.value.trim();

    if (username === '' || email === '' || password === '') {
      alert('Por favor, complete todos los campos');
      return;
    }

    const apiUrl = `https://localhost:7160/user-register?correo=${encodeURIComponent(email)}&password=${encodeURIComponent(password)}&userName=${encodeURIComponent(username)}`;

    fetch(apiUrl, {
      method: 'POST',
      headers: {
        'Content-Type': 'application/json'
      }
    })
      .then(response => response.json())
      .then(data => {
        if (data !== null) {
          window.apiResponse = data;
          alert('Registro exitoso');

          // Verificar si window.apiResponse tiene un valor antes de redirigir
          if (window.apiResponse !== undefined) {
             url = `./index.html?codigo=${encodeURIComponent(JSON.stringify(data))}`;
            window.location.href = url;
          } else {
            console.error('No se pudo obtener la respuesta de la API');
          }
        } else {
          alert('Error en el registro');
        }
      })
      .catch(error => {
        console.error('Error al registrar el usuario:', error);
      });
  });
});
