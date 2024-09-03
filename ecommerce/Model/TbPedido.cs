namespace ecommerce.Model
{
    public class TbPedido
    {
        public int PedidoId { get; set; }
        public int UsuarioId { get; set; }
        public int EstadoId { get; set; }
        public decimal ValorTotal { get; set; }
        public DateTime Fecha { get; set; }
        public bool Eliminado { get; set; }

    }
}
