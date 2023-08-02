using ComplaintSystem.Dtos;
using ComplaintSystem.Services.Interfaces;
using QRCoder;
using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;

namespace ComplaintSystem.Services.QRGeneration
{
    public class QrCodeService : IQrCodeService
    {
        public (byte[] qrCodeBytes, string filename) GenerateQRCode(string qrCodeText, int pixelSize)
        {
            string uniqueFilename = $"qr_code_{Guid.NewGuid().ToString("N")}.png";
            QRCodeGenerator qrGenerator = new QRCodeGenerator();
            QRCodeData qrCodeData = qrGenerator.CreateQrCode(qrCodeText, QRCodeGenerator.ECCLevel.Q);
            QRCode qrCode = new QRCode(qrCodeData);
            Bitmap qrBitmap = qrCode.GetGraphic(pixelSize);

            using (MemoryStream ms = new MemoryStream())
            {
                qrBitmap.Save(ms, ImageFormat.Png);
                return (ms.ToArray(), uniqueFilename);
            }
        }
    }
}
