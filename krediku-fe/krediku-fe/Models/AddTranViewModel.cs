using System.ComponentModel.DataAnnotations;

namespace krediku_fe.Models
{
    public class AddTranViewModel
    {
        [Required]
        [Display(Name = "Agreement Number", Prompt = "Input Agreement Number")]
        public string NoAgreement { get; set; }
        [Display(Name = "No. BPKB", Prompt = "Input No. BPKB")]
        public string NoBPKB { get; set; }
        [Display(Name = "Branch Id", Prompt = "Input Branch Id")]
        public string BranchId { get; set; }
        [Display(Name = "Tanggal BPKB", Prompt = "mm/dd/yyyy")]
        public DateTime DateBPKB { get; set; }
        [Display(Name = "No. Faktur", Prompt = "Input No. Faktur")]
        public string NoFaktur { get; set; }
        [Display(Name = "Tanggal Faktur", Prompt = "mm/dd/yyyy")]
        public DateTime DateFaktur { get; set; }
        [Display(Name = "Lokasi Penyimpanan", Prompt = "Select Lokasi Penyimpanan")]
        public string LocationId { get; set; }
        [Display(Name = "Nomor Polisi", Prompt = "Input Nomor Polisi")]
        public string NoPolis { get; set; }
        [Display(Name = "Tanggal BPKB In", Prompt = "mm/dd/yyyy")]
        public DateTime DateInput { get; set; }
    }
}
