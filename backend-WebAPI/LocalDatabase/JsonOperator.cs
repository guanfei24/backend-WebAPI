using System;
using System.Text;
using Newtonsoft.Json;

namespace backend_WebAPI.LocalDatabase
{
	public class JsonOperator
	{
        /// <summary>
        /// 将序列化的json字符串内容写入Json文件，并且保存
        /// </summary>
        /// <param name="path">路径</param>
        /// <param name="jsonConents">Json内容</param>
        public static void WriteJsonFile(string path, string jsonConents)
        {
            using (FileStream fs = new FileStream(path, FileMode.OpenOrCreate, System.IO.FileAccess.ReadWrite, FileShare.ReadWrite))
            {
                fs.Seek(0, SeekOrigin.Begin);
                fs.SetLength(0);
                using (StreamWriter sw = new StreamWriter(fs, Encoding.UTF8))
                {
                    sw.WriteLine(jsonConents);
                }
            }
        }

        /// <summary>
        /// 获取到本地的Json文件并且解析返回对应的json字符串
        /// </summary>
        /// <param name="filepath">文件路径</param>
        /// <returns>Json内容</returns>
        public static string GetJsonFile(string filepath)
        {
            string json = string.Empty;
            using (FileStream fs = new FileStream(filepath, FileMode.OpenOrCreate, System.IO.FileAccess.ReadWrite, FileShare.ReadWrite))
            {
                using (StreamReader sr = new StreamReader(fs, Encoding.UTF8))
                {
                    json = sr.ReadToEnd().ToString();
                }
            }
            return json;
        }

        public static List<Student> ReadJsonFileToList(string filepath)
        {
            //将Json转换回列表
            //var directorypath = Directory.GetCurrentDirectory();
            //string strFileName = "\\LocalData\\Student.json";
            string jsonData = GetJsonFile(filepath);
            Console.WriteLine(jsonData);
            //反序列化Json字符串内容为对象
            List<Student> jsondata = JsonConvert.DeserializeObject<List<Student>>(jsonData);
            return jsondata;

        }
    }
}

