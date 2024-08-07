namespace vodorod.test.task.api.Contracts
{
    //DTO
    public class RatesResponse(Guid Id, decimal Cur_OfficialRate, string Cur_Abbreviation, int Cur_Scale, DateTime date)
    {
        public Guid Id { get; set; } = Id;
        public decimal Cur_OfficialRate { get; set; } = Cur_OfficialRate;
        public string Cur_Abbreviation { get; set; } = Cur_Abbreviation;
        public int Cur_Scale { get; set; } = Cur_Scale;
        public DateTime date { get; set; } = date;
    }
}
