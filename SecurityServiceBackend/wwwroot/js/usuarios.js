$(document).ready(function () {

    $('#tablaUsuarios').DataTable({

        language: {
            search: "Buscar:",
            lengthMenu: "Mostrar _MENU_ registros",
            info: "Mostrando _START_ a _END_ de _TOTAL_ registros",

            paginate: {
                next: "Siguiente",
                previous: "Anterior"
            }
        }

    });

});

function abrirModal(nombre, dni, telefono, departamento, estado) {

    document.getElementById("mNombre").innerText = nombre;

    document.getElementById("mDni").innerText = dni;

    document.getElementById("mTelefono").innerText = telefono;

    document.getElementById("mDepartamento").innerText = departamento;

    document.getElementById("mEstado").innerText = estado;

    document.getElementById("modalUsuario").style.display = "block";
}

function cerrarModal() {

    document.getElementById("modalUsuario").style.display = "none";

}