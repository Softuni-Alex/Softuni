namespace WebCralwer.Tests
{
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using System.Linq;

    [TestClass]
    public class CrawlerTests
    {
        [TestMethod]
        public void ExtractImageUrls_Should_Return_Collection_Of_Image_Src_Content()
        {
            // Arrange
            //MOQ EXAMPLE
            // var mock = new Mock<IHtmlDownloader>();
            // mock.Setup(h => h.DownloadHtml(It.IsAny<string>())).Returns("......");

            //mock.Setup(h => h.DownloadedHtml(It.Is((string url) => url ==null))).Throws(new ArgumentNullException());
            //
            // var crawler = new Crawler(mock.Object);

            var expectedImageUrls = new[]
            {
                // What to expect?
                "nakov.png",
                "courses/inner/background.jpeg"
            };

            // Act
            var imageUrls = crawler.ExtractImageUrls(string.Empty)
                .ToList();


            // Assert
            CollectionAssert.AreEqual(expectedImageUrls, imageUrls);
        }
    }
}
