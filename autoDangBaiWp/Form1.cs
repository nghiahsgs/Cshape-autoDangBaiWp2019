using Newtonsoft.Json.Linq;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using xNet;

namespace autoDangBaiWp
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            Control.CheckForIllegalCrossThreadCalls = false;
            //pictureBox1.ImageLocation = "http://media.bongda.com.vn/files/anh.vu/2017/03/30/3a1-1010.jpg";
            // pictureBox1.ImageLocation = "http://nghiahsgs1000.000webhostapp.com/bannerToolCuongBig.html";
            // Define the border style of the form to a dialog box.
            this.FormBorderStyle = FormBorderStyle.FixedDialog;
            // Set the MaximizeBox to false to remove the maximize box.
            this.MaximizeBox = false;
            // Set the MinimizeBox to false to remove the minimize box.
            // this.MinimizeBox = false;
            // Set the start position of the form to the center of the screen.
            this.StartPosition = FormStartPosition.CenterScreen;
            // Display the form as a modal dialog box.
            //this.ShowDialog();
        }

        private void HamDangBaiwp(ChromeDriver driver, string titlePost, string ndungHTML, string price, string fileUpThumnail, ArrayList arrfileUpProduct)
        {

            string js = "";

            driver.Navigate().GoToUrl("http://spdep.com/wp-admin/post-new.php?post_type=product");
            Thread.Sleep(3000);
            driver.Navigate().GoToUrl("http://spdep.com/wp-admin/post-new.php?post_type=product");

            //  //MessageBox.Show("ok");
            while (true)
            {
                try
                {

                    js = "document.querySelector('input[name=\"post_title\"]').value='" + titlePost + "';";
                    ((IJavaScriptExecutor)driver).ExecuteScript(js);

                    break;
                }
                catch
                {

                }

            }
            //  //MessageBox.Show("ok");
            //  ndungHTML = ndungHTML.Replace("\n", "<br>");
            //  ndungHTML = ndungHTML.Replace(Environment.NewLine, "<br>");
            //  System.IO.File.WriteAllText("writeText2.html", ndungHTML);

            Thread.Sleep(1000);
            //MessageBox.Show(ndungHTML);

            //richTextBox1.Text = ndungHTML;

            //System.IO.File.WriteAllText("WriteText20.html", ndungHTML);
            // MessageBox.Show("ok");

            //  while (true)
            // {
            try
            {

                js = "document.querySelector('.wp-editor-area').value=\"" + ndungHTML + "\"";
                ((IJavaScriptExecutor)driver).ExecuteScript(js);

                // break;
            }
            catch
            {

            }

            // }
            // MessageBox.Show("ok2");

            //  chon danh muc
            /*
            while (true)
            {
                try
                {

                    js = "document.querySelector('#in-product_cat-32').click()";
                    ((IJavaScriptExecutor)driver).ExecuteScript(js);

                    break;
                }
                catch
                {

                }

            }*/

            //  title seo
            while (true)
            {
                try
                {

                    js = "document.querySelector('#yoast_wpseo_focuskw_text_input').value='" + titlePost + "'";
                    ((IJavaScriptExecutor)driver).ExecuteScript(js);

                    break;
                }
                catch
                {

                }

            }



            //  price
            while (true)
            {
                try
                {

                    js = "document.querySelector('.short.wc_input_price').value='" + price + "'";
                    ((IJavaScriptExecutor)driver).ExecuteScript(js);

                    break;
                }
                catch
                {

                }

            }

            // //MessageBox.Show("set thumbnail");
            //  set thumbnail

            while (true)
            {
                try
                {

                    js = "document.querySelector('#set-post-thumbnail').click()";
                    ((IJavaScriptExecutor)driver).ExecuteScript(js);

                    break;
                }
                catch
                {

                }

            }

            while (true)
            {
                try
                {

                    js = "document.querySelectorAll('.media-menu-item')[1].click()";
                    ((IJavaScriptExecutor)driver).ExecuteScript(js);

                    break;
                }
                catch
                {

                }

            }

            //  //MessageBox.Show(fileUpThumnail);
            // driver.FindElement(By.CssSelector("input[type=\"file\"]")).SendKeys(fileUpThumnail);
            Thread.Sleep(3000);

            //while (true)
            // {
            try
            {

                driver.FindElement(By.CssSelector("input[type=\"file\"]")).SendKeys(fileUpThumnail);
                //cho upload xong
                while (true)
                {
                    try
                    {

                        js = "return document.querySelector('.button.media-button.button-primary.button-large').getAttribute('disabled')=='disabled'";
                        string kq = ((IJavaScriptExecutor)driver).ExecuteScript(js).ToString();

                        ////MessageBox.Show(kq);
                        if (kq == "False")
                        {

                            //  //MessageBox.Show("set thoi");
                            //upload xong thi set lam thumbnail
                            js = "document.querySelector('.button.media-button.button-primary.button-large').click()";
                            ((IJavaScriptExecutor)driver).ExecuteScript(js);
                            break;
                        }


                        js = "return document.querySelector('.upload-error')==null";
                        kq = ((IJavaScriptExecutor)driver).ExecuteScript(js).ToString();
                        //upload loi
                        ////MessageBox.Show(kq);
                        if (kq == "False")
                        {
                            //upload loi thi se close
                            js = "document.querySelector('.media-modal-icon').click()";
                            ((IJavaScriptExecutor)driver).ExecuteScript(js);

                            break;
                        }




                    }
                    catch
                    {

                    }

                    Thread.Sleep(500);

                }

                //break;
            }
            catch
            {
                js = "document.querySelector('.media-modal-icon').click()";
                ((IJavaScriptExecutor)driver).ExecuteScript(js);
            }

            // }







            //   //MessageBox.Show("xong thumnail");



            for (int i = 0; i < arrfileUpProduct.Count; i++)
            {

                string fileUpProduct = arrfileUpProduct[i].ToString();
                //  set anh san pham


                while (true)
                {
                    try
                    {

                        js = "document.querySelector('.add_product_images a').click()";
                        ((IJavaScriptExecutor)driver).ExecuteScript(js);

                        break;
                    }
                    catch
                    {

                    }

                }

                while (true)
                {
                    try
                    {

                        js = "document.querySelectorAll('.media-menu-item')[4].click()";
                        ((IJavaScriptExecutor)driver).ExecuteScript(js);

                        break;
                    }
                    catch
                    {

                    }

                }

                // //MessageBox.Show("ok");
                Thread.Sleep(3000);
                // while (true)
                // {
                try
                {

                    driver.FindElements(By.CssSelector("input[type=\"file\"]"))[1].SendKeys(fileUpProduct);

                    //cho upload xong
                    while (true)
                    {
                        try
                        {

                            js = "return document.querySelectorAll('.button.media-button.button-primary.button-large')[1].getAttribute('disabled')=='disabled'";
                            string kq = ((IJavaScriptExecutor)driver).ExecuteScript(js).ToString();

                            ////MessageBox.Show(kq);
                            if (kq == "False")
                            {
                                //upload xong thi set lam anh sp
                                js = "document.querySelectorAll('.button.media-button.button-primary.button-large')[1].click()";
                                ((IJavaScriptExecutor)driver).ExecuteScript(js);
                                break;
                            }


                            js = "return document.querySelector('.upload-error')==null";
                            kq = ((IJavaScriptExecutor)driver).ExecuteScript(js).ToString();
                            //upload loi
                            ////MessageBox.Show(kq);
                            if (kq == "False")
                            {
                                //upload loi thi se close
                                js = "document.querySelectorAll('.media-modal-close')[1].click()";
                                ((IJavaScriptExecutor)driver).ExecuteScript(js);

                                break;
                            }


                        }
                        catch
                        {

                        }

                        Thread.Sleep(500);

                    }



                    // break;
                }
                catch
                {
                    js = "document.querySelectorAll('.media-modal-close')[1].click()";
                    ((IJavaScriptExecutor)driver).ExecuteScript(js);

                }

                //  }
                Thread.Sleep(3000);
                ////MessageBox.Show("ok");


                //  //MessageBox.Show("set thoi");







                // //MessageBox.Show("xong 1 anh sp");

            }



            // publish
            while (true)
            {
                try
                {

                    js = "document.querySelector('#publish').click()";
                    ((IJavaScriptExecutor)driver).ExecuteScript(js);

                    break;
                }
                catch
                {

                }

            }




        }
        private void button1_Click(object sender, EventArgs e)
        {

        }
        private string GetLinkAff(string cookie, string name, string itemid, string shopid)
        {

            // MessageBox.Show(Uri.EscapeDataString("nghiahsgs@gmail.com"));

            //string name = "Giày sneaker nữ thời trang";
            //string itemid = "1247756202";
            //string shopid = "39041561";

            HttpRequest request = new HttpRequest();
            request.UserAgent = Http.ChromeUserAgent();
            request.Cookies = new CookieDictionary();


            request.AddHeader("cookie", cookie);

            request.AddHeader("Upgrade-Insecure-Requests", "1");


            string urlSp = "https://shopee.vn/" + name + "-i." + shopid + "." + itemid;
            // MessageBox.Show(urlSp);

            string dataPost = "url=" + Uri.EscapeDataString(urlSp) + "&utm_source=&utm_medium=&utm_campaign=&utm_content=&short_link=1";



            String cc = request.Post("https://pub.accesstrade.vn/tools/product_links", dataPost, "application/x-www-form-urlencoded").ToString();
            //  MessageBox.Show(cc);

            // System.IO.File.WriteAllText("WriteText2.html", cc);


            Match y = Regex.Match(cc, "https:\\/\\/shorten.asia(.*?)\"");
            string linkRutGon = y.Groups[1].ToString();
            linkRutGon = "https://shorten.asia" + linkRutGon;


            //    MessageBox.Show(linkRutGon);

            return linkRutGon;





        }
        private void auto_login_wp(string urlWeb, string username, string password, ChromeDriver driver)
        {
            driver.Navigate().GoToUrl(urlWeb);
            //Thread.Sleep(3000);

            string js = "";
            while (true)
            {
                try
                {

                    js = "document.querySelector('#user_login').value='" + username + "'";
                    ((IJavaScriptExecutor)driver).ExecuteScript(js);

                    break;
                }
                catch
                {

                }

            }

            while (true)
            {
                try
                {

                    js = "document.querySelector('#user_pass').value='" + password + "'";
                    ((IJavaScriptExecutor)driver).ExecuteScript(js);

                    break;
                }
                catch
                {

                }

            }

            while (true)
            {
                try
                {

                    js = "document.querySelector('#wp-submit').click();";
                    ((IJavaScriptExecutor)driver).ExecuteScript(js);

                    break;
                }
                catch
                {

                }

            }

            while (true)
            {
                js = "return document.readyState;";
                var x = ((IJavaScriptExecutor)driver).ExecuteScript(js).ToString();
                if (x == "complete")
                {
                    break;
                }
                // //MessageBox.Show(x);
                // Console.WriteLine(x);
                Thread.Sleep(500);
            }

        }

        private void button2_Click(object sender, EventArgs e)
        {


            ChromeDriverService service = ChromeDriverService.CreateDefaultService();
            service.HideCommandPromptWindow = true;
            var options = new ChromeOptions();
            options.AddArgument("start-maximized");
            //options.AddArgument("--window-position=-32000,-32000");
            //options.AddArgument("--disable-notifications");
            //  options.AddArgument("--headless");
            //don't load image
            options.AddUserProfilePreference("profile.default_content_setting_values.images", 2);
            options.AddArgument("--user-agent=Opera/9.80 (Windows NT 6.0) Presto/2.12.388 Version/12.14");
            var driver = new ChromeDriver(service, options);

            string username = txtUserName1.Text;
            string password = txtPassWord1.Text;
            string cookie = richTextBoxCookieAff.Text;

            auto_login_wp("http://truyenzz.com/wp-admin/", username, password, driver);

            string keySearch = System.Uri.EscapeDataString(txtkeywordSp.Text);
            //MessageBox.Show(keySearch);


            HttpRequest request = new HttpRequest();
            request.UserAgent = Http.ChromeUserAgent();
            request.Cookies = new CookieDictionary();

            int newest = 0;

            for (int j = 0; j < 1000; j++)
            {

                string url = "https://shopee.vn/api/v2/search_items/?by=sales&keyword=" + keySearch + "&limit=50&locations=H%25C3%25A0%2520N%25E1%25BB%2599i&newest=" + newest.ToString() + "&order=desc&page_type=search";


                String cc = request.Get(url).ToString();

                JObject o = JObject.Parse(cc);



                //JToken jtoken = o["paging"]["next"];
                if (o["items"] != null)
                {
                    for (int i = 0; i < 1; i++)
                    // for (int i = 0; i < o["items"].Count(); i++)
                    {
                        // richTextBox1.Text = o["items"][i].ToString();

                        try
                        {
                            string itemid = o["items"][i]["itemid"].ToString();
                            string shopid = o["items"][i]["shopid"].ToString();

                            string name = o["items"][i]["name"].ToString();
                            //+ //MessageBox.Show(name);

                            // //MessageBox.Show("sp moi");
                            hamGetInfoSpShopeeAndDangBai(cookie, itemid, shopid, name, driver);
                        }
                        catch
                        {

                        }

                    }
                }

                newest += 50;
            }

        }
        public static string convertToUnSign3(string s)
        {
            Regex regex = new Regex("\\p{IsCombiningDiacriticalMarks}+");
            string temp = s.Normalize(NormalizationForm.FormD);
            return regex.Replace(temp, String.Empty).Replace('\u0111', 'd').Replace('\u0110', 'D');
        }

        private void hamGetInfoSpShopeeAndDangBai(string cookie, string itemid, string shopid, string name, ChromeDriver driver)
        {

            //System.IO.File.WriteAllText("log.txt", "itemid:"+ itemid+"|"+ "shopid:" + shopid);

            using (StreamWriter writetext = new StreamWriter("log.txt", true))
            {
                writetext.WriteLine("itemid:" + itemid + "|" + "shopid:" + shopid);
            }


            string linkRutGon = GetLinkAff(cookie, name, itemid, shopid);
            // MessageBox.Show(linkRutGon);

            //name = name.Replace(" ", "-");
            // string linkSp = "https://shopee.vn/"+ name + "-i."+ shopid + "."+ itemid;
            // richTextBox1.Text = linkSp;


            HttpRequest request = new HttpRequest();
            request.UserAgent = Http.ChromeUserAgent();
            request.Cookies = new CookieDictionary();

            request.AddHeader("user-agent", "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/67.0.3396.99 Safari/537.36");
            request.AddHeader("x-api-source", "pc");
            request.AddHeader("x-requested-with", "XMLHttpRequest");

            string url = "https://shopee.vn/api/v1/item_detail/?item_id=" + itemid + "&shop_id=" + shopid;
            String cc = request.Get(url).ToString();

            // richTextBox1.Text = cc;


            JObject o = JObject.Parse(cc);


            string description = "";
            if (o["description"] != null)
            {
                description = o["description"].ToString();
                // //MessageBox.Show(description);
                //System.IO.File.WriteAllText("description.txt", description);
                //richTextBox1.Text = description;
            }


            string rawNameFile = convertToUnSign3(name);
            rawNameFile = rawNameFile.Replace(" ", "-");
            rawNameFile.Replace(" ", "");
            //rawNameFile = "giay";

            ArrayList arrfileUpProduct = new ArrayList();





            if (o["images"] != null)
            {
                string images = o["images"].ToString();
                ////MessageBox.Show(images);
                string[] tokens = images.Split(',');


                for (int k = 0; k < tokens.Count(); k++)
                {

                    using (WebClient client = new WebClient())
                    {

                        client.DownloadFileAsync(new Uri("https://cf.shopee.vn/file/" + tokens[k]), @"C:\Users\DinhVan\Desktop\autoDangBaiWpSpDepzzz\img\" + rawNameFile + "-" + k.ToString() + ".png");


                        arrfileUpProduct.Add((@"C:\Users\DinhVan\Desktop\autoDangBaiWpSpDepzzz\img\" + rawNameFile + "-" + k.ToString() + ".png").Replace(" ", ""));
                    }
                }
                //  //MessageBox.Show(images);





                string titlePost = name;

                //MessageBox.Show(titlePost);
                /*
                description = "<br><strong>Click để mua giá rẻ hơn => <a href=\"" + linkRutGon + "\">"+ "Mua rẻ" + "</a></strong><br>" + description + ". <br>";

                description = "<br> sản phẩm đẹp là cửa hàng thời trang cung cấp những những đồ thời trang đẹp, giá rẻ , chúng tôi có " + name+description+ ". <br>";

               description = "<br>Liên hệ <strong>0982.149.607</strong> để được tư vấn miễn phí và hướng dẫn mua hàng <br>" + description+ " <br>";

                description = "<br><strong>Xem chi tiết hơn=> <a href=\"" + linkRutGon + "\">" + "Tại đây" + "</a></strong><br>" + description + ". <br>";



                description += "<br><strong>Còn chần chờ gì nữa, mua ngay thôi => <a href=\"" + linkRutGon + "\">" + "tại đây" + "</a></strong><br>";

                // description += "<br>Lưu ý: giá niêm yết bên trên không phải giá cuối cùng, giá cả thay đổi theo thị trường, vì vậy nên bạn muốn mua hàng thì nên gọi cho chúng tôi <strong>0982.149.607</strong>, chúng tôi sẽ gọi lại tư vấn miễn phí hoặc bạn có thể inbox với fanpage của chúng tôi; địa chỉ chính của chúng tôi ở ngõ <strong>127 phùng khoang, thanh xuân hà nội</strong>, xin cảm ơn !";

                string ndungHTML = "<div ><span>" + description + "</span></div>";
                */
                string ndungHTML = "<h2>nghiahsgs có thật sự chất lượng ?</h2> Spdep chúng tôi tự hào là đơn vị dẫn đầu trong phân phối cung cấp các sản phẩm <b><a href='https://www.youtube.com/channel/UC42DoOMU5kn1iyEhPs8v4OA'>túi xách nữ đẹp</a></b> chất lượng cực tốt . Sản phẩm được kiểm duyệt kĩ càng trước khi giao đến cho khách hàng . Với nhiều năm sản xuất chúng tôi cam kết đưa đến cho bạn sản phẩm, đúng kích thước , đúng màu sắc và đúng chất lượng như trên hình vẽ . Để làm làm rõ hơn chất lượng thực tế của sản phẩm chúng tôi cung cấp cho khác hàng các hình ảnh sống động chi tiết chất thông qua nguồn video trên youtube<center><b><a href='https://www.youtube.com/channel/UC42DoOMU5kn1iyEhPs8v4OA'> -&gt; Click vào xem mẫu túi xách trên youtube &lt;- </a> </b></center><center><img class='alignnone size-full wp-image-35440' src='http://spdep.com/wp-content/uploads/2018/11/sanphamdep.png' alt='túi xách nữ đẹp spdep' width='600' height='600' /></center><h2>nghiahsgs có thông số như thế nào ?</h2>";

                ndungHTML = ndungHTML.Replace("nghiahsgs", titlePost);

                ndungHTML += description;

                ndungHTML += "<h3>Làm thế nào tôi có thể mua được nghiahsgs ?</h3> Để mua được sản phẩm của chúng tôi bạn vui long click vào nút “Mua Ngay” bên trên dòng mô tả chúng tôi sẽ điều hướng bạn đến trang của shopspdep trên facebook .Khi đó đội ngũ chăm sóc khách hàng của chúng tôi sẽ hỗ trợ bạn các thống tin cần thiết để mọi người thực hiện mua hàng 1 cách dễ dàng .Ngoài ra bạn có thể liên hệ với chúng tôi thông qua<center><img class='alignnone size-full wp-image-35442' src='http://spdep.com/wp-content/uploads/2018/11/spdeptrenfaceebook.jpg' alt='túi xách nữ đẹp spdep' width='600' height='600' /> Click vào gửi tin nhắn để đội ngũ nhân viên hỗ trợ bạn</center><center><a href='https://www.facebook.com/shopmonmen/'>-&gt; Truy cập trang facebook của sản phẩm đẹp để mua hàng &lt;-</a></center>&nbsp;<h3>Các chính sách mua hàng tại sản phẩm đẹp</h3> Chúng tôi cung cấp dịch vụ chuyển phát với giá 30.000vnd 1 đơn hàng khu vực hà nội , thành phố hồ chí minh , đà nẵng . Đối với các khách hàng ngoại tỉnh phí ship 40.000vnđ Thời gian giao hàng giao động từ 2-7 ngày kể từ thời điểm chốt đơn giữa khách và đội ngũ nhân viên của chúng tôiNgoài ra đối với sản phẩm có giá trị trên 1.000.000đ shop sẽ hỗ trợ bạn 100% tiền ship Chúc quý khách có thể lựa chọn được mẫu giày nữ đẹp ưng ý nhất . Cùng ủng hộ shop bằng cách chia sẻ , follow và like cho shop trên các mạng xã hội nhé . <strong style='color: red; font-size: 20px;'>Cam kết của shop: Đổi -Trả-Hoàn tiền 100% nếu khách không hài lòng về sản phẩm Qúy khách vui lòng liên hệ <b>0969567833 </b> (Nhắn tin/ gọi điện/Zalo</strong>để được xử lý nhanh nhất)🍀 Túi xách nữ dành cho phái đẹp Hiện nay,túi xách nữ là phụ kiện thời trang thiết yếu với những cô gái.Một chiếc túi xách nữ phù hợp với phong cách và hoàn cảnh sẽ giúp bạn trở lên sang trọng quyến rũ gây ấn tượng mạnh trong mắt người xung quanh. Túi xách nữ là một phụ kiện hoàn hảo để tạo điểm nhân cho chính bạn.Các thương hiệu túi xách nữ đang ngày càng bùng nổ lan tỏa khắp mạng xã hội hay trên các diễn đàn.<h3>Sự đa dạng về mẫu mã và kiểu dáng của túi xách nữ</h3> <b>Túi xách nữ</b> : Với rất nhiều thương hiệu nổi bật như Gucci,Channel,Dior,…đã mang lại sự lựa chọn đa dạng cho các bạn gái <b>Túi bản to, túi đeo chéo</b> : được ra đời từ những thiệp niên đời đầu, túi bản to rất phù hợp cho các bạn thích di chuyển nhiều hay mang nhiều đồ.Những túi bản to đa dạng mẫu mã luôn làm bạn nổi bật giữa biển người <b>Túi handmade</b> : xuất phát nguồn từ những người dân miền núi , được làm thủ công nên mất rất nhiều thời gian <b>Túi xách nữ Quảng châu</b> : với cái giá đi kèm với chất lượng sản phẩm thì túi xách nữ Quảng Châu luon làm khách hàng cảm thấy vừa lòng <b>Túi xách nữ Hàn Quốc</b> : Với sự đa dạng về mẫu mã nên túi xách Hàn Quốc luôn được giới trẻ ưa chuộng <a href='http://spdep.com'>SPDEP.COM </a>sẽ cho các bạn hàng ngàn sự lựa chọn về những chiếc túi xách nữ.Bạn chỉ cần ở nhà và click chuột chúng sẽ mang đến cho bạn những chiếc túi đẹp nhất thị trường.Được đánh giá chất lượng 5* chúng tôi luôn tự hào về chất lượng của <b>túi xách nữ</b>";

                ndungHTML = ndungHTML.Replace("nghiahsgs", titlePost);

                ndungHTML = ndungHTML.Replace("\n", "<br>");
                ndungHTML = ndungHTML.Replace("\r", "<br>");
                ndungHTML = ndungHTML.Replace("\rn", "<br>");
                //ndungHTML = ndungHTML.Replace("\t", "");
                ndungHTML = ndungHTML.Replace(Environment.NewLine, "<br>");


                // using (StreamWriter writetext = new StreamWriter("test.txt", true))
                // {
                //     writetext.WriteLine(ndungHTML);
                // }
                // MessageBox.Show(ndungHTML);



                //  MessageBox.Show(ndungHTML);


                //richTextBox1.Text = ndungHTML;
                Random rnd = new Random();
                int month = rnd.Next(30, 50);

                string price = month.ToString() + "0000";

                int j = 0;
                string fileUpThumnail = (@"C:\Users\DinhVan\Desktop\autoDangBaiWpSpDepzzz\img\" + rawNameFile + " - " + j.ToString() + ".png").Replace(" ", "");
                // //MessageBox.Show(fileUpThumnail);
                //string fileUpThumnail = @"C:\Users\Mia\source\repos\autoGetSpShopee\autoGetSpShopee\bin\Debug\giay0.png";

                //string fileUpProduct =;

                //string[] arrfileUpProduct = new string[] { @"C:\Users\Mia\source\repos\autoGetSpShopee\autoGetSpShopee\bin\Debug\giay0.png", @"C:\Users\Mia\source\repos\autoGetSpShopee\autoGetSpShopee\bin\Debug\giay1.png", @"C:\Users\Mia\source\repos\autoGetSpShopee\autoGetSpShopee\bin\Debug\giay2.png" };

                //danh muc set trong ham
                HamDangBaiwp(driver, titlePost, ndungHTML, price, fileUpThumnail, arrfileUpProduct);




            }



        }

        private void button3_Click(object sender, EventArgs e)
        {
            string x = convertToUnSign3("Giày thể thao số 8 mới( full box)video shop quay");
            //MessageBox.Show(x);
        }

        private void button3_Click_1(object sender, EventArgs e)
        {

        }

        private void tabPage1_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void getNdungFromUrlAndRepost(string username, string password, string url, ChromeDriver driver)
        {
            driver.Navigate().GoToUrl(url);
            //Thread.Sleep(3000);

            string js = "";
            string title = "";
            while (true)
            {
                try
                {

                    js = "return document.querySelector('h1').innerText";
                    title = ((IJavaScriptExecutor)driver).ExecuteScript(js).ToString();
                    if (title != "")
                    {
                        break;
                    }

                }
                catch
                {

                }

            }
            // MessageBox.Show(title);

            string ndungHTML = "";
            while (true)
            {
                try
                {

                    js = "return document.querySelector('.maincontent').innerHTML";
                    ndungHTML = ((IJavaScriptExecutor)driver).ExecuteScript(js).ToString();
                    if (ndungHTML != "")
                    {
                        break;
                    }

                }
                catch
                {

                }

            }
            //MessageBox.Show(ndungHTML);


            //dang bai
            string introPost = "Truyện: <span style='color: #ff0000;'>" + title + "</span>";
            introPost += "<br>";
            introPost += "Tình trạng: Hoàn thành";
            introPost += "<br>";
            introPost += "Thể loại: <a href='http://truyenzz.com/category/truyen-gia-dinh/'>Truyện ngắn - Truyện Gia Đình</a>";
            introPost += "<br>";
            introPost += "Post bởi :<a href='http://truyenzz.com/' style='color: #ff0000;'>Truyện ZZ</a>";
            introPost += "<p style='text-align:center;'><strong>**********************</strong></p>";


            ndungHTML = introPost + ndungHTML;
            ndungHTML = ndungHTML.Replace("\n", "");
            ndungHTML = ndungHTML.Replace("\"", "'");
            ndungHTML = ndungHTML.Replace("\t", "");
            ndungHTML = ndungHTML.Replace("\r", "<br>");
            ndungHTML = ndungHTML.Replace("\rn", "<br>");

            ndungHTML = ndungHTML.Replace("img src", "p src");
            ndungHTML = ndungHTML.Replace(Environment.NewLine, "<br>");

            //  MessageBox.Show(ndungHTML);

            auto_post_bai_wp(title, ndungHTML, driver);



        }
        private void auto_post_bai_wp(string titlePost, string ndungHTML, ChromeDriver driver)
        {
            string js = "";

            driver.Navigate().GoToUrl("http://truyenzz.com/wp-admin/post-new.php");
            Thread.Sleep(1000);
            driver.Navigate().GoToUrl("http://truyenzz.com/wp-admin/post-new.php");
            Thread.Sleep(1000);



            //  MessageBox.Show("ok");
            while (true)
            {
                try
                {

                    js = "document.querySelector('input[name=\"post_title\"]').value='" + titlePost + "';";
                    ((IJavaScriptExecutor)driver).ExecuteScript(js);

                    break;
                }
                catch
                {

                }

            }


            Thread.Sleep(1000);

            // System.IO.File.WriteAllText("writeText2.html", ndungHTML);
            try
            {

                js = "document.querySelector('.wp-editor-area').value=\"" + ndungHTML + "\"";
                ((IJavaScriptExecutor)driver).ExecuteScript(js);

                // break;
            }
            catch
            {

            }
            // MessageBox.Show("ndungHTML");
            //chọn danh mục truyện
            while (true)
            {
                try
                {
                    //truyện ngắn
                    js = "document.querySelector(\"#category-2 input\").click()";
                    ((IJavaScriptExecutor)driver).ExecuteScript(js);

                    break;
                }
                catch
                {

                }

            }
            while (true)
            {
                try
                {
                    //truyện ngắn gia đình
                    js = "document.querySelector(\"#category-5 input\").click()";
                    ((IJavaScriptExecutor)driver).ExecuteScript(js);

                    break;
                }
                catch
                {

                }

            }

            //  title seo
            while (true)
            {
                try
                {

                    js = "document.querySelectorAll(\".SectionTitle__StyledTitle-iIjdHW\")[2].click()";
                    ((IJavaScriptExecutor)driver).ExecuteScript(js);

                    break;
                }
                catch
                {

                }

            }
            Thread.Sleep(1000);

            while (true)
            {
                try
                {

                    driver.FindElement(By.Id("focus-keyword-input")).SendKeys("TRUYỆN " + titlePost);

                    break;
                }
                catch
                {

                }

            }
            /*
            // them mo ta cho bai viet
            while (true)
            {
                try
                {

                    js = "document.querySelectorAll(\".Button-kDSBcD\")[3].click()";
                    ((IJavaScriptExecutor)driver).ExecuteScript(js);

                    break;
                }
                catch
                {

                }

            }
            Thread.Sleep(1000);
            string description = "Truyện \""+ titlePost + "\" . Hãy ghé thăm truyện ZZ để trải nghiệm nhiều hơn nhé";
            description = "nghaihsgs";
            MessageBox.Show(description);
            while (true)
            {
                try
                {

                    driver.FindElements(By.ClassName("public-DraftStyleDefault-block"))[1].SendKeys(description);
                    

                    break;
                }
                catch
                {

                }

                Thread.Sleep(500);
            }
            MessageBox.Show(description);
            */

            //Thread.Sleep(1000);
            Thread.Sleep(5000);

            // publish
            //while (true)
            //{
            try
            {

                js = "document.querySelector('#publish').click()";
                ((IJavaScriptExecutor)driver).ExecuteScript(js);
                driver.FindElement(By.Id("publish")).Click();

                //break;
            }
            catch
            {

            }
            Thread.Sleep(500);

            // }
        }
        private void button1_Click_1(object sender, EventArgs e)
        {
            ChromeDriverService service = ChromeDriverService.CreateDefaultService();
            service.HideCommandPromptWindow = true;
            var options = new ChromeOptions();
            options.AddArgument("start-maximized");
            //options.AddArgument("--window-position=-32000,-32000");
            //options.AddArgument("--disable-notifications");
            //  options.AddArgument("--headless");
            //don't load image
            options.AddUserProfilePreference("profile.default_content_setting_values.images", 2);
            options.AddArgument("--user-agent=Opera/9.80 (Windows NT 6.0) Presto/2.12.388 Version/12.14");
            var driver = new ChromeDriver(service, options);

            string username = txtUserName2.Text;
            string password = txtPassWord2.Text;

            auto_login_wp("http://truyenzz.com/wp-admin/", username, password, driver);
            //MessageBox.Show("setting prevent show pop up this web");

            HttpRequest request = new HttpRequest();
            request.UserAgent = Http.ChromeUserAgent();
            request.Cookies = new CookieDictionary();


            for (int j = 46; j > 0; j--)
            {

                using (StreamWriter writetext = new StreamWriter("log.txt", true))
                {
                    writetext.WriteLine("page:" + j.ToString());
                }

                string url = "https://www.truyenngan.com.vn/truyen-ngan/truyen-ngan-gia-dinh/" + j.ToString();

                String cc = request.Get(url).ToString();

                Match y = Regex.Match(cc, "https:\\/\\/www.truyenngan.com.vn\\/truyen-ngan\\/truyen-ngan-gia-dinh\\/(.*?)\\.html");

                string kq = "";
                while (y.ToString() != "")
                {

                    if (kq != y.ToString())
                    {
                        //URL
                        kq = y.ToString();
                        //MessageBox.Show(kq);
                        getNdungFromUrlAndRepost(username, password, kq, driver);

                    }
                    y = y.NextMatch();


                }
            }
        }
    }
}
