// Cuando se encuentra listo el doc esto es lo primero que se ejecutara
$(document).ready(function () {
    listar();
});


/*Limpia los campos*/
function limpiar() {
    $("#txtId").val("");
    $("#txtUsuario").val("");
    $("#txtPassword").val("");
}


/* Guarda informacion */
function guardar() {

    var id = ($("#txtId").val() == "") ? -1 : $("#txtId").val();
    var usuario = $("#txtUsuario").val();
    var password = $("#txtPassword").val();

    if (usuario != "" && password != "") {
        $.ajax({
            type: 'POST',
            url: "/Usuarios/SaveInfo",
            data: { id: id, usu: usuario, pass: password },
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

    var usuario = $("#txtUsuario").val();

    if (usuario != "") {

        $.ajax({
            type: 'POST',
            url: "/Usuarios/SearchInfo",
            data: { usu: usuario },
            success: function (data) {

                if (data.d.length > 0) {
                    $("#txtId").val(data.d[0]);
                    $("#txtUsuario").val(data.d[1]);
                    $("#txtPassword").val(data.d[2]);
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
            url: "/Usuarios/DeleteInfo",
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
        url: "/Usuarios/ListInfo",
        data: "",
        success: function (data) {


            if (data.d.length > 0) {


                var qantity = (data.d.length);
                var rows = parseInt(data.d[qantity - 1]);
                var cols = parseInt(data.d[qantity - 2]);
                qantity -= 2;


                var list = "<table class='listado'>";

                list += "<tr>";
                list += "<th>Nombre usuario</th>";
                list += "<th>Password</th>";
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
