using System.ComponentModel.DataAnnotations;

namespace Hotel.WEB.Areas.Admin.Models
{
    public class ConvenienceDetailsVm
    {
        public int  Id { get; set; }

        [Required(ErrorMessage = "Поле названия обязательно для заполнения")]
        [RegularExpression(@"^[А-Яа-я- ]+$", ErrorMessage = "Название должно содержать только буквы или знак \"-\"")]
        [Display(Name = "Название")]
        public string Name { get; set; }
    }
}