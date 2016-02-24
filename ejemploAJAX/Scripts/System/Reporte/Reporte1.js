/*Se cargan los paquetes del api de visualizacion*/
google.charts.load('current', { 'packages': ['corechart', 'controls', 'bar'] });
/*Se define la funcion graficadora*/
google.charts.setOnLoadCallback(generarReporte);


function generarReporte() {

    $.ajax({
        type: 'POST',
        url: "/Reporte1/GenerarReporte",
        data: "",
        success: function (res) {

            //Se definen los datos
            var data = new google.visualization.DataTable();
            data.addColumn('string', 'Municipio');
            data.addColumn('number', 'Percentaje ');
            
            if (res.d.length > 0) {

                var qantity = (res.d.length);
                var rows = parseInt(res.d[qantity - 1]);
                var cols = parseInt(res.d[qantity - 2]);
                qantity -= 2;              

                
                for (var k = 0; k < qantity; k += cols) {
                    data.addRow([res.d[k + 1], parseInt(res.d[k])]);
                }
                               
                // Set chart options
                var options = {
                    'title': 'Distribucion de estudiantes por municipio',
                    'width': '100%',
                    'height': 300,
                    'legend': 'rigth'//Ubicacion de la descripcion de los colores
                };

                // Instantiate and draw the chart.
                var chart = new google.visualization.PieChart(document.getElementById('grafico1'));
                chart.draw(data, options);
               

            } else {
                alert("No se encuentra")
            }


        },
        error: function (jqXHR, textStatus, errorThrown) {
            alert("Error detectado: " + textStatus + "\nExcepcion: " + errorThrown);
        }
    });

   

}


