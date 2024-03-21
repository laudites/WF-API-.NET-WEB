using System;
using System.Diagnostics;
using System.Windows.Forms;
using B_Sync_Pro.Forms;
using FirebaseAdmin;
using Google.Apis.Auth.OAuth2;
using Google.Cloud.Firestore;
using System.Security.Cryptography;
using System.Text;

namespace B_Sync_Pro
{
    //PRODUCAO
   
    public partial class Form_Inicio : Form
    {
        private Form_Login formMenu;        

        public Form_Inicio()
        {
            InitializeComponent();
            button1.Enabled = false;
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            formMenu = new Form_Login();
            this.Hide();
            formMenu.FormClosed += FormMenu_FormClosed;
            formMenu.Show();
        }
        private void FormMenu_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit(); // ou Environment.Exit(0);
        }

        private void toolStripMenuItem_sobre_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Em desenvolvimento!");
        }

        private string PromptForChave()
        {
            string chave = "";
            using (var chaveInput = new Form())
            {
                chaveInput.Text = "Digite a Chave";
                var inputBox = new TextBox() { Left = 50, Top = 20, Width = 200 };
                var confirmButton = new Button() { Text = "OK", Left = 150, Width = 100, Top = 50, DialogResult = DialogResult.OK };
                confirmButton.Click += (sender, e) => chaveInput.Close();
                chaveInput.Controls.Add(inputBox);
                chaveInput.Controls.Add(confirmButton);
                chaveInput.AcceptButton = confirmButton;

                if (chaveInput.ShowDialog() == DialogResult.OK)
                {
                    chave = inputBox.Text;
                }
            }
            return chave;
        }

        private string EncryptString(string plainText)
        {
            using (Aes aesAlg = Aes.Create())
            {
                aesAlg.Key = Encoding.UTF8.GetBytes("B-codigo@"); // Substitua pela sua chave de criptografia
                aesAlg.IV = new byte[16]; // Voc� pode gerar um IV aleat�rio ou usar uma t�cnica apropriada de gera��o de IV

                ICryptoTransform encryptor = aesAlg.CreateEncryptor(aesAlg.Key, aesAlg.IV);

                using (MemoryStream msEncrypt = new MemoryStream())
                {
                    using (CryptoStream csEncrypt = new CryptoStream(msEncrypt, encryptor, CryptoStreamMode.Write))
                    {
                        using (StreamWriter swEncrypt = new StreamWriter(csEncrypt))
                        {
                            swEncrypt.Write(plainText);
                        }
                    }
                    return Convert.ToBase64String(msEncrypt.ToArray());
                }
            }
        }

        private string DecryptString(string encryptedText)
        {
            using (Aes aesAlg = Aes.Create())
            {
                aesAlg.Key = Encoding.UTF8.GetBytes("B-codigo@"); // Use a mesma chave de criptografia
                aesAlg.IV = new byte[16]; // Use o mesmo IV (Vetor de Inicializa��o)

                ICryptoTransform decryptor = aesAlg.CreateDecryptor(aesAlg.Key, aesAlg.IV);

                using (MemoryStream msDecrypt = new MemoryStream(Convert.FromBase64String(encryptedText)))
                {
                    using (CryptoStream csDecrypt = new CryptoStream(msDecrypt, decryptor, CryptoStreamMode.Read))
                    {
                        using (StreamReader srDecrypt = new StreamReader(csDecrypt))
                        {
                            return srDecrypt.ReadToEnd();
                        }
                    }
                }
            }
        }

        private async void Form_Inicio_Load(object sender, EventArgs e)
        {
            button1.Enabled = true;

            // Diret�rio onde o aplicativo est� instalado
            string diretorioDoAplicativo = Directory.GetCurrentDirectory();

            // Constr�i o caminho para a pasta "Imagem"
            string caminhoDaPastaImagem = Path.Combine(diretorioDoAplicativo, "Imagens");

            // Verifica se a pasta "Imagem" existe
            if (Directory.Exists(caminhoDaPastaImagem))
            {
                // Caminho para a imagem desejada
                string caminhoDaImagem = Path.Combine(caminhoDaPastaImagem, "Logo_Inicio.jpg");

                // Verifica se o arquivo existe antes de definir como plano de fundo
                if (File.Exists(caminhoDaImagem))
                {
                    // Carrega a imagem
                    Image imagem = Image.FromFile(caminhoDaImagem);

                    // Define a imagem como plano de fundo do controle desejado
                    this.pictureBox1.BackgroundImage = imagem;

                    // Define o layout da imagem como desejado (ex: Stretch, Center, etc.)
                    this.pictureBox1.BackgroundImageLayout = ImageLayout.Stretch;
                }
                else
                {
                    MessageBox.Show("A imagem especificada n�o foi encontrada na pasta 'Imagem'.");
                }
            }
            else
            {
                MessageBox.Show("A pasta 'Imagem' n�o foi encontrada no diret�rio do aplicativo.");
            }
        }


            private async void Form_Inicio_Load1(object sender, EventArgs e)
        {


            // Verifica se o arquivo "chave.txt" existe
            if (!File.Exists("chave.txt"))
            {
                // Se n�o existir, solicita a chave ao usu�rio
                string chave = PromptForChave();

                // Criptografa a chave antes de escrev�-la no arquivo
                string chaveCriptografada = EncryptString(chave);

                // Cria o arquivo "chave.txt" com a chave criptografada
                File.WriteAllText("chave.txt", chaveCriptografada);

                MessageBox.Show("Chave salva com sucesso!");
            }

            try
            {
                Environment.SetEnvironmentVariable("GOOGLE_APPLICATION_CREDENTIALS", "gerenciadorlicencas-firebase-a.json");

                string arquivoCriptografado = "gerenciadorlicencas-firebase-admin.json";

                // 1. Ler o conte�do do arquivo JSON
                string conteudoJsonCriptografado = File.ReadAllText(arquivoCriptografado);

                // 2. Descriptografar o conte�do
                string conteudoJsonDescriptografado = DecryptString(conteudoJsonCriptografado);

                // 3. Fazer as opera��es desejadas no conte�do descriptografado
                // ...
                File.WriteAllText(arquivoCriptografado, conteudoJsonDescriptografado);




                // Carregar as credenciais do Firebase
                FirebaseApp.Create(new AppOptions
                {
                    Credential = GoogleCredential.FromFile("gerenciadorlicencas-firebase-adminsdk-9j.json")
                });

                string projectId = "gerenciadorlicencas";
                string collectionName = "chaves";

                FirestoreDb firestoreDb = FirestoreDb.Create(projectId);

                // Crie uma refer�ncia para a cole��o "chaves"
             CollectionReference collectionRef = firestoreDb.Collection(collectionName);

             // Execute uma consulta para recuperar todos os documentos da cole��o
             QuerySnapshot querySnapshot = await collectionRef.GetSnapshotAsync();

             // Itere sobre os documentos retornados e exiba seus dados
            foreach (DocumentSnapshot documentSnapshot in querySnapshot.Documents)
             {
                    // Exiba os dados do documento
                    //Console.WriteLine($"Documento: {documentSnapshot.Id}");

                    // L� a chave criptografada do arquivo "chave.txt"
                    string chaveCriptografada = File.ReadAllText("chave.txt");

                    // Descriptografa a chave
                    string chaveDescriptografada = DecryptString(chaveCriptografada);


                    if (documentSnapshot.Id.Equals(chaveDescriptografada))
                    {
                        object dataExpiracaoObj;
                        if (documentSnapshot.TryGetValue("Data_expiracao", out dataExpiracaoObj) && dataExpiracaoObj is Timestamp timestamp)
                        {
                            DateTime dataExpiracao = timestamp.ToDateTime();

                            // Agora voc� pode verificar se a data est� dentro da data de validade
                            DateTime dataAtual = DateTime.UtcNow; // Obt�m a data atual em UTC

                            if (dataExpiracao > dataAtual)
                            {
                                // A chave est� ativa
                                //MessageBox.Show("A chave est� ativa!", "Chave Ativa", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                button1.Enabled = true;
                            }
                            else
                            {
                                button1.Enabled = false;
                                // A chave expirou
                                MessageBox.Show("A chave expirou!\n Favor entrar em contato com o administrador do sistema!", "Chave Expirada", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                Application.Exit();
                            }
                        }
                        else
                        {
                            // A chave "Data_expiracao" n�o existe no documento ou n�o � um Timestamp
                            button1.Enabled = false;
                            MessageBox.Show("A chave 'Data_expiracao' n�o existe no documento ou n�o � um Timestamp", "Chave N�o Encontrada ou Tipo Inv�lido", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            Application.Exit();
                        }
                    }
                    else
                    {
                        // O documentSnapshot.Id n�o � igual a "24Jx4z7AmAwwdqzEYW0I"
                        button1.Enabled = false;
                        MessageBox.Show("Chave n�o existe \nFavor entrar em contato com o administrador do sistema!");
                        Application.Exit();
                    }
                    Dictionary<string, object> data = documentSnapshot.ToDictionary();
                    
                    // 4. Criptografar o conte�do novamente
                    string conteudoJsonCriptografadoNovamente = EncryptString(conteudoJsonDescriptografado);

                    // 5. Salvar o conte�do criptografado de volta no arquivo JSON
                    File.WriteAllText(arquivoCriptografado, conteudoJsonCriptografadoNovamente);
                    
                }
            }
            catch (Exception ex)
            {
                // Lidar com exce��es
                MessageBox.Show($"Ocorreu um erro: {ex.Message}", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Application.Exit();
            }
        }
    }
}