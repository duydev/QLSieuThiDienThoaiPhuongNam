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
    
    public partial class TheKhachHang
    {
        public int MaThe { get; set; }
        public int MaKH { get; set; }
        public int DiemTichLuy { get; set; }
        public bool TinhTrang { get; set; }
        public System.DateTime NgayThem { get; set; }
    
        public virtual KhachHang KhachHang { get; set; }
    }
}
