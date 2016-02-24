// Cuando se encuentra listo el doc esto es lo primero que se ejecutara
$(document).ready(function () {
    listar();
    cargarDepartamento();
});


/*Limpia campos de texto*/
function limpiar() {
    $("#txtId").val("");
    $("#txtNombre").val("");
    $("#txtApellido").val("");
    $("#txtSemestre").val("");
    $("#txtDocumento").val("");
    $("#selDepartamento").val("-1");
    $("#selMunicipio").val("-1");
}


/* Guarda informacion */
function guardar() {

    var id = ($("#txtId").val() == "") ? -1 : $("#txtId").val();
    var nombre = $("#txtNombre").val();
    var apellido = $("#txtApellido").val();
    var semestre = $("#txtSemestre").val();
    var documento = $("#txtDocumento").val();
    var municipio = $("#selMunicipio").val();

    if (nombre != "" && apellido != "" && semestre != "" && documento != "" && municipio != -1) {
        $.ajax({
            type: 'POST',
            url: "/Estudiantes/SaveInfo",
            data: { id: id, nombre: nombre, apellido: apellido, semestre: semestre, documento: documento, municipio: municipio },
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







/* Buscar informacion */
function buscar() {    
    var documento = $("#txtDocumento").val();

    if (documento != "") {

        $.ajax({
            type: 'POST',
            url: "/Estudiantes/SearchInfo",
            data: { documento: documento },
            success: function (data) {
                if (data.d.length > 0) {
                    $("#txtId").val(data.d[0]);
                    $("#txtNombre").val(data.d[1]);
                    $("#txtApellido").val(data.d[2]);
                    $("#txtSemestre").val(data.d[3]);
                    $("#txtDocumento").val(data.d[4]);
                    $("#selDepartamento").val(data.d[6]);
                    cargarMunicipio(data.d[5]);                    
                    
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
            url: "/Estudiantes/DeleteInfo",
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
        url: "/Estudiantes/ListInfo",
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
                list += "<th>Apellido</th>";
                list += "<th>Semestre</th>";
                list += "<th>Documento</th>";
                list += "<th>Municipio</th>";
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





/* Carga en un combo los departamentos */
function cargarDepartamento() {

    $.ajax({
        type: 'POST',
        url: "/Estudiantes/LoadDepartamento",
        data: "",
        success: function (data) {

            if (data.d.length > 0) {


                var qantity = (data.d.length);
                var rows = parseInt(data.d[qantity - 1]);
                var cols = parseInt(data.d[qantity - 2]);
                qantity -= 2;

                var select = document.getElementById("selDepartamento");

                while (select.length > 1) {
                    select.remove(select.length - 1);
                }

                var opt = null;

                for (var k = 0; k < qantity; k += cols) {
                    opt = new Option(data.d[k + 1], data.d[k]);
                    select.options[select.length] = opt;
                }

                select.value = -1;


            } else {
                alert("No se encuentra");
            }


        },
        error: function (jqXHR, textStatus, errorThrown) {
            alert("Error detectado: " + textStatus + "\nExcepcion: " + errorThrown);
        }
    });
}






/* Carga en un combo los municipios */
function cargarMunicipio(seleccion) {

    var departamento = $("#selDepartamento").val();

    if (departamento != -1) {

        $.ajax({
            type: 'POST',
            url: "/Estudiantes/LoadMunicipio",
            data: { departamento: departamento },
            success: function (data) {

                if (data.d.length > 0) {

                    var qantity = (data.d.length);
                    var rows = parseInt(data.d[qantity - 1]);
                    var cols = parseInt(data.d[qantity - 2]);
                    qantity -= 2;

                    var select = document.getElementById("selMunicipio");

                    while (select.length > 1) {
                        select.remove(select.length - 1);
                    }

                    var opt = null;

                    for (var k = 0; k < qantity; k += cols) {
                        opt = new Option(data.d[k + 1], data.d[k]);
                        select.options[select.length] = opt;
                    }

                    if (seleccion) {
                        $("#selMunicipio").val(seleccion);
                    } else {
                        select.value = -1;
                    }
                    
                } else {

                    var select = document.getElementById("selMunicipio");

                    while (select.length > 1) {
                        select.remove(select.length - 1);
                    }
                }


            },
            error: function (jqXHR, textStatus, errorThrown) {
                alert("Error detectado: " + textStatus + "\nExcepcion: " + errorThrown);
            }
        });
    }
}