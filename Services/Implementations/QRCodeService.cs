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
        public byte[] GenerateQRCode(string qrCodeText, int pixelSize)
        {
            //QRCodeGenerator qrGenerator = new QRCodeGenerator();
            //QRCodeData qrCodeData = qrGenerator.CreateQrCode(qrCodeText, QRCodeGenerator.ECCLevel.Q);
            //QRCode qrCode = new QRCode(qrCodeData);
            //Bitmap qrBitmap = qrCode.GetGraphic(pixelSize);
            //byte[] bitmapBytes;

            //using (MemoryStream ms = new MemoryStream())
            //{
            //    qrBitmap.Save(ms, ImageFormat.Png);
            //    bitmapBytes = ms.ToArray();
            //}

            //string qrUri = $"data:image/png;base64,{Convert.ToBase64String(bitmapBytes)}";
            //return qrUri;
            QRCodeGenerator qrGenerator = new QRCodeGenerator();
            QRCodeData qrCodeData = qrGenerator.CreateQrCode(qrCodeText, QRCodeGenerator.ECCLevel.Q);
            QRCode qrCode = new QRCode(qrCodeData);
            Bitmap qrBitmap = qrCode.GetGraphic(pixelSize);

            using (MemoryStream ms = new MemoryStream())
            {
                qrBitmap.Save(ms, ImageFormat.Png);
                return ms.ToArray();
            }
        }
    }
}
