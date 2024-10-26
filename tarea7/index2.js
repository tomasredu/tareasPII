const servicios = [
  {
    id: 1,
    nombre: 'Corte de pelo'
  },
  {
    id: 2,
    nombre: 'Baño'
  },

]

const usuarios = [
  {
    id: 1,
    nombre: 'Luciana Gennari',

  },
  {
    id: 2,
    nombre: 'Rago Tomas',

  },
];
const turnos = [
  {
    idCliente: 1,
    fecha: '2022-01-01',
    hora: '10:00',
    servicios:[
      {
        id: 1
      },
      {
        id: 2
      }
    ]
  }
];

document.querySelector('#btn-dashboard').addEventListener('click', async function () {
  await dashboard();
});
document.querySelector('#btn-turnos').addEventListener('click', async function () {
  await consultarTurnos();
});
document.querySelector('#btn-nuevo-turno').addEventListener('click', async function () {
  await nuevoTurno();
});
document.addEventListener('DOMContentLoaded', async function () {
  await dashboard();
})

async function loadContent( url ) {
  const response = await fetch(url);
  const txt = await response.text();
  const $content = document.querySelector('#content');
  $content.innerHTML = txt;
}
 

async function nuevoTurno() {
  await loadContent('./nuevoTurno.html');
  usuarios.forEach(user => {
    const $select = document.querySelector('#select');
    document.querySelector('#select').innerHTML += `<option value="${user.id}">${user.nombre}</option>`
  })
  document.querySelector('#form').addEventListener('submit', function (e) {
    e.preventDefault();
    cargarTurno();
  });
  document.querySelectorAll('input[type="checkbox"]').forEach(checkbox => {
    checkbox.addEventListener('change', function () {
      const $checkCorte = document.querySelector('#checkCorte');
      const $checkBano = document.querySelector('#checkBano');
      if ($checkCorte.checked || $checkBano.checked) {
        $checkCorte.removeAttribute('required');
        $checkBano.removeAttribute('required');
      }
      else {
        $checkCorte.setAttribute('required', '');
        $checkBano.setAttribute('required', '');
      }
    })
  });

}




function cargarTurno() {
  const $select = document.querySelector('#select');
  const $fecha = document.querySelector('#fecha');
  const $hora = document.querySelector('#hora');
  const $checkCorte = document.querySelector('#checkCorte');
  const $checkBano = document.querySelector('#checkBano');
  turnos.push({
    idCliente: $select.value,
    fecha: $fecha.value,
    hora: $hora.value,
    servicios: [
      {
        id: $checkCorte.checked ? 1 : 0
      },
      {
        id: $checkBano.checked ? 2 : 0
      }
    ]
  })
  alert('Turno reservado');
}

async function consultarTurnos() {

  await loadContent('./consultarTurnos.html').then(() => {
    console.log(document.querySelector('#table'));
    const $tableBody = document.querySelector('#table > tbody');


    turnos.forEach(turnos => {
      
      const row = document.createElement('tr');
      const tdCliente = document.createElement('td');
      const tdFecha = document.createElement('td');
      const tdHora = document.createElement('td');
      const tdServicios = document.createElement('td');

      tdCliente.innerHTML = usuarios.find(user => user.id === turnos.idCliente).nombre;
      tdFecha.innerHTML = turnos.fecha;
      tdHora.innerHTML = turnos.hora;
      let array = [];
      array = turnos.servicios.filter( servicio => servicio.id !== 0).map(servicio => servicio.id);

      tdServicios.innerHTML = array.map(id => `${servicios.find(s => s.id === id).nombre}`).join(', ');
      row.append(tdCliente, tdFecha, tdHora, tdServicios);
      $tableBody.appendChild(row);
    })
  });
  
}

async function dashboard() {
  await loadContent('./dashboard.html');
  console.log(document.querySelector('table > tbody'));
  const $tableBody = document.querySelector('table > tbody');

  const cantTurnos = [];

  usuarios.forEach(user => {
    cantTurnos.push({
      id: user.id,
      cant: turnos.filter(turno => turno.idCliente === user.id).length
    })
  })

  cantTurnos.forEach(cliente => {
    const row = document.createElement('tr');
    const tdCliente = document.createElement('td');
    const tdTurnos = document.createElement('td');
    tdCliente.innerHTML = usuarios.find(usuario => usuario.id === cliente.id).nombre;
    tdTurnos.innerHTML = cliente.cant;
    row.append(tdCliente, tdTurnos);
    $tableBody.appendChild(row);
  })

}
