using ecommerce.Model;
using FluentValidation;

namespace ecommerce.Validators
{
    public class TbProductoValidator : AbstractValidator<TbProducto>
    {
        public TbProductoValidator()
        {
            RuleFor(producto => producto.Nombre)
                .NotEmpty().WithMessage("El nombre es obligatorio.")
                .Length(2, 100).WithMessage("El nombre debe tener entre 2 y 100 caracteres.");

            RuleFor(producto => producto.Descripcion)
                .NotEmpty().WithMessage("La descripción es obligatoria.");

            RuleFor(producto => producto.Precio)
                .GreaterThan(0).WithMessage("El precio debe ser mayor que 0.");

            RuleFor(producto => producto.Stock)
                .GreaterThanOrEqualTo(0).WithMessage("El stock no puede ser negativo.");

            RuleFor(producto => producto.StockReservado)
                .GreaterThanOrEqualTo(0).WithMessage("El stock reservado no puede ser negativo.");

            RuleFor(producto => producto.Habilitado)
                .NotNull().WithMessage("El campo habilitado es obligatorio.");

            RuleFor(producto => producto.Eliminado)
                .InclusiveBetween(0, 1).WithMessage("El campo eliminado debe ser 0 o 1.");
        }
    
    }
}
