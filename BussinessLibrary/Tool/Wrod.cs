using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Aspose.Pdf;

namespace BussinessLibrary
{
    public class Wrod
    {
        public string SaveWrod(string pdf,string word)
        {
            try
            {
                var pdfDocument = new Document(pdf);
                pdfDocument.Save(word, SaveFormat.Doc);
                return "转换成功";
            }
            catch (Exception ex)
            {
                Log.Log.WriterLog(ex.Message);
                return "转换失败";
            }
        }
    }
}
