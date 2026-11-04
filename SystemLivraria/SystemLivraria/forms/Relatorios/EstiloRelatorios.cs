using System;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using System.Xml.Linq;

namespace SystemLivraria.forms.Relatorios
{
    internal static class EstiloRelatorios
    {
        private const string Azul = "#123252";

        internal static string Aplicar(string xml, string titulo)
        {
            var doc = XDocument.Parse(xml);

            XElement report = doc.Root;
            XNamespace r = report.Name.Namespace;

            XElement page = report.Element(r + "Page");
            XElement body = report.Element(r + "Body");

            if (page == null || body == null)
            {
                throw new InvalidOperationException(
                    "O layout precisa conter Body e Page.");
            }

            XElement itens = body.Element(r + "ReportItems");

            if (itens == null)
            {
                throw new InvalidOperationException(
                    "O relatório não possui itens.");
            }

            // Pequena folga para evitar ultrapassar a largura do papel.
            double area =
                Cm((string)page.Element(r + "PageWidth") ?? "21cm")
                - Cm((string)page.Element(r + "LeftMargin") ?? "1cm")
                - Cm((string)page.Element(r + "RightMargin") ?? "1cm")
                - 0.05;

            if (area <= 0)
            {
                throw new InvalidOperationException(
                    "Margens maiores que a página.");
            }

            report.SetElementValue(r + "Width", Medida(area));

            string subtitulo = page
                .Descendants(r + "Textbox")
                .Where(t => (string)t.Attribute("Name") == "CabecalhoPeriodo")
                .SelectMany(t => t.Descendants(r + "Value"))
                .Select(v => v.Value)
                .FirstOrDefault() ?? "";

            string[] nomesPeriodo =
            {
                "Periodo",
                "DataConsulta",
                "Subtitulo",
                "SubtituloRelatorio"
            };

            // Retira os títulos antigos do corpo.
            // Eles serão colocados no cabeçalho da página.
            foreach (var item in itens.Elements(r + "Textbox").ToList())
            {
                string nome = (string)item.Attribute("Name");

                if (nomesPeriodo.Contains(nome))
                {
                    subtitulo = item.Descendants(r + "Value")
                        .Select(v => v.Value)
                        .FirstOrDefault() ?? "";

                    item.Remove();
                }
                else if (nome == "Titulo" || nome == "TituloRelatorio")
                {
                    item.Remove();
                }
            }

            var tabelas = itens.Elements(r + "Tablix").ToList();

            double deslocamento = tabelas.Count == 0
                ? 0
                : Math.Max(
                    0,
                    tabelas.Min(t => Cm((string)t.Element(r + "Top")))
                    - 0.15);

            foreach (var item in itens.Elements())
            {
                item.SetElementValue(
                    r + "Top",
                    Medida(Math.Max(
                        0,
                        Cm((string)item.Element(r + "Top"))
                        - deslocamento)));
            }

            foreach (var tabela in tabelas)
            {
                var colunas = tabela
                    .Descendants(r + "TablixColumn")
                    .ToList();

                double largura = colunas.Sum(
                    c => Cm((string)c.Element(r + "Width")));

                if (largura <= 0)
                {
                    throw new InvalidOperationException(
                        "Tabela sem largura.");
                }

                double escala = Math.Min(1, area / largura);

                foreach (var coluna in colunas)
                {
                    coluna.SetElementValue(
                        r + "Width",
                        Medida(
                            Cm((string)coluna.Element(r + "Width"))
                            * escala));
                }

                largura = colunas.Sum(
                    c => Cm((string)c.Element(r + "Width")));

                tabela.SetElementValue(r + "Width", Medida(largura));

                // Centraliza a tabela na área útil.
                tabela.SetElementValue(
                    r + "Left",
                    Medida(Math.Max(0, (area - largura) / 2)));

                var linhas = tabela
                    .Element(r + "TablixBody")
                    .Element(r + "TablixRows")
                    .Elements(r + "TablixRow")
                    .ToList();

                for (int i = 0; i < linhas.Count; i++)
                {
                    bool cabecalho = i == 0;
                    bool total =
                        i == linhas.Count - 1 && linhas.Count > 2;

                    foreach (var caixa in linhas[i]
                        .Descendants(r + "Textbox"))
                    {
                        var estilo = Garantir(caixa, r + "Style");

                        estilo.SetElementValue(
                            r + "BackgroundColor",
                            cabecalho ? Azul
                            : total ? "#E8EFF7"
                            : "=IIF(RowNumber(Nothing) Mod 2 = 0, " +
                              "\"#F3F6FB\", \"White\")");

                        var borda = Garantir(estilo, r + "Border");

                        borda.SetElementValue(r + "Color", "#D9E2ED");
                        borda.SetElementValue(r + "Style", "Solid");

                        foreach (var trecho in caixa
                            .Descendants(r + "TextRun"))
                        {
                            var fonte = Garantir(trecho, r + "Style");

                            fonte.SetElementValue(
                                r + "FontFamily", "Arial");

                            fonte.SetElementValue(
                                r + "FontSize", "9pt");

                            fonte.SetElementValue(
                                r + "Color",
                                cabecalho ? "White" : "#24364B");

                            fonte.SetElementValue(
                                r + "FontWeight",
                                cabecalho || total ? "Bold" : "Normal");
                        }

                        if (cabecalho)
                        {
                            foreach (var paragrafo in caixa
                                .Descendants(r + "Paragraph"))
                            {
                                Garantir(paragrafo, r + "Style")
                                    .SetElementValue(
                                        r + "TextAlign", "Center");
                            }
                        }
                    }
                }
            }

            // Centraliza os resumos que ficam abaixo da tabela.
            foreach (var caixa in itens.Elements(r + "Textbox"))
            {
                caixa.SetElementValue(r + "Left", "0cm");
                caixa.SetElementValue(r + "Width", Medida(area));

                foreach (var p in caixa.Descendants(r + "Paragraph"))
                {
                    Garantir(p, r + "Style")
                        .SetElementValue(r + "TextAlign", "Center");
                }
            }

            double altura = itens.Elements()
                .Select(i =>
                    Cm((string)i.Element(r + "Top"))
                    + Cm((string)i.Element(r + "Height")))
                .DefaultIfEmpty(1)
                .Max();

            body.SetElementValue(r + "Height", Medida(altura + 0.1));

            page.Elements(r + "PageHeader").Remove();
            page.Elements(r + "PageFooter").Remove();

            // Cabeçalho repetido em todas as páginas.
            page.Add(
                new XElement(
                    r + "PageHeader",
                    new XElement(r + "Height", "1.8cm"),
                    new XElement(r + "PrintOnFirstPage", "true"),
                    new XElement(r + "PrintOnLastPage", "true"),
                    new XElement(
                        r + "ReportItems",

                        Faixa(
                            r,
                            "FaixaTitulo",
                            area,
                            "1cm",
                            Texto(
                                r, "CabecalhoTitulo", titulo,
                                0.2, 0.12, area - 0.4, 0.75,
                                "14pt", "White", "Center", true)),

                        Texto(
                            r, "CabecalhoPeriodo", subtitulo,
                            0, 1.05, area, 0.65,
                            "8pt", Azul, "Center", false))));

            string logo = LerLogo();
            XElement imagem = null;

            if (logo != null)
            {
                var imagens = Garantir(report, r + "EmbeddedImages");

                imagens.Elements(r + "EmbeddedImage")
                    .Where(e =>
                        (string)e.Attribute("Name") == "LogoRelatorios")
                    .Remove();

                imagens.Add(
                    new XElement(
                        r + "EmbeddedImage",
                        new XAttribute("Name", "LogoRelatorios"),
                        new XElement(r + "MIMEType", "image/png"),
                        new XElement(r + "ImageData", logo)));

                imagem = new XElement(
                    r + "Image",
                    new XAttribute("Name", "LogoRodape"),
                    new XElement(r + "Source", "Embedded"),
                    new XElement(r + "Value", "LogoRelatorios"),
                    new XElement(r + "Sizing", "FitProportional"),
                    new XElement(r + "Top", "0.1cm"),
                    new XElement(r + "Left", "0.2cm"),
                    new XElement(r + "Height", "1.1cm"),
                    new XElement(r + "Width", "1.3cm"),
                    new XElement(r + "Style"));
            }

            // Rodapé com logo e numeração.
            page.Add(
                new XElement(
                    r + "PageFooter",
                    new XElement(r + "Height", "1.5cm"),
                    new XElement(r + "PrintOnFirstPage", "true"),
                    new XElement(r + "PrintOnLastPage", "true"),
                    new XElement(
                        r + "ReportItems",
                        Faixa(
                            r,
                            "FaixaRodape",
                            area,
                            "1.3cm",
                            imagem,

                            Texto(
                                r, "MarcaRodape", "Livraria",
                                logo == null ? 0.3 : 1.7,
                                0.35, area - 8, 0.6,
                                "10pt", "White", "Left", true),

                            Texto(
                                r,
                                "Paginacao",
                                "=\"Página \" & Globals!PageNumber & " +
                                "\" de \" & Globals!TotalPages",
                                area - 6, 0.35, 5.7, 0.6,
                                "9pt", "White", "Right", false)))));

            return doc.ToString();
        }

        private static XElement Texto(
            XNamespace r,
            string nome,
            string valor,
            double esquerda,
            double topo,
            double largura,
            double altura,
            string tamanho,
            string cor,
            string alinhamento,
            bool negrito)
        {
            return new XElement(
                r + "Textbox",
                new XAttribute("Name", nome),
                new XElement(r + "CanGrow", "true"),
                new XElement(r + "KeepTogether", "true"),

                new XElement(
                    r + "Paragraphs",
                    new XElement(
                        r + "Paragraph",
                        new XElement(
                            r + "TextRuns",
                            new XElement(
                                r + "TextRun",
                                new XElement(r + "Value", valor),
                                new XElement(
                                    r + "Style",
                                    new XElement(r + "FontFamily", "Arial"),
                                    new XElement(r + "FontSize", tamanho),
                                    new XElement(r + "Color", cor),
                                    new XElement(
                                        r + "FontWeight",
                                        negrito ? "Bold" : "Normal")))),
                        new XElement(
                            r + "Style",
                            new XElement(r + "TextAlign", alinhamento)))),

                new XElement(r + "Top", Medida(topo)),
                new XElement(r + "Left", Medida(esquerda)),
                new XElement(r + "Width", Medida(largura)),
                new XElement(r + "Height", Medida(altura)),

                new XElement(
                    r + "Style",
                    new XElement(r + "VerticalAlign", "Middle")));
        }

        private static XElement Faixa(
            XNamespace r,
            string nome,
            double largura,
            string altura,
            params object[] itens)
        {
            return new XElement(
                r + "Rectangle",
                new XAttribute("Name", nome),
                new XElement(r + "ReportItems", itens),
                new XElement(r + "Top", "0cm"),
                new XElement(r + "Left", "0cm"),
                new XElement(r + "Width", Medida(largura)),
                new XElement(r + "Height", altura),
                new XElement(
                    r + "Style",
                    new XElement(r + "BackgroundColor", Azul)));
        }

        private static string LerLogo()
        {
            var assembly = Assembly.GetExecutingAssembly();

            string nome = assembly.GetManifestResourceNames()
                .FirstOrDefault(n =>
                    n.EndsWith(
                        ".logobranca.png",
                        StringComparison.OrdinalIgnoreCase));

            if (nome == null)
                return null;

            using (var origem = assembly.GetManifestResourceStream(nome))
            using (var destino = new MemoryStream())
            {
                if (origem == null)
                    return null;

                origem.CopyTo(destino);

                return Convert.ToBase64String(destino.ToArray());
            }
        }

        private static XElement Garantir(XElement pai, XName nome)
        {
            var elemento = pai.Element(nome);

            if (elemento == null)
            {
                elemento = new XElement(nome);
                pai.Add(elemento);
            }

            return elemento;
        }

        private static double Cm(string medida)
        {
            if (string.IsNullOrEmpty(medida))
                return 0;

            var m = Regex.Match(
                medida.Trim(),
                @"^([+-]?\d+(?:\.\d+)?)(cm|mm|in|pt)$");

            if (!m.Success)
            {
                throw new InvalidOperationException(
                    "Medida inválida: " + medida);
            }

            double valor = double.Parse(
                m.Groups[1].Value,
                CultureInfo.InvariantCulture);

            switch (m.Groups[2].Value)
            {
                case "mm": return valor / 10;
                case "in": return valor * 2.54;
                case "pt": return valor * 2.54 / 72;
                default: return valor;
            }
        }

        private static string Medida(double valor)
        {
            return valor.ToString(
                "0.###",
                CultureInfo.InvariantCulture) + "cm";
        }
    }

    internal static class JanelaRelatorios
    {
        internal static void Ajustar(Form janela, Control painel)
        {
            janela.WindowState = FormWindowState.Normal;
            janela.Dock = DockStyle.None;
            janela.StartPosition = FormStartPosition.Manual;

            janela.Size = new Size(
                Math.Min(
                    janela.Width,
                    Math.Min(820, Math.Max(1, painel.ClientSize.Width - 24))),
                Math.Min(
                    janela.Height,
                    Math.Min(520, Math.Max(1, painel.ClientSize.Height - 24))));

            janela.Location = new Point(
                Math.Max(0, (painel.ClientSize.Width - janela.Width) / 2),
                Math.Max(0, (painel.ClientSize.Height - janela.Height) / 2));

            var titulo = janela.Controls["cabecalhoRelatorio"] as Label;

            if (titulo == null)
            {
                var fonte = new Font(
                    "Segoe UI", 12, FontStyle.Bold);

                titulo = new Label
                {
                    Name = "cabecalhoRelatorio",
                    Dock = DockStyle.Top,
                    Height = 42,
                    BackColor = Color.FromArgb(18, 50, 82),
                    ForeColor = Color.White,
                    TextAlign = ContentAlignment.MiddleCenter,
                    Font = fonte
                };

                janela.Controls.Add(titulo);
                titulo.SendToBack();

                janela.Disposed += delegate { fonte.Dispose(); };
            }

            titulo.Text = janela.Text;
        }
    }
}