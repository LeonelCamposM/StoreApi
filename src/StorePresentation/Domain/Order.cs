using System;
using System.ComponentModel.DataAnnotations;

namespace StorePresentation.Domain
{
    public class Order
    {
        [Required(ErrorMessage = "La dirección es requerida.")]
        [StringLength(100, ErrorMessage = "La dirección debe tener como máximo {1} caracteres.")]
        public string Address { get; set; }

        [Range(0, double.MaxValue, ErrorMessage = "El total debe ser mayor o igual a cero.")]
        public double Total { get; set; }

        [Required(ErrorMessage = "Date is required")]
        public string Date { get; set; }

        [Required(ErrorMessage = "El email es requerido.")]
        [EmailAddress(ErrorMessage = "El email ingresado no es válido.")]
        public string Email { get; set; }

        public Order(string address, double total, string date, string email)
        {
            Address = address;
            Total = total;
            Date = date;
            Email = email;
        }
    }
}
