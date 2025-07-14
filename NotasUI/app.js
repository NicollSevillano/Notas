const API_URL = 'https://notasapi-d8cshth6axccdwdj.canadacentral-01.azurewebsites.net/api/notas';
const notasTableBody = document.getElementById('notasTableBody');

async function cargarNotas() {
  console.log('Llamando a:', API_URL);

  try {
    const response = await fetch(API_URL);
    const notas = await response.json();
    console.log('Notas recibidas:', notas);

    notasTableBody.innerHTML = '';

    notas.forEach(nota => {
      const row = document.createElement('tr');
      row.innerHTML = `
        <td>${nota.title}</td>
        <td>${nota.content}</td>
        <td>
          <button class="btn btn-sm btn-warning" onclick="editarNota(${nota.id})">Editar</button>
          <button class="btn btn-sm btn-danger" onclick="eliminarNota(${nota.id})">Eliminar</button>
        </td>
      `;
      notasTableBody.appendChild(row);
    });

  } catch (error) {
    console.error('Error al cargar notas:', error);
  }
}

async function eliminarNota(id) {
  if (!confirm('¿Seguro que quieres eliminar esta nota?')) return;

  try {
    const response = await fetch(`${API_URL}/${id}`, {
      method: 'DELETE'
    });

    if (response.ok) {
      alert('Nota eliminada');
      cargarNotas(); 
    } else {
      alert('Error al eliminar la nota');
    }
  } catch (error) {
    console.error('Error al eliminar:', error);
  }
}

function editarNota(id) {
  alert(`Aquí abrirías un formulario para editar la nota con ID: ${id}`);
}

window.onload = cargarNotas;
