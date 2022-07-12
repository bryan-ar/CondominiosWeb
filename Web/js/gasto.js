$(function(){ // .ready() callback, is only executed when the DOM is fully loaded
    fnCargarCondominios(1);
    fnCargarCondominios(2);

    fnCargarTiposGasto();
    fnCargarTiposCalculo();

    $('input:checkbox').click(function() {
        $('input:checkbox').not(this).prop('checked', false);
    });
});

function fnCargarCondominios(tab){
    $.ajax({
        type: "GET",
        url: "https://localhost:44310/api/gasto/condominios/",
        success: function (data) {
            if(data.length > 0){
                $("#cboCondominio" + tab).empty();
                $("#cboCondominio" + tab).append('<option value="0">Seleccionar</option>');
                $("#cboTorre" + tab).empty();
                $('#cboTorre' + tab).append('<option value="0">Seleccionar</option>');
                $("#cboDepartamento" + tab).empty();
                $('#cboDepartamento' + tab).append('<option value="0">Seleccionar</option>');

                $.each(data, function(index, o){
                    $('#cboCondominio' + tab).append('<option value="' + o.idcondominio + '">' + o.Nombre + '</option>');
                });
            }
        },
        error: function(xhr, status, error) {
            var err = eval("(" + xhr.responseText + ")");
            alert(err.Message);
          }
    });
}

function fnCargarTorres(tab, idcondominio){

    if(idcondominio == 0){
        $("#cboTorre" + tab).empty();
        $('#cboTorre' + tab).append('<option value="0">Seleccionar</option>');
        $("#cboDepartamento" + tab).empty();
        $('#cboDepartamento' + tab).append('<option value="0">Seleccionar</option>');
        return;
    }

    $.ajax({
        type: "GET",
        url: "https://localhost:44310/api/gasto/torres/" + idcondominio,
        success: function (data) {
            if(data.length > 0){
                $("#cboTorre" + tab).empty();
                $('#cboTorre' + tab).append('<option value="0">Seleccionar</option>');
                $("#cboDepartamento" + tab).empty();
                $('#cboDepartamento' + tab).append('<option value="0">Seleccionar</option>');

                $.each(data, function(index, o){
                    $('#cboTorre' + tab).append('<option value="' + o.idtorre + '">' + o.Nombre + '</option>');
                });
            }
        },
        error: function(xhr, status, error) {
            var err = eval("(" + xhr.responseText + ")");
            alert(err.Message);
          }
    });

}

function fnCargarDepartamentos(tab, idtorre){

    if(idtorre == 0){
        $("#cboDepartamento" + tab).empty();
        $('#cboDepartamento' + tab).append('<option value="0">Seleccionar</option>');
        return;
    }

    $.ajax({
        type: "GET",
        url: "https://localhost:44310/api/gasto/departamentos/" + idtorre,
        success: function (data) {
            if(data.length > 0){
                $("#cboDepartamento" + tab).empty();
                $('#cboDepartamento' + tab).append('<option value="0">Seleccionar</option>');

                $.each(data, function(index, o){
                    $('#cboDepartamento' + tab).append('<option value="' + o.iddepartamento + '">' + o.NumDepartamento + '</option>');
                });
            }
        },
        error: function(xhr, status, error) {
            var err = eval("(" + xhr.responseText + ")");
            alert(err.Message);
          }
    });

}

function fnListarProveedores(){

    var nombre = $("#iptRazonSocial").val();

    $.ajax({
        type: "GET",
        url: "https://localhost:44310/api/gasto/proveedores/" + nombre,
        success: function (data) {
            $("#tbProveedores tbody").empty();

            if(data.length > 0){
                $.each(data, function(index, o){
                    debugger;
                    $("#tbProveedores tbody").append("<tr><td><input name='checks' type='checkbox' id='" + o.idproveedor + "' value='" + o.RazonSocial + "' /></td><td>" + o.idproveedor + 
                    "</td><td>" + o.RazonSocial + "</td><td>" + o.tipoDocumento + "</td><td>" + o.nrodocumento + "</td></tr>");
                });
            }else{
                $("#tbProveedores tbody").append("<tr><td colspan='5'>No existen registros</td></tr>");
            }
        },
        error: function(xhr, status, error) {
            var err = eval("(" + xhr.responseText + ")");
            alert(err.Message);
          }
    });
}

function fnSeleccionarProveedor(){
    var checkeds = $("input[name=checks]:checked");

    if(checkeds.length == 0){
        alert("Por favor seleccione un proveedor");
        return;
    }

    var checked = checkeds[0];

    var ref_this = $("#myTab li a.active");

    if(ref_this[0].childNodes[0].data == "Consultar"){
        $("#iptIdProveedor1").val(checked.id);
        $("#iptProveedor1").val(checked.value);
    }else{
        $("#iptIdProveedor2").val(checked.id);
        $("#iptProveedor2").val(checked.value);
    }


    
    $("#basicExampleModal").modal("toggle");
}

function fnConsultarGasto(){
    var oParams = {
        "IdCondominio": $("#cboCondominio1").val(),
        "IdTorre": $("#cboTorre1").val(),
        "IdDepartamento": $("#cboDepartamento1").val(),
        "IdProveedor": $("#iptIdProveedor1").val(),
        "FechaGasto": $("#iptFechaGasto1").val(),
        "FechaVencimiento": $("#iptFechaVencimiento1").val()
      }

    var params = "idCondominio=" + oParams.IdCondominio + "&idTorre=" + oParams.IdTorre + "&idDepartamento=" + oParams.IdDepartamento +
    "&idProveedor=" + oParams.IdProveedor + "&fechaGasto=" + oParams.FechaGasto + "&fechaVencimiento=" + oParams.FechaVencimiento;

      $.ajax({
        type: "GET",
        url: "https://localhost:44310/api/gasto?" + params,
        success: function (data) {
            if(data != null){
                $("#iptDescripcion1").val(data.descripcion);
                $("#iptTipoGasto1").val(data.tipoGastoDesc);
                $("#iptTipoCalculo1").val(data.tipoCalculoDesc);
                $("#iptMonto1").val("S/ " + data.montosoles);
            }else{
                alert("No se encontraron registros");
            }
        },
        error: function(xhr, status, error) {
            alert("No se encontraron registros");
          }
    });
}

function fnRegistrarGasto(){
    debugger;
    var gasto = {
        "descripcion": $("#iptDescripcion2").val(),
        "idProveedor": $("#iptIdProveedor2").val(),
        "fechaGasto": $("#iptFechaGasto2").val(),
        "fechaVencimiento": $("#iptFechaVencimiento2").val(),
        "tipoGasto": $("#cboTipoGasto2").val(),
        "tipoCalculo": $("#cboTipoCalculo2").val(),
        "idCondominio": $("#cboCondominio2").val(),
        "idTorre": $("#cboTorre2").val(),
        "idDepartamento": $("#cboDepartamento2").val(),
        "montosoles": $("#iptMonto2").val()
      }

      var oParams = {
        "gasto": gasto
      }

      var gasto = {
        "message": "Hola"
      }

    // var params = "idCondominio=" + oParams.IdCondominio + "&idTorre=" + oParams.IdTorre + "&idDepartamento=" + oParams.IdDepartamento +
    // "&idProveedor=" + oParams.IdProveedor + "&fechaGasto=" + oParams.FechaGasto + "&fechaVencimiento=" + oParams.FechaVencimiento;

      $.ajax({
        type: "POST",
        url: "https://localhost:44310/api/gasto",
        data: JSON.stringify({gasto}),
        contentType: "application/json",
        success: function (data) {
            debugger;
            if(data != null){
                $("#iptDescripcion1").val(data.descripcion);
                $("#iptTipoGasto1").val(data.tipoGastoDesc);
                $("#iptTipoCalculo1").val(data.tipoCalculoDesc);
                $("#iptMonto1").val("S/ " + data.montosoles);
            }else{
                alert("No se encontraron registros");
            }
        },
        error: function(xhr, status, error) {
            alert("No se encontraron registros");
          }
    });
}

function fnCargarTiposCalculo(){
    $.ajax({
        type: "GET",
        url: "https://localhost:44310/api/gasto/tiposcalculo/",
        success: function (data) {
            if(data.length > 0){
                $("#cboTipoCalculo2").empty();
                $("#cboTipoCalculo2").append('<option value="0">Seleccionar</option>');
                
                $.each(data, function(index, o){
                    $('#cboTipoCalculo2').append('<option value="' + o.idTipoCalculo + '">' + o.descripcion + '</option>');
                });
            }
        },
        error: function(xhr, status, error) {
            var err = eval("(" + xhr.responseText + ")");
            alert(err.Message);
          }
    });
}

function fnCargarTiposGasto(){
    $.ajax({
        type: "GET",
        url: "https://localhost:44310/api/gasto/tiposgasto/",
        success: function (data) {
            if(data.length > 0){
                $("#cboTipoGasto2").empty();
                $("#cboTipoGasto2").append('<option value="0">Seleccionar</option>');
                
                $.each(data, function(index, o){
                    $('#cboTipoGasto2').append('<option value="' + o.idGasto + '">' + o.descripcion + '</option>');
                });
            }
        },
        error: function(xhr, status, error) {
            var err = eval("(" + xhr.responseText + ")");
            alert(err.Message);
          }
    });
}