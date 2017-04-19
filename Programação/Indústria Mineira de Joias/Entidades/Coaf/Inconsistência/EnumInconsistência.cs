namespace Entidades.Coaf.Inconsistência
{
    public enum EnumInconsistência : uint
    {
        PJSemPreposto = 1,
        PessoaFísicaSemCPF = 2,
        IdentidadeInválida = 3,
        OrgãoEmissorInválido = 4,
        PFNomeInválido = 5,
        PrepostoSemNome = 12,
        PrepostoIdentidadeInválida = 13,
        PrepostoÓrgãoEmissorInválido = 14,
        PJNomeFantasiaInválido = 15,
        PJRazãoSocialInválido = 16
    }
}
