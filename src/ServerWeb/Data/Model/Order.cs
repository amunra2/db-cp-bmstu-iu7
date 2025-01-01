using Microsoft.AspNetCore.Mvc.ModelBinding;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ServerWeb.Data.Model {
    public class Order {

        [BindNever] // поле никогда не будет показано на странице
        public int id { get; set; }

        [Display(Name = "Имя")] // Ограничения на поля
        [StringLength(10)]
        [Required(ErrorMessage = "Длина имени не менее 2 символов")]
        public string name { get; set; }

        [Display(Name = "Фамилия")] // Ограничения на поля
        [StringLength(10)]
        [Required(ErrorMessage = "Длина фамилии не менее 5 символов")]
        public string surname { get; set; }

        [Display(Name = "Адрес доставки")] // Ограничения на поля
        [StringLength(30)]
        [Required(ErrorMessage = "Длина адреса доставки не менее 5 символов")]
        public string adress { get; set; }

        [Display(Name = "Номер телефона")] // Ограничения на поля
        [DataType(DataType.PhoneNumber)]
        [StringLength(10)]
        [Required(ErrorMessage = "Длина номера телефона не менее 10 символов")]
        public string phone { get; set; }

        [Display(Name = "Email")] // Ограничения на поля
        [DataType(DataType.EmailAddress)]
        [StringLength(25)]
        [Required(ErrorMessage = "Длина email не менее 10 символов")]
        public string email { get; set; }

        [BindNever]
        [ScaffoldColumn(false)] // поле скрыто ото всех
        public DateTime orderTime { get; set; }

        public List<OrderDetail> orderDetails { get; set; }


    }
}
