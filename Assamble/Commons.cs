using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
// MSSQL 접속 클래스 라이브러리 
using System.Data.SqlClient;

namespace Assamble
{
    /* 클래스라이브러리, 프로젝트파일, 네임스페이스, DLL 파일
     * -하나 이상의 앱(클래스)에서 호출되는 형식 및 매서드 등을 정의하여 DLL로 제공
     *  단독으로 실행되지 않고 다른 프로그램에서 참조하여 사용하는 구조
     *  1. 핵심 소스의 보안성을 유지
     *  2. 배포 및 재사용이 쉽도록 지원
     */


    public class Commons
    {
        /* Static 한정자
         * - 프로그램 전체에서 유기적으로 관리해야하는 값이 발생하는 경우.
         *   객체의 생성없이 클래스 내의 필드(멤버변수) 값 자체를
         *   수정/읽기 하여 사용 할 수 있음.
         *   클래스에 머물러 있는 필드나 메서드 라는 의미에서
         *   정적필드/ 정적 메서드라고 함.
         */

        public static bool cLogInSF;
        public static string cLogInId;
        public static string cUserName;
        public static string cDbCon = "Data Source =222.235.141.8; Initial Catalog =LOT_F; User ID= LOT4; Password=2222";

        public DataTable Standard_Code(string sMajorCode)
        {
            // 공통코드(시스템코드) 테이블에서 sMajorCode 에 관련된 항목들을
            // DataTable 형식으로 return
            DataTable dtTemp = new DataTable();

            // 데이터베이스 접속.
            SqlConnection Con = new SqlConnection(cDbCon);
            Con.Open();

            try
            {
                // sMajorCode별 공통코드 정보를 받아오는 SQL 구문 작성.
                string sSelectStandard = string.Empty;


                sSelectStandard += "SELECT '[선택]' AS FSPACE ";
                sSelectStandard += "UNION                                ";
                sSelectStandard += "SELECT  FSPACE                     ";
                sSelectStandard += "FROM WORKORDER               ";
                //sSelectStandard += "SELECT '선택' AS WORK_ORDER";
                //sSelectStandard += "UNION                                ";
                //sSelectStandard += "SELECT FSPACE                     ";
                //sSelectStandard += "FROM WORKORDER               ";

                SqlDataAdapter Adatper = new SqlDataAdapter(sSelectStandard, Con);
                Adatper.Fill(dtTemp);

            }
            catch (Exception ex)
            {

            }
            finally
            {
                Con.Close();
            }

            return dtTemp;
        }
    }
}
