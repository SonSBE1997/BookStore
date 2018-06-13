namespace Models.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("BookAuthor")]
    public partial class BookAuthor
    {
        public long ID { get; set; }

        [Required]
        [StringLength(250)]
        [Display(Name = "Họ và tên")]
        public string Name { get; set; }

        [StringLength(250)]
        [Display(Name = "Ảnh")]
        public string PictureProfile { get; set; }

        [StringLength(250)]
        [Display(Name = "Địa chỉ")]
        public string Address { get; set; }

        [StringLength(50)]
        [Display(Name = "Số điện thoại")]
        public string PhoneNumber { get; set; }

        [Column(TypeName = "ntext")]
        [Display(Name = "Tiểu sử")]
        public string Story { get; set; }
    }
}
