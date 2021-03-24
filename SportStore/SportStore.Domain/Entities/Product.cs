using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace SportStore.Domain.Entities
{
    public class Product
    {
        [HiddenInput(DisplayValue =false)]
        public int ProductID { get; set; }
        [Required(ErrorMessage ="이름을 입력하세요!")]
        public string Name { get; set; }
        [DataType(DataType.MultilineText)]
        [Required(ErrorMessage ="상세 내용을 입력하세요!")]
        public string Description { get; set; }

        [Required]
        [Range(0.01,double.MaxValue,ErrorMessage ="유효한 값을 올려주세요!")]
        public decimal Price { get; set; }
        [Required(ErrorMessage ="카탈로그를 선택하세요!")]
        public string Category { get; set; }
    }
}

