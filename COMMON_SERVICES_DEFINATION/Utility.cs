using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Data;
using NPOI.SS.UserModel;
using NPOI.XSSF.UserModel;
using ClosedXML.Excel;
using CustomModel;

namespace COMMON_SERVICES_DEFINATION
{
    public class Utility
    {
        IWebHostEnvironment webHostEnvironment;
        public string FileUpload(string FolderName, IFormFile file, IWebHostEnvironment webHostEnvironment)
        {
            string FilePath = "";
            string filename = "";

            if (file.Length > 0)
            {
                Guid _guid = Guid.NewGuid();
                string extension = Path.GetExtension(file.FileName).ToLower();

                if (!Directory.Exists(webHostEnvironment.ContentRootPath + "\\" + FolderName + "\\"))
                {
                    Directory.CreateDirectory(webHostEnvironment.ContentRootPath + "" + FolderName + "");
                }
                    filename = _guid + extension;
                    FilePath = webHostEnvironment.ContentRootPath + "\\" + FolderName + "\\"+ filename;//+ _guid  + extension;
                    using (FileStream filestream = System.IO.File.Create(FilePath))
                    {
                        file.CopyTo(filestream);
                        filestream.Flush();
                    }
                
            }
            return filename;
        }
        public string GetFilePath(string FolderName, IWebHostEnvironment webHostEnvironment)
        {
            string FilePath = "";
            if (!Directory.Exists(webHostEnvironment.ContentRootPath + "\\" + FolderName + "\\"))
            {
                Directory.CreateDirectory(webHostEnvironment.ContentRootPath + "\\" + FolderName + "\\");
            }
            FilePath = webHostEnvironment.ContentRootPath + "\\" + FolderName + "\\";
            return FilePath;
        }

        public void RemoveDirectoryPath(string filePath)
        {

            if (!Directory.Exists(filePath))
            {
                Directory.Delete(filePath);
            }

        }
        public void RemoveFile(string filename, string FolderName, IWebHostEnvironment webHostEnvironment)
        {
            if (!string.IsNullOrEmpty(filename))
            {
                string FilePath = webHostEnvironment.ContentRootPath + "\\" + FolderName + "\\" + filename;
                if (!string.IsNullOrEmpty(FilePath))
                {
                    if (File.Exists(FilePath))
                    {
                        File.Delete(FilePath);
                    }
                }
            }
        }
        public DataTable ExcelToDatable(string Path)
        {
            DataTable dtTable = new DataTable();
            try
            {

                List<string> rowList = new List<string>();
                ISheet sheet;
                using (var stream = new FileStream(Path, FileMode.Open))
                {
                    stream.Position = 0;
                    XSSFWorkbook xssWorkbook = new XSSFWorkbook(stream);
                    sheet = xssWorkbook.GetSheetAt(0);
                    IRow headerRow = sheet.GetRow(0);
                    int cellCount = headerRow.LastCellNum;
                    for (int j = 0; j < cellCount; j++)
                    {
                        ICell cell = headerRow.GetCell(j);
                        if (cell == null || string.IsNullOrWhiteSpace(cell.ToString())) continue;
                        {
                            dtTable.Columns.Add(cell.ToString());
                        }
                    }
                    for (int i = (sheet.FirstRowNum + 1); i <= sheet.LastRowNum; i++)
                    {
                        IRow row = sheet.GetRow(i);
                        if (row == null) continue;
                        if (row.Cells.All(d => d.CellType == CellType.Blank)) continue;
                        for (int j = row.FirstCellNum; j < cellCount; j++)
                        {
                            if (row.GetCell(j) != null)
                            {
                                if (!string.IsNullOrEmpty(row.GetCell(j).ToString()) && !string.IsNullOrWhiteSpace(row.GetCell(j).ToString()))
                                {
                                    rowList.Add(row.GetCell(j).ToString());
                                }
                            }
                        }
                        if (rowList.Count > 0)
                            dtTable.Rows.Add(rowList.ToArray());
                        rowList.Clear();
                    }
                }
                RemoveDirectoryPath(Path);
            }
            catch (Exception)
            {


            }
            return (dtTable);
        }
        public string ExportExcel(DataTable dt, string Path)
        {
            Guid _guid = new Guid();
            Path = Path + _guid + ".xlsx";
            using (XLWorkbook wb = new XLWorkbook())
            {
                wb.Worksheets.Add(dt);
                wb.SaveAs(Path);
            }
            return Path;
        }

        /// <summary>
        /// This Method is Created to Bind 
        /// List<Additional_CertificatesFiles>
        /// List<Additional_Certificate_ExpiryDate>
        /// List<Additional_Certificate_Title> To 
        /// List<AddtionalFilesDynamic>
        /// </summary>
        public List<FilesDynamic> GetListModel(List<IFormFile> Files, List<string> Title, List<string> ExpiryDate)
        {
            //if(Additional_CertificatesFiles.Count().Equals(Additional_Certificate_Title.Count()).Equals(Additional_Certificate_ExpiryDate.Count()))
            //{
                List<FilesDynamic> list = new List<FilesDynamic>();
                int i = 0;
                foreach (IFormFile Additional_Certificate in Files)
                {
                    FilesDynamic afd = new FilesDynamic();
                    afd.ExpiryDate =Convert.ToDateTime(ExpiryDate[i]);
                    afd.Title = Title[i];
                    afd.Files = Files[i];
                    list.Add(afd);
                i++;
                }
                return list;
            //}
            //else
            //{
            //    throw (new Exception("Invalid Listed Parameters are passed. Number of elements in each list must be same."));
            //}
        }
    }
}
