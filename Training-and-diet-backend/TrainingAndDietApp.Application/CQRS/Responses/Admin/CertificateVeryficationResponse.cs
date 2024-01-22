namespace TrainingAndDietApp.Application.CQRS.Responses.Admin{
public class CertificateVerificationResponse
{
    public DateTime AddedDate { get; set; }
    public string Description { get; set; }
    public bool IsAccepted { get; set; }
    public string PdfUri { get; set; }
}
}
