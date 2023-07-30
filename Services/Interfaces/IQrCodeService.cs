namespace ComplaintSystem.Services.Interfaces
{
    public interface IQrCodeService
    {
        byte[] GenerateQRCode(string qrCodeText, int pixelSize);
    }
}
