using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace krediku_fe.Models
{
    public class TranViewModel
    {
        [DisplayName("Agreement Number")]
        public string NoAgreement { get; set; }
        [DisplayName("No. BPKB")]
        public string NoBPKB { get; set; }
        [DisplayName("Branch Id")]
        public string BranchId { get; set; }
        [DisplayName("Tanggal BPKB")]
        public DateTime DateBPKB { get; set; }
        [DisplayName("No. Faktur")]
        public string NoFaktur { get; set; }
        [DisplayName("Tanggal Faktur")]
        public DateTime DateFaktur { get; set; }
        [DisplayName("Lokasi Penyimpanan")]
        public string Location { get; set; }
        [DisplayName("Nomor Polisi")]
        public string NoPolis { get; set; }
        [DisplayName("Tanggal BPKB In")]
        public DateTime DateInput { get; set; }
    }
}
