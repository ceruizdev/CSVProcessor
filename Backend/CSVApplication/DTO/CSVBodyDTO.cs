namespace CSVApplication.WebAPI.DTO
{
    public class CSVBodyDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string? FileAsBase64 { get; set; }
        public string Delimiter { get; set; }
        public DateTime? CreationDate { get; set; }
        public DateTime? LastUpdate { get; set; }
        public List<string>? InformationDecoded { get; set; }
    }
}
