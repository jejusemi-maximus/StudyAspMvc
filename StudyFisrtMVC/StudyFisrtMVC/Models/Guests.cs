using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace StudyFisrtMVC.Models
{
    public class Guests
    {
        [Required(ErrorMessage ="이름을 입력하세요")]
        public string Name { get; set; }
        [Required(ErrorMessage ="이메일을 입력하세요")]
        [RegularExpression(".+\\@.\\..+",ErrorMessage ="이메일 형식을 확인해주세요")]
        public string Email { get; set; }
        [Required(ErrorMessage ="휴대폰번호를 입력하세요")]
        public string Phone { get; set; }
        [Required(ErrorMessage ="참석여부를 선택해주세여")]
        public bool? Attend { get; set; }
    }
}