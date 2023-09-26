using CRUD_Forms.Data;
using CRUD_Forms.Model;
using NITGEN.SDK.NBioBSP;
using System;
using System.Data;
using System.Windows.Forms;

namespace CRUD_Forms.Entity
{
    public class Biometria
    {
        // Declaração de vários campos relacionados à biometria e ao SDK da NitGen
        NBioAPI m_NBioAPI = new NBioAPI();
        NBioAPI.Type.FIR_TEXTENCODE m_textFIR;
        NBioAPI.IndexSearch m_IndexSearch;
        NBioAPI.Type.WINDOW_OPTION m_WinOption;
        NBioAPI.Type.HFIR hCapturedFIR;
        NBioAPI.Type.FIR_PAYLOAD myPayload;

        public void Form1_Load(object sender, System.EventArgs e)
        {
            // Inicialização do mecanismo de índice de pesquisa
            uint ret = m_IndexSearch.InitEngine();
            if (ret != NBioAPI.Error.NONE)
            {
                // Tratamento de erro, se necessário
            }

            // Obtém a versão do SDK
            NBioAPI.Type.VERSION version = new NBioAPI.Type.VERSION();
            m_NBioAPI.GetVersion(out version);
        }

        public void Registrar(Model.User user)
        {
           
            NBioAPI.Type.FIR Byte_FIR;
            NBioAPI.Type.HFIR hEnrolledFIR;

            // Abre o dispositivo biométrico
            m_NBioAPI.OpenDevice(NBioAPI.Type.DEVICE_ID.AUTO);

            // Tenta realizar o registro biométrico
            uint ret = m_NBioAPI.Enroll(null, out hEnrolledFIR, null, NBioAPI.Type.TIMEOUT.DEFAULT, null, m_WinOption);

            if (ret == NBioAPI.Error.NONE)
            {
                // Tratamento de erro, se necessário
                m_NBioAPI.CloseDevice(NBioAPI.Type.DEVICE_ID.AUTO);
            }

            // Obtém a representação de texto da impressão digital registrada
            m_NBioAPI.GetTextFIRFromHandle(hEnrolledFIR, out m_textFIR, true);

            // Obtém a representação binária da impressão digital registrada
            m_NBioAPI.GetFIRFromHandle(hEnrolledFIR, out Byte_FIR);

             

            // Atualiza as propriedades do usuário com os dados biométricos
            user.TemplateByte = Byte_FIR;
            user.template = m_textFIR.TextFIR.ToString();
        }

        public Boolean Comparar(string Digital)
        {
            // Declaração de variáveis locais
            uint ret;
            bool result;

            // Abre o dispositivo biométrico
            m_NBioAPI.OpenDevice(NBioAPI.Type.DEVICE_ID.AUTO);

            // Realiza a captura biométrica
            m_NBioAPI.Capture(out hCapturedFIR);

            // Define a impressão digital capturada como texto
            m_textFIR.TextFIR = Digital;

            // Realiza a verificação biométrica
            ret = m_NBioAPI.VerifyMatch(hCapturedFIR, m_textFIR, out result, myPayload);

            // Retorna o resultado da verificação
            return result;
        }

        public Boolean CompararBinario(int ID)
        {
            // Declaração de variáveis locais
            SQL sql = new SQL();
            DataTable digital = sql.ListarTemplate(ID);
            uint ret;
            bool result;

            // Declaração do objeto FIR biométrico
            NBioAPI.Type.FIR biFIR = new NBioAPI.Type.FIR();

            biFIR.Data = (byte[])digital.Rows[0]["TemplateByte"];
            //Não é necessário alterar esses valores.
            //Valores setados por padrão para a montagem do objeto.
            //Caso queira enviar os valores reais para o banco de dados, faça um debug no método Registro() e olha os atributos do 'out Byte_FIR'
            //na linha 59.
            biFIR.Header.DataLength = (uint)biFIR.Data.Length;
            biFIR.Header.DataType = 18;
            biFIR.Header.Length = 20;
            biFIR.Header.Purpose = 3;
            biFIR.Header.Quality = 100;
            biFIR.Header.Reserved = 0;
            biFIR.Header.Version = 1;
            biFIR.Format = 1;


            // Abre o dispositivo biométrico
            m_NBioAPI.OpenDevice(NBioAPI.Type.DEVICE_ID.AUTO);

            // Realiza a captura biométrica
            m_NBioAPI.Capture(out hCapturedFIR);

            // Realiza a verificação biométrica usando a representação binária da impressão digital do usuário
            //ret = m_NBioAPI.Verify(biFIR, out result, myPayload);
            ret = m_NBioAPI.VerifyMatch(hCapturedFIR, biFIR, out result, myPayload);

            // Retorna o resultado da verificação
            return result;
        }

        public string IndexSearch()
        {
            NBioAPI m_NBioAPI = new NBioAPI(); // Inicializa a API biométrica

            NBioAPI.Type.FIR_TEXTENCODE m_textFIR = new NBioAPI.Type.FIR_TEXTENCODE();

            NBioAPI.IndexSearch m_IndexSearch = new NBioAPI.IndexSearch(m_NBioAPI); // Inicializa o mecanismo de pesquisa biométrica

            NBioAPI.IndexSearch.CALLBACK_INFO_0 cbInfo0 = new NBioAPI.IndexSearch.CALLBACK_INFO_0();

            NBioAPI.IndexSearch.FP_INFO[] fpInfo; // Array para armazenar informações biométricas

            SQL sql = new SQL(); // Inicializa a classe SQL para interagir com o banco de dados

            DataTable DT = new DataTable(); // Cria uma tabela para armazenar dados do banco de dados

            NBioAPI.Type.FIR template = new NBioAPI.Type.FIR();

            DT = sql.ListarBinario(); // Preenche a tabela com dados biométricos do banco de dados

            m_IndexSearch.InitEngine(); // Inicializa o mecanismo de pesquisa biométrica

            for (int i = 0; i < DT.Rows.Count; i++)
            {
                uint id = Convert.ToUInt32(DT.Rows[i]["id"]);
                template.Data = (byte[])DT.Rows[i]["TemplateByte"]; // Obtém a impressão digital binária do banco de dados

                // Configura as informações da impressão digital
                //Não é necessário alterar esses valores.
                //Valores setados por padrão para a montagem do objeto.
                //Caso queira enviar os valores reais para o banco de dados, faça um debug no método Registro() e olha os atributos do 'out Byte_FIR'
                //na linha 59.
                template.Header.DataLength = (uint)template.Data.Length;
                template.Header.DataType = 18;
                template.Header.Length = 20;
                template.Header.Purpose = 3;
                template.Header.Quality = 100;
                template.Header.Reserved = 0;
                template.Header.Version = 1;
                template.Format = 1;
                m_IndexSearch.AddFIR(template, id, out fpInfo); // Adiciona a impressão digital à memória
            }

            m_IndexSearch.GetDataCount(out uint dataCount); // Obtém o número de dados de impressões digitais na memória

            m_NBioAPI.OpenDevice(NBioAPI.Type.DEVICE_ID.AUTO); // Abre o dispositivo biométrico

            uint ret;

            ret = m_NBioAPI.Capture(NBioAPI.Type.FIR_PURPOSE.VERIFY, out NBioAPI.Type.HFIR hCapturedFIR, NBioAPI.Type.TIMEOUT.DEFAULT, null, null); // Captura uma nova impressão digital

            if (ret != NBioAPI.Error.NONE)
            {
                m_IndexSearch.TerminateEngine(); // Encerra o mecanismo de pesquisa
                return "Erro na captura";
            }

            ret = m_IndexSearch.IdentifyData(hCapturedFIR, NBioAPI.Type.FIR_SECURITY_LEVEL.NORMAL, out NBioAPI.IndexSearch.FP_INFO fpInfo2, cbInfo0); // Realiza a busca da impressão digital capturada
            if (fpInfo2.ID != 0)
            {
                m_IndexSearch.TerminateEngine(); // Encerra o mecanismo de pesquisa
                return "Id da digital encontrada: " + fpInfo2.ID.ToString(); // Retorna o ID da impressão digital encontrada
            }

            m_IndexSearch.TerminateEngine(); // Encerra o mecanismo de pesquisa
            return "Não encontrado"; // Retorna uma mensagem indicando que a impressão digital não foi encontrada
        }

    }
}
