using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TranHoangDieu_131
{
    [Table("Lophocs")]
    public class Lophoc 
    {
        
        [Key]
        public string MaLop { get; set; }

        public int TenLop { get; set; }

        public double SoTT { get; set; }
        public ICollection<Sinhvien>? Sinhvien {get; set;}

        

    }
}