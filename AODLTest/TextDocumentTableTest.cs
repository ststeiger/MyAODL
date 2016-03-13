/*
 * $Id: TextDocumentTableTest.cs,v 1.2 2006/02/08 16:37:36 larsbm Exp $
 */

/*
 * License: 
 * GNU Lesser General Public License. You should recieve a
 * copy of this within the library. If not you will find
 * a whole copy at http://www.gnu.org/licenses/lgpl.html .
 * 
 * Author:
 * Copyright 2006, Lars Behrmann, lb@OpenDocument4all.com
 * 
 * Last changes:
 * 
 */

using System;
using System.Xml;
using AODL.Document.Content.Tables;
using AODL.Document.TextDocuments;
using AODL.Document.Styles;
using AODL.Document.Content.Text;
using AODL.Document.Helper;


// using NUnit.Framework;


namespace AODLTest
{
    [NUnit.Framework.TestFixture]
    public class TextDocumentTableTest
    {
        [NUnit.Framework.Test]
        public void SimpleTable()
        {
            //Create a new text document
            TextDocument document = new TextDocument();
            document.New();
            //Create a table for a text document using the TableBuilder
            Table table = TableBuilder.CreateTextDocumentTable(
                                                        document,
                                                        "table1",
                                                        "table1",
                                                        3,
                                                        3,
                                                        16.99,
                                                        false,
                                                        false);
            //Create a standard paragraph
            Paragraph paragraph = ParagraphBuilder.CreateStandardTextParagraph(document);
            //Add some simple text
            paragraph.TextContent.Add(new SimpleText(document, "Some cell text"));
            //Insert paragraph into the first cell
            table.RowCollection[0].CellCollection[0].Content.Add(paragraph);
            //Add table to the document
            document.Content.Add(table);
            //Save the document
            document.SaveTo(AARunMeFirstAndOnce.outPutFolder + "simpleTable.odt");
        }

        [NUnit.Framework.Test]
        public void SimpleTableWithRowHeaderAndBorder()
        {
            //Create a new text document
            TextDocument document = new TextDocument();
            document.New();
            //Create a table for a text document using the TableBuilder
            Table table = TableBuilder.CreateTextDocumentTable(
                                                        document,
                                                        "table1",
                                                        "table1",
                                                        3,
                                                        3,
                                                        16.99,
                                                        true,
                                                        true);
            //Create a standard paragraph for the row header
            Paragraph paragraph1 = ParagraphBuilder.CreateStandardTextParagraph(document);
            paragraph1.TextContent.Add(new SimpleText(document, "Table row header"));
            table.RowHeader.RowCollection[0].CellCollection[0].Content.Add(paragraph1);
            //Create a standard paragraph
            Paragraph paragraph = ParagraphBuilder.CreateStandardTextParagraph(document);
            //Add some simple text
            paragraph.TextContent.Add(new SimpleText(document, "Some cell text"));
            //Insert paragraph into the first cell
            table.RowCollection[0].CellCollection[0].Content.Add(paragraph);
            //Add table to the document
            document.Content.Add(table);
            //Save the document
            document.SaveTo(AARunMeFirstAndOnce.outPutFolder + "simpleTableWithBorderRowheader.odt");
        }

        [NUnit.Framework.Test]
        public void SimpleTableWithList()
        {
            //Create a new text document
            TextDocument document = new TextDocument();
            document.New();
            //Create a table for a text document using the TableBuilder
            Table table = TableBuilder.CreateTextDocumentTable(
                document,
                "table1",
                "table1",
                3,
                3,
                16.99,
                false,
                false);
            //Create a bullet list
            List list = new List(document, "L1", ListStyles.Bullet, "L1P1");
            //Create a list item
            ListItem lit = new ListItem(list);
            //Create a standard paragraph
            Paragraph paragraph = ParagraphBuilder.CreateStandardTextParagraph(document);
            //Add some simple text
            paragraph.TextContent.Add(new SimpleText(document, "List item text"));
            //Add paragraph to the list item
            lit.Content.Add(paragraph);
            //Add item to the list
            list.Content.Add(lit);
            //Insert paragraph into the first cell
            table.RowCollection[0].CellCollection[0].Content.Add(list);
            //Add table to the document
            document.Content.Add(table);
            //Save the document
            document.SaveTo(AARunMeFirstAndOnce.outPutFolder + "simpleTableWithList.odt");
        }

        [NUnit.Framework.Test]
        public void SimpleTableWithMergedCells()
        {
            //Create a new text document
            TextDocument document = new TextDocument();
            document.New();
            //Create a table for a text document using the TableBuilder
            Table table = TableBuilder.CreateTextDocumentTable(
                document,
                "table1",
                "table1",
                3,
                3,
                16.99,
                false,
                false);

            //Fill first all tables
            foreach (Row row in table.RowCollection)
                foreach (Cell cell in row.CellCollection)
                {
                    //Create a standard paragraph
                    Paragraph paragraph = ParagraphBuilder.CreateStandardTextParagraph(document);
                    //Add some simple text
                    paragraph.TextContent.Add(new SimpleText(document, "Cell text"));
                    cell.Content.Add(paragraph);
                }
            //Merge some cells. Notice this is only available in text documents!
            table.RowCollection[1].MergeCells(document, 1, 2, true);
            //Add table to the document
            document.Content.Add(table);
            //Save the document
            document.SaveTo(AARunMeFirstAndOnce.outPutFolder + "simpleTableWithMergedCells.odt");
        }

        [NUnit.Framework.Test]
        public void NestedTable()
        {
            //Create a new text document
            TextDocument document = new TextDocument();
            document.New();
            //Create a table for a text document using the TableBuilder
            Table table = TableBuilder.CreateTextDocumentTable(
                document,
                "table1",
                "table1",
                3,
                3,
                16.99,
                false,
                false);
            //Create a standard paragraph
            Paragraph paragraph = ParagraphBuilder.CreateStandardTextParagraph(document);
            //Add some simple text
            paragraph.TextContent.Add(new SimpleText(document, "Some cell text"));
            NUnit.Framework.Assert.IsNotNull(table.RowCollection, "Must exist.");
            NUnit.Framework.Assert.IsTrue(table.RowCollection.Count == 3, "There must be 3 rows.");
            //Insert paragraph into the second cell
            table.RowCollection[0].CellCollection[1].Content.Add(paragraph);
            //Get width of the nested table
            double nestedTableWidth = SizeConverter.GetDoubleFromAnOfficeSizeValue(
                table.ColumnCollection[0].ColumnStyle.ColumnProperties.Width);
            //Create another table using the TableBuilder
            Table nestedTable = TableBuilder.CreateTextDocumentTable(
                document,
                "table1",
                "table1",
                2,
                2,
                nestedTableWidth,
                false,
                false);
            //Create a new standard paragraph
            paragraph = ParagraphBuilder.CreateStandardTextParagraph(document);
            //Add some simple text
            paragraph.TextContent.Add(new SimpleText(document, "Some cell text inside the nested table"));
            NUnit.Framework.Assert.IsNotNull(nestedTable.RowCollection, "Must exist.");
            NUnit.Framework.Assert.IsTrue(nestedTable.RowCollection.Count == 2, "There must be 3 rows.");
            //Insert paragraph into the first cell
            nestedTable.RowCollection[0].CellCollection[0].Content.Add(paragraph);
            //Insert the nested table into the first row and first cell
            table.RowCollection[0].CellCollection[0].Content.Add(nestedTable);
            NUnit.Framework.Assert.IsTrue(table.RowCollection[0].CellCollection[0].Content[0] is Table, "Must be the nested table.");
            //Add table to the document
            document.Content.Add(table);
            //Save the document
            document.SaveTo(AARunMeFirstAndOnce.outPutFolder + "nestedTable.odt");
        }
    }
}
