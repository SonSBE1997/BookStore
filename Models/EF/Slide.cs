namespace Models.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Slide")]
    public partial class Slide
    {
        public long ID { get; set; }

        [Required]
        [StringLength(250)]
        [Display(Name = "Tên slide")]
        public string Name { get; set; }

        [Required]
        [StringLength(50)]
        [Display(Name = "Hình ảnh")]
        public string Link { get; set; }

        [Display(Name = "Trạng thái hiển thị")]
        public bool Status { get; set; }
    }
}
