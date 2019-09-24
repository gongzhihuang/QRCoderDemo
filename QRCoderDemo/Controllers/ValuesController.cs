using System;
using System.Collections.Generic;
using System.DrawingCore;
using System.DrawingCore.Imaging;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using QRCoder;

namespace QRCoderDemo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        /// <summary>
        /// 获取二维码
        /// </summary>
        /// <returns></returns>
        [HttpGet("QRCode")]
        public ActionResult QRCode()
        {
            QRCodeGenerator qrGenerator = new QRCodeGenerator();

            string playload = "888";

            QRCodeData qrCodeData = qrGenerator.CreateQrCode(playload, QRCodeGenerator.ECCLevel.H);
            QRCode qrCode = new QRCode(qrCodeData);

            Bitmap qrCodeImage = qrCode.GetGraphic(10, Color.Black, Color.White, null, 15, 6, true);

            var bitmapBytes = BitmapToBytes(qrCodeImage);
            


            return File(bitmapBytes, "image/jpeg");
        }

        private static byte[] BitmapToBytes(Bitmap img)
        {
            using (MemoryStream stream = new MemoryStream())
            {
                img.Save(stream, ImageFormat.Jpeg);
                return stream.GetBuffer();
            }
        }

        // GET api/values
        [HttpGet]
        public ActionResult<IEnumerable<string>> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public ActionResult<string> Get(int id)
        {
            return "value";
        }

        // POST api/values
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
