using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Office.Interop.Excel;
using System.Runtime.InteropServices;
using System.Drawing;
using System.Data;
using System.Reflection;

namespace TableCatalogCreator2
{
    class xsldoc
    {
        private static void ReleaseExcelObject(object obj)
        {
            try
            {
                if(obj != null)
                {
                    Marshal.ReleaseComObject(obj);
                    obj = null;
                }
            }
            catch(Exception ex)
            {
                obj = null;
                throw ex;
            }
            finally
            {
                GC.Collect();
            }
        }

        internal static void WorkThat(List<List<string>> splitList, System.Data.DataSet ds)
        {
            
            //4. 엑셀 파일을 3에서 만든 기준대로 쪼갬
            foreach(var list in splitList)
            {
                WorkOneFile(list, ds);
            }

        }

        private static void WorkOneFile(List<string> list, System.Data.DataSet ds)
        {
            try
            {
                //1. 엑셀을 실행하고
                Application excelApp = null;
                Workbook wb = null;
                Worksheet ws = null;
                try
                {
                    excelApp = new Application();
                    wb = excelApp.Workbooks.Add();

                    //wb.Worksheets.Delete();

                    //2. 각 테이블 목록별로 Sheet 생성


#if !DEBUG
                    foreach(var a in list) wb.Worksheets.Add();
                    //3. 각 sheet별로 내용 집어넣고
                    for(int k = 0; k < list.Count; k++)
                    {
                        //워크시트 내용 삽입
                        ((Worksheet)wb.Worksheets[k + 1]).Name = list[k];

                        #region   워크시트 내용 수셔넣기 시작

                        //테스트용으로 제일 첫 시트만
                        //워크시트 내용 삽입
                        ws = (Worksheet)wb.Worksheets[k + 1];
                        //이름 지정
                        ws.Name = list[k];
                        Console.WriteLine($"테이블 {ws.Name} 엑셀 기록 시작");

                        //테이블명
                        ((Range)ws.Cells[1, 1]).Value = "테이블명";
                        ((Range)ws.Cells[1, 1]).Interior.Color = XlRgbColor.rgbLightYellow;
                        ((Range)ws.Range[ws.Cells[1, 1], ws.Cells[1, 2]]).Merge();
                        ((Style)((Range)ws.Cells[1, 1]).Style).HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenterAcrossSelection;

                        ((Range)ws.Cells[1, 3]).Value = ws.Name;
                        ((Range)ws.Range[ws.Cells[1, 3], ws.Cells[1, 7]]).Merge();

                        //테이블 설명
                        ((Range)ws.Cells[2, 1]).Value = "테이블 설명";
                        ((Range)ws.Cells[2, 1]).Interior.Color = XlRgbColor.rgbLightYellow;
                        ((Range)ws.Range[ws.Cells[2, 1], ws.Cells[2, 2]]).Merge();
                        ((Style)((Range)ws.Cells[2, 1]).Style).HorizontalAlignment = XlHAlign.xlHAlignCenterAcrossSelection;

                        ((Range)ws.Cells[2, 3]).Value = ws.Name;
                        ((Range)ws.Range[ws.Cells[2, 3], ws.Cells[2, 7]]).Merge();


                        //컬럼 헤더
                        ((Range)ws.Cells[3, 1]).Value = "No";
                        ((Range)ws.Cells[3, 2]).Value = "필드명";
                        ((Range)ws.Cells[3, 3]).Value = "자료형";
                        ((Range)ws.Cells[3, 4]).Value = "길이";
                        ((Range)ws.Cells[3, 5]).Value = "NULL여부";
                        ((Range)ws.Cells[3, 6]).Value = "PK여부";
                        ((Range)ws.Cells[3, 7]).Value = "비고";
                        ((Range)ws.Range[ws.Cells[3, 1], ws.Cells[3, 7]]).HorizontalAlignment = XlHAlign.xlHAlignCenter;
                        ((Range)ws.Range[ws.Cells[2, 1], ws.Cells[3, 7]]).Interior.Color = XlRgbColor.rgbLightYellow;

                        //값 나열하기

                        System.Data.DataTable dt = ds.Tables[ws.Name];
                        for(int i = 0; i < dt.Rows.Count; i++)
                        {
                            DataRow dr = dt.Rows[i];
                            for(int j = 0; j < dr.ItemArray.Count(); j++)
                            {
                                ((Range)ws.Cells[4 + i, j + 1]).Value = dr[j].ToString();
                            }
                        }
                    ((Range)ws.Range[ws.Cells[4, 1], ws.Cells[3 + dt.Rows.Count, dt.Columns.Count]]).HorizontalAlignment = XlHAlign.xlHAlignCenter;
                        ((Range)ws.Range[ws.Cells[4, 2], ws.Cells[3 + dt.Rows.Count, 2]]).HorizontalAlignment = XlHAlign.xlHAlignLeft;
                        ws.UsedRange.Columns.AutoFit();
                        ws.UsedRange.Cells.Borders.LineStyle = XlLineStyle.xlContinuous;

                        #endregion 워크시트 내용 수셔넣기 끝

                    }
#endif

#if DEBUG
                wb.Worksheets.Add();
                //테스트용으로 제일 첫 시트만
                //워크시트 내용 삽입
                ws = (Worksheet)wb.Worksheets[1];
                //이름 지정
                ws.Name = list[0];
                Console.WriteLine($"테이블 {ws.Name} 엑셀 기록 시작");

                //테이블명
                ((Range)ws.Cells[1, 1]).Value = "테이블명";
                ((Range)ws.Cells[1, 1]).Interior.Color = XlRgbColor.rgbLightYellow;
                ((Range)ws.Range[ws.Cells[1, 1], ws.Cells[1, 2]]).Merge();
                ((Style)((Range)ws.Cells[1, 1]).Style).HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenterAcrossSelection;

                ((Range)ws.Cells[1, 3]).Value = ws.Name;
                ((Range)ws.Range[ws.Cells[1, 3], ws.Cells[1, 7]]).Merge();

                //테이블 설명
                ((Range)ws.Cells[2, 1]).Value = "테이블 설명";
                ((Range)ws.Cells[2, 1]).Interior.Color = XlRgbColor.rgbLightYellow;
                ((Range)ws.Range[ws.Cells[2, 1], ws.Cells[2, 2]]).Merge();
                ((Style)((Range)ws.Cells[2, 1]).Style).HorizontalAlignment = XlHAlign.xlHAlignCenterAcrossSelection;

                ((Range)ws.Cells[2, 3]).Value = ws.Name;
                ((Range)ws.Range[ws.Cells[1, 3], ws.Cells[1, 7]]).Merge();


                //컬럼 헤더
                ((Range)ws.Cells[3, 1]).Value = "No";
                ((Range)ws.Cells[3, 2]).Value = "필드명";
                ((Range)ws.Cells[3, 3]).Value = "자료형";
                ((Range)ws.Cells[3, 4]).Value = "길이";
                ((Range)ws.Cells[3, 5]).Value = "NULL여부";
                ((Range)ws.Cells[3, 6]).Value = "PK여부";
                ((Range)ws.Cells[3, 7]).Value = "비고";
                ((Range)ws.Range[ws.Cells[3, 1], ws.Cells[3, 7]]).HorizontalAlignment = XlHAlign.xlHAlignCenter;
                ((Range)ws.Range[ws.Cells[2, 1], ws.Cells[3, 7]]).Interior.Color = XlRgbColor.rgbLightYellow;
                
                //값 나열하기

                System.Data.DataTable dt = ds.Tables[ws.Name];
                for(int i = 0; i < dt.Rows.Count; i++)
                {
                    DataRow dr = dt.Rows[i];
                    for(int j = 0; j < dr.ItemArray.Count(); j++)
                    {
                        ((Range)ws.Cells[4 + i, j + 1]).Value = dr[j].ToString();
                    }
                }
                ((Range)ws.Range[ws.Cells[4, 1], ws.Cells[4 + dt.Rows.Count, dt.Columns.Count]]).HorizontalAlignment = XlHAlign.xlHAlignCenter;
                ((Range)ws.Range[ws.Cells[4, 2], ws.Cells[4 + dt.Rows.Count, 2]]).HorizontalAlignment = XlHAlign.xlHAlignLeft;
                ws.UsedRange.Columns.AutoFit();
                ws.UsedRange.Cells.Borders.LineStyle = XlLineStyle.xlContinuous;
#endif


                    //4. 엑셀 저장하고 마무리
                    wb.SaveAs(Environment.CurrentDirectory.ToString() + $@"\{list[0].Split('_')[0]}.xlsx", XlFileFormat.xlOpenXMLWorkbook, Missing.Value, Missing.Value, false, false, XlSaveAsAccessMode.xlNoChange, XlSaveConflictResolution.xlUserResolution, true, Missing.Value, Missing.Value, Missing.Value);
                    wb.Close(true);
                    excelApp.Quit();
                }
                finally
                {
                    // Clean up
                    ReleaseExcelObject(ws);
                    ReleaseExcelObject(wb);
                    ReleaseExcelObject(excelApp);
                }
            }
            catch(Exception e)
            {
                Console.WriteLine(e.ToString());
            }
        }
    }
}
