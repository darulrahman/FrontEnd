namespace krediku_fe.Models.Backend
{
    public class Transaction
    {
        public string AgreementNumber { get; set; }
        public string BpkbNumber { get; set; }
        public string BranchId { get; set; }
        public DateTime BpkbDate { get; set; }
        public string FakturNumber { get; set; }
        public DateTime FakturDate { get; set; }
        public string LocationId { get; set; }
        public string LocationName { get; set; }
        public string PoliceNumber { get; set; }
        public DateTime BpkbDateInput { get; set; }
    }
}
