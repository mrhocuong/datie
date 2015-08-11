using System;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Text.RegularExpressions;

namespace gDrive
{
    internal class Program
    {
        private const string ApiKey = "6d3483e6373d658";
        private const string ApiSecret = "07e2d23520b7c8d17288665358a881b26780d7bc";
        // private const string ApiKey = "e8d2e289bf6fbba";
        //  private const string ApiSecret = "d85fca9d473c12e8ab768caf718e78accf6bc805";
        private static readonly DatieDBEntities _dbEntities = new DatieDBEntities();

        private static void Main(string[] args)
        {
            var logPath = @"c:\logImg.txt";
            var sb = new StringBuilder();
            var path = @"C:\img_resource";
            var files = Directory.EnumerateFiles(path, "*.*", SearchOption.AllDirectories).ToList();
            for (var i = 0; i < files.Count; i++)
            {
                var pathFile = files[i];
                Console.WriteLine("Upload file " + pathFile);
                var shopId = Convert.ToInt32(Directory.GetParent(pathFile).Name);
                Console.WriteLine("Shop Id " + shopId);
                var url = PostToImgur(pathFile, ApiKey, ApiSecret);
                if (url != null)
                {
                    Console.WriteLine("Upload Success " + url);
                    var img = AddImage(shopId, url);
                    if (img)
                    {
                        Console.WriteLine(i + " Shop Id ( " + shopId + " ) ---- " + "URL: " + url +
                                          " Add to database - success");
                        sb.AppendLine("Shop Id ( " + shopId + " ) ---- " + "URL: " + url +
                                      " Add to database - success");
                        sb.AppendLine();
                        using (var outfile = new StreamWriter(logPath, true))
                        {
                            outfile.WriteAsync(sb.ToString());
                        }
                        Console.WriteLine(url);
                    }
                    else
                    {
                        Console.WriteLine(i + " Shop Id ( " + shopId + " ) ---- " + "URL: " + url +
                                          " Add to database - fail");
                        sb.AppendLine("Shop Id ( " + shopId + " ) ---- " + "URL: " + url +
                                      " Add to database - fail");
                        sb.AppendLine();
                        using (var outfile = new StreamWriter(logPath, true))
                        {
                            outfile.WriteAsync(sb.ToString());
                        }
                        Console.WriteLine(url);
                    }
                }
                else
                {
                    url = "null";
                    Console.WriteLine(i + " Shop Id ( " + shopId + " ) ---- " + "URL: " + url +
                                      " Add to database - fail");
                    sb.AppendLine("Shop Id ( " + shopId + " ) ---- " + "URL: " + url +
                                  " Add to database - fail");
                    sb.AppendLine();
                    using (var outfile = new StreamWriter(logPath, true))
                    {
                        outfile.WriteAsync(sb.ToString());
                    }
                    Console.WriteLine(url);
                }
            }
            Console.ReadLine();
        }

        public static string PostToImgur(string imagFilePath, string apiKey, string apiSecret)
        {
            byte[] imageData;
            var fileStream = File.OpenRead(imagFilePath);
            imageData = new byte[fileStream.Length];
            fileStream.Read(imageData, 0, imageData.Length);
            fileStream.Close();

            const int MAX_URI_LENGTH = 32766;
            var base64img = Convert.ToBase64String(imageData);
            var sb = new StringBuilder();
            for (var i = 0; i < base64img.Length; i += MAX_URI_LENGTH)
            {
                sb.Append(Uri.EscapeDataString(base64img.Substring(i, Math.Min(MAX_URI_LENGTH, base64img.Length - i))));
            }

            var uploadRequestString = "client_id" + apiKey + "client_secret" + apiSecret + "&title=" + "imageTitle" +
                                      "&caption=" + "img" + "&image=" + sb;

            var webRequest = (HttpWebRequest) WebRequest.Create("https://api.imgur.com/3/upload.xml");
            //Authorization with project ID
            webRequest.Headers.Add("Authorization", "Client-ID e8d2e289bf6fbba");
            webRequest.Method = "POST";
            webRequest.ContentType = "application/x-www-form-urlencoded";
            webRequest.ServicePoint.Expect100Continue = false;

            var streamWriter = new StreamWriter(webRequest.GetRequestStream());

            streamWriter.Write(uploadRequestString);
            streamWriter.Close();

            var response = webRequest.GetResponse();
            var responseStream = response.GetResponseStream();
            var responseReader = new StreamReader(responseStream);
            var responseString = responseReader.ReadToEnd();


            var regex = new Regex("<link>(.*)</link>");
            //regex.ToString();
            var txtLink = regex.Match(responseString).Groups[1].ToString();
            return txtLink;
        }

        public static bool AddImage(int id, string imgLink)
        {
            var data = new tbl_Image
            {
                id_shop = id,
                url_image = imgLink,
                isDelete = false,
                update_date = DateTime.Now
            };
            _dbEntities.tbl_Image.Add(data);
            var check = _dbEntities.SaveChanges();
            if (check > 0)
            {
                return true;
            }
            return false;
        }
    }
}