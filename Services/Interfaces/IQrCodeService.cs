namespace ComplaintSystem.Services.Interfaces
{
    public interface IQrCodeService
    {
        (byte[] qrCodeBytes, string filename) GenerateQRCode(string qrCodeText, int pixelSize);
    }
}
