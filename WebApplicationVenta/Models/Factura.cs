using System;
using System.Collections.Generic;
using System.Text;

namespace Entity
{
    class Factura
    {
    }

    public class SaveFacturaFlt
    {
        public long id_factura { get; set; }
        public string serie { get; set; }
        public string num_correlativo { get; set; }
        public DateTime fec_emision { get; set; }
        public string ruc { get; set; }
        public int id_cliente_factura { get; set; }
        public string razon_social { get; set; }
        public DateTime fec_vcmto { get; set; }
        public int id_moneda { get; set; }
        public decimal por_impto_venta { get; set; }
        public decimal imp_impto_venta { get; set; }
        public decimal imp_valor_venta { get; set; }
        public decimal imp_total_venta { get; set; }
        public decimal imp_paga_venta { get; set; }
        public decimal imp_vuelto_venta { get; set; }
        public int id_usuario { get; set; }
        public string correo_cliente { get; set; }
        public List<SaveFacturaDetFlt> ListSaveFacturaDetFlt { get; set; }
    }

    public class SaveFacturaDetFlt
    {
        public long id_factura { get; set; }
        public int item_factura { get; set; }
        public string conceptop_vta { get; set; }
        public decimal imp_unit_vta_det { get; set; }
        public int can_unit_vta_det { get; set; }
        public decimal imp_costo_vta_det { get; set; }
        public decimal por_impto_vta_det { get; set; }
        public decimal imp_impto_vta_det { get; set; }
        public decimal imp_precio_vta_det { get; set; }
    }
}
