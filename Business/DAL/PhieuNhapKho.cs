//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Business.DAL
{
    using System;
    using System.Collections.Generic;
    
    public partial class PhieuNhapKho
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public PhieuNhapKho()
        {
            this.CT_PhieuNhapKho = new HashSet<CT_PhieuNhapKho>();
        }
    
        public int MaPNK { get; set; }
        public int MaDDH { get; set; }
        public int MaTK { get; set; }
        public System.DateTime NgayThem { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<CT_PhieuNhapKho> CT_PhieuNhapKho { get; set; }
        public virtual DonDatHang DonDatHang { get; set; }
        public virtual TaiKhoan TaiKhoan { get; set; }
    }
}
