using Leaf.Core.Domain.Spreads;
using NPOI.HSSF.UserModel;
using NPOI.SS.UserModel;
using System;
using System.Collections.Generic;
using System.Text;

namespace Leaf.Services.Helpers
{
    public interface IXlsHelper
    {
        void ReadXls(string filename);

        IList<Qichacha> LoadFromXls(string filename);
    }


    public class XlsHelper : IXlsHelper
    {
        public void ReadXls(string filename)
        {
            var hswb = new HSSFWorkbook(new System.IO.FileStream(filename, System.IO.FileMode.Open, System.IO.FileAccess.ReadWrite));

            HSSFSheet sheet = (HSSFSheet)hswb.GetSheetAt(0);

            //HSSFRow hssfRow = null;

            //hssfRow = (HSSFRow)sheet.GetRow(0);

            //int num = sheet.LastRowNum;

            //hssfRow = sheet.GetRow(i);
            //if (hssfRow == null) break;
            //cangKuName = XlsCellHeler.getCellValue(hssfRow.GetCell(0));
            //Imei = XlsCellHeler.getCellValue(hssfRow.GetCell(1));


            IRow hssfRow = null;

            hssfRow = sheet.GetRow(0);

            int num = sheet.LastRowNum;
            int cnum = hssfRow.LastCellNum;


            // if (hssfRow == null) break;
            string name = XlsCellHeler.getCellValue2(hssfRow.GetCell(0));

            // Imei = XlsCellHeler.getCellValue(hssfRow.GetCell(1));


            Console.WriteLine(num);

        }


        public IList<Qichacha> LoadFromXls(string filename)
        {

            List<Qichacha> qilist = new List<Qichacha>();

            var hswb = new HSSFWorkbook(new System.IO.FileStream(filename, System.IO.FileMode.Open, System.IO.FileAccess.ReadWrite));

            HSSFSheet sheet = (HSSFSheet)hswb.GetSheetAt(0);

            //HSSFRow hssfRow = null;

            //hssfRow = (HSSFRow)sheet.GetRow(0);

            //int num = sheet.LastRowNum;

            //hssfRow = sheet.GetRow(i);
            //if (hssfRow == null) break;
            //cangKuName = XlsCellHeler.getCellValue(hssfRow.GetCell(0));
            //Imei = XlsCellHeler.getCellValue(hssfRow.GetCell(1));


            IRow hssfRow = null;

            hssfRow = sheet.GetRow(0);

            int num = sheet.LastRowNum;
            int cnum = hssfRow.LastCellNum;


            // if (hssfRow == null) break;
            //string name = XlsCellHeler.getCellValue(hssfRow.GetCell(0));
            int i = 1;
            for (i = 1; i <= num; i++)
            {
                hssfRow = sheet.GetRow(i);
                if (hssfRow == null)
                {
                    break;
                }


                string name = XlsCellHeler.getCellValue2(hssfRow.GetCell(0));
                string linkMan = XlsCellHeler.getCellValue2(hssfRow.GetCell(1));
                string fundDate = XlsCellHeler.getCellValue2(hssfRow.GetCell(2));
                string regCapitalStr = XlsCellHeler.getCellValue2(hssfRow.GetCell(3));
                string actWorkAddr = XlsCellHeler.getCellValue2(hssfRow.GetCell(4));
                string email = XlsCellHeler.getCellValue2(hssfRow.GetCell(5));
                string linkPhone = XlsCellHeler.getCellValue2(hssfRow.GetCell(6));
                string actScope = XlsCellHeler.getCellValue2(hssfRow.GetCell(7));
                string webSiteUrl = XlsCellHeler.getCellValue2(hssfRow.GetCell(8));

                qilist.Add(new Qichacha()
                {
                    Name = name,
                    LinkMan = linkMan,
                    FundDate = fundDate,
                    RegCapitalStr = regCapitalStr,
                    ActWorkAddr = actWorkAddr,
                    Email = email,
                    LinkPhone = linkPhone,
                    ActScope = actScope,
                    WebSiteUrl = webSiteUrl
                });
            }



            return qilist;

        }
    }


    public class XlsCellHeler
    {
        //20110819扩展,公式单元格数据可能是文本内容

        public static string getCellValue2(ICell cell)
        {
            if (cell == null) return "";

            switch ((int)cell.CellType)
            {
                case CellType.CELL_TYPE_NUMERIC:
                    return cell.NumericCellValue.ToString();
                case CellType.CELL_TYPE_BOOLEAN:
                    return cell.BooleanCellValue.ToString();
                case CellType.CELL_TYPE_BLANK:
                    return "";
                case CellType.CELL_TYPE_ERROR:
                    return cell.ErrorCellValue.ToString();
                case CellType.CELL_TYPE_STRING:
                    return cell.StringCellValue.Trim();
                case CellType.CELL_TYPE_FORMULA:
                    string str = string.Empty;
                    try
                    {
                        str = Math.Round(cell.NumericCellValue, 2).ToString();
                    }
                    catch
                    {
                        str = cell.StringCellValue;
                    }
                    return str;
                default:
                    return "";
            }


        }

        public static string getCellValue(HSSFCell cell)
        {
            if (cell == null) return "";

            switch ((int)cell.CellType)
            {
                case CellType.CELL_TYPE_NUMERIC:
                    return cell.NumericCellValue.ToString();
                case CellType.CELL_TYPE_BOOLEAN:
                    return cell.BooleanCellValue.ToString();
                case CellType.CELL_TYPE_BLANK:
                    return "";
                case CellType.CELL_TYPE_ERROR:
                    return cell.ErrorCellValue.ToString();
                case CellType.CELL_TYPE_STRING:
                    return cell.StringCellValue.Trim();
                case CellType.CELL_TYPE_FORMULA:
                    string str = string.Empty;
                    try
                    {
                        str = Math.Round(cell.NumericCellValue, 2).ToString();
                    }
                    catch
                    {
                        str = cell.StringCellValue;
                    }
                    return str;
                default:
                    return "";
            }


        }

        public static void addCell(HSSFRow row, int index, string val, HSSFCellStyle style)
        {
            addCell(row, index, new ExcelCell { ValType = CellType.CELL_TYPE_STRING, Val = val }, style);
        }

        public static void addCell2(IRow row, int index, string val, ICellStyle style)
        {
            addCell2(row, index, new ExcelCell { ValType = CellType.CELL_TYPE_STRING, Val = val }, style);
        }

        /// <summary>
        /// 添加Excel单元格
        /// </summary>
        /// <param name="row">行对象</param>
        /// <param name="index">单元格索引号</param>
        /// <param name="val">ExcelCell对象</param>
        /// <param name="style">样式</param>
        public static void addCell(HSSFRow row, int index, ExcelCell val, HSSFCellStyle style)
        {

            HSSFCell cell = (HSSFCell)row.CreateCell(index);
            if (!string.IsNullOrEmpty(val.Val))
                switch (val.ValType)
                {
                    case CellType.CELL_TYPE_NUMERIC:
                        cell.SetCellValue(double.Parse(val.Val));
                        break;
                    case CellType.CELL_TYPE_BOOLEAN:
                        cell.SetCellValue(bool.Parse(val.Val));
                        break;
                    case CellType.CELL_TYPE_BLANK:
                        cell.SetCellValue(val.Val);
                        break;
                    case CellType.CELL_TYPE_ERROR:
                        cell.SetCellValue(val.Val);
                        break;
                    case CellType.CELL_TYPE_STRING:
                        cell.SetCellValue(val.Val);
                        break;
                    case CellType.CELL_TYPE_DATE:
                        cell.SetCellValue(DateTime.Parse(val.Val).ToString("yyyy-MM-dd"));
                        break;
                    case CellType.CELL_TYPE_FORMULA:
                        cell.SetCellFormula(val.Val);
                        break;


                }

        }


        public static void addCell2(IRow row, int index, ExcelCell val, ICellStyle style)
        {

            ICell cell = row.CreateCell(index);
            if (!string.IsNullOrEmpty(val.Val))
                switch (val.ValType)
                {
                    case CellType.CELL_TYPE_NUMERIC:
                        cell.SetCellValue(double.Parse(val.Val));
                        break;
                    case CellType.CELL_TYPE_BOOLEAN:
                        cell.SetCellValue(bool.Parse(val.Val));
                        break;
                    case CellType.CELL_TYPE_BLANK:
                        cell.SetCellValue(val.Val);
                        break;
                    case CellType.CELL_TYPE_ERROR:
                        cell.SetCellValue(val.Val);
                        break;
                    case CellType.CELL_TYPE_STRING:
                        cell.SetCellValue(val.Val);
                        break;
                    case CellType.CELL_TYPE_DATE:
                        cell.SetCellValue(DateTime.Parse(val.Val).ToString("yyyy-MM-dd"));
                        break;
                    case CellType.CELL_TYPE_FORMULA:
                        cell.SetCellFormula(val.Val);
                        break;


                }

        }


        /// <summary>
        /// 批量添加Excel单元格
        /// </summary>
        /// <param name="row">行对象</param>
        /// <param name="vals">值数组</param>
        /// <param name="style">样式</param>
        public static void addBatchCell(HSSFRow row, List<ExcelCell> vals, HSSFCellStyle style)
        {
            addBatchCell(row, 0, vals, style);
        }

        /// <summary>
        /// 批量添加Excel单元格
        /// </summary>
        /// <param name="row">行对象</param>
        /// <param name="startIndex">起始单元格索引号</param>
        /// <param name="vals">值数组</param>
        /// <param name="style">样式</param>
        public static void addBatchCell(HSSFRow row, int startIndex, List<ExcelCell> vals, HSSFCellStyle style)
        {
            for (int i = 0; i < vals.Count; i++)
            {
                addCell(row, i + startIndex, vals[i], style);
            }

        }

        public static void addBatchCell2(IRow row, int startIndex, List<ExcelCell> vals,ICellStyle style)
        {
            for (int i = 0; i < vals.Count; i++)
            {
                addCell2(row, i + startIndex, vals[i], style);
            }

        }

    }
    public class ExcelCell
    {
        /// <summary>
        /// 值
        /// </summary>
        public string Val { get; set; }
        /// <summary>
        /// 类型
        /// </summary>
        public int ValType { get; set; }
    }
    public class CellType
    {
        public const int CELL_TYPE_NUMERIC = 0;
        public const int CELL_TYPE_STRING = 1;
        public const int CELL_TYPE_FORMULA = 2;
        public const int CELL_TYPE_BLANK = 3;
        public const int CELL_TYPE_BOOLEAN = 4;
        public const int CELL_TYPE_ERROR = 5;
        public const int CELL_TYPE_DATE = 6;
    }
}
