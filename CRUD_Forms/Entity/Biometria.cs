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
        NBioAPI.Type.HFIR hNewFIR;
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

            if (ret != NBioAPI.Error.NONE)
            {
                // Tratamento de erro, se necessário
                m_NBioAPI.CloseDevice(NBioAPI.Type.DEVICE_ID.AUTO);
            }

            // Fecha o dispositivo biométrico
            m_NBioAPI.CloseDevice(NBioAPI.Type.DEVICE_ID.AUTO);

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

        public Boolean CompararBinario(Model.User user)
        {
            // Declaração de variáveis locais
            SQL sql = new SQL();
            DataTable digital = sql.ListarTemplate(1);
            uint ret;
            bool result;

            // Declaração do objeto FIR biométrico
            NBioAPI.Type.FIR biFIR = new NBioAPI.Type.FIR();

            // Abre o dispositivo biométrico
            m_NBioAPI.OpenDevice(NBioAPI.Type.DEVICE_ID.AUTO);

            // Realiza a captura biométrica
            m_NBioAPI.Capture(out hCapturedFIR);

            // Realiza a verificação biométrica usando a representação binária da impressão digital do usuário
            ret = m_NBioAPI.VerifyMatch(hCapturedFIR, user.TemplateByte, out result, myPayload);

            // Retorna o resultado da verificação
            return result;
        }
    }
}
