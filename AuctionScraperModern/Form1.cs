using HtmlAgilityPack;
using MetroFramework;
using MetroFramework.Forms;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Reflection;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Web;
using System.Windows.Forms;

namespace AuctionScraperModern
{
    public partial class Form1 : MetroForm
    {
        public static List<MusicEvent> _MusicEventList = new List<MusicEvent>();
        public static HtmlWeb web = new HtmlWeb();
        public static DataTable dt = new DataTable();
        public static int number = 0;
        public Form1()
        {
            InitializeComponent();          
            txtlogs.Visible = false;
            metroProgressSpinner4.Visible = false;
            metroProgressSpinner1.Visible = false;
        }
        void updateContent(MetroFramework.Controls.MetroTextBox textBox, string content)
        {

            textBox.Invoke(
                new EventHandler(
                    delegate
                    {
                        txtlogs.AppendText(Environment.NewLine);
                        textBox.AppendText(content);
                    }));
        }
        private void metroButton2_Click(object sender, EventArgs e)
        {
            writeLog("Start Scraping *****");
            txtlogs.Visible = true;
            txtlogs.Text = "Logs";
            number = 0;
            dt = new DataTable();
            metroGrid1.DataSource = dt;
            metroProgressSpinner4.Visible = true;
            metroProgressSpinner1.Visible = true;
            metroButton2.Enabled = false;
            userDetails();
        }
        public async Task userDetails()
        {
            try
            {
                List<string> collection = new List<string>();
                collection.Add(chkticketmasterMX.Text.ToString());
                collection.Add(chkticketmasterES.Text.ToString());
                collection.Add(chkticketek.Text.ToString());
                collection.Add(chkconcertfix.Text.ToString());

                collection.Add(chkauctionsnewengland.Text.ToString());
                collection.Add(chkauctionsri.Text.ToString());
                collection.Add(chkauctionmarketinggroup.Text.ToString());
                collection.Add(chkbaystateauction.Text.ToString());
                collection.Add(chkbermanauctions.Text.ToString());
                collection.Add(chkjjmanning.Text.ToString());
                collection.Add(chklandmarkauction.Text.ToString());
                collection.Add(chkmaxpollack.Text.ToString());
                collection.Add(chkmonroeauctiongroup.Text.ToString());
                collection.Add(chkdeanassociatesinc.Text.ToString());
                collection.Add(chklivenation.Text.ToString());

                collection.Add(chktcpr.Text.ToString());
                collection.Add(chkatrapalo.Text.ToString());
                collection.Add(chkticketmundo.Text.ToString());
                collection.Add(chkticketpop.Text.ToString());
                collection.Add(chkticketeaNew.Text.ToString());
                collection.Add(chktickeri.Text.ToString());
                collection.Add(chktuticketNov.Text.ToString());
                collection.Add(chkticketshopNov.Text.ToString());
                foreach (var item in collection)
                {
                    await Task.Run(() =>
                               {
                                   if (chkauctionmarketinggroup.Checked == true && item.Contains("eventos.tuboleta.com.do"))
                                   {
                                       ThreadCall(item);
                                   }
                                   if (chkauctionsri.Checked == true && item.Contains("uepatickets.com"))
                                   {
                                       ThreadCall(item);
                                   }
                                   if (chkauctionsnewengland.Checked == true && item.Contains("ticketexpress.com.do"))
                                   {
                                       ThreadCall(item);
                                   }
                                   if (chkbaystateauction.Checked == true && item.Contains("quehacerhoy.com.do"))
                                   {
                                       ThreadCall(item);
                                   }
                                   if (chkbermanauctions.Checked == true && item.Contains("puntoticket.com"))
                                   {
                                       ThreadCall(item);
                                   }
                                   if (chkjjmanning.Checked == true && item.Contains("eticket.cr"))
                                   {
                                       ThreadCall(item);
                                   }
                                   if (chklandmarkauction.Checked == true && item.Contains("ticketshow.com"))
                                   {
                                       ThreadCall(item);
                                   }
                                   if (chkmaxpollack.Checked == true && item.Contains("stubhub.com.mx"))
                                   {
                                       ThreadCall(item);
                                   }
                                   if (chkmonroeauctiongroup.Checked == true && item.Contains("ticketea.com.py"))
                                   {
                                       ThreadCall(item);
                                   }
                                   if (chkdeanassociatesinc.Checked == true && item.Contains("vive.tuboleta.com"))
                                   {
                                       ThreadCall(item);
                                   }
                                   if (chklivenation.Checked == true && item.Contains("livenation.com"))
                                   {
                                       ThreadCall(item);
                                   }


                                   if (chktcpr.Checked == true && item.Contains("https://tcpr.com/"))
                                   {
                                       ThreadCall(item);
                                   }
                                   if (chkatrapalo.Checked == true && item.Contains("www.atrapalo.com"))
                                   {
                                       ThreadCall(item);
                                   }
                                   if (chkticketmundo.Checked == true && item.Contains("www.ticketmundo.com"))
                                   {
                                       ThreadCall(item);
                                   }
                                   if (chkticketpop.Checked == true && item.Contains("www.ticketpop.com"))
                                   {
                                       ThreadCall(item);
                                   }



                                   if (chkconcertfix.Checked == true && item.Contains("concertfix.com"))
                                   {
                                       ThreadCall(item);
                                   }
                                   if (chkticketmasterES.Checked == true && item.Contains("ticketmaster.es"))
                                   {
                                       ThreadCall(item);
                                   }
                                   if (chkticketmasterMX.Checked == true && item.Contains("ticketmaster.com.mx"))
                                   {
                                       ThreadCall(item);
                                   }
                                   if (chkticketek.Checked == true && item.Contains("ticketek.com.ar"))
                                   {
                                       ThreadCall(item);
                                   }

                                   if (chkticketeaNew.Checked == true && item.Contains("www.ticketea.com/"))
                                   {
                                       ThreadCall(item);
                                   }
                                   if (chktickeri.Checked == true && item.Contains("www.tickeri.com"))
                                   {
                                       ThreadCall(item);
                                   }


                                   if (chkticketshopNov.Checked == true && item.Contains("ticketshop.com.co"))
                                   {
                                       ThreadCall(item);
                                   }
                                   if (chktuticketNov.Checked == true && item.Contains("www.tuticket.com"))
                                   {
                                       ThreadCall(item);
                                   }
                               });
                }

                await excel();
                metroButton2.Enabled = true;
                metroProgressSpinner4.Visible = false;
                metroProgressSpinner1.Visible = false;
                txtlogs.Visible = false;
            }
            catch (Exception ex)
            {
                //lblwait.Visible = false;
                metroProgressSpinner4.Visible = false;
                metroProgressSpinner1.Visible = false;
                txtlogs.Visible = false;
                metroButton2.Enabled = true;
                MessageBox.Show("Error" + ex.ToString());
            }
        }
        public async Task excel()
        {
            writeLog("Start Export To CSV");
            try
            {
                string appPath = System.IO.Path.GetDirectoryName(Application.ExecutablePath) + @"\ExportFile";
                bool exists = System.IO.Directory.Exists(appPath);
                if (!exists)
                {
                    System.IO.Directory.CreateDirectory(appPath);
                }
                string filePath = appPath + @"\music_event_" + DateTime.Now.ToString("MM-dd-yyyy-HHmmssfff") + ".csv";
                dt = ToDataTable(_MusicEventList);
                ToCSV(dt, filePath);
                metroGrid1.DataSource = dt;
                //MessageBox.Show("File Path :" + filePath);
                MetroMessageBox.Show(this, "File Path :" + filePath, "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Process proc = new Process();
                proc.StartInfo = new ProcessStartInfo("excel.exe", filePath);
                proc.Start();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error" + ex.ToString());
            }
        }
        public async void ThreadCall(string type)
        {
            try
            {
                if (type.Contains("www.ticketea.com/"))
                {
                    ticketeaNew();
                }
                if (type.Contains("www.tickeri.com"))
                {
                    tickeri();
                }
                if (type.Contains("livenation.com"))
                {
                    Livenation();
                }
                if (type.Contains("eventos.tuboleta.com.do"))
                {
                    Eventos();
                }
                if (type.Contains("uepatickets.com"))
                {
                    Uepatickets();
                }
                if (type.Contains("ticketexpress.com.do"))
                {
                    Ticketexpress();
                }
                if (type.Contains("quehacerhoy.com.do"))
                {
                    Quehacerhoy();
                }

                if (type.Contains("puntoticket.com"))
                {
                    Puntoticket();
                }
                if (type.Contains("vive.tuboleta.com"))
                {
                    Tuboleta();
                }
                if (type.Contains("eticket.cr"))
                {
                    Eticket();
                }

                if (type.Contains("ticketshow.com"))
                {
                    Ticketshow();
                }
                if (type.Contains("www.stubhub.com.mx"))
                {
                    Stubhub();
                }
                if (type.Contains("ticketea.com.py"))
                {
                    Ticketea();
                }

                if (type.Contains("https://tcpr.com/"))
                {
                    Tcpr();
                }
                if (type.Contains("www.atrapalo.com"))
                {
                    Atrapalo();
                }
                if (type.Contains("www.ticketmundo.com"))
                {
                    Ticketmundo();
                }
                if (type.Contains("www.ticketpop.com"))
                {
                    Ticketpop();
                }

                if (type.Contains("ticketek.com.ar"))
                {
                    ticketek();
                }
                if (type.Contains("ticketmaster.es"))
                {
                    ticketmasterES();
                }
                if (type.Contains("ticketmaster.com.mx"))
                {
                    ticketmasterMX();
                }
                if (type.Contains("concertfix.com"))
                {
                    concertfix();
                }
                if (type.Contains("www.tuticket.com"))
                {
                    tuticket();
                }
                if (type.Contains("ticketshop.com.co"))
                {
                    ticketshop();
                }
            }
            catch (Exception)
            {

            }
        }

        public static List<string> superboletos_Post(string URL)
        {
            List<string> PageData = new List<string>();
            string responseData = string.Empty;
            try
            {
                CookieContainer cookies = new CookieContainer();
                responseData = GetFirstRespParams("http://web.superboletos.com:8001/SuperBoletos/cdmxyedomex/concierto", ref cookies);
             
                for (int i = 1; i < 10; i++)
                {
                       
                        string postData = String.Format("_callCount=1"
                                                        + "windowName="
                                                        + "c0-scriptName=dwrServiceIndex"
                                                        + "c0-methodName=obtenerEventosPaginado"
                                                        + "c0-id=0"
                                                        + "c0-param0=string:CDMXYEDOMEX"
                                                        + "c0-param1=string:CONCIERTO"
                                                        + "c0-param2=string:"
                                                        + "c0-param3=string:encontrado"
                                                        + "c0-param4=number:4"
                                                        + "c0-param5=string:g9BmWhNHicCyTpNS9TlvmQ"
                                                        + "batchId="+i
                                                        + "page=%2FSuperBoletos%2Fcdmxyedomex%2Fconcierto"
                                                        + "httpSessionId="
                                                        + "scriptSessionId=B9C1B425319C3FCA1891FF8B3713627D");
                        string HostName = "web.superboletos.com:8001";
                        responseData = GetDataWithParams("http://web.superboletos.com:8001/SuperBoletos/cdmxyedomex/concierto", ref cookies, postData, HostName);
                       
                        PageData.Add(responseData);                  
                }
            }
            catch (Exception ex)
            { }
            return PageData;
        }


        public void superboletos()
        {
            try
            {
                updateContent(txtlogs, "******Start Scraping :http://web.superboletos.com:8001/SuperBoletos/cdmxyedomex/concierto");
                string responseData = string.Empty;
                List<string> PageData = superboletos_Post("http://web.superboletos.com:8001/SuperBoletos/index.do");
                CookieContainer cookies = new CookieContainer();
                responseData = GetFirstRespParams("http://web.superboletos.com:8001/SuperBoletos/index.do", ref cookies);

                responseData = GetFirstRespParams("http://web.superboletos.com:8001/SuperBoletos/cdmxyedomex/concierto", ref cookies);
                HtmlAgilityPack.HtmlDocument htmlDocument = new HtmlAgilityPack.HtmlDocument();
                htmlDocument.LoadHtml(responseData);
                HtmlNodeCollection Page = htmlDocument.DocumentNode.SelectNodes("//a[@class='tahoma14 blue12']");
                if (Page != null)
                {
                    for (int i = 0; i < Page.Count(); i++)
                    {
                        try
                        {

                            string busyUrl = "https://www.tuticket.com" + Page[i].Attributes["href"].Value;
                            busyUrl = busyUrl.Replace(" ", "%20");
                            HtmlAgilityPack.HtmlDocument doc1 = web.Load(busyUrl.Replace("2_M&#250;sica", "2_Música"));
                            HtmlNodeCollection datafun = doc1.DocumentNode.SelectNodes("//label[@id='lblTitulo']");

                            MusicEvent _obj = new MusicEvent();
                            _obj.Website = "https://www.tuticket.com/";

                            _obj.Function = Replace(datafun[0].InnerText.Trim());
                            HtmlNodeCollection time = doc1.DocumentNode.SelectNodes(".//select[@class='fechaFuncion form-control']");
                            string datetime = time[0].InnerText.Trim().Remove(time[0].InnerText.Trim().Length - 10);
                            datetime = datetime.Replace("@", "");
                            datetime = datetime.Replace("2017", "");
                            datetime = datetime.Replace("2018", "");
                            datetime = datetime.Replace("2019", "");
                            datetime = datetime.Replace("2020", "");
                            _obj.DateTime = datetime.Replace(" de ", " ").Trim();
                            HtmlNodeCollection Ens = doc1.DocumentNode.SelectNodes(".//label[@id='Label3']");

                            _obj.Enclosure = Replace(Ens[0].InnerText.Replace("mostrar mapa", "").Trim());

                            _obj.BuyLink = busyUrl.Replace("2_M&#250;sica", "2_Música");
                            updateContent(txtlogs, "Site: https://www.ticketea.com = > Function :" + _obj.Function + ", Date :" + _obj.DateTime);

                            _obj.Function = ReplaceChar(_obj.Function);
                            _obj.Enclosure = ReplaceChar(_obj.Enclosure);
                            _obj.DateTime = ReplaceChar(_obj.DateTime.Replace(",", ""));
                            _obj.DateTime = Convert.ToDateTime(_obj.DateTime).ToString();
                            _MusicEventList.Add(_obj);
                        }
                        catch (Exception)
                        {
                            continue;
                        }
                    }
                }
            }
            catch (Exception ex)
            {

            }
        }



        public void tuticket()
        {
            try
            {
                updateContent(txtlogs, "******Start Scraping :https://www.tuticket.com");

                string responseData = GetEventLists2("https://www.tuticket.com/Website/co");
                HtmlAgilityPack.HtmlDocument htmlDocument = new HtmlAgilityPack.HtmlDocument();
                htmlDocument.LoadHtml(responseData);
                HtmlNodeCollection Page = htmlDocument.DocumentNode.SelectNodes("//a[@class='tahoma14 blue12']");
                if (Page != null)
                {
                    for (int i = 0; i < Page.Count(); i++)
                    {
                        try
                        {

                            string busyUrl = "https://www.tuticket.com" + Page[i].Attributes["href"].Value;
                            busyUrl = busyUrl.Replace(" ", "%20");
                            HtmlAgilityPack.HtmlDocument doc1 = web.Load(busyUrl.Replace("2_M&#250;sica", "2_Música"));
                            HtmlNodeCollection datafun = doc1.DocumentNode.SelectNodes("//label[@id='lblTitulo']");

                            MusicEvent _obj = new MusicEvent();
                            _obj.Website = "https://www.tuticket.com/";

                            _obj.Function = Replace(datafun[0].InnerText.Trim());
                            HtmlNodeCollection time = doc1.DocumentNode.SelectNodes(".//select[@class='fechaFuncion form-control']");
                            string datetime = time[0].InnerText.Trim().Remove(time[0].InnerText.Trim().Length - 10);
                            datetime = datetime.Replace("@", "");
                            datetime = datetime.Replace("2017", "");
                            datetime = datetime.Replace("2018", "");
                            datetime = datetime.Replace("2019", "");
                            datetime = datetime.Replace("2020", "");
                            _obj.DateTime = datetime.Replace(" de ", " ").Trim();
                            HtmlNodeCollection Ens = doc1.DocumentNode.SelectNodes(".//label[@id='Label3']");

                            _obj.Enclosure = Replace(Ens[0].InnerText.Replace("mostrar mapa", "").Trim());

                            _obj.BuyLink = busyUrl.Replace("2_M&#250;sica", "2_Música");
                            updateContent(txtlogs, "Site: https://www.ticketea.com = > Function :" + _obj.Function + ", Date :" + _obj.DateTime);

                            _obj.Function = ReplaceChar(_obj.Function);
                            _obj.Enclosure = ReplaceChar(_obj.Enclosure);
                            _obj.DateTime = ReplaceChar(_obj.DateTime.Replace(",", ""));
                            _obj.DateTime = Convert.ToDateTime(_obj.DateTime).ToString();
                            _MusicEventList.Add(_obj);
                        }
                        catch (Exception)
                        {
                            continue;
                        }
                    }
                }
            }
            catch (Exception ex)
            {

            }
        }

        public string GetEventLists2(string url)
        {

            string responseData = string.Empty;
            CookieContainer cookies = new CookieContainer();
            responseData = GetFirstRespParams(url, ref cookies);
            responseData = GetFirstRespParams("https://www.tuticket.com/Website/Seccion/Musica", ref cookies);

            return responseData;

        }

        public void ticketshop()
        {
            try
            {
                updateContent(txtlogs, "******Start Scraping :https://ticketshop.com.co/site/conciertos/");
                HtmlAgilityPack.HtmlDocument doc = web.Load("https://ticketshop.com.co/site/conciertos/");
                HtmlNodeCollection collection = doc.DocumentNode.SelectNodes("//div[@class='carrusel_eventos']/ul/li");
                if (collection != null)
                {
                    for (int i = 0; i < collection.Count(); i++)
                    {
                        try
                        {

                            MusicEvent _obj = new MusicEvent();
                            HtmlNodeCollection collection2 = collection[i].SelectNodes(".//h2");
                            _obj.Function = collection2[0].InnerText.Replace("\r\n", " ").Trim();
                            _obj.Website = "ticketshop.com.co/";
                            HtmlNodeCollection collection3 = collection[i].SelectNodes(".//p");
                            string date1 = collection3[0].InnerText.Replace("\r\n", " ").Trim();
                            string time1 = collection3[3].InnerText.Replace("Horario: ", "").Trim();
                            _obj.DateTime = date1 + " " + time1;
                            string place = collection3[6].InnerText.Replace("Lugar: ", "").Trim();
                            _obj.Enclosure = place;
                            HtmlNodeCollection url1 = collection[i].SelectNodes(".//div/a");
                            _obj.BuyLink = url1[0].Attributes["href"].Value; ;
                            _obj.Function = ReplaceChar(_obj.Function);
                            _obj.Enclosure = ReplaceChar(_obj.Enclosure);
                            _obj.DateTime = _obj.DateTime.Replace(" de ", " ");
                            _obj.DateTime = _obj.DateTime.Replace(" DE ", " ");
                            _obj.DateTime = Convert.ToDateTime(ReplaceChar(_obj.DateTime).Trim().Replace("Hs", ":00")).ToString();
                            updateContent(txtlogs, "Site: http://www.ticketek.com.ar = > Function :" + _obj.Function + ", Date :" + _obj.DateTime);

                            _MusicEventList.Add(_obj);
                        }
                        catch (Exception)
                        {
                            continue;
                        }
                    }
                }
            }
            catch (Exception ex)
            {

            }
        }


        public void ticketeaNew()
        {
            try
            {
                updateContent(txtlogs, "******Start Scraping : https://www.ticketea.com/");
                for (int i = 1; i < 30; i++)
                {
                    HtmlAgilityPack.HtmlDocument doc1 = web.Load("https://www.ticketea.com/conciertos/?sorted_by=start_date_time&page=" + i);
                    HtmlNodeCollection Page = doc1.DocumentNode.SelectNodes("//a[@class='card__link']");
                    for (int j = 0; j < Page.Count; j++)
                    {
                        try
                        {

                            string busyUrl = Page[j].Attributes["href"].Value;
                            doc1 = web.Load(busyUrl);
                            HtmlNodeCollection datafun = doc1.DocumentNode.SelectNodes("//p[@class='header-details__event-title']");

                            MusicEvent _obj = new MusicEvent();
                            _obj.Website = "ticketea.com/";

                            _obj.Function = Replace(datafun[0].InnerText);
                            HtmlNodeCollection date = doc1.DocumentNode.SelectNodes(".//li[@class='detail-date']");
                            HtmlNodeCollection time = doc1.DocumentNode.SelectNodes(".//li[@class='detail-time']/span/strong");
                            _obj.DateTime = Replace(date[0].InnerText.Trim().Replace("      ", "") + " " + time[0].InnerText.Trim().Replace("(CEST)        Europe/Madrid", "")).Replace("         ", " ").Trim();
                            HtmlNodeCollection Ens = doc1.DocumentNode.SelectNodes(".//li[@class='detail-location']");

                            _obj.Enclosure = Replace(Ens[0].InnerText.Replace("mostrar mapa", "").Trim());

                            _obj.BuyLink = busyUrl;
                            updateContent(txtlogs, "Site: https://www.ticketea.com = > Function :" + _obj.Function + ", Date :" + _obj.DateTime);

                            _obj.Function = ReplaceChar(_obj.Function);
                            _obj.Enclosure = ReplaceChar(_obj.Enclosure);
                            _obj.DateTime = ReplaceChar(_obj.DateTime.Replace("h", ""));
                            _obj.DateTime = Convert.ToDateTime(_obj.DateTime).ToString();
                            _MusicEventList.Add(_obj);


                        }
                        catch (Exception ex)
                        {
                            continue;
                        }
                    }
                }
            }
            catch (Exception)
            {
            }
        }

        public void tickeri()
        {
            try
            {
                updateContent(txtlogs, "******Start Scraping : https://www.tickeri.com");
                for (int i = 1; i < 17; i++)
                {
                    HtmlAgilityPack.HtmlDocument doc1 = web.Load("https://www.tickeri.com/events?page=" + i);
                    HtmlNodeCollection Page = doc1.DocumentNode.SelectNodes("//div[@class='flyer']/a");
                    for (int j = 0; j < Page.Count; j++)
                    {
                        try
                        {

                            string busyUrl = "https://www.tickeri.com" + Page[j].Attributes["href"].Value;
                            doc1 = web.Load(busyUrl);
                            HtmlNodeCollection datafun = doc1.DocumentNode.SelectNodes("//h1[@id='event-name']");

                            MusicEvent _obj = new MusicEvent();
                            _obj.Website = "tickeri.com/";

                            _obj.Function = Replace(datafun[0].InnerText);
                            HtmlNodeCollection date = doc1.DocumentNode.SelectNodes(".//h2[@id='event-date']");

                            _obj.DateTime = Replace(date[0].InnerText.Trim().Replace("      ", "")).Replace("         ", " ").Trim();
                            HtmlNodeCollection Ens = doc1.DocumentNode.SelectNodes(".//h3[@id='event-venue']");
                            HtmlNodeCollection Ens1 = doc1.DocumentNode.SelectNodes(".//address[@id='event-address']");
                            _obj.Enclosure = Replace(Ens[0].InnerText.Replace("mostrar mapa", "").Trim() + " " + Ens1[0].InnerText.Trim());

                            _obj.BuyLink = busyUrl;
                            updateContent(txtlogs, "Site: https://www.tickeri.com = > Function :" + _obj.Function + ", Date :" + _obj.DateTime);

                            _obj.Function = ReplaceChar(_obj.Function);
                            _obj.Enclosure = ReplaceChar(_obj.Enclosure);
                            //_obj.DateTime = _obj.DateTime.Replace("2017", "");
                            //_obj.DateTime = _obj.DateTime.Replace("2018", "");
                            //_obj.DateTime = _obj.DateTime.Replace("2019", "");
                            //_obj.DateTime = _obj.DateTime.Replace("2020", "");                           
                            //_obj.DateTime = _obj.DateTime.Replace("Jan", "January " + DateTime.Now.Year);
                            //_obj.DateTime = _obj.DateTime.Replace("Feb", "February " + DateTime.Now.Year + " ");                          
                            //_obj.DateTime = _obj.DateTime.Replace("Mar", "March " + DateTime.Now.Year);
                            //_obj.DateTime = _obj.DateTime.Replace("Apr", "April " + DateTime.Now.Year);                           
                            //_obj.DateTime = _obj.DateTime.Replace("Jun", "June " + DateTime.Now.Year);
                            //_obj.DateTime = _obj.DateTime.Replace("Jul", "July " + DateTime.Now.Year);
                            //_obj.DateTime = _obj.DateTime.Replace("Aug", "August " + DateTime.Now.Year);
                            //_obj.DateTime = _obj.DateTime.Replace("Sep", "September " + DateTime.Now.Year);   
                            //_obj.DateTime = _obj.DateTime.Replace("Oct", "October " + DateTime.Now.Year);
                            //_obj.DateTime = _obj.DateTime.Replace("Dec", "December " + DateTime.Now.Year);
                            _obj.DateTime = _obj.DateTime.Replace("-", "");       
                            _obj.DateTime = Convert.ToDateTime(_obj.DateTime).ToString();
                            _MusicEventList.Add(_obj);


                        }
                        catch (Exception ex)
                        {
                            continue;
                        }
                    }
                }
            }
            catch (Exception)
            {
            }
        }

        public void concertfix()
        {
            try
            {
                updateContent(txtlogs, "******Start Scraping :http://concertfix.com/");
                HtmlAgilityPack.HtmlDocument doc = web.Load("http://concertfix.com/concerts/all-cities");
                HtmlNodeCollection collection = doc.DocumentNode.SelectNodes("//div[@class='trip-list']/ul/li/a");
                if (collection != null)
                {
                    for (int i = 0; i < 100; i++)
                    {
                        try
                        {
                            string tdurl = "http://concertfix.com" + collection[i].Attributes["href"].Value;
                            HtmlAgilityPack.HtmlDocument doc2 = web.Load("http://www.jungle-search.com/search?cat=11055981&type=advanced&kw=nivea+cream&bn=&po1=0&po2=&pr1=1000&pr2=525555&ao=1&cr=5-&so=price-asc-rank");
                            HtmlNodeCollection Eventdate = doc2.DocumentNode.SelectNodes("//div[@class='date-events']");
                            HtmlNodeCollection Eventdetails = doc2.DocumentNode.SelectNodes("//div[@class='eventblock']");
                            for (int p = 0; p < Eventdate.Count(); p++)
                            {
                                try
                                {
                                    MusicEvent _obj = new MusicEvent();
                                    _obj.DateTime = Eventdate[p].InnerText.Replace(",", " ").Trim();

                                    HtmlNodeCollection collection2 = Eventdetails[p].SelectNodes(".//h4/a");
                                    _obj.Function = collection2[0].InnerText.Replace("\r\n", " ").Trim();

                                    collection2 = Eventdetails[p].SelectNodes(".//p");
                                    _obj.Enclosure = collection2[0].InnerText.Replace("Venue:", " ").Trim();
                                    _obj.Enclosure = _obj.Enclosure.Replace(", ", "");

                                    HtmlNodeCollection link = Eventdetails[p].SelectNodes(".//a[@class='btn btn-info']");
                                    string a = link[1].Attributes["href"].Value;
                                    _obj.BuyLink = "http://concertfix.com" + a;
                                    _obj.Website = "concertfix.com";

                                    _obj.Function = ReplaceChar(_obj.Function);
                                    _obj.Enclosure = ReplaceChar(_obj.Enclosure);
                                    _obj.DateTime = Convert.ToDateTime(ReplaceChar(_obj.DateTime)).ToString();
                                    updateContent(txtlogs, "Site: http://concertfix.com/ = > Function :" + _obj.Function + ", Date :" + _obj.DateTime);

                                    _MusicEventList.Add(_obj);

                                }
                                catch (Exception)
                                {
                                    continue;
                                }
                            }

                        }
                        catch (Exception)
                        {
                            continue;
                        }
                    }
                }
            }
            catch (Exception ex)
            {

            }
        }

        public void ticketmasterES()
        {
            try
            {
                updateContent(txtlogs, "******Start Scraping :http://www.ticketmaster.es");

                string jsonString = GetEventLists("ES");
                TicketMasterClass.RootObject _objEmbedded = JsonConvert.DeserializeObject<TicketMasterClass.RootObject>(jsonString);
                foreach (var item in _objEmbedded._embedded.events)
                {
                    try
                    {
                        MusicEvent _obj = new MusicEvent();
                        string FullAddress = item._embedded.venues[0].address.line1 + "," + item._embedded.venues[0].city.name + "," + item._embedded.venues[0].country.name + "," + item._embedded.venues[0].postalCode;
                        _obj.Enclosure = FullAddress;
                        _obj.DateTime = item.dates.start.localDate + " " + item.dates.start.localTime;
                        _obj.Function = item.name;
                        _obj.BuyLink = item.url;
                        _obj.Website = "ticketmaster.es";
                        if (item.dates.status.code == "onsale")
                        {
                            _obj.Function = ReplaceChar(_obj.Function);
                            _obj.Enclosure = ReplaceChar(_obj.Enclosure);
                            _obj.DateTime = Convert.ToDateTime(ReplaceChar(_obj.DateTime)).ToString();
                            _MusicEventList.Add(_obj);
                            updateContent(txtlogs, "Site:http://www.ticketmaster.es = > Function :" + _obj.Function + ", Date :" + _obj.DateTime);
                        }
                    }
                    catch (Exception)
                    {
                        continue;
                    }
                }

            }
            catch (Exception ex)
            {

            }
        }

        public void ticketmasterMX()
        {
            try
            {
                updateContent(txtlogs, "******Start Scraping :http://www.ticketmaster.com.mx");

                string jsonString = GetEventLists("MX");
                TicketMasterClass.RootObject _objEmbedded = JsonConvert.DeserializeObject<TicketMasterClass.RootObject>(jsonString);
                foreach (var item in _objEmbedded._embedded.events)
                {
                    try
                    {
                        MusicEvent _obj = new MusicEvent();
                        string FullAddress = item._embedded.venues[0].address.line1 + "," + item._embedded.venues[0].city.name + "," + item._embedded.venues[0].country.name + "," + item._embedded.venues[0].postalCode;
                        _obj.Enclosure = FullAddress;
                        _obj.DateTime = item.dates.start.localDate + " " + item.dates.start.localTime;
                        _obj.Function = item.name;
                        _obj.BuyLink = item.url;
                        _obj.Website = "ticketmaster.com.mx";
                        if (item.dates.status.code == "onsale")
                        {
                            _obj.Function = ReplaceChar(_obj.Function);
                            _obj.Enclosure = ReplaceChar(_obj.Enclosure);
                            _obj.DateTime = ReplaceChar(_obj.DateTime);
                            _obj.DateTime = Convert.ToDateTime(_obj.DateTime).ToString();
                            _MusicEventList.Add(_obj);
                            updateContent(txtlogs, "Site:http://www.ticketmaster.com.mx = > Function :" + _obj.Function + ", Date :" + _obj.DateTime);
                        }
                    }
                    catch (Exception)
                    {
                        continue;
                    }
                }

            }
            catch (Exception ex)
            {

            }
        }
        public string GetEventLists(string country)
        {
            string startDateTime = DateTime.UtcNow.ToString("yyyy-MM-dd") + "T00:00:00Z"; ;
            string endDateTime = DateTime.UtcNow.AddMonths(6).ToString("yyyy-MM-dd") + "T00:00:00Z";
            string size = "200";
            string responseData = string.Empty;
            string URL = "https://app.ticketmaster.com/discovery/v2/events.json?classificationName=music&countryCode=" + country + "&apikey=8HaPIUrURinPV518j2kYBnIXBCr2irdG&startDateTime=" + startDateTime + "&endDateTime=" + endDateTime + "&size=" + size;
            CookieContainer cookies = new CookieContainer();
            HttpWebRequest webRequest = WebRequest.Create(URL) as HttpWebRequest;
            webRequest.CookieContainer = cookies;
            StreamReader responseReader = new StreamReader(webRequest.GetResponse().GetResponseStream());
            HttpWebResponse response = (HttpWebResponse)webRequest.GetResponse();
            response.Cookies = webRequest.CookieContainer.GetCookies(webRequest.RequestUri);
            responseData = responseReader.ReadToEnd();
            responseReader.Close();
            webRequest.KeepAlive = false;


            return responseData;

        }

        public void ticketek()
        {
            try
            {
                updateContent(txtlogs, "******Start Scraping :http://www.ticketek.com.ar/musica");
                HtmlAgilityPack.HtmlDocument doc = web.Load("http://www.ticketek.com.ar/musica");
                HtmlNodeCollection collection = doc.DocumentNode.SelectNodes("//div[@class='artists-list-item-image ']/a");
                if (collection != null)
                {
                    for (int i = 0; i < collection.Count(); i++)
                    {
                        try
                        {
                            string tdurl = "http://www.ticketek.com.ar" + collection[i].Attributes["href"].Value;
                            HtmlAgilityPack.HtmlDocument doc2 = web.Load(tdurl);

                            MusicEvent _obj = new MusicEvent();
                            HtmlNodeCollection collection2 = doc2.DocumentNode.SelectNodes("//h2[@class='pane-title']");
                            _obj.Function = collection2[4].InnerText.Replace("\r\n", " ").Trim();

                            collection2 = doc2.DocumentNode.SelectNodes(".//div[@class='next-date']");
                            string DateTime = collection2[0].InnerHtml.Replace("Next date", " ");

                            int sta = DateTime.IndexOf("</div>\n") + 8;
                            int end = DateTime.IndexOf("<a href=");
                            string test = DateTime.Substring(sta, end - sta);
                            _obj.DateTime = test.Trim();
                            HtmlNodeCollection link = doc2.DocumentNode.SelectNodes(".//a[@class='comprar buy']");
                            string a = link[0].Attributes["href"].Value;
                            _obj.BuyLink = a;
                            _obj.Website = "ticketek.com.ar/";

                            HtmlNodeCollection titles = doc2.DocumentNode.SelectNodes(".//div[@class='titles']");
                            HtmlNodeCollection state = doc2.DocumentNode.SelectNodes(".//div[@class='state']");
                            HtmlNodeCollection city = doc2.DocumentNode.SelectNodes(".//div[@class='city']");
                            HtmlNodeCollection address = doc2.DocumentNode.SelectNodes(".//div[@class='address']");
                            _obj.Enclosure = address[0].InnerText.Trim() + " " + city[0].InnerText.Trim() + " " + state[0].InnerText.Trim() + ", " + titles[0].InnerText.Trim();

                            _obj.Function = ReplaceChar(_obj.Function);
                            _obj.Enclosure = ReplaceChar(_obj.Enclosure);
                            _obj.DateTime = _obj.DateTime.Replace(" de ", " ");
                            _obj.DateTime = _obj.DateTime.Replace(" DE ", " ");
                            _obj.DateTime = Convert.ToDateTime(ReplaceChar(_obj.DateTime).Trim().Replace("Hs", ":00")).ToString();
                            updateContent(txtlogs, "Site: http://www.ticketek.com.ar = > Function :" + _obj.Function + ", Date :" + _obj.DateTime);

                            _MusicEventList.Add(_obj);
                        }
                        catch (Exception)
                        {
                            continue;
                        }
                    }
                }
            }
            catch (Exception ex)
            {

            }
        }

        public void Tcpr()
        {
            try
            {
                updateContent(txtlogs, "******Start Scraping : https://tcpr.com/categories/concerts/2");
                HtmlAgilityPack.HtmlDocument doc = web.Load("https://tcpr.com/categories/concerts/2");
                HtmlNodeCollection collection = doc.DocumentNode.SelectNodes("//div[@class='dataItem item_background item_data_background ']");
                if (collection != null)
                {
                    for (int i = 0; i < collection.Count(); i++)
                    {
                        try
                        {
                            MusicEvent _obj = new MusicEvent();
                            HtmlNodeCollection td = collection[i].SelectNodes(".//span[@class='small_text_d name']");
                            _obj.Website = "tcpr.com/";
                            _obj.Function = td[0].InnerText.Replace("\r\n", " ").Trim();
                            td = collection[i].SelectNodes(".//div[@class='date']");
                            _obj.DateTime = td[0].InnerHtml.Replace("<div>", " ");
                            _obj.DateTime = _obj.DateTime.Replace("</div>", " ").Trim();
                            _obj.DateTime = _obj.DateTime.Replace("<span>", " ").Trim();
                            _obj.DateTime = _obj.DateTime.Replace("</span>", " ").Trim();

                            td = collection[i].SelectNodes(".//span[@class='rangetitle']");
                            _obj.Enclosure = td[0].InnerText.Replace("\r\n", " ").Trim();

                            HtmlNodeCollection link = collection[i].SelectNodes(".//a[@id='btnAddToBasket']");
                            string a = link[0].Attributes["href"].Value;
                            _obj.BuyLink = "https://tcpr.com/" + a;
                            updateContent(txtlogs, "Site: http://tcpr.com/ = > Function :" + _obj.Function + ", Date :" + _obj.DateTime);
                            _obj.Function = ReplaceChar(_obj.Function);
                            _obj.Enclosure = ReplaceChar(_obj.Enclosure);
                            _obj.DateTime = ReplaceChar(_obj.DateTime);
                            _MusicEventList.Add(_obj);
                        }
                        catch (Exception)
                        {
                            continue;
                        }
                    }
                }
            }
            catch (Exception ex)
            {

            }
        }
        public void Atrapalo()
        {
            try
            {
                updateContent(txtlogs, "******Start Scraping : https://www.atrapalo.com/");
                HtmlAgilityPack.HtmlDocument doc = web.Load("https://www.atrapalo.com/entradas/musica/");
                HtmlNodeCollection collection = doc.DocumentNode.SelectNodes("//div[@id='resultados_espectaculos']/ul/li");
                if (collection != null)
                {
                    for (int i = 0; i < collection.Count(); i++)
                    {
                        try
                        {
                            MusicEvent _obj = new MusicEvent();
                            HtmlNodeCollection td = collection[i].SelectNodes(".//a[@class='title  summary  GATrackEvent_nombre_producto']");
                            _obj.Website = "atrapalo.com/";
                            _obj.Function = td[0].InnerText.Replace("\r\n", " ").Trim();
                            td = collection[i].SelectNodes(".//span[@class=' dtstart ']/span");

                            _obj.DateTime = td[0].Attributes["title"].Value.Replace("<div>", " ");

                            td = collection[i].SelectNodes(".//span[@class='type large-loc']");
                            _obj.Enclosure = td[0].InnerText.Replace("\n", " ").Trim();

                            HtmlNodeCollection link = collection[i].SelectNodes(".//div[@class='price-btn clear']/a");
                            string a = link[0].Attributes["href"].Value;
                            _obj.BuyLink = "https://www.atrapalo.com" + a;
                            updateContent(txtlogs, "Site: http://atrapalo.com/ = > Function :" + _obj.Function + ", Date :" + _obj.DateTime);
                            _obj.Function = ReplaceChar(_obj.Function);
                            _obj.Enclosure = ReplaceChar(_obj.Enclosure);
                            _obj.DateTime = ReplaceChar(_obj.DateTime);
                            _MusicEventList.Add(_obj);
                        }
                        catch (Exception)
                        {
                            continue;
                        }
                    }
                }
            }
            catch (Exception ex)
            {

            }
        }
        public void Ticketmundo()
        {
            try
            {
                updateContent(txtlogs, "******Start Scraping : http://www.ticketmundo.com/");
                HtmlAgilityPack.HtmlDocument doc = web.Load("http://venezuela.ticketmundo.com/Categoria/Lista/Musica/1");
                HtmlNodeCollection collection = doc.DocumentNode.SelectNodes("//div[@id='categoryleft']/div");
                if (collection != null)
                {
                    for (int i = 0; i < collection.Count(); i++)
                    {
                        try
                        {
                            MusicEvent _obj = new MusicEvent();
                            HtmlNodeCollection td = collection[i].SelectNodes(".//span[@class='categoryleftname']");
                            _obj.Website = "ticketmundo.com/";
                            _obj.Function = td[0].InnerText.Replace("\r\n", " ").Trim();
                            td = collection[i].SelectNodes(".//div[@class='col-xs-6 hidden-xs col-sm-6 col-md-2 col-md-offset-1 vcenter-category categoryleftspan']");

                            _obj.DateTime = td[0].InnerText.Trim() + " " + DateTime.Now.Year;

                            td = collection[i].SelectNodes(".//div[@class='col-xs-6 hidden-xs col-sm-6 col-md-1 vcenter-category categoryleftspan']");
                            _obj.Enclosure = td[0].InnerText.Replace("\n", " ").Trim();

                            HtmlNodeCollection link = collection[i].SelectNodes(".//a");
                            string a = link[0].Attributes["href"].Value;
                            _obj.BuyLink = "http://venezuela.ticketmundo.com" + a;
                            updateContent(txtlogs, "Site: www.ticketmundo.com = > Function :" + _obj.Function + ", Date :" + _obj.DateTime);
                            _obj.Function = ReplaceChar(_obj.Function);
                            _obj.Enclosure = ReplaceChar(_obj.Enclosure);
                            _obj.DateTime = ReplaceChar(_obj.DateTime);
                            _obj.DateTime = Convert.ToDateTime(_obj.DateTime).ToString();
                            _MusicEventList.Add(_obj);
                        }
                        catch (Exception)
                        {
                            continue;
                        }
                    }
                }
            }
            catch (Exception ex)
            {

            }
        }
        public void Ticketpop()
        {
            try
            {
                HtmlAgilityPack.HtmlDocument doc1 = web.Load("http://www.ticketpop.com/en/events/category/concerts");
                HtmlNodeCollection Page = doc1.DocumentNode.SelectNodes("//div[@class='info_wrapper']");
                for (int i = 0; i < Page.Count; i++)
                {
                    try
                    {

                        HtmlNodeCollection H3 = Page[i].SelectNodes(".//h3/a");
                        string busyUrl = H3[0].Attributes["href"].Value;
                        doc1 = web.Load(busyUrl);
                        HtmlNodeCollection Datetimetotal = doc1.DocumentNode.SelectNodes("//div[@class='m-eventDetailShowings']/ul/li");
                        for (int j = 0; j < Datetimetotal.Count; j++)
                        {
                            MusicEvent _obj = new MusicEvent();
                            _obj.Website = "ticketpop.com/";
                            _obj.DateTime = Datetimetotal[j].InnerText.Trim().Replace("Buy Tickets", "");
                            _obj.DateTime = _obj.DateTime.Replace("\n", "");
                            _obj.DateTime = _obj.DateTime.Replace("\t.st0{opacity:0.98;}", "");
                            HtmlNodeCollection datafun = doc1.DocumentNode.SelectNodes("//ul[@class='m-eventDetailList']/li");
                            HtmlNodeCollection fuction = doc1.DocumentNode.SelectNodes("//div[@class='m-eventDetail__heading']");
                            _obj.Function = Replace(fuction[0].InnerText).Replace("\"", "");
                            //HtmlNodeCollection date = datafun[0].SelectNodes(".//span");
                            //HtmlNodeCollection time = datafun[1].SelectNodes(".//span");                           
                            //if (time[0].InnerText.Trim().Contains("PM") || time[0].InnerText.Trim().Contains("AM"))
                            //    _obj.DateTime = Replace(date[0].InnerText.Trim() + " " + time[0].InnerText.Trim());
                            //else
                            //{
                            //    string[] split = date[0].InnerText.Trim().Split('-');
                            //    if (split.Count() > 1)
                            //    {                                                               
                            //        _obj.DateTime = DateTime.UtcNow.ToShortDateString(); ;
                            //    }
                            //}
                            HtmlNodeCollection enc = datafun[2].SelectNodes(".//span");
                            _obj.Enclosure = Replace(enc[0].InnerText);
                            HtmlNodeCollection url = doc1.DocumentNode.SelectNodes(".//a[@class='tickets onsalenow ']");
                            _obj.BuyLink = busyUrl;
                            _obj.Function = ReplaceChar(_obj.Function);
                            _obj.Enclosure = ReplaceChar(_obj.Enclosure);
                            _obj.DateTime = Convert.ToDateTime(_obj.DateTime).ToString();
                            _MusicEventList.Add(_obj);
                            updateContent(txtlogs, "Site: http://ticketpop.com/ = > Function :" + _obj.Function + ", Date :" + _obj.DateTime); 
                        }
                    }
                    catch (Exception ex)
                    {
                        continue;
                    }
                }
            }
            catch (Exception)
            {
            }
        }

        public void Eventos()
        {
            try
            {
                updateContent(txtlogs, "******Start Scraping : http://eventos.tuboleta.com.do/");
                HtmlAgilityPack.HtmlDocument doc = web.Load("http://eventos.tuboleta.com.do/");
                HtmlNodeCollection collection = doc.DocumentNode.SelectNodes("//table[@id='plTable']/tr[@class='plRow']");
                if (collection != null)
                {
                    for (int i = 0; i < collection.Count(); i++)
                    {
                        try
                        {
                            MusicEvent _obj = new MusicEvent();
                            HtmlNodeCollection td = collection[i].SelectNodes("td");
                            _obj.Website = "eventos.tuboleta.com";
                            _obj.Function = td[2].InnerText.Replace("\r\n", " ").Trim();
                            _obj.DateTime = td[3].InnerText.Replace("\r\n", " ").Trim();
                            _obj.Enclosure = td[4].InnerText.Replace("\r\n", " ").Trim();
                            HtmlNodeCollection link = td[5].SelectNodes("a");
                            string a = link[0].Attributes["href"].Value;
                            _obj.BuyLink = "http://eventos.tuboleta.com.do" + a;
                            updateContent(txtlogs, "Site: eventos.tuboleta.com.do = > Function :" + _obj.Function + ", Date :" + _obj.DateTime);
                            _obj.Function = ReplaceChar(_obj.Function);
                            _obj.Enclosure = ReplaceChar(_obj.Enclosure);
                            _obj.DateTime = ReplaceChar(_obj.DateTime);
                            _MusicEventList.Add(_obj);
                        }
                        catch (Exception)
                        {
                            continue;
                        }
                    }
                }

            }
            catch (Exception ex)
            {

            }
        }
        public void Uepatickets()
        {
            try
            {
                updateContent(txtlogs, "******Start Scraping : http://uepatickets.com/");
                HtmlAgilityPack.HtmlDocument doc = web.Load("https://uepatickets.com/default.aspx?category_name=Conciertos");
                HtmlNodeCollection collection = doc.DocumentNode.SelectNodes("//table[@id='sample_1']/tbody/tr");
                if (collection != null)
                {
                    for (int i = 0; i < collection.Count(); i++)
                    {
                        try
                        {
                            MusicEvent _obj = new MusicEvent();
                            HtmlNodeCollection td = collection[i].SelectNodes(".//div[@class='item-name']");
                            _obj.Website = "uepatickets.com/";
                            _obj.Function = td[0].InnerText.Replace("\r\n", " ").Trim();
                            td = collection[i].SelectNodes(".//div[@class='item-start-date']");
                            _obj.DateTime = td[0].InnerText.Replace("\r\n", " ").Trim();
                            _obj.DateTime = _obj.DateTime.Replace("  ", "").Trim();
                            _obj.DateTime = _obj.DateTime.Replace("&nbsp;", "").Trim();
                            _obj.DateTime = _obj.DateTime.Replace("Fecha:", "").Trim();
                            _obj.DateTime = _obj.DateTime.Replace("Dic. ", "Dec ").Trim();
                            _obj.DateTime = _obj.DateTime.Substring(5, _obj.DateTime.Length - 5).ToString().Replace(".", "");
                            _obj.DateTime = Convert.ToDateTime(_obj.DateTime).ToString();
                            td = collection[i].SelectNodes(".//div[@class='item-venue']");
                            _obj.Enclosure = td[0].InnerText.Replace("\r\n", " ").Trim();
                            td = collection[i].SelectNodes(".//div[@class='item-link result-box-item-details last-column last-column unknown']");
                            HtmlNodeCollection link = td[0].SelectNodes("a");
                            string a = link[0].Attributes["href"].Value;
                            _obj.BuyLink = "http://uepatickets.com/" + a;
                            _obj.Function = ReplaceChar(_obj.Function);
                            _obj.Enclosure = ReplaceChar(_obj.Enclosure);
                            _obj.DateTime = ReplaceChar(_obj.DateTime);
                            updateContent(txtlogs, "Site: http://uepatickets.com/ = > Function :" + _obj.Function + ", Date :" + _obj.DateTime);

                            _MusicEventList.Add(_obj);
                        }
                        catch (Exception)
                        {
                            continue;
                        }
                    }
                }
            }
            catch (Exception ex)
            {

            }
        }
        public void Ticketexpress()
        {
            try
            {
                updateContent(txtlogs, "******Start Scraping : http://www.ticketexpress.com.do/");

                HtmlAgilityPack.HtmlDocument doc = web.Load("http://www.ticketexpress.com.do/ShowEventByCategory.aspx?ID=62");
                HtmlNodeCollection collection = doc.DocumentNode.SelectNodes("//div[@id='events']/dl");
                if (collection != null)
                {
                    for (int i = 0; i < collection.Count(); i++)
                    {

                        try
                        {
                            MusicEvent _obj = new MusicEvent();
                            HtmlNodeCollection td = collection[i].SelectNodes("dd/h2/a");
                            _obj.Website = "ticketexpress.com.do/";
                            _obj.Function = td[0].InnerText.Replace("\r\n", " ").Trim();
                            td = collection[i].SelectNodes("dd/h3");
                            _obj.DateTime = td[0].InnerText.Replace("\r\n", " ").Trim();
                            _obj.DateTime = _obj.DateTime.Replace("\t", "").Trim();
                            _obj.DateTime = _obj.DateTime.Replace("&nbsp;", "").Trim();
                            string[] split = _obj.DateTime.Split('-');
                            if (split.Count() > 1)
                            {
                                DateTime dt = DateTime.ParseExact(split[0].Trim(), "dd/MM/yyyy", System.Globalization.CultureInfo.InvariantCulture);
                                _obj.DateTime = dt.ToString();
                            }
                            td = collection[i].SelectNodes("dd/p");
                            _obj.Enclosure = td[0].InnerText.Replace("\r\n", " ").Trim();
                            _obj.Enclosure = _obj.Enclosure.Replace("\t", " ").Trim();
                            HtmlNodeCollection link = collection[i].SelectNodes("dd/h2/a");
                            string a = link[0].Attributes["href"].Value;
                            _obj.BuyLink = "http://www.ticketexpress.com.do/" + a;
                            _obj.Function = ReplaceChar(_obj.Function);
                            _obj.Enclosure = ReplaceChar(_obj.Enclosure);
                            _obj.DateTime = ReplaceChar(_obj.DateTime);
                            updateContent(txtlogs, "Site: www.ticketexpress.com.do/ = > Function :" + _obj.Function + ", Date :" + _obj.DateTime);

                            _MusicEventList.Add(_obj);
                        }
                        catch (Exception)
                        {
                            continue;
                        }

                    }
                }
            }
            catch (Exception ex)
            {

            }
        }
        public void Quehacerhoy()
        {
            try
            {
                updateContent(txtlogs, "******Start Scraping : http://www.quehacerhoy.com.do/");

                HtmlAgilityPack.HtmlDocument doc = web.Load("http://www.quehacerhoy.com.do/que-hacer-hoy/m%C3%BAsica");
                HtmlNodeCollection collection = doc.DocumentNode.SelectNodes("//div[@id='detalle-teaser']");
                if (collection != null)
                {
                    for (int i = 0; i < collection.Count(); i++)
                    {
                        try
                        {
                            MusicEvent _obj = new MusicEvent();
                            HtmlNodeCollection h3 = collection[i].SelectNodes("h3");
                            _obj.Website = "quehacerhoy.com.do/";
                            _obj.Function = h3[0].InnerText.Replace("\r\n", " ").Trim();
                            HtmlNodeCollection td = collection[i].SelectNodes("div[@class='field-item']");
                            // td = collection[0].SelectNodes("dd/h3");
                            _obj.DateTime = td[0].InnerText.Replace("\r\n", " ").Trim();
                            _obj.DateTime = _obj.DateTime.Replace("(Todo el día)", "").Trim();
                            _obj.DateTime = _obj.DateTime.Replace("de ", "").Trim();
                            _obj.Enclosure = td[1].InnerText.Replace("\r\n", " ").Trim();
                            _obj.Enclosure = _obj.Enclosure.Replace("\t", " ").Trim();
                            HtmlNodeCollection link = collection[i].SelectNodes("div[@class='node-readmore']/a");
                            string a = link[0].Attributes["href"].Value;
                            _obj.BuyLink = "http://www.quehacerhoy.com.do" + a;
                            updateContent(txtlogs, "Site: www.quehacerhoy.com.do/ = > Function :" + _obj.Function + ", Date :" + _obj.DateTime);
                            _obj.Function = ReplaceChar(_obj.Function);
                            _obj.Enclosure = ReplaceChar(_obj.Enclosure);
                            _obj.DateTime = ReplaceChar(_obj.DateTime.Replace(DateTime.Now.Year.ToString(), "")).Replace("-", "");
                            _obj.DateTime = Convert.ToDateTime(_obj.DateTime.Replace(",", "")).ToString();
                            _MusicEventList.Add(_obj);
                        }
                        catch (Exception)
                        {
                            continue;
                        }
                    }
                }
            }
            catch (Exception ex)
            {

            }
        }
        public void Puntoticket()
        {
            try
            {
                updateContent(txtlogs, "******Start Scraping : http://www.puntoticket.com/");
                ServicePointManager.SecurityProtocol = SecurityProtocolType.Ssl3 | SecurityProtocolType.Tls | SecurityProtocolType.Tls11 | SecurityProtocolType.Tls12;
                HtmlAgilityPack.HtmlDocument doc1 = web.Load("http://www.puntoticket.com/musica");
                HtmlNodeCollection Page = doc1.DocumentNode.SelectNodes("//div[@class='row articles']/article");
                for (int i = 1; i < Page.Count; i++)
                {
                    try
                    {
                        MusicEvent _obj = new MusicEvent();
                        _obj.Website = "puntoticket.com/";
                        HtmlNodeCollection Function = Page[i].SelectNodes(".//h3");
                        _obj.Function = Function[0].InnerText.Trim();
                        HtmlNodeCollection DateTime = Page[i].SelectNodes(".//p[@class='fecha']");
                        _obj.DateTime = DateTime[0].InnerText.Trim();
                        HtmlNodeCollection Enclosure = Page[i].SelectNodes(".//p[@class='descripcion visible-lg']");
                        _obj.Enclosure = Enclosure[0].InnerText.Trim();
                        HtmlNodeCollection url = Page[i].SelectNodes(".//a");
                        string urlstring = url[0].Attributes["href"].Value.Trim();
                        //  doc1 = web.Load(urlstring);
                        //  HtmlNodeCollection  PageURL = doc1.DocumentNode.SelectNodes("//select[@id='discounts-select']");
                        // string tbuyurl = PageURL[0].Attributes["href"].Value;
                        //td = td[3].SelectNodes("a");
                        //string tbuyurl = td[0].Attributes["href"].Value;
                        _obj.BuyLink = urlstring;
                        _obj.Function = ReplaceChar(_obj.Function);
                        _obj.Enclosure = ReplaceChar(_obj.Enclosure);
                        _obj.DateTime = ReplaceChar(_obj.DateTime);
                        updateContent(txtlogs, "Site: www.puntoticket.com/ = > Function :" + _obj.Function + ", Date :" + _obj.DateTime);

                        _MusicEventList.Add(_obj);
                    }
                    catch (Exception)
                    {
                        continue;
                    }
                }
            }
            catch (Exception)
            {
            }
        }
        public void Tuboleta()
        {
            try
            {
                updateContent(txtlogs, "******Start Scraping : http://vive.tuboleta.com/");
                int inc = 0;
                for (int m = 0; m < 5; m++)
                {
                    inc++;
                    HtmlAgilityPack.HtmlDocument doc1 = web.Load("http://vive.tuboleta.com/shows/genre.aspx?c=1004&page=" + inc);
                    HtmlNodeCollection Page = doc1.DocumentNode.SelectNodes("//div[@class='searchResults clearfix']/div");
                    for (int i = 1; i < Page.Count; i++)
                    {
                        try
                        {
                            MusicEvent _obj = new MusicEvent();
                            _obj.Website = "vive.tuboleta.com/";
                            HtmlNode contentEvent = Page[i].SelectSingleNode(".//div[@class='contentEvent']");
                            if (contentEvent != null)
                            {
                                _obj.Function = Replace(contentEvent.InnerText.ToString().Trim());
                                _obj.Function = ReplaceChar(_obj.Function);
                            }
                            HtmlNode contentLocation = Page[i].SelectSingleNode(".//div[@class='contentLocation']");
                            if (contentLocation != null)
                            {
                                _obj.Enclosure = Replace(contentLocation.InnerText.ToString().Trim());
                                _obj.Enclosure = ReplaceChar(_obj.Enclosure);
                            }
                            HtmlNode contentDate = Page[i].SelectSingleNode(".//div[@class='contentDate']");
                            if (contentDate != null)
                            {
                                if (contentDate.InnerText.ToString().Trim().Contains("hasta"))
                                {
                                    string[] split = contentDate.InnerHtml.ToString().Trim().Split('<');
                                    _obj.DateTime = split[0];
                                }
                                else
                                {
                                    _obj.DateTime = Replace(contentDate.InnerText.ToString().Trim());
                                }
                                _obj.DateTime = _obj.DateTime.Replace("mar. ", "");
                                _obj.DateTime = _obj.DateTime.Replace("hastamié. 20 dic. 2017", "");
                                _obj.DateTime = _obj.DateTime.Replace(" dic. ", " December ");
                                _obj.DateTime = _obj.DateTime.Replace(" ene. ", " January ");
                                _obj.DateTime = ReplaceChar(_obj.DateTime);
                                _obj.DateTime = Convert.ToDateTime(_obj.DateTime.Replace(".", "").Trim()).ToString();
                            }
                            HtmlNode resultBuyNow = Page[i].SelectSingleNode(".//div[@class='resultBuyNow']/a");
                            if (resultBuyNow != null)
                            {
                                string tbuyurl = resultBuyNow.Attributes["href"].Value;
                                _obj.BuyLink = "http://vive.tuboleta.com" + tbuyurl;
                            }


                            if (contentDate != null)
                            {
                                updateContent(txtlogs, "Site: http://vive.tuboleta.com = > Function :" + _obj.Function + ", Date :" + _obj.DateTime);
                                _MusicEventList.Add(_obj);
                            }
                        }
                        catch (Exception)
                        {
                            continue;
                        }
                    }
                }
            }
            catch (Exception)
            {
            }
        }
        public void Eticket()
        {
            try
            {
                updateContent(txtlogs, "******Start Scraping : http://www.eticket.cr/");
                HtmlAgilityPack.HtmlDocument doc1 = web.Load("http://www.eticket.cr/categorias.aspx?q=8s6QS9jkrTbnykVpYsjazA==");
                HtmlNodeCollection Page = doc1.DocumentNode.SelectNodes("//table[@id='contenido']/tr/td/table/tr");
                for (int i = 1; i < Page.Count; i++)
                {
                    try
                    {
                        HtmlNodeCollection td = Page[i].SelectNodes("td/table/tr/td");
                        if (td != null)
                        {
                            MusicEvent _obj = new MusicEvent();
                            _obj.Website = "eticket.cr/";
                            _obj.Function = Replace(td[1].InnerText.ToString().Trim());
                            _obj.Enclosure = Replace(td[2].InnerText.ToString().Trim());

                            _obj.DateTime = Replace(td[3].InnerText.ToString().Replace("Compra tus boletos", "").Trim());
                            _obj.DateTime = _obj.DateTime.Replace("  ", " ");
                            _obj.DateTime = _obj.DateTime + ":00";
                            DateTime dt = DateTime.ParseExact(_obj.DateTime.Trim(), "dd/MM/yyyy HH:mm:ss", System.Globalization.CultureInfo.InvariantCulture);
                            _obj.DateTime = dt.ToString();
                            td = td[3].SelectNodes("div");
                            td = td[1].SelectNodes("a");
                            string tbuyurl = td[0].Attributes["href"].Value;
                            _obj.BuyLink = "http://www.eticket.cr/" + tbuyurl;
                            _obj.Function = ReplaceChar(_obj.Function);
                            _obj.Enclosure = ReplaceChar(_obj.Enclosure);
                            _obj.DateTime = ReplaceChar(_obj.DateTime);
                            updateContent(txtlogs, "Site: http://www.eticket.cr/ = > Function :" + _obj.Function + ", Date :" + _obj.DateTime);

                            _MusicEventList.Add(_obj);
                        }
                    }
                    catch (Exception)
                    {
                        continue;
                    }
                }
            }
            catch (Exception)
            {

            }
        }
        public void Ticketshow()
        {
            try
            {
                updateContent(txtlogs, "******Start Scraping : http://www.ticketshow.com.ec/");

                HtmlAgilityPack.HtmlDocument doc1 = web.Load("https://www.ticketshow.com.ec/pages/conciertos.aspx");
                HtmlNodeCollection Page = doc1.DocumentNode.SelectNodes("//div[@class='mosaic-backdrop']/a");
                for (int i = 0; i < Page.Count; i++)
                {
                    try
                    {
                        string busyUrl = "https://www.ticketshow.com.ec/pages/" + Page[i].Attributes["href"].Value;
                        doc1 = web.Load(busyUrl);
                        HtmlNodeCollection datafun = doc1.DocumentNode.SelectNodes("//tr/td[@class='titulo_evento']");
                        HtmlNodeCollection datadate = doc1.DocumentNode.SelectNodes("//tr/td[@class='texto_datos_superior_evento']");
                        MusicEvent _obj = new MusicEvent();
                        _obj.Website = "ticketshow.com.ec/";
                        _obj.Function = datafun[0].InnerText;
                        if (datadate[5].InnerText.Contains(":00"))
                            _obj.DateTime = datadate[1].InnerText.Replace("de ", "") + " " + datadate[5].InnerText;
                        else
                            _obj.DateTime = datadate[1].InnerText.Replace("de ", "");
                        _obj.DateTime = _obj.DateTime.Replace("TEATRO CENTRO DE ARTE - SALA MULTIARTE", "");
                        _obj.DateTime = Convert.ToDateTime(_obj.DateTime).ToString();
                        _obj.Enclosure = datadate[3].InnerText;
                        _obj.BuyLink = busyUrl;
                        updateContent(txtlogs, "Site: http://www.ticketshow.com.ec/ = > Function :" + _obj.Function + ", Date :" + _obj.DateTime);
                        _obj.Function = ReplaceChar(_obj.Function);
                        _obj.Enclosure = ReplaceChar(_obj.Enclosure);
                        _obj.DateTime = ReplaceChar(_obj.DateTime);
                        _MusicEventList.Add(_obj);
                    }
                    catch (Exception)
                    {
                        continue;
                    }
                }
            }
            catch (Exception)
            {
            }
        }
        public void Stubhub()
        {
            try
            {
                updateContent(txtlogs, "******Start Scraping : http://www.stubhub.com.mx/");
                HtmlAgilityPack.HtmlDocument doc1 = web.Load("http://www.stubhub.com.mx/boletos-artistas/ca78");
                HtmlNodeCollection Page = doc1.DocumentNode.SelectNodes("//ul[@class='categoriesList striped']/li/div/a");
                for (int i = 0; i < Page.Count; i++)
                {
                    try
                    {
                        string busyUrl = Page[i].Attributes["href"].Value;
                        doc1 = web.Load(busyUrl);
                        HtmlNodeCollection datafun = doc1.DocumentNode.SelectNodes("//table[@class='events-list striped']/tbody/tr");
                        for (int j = 0; j < datafun.Count; j++)
                        {
                            try
                            {
                                HtmlNodeCollection td = datafun[j].SelectNodes(".//td");
                                MusicEvent _obj = new MusicEvent();
                                _obj.Website = "stubhub.com/";
                                HtmlNodeCollection datadate = td[0].SelectNodes(".//a");
                                _obj.Function = Replace(datadate[0].InnerText);
                                _obj.DateTime = Replace(td[1].InnerText);
                                HtmlNodeCollection dataLoc = td[0].SelectNodes(".//div[@itemprop='location']");
                                _obj.Enclosure = Replace(dataLoc[0].InnerText);
                                HtmlNodeCollection a = datafun[3].SelectNodes(".//a");
                                _obj.BuyLink = a[0].Attributes["href"].Value;
                                updateContent(txtlogs, "Site: http://www.stubhub.com.mx = > Function :" + _obj.Function + ", Date :" + _obj.DateTime);
                                _obj.Function = ReplaceChar(_obj.Function);
                                _obj.Enclosure = ReplaceChar(_obj.Enclosure);
                                _obj.DateTime = ReplaceChar(_obj.DateTime).Trim();
                                _obj.DateTime = _obj.DateTime.Replace("        ", " ");
                                _obj.DateTime = Convert.ToDateTime(_obj.DateTime).ToString();

                                _MusicEventList.Add(_obj);
                            }
                            catch (Exception)
                            {
                                continue;
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        continue;
                    }
                }
            }
            catch (Exception)
            {
            }
        }
        public void Ticketea()
        {
            try
            {
                updateContent(txtlogs, "******Start Scraping : http://www.ticketea.com.py/");

                HtmlAgilityPack.HtmlDocument doc1 = web.Load("http://www.ticketea.com.py/categoria.php?categoria=13");
                HtmlNodeCollection Page = doc1.DocumentNode.SelectNodes("//figcaption/span/div[@class='medium oval primary btn']/a");
                for (int i = 0; i < Page.Count; i++)
                {
                    try
                    {
                        string busyUrl = Page[i].Attributes["href"].Value;
                        doc1 = web.Load(busyUrl);
                        HtmlNodeCollection datafun = doc1.DocumentNode.SelectNodes("//figcaption/h4");
                        MusicEvent _obj = new MusicEvent();
                        _obj.Website = "ticketea.com/";
                        _obj.Function = Replace(datafun[1].InnerText);
                        _obj.DateTime = Replace(datafun[0].InnerText);
                        _obj.Enclosure = Replace(datafun[2].InnerText);
                        _obj.BuyLink = busyUrl;
                        updateContent(txtlogs, "Site: http://www.ticketea.com.py = > Function :" + _obj.Function + ", Date :" + _obj.DateTime);
                        _obj.Function = ReplaceChar(_obj.Function);
                        _obj.Enclosure = ReplaceChar(_obj.Enclosure);
                        _obj.DateTime = ReplaceChar(_obj.DateTime.Replace(DateTime.Now.Year.ToString(), ""));
                        _obj.DateTime = _obj.DateTime.Replace(" hs", ":00");
                        _obj.DateTime = _obj.DateTime.Replace("  - ", " ");
                        _obj.DateTime = _obj.DateTime.Replace("de", "").Trim();
                        _obj.DateTime = Convert.ToDateTime(_obj.DateTime).ToString();
                        _MusicEventList.Add(_obj);
                    }
                    catch (Exception ex)
                    {
                        continue;
                    }
                }
            }
            catch (Exception)
            {
            }
        }

        public void Livenation()
        {
            try
            {
                updateContent(txtlogs, "******Start Scraping : http://www.livenation.es/");
                for (int i = 1; i < 4; i++)
                {
                    HtmlAgilityPack.HtmlDocument doc1 = web.Load("http://www.livenation.es/event/allevents?page=" + i);
                    HtmlNodeCollection Page = doc1.DocumentNode.SelectNodes("//li[@class='artistticket ']");
                    for (int j = 0; j < Page.Count; j++)
                    {
                        try
                        {
                            HtmlNodeCollection a = Page[j].SelectNodes("./a");
                            string busyUrl = "http://www.livenation.es" + a[0].Attributes["href"].Value;
                            doc1 = web.Load(busyUrl);
                            HtmlNodeCollection datafun = doc1.DocumentNode.SelectNodes("//a[@class='eventtickets__ticket__buy--loggedin']");
                            if (datafun == null)
                            {
                                datafun = doc1.DocumentNode.SelectNodes("//a[@class='eventfeaturedtix__buy']");
                            }
                            MusicEvent _obj = new MusicEvent();
                            _obj.Website = "livenation.es/";
                            HtmlNodeCollection Fun = Page[j].SelectNodes(".//h3[@class='artistticket__ticketsname']");
                            _obj.Function = Replace(Fun[0].InnerText);
                            HtmlNodeCollection date = Page[j].SelectNodes(".//div[@class='artistticket__date']");
                            _obj.DateTime = Replace(date[0].InnerText).Replace("s&#225;b", "").Trim();
                            HtmlNodeCollection Ens = Page[j].SelectNodes(".//h4[@class='artistticket__venue']");
                            HtmlNodeCollection Ens2 = Page[j].SelectNodes(".//h5[@class='artistticket__city']");
                            _obj.Enclosure = Replace(Ens[0].InnerText + " " + Ens2[0].InnerText);
                            if (datafun != null)
                            {
                                _obj.BuyLink = datafun[0].Attributes["href"].Value;
                                updateContent(txtlogs, "Site: http://www.livenation.es = > Function :" + _obj.Function + ", Date :" + _obj.DateTime);

                                _obj.Function = ReplaceChar(_obj.Function);
                                _obj.Enclosure = ReplaceChar(_obj.Enclosure);
                                _obj.DateTime = ReplaceChar(_obj.DateTime);
                                _MusicEventList.Add(_obj);
                            }

                        }
                        catch (Exception ex)
                        {
                            continue;
                        }
                    }
                }
            }
            catch (Exception)
            {
            }
        }
        //Remaining

        public static bool AcceptAll(object sender, System.Security.Cryptography.X509Certificates.X509Certificate certification, System.Security.Cryptography.X509Certificates.X509Chain chain, System.Net.Security.SslPolicyErrors sslPolicyErrors)
        {
            return true;
        }
        public static List<string> Towneauction_Post(string URL)
        {
            List<string> PageData = new List<string>();
            string responseData = string.Empty;
            try
            {
                CookieContainer cookies = new CookieContainer();
                responseData = GetFirstRespParams(URL, ref cookies);
                PageData.Add(responseData);
                for (; ; )
                {
                    string __VIEWSTATE = ExtractViewState(responseData, "__VIEWSTATE");
                    string postData = String.Format("__EVENTTARGET=GridView1&__EVENTARGUMENT=Page%24Next&__LASTFOCUS=" +
                        "&__VIEWSTATE=" + __VIEWSTATE +
                        "&__VIEWSTATEGENERATOR=B919013C&tbBeginDate=&tbEndDate=&TextBox1=&CheckBoxActive=on&CheckBoxPostponed=on&CheckBoxCanceled=on&inpSize=testing&inpStartDate=&inpEndDate=");
                    string HostName = "www.towneauction.com";
                    responseData = GetDataWithParams(URL, ref cookies, postData, HostName);
                    if (PageData[PageData.Count - 1] == responseData)
                    {
                        break;
                    }
                    PageData.Add(responseData);
                }
            }
            catch (Exception ex)
            { }
            return PageData;
        }
        public static string GetFirstRespParams(string URL, ref CookieContainer cookies)
        {
            //Access the page to extract view state information
            ServicePointManager.ServerCertificateValidationCallback = new System.Net.Security.RemoteCertificateValidationCallback(AcceptAll);
            HttpWebRequest webRequest = WebRequest.Create(URL) as HttpWebRequest;
            webRequest.CookieContainer = cookies;
            StreamReader responseReader = new StreamReader(webRequest.GetResponse().GetResponseStream());
            HttpWebResponse response = (HttpWebResponse)webRequest.GetResponse();
            response.Cookies = webRequest.CookieContainer.GetCookies(webRequest.RequestUri);
            string responseData = responseReader.ReadToEnd();
            responseReader.Close();
            webRequest.KeepAlive = false;
            return responseData;
        }
        public static string GetDataWithParams(string URL, ref CookieContainer cookies, string postData, string HostName)
        {
            //again access the login page with posted data to get cookies
            ServicePointManager.ServerCertificateValidationCallback = new System.Net.Security.RemoteCertificateValidationCallback(AcceptAll);
            HttpWebRequest webRequest = WebRequest.Create(URL) as HttpWebRequest;
            webRequest.Method = "POST";
            webRequest.Accept = "text/html,application/xhtml+xml,application/xml;q=0.9,image/webp,*/*;q=0.8";
            webRequest.Headers.Add("Accept-Language", "en-us;q=0.7,en;q=0.3");
            webRequest.AutomaticDecompression = DecompressionMethods.GZip | DecompressionMethods.Deflate;
            webRequest.ContentType = "application/x-www-form-urlencoded";
            webRequest.CookieContainer = cookies;
            webRequest.Host = HostName;
            webRequest.Proxy = new WebProxy();
            webRequest.KeepAlive = true;
            webRequest.UserAgent = "Mozilla/5.0 (Windows NT 6.1; WOW64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/45.0.2454.93 Safari/537.36";

            //access the page with posted data
            StreamWriter requestWriter = new StreamWriter(webRequest.GetRequestStream());
            requestWriter.Write(postData);
            requestWriter.Close();
            StreamReader responseReader = new StreamReader(webRequest.GetResponse().GetResponseStream());
            string responseData = responseReader.ReadToEnd();
            responseReader.Close();
            webRequest.KeepAlive = false;
            return responseData;
        }
        private static string ExtractViewState(string s, string Name)
        {
            string viewStateNameDelimiter = Name;
            string valueDelimiter = "value=\"";

            int viewStateNamePosition = s.IndexOf(viewStateNameDelimiter);
            int viewStateValuePosition = s.IndexOf(valueDelimiter, viewStateNamePosition);

            int viewStateStartPosition = viewStateValuePosition + valueDelimiter.Length;
            int viewStateEndPosition = s.IndexOf("\"", viewStateStartPosition);

            return HttpUtility.UrlEncodeUnicode(s.Substring(viewStateStartPosition, viewStateEndPosition - viewStateStartPosition));
        }

        public static string Replace(string MainString)
        {
            MainString = MainString.Replace("\n", " ");
            MainString = MainString.Replace("&nbsp;", " ");
            MainString = MainString.Replace("\t", "");
            MainString = MainString.Replace("\r", "");
            MainString = MainString.Replace("   ", " ");
            MainString = MainString.Replace(",", " ");
            MainString = MainString.Replace("*", " ");
            return MainString;
        }
        public static void ToCSV(DataTable dtDataTable, string strFilePath)
        {
            StreamWriter sw = new StreamWriter(strFilePath, false);
            //headers  
            for (int i = 0; i < dtDataTable.Columns.Count; i++)
            {
                sw.Write(dtDataTable.Columns[i]);
                if (i < dtDataTable.Columns.Count - 1)
                {
                    sw.Write(",");
                }
            }
            sw.Write(sw.NewLine);
            foreach (DataRow dr in dtDataTable.Rows)
            {
                for (int i = 0; i < dtDataTable.Columns.Count; i++)
                {
                    if (!Convert.IsDBNull(dr[i]))
                    {
                        string value = dr[i].ToString();
                        if (i == 6)
                        {
                            value = "=\"" + value + "\"";
                        }
                        if (value.Contains(','))
                        {
                            value = String.Format("\"{0}\"", value);
                            sw.Write(value);
                        }
                        else
                        {
                            sw.Write(value);
                        }
                    }
                    if (i < dtDataTable.Columns.Count - 1)
                    {
                        sw.Write(",");
                    }
                }
                sw.Write(sw.NewLine);
            }
            sw.Close();
        }
        public static DataTable ToDataTable<T>(List<T> items)
        {
            DataTable dataTable = new DataTable(typeof(T).Name);
            //Get all the properties
            PropertyInfo[] Props = typeof(T).GetProperties(BindingFlags.Public | BindingFlags.Instance);
            foreach (PropertyInfo prop in Props)
            {
                //Setting column names as Property names
                dataTable.Columns.Add(prop.Name);
            }
            foreach (T item in items)
            {
                var values = new object[Props.Length];
                for (int i = 0; i < Props.Length; i++)
                {
                    //inserting property values to datatable rows
                    values[i] = Props[i].GetValue(item, null);
                }
                dataTable.Rows.Add(values);
            }
            //put a breakpoint here and check datatable
            return dataTable;
        }

        public static void writeLog(string content)
        {
            try
            {
                string logfilePath = AppDomain.CurrentDomain.BaseDirectory + "Logs\\" + DateTime.Now.ToString("ddMMMyyyy") + ".log";
                Directory.CreateDirectory(Path.GetDirectoryName(logfilePath));
                FileStream fs = new FileStream(logfilePath, FileMode.OpenOrCreate, FileAccess.Write, FileShare.ReadWrite);
                StreamWriter sw = new StreamWriter(fs);
                sw.BaseStream.Seek(0, SeekOrigin.End);
                sw.WriteLine(": " + content);
                sw.Flush();
                sw.Close();
            }
            catch (Exception ex)
            {

            }
        }

        private void txtlogs_Click(object sender, EventArgs e)
        {

        }

        private void metroTabPage1_Click(object sender, EventArgs e)
        {

        }

        private void chkbaystateauction_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void chkpesco_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {

        }

        private void metroButton1_Click(object sender, EventArgs e)
        {
            string appPath = System.IO.Path.GetDirectoryName(Application.ExecutablePath) + @"\ExportFile";
            bool exists = System.IO.Directory.Exists(appPath);
            if (!exists)
            {
                System.IO.Directory.CreateDirectory(appPath);
            }
            string filePath = appPath + @"\music_event_" + DateTime.Now.ToString("MM-dd-yyyy-HHmmssfff") + ".csv";
            dt = ToDataTable(_MusicEventList);
            ToCSV(dt, filePath);
            metroGrid1.DataSource = dt;
            //MessageBox.Show("File Path :" + filePath);
            MetroMessageBox.Show(this, "File Path :" + filePath, "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            Process proc = new Process();
            proc.StartInfo = new ProcessStartInfo("excel.exe", filePath);
            proc.Start();
            this.Close();
        }

        public string ReplaceChar(string test)
        {
            test = test.Replace("&#383;", "ſ");
            test = test.Replace("â€", "”");
            test = test.Replace("â€œ", "“");
            test = test.Replace("Ã¡", "á");
            test = test.Replace("Ã©", "é");
            test = test.Replace("Ã³", "ó");
            test = test.Replace("ï¿½", "á");
            test = test.Replace("&#243;", "ó");
            test = test.Replace("&quot;", "''");
            test = test.Replace("&#225;", "á");
            test = test.Replace("Ã­", "í");
            test = test.Replace("Ã±", "ñ");
            test = test.Replace("&amp;", "&");
            test = test.Replace("&#250;", "ú");
            test = test.Replace("Â´s", "‘s");
            test = test.Replace("&#039;", "‘");
            test = test.Replace("Ãº", "ú");
            test = test.Replace("Ã©", "é");
            test = test.Replace("Ã³", "ó");
            test = test.Replace("&aacute;", "á");
            test = test.Replace("&Oacute;", "Ó");
            test = test.Replace("Ãš", "Ú");
            test = test.Replace("Ã‘", "Ñ");
            test = test.Replace("&#211;", "Ó");
            test = test.Replace("&#218;", "Ú");
            test = test.Replace("&#193;", "á");
            test = test.Replace("&eacute;", "é");
            test = test.Replace("&uacute;", "ú");

            test = test.Replace("&#033;", "!");
            test = test.Replace("&#034;", "");
            test = test.Replace("&#035;", "#");
            test = test.Replace("&#036;", "$");
            test = test.Replace("&#037;", "%");
            test = test.Replace("&#038;", "&");
            test = test.Replace("&#039;", "'");
            test = test.Replace("&#040;", "(");
            test = test.Replace("&#041;", ")");
            test = test.Replace("&#042;", "*");
            test = test.Replace("&#043;", "+");
            test = test.Replace("&#044;", "t");
            test = test.Replace("&#045;", "-");
            test = test.Replace("&#046;", ".");
            test = test.Replace("&#047;", "/");

            test = test.Replace("&#049;", "1");
            test = test.Replace("&#050;", "2");
            test = test.Replace("&#051;", "3");
            test = test.Replace("&#052;", "4");
            test = test.Replace("&#053;", "5");
            test = test.Replace("&#054;", "6");
            test = test.Replace("&#055;", "7");
            test = test.Replace("&#056;", "8");
            test = test.Replace("&#057;", "9");
            test = test.Replace("&#066;", "B");
            test = test.Replace("&#067;", "C");
            test = test.Replace("&#068;", "D");
            test = test.Replace("&#069;", "E");
            test = test.Replace("&#070;", "F");
            test = test.Replace("&#071;", "G");
            test = test.Replace("&#072;", "H");
            test = test.Replace("&#073;", "I");
            test = test.Replace("&#074;", "J");
            test = test.Replace("&#075;", "K");
            test = test.Replace("&#076;", "L");
            test = test.Replace("&#077;", "M");
            test = test.Replace("&#078;", "N");
            test = test.Replace("&#079;", "O");
            test = test.Replace("&#080;", "P");
            test = test.Replace("&#081;", "Q");
            test = test.Replace("&#082;", "R");
            test = test.Replace("&#083;", "S");
            test = test.Replace("&#084;", "T");
            test = test.Replace("&#085;", "U");
            test = test.Replace("&#086;", "V");
            test = test.Replace("&#087;", "W");
            test = test.Replace("&#088;", "X");
            test = test.Replace("&#089;", "Y");
            test = test.Replace("&#090;", "Z");
            test = test.Replace("&#098;", "b");
            test = test.Replace("&#099;", "c");
            test = test.Replace("&#100;", "d");
            test = test.Replace("&#101;", "e");
            test = test.Replace("&#102;", "f");
            test = test.Replace("&#103;", "g");
            test = test.Replace("&#104;", "h");
            test = test.Replace("&#105;", "i");
            test = test.Replace("&#106;", "j");
            test = test.Replace("&#107;", "k");
            test = test.Replace("&#108;", "l");
            test = test.Replace("&#109;", "m");
            test = test.Replace("&#110;", "n");
            test = test.Replace("&#111;", "o");
            test = test.Replace("&#112;", "p");
            test = test.Replace("&#113;", "q");
            test = test.Replace("&#114;", "r");
            test = test.Replace("&#115;", "s");
            test = test.Replace("&#116;", "t");
            test = test.Replace("&#117;", "u");
            test = test.Replace("&#118;", "v");
            test = test.Replace("&#119;", "w");
            test = test.Replace("&#120;", "x");
            test = test.Replace("&#121;", "y");
            test = test.Replace("&#122;", "z");

            test = test.Replace("&#161;", "¡");
            test = test.Replace("&#162;", "¢");
            test = test.Replace("&#163;", "£");
            test = test.Replace("&#164;", "¤");
            test = test.Replace("&#165;", "¥");
            test = test.Replace("&#166;", "¦");
            test = test.Replace("&#167;", "§");
            test = test.Replace("&#168;", "¨");
            test = test.Replace("&#169;", "©");
            test = test.Replace("&#170;", "ª");
            test = test.Replace("&#171;", "«");
            test = test.Replace("&#172;", "¬");
            test = test.Replace("&#174;", "®");
            test = test.Replace("&#175;", "¯");
            test = test.Replace("&#176;", "°");
            test = test.Replace("&#177;", "±");
            test = test.Replace("&#178;", "²");
            test = test.Replace("&#179;", "³");
            test = test.Replace("&#180;", "´");
            test = test.Replace("&#181;", "µ");
            test = test.Replace("&#182;", "¶");
            test = test.Replace("&#183;", "·");
            test = test.Replace("&#184;", "¸");
            test = test.Replace("&#185;", "¹");
            test = test.Replace("&#186;", "º");
            test = test.Replace("&#187;", "»");
            test = test.Replace("&#188;", "¼");
            test = test.Replace("&#189;", "½");
            test = test.Replace("&#190;", "¾");
            test = test.Replace("&#191;", "¿");

            test = test.Replace("&#193;", "Á");
            test = test.Replace("&#194;", "Â");
            test = test.Replace("&#195;", "Ã");
            test = test.Replace("&#196;", "Ä");
            test = test.Replace("&#197;", "Å");
            test = test.Replace("&#198;", "Æ");
            test = test.Replace("&#199;", "Ç");
            test = test.Replace("&#200;", "È");
            test = test.Replace("&#201;", "É");
            test = test.Replace("&#202;", "Ê");
            test = test.Replace("&#203;", "Ë");
            test = test.Replace("&#204;", "Ì");
            test = test.Replace("&#205;", "Í");
            test = test.Replace("&#206;", "Î");
            test = test.Replace("&#207;", "Ï");
            test = test.Replace("&#208;", "Ð");
            test = test.Replace("&#209;", "Ñ");
            test = test.Replace("&#210;", "Ò");
            test = test.Replace("&#211;", "Ó");
            test = test.Replace("&#212;", "Ô");
            test = test.Replace("&#213;", "Õ");
            test = test.Replace("&#214;", "Ö");
            test = test.Replace("&#217;", "Ù");
            test = test.Replace("&#218;", "Ú");
            test = test.Replace("&#219;", "Û");
            test = test.Replace("&#220;", "Ü");
            test = test.Replace("&#221;", "Ý");
            test = test.Replace("&#222;", "Þ");
            test = test.Replace("&#223;", "ß");
            test = test.Replace("&#224;", "à");
            test = test.Replace("&#225;", "á");
            test = test.Replace("&#226;", "â");
            test = test.Replace("&#227;", "ã");
            test = test.Replace("&#228;", "ä");
            test = test.Replace("&#229;", "å");
            test = test.Replace("&#230;", "æ");
            test = test.Replace("&#231;", "ç");
            test = test.Replace("&#232;", "è");
            test = test.Replace("&#233;", "é");
            test = test.Replace("&#234;", "ê");
            test = test.Replace("&#235;", "ë");
            test = test.Replace("&#236;", "ì");
            test = test.Replace("&#237;", "í");
            test = test.Replace("&#238;", "î");
            test = test.Replace("&#239;", "ï");
            test = test.Replace("&#240;", "ð");
            test = test.Replace("&#241;", "ñ");
            test = test.Replace("&#242;", "ò");
            test = test.Replace("&#243;", "ó");
            test = test.Replace("&#244;", "ô");
            test = test.Replace("&#245;", "õ");
            test = test.Replace("&#246;", "ö");

            test = test.Replace("&#249;", "ù");
            test = test.Replace("&#250;", "ú");
            test = test.Replace("&#251;", "û");
            test = test.Replace("&#252;", "ü");
            test = test.Replace("&#253;", "ý");
            test = test.Replace("&#254;", "þ");
            test = test.Replace("&#255;", "ÿ");
            test = test.Replace("&#257;", "ā");
            test = test.Replace("&#258;", "Ă");
            test = test.Replace("&#259;", "ă");
            test = test.Replace("&#260;", "Ą");
            test = test.Replace("&#261;", "ą");
            test = test.Replace("&#262;", "Ć");
            test = test.Replace("&#263;", "ć");
            test = test.Replace("&#264;", "Ĉ");
            test = test.Replace("&#265;", "ĉ");
            test = test.Replace("&#266;", "Ċ");
            test = test.Replace("&#267;", "ċ");
            test = test.Replace("&#268;", "Č");
            test = test.Replace("&#269;", "č");
            test = test.Replace("&#270;", "Ď");
            test = test.Replace("&#271;", "ď");
            test = test.Replace("&#272;", "Đ");
            test = test.Replace("&#273;", "đ");
            test = test.Replace("&#274;", "Ē");
            test = test.Replace("&#275;", "ē");
            test = test.Replace("&#276;", "Ĕ");
            test = test.Replace("&#277;", "ĕ");
            test = test.Replace("&#278;", "Ė");
            test = test.Replace("&#279;", "ė");
            test = test.Replace("&#280;", "Ę");
            test = test.Replace("&#281;", "ę");
            test = test.Replace("&#282;", "Ě");
            test = test.Replace("&#283;", "ě");
            test = test.Replace("&#284;", "Ĝ");
            test = test.Replace("&#285;", "ĝ");
            test = test.Replace("&#286;", "Ğ");
            test = test.Replace("&#287;", "ğ");
            test = test.Replace("&#288;", "Ġ");
            test = test.Replace("&#289;", "ġ");
            test = test.Replace("&#290;", "Ģ");
            test = test.Replace("&#291;", "ģ");
            test = test.Replace("&#292;", "Ĥ");
            test = test.Replace("&#293;", "ĥ");
            test = test.Replace("&#294;", "Ħ");
            test = test.Replace("&#295;", "ħ");
            test = test.Replace("&#296;", "Ĩ");
            test = test.Replace("&#297;", "ĩ");
            test = test.Replace("&#298;", "Ī");
            test = test.Replace("&#299;", "ī");
            test = test.Replace("&#300;", "Ĭ");
            test = test.Replace("&#301;", "ĭ");
            test = test.Replace("&#302;", "Į");
            test = test.Replace("&#303;", "į");
            test = test.Replace("&#304;", "İ");
            test = test.Replace("&#305;", "ı");
            test = test.Replace("&#306;", "Ĳ");
            test = test.Replace("&#307;", "ĳ");
            test = test.Replace("&#308;", "Ĵ");
            test = test.Replace("&#309;", "ĵ");
            test = test.Replace("&#310;", "Ķ");
            test = test.Replace("&#311;", "ķ");
            test = test.Replace("&#312;", "ĸ");
            test = test.Replace("&#313;", "Ĺ");
            test = test.Replace("&#314;", "ĺ");
            test = test.Replace("&#315;", "Ļ");
            test = test.Replace("&#316;", "ļ");
            test = test.Replace("&#317;", "Ľ");
            test = test.Replace("&#318;", "ľ");
            test = test.Replace("&#319;", "Ŀ");
            test = test.Replace("&#320;", "ŀ");
            test = test.Replace("&#321;", "Ł");
            test = test.Replace("&#322;", "ł");
            test = test.Replace("&#323;", "Ń");
            test = test.Replace("&#324;", "ń");
            test = test.Replace("&#325;", "Ņ");
            test = test.Replace("&#326;", "ņ");
            test = test.Replace("&#327;", "Ň");
            test = test.Replace("&#328;", "ň");
            test = test.Replace("&#331;", "ŋ");
            test = test.Replace("&#332;", "Ō");
            test = test.Replace("&#333;", "ō");
            test = test.Replace("&#334;", "Ŏ");
            test = test.Replace("&#335;", "ŏ");
            test = test.Replace("&#336;", "Ő");
            test = test.Replace("&#337;", "ő");
            test = test.Replace("&#338;", "Œ");
            test = test.Replace("&#339;", "œ");
            test = test.Replace("&#340;", "Ŕ");
            test = test.Replace("&#341;", "ŕ");
            test = test.Replace("&#342;", "Ŗ");
            test = test.Replace("&#343;", "ŗ");
            test = test.Replace("&#344;", "Ř");
            test = test.Replace("&#345;", "ř");
            test = test.Replace("&#346;", "Ś");
            test = test.Replace("&#347;", "ś");
            test = test.Replace("&#348;", "Ŝ");
            test = test.Replace("&#349;", "ŝ");
            test = test.Replace("&#350;", "Ş");
            test = test.Replace("&#351;", "ş");
            test = test.Replace("&#352;", "Š");
            test = test.Replace("&#353;", "š");
            test = test.Replace("&#354;", "Ţ");
            test = test.Replace("&#355;", "ţ");
            test = test.Replace("&#356;", "Ť");
            test = test.Replace("&#357;", "ť");
            test = test.Replace("&#358;", "Ŧ");
            test = test.Replace("&#359;", "ŧ");
            test = test.Replace("&#360;", "Ũ");
            test = test.Replace("&#361;", "ũ");
            test = test.Replace("&#362;", "Ū");
            test = test.Replace("&#363;", "ū");
            test = test.Replace("&#364;", "Ŭ");
            test = test.Replace("&#365;", "ŭ");
            test = test.Replace("&#366;", "Ů");
            test = test.Replace("&#367;", "ů");
            test = test.Replace("&#368;", "Ű");
            test = test.Replace("&#369;", "ű");
            test = test.Replace("&#370;", "Ų");
            test = test.Replace("&#371;", "ų");
            test = test.Replace("&#372;", "Ŵ");
            test = test.Replace("&#373;", "ŵ");
            test = test.Replace("&#374;", "Ŷ");
            test = test.Replace("&#375;", "ŷ");
            test = test.Replace("&#376;", "Ÿ");
            test = test.Replace("&#377;", "Ź");
            test = test.Replace("&#378;", "ź");
            test = test.Replace("&#379;", "Ż");
            test = test.Replace("&#380;", "ż");
            test = test.Replace("&#381;", "Ž");
            test = test.Replace("&#382;", "ž");

            test = test.Replace("Lunes", "");
            test = test.Replace("Martes", "");
            test = test.Replace("Miercoles", "");
            test = test.Replace("Miércoles", "");
            test = test.Replace("Mierc.", "");
            test = test.Replace("Jueves", "");
            test = test.Replace("Viernes", "");
            test = test.Replace("Sabado", "");
            test = test.Replace("Sábado", "");
            test = test.Replace("Domingo", "");
            test = test.Replace("SABADO", "");
            test = test.Replace("VIERNES", "");
            test = test.Replace("Sábado", "");

            test = test.Replace("lun. ", "");
            test = test.Replace("mar. ", "");
            test = test.Replace("mie. ", "");
            test = test.Replace("mié. ", "");
            test = test.Replace("jue. ", "");
            test = test.Replace("juev. ", "");
            test = test.Replace("vie. ", "");
            test = test.Replace("sab. ", "");
            test = test.Replace("dom. ", "");



            test = test.Replace("Lun.", "");
            test = test.Replace("Mar.", "");
            test = test.Replace("Mie.", "");
            test = test.Replace("Jue.", "");
            test = test.Replace("Juev.", "");
            test = test.Replace("Vie.", "");
            test = test.Replace("Sab.", "");
            test = test.Replace("sáb.", "");
            test = test.Replace("Dom.", "");

            test = test.Replace("lun", "");
            test = test.Replace("mar", "");
            test = test.Replace("mie", "");
            test = test.Replace("jue", "");
            test = test.Replace("vie", "");
            test = test.Replace("sab", "");
            test = test.Replace("dom", "");
            test = test.Replace("mié", "");
            test = test.Replace("miér", "");
            test = test.Replace("Enero", "January " + DateTime.Now.Year);
            test = test.Replace("Feb.", "February " + DateTime.Now.Year + " ");
            test = test.Replace("Febrero", "February " + DateTime.Now.Year);
            test = test.Replace("Marzo", "March " + DateTime.Now.Year);
            test = test.Replace("Abril", "April " + DateTime.Now.Year);
            test = test.Replace("Mayo", "May " + DateTime.Now.Year);
            test = test.Replace("Junio", "June " + DateTime.Now.Year);
            test = test.Replace("Julio", "July " + DateTime.Now.Year);
            test = test.Replace("Agosto", "August " + DateTime.Now.Year);
            test = test.Replace("Setiembre", "September " + DateTime.Now.Year);
            test = test.Replace("Sept.", "September " + DateTime.Now.Year);
            test = test.Replace("Septiembre", "September " + DateTime.Now.Year);
            test = test.Replace("Octubre", "October " + DateTime.Now.Year);
            test = test.Replace("Nov", "November " + DateTime.Now.Year);
            test = test.Replace("Nombre", "November " + DateTime.Now.Year);
            test = test.Replace("Noviembre", "November " + DateTime.Now.Year);
            test = test.Replace("NOVIEMBRE", "November " + DateTime.Now.Year);
            test = test.Replace("Dic.", "December " + DateTime.Now.Year);
            test = test.Replace("Diciembre", "December " + DateTime.Now.Year);
            test = test.Replace("DICIEMBRE", "December " + DateTime.Now.Year);



            test = test.Replace("Pta:", "");
            test = test.Replace(". Pta ", " ");
            return test;
        }

        private void metroCheckBox2_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void metroCheckBox1_CheckedChanged(object sender, EventArgs e)
        {

        }

    }
    public class MusicEvent
    {
        public string Website { get; set; }
        public string Function { get; set; }
        public string DateTime { get; set; }
        public string Enclosure { get; set; }
        public string BuyLink { get; set; }
    }
    public class TicketMasterClass
    {
        public class Self
        {
            public string href { get; set; }
            public bool templated { get; set; }
        }

        public class Next
        {
            public string href { get; set; }
            public bool templated { get; set; }
        }

        public class Links
        {
            public Self self { get; set; }
            public Next next { get; set; }
        }

        public class Image
        {
            public string ratio { get; set; }
            public string url { get; set; }
            public int width { get; set; }
            public int height { get; set; }
            public bool fallback { get; set; }
        }

        public class Public
        {
            public string startDateTime { get; set; }
            public bool startTBD { get; set; }
            public string endDateTime { get; set; }
        }

        public class Presale
        {
            public string startDateTime { get; set; }
            public string endDateTime { get; set; }
            public string name { get; set; }
            public string description { get; set; }
            public string url { get; set; }
        }

        public class Sales
        {
            public Public @public { get; set; }
            public List<Presale> presales { get; set; }
        }

        public class Start
        {
            public string localDate { get; set; }
            public string localTime { get; set; }
            public string dateTime { get; set; }
            public bool dateTBD { get; set; }
            public bool dateTBA { get; set; }
            public bool timeTBA { get; set; }
            public bool noSpecificTime { get; set; }
        }

        public class Status
        {
            public string code { get; set; }
        }

        public class Dates
        {
            public Start start { get; set; }
            public string timezone { get; set; }
            public Status status { get; set; }
        }

        public class Segment
        {
            public string id { get; set; }
            public string name { get; set; }
        }

        public class Genre
        {
            public string id { get; set; }
            public string name { get; set; }
        }

        public class SubGenre
        {
            public string id { get; set; }
            public string name { get; set; }
        }

        public class Classification
        {
            public bool primary { get; set; }
            public Segment segment { get; set; }
            public Genre genre { get; set; }
            public SubGenre subGenre { get; set; }
        }

        public class Promoter
        {
            public string id { get; set; }
            public string name { get; set; }
            public string description { get; set; }
        }

        public class PriceRange
        {
            public string type { get; set; }
            public string currency { get; set; }
            public double min { get; set; }
            public double max { get; set; }
        }

        public class Self2
        {
            public string href { get; set; }
        }

        public class Attraction
        {
            public string href { get; set; }
        }

        public class Venue
        {
            public string href { get; set; }
        }

        public class Links2
        {
            public Self2 self { get; set; }
            public List<Attraction> attractions { get; set; }
            public List<Venue> venues { get; set; }
        }

        public class City
        {
            public string name { get; set; }
        }

        public class State
        {
            public string name { get; set; }
            public string stateCode { get; set; }
        }

        public class Country
        {
            public string name { get; set; }
            public string countryCode { get; set; }
        }

        public class Address
        {
            public string line1 { get; set; }
        }

        public class Location
        {
            public string longitude { get; set; }
            public string latitude { get; set; }
        }

        public class Market
        {
            public string id { get; set; }
        }

        public class Dma
        {
            public int id { get; set; }
        }

        public class Self3
        {
            public string href { get; set; }
        }

        public class Links3
        {
            public Self3 self { get; set; }
        }

        public class Venue2
        {
            public string name { get; set; }
            public string type { get; set; }
            public string id { get; set; }
            public bool test { get; set; }
            public string url { get; set; }
            public string locale { get; set; }
            public string postalCode { get; set; }
            public string timezone { get; set; }
            public City city { get; set; }
            public State state { get; set; }
            public Country country { get; set; }
            public Address address { get; set; }
            public Location location { get; set; }
            public List<Market> markets { get; set; }
            public List<Dma> dmas { get; set; }
            public Links3 _links { get; set; }
        }

        public class Image2
        {
            public string ratio { get; set; }
            public string url { get; set; }
            public int width { get; set; }
            public int height { get; set; }
            public bool fallback { get; set; }
            public string attribution { get; set; }
        }

        public class Segment2
        {
            public string id { get; set; }
            public string name { get; set; }
        }

        public class Genre2
        {
            public string id { get; set; }
            public string name { get; set; }
        }

        public class SubGenre2
        {
            public string id { get; set; }
            public string name { get; set; }
        }

        public class Classification2
        {
            public bool primary { get; set; }
            public Segment2 segment { get; set; }
            public Genre2 genre { get; set; }
            public SubGenre2 subGenre { get; set; }
        }

        public class Self4
        {
            public string href { get; set; }
        }

        public class Links4
        {
            public Self4 self { get; set; }
        }

        public class Attraction2
        {
            public string name { get; set; }
            public string type { get; set; }
            public string id { get; set; }
            public bool test { get; set; }
            public string url { get; set; }
            public string locale { get; set; }
            public List<Image2> images { get; set; }
            public List<Classification2> classifications { get; set; }
            public Links4 _links { get; set; }
        }

        public class Embedded2
        {
            public List<Venue2> venues { get; set; }
            public List<Attraction2> attractions { get; set; }
        }

        public class Event
        {
            public string name { get; set; }
            public string type { get; set; }
            public string id { get; set; }
            public bool test { get; set; }
            public string url { get; set; }
            public string locale { get; set; }
            public List<Image> images { get; set; }
            public Sales sales { get; set; }
            public Dates dates { get; set; }
            public List<Classification> classifications { get; set; }
            public Promoter promoter { get; set; }
            public string pleaseNote { get; set; }
            public List<PriceRange> priceRanges { get; set; }
            public Links2 _links { get; set; }
            public Embedded2 _embedded { get; set; }
            public string info { get; set; }
        }

        public class Embedded
        {
            public List<Event> events { get; set; }
        }

        public class Page
        {
            public int size { get; set; }
            public int totalElements { get; set; }
            public int totalPages { get; set; }
            public int number { get; set; }
        }

        public class RootObject
        {
            public Links _links { get; set; }
            public Embedded _embedded { get; set; }
            public Page page { get; set; }
        }
    }

}
