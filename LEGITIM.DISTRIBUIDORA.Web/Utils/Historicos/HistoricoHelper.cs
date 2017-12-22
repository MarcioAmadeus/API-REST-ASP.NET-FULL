//using System;
//using System.Linq;
//using LEGITIM.DISTRIBUIDORA.Domain.Models.Basic;
//using LEGITIM.DISTRIBUIDORA.Utils.Enums;
//using LEGITIM.DISTRIBUIDORA.Web.Utils.Usuarios;
//using SharpArch.Domain.PersistenceSupport;
//using System.Web;

//namespace LEGITIM.DISTRIBUIDORA.Web.Utils.Historicos
//{
//    public class HistoricoHelper
//    {
//        private readonly IRepository<Historico> _historicoRepository;
//        private readonly IRepository<Professor> _professorRepository;
//        private readonly IRepository<Orientacao> _orientacaoRepository;

//        public HistoricoHelper(IRepository<Historico> historicoRepository,
//            IRepository<Professor> professorRepository,
//            IRepository<Orientacao> orientacaoRepository)
//        {
//            _historicoRepository = historicoRepository;
//            _professorRepository = professorRepository;
//            _orientacaoRepository = orientacaoRepository;
//        }

//        public void salvarProjeto(string situacao, Projeto projeto)
//        {
//            int professorId = 0;
//            var orientacao = _orientacaoRepository.GetAll().ToList();
//            var orientacaoCount = orientacao.Count;
//            var orientacaoprofessor = orientacao.FirstOrDefault(x => x.Aluno.Id == projeto.Aluno.Id);

//            if (orientacaoCount > 0 &&
//                orientacaoprofessor != null)
//            {
//                professorId = _orientacaoRepository.GetAll().FirstOrDefault(x => x.Aluno.Id == projeto.Aluno.Id).Professor.Id;
//            }
//            var hitorico = new Historico()
//            {
//                Origem = eOrigemHistorico.Projeto,
//                Situacao = situacao,
//                UsuarioId = UsuarioAtual.getUsuarioLogado().Id,
//                DataHistorico = DateTime.Today,
//                Projeto = projeto,
//                AlunoId = projeto.Aluno.Id,
//                ProfessorId = professorId
//            };
//            _historicoRepository.SaveOrUpdate(hitorico);
//        }

//        public void salvarProjeto(string situacao, Projeto projeto, string justificativa)
//        {
//            var hitorico = new Historico()
//            {
//                Origem = eOrigemHistorico.Projeto,
//                Situacao = situacao,
//                Justificativa = justificativa,
//                UsuarioId = UsuarioAtual.getUsuarioLogado().Id,
//                DataHistorico = DateTime.Today,
//                Projeto = projeto,
//                AlunoId = projeto.Aluno.Id,
//                ProfessorId = _professorRepository.GetAll().FirstOrDefault(x => x.Usuario.Id == UsuarioAtual.getUsuarioLogado().Id).Id
//            };

//            _historicoRepository.SaveOrUpdate(hitorico);
//        }

//        public void salvarOrientacao(string situacao, Orientacao orientacao)
//        {
//            var hitorico = new Historico()
//            {
//                Origem = eOrigemHistorico.Orientacao,
//                Situacao = situacao,
//                UsuarioId = UsuarioAtual.getUsuarioLogado().Id,
//                DataHistorico = DateTime.Today,
//                Orientacao = orientacao,
//                AlunoId = orientacao.Aluno.Id,
//                ProfessorId = orientacao.Professor.Id

//            };

//            _historicoRepository.SaveOrUpdate(hitorico);
//        }

//        public void salvarBanca(string situacao, Banca banca)
//        {
//            var hitorico = new Historico()
//            {
//                Origem = eOrigemHistorico.Banca,
//                Situacao = situacao,
//                UsuarioId = UsuarioAtual.getUsuarioLogado().Id,
//                DataHistorico = DateTime.Today,
//                Banca = banca,
//                AlunoId = banca.Projeto.Aluno.Id,
//                ProfessorId = banca.Orientador.Id

//            };

//            _historicoRepository.SaveOrUpdate(hitorico);
//        }

//        public void salvarBanca(string situacao, Banca banca, string justificativa)
//        {
//            var hitorico = new Historico()
//            {
//                Origem = eOrigemHistorico.Banca,
//                Situacao = situacao,
//                Justificativa = justificativa,
//                UsuarioId = UsuarioAtual.getUsuarioLogado().Id,
//                DataHistorico = DateTime.Today,
//                Banca = banca,
//                AlunoId = banca.Projeto.Aluno.Id,
//                ProfessorId = banca.Orientador.Id
//            };

//            _historicoRepository.SaveOrUpdate(hitorico);
//        }

//        public void salvarProrrogacao(string situacao, Prorrogacao prorrogacao, string justificativa)
//        {

//            var hitorico = new Historico()
//            {
//                Origem = eOrigemHistorico.Prorrogacao,
//                Situacao = situacao,
//                Justificativa = justificativa,
//                UsuarioId = UsuarioAtual.getUsuarioLogado().Id,
//                DataHistorico = DateTime.Today,
//                Prorrogacao = prorrogacao,
//                AlunoId = prorrogacao.Aluno.Id,
//            };
//            if (prorrogacao.Evento != eEventos.PREPROJETO)
//            {
//                var orientacao = _orientacaoRepository.GetAll().FirstOrDefault(x => x.Aluno.Id == prorrogacao.Aluno.Id);
//                if (orientacao != null)
//                {
//                    hitorico.ProfessorId = orientacao.Professor.Id;
//                }
//            }

//            _historicoRepository.SaveOrUpdate(hitorico);
//        }
//    }
//}