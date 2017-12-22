using System.ComponentModel;

namespace FGV.EBAPE.Utils.Enums
{
    public enum eSituacoesDistribuicaoOrientacao
    {
        [Description("Não possui orientação")]
        NAOPOSSUIORIENTACAO,
        [Description("Orientação foi solicitada")]
        ORIENTACAOSOLICITADA,
        [Description("Orientação foi aceita")]
        ORIENTACAOACEITA
    }
}