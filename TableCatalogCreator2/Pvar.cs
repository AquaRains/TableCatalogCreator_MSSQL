using System.IO;
using System.Text;

namespace TableCatalogCreator2.Modules
{

    /// <summary>
    /// 프로그램 전역에서 참조하는 값들을 포함하는 클래스입니다.
    /// </summary>
    public class PublicVar
    {
        /// <summary>
        /// MoldCTS 버전 정보
        /// </summary>
        public string VersionInfo { get; }
        /// <summary>
        /// 접속 정보
        /// </summary>
        public ConnectInfo ConnectInfo { get; }


        public PublicVar(string optionsPath)
        {
            this.VersionInfo = GetVersionInfo(optionsPath);
            this.ConnectInfo = new ConnectInfo(optionsPath);
        }

        private string GetVersionInfo(string Path)
        {
            return "unnumbered";
        }

    }

    
    

    public class ConnectInfo
    {
        public string IpAddress { get; private set; }
        public string Port { get; private set; }
        public string DbName { get; internal set; }
        private string FileName = "Server.ini";
        public ConnectInfo(string path)
        {
            CheckFile(path);
        }

        private void CheckFile(string Path)
        {
            string filePath = Path + FileName;
            if(File.Exists(filePath))
            {
                StringBuilder sb = new StringBuilder(255);
                INI.GetPrivateProfileString("LoginInfo", "ServerIP", "", sb, sb.Capacity, filePath);
                this.IpAddress = sb.ToString();
                INI.GetPrivateProfileString("LoginInfo", "Port", "1433", sb, sb.Capacity, filePath);
                this.Port = sb.ToString();
                INI.GetPrivateProfileString("LoginInfo", "DB", "", sb, sb.Capacity, filePath);
                this.DbName = sb.ToString();
            }
            else
            {
                throw new FileNotFoundException($@"{FileName}파일을 찾을 수 없습니다.");
            }
        }
    }

}
