using System.ComponentModel;

namespace LIFE.JOY.Utils.Enums
{
    // string bodyTest = System.IO.File.ReadAllText("C:/Users/Amadeus/Desktop/email_FGV_HTML.html");
    public enum eMailHelper
    {
        /// <summary>
        /// / Enumerados de Orientacao 
        /// </summary>
        /// 



        //string bodyTest = System.IO.File.ReadAllText("C:/Users/Amadeus/Desktop/email_FGV_HTML.html");

        // Orientacao // 

        [Description("Foi realizada uma prorrogação de {0}, a mesma foi realizada por {1} com a justificativa: {2}."
             + "<br> O novo prazo para efetuar a entrega será de {3} até {4} <br>")]
        ProrrogacaoCadstrada,

        [Description("Foi realizada a edição da prorrogação de {0}, a mesma foi realizada por {1} com a justificativa: {2}."
             + "<br> O novo prazo para efetuar a entrega será de {3} até {4} <br>")]
        ProrrogacaoEditar,

        [Description("Foi realizada a exclusão da prorrogação de {0} a mesma foi realizada por {1}, com a justificativa: {2}.")]
        ProrrogacaoExcluir,

        
        // Orientacao // 

        [Description("Foi realizada uma solicitação de orientação em seu nome, para o(a) aluno(a): {0} "
            + "<br>Proposta de tema do(a) aluno(a): {1} ")]
        OrientacaoSolicitada,

        [Description("Foi realizada a aceitação de uma orientação, pelo(a) professor(a): <a href='{1}'>{0}</a>"
           + "<br>Essa orientação tem como aluno(a) o(a): {2}")]
        OrientacaoAceitaOrientador,

        [Description("Foi realizada a aceitação da sua orientação, pelo(a) professor(a): <a href='{1}'>{0}</a>")]
        OrientacaoAceitaAluno,


        // Projeto // 

        [Description("Foi realizada envio de projeto pelo(a) aluno(a): {0}"
            )]
        ProjetoSubmetidoSucesso,

        [Description("Seu projeto foi aprovado pelo(a) professor(a): <a href='{1}'>{0}</a> e será protocolado na SRA (Secretaria de Registros Acadêmicos)."
           + "<br> Observações <br> {2}")]
        ProjetoAprovado,

        [Description("O seu projeto teve revisão solicitada pelo(a) professor(a): <a href='{1}'>{0}</a><br>"
            + "<br> Com a justificativa: <br> {2}" 
            + "<br> Acesse o sistema para enviar uma nova versão de seu projeto.")]
        ProjetoReprovado, 


        // Tese Pre //

        [Description("Foi entregue a versão preliminar do trabalho final do(a) aluno(a):  {0} <br>"
            )]
        TesePreSubmetidoSucesso,

        [Description("Sua versão preliminar do trabalho final foi aceita pelo(a) professor(a):  <a href='{1}'>{0}</a> <br>"
            )]
        TesePreSubmetidoAprovado,

        [Description("Sua versão preliminar do trabalho final teve revisão solicitada pelo(a) professor(a): <a href='{1}'>{0}</a> <br>"
          + "<br> Com a justificativa: <br> {2}"
          + "<br> Acesse o sistema para enviar uma nova versão preliminar do trabalho final.")]
        TesePreSubmetidoReprovado,

        // Banca // 

        [Description("Foi realizada a solicitação de marcação de banca do(a)aluno(a):  {0} <br>"
            )]
        BancaSubmetidoSucesso,

        [Description("Sua marcação de banca foi aceita pelo(a) professor(a): <a href='{1}'>{0}</a> e será protocolado na SRA (Secretaria de Registros Acadêmicos)."
           )]
        BancaAprovada,

        [Description("Sua marcação de banca final teve pedido de revisão solicitada pelo(a) professor(a): pelo(a) professor(a): <a href='{1}'>{0}</a> <br>"
            + "<br> Com a justificativa: <br> {2}"
            + "<br> Acesse o sistema para enviar uma nova versão de sua marcação de banca final.")]
        BancaReprovada,

        [Description("Sua marcação de banca final teve pedido de revisão solicitada pelo setor de regulação"
            + "<br> Com a justificativa: <br> {0}"
            + "<br> Acesse o sistema para efetuar uma nova marcação de banca final.")]
        BancaReprovadaRegulacao,

        [Description("Sua banca foi agendada para o dia: {0}"
            + ", horário {1} "
            +"e na sala {2}")]
        BancaAgendadeAluno,

        [Description("A banca do seu aluno(a): {0}"
            + "\nFoi agendada para o dia {1} "
            + ", horário {2} "
            +" e na sala {3}"
            )]
        BancaAgendaProfessor,


        // Defesa //

        [Description("Sua defesa trabalho final foi aprovada pelo(a) professor(a): <a href='{1}'>{0}</a>"

           )]
        DefesaAprovada,

        [Description("Sua defesa de trabalho final foi Reprovada pelo(a) professor(a): <a href='{1}'>{0}</a>"
             + "<br> Com a justificativa: <br> {2}"

           )]
        DefesaReprovada,

        [Description("Sua defesa de trabalho final foi aprovada com 30 dias para entrega pelo pelo(a) professor(a): <a href='{1}'>{0}</a>"
            + "<br> Com a justificativa: <br> {2}"
          )]
        DefesaAPROVADA30DIAS,

        [Description("Sua defesa de trabalho final foi aprovada com 60 dias para entrega pelo pelo(a) professor(a): <a href='{1}'>{0}</a>"
            + "<br> Com a justificativa: <br> {2}"
          )]
        DefesaAPROVADA60DIAS,

        // tese Final //
        [Description("Foi entregue o trabalho final do(a) aluno(a):{0}"

            )]
        TeseFinalEntregar,

        [Description("Seu trabalho final foi aceito pelo(a) professor(a): <a href='{1}'>{0}</a>"

            )]
        TeseFinalAprovar,
        [Description("Seu trabalho final teve revisão solicitada pelo(a) professor(a): <a href='{1}'>{0}</a>"
            + "<br> Com a justificativa: <br> {2}"
            + "<br> Acesse o sistema para enviar uma nova versão de seu trabalho final."
            )]
        TeseFinalReprovar,
    }
}
