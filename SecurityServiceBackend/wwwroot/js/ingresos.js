    $(document).ready(function () {

        $('#tablaIngresos').DataTable({

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

    function abrirModal(personal, dni, placa, fecha, encargado)
    {
        document.getElementById("mPersonal").innerText = personal;

    document.getElementById("mDni").innerText = dni;

    document.getElementById("mPlaca").innerText = placa;

    document.getElementById("mFecha").innerText = fecha;

    document.getElementById("mEncargado").innerText = encargado;

    document.getElementById("modalIngreso").style.display = "block";
        }

    function cerrarModal()
    {
        document.getElementById("modalIngreso").style.display = "none";
        }
