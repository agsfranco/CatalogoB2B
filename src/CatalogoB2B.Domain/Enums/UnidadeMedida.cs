using System;
using System.ComponentModel;
using System.Reflection;

namespace CatalogoB2B.Domain.Enums
{
    public enum UnidadeMedida
    {
        // ==========================================
        // UNIDADE E EMBALAGEM
        // ==========================================
        [Description("Unidade")]
        UN = 1,

        [Description("Peça")]
        PC = 2,

        [Description("Caixa")]
        CX = 3,

        [Description("Pacote")]
        PCT = 4,

        [Description("Conjunto")]
        CJ = 5,

        [Description("Par")]
        PAR = 6,

        [Description("Kit")]
        KIT = 7,

        [Description("Jogo")]
        JG = 8,

        [Description("Fardo")]
        FD = 9,

        [Description("Dúzia")]
        DZ = 10,

        [Description("Cento")]
        CN = 11,

        [Description("Milheiro")]
        MIL = 12,

        [Description("Rolo")]
        RL = 13,

        [Description("Bobina")]
        BOB = 14,

        [Description("Cartela")]
        CART = 15,

        [Description("Cápsula")]
        CAPS = 16,

        [Description("Frasco")]
        FR = 17,

        [Description("Ampola")]
        AMP = 18,

        [Description("Bisnaga")]
        BIS = 19,

        [Description("Saco")]
        SC = 20,

        [Description("Lata")]
        LT = 21,

        [Description("Garrafa")]
        GF = 22,

        [Description("Bandeja")]
        BDJ = 23,

        [Description("Palete")]
        PLT = 24,

        [Description("Balde")]
        BD = 25,

        [Description("Tambor")]
        TB = 26,

        [Description("Folha")]
        FL = 27,

        [Description("Bloco")]
        BL = 28,

        // ==========================================
        // PESO (MASSA)
        // ==========================================
        [Description("Quilograma")]
        KG = 100,

        [Description("Grama")]
        G = 101,

        [Description("Miligrama")]
        MG = 102,

        [Description("Tonelada")]
        T = 103,

        // ==========================================
        // COMPRIMENTO
        // ==========================================
        [Description("Metro")]
        M = 200,

        [Description("Centímetro")]
        CM = 201,

        [Description("Milímetro")]
        MM = 202,

        [Description("Quilômetro")]
        KM = 203,

        [Description("Polegada")]
        POL = 204,

        // ==========================================
        // ÁREA
        // ==========================================
        [Description("Metro Quadrado")]
        M2 = 300,

        [Description("Centímetro Quadrado")]
        CM2 = 301,

        [Description("Hectare")]
        HA = 302,

        // ==========================================
        // VOLUME E CAPACIDADE
        // ==========================================
        [Description("Litro")]
        L = 400,

        [Description("Mililitro")]
        ML = 401,

        [Description("Metro Cúbico")]
        M3 = 402,

        [Description("Centímetro Cúbico")]
        CM3 = 403,

        [Description("Galão")]
        GL = 404,

        [Description("Barril")]
        BBL = 405
    }

    // Método de extensão
    public static class UnidadeMedidaExtensions
    {
        public static string ObterDescricao(this UnidadeMedida unidade)
        {
            FieldInfo? field = unidade.GetType().GetField(unidade.ToString());
            if (field == null) return unidade.ToString();

            var attribute = Attribute.GetCustomAttribute(field, typeof(DescriptionAttribute)) as DescriptionAttribute;
            return attribute?.Description ?? unidade.ToString();
        }

        public static string ObterSigla(this UnidadeMedida unidade)
        {
            return unidade.ToString();
        }

        public static string ObterDescricaoCompleta(this UnidadeMedida unidade)
        {
            return $"{unidade.ObterSigla()} - {unidade.ObterDescricao()}";
        }
    }
}
