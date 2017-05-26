using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Text.RegularExpressions;
using Novacode;


namespace WordDocGenerator
{
    internal class MainClass
    {
        internal static void Main()
        {

            string fileName = @"..\..\Softuni-RPG-Game-Contest.docx";

            //we are creating a dox
            var doc = DocX.Create(fileName);

            //reading a text
            string[] textLines = File.ReadAllLines(@"..\..\text.txt");

            var headLineFormat = new Formatting();

            headLineFormat.Size = 23D;
            headLineFormat.Bold = true;
       

            //insert a title

            Paragraph title = doc.InsertParagraph(textLines[0], false, headLineFormat);

            Paragraph picParagraph = doc.InsertParagraph();


            using (MemoryStream ms = new MemoryStream())
            {
                System.Drawing.Image myImg = System.Drawing.Image.FromFile(@"..\..\rpg-game.png");

                // Calculate Horizontal and Vertical scale
                float Hscale = (float)22 / myImg.HorizontalResolution;
                float Vscale = (float)22 / myImg.VerticalResolution;

                myImg.Save(ms, myImg.RawFormat);  // Save your picture in a memory stream.
                ms.Seek(0, SeekOrigin.Begin);

                Novacode.Image img = doc.AddImage(ms); // Create image.
                Picture pic1 = img.CreatePicture();     // Create picture.

                // Apply scale to height & width
                pic1.Height = (int)(myImg.Height * Hscale);
                pic1.Width = (int)(myImg.Width * Vscale);

                picParagraph.InsertPicture(pic1, 0); // Insert picture into paragraph.
            }

            // A formatting object for our normal paragraph text:
            var paraFormat = new Formatting();
            paraFormat.FontFamily = new System.Drawing.FontFamily("Calibri");
            paraFormat.Size = 10D;

            // Insert text between picture and table
            for (int i = 1; i < 4; i++)
            {
                doc.InsertParagraph(textLines[i], false, paraFormat);
            }

            // Insert bulleted lines
            var bulletedList = doc.AddList(textLines[4], 0, ListItemType.Bulleted);
            doc.AddListItem(bulletedList, textLines[5]);
            doc.AddListItem(bulletedList, textLines[6]);
            doc.InsertList(bulletedList);

            doc.InsertParagraph();

            // Add a Table into the document.
            Table table = doc.AddTable(4, 3);
            table.Design = TableDesign.MediumGrid1Accent1;
            table.Alignment = Alignment.center;

            string[] tableRow1 = Regex.Split(textLines[8], @"\s+");
            string[] tableRow2 = Regex.Split(textLines[9], @"\s+");
            string[] tableRow3 = Regex.Split(textLines[10], @"\s+");
            string[] tableRow4 = Regex.Split(textLines[11], @"\s+");

            table.Rows[0].Cells[0].Paragraphs[0].Append(tableRow1[0]);
            table.Rows[0].Cells[1].Paragraphs[0].Append(tableRow1[1]);
            table.Rows[0].Cells[2].Paragraphs[0].Append(tableRow1[2]);
            table.Rows[1].Cells[0].Paragraphs[0].Append(tableRow2[0]);
            table.Rows[1].Cells[1].Paragraphs[0].Append(tableRow2[1]);
            table.Rows[1].Cells[2].Paragraphs[0].Append(tableRow2[2]);
            table.Rows[2].Cells[0].Paragraphs[0].Append(tableRow3[0]);
            table.Rows[2].Cells[1].Paragraphs[0].Append(tableRow3[1]);
            table.Rows[2].Cells[2].Paragraphs[0].Append(tableRow3[2]);
            table.Rows[3].Cells[0].Paragraphs[0].Append(tableRow4[0]);
            table.Rows[3].Cells[1].Paragraphs[0].Append(tableRow4[1]);
            table.Rows[3].Cells[2].Paragraphs[0].Append(tableRow4[2]);

            doc.InsertTable(table);

            doc.InsertParagraph();
            Paragraph prizeDesc = doc.InsertParagraph(textLines[13]);
            prizeDesc.Alignment = Alignment.center;

            Paragraph prize = doc.InsertParagraph(textLines[14]).Bold().FontSize(24D).Color(Color.DarkBlue).UnderlineStyle(UnderlineStyle.singleLine);
            prize.Alignment = Alignment.center;

            // Save to the output directory:
            doc.Save();

            // Open in Word:
            Process.Start("WINWORD.exe", fileName);


        }
    }


}
