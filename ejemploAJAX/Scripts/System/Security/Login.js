/* Funciones jQuery */
$(window).load(function () {
    $("#txtUser").focus();
});

/* Identificar a un usuario del sistema */
function validarUsuario() {

    var usuario = $("#txtUser").val();
    var password = $("#txtKey").val();

    if (usuario != "" && password != "") {

        $.ajax({
            type: 'post',
            url: "/Security/UserIdentify",
            data: { usu: usuario, pass: password },
            success: function (data) {

                var response = data.d[1];

                switch (response) {
                    case "Success":
                        /*Funcion que refresca la pagina*/
                        LoginProcessSuccessfull();
                        break;
                    case undefined:
                        alert("Datos Incorrectos.");
                        break;
                }


            },
            error: function (jqXHR, textStatus, errorThrown) {
                alert("Error detectado: " + textStatus + "\nExcepcion: " + errorThrown);
            }
        });
    } else {
        alert("Por favor ingrese todos los datos");
    }
}


/* Cuando Se Ejecuta El Login Exitosamente */
function LoginProcessSuccessfull() {

    /*Se obtiene la variable GET url actual, decodificandola, si no existe solo abre el inicio*/    
    var url = GetURLvar("url");

    /*Si pudo generarla se va a la urlsolicitada, si no refresca la pagina actual*/
    if (url != undefined) {
        location.href = url;
    } else {
        location.href = document.URL;
    }
}


/*Valida si la variable GET url? se encuentra definida, debido a que puede especificar en que pagina se encontraba antes de 
que finalizara su sesion, de ser asi la decoficia y la abre, si no solo refresca la pagina para ir al inicio*/
function GetURLvar(var_name) {
    /*Se define una expresion regular para validar la url*/
    var re = new RegExp(var_name + "(?:=([^&]*))?", "i");

    /*Valida si se puede decodificar la URI de la pagina actual ejemplo*/
    /*
    http%3A%2F%2Fw3schools.com%2Fmy%20test.asp%3Fname%3Dst%C3%A5le%26car%3Dsaab     // Encoded URI
    http://w3schools.com/my test.asp?name=ståle&car=saab                            // Decoded URI
    */
    var pm = re.exec(decodeURIComponent(location.search));

    /*Determina si pudo o no ser decodificada, dependiendo si existia dicha variable GET*/
    if (pm === null) return undefined;
    return pm[1] || "";
}