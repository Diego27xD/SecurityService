$(document).ready(function () {


    var tabla = $('#tablaIngresos').DataTable({

        language: {

            lengthMenu: "Mostrar _MENU_ registros",

            info: "Mostrando _START_ a _END_ de _TOTAL_ registros",

            paginate: {

                next: "Siguiente",

                previous: "Anterior"

            }

        }

    });



    // BOTÓN BUSCAR PERSONALIZADO

    $("#btnBuscar").click(function () {


        var texto = $("#buscarIngreso").val();


        tabla.search(texto).draw();


    });



    // BUSCAR MIENTRAS ESCRIBE

    $("#buscarIngreso").keyup(function () {


        var texto = $(this).val();


        tabla.search(texto).draw();


    });



});





function abrirModal(
    matricula,
    propietario,
    dni,
    horaIngreso,
    horaSalida,
    usuario,
    area
) {


    document.getElementById("mMatricula").innerHTML = matricula;


    document.getElementById("mPropietario").innerHTML = propietario;


    document.getElementById("mDni").innerHTML = dni;


    document.getElementById("mHoraIngreso").innerHTML = horaIngreso;


    document.getElementById("mHoraSalida").innerHTML = horaSalida;


    document.getElementById("mUsuario").innerHTML = usuario;


    document.getElementById("mArea").innerHTML = area;



    document.getElementById("modalIngreso").style.display = "block";

}




function cerrarModal() {


    document.getElementById("modalIngreso").style.display = "none";


}





window.onclick = function (event) {


    var modal = document.getElementById("modalIngreso");


    if (event.target == modal) {


        modal.style.display = "none";


    }


}
