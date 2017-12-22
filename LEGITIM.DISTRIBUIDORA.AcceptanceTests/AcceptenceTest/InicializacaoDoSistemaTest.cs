using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using NUnit.Framework;
using LEGITIM.DISTRIBUIDORA.AcceptanceTests.PageObject;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Support.UI;
using System.Drawing;
using System.Threading;


namespace LEGITIM.DISTRIBUIDORA.AcceptanceTests.AcceptenceTest
{
    [TestFixture]
    class InicializacaoDoSistemaTest
    {
        private linhaDePesquisaCadastraPage linhaDePesquisacadastro;
        private LoginPage login;
        private MockPage mock;
        private ImportaAlunoPage importarAluno;
        private ImportaProfessorPage importaProfessor;
        private ImportarOrientacao importarOrientacao;
        private CadastraUsuarioPage cadastraUsuario;
        private CadastraUsuarioCoordenadorPage cadastraUsuarioCoordenador;
        private CadastraEventoPage cadastraEvento;
        private ListarEventosPage listarEventos;
        private PerfilUsuarioPage perfilAluno;
        private EditarTurmaDataFimPage EditarTurma;
        private KitSubmissaoPage KitSubmissao;
        private CadastraMembroExterno CadastraMembroExterno;

        public InicializacaoDoSistemaTest()
        {

            IWebDriver driver = new FirefoxDriver();
            //
            //IWebDriver driver = new ChromeDriver();

            this.linhaDePesquisacadastro = new linhaDePesquisaCadastraPage(driver);
            this.login = new LoginPage(driver);
            this.mock = new MockPage(driver);
            this.importarAluno = new ImportaAlunoPage(driver);
            this.importaProfessor = new ImportaProfessorPage(driver);
            this.importarOrientacao = new ImportarOrientacao(driver);
            this.cadastraUsuario = new CadastraUsuarioPage(driver);
            this.cadastraUsuarioCoordenador = new CadastraUsuarioCoordenadorPage(driver);
            this.cadastraEvento = new CadastraEventoPage(driver);
            this.listarEventos = new ListarEventosPage(driver);
            this.perfilAluno = new PerfilUsuarioPage(driver);
            this.EditarTurma = new EditarTurmaDataFimPage(driver);
            this.KitSubmissao = new KitSubmissaoPage(driver);
            this.CadastraMembroExterno = new CadastraMembroExterno(driver);
        }

        [Test]
        public void Test0_mock()
        {
            mock.visita();
        }

        [Test]
        public void Test001_logar()
        {
            login.visita();
            login.logar("admsistema", "123");
        }

        [Test]
        public void Test02_ImportaAluno()
        {
            importarAluno.visita(); 
            importarAluno.upload(@"C:\Projetos\FGV-EBAPE\System\LEGITIM.DISTRIBUIDORA.Web\Content\importacoes\alunos-reduzido.csv");
        }

        [Test]
        public void Test03_ImportaProfessor()
        {
            importaProfessor.visita();  
            importaProfessor.upload(@"C:\Projetos\FGV-EBAPE\System\LEGITIM.DISTRIBUIDORA.Web\Content\importacoes\professoresmap-atualizado.csv", "182");
        }

        [Test]
        public void Test04_ImportaOrientacoes()
        {
            importarOrientacao.visita();
            importarOrientacao.upload(@"C:\Projetos\FGV-EBAPE\System\LEGITIM.DISTRIBUIDORA.Web\Content\importacoes\orientacoes.csv");
        }


        [Test]
        public void Test041_Membro_Externo()
        {
            CadastraMembroExterno.visita();
            CadastraMembroExterno.MenbroExternoAdicionar("Marcio Amadeus", "12484087721", "marcioamadeus@PUC-RIO.br", "988970663", "PUC-RIO");

        }

        [Test]
        public void Test042_Membro_Externo()
        {
            CadastraMembroExterno.visita();
            CadastraMembroExterno.MenbroExternoAdicionar("Jefferson Santos", "69852286749", "Jefferson@FGV.br", "988970662", "FGV");
        }

        [Test]
        public void Test05_cadastraLinhaDePesquisa()
        {
            linhaDePesquisacadastro.visita();
            linhaDePesquisacadastro.LinhaDePesquisaAdicionar("182", "MAP", "Políticas Públicas");
        }

        [Test]
        public void Test051_cadastraLinhaDePesquisa()
        {
            linhaDePesquisacadastro.visita();
            linhaDePesquisacadastro.LinhaDePesquisaAdicionar("182", "MAP", "Governança e Administração Pública");
        }
        [Test]
        public void Test052_cadastraLinhaDePesquisa()
        {
            linhaDePesquisacadastro.visita();
            linhaDePesquisacadastro.LinhaDePesquisaAdicionar("105", "MEX", "Estratégia Empresarial");
        }
        [Test]
        public void Test053_cadastraLinhaDePesquisa()
        {
            linhaDePesquisacadastro.visita();
            linhaDePesquisacadastro.LinhaDePesquisaAdicionar("105", "MEX", "Comportamento e Gestão Estratégica de Pessoas");
        }
        [Test]
        public void Test054_cadastraLinhaDePesquisa()
        {
            linhaDePesquisacadastro.visita();
            linhaDePesquisacadastro.LinhaDePesquisaAdicionar("105", "MEX", "Finanças Empresariais e Contabilidade");
        }

        [Test]
        public void Test055_cadastraCadastrarKit()
        {
            KitSubmissao.visita();
            KitSubmissao.KitSubmissaoAdicionar("182", "Prazo de entrega da versão preliminar do trabalho final",
                @"C:\Projetos\FGV-EBAPE\System\LEGITIM.DISTRIBUIDORA.Web\Content\importacoes\Kit_108_preliminar.zip");
        }

        [Test]
        public void Test056_cadastraCadastrarKit()
        {
            KitSubmissao.visita();
            KitSubmissao.KitSubmissaoAdicionar("182", "Prazo de entrega da versão do trabalho final",
                @"C:\Projetos\FGV-EBAPE\System\LEGITIM.DISTRIBUIDORA.Web\Content\importacoes\Kit_108_final.zip");
        }

        [Test]
        public void Test06_cadastrarUsuarios()
        {
            cadastraUsuario.visita();
            cadastraUsuario.UsuarioAdicionar("Aline F", "aline@fgv.com", "Administrador de Programa", "aline", "aline", "aline");
        }

        [Test]
        public void Test061_cadastrarUsuarios()
        {
            cadastraUsuario.visita();
            cadastraUsuario.UsuarioAdicionar("Marcelo", "marcelo@fgv.com", "Regulação", "marcelo", "marcelo", "marcelo");
        }

        [Test]
        public void Test07_cadastraUsuarioCoordenador()
        {
            cadastraUsuarioCoordenador.visita();
            cadastraUsuarioCoordenador.AdicionarCoordenador("182", "Roberto da Costa Pimenta", "Armando Santos Moreira da Cunha");
            /**/
        }

        [Test]
        public void Test08_cadastraEventoPreProjeto()
        {
            cadastraEvento.visita();
            cadastraEvento.Adicionarevento("182", "Mestrado Profissional em Administração Pública(2016)", "Prazo de detalhamento de tema", "Pre Projeto");
            /**/
        }
        [Test]
        public void Test09_cadastraEventoOrientacao()
        {
            cadastraEvento.visita();
            cadastraEvento.Adicionarevento("182", "Mestrado Profissional em Administração Pública(2016)", "Prazo de orientação", "Orientacao");
            /**/
        }

        [Test]
        public void Test10_cadastraEventoPrtojeto()
        {
            cadastraEvento.visita();
            cadastraEvento.Adicionarevento("182", "Mestrado Profissional em Administração Pública(2016)", "Prazo de projeto", "Projeto");
            /**/
        }
        [Test]
        public void Test11_cadastraEventoTesePre()
        {
            cadastraEvento.visita();
            cadastraEvento.Adicionarevento("182", "Mestrado Profissional em Administração Pública(2016)", "Prazo de entrega da versão preliminar do trabalho final", "Tese Preliminar");
            /**/
        }
        [Test]
        public void Test12_cadastraEventoBanca()
        {
            cadastraEvento.visita();
            cadastraEvento.Adicionarevento("182", "Mestrado Profissional em Administração Pública(2016)", "Prazo de defesa", "Banca");
            /**/
        }

        [Test]
        public void Test13_cadastraEventoTeseFinal()
        {
            cadastraEvento.visita();
            cadastraEvento.Adicionarevento("182", "Mestrado Profissional em Administração Pública(2016)", "Prazo de entrega da versão do trabalho final", "entrega da versão final");
            /**/
        }

        [Test]
        public void Test14_listarEventos()
        {
            listarEventos.visita();
        }

        [Test]
        public void Test17_editarTurma()
        {
            var test = "http://localhost:1654/Turma/EditarTurma?turmaId=4";
            EditarTurma.visita(test);
            EditarTurma.EditarTurma(2015);

            EditarTurma.visita("http://localhost:1654/Turma/EditarTurma?turmaId=19");
            EditarTurma.EditarTurma(2015);

            EditarTurma.visita("http://localhost:1654/Turma/EditarTurma?turmaId=18");
            EditarTurma.EditarTurma(2015);

            EditarTurma.visita("http://localhost:1654/Turma/EditarTurma?turmaId=1");
            EditarTurma.EditarTurma(2015);

            EditarTurma.visita("http://localhost:1654/Turma/EditarTurma?turmaId=14");
            EditarTurma.EditarTurma(2015);

            EditarTurma.visita("http://localhost:1654/Turma/EditarTurma?turmaId=6");
            EditarTurma.EditarTurma(2015);

            EditarTurma.visita("http://localhost:1654/Turma/EditarTurma?turmaId=3");
            EditarTurma.EditarTurma(2015);

            ///
            // 2016 //

            EditarTurma.visita("http://localhost:1654/Turma/EditarTurma?turmaId=9");
            EditarTurma.EditarTurma(2016);

            EditarTurma.visita("http://localhost:1654/Turma/EditarTurma?turmaId=16");
            EditarTurma.EditarTurma(2016);

            EditarTurma.visita("http://localhost:1654/Turma/EditarTurma?turmaId=7");
            EditarTurma.EditarTurma(2016);

            EditarTurma.visita("http://localhost:1654/Turma/EditarTurma?turmaId=22");
            EditarTurma.EditarTurma(2016);

            EditarTurma.visita("http://localhost:1654/Turma/EditarTurma?turmaId=8");
            EditarTurma.EditarTurma(2016);

            EditarTurma.visita("http://localhost:1654/Turma/EditarTurma?turmaId=12");
            EditarTurma.EditarTurma(2016);

            /**/
        }

    }
}
