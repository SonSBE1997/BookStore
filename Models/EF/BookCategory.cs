namespace Models.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("BookCategory")]
    public partial class BookCategory
    {
        public long ID { get; set; }

        [StringLength(250)]
        [Display(Name = "Tên danh mục")]
        public string Name { get; set; }

        [Display(Name = "Thư mục cha")]
        public long? ParentID { get; set; }

        [Display(Name = "Thứ tự sắp xếp")]
        public int? DisplayOrder { get; set; }

        [Display(Name = "Trạng thái bán hàng")]
        public bool Status { get; set; }
    }
}
