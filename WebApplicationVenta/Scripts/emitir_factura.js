// --
const functions = new Functions()

//#region -- Cliente Empresa

// -- VARIABLES
var listFacturaDet = new Array()
var indexListFacturaDet = 1
var id_cliente_factura = 0

// -- TABLE
var tableFacturaDet = $('#tbl_factura_det').DataTable({
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


