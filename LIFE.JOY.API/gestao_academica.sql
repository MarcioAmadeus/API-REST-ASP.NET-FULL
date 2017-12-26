
    PRAGMA foreign_keys = OFF;

    drop table if exists GESTAO_ACADEMICA_PERFIL;

    drop table if exists GESTAO_ACADEMICA_PERFIL_ACAO;

    drop table if exists GESTAO_ACADEMICA_ACAO;

    drop table if exists GESTAO_ACADEMICA_USUARIO;

    drop table if exists GESTAO_ACADEMICA_ALUNO;

    PRAGMA foreign_keys = ON;

    create table GESTAO_ACADEMICA_PERFIL (
        SQ_PERFIL  integer primary key autoincrement,
       ATIVO TEXT default 'S'  not null,
       DESCRICAO TEXT not null
    );

    create table GESTAO_ACADEMICA_PERFIL_ACAO (
        SQ_PERFIL INT not null,
       SQ_ACAO INT not null,
       constraint FKF8C8711260A4599D foreign key (SQ_ACAO) references GESTAO_ACADEMICA_ACAO,
       constraint FKF8C8711246E2A34B foreign key (SQ_PERFIL) references GESTAO_ACADEMICA_PERFIL
    );

    create table GESTAO_ACADEMICA_ACAO (
        SQ_ACAO  integer primary key autoincrement,
       ATIVO TEXT default 'S'  not null,
       CONTROLLER TEXT not null,
       ACTION TEXT not null,
       URL TEXT not null,
       PRIORIDADE INT,
       PAI TEXT,
       PRIORIDADE_INTERNA INT,
       VISIVEL_MENU TEXT default 'S'  not null
    );

    create table GESTAO_ACADEMICA_USUARIO (
        SQ_USUARIO  integer primary key autoincrement,
       ATIVO TEXT default 'S'  not null,
       NOME TEXT not null,
       LOGIN TEXT not null,
       EMAIL TEXT not null,
       SENHA TEXT not null,
       PESSOAID TEXT,
       SQ_PERFIL INT not null,
       constraint FK_PERFIL foreign key (SQ_PERFIL) references GESTAO_ACADEMICA_PERFIL
    );

    create table GESTAO_ACADEMICA_ALUNO (
        SQ_ALUNO  integer primary key autoincrement,
       ATIVO TEXT default 'S'  not null,
       NOME TEXT not null,
       MATRICULA TEXT not null,
       EMAIL_EXTERNO TEXT not null,
       EMAIL_INTERNO TEXT,
       SITUACAO TEXT,
       CURRICULO TEXT,
       DATA_INGRESSO DATE,
       LattesLink TEXT,
       ENDERECO_PROFISSIONAL TEXT,
       CARGO TEXT,
       TIPO_VINCULO TEXT,
       TIPO_INSTITUICAO TEXT,
       EXPECTATIVA_ATUACAO TEXT,
       MESMA_AREA_TRABALHO TEXT,
       PROGRAMA_FOMENTO TEXT,
       NUMERO_MESES_BOLSA INT
    );
