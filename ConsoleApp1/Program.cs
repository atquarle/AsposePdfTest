using Aspose.Pdf;
using Aspose.Pdf.Annotations;
using System;
using System.IO;
using System.Reflection;

namespace ConsoleApp1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var pdfLicense = new License();

            var assembly = Assembly.GetExecutingAssembly();
            var licenseFileName = $"{assembly.GetName().Name}.License.Aspose.Total.NET.lic";

            using var stream = assembly.GetManifestResourceStream(licenseFileName);
            pdfLicense.SetLicense(stream);

            var outputDirectory = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "ReportBuilderTests");
            Directory.CreateDirectory(outputDirectory);

            var path = Path.Combine(outputDirectory, "DrawingSet.pdf");

            using (var outputStream = File.OpenWrite(path))
            {
                Document doc = new Document();

                var titlePage = doc.Pages.Add();
                titlePage.PageInfo.Margin = new MarginInfo(0, 0, 0, 0);
                titlePage.SetPageSize(17 * 72, 11 * 72);

                // Create Graph instance
                var graph = new Aspose.Pdf.Drawing.Graph((float)titlePage.PageInfo.Width, (float)titlePage.PageInfo.Height);

                // Add graph object to paragraphs collection of page instance
                titlePage.Paragraphs.Add(graph);

                // Create Rectangle instance
                var rect = new Aspose.Pdf.Drawing.Rectangle(10, 10, 100, 100);

                // Specify fill color for Graph object
                rect.GraphInfo.FillColor = Color.Blue;

                // Add rectangle object to shapes collection of Graph object
                graph.Shapes.Add(rect);

                doc.Save(outputStream);
            }
        }
    }
}
