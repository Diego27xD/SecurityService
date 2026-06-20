$(document).ready(function () {


    let tiempoBusqueda;


    function cargarUsuarios(page = 1) {


        let texto = $("#buscarUsuario").val();



        $.ajax({

            url: "/Usuarios/Index",

            type: "GET",

            data: {

                buscar: texto,

                page: page,

                limit: 10

            },


            headers: {

                "X-Requested-With": "XMLHttpRequest"

            },


            success: function (resultado) {


                let contenido = $("<div>").html(resultado);



                // actualizar filas

                $("#tablaDatos").html(
                    contenido.find("#tablaDatos").html()
                );



                // actualizar botones paginacion

                $("#paginacion").html(
                    contenido.find("#paginacion").html()
                );



                // mantener texto buscado

                $("#buscarUsuario").val(texto);


            },


            error: function () {

                console.log("Error cargando usuarios");

            }


        });


    }






    // BUSQUEDA AUTOMATICA

    $("#buscarUsuario").keyup(function () {


        clearTimeout(tiempoBusqueda);



        tiempoBusqueda = setTimeout(function () {


            cargarUsuarios(1);


        }, 400);



    });






    // PAGINACION

    $(document).on("click", ".btn-pagina", function (e) {


        e.preventDefault();



        let pagina = $(this).data("page");



        cargarUsuarios(pagina);



    });



});





function abrirModal(
    nombre,
    dni,
    telefono,
    cargo,
    departamento,
    estado
) {


    document.getElementById("mNombre").innerHTML = nombre;

    document.getElementById("mDni").innerHTML = dni;

    document.getElementById("mTelefono").innerHTML = telefono;

    document.getElementById("mCargo").innerHTML = cargo;

    document.getElementById("mDepartamento").innerHTML = departamento;

    document.getElementById("mEstado").innerHTML = estado;



    document.getElementById("modalUsuario").style.display = "block";

}



function cerrarModal() {


    document.getElementById("modalUsuario").style.display = "none";


}




window.onclick = function (event) {


    var modal = document.getElementById("modalUsuario");


    if (event.target == modal) {

        modal.style.display = "none";

    }

}