using System;
using System.Collections.Generic;
using System.Data;
using System.Globalization;
using System.Linq;
using System.Web;
using Microsoft.VisualBasic.FileIO;

namespace SoftDevCase
{
    public class FileReader
    {
        public static string ValidateUploadedFileData(string uploadPath)
        {
            string resp = "OK";
            int lineNumb = 1;

            DataTable csvData = new DataTable();
            try
            {
                using (TextFieldParser csvReader = new TextFieldParser(uploadPath))
                {
                    csvReader.SetDelimiters(new string[] { "," });
                    csvReader.HasFieldsEnclosedInQuotes = true;
                    while (!csvReader.EndOfData)
                    {
                        if (resp.Trim().Equals("OK"))
                        {
                            string[] fieldData = csvReader.ReadFields();
                            if (fieldData.Length == 14)
                            {
                                for (int i = 0; i < fieldData.Length; i++)
                                {
                                    if ((i == 0 || i == 7) && lineNumb == 1)
                                    {
                                        DateTime temp;
                                        if (DateTime.TryParseExact(fieldData[i], "M/d/yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out temp))
                                        {
                                            resp = "VALIDATION FAIL. UPLOADED FILE SHOULD HAVE COLUMN HEADERS ON LINE " + lineNumb;
                                            break;
                                        }
                                    }
                                    else if ((i == 6 || i == 8 || i == 9 || i == 10 || i == 11 || i == 12 || i == 13) && lineNumb == 1)
                                    {
                                        Double temp;

                                        if (Double.TryParse(fieldData[i], out temp))
                                        {
                                            resp = "VALIDATION FAIL. UPLOADED FILE SHOULD HAVE COLUMN HEADERS ON LINE "+ lineNumb;
                                            break;
                                        }
                                    }
                                    else if ((i == 5 || i == 7) && lineNumb!=1)
                                    {
                                        DateTime temp;
                                        if (!DateTime.TryParseExact(fieldData[i], "M/d/yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out temp))
                                        {
                                            resp = "ERROR. UPLOADED FILE HAS INVALID DATE (" + fieldData[i] + ") ON LINE " + lineNumb + " FIELD " + (i + 1);
                                            break;
                                        }
                                    }
                                    else if ((i == 6 || i == 8 || i == 9 || i == 10 || i == 11 || i == 12 || i == 13) && lineNumb != 1)
                                    {
                                        Double temp;

                                        if (!Double.TryParse(fieldData[i], out temp))
                                        {
                                            resp = "VALIDATION FAIL. UPLOADED FILE HAS INVALID NUMERIC ENTRY (" + fieldData[i] + ")  ON LINE " + lineNumb + " FIELD " + (i + 1);
                                            break;
                                        }
                                    }
                                }
                            }
                            else
                            {
                                resp = "VALIDATION FAIL. UPLOADED FILE HAS " + fieldData.Length + " FIELDS ON LINE " + lineNumb + ". EXPECTING 14 FIELDS";
                                break;
                            }
                            lineNumb++;
                        }
                        else
                        {
                            break;
                        }


                    }
                }
            }
            catch (Exception ex)
            {
                resp=ex.Message;
            }
            return resp;
        }
        public static DataTable GetDataFromUploadedFile(string uploadPath,string uploadedBy)
        {
            DataTable records = new DataTable();
            try
            {
                using (TextFieldParser csvReader = new TextFieldParser(uploadPath))
                {
                    csvReader.SetDelimiters(new string[] { "," });
                    csvReader.HasFieldsEnclosedInQuotes = true;
                    string[] colFields = csvReader.ReadFields();
                    foreach (string column in colFields)
                    {
                        string colName = column.Replace(' ', '_');
                        DataColumn datecolumn = new DataColumn(colName);
                        datecolumn.AllowDBNull = true;
                        records.Columns.Add(datecolumn);
                    }
                    //Add the uploaded_by Info Header
                    DataColumn uploadDetailCoumn = new DataColumn("uploaded_by");
                    uploadDetailCoumn.AllowDBNull = true;
                    records.Columns.Add(uploadDetailCoumn);

                    while (!csvReader.EndOfData)
                    {
                        string[] fieldDataInfo = csvReader.ReadFields();
                        List<string> fieldlist = fieldDataInfo.ToList();
                        fieldlist.Add(uploadedBy);
                        string[] fieldData = fieldlist.ToArray();
                        //Making empty value as null
                        for (int i = 0; i < fieldData.Length; i++)
                        {
                            if (fieldData[i] == "")
                            {
                                fieldData[i] = null;
                            }
                        }
                        records.Rows.Add(fieldData);
                    }
                }
            }
            catch (Exception ex)
            {
                return null;
            }
            return records;
        }
    }
}
