/* Se cierra la sesión activa */
function LogOut() {
    
    $.ajax({
        type: 'post',
        url: "/Security/LogOut",
        data: "",
        success: function (data) {

            var response = data.resp;

            switch (response) {
                case "Success":
                    location.href = document.URL;
                    break;
                case undefined:
                    alert("No se pudo cerrar sesion");
                    break;
            }


        },
        error: function (jqXHR, textStatus, errorThrown) {
            alert("Error detectado: " + textStatus + "\nExcepcion: " + errorThrown);
        }
    });
}

