// --
const functions = new Functions()

//#region -- Cliente Empresa

// -- VARIABLES
var listClienteEmpresa = new Array()
var indexListClienteEmpresa = 1
var id_cliente_factura = 0

// -- TABLE
var tableClienteEmpresa = $('#tbl_cliente_empresa').DataTable({
    responsive: true,
    bPaginate: true,
    bFilter: true,
    //lengthMenu: [20,50,80],
    pageLength: 100,
    bInfo: true,
    language: {
        "url": "../Files/lenguaje-spanish.json"
    },
    order: [[1, "asc"]]
})



$('#btnNuevoCliente').on('click', function () {
    $('#modalMantClienteEmpresa').modal('show');
    id_cliente_factura = 0
    limpiarCamposModal()
})

function limpiarCamposModal() {
    $('#txtruc').val('')
    $('#txtrazonsocial').val('')
    $('#txtdireccion').val('')
}

// --
function getListClienteEmpresa() {
    // --
    $("#tbl_cliente_empresa").DataTable().clear().draw()
    let url = urlGetListClienteEmpresa
    // --
    //showLoader();
    // --
    setTimeout(function () {
        $.ajax({
            type: "POST",
            url: url,
            dataType: 'json',
            success: function (data) {
                //console.log(data)
                let obj = data.apiResponse
                console.log(obj)

                if (obj != null) {

                    // -- CADETES
                    let lista = obj
                    listClienteEmpresa = lista

                    lista.forEach((element) => {

                        tableClienteEmpresa.row.add([
                            element.id_cliente_factura,
                            element.ruc,
                            element.razon_social,
                            element.direccion,
                            '<button type="button" class="btn btn-sm btn-danger" data-id="' + element.id_cliente_factura + '" id="btn_edit_row"><i class="tf-icons bx bx-edit"></i></button>' +
                            ' <button type="button" class= "btn btn-sm btn-danger" data-id="' + element.id_cliente_factura + '" id="btn_delete_row"><i class="tf-icons bx bx-trash"></i></button>'
                        ]).draw(false);
                        tableClienteEmpresa.columns.adjust()
                            .responsive.recalc();
                    })

                    functions.notify_message(MESSAGE.es.success_select, 'success')
                }
                //hideLoader();
            }
        });
        // --
    }, 1000)

}

$('#btnExtraerDatosRuc').on('click', function () {
    let txtruc = $('#txtruc').val()

    let objData = {
        "ruc": txtruc
    }
    if (txtruc.trim().length == 11) {
        $.ajax({
            type: "POST",
            url: urlObtenerDatosRuc,
            dataType: 'json',
            data: objData,
            success: function (data) {
                console.log(data)
                let obj = data.apiResponse
                console.log(obj)

                $('#txtrazonsocial').val(obj.razonSocial)
                $('#txtdireccion').val(obj.direccion)
            }
        });
    }
})

$(document).on('click', '#btn_edit_row', function () {
    // --
    let value = $(this).attr('data-id')

    let ObjClienteEmpresa = listClienteEmpresa.find(x => x.id_cliente_factura == value)
    console.log(ObjClienteEmpresa)
    id_cliente_factura = ObjClienteEmpresa.id_cliente_factura
    $('#txtruc').val(ObjClienteEmpresa.ruc)
    $('#txtrazonsocial').val(ObjClienteEmpresa.razon_social)
    $('#txtdireccion').val(ObjClienteEmpresa.direccion)
    $('#modalMantClienteEmpresa').modal('show')
})

$(document).on('click', '#btn_delete_row', function () {
    // --
    let value = $(this).attr('data-id')

    Swal.queue([{
        icon: 'info',
        title: '¿Desea eliminar el registro?',
        confirmButtonText: 'Si',
        cancelButtonText: 'No',
        cancelButtonColor: '#d33',
        showCancelButton: true,
        showLoaderOnConfirm: true,
        preConfirm: () => {

            let objData = {
                "id_cliente_factura": value
            }
            $.ajax({
                url: urlDeleteClienteFactura,
                type: 'POST',
                dataType: 'json',
                data: objData,
                success: function (d) {
                    //console.log(d)

                    getListClienteEmpresa()
                }
            });
        }
    }])
    $('#modal_historial_sanciones').modal('show')
})

$('#btnGuardar').on('click', function () {
    let txtruc = $('#txtruc').val().trim()
    let txtrazonsocial = $('#txtrazonsocial').val().trim()
    let txtdireccion = $('#txtdireccion').val().trim()

    let objData = {
        "id_cliente_factura": id_cliente_factura,
        "ruc": txtruc,
        "razon_social": txtrazonsocial,
        "direccion": txtdireccion,
    }
    console.log(objData)
    if (txtruc.length == 11 && txtrazonsocial.length > 0 && txtdireccion.length > 0) {
        

        $.ajax({
            type: "POST",
            url: urlSaveClienteEmpresa,
            dataType: 'json',
            data: objData,
            success: function (data) {
                $('#modalMantClienteEmpresa').modal('hide')
                getListClienteEmpresa()
            }
        });
    } else {

        functions.notify_message('Campos incompletos', 'danger')
    }

    
})

getListClienteEmpresa()