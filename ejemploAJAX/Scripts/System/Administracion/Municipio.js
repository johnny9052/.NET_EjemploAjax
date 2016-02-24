// Cuando se encuentra listo el doc esto es lo primero que se ejecutara
$(document).ready(function () {
    listar();
    cargarDepartamento();
});


/*Limpia los campos*/
function limpiar() {
    $("#txtId").val("");
    $("#txtNombre").val("");
    $("#txtDescripcion").val("");
    $("#selDepartamento").val("-1");
}


/* Guarda informacion */
function guardar() {

    var id = ($("#txtId").val() == "") ? -1 : $("#txtId").val();
    var nombre = $("#txtNombre").val();
    var descripcion = $("#txtDescripcion").val();
    var departamento = $("#selDepartamento").val();

    if (nombre != "" && descripcion != "" && departamento!=-1) {
        $.ajax({
            type: 'POST',
            url: "/Municipio/SaveInfo",
            data: { id: id, nombre: nombre, descripcion: descripcion, departamento:departamento },
            success: function (data) {

                var response = data.d[1];

                switch (response) {
                    case "Success":
                        alert("Operacion exitosa");
                        limpiar();
                        listar();
                        break;
                    case undefined:
                        alert("Error en la operacion.");
                        break;
                }


            },
            error: function (jqXHR, textStatus, errorThrown) {
                alert("Error detectado: " + textStatus + "\nExcepcion: " + errorThrown);
            }
        });
    } else {
        alert("Por favor ingresa todos los datos");
    }
}







/* Busca informacion */
function buscar() {

    var nombre = $("#txtNombre").val();

    if (nombre != "") {

        $.ajax({
            type: 'POST',
            url: "/Municipio/SearchInfo",
            data: { nombre: nombre },
            success: function (data) {
                if (data.d.length > 0) {
                    $("#txtId").val(data.d[0]);
                    $("#txtNombre").val(data.d[1]);
                    $("#txtDescripcion").val(data.d[2]);
                    $("#selDepartamento").val(data.d[3]);
                } else {
                    alert("No se encuentra")
                }


            },
            error: function (jqXHR, textStatus, errorThrown) {
                alert("Error detectado: " + textStatus + "\nExcepcion: " + errorThrown);
            }
        });
    } else {
        alert("Ingresa el dato de busqueda");
    }
}








/* Elimina informacion */
function eliminar() {

    var id = ($("#txtId").val() == "") ? -1 : $("#txtId").val();

    if (id != "-1") {

        $.ajax({
            type: 'POST',
            url: "/Municipio/DeleteInfo",
            data: { id: id },
            success: function (data) {

                var response = data.d[1];

                switch (response) {
                    case "Success":
                        alert("Operacion exitosa");
                        limpiar();
                        listar();
                        break;
                    case undefined:
                        alert("Error en la operacion.");
                        break;
                }


            },
            error: function (jqXHR, textStatus, errorThrown) {
                alert("Error detectado: " + textStatus + "\nExcepcion: " + errorThrown);
            }
        });
    } else {
        alert("Debe buscar primero el dato a eliminar");
    }
}





/* Lista informacion */
function listar() {

    $.ajax({
        type: 'POST',
        url: "/Municipio/ListInfo",
        data: "",
        success: function (data) {


            if (data.d.length > 0) {


                var qantity = (data.d.length);
                var rows = parseInt(data.d[qantity - 1]);
                var cols = parseInt(data.d[qantity - 2]);
                qantity -= 2;


                var list = "<table class='listado'>";

                list += "<tr>";
                list += "<th>Nombre</th>";
                list += "<th>Descripcion</th>";
                list += "<th>Departamento</th>";
                list += "</tr>";

                for (var k = 0; k < qantity; k += cols) {

                    list += "<tr>";

                    for (j = 1; j < cols; j++) {
                        list += "<td>" + data.d[k + j] + "</td>";
                    }

                    list += "</tr>";

                }

                list += "</table>";


                $("#listado").html(list);

            } else {
                alert("No se encuentra")
            }


        },
        error: function (jqXHR, textStatus, errorThrown) {
            alert("Error detectado: " + textStatus + "\nExcepcion: " + errorThrown);
        }
    });
}





/* Carga el combo de departamentos */
function cargarDepartamento() {

    $.ajax({
        type: 'POST',
        url: "/Municipio/LoadDepartamento",
        data: "",
        success: function (data) {

            if (data.d.length > 0) {

                var qantity = (data.d.length);
                var rows = parseInt(data.d[qantity - 1]);
                var cols = parseInt(data.d[qantity - 2]);
                qantity -= 2;

                var select = document.getElementById("selDepartamento");

                while(select.length > 1){
                    select.remove(select.length - 1);
                }

                var opt = null;

                for (var k = 0; k < qantity; k += cols) {
                    opt = new Option(data.d[k + 1],data.d[k]);
                    select.options[select.length] = opt;
                }

                select.value = -1;


            } else {
                alert("No se encuentra")
            }


        },
        error: function (jqXHR, textStatus, errorThrown) {
            alert("Error detectado: " + textStatus + "\nExcepcion: " + errorThrown);
        }
    });
}
