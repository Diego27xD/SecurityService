$(document).ready(function () {


    $('#tablaAcceso').DataTable({


        language: {


            search: "Buscar:",


            lengthMenu:
                "Mostrar _MENU_ registros",


            info:
                "Mostrando _START_ a _END_ de _TOTAL_ registros",



            paginate: {


                next:
                    "Siguiente",


                previous:
                    "Anterior"


            },


            zeroRecords:
                "No se encontraron registros"


        }


    });


});

