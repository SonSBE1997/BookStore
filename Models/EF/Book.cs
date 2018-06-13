namespace Models.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Book")]
    public partial class Book
    {
        public long ID { get; set; }

        [Required]
        [StringLength(250)]
        [Display(Name = "Tên sách")]
        public string Name { get; set; }

        [StringLength(50)]
        [Display(Name = "Mã sách")]
        public string Code { get; set; }

        [StringLength(500)]
        [Display(Name = "Mô tả")]
        public string Description { get; set; }

        [StringLength(250)]
        [Display(Name = "Ảnh bìa")]
        public string CoverPhoto { get; set; }

        [Display(Name = "Đơn giá")]
        public decimal Price { get; set; }

        [Display(Name = "Số lượng sách")]
        public int? Quantity { get; set; }

        [Column(TypeName = "ntext")]
        [Display(Name = "Giới thiệu sách")]
        public string Detail { get; set; }

        [Display(Name = "Tác giả")]
        public long? BookAuthor { get; set; }

        [Display(Name = "Danh mục sách")]
        public long? BookCategory { get; set; }

        [Display(Name = "Nhà xuất bản")]
        public long? BookPublisher { get; set; }

        [Display(Name = "Sách bán chạy")]
        public bool TopHot { get; set; }

        [Display(Name = "Sản phẩm mới")]
        public bool New { get; set; }

        [Display(Name = "Tình trạng bán hàng")]
        public bool Status { get; set; }
    }
}
