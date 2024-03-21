using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static B_Sync_Pro.Models.Class_token;

namespace B_Sync_Pro.Forms
{
    public partial class Form_Login : Form
    {
        private Form_Menu formMenu;
        public string AccessToken { get; private set; }

        public Form_Login()
        {
            InitializeComponent();           
        }

        private void Form_menu_Load(object sender, EventArgs e)
        {
            InitBrowser();
        }
        private async Task initizated()
        {
            await webView21.EnsureCoreWebView2Async(null);
        }

        public async void InitBrowser()
        {
            await initizated();
            webView21.CoreWebView2.Navigate("https://www.bling.com.br/b/OAuth2/views/authorization.php?response_type=code&client_id=89009094a6aa3aaa70764f&scopes=98308+98309");

            
        }

        int i = 0;
        private async void webView21_NavigationStarting(object sender, Microsoft.Web.WebView2.Core.CoreWebView2NavigationStartingEventArgs e)
        {
            Uri uri = new Uri(e.Uri);

            if (uri.AbsoluteUri.StartsWith("https://www.localhost/api/Auth/teste") && !string.IsNullOrEmpty(uri.Query))
            {
                string query = uri.Query; // Isso incluirá o ? na string

                // Separe a query para obter os parâmetros individuais
                string[] queryParams = query.Split('&');
                foreach (string param in queryParams)
                {
                    if (param.StartsWith("?code="))
                    {
                        if (i == 0)
                        {
                            string code = param.Substring(6); // Pega o valor após "code="
                                                              // Agora você tem o código, faça a validação e prossiga conforme necessário
                            await GetAccessToken(code);
                            i++;
                        }                        
                    }
                }
            }
        }




        private async Task GetAccessToken(string authorizationCode)
        {
            string tokenUrl = "https://www.bling.com.br/Api/v3/oauth/token";

            // Monta as credenciais em base64 (client_id:client_secret)
            string clientId = "8900909450c7c7c1c689f0cf1339f";
            string clientSecret = "ad87a30b83cbca5e504";
            string credentials = Convert.ToBase64String(Encoding.UTF8.GetBytes($"{clientId}:{clientSecret}"));

            // Monta os dados do corpo da requisição
            var requestData = new List<KeyValuePair<string, string>>
            {
                new KeyValuePair<string, string>("grant_type", "authorization_code"),
                new KeyValuePair<string, string>("code", authorizationCode)
            };
                
            using (HttpClient client = new HttpClient())
            {
                client.DefaultRequestHeaders.Add("Authorization", $"Basic {credentials}");
                var content = new FormUrlEncodedContent(requestData);

                HttpResponseMessage response = await client.PostAsync(tokenUrl, content);
                if (response.IsSuccessStatusCode)
                {
                    string responseContent = await response.Content.ReadAsStringAsync();
                    // Trate a resposta JSON para obter os tokens de acesso
                    var tokens = JsonConvert.DeserializeObject<AccessTokenResponse>(responseContent);


                    // Agora você pode acessar os tokens usando a variável 'tokens'
                    string accessToken = tokens.access_token;
                    string refreshToken = tokens.refresh_token;

                    formMenu = new Form_Menu(accessToken);
                    this.Hide();
                    formMenu.FormClosed += FormMenu_FormClosed;
                    formMenu.Show();
                }
               
            }
        }


        private void FormMenu_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit(); // ou Environment.Exit(0);
        }
    }
}