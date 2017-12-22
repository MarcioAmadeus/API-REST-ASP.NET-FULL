
    PRAGMA foreign_keys = OFF;

    drop table if exists LEGITIM_DISTRIBUIDORA_PERFIL;

    drop table if exists LEGITIM_DISTRIBUIDORA_PERFIL_ACAO;

    drop table if exists LEGITIM_DISTRIBUIDORA_ACAO;

    drop table if exists LEGITIM_DISTRIBUIDORA_USUARIO;

    drop table if exists LEGITIM_DISTRIBUIDORA_ALUNO;

    PRAGMA foreign_keys = ON;

    create table LEGITIM_DISTRIBUIDORA_PERFIL (
        SQ_PERFIL  integer primary key autoincrement,
       ATIVO TEXT default 'S'  not null,
       DESCRICAO TEXT not null
    );

    create table LEGITIM_DISTRIBUIDORA_PERFIL_ACAO (
        SQ_PERFIL INT not null,
       SQ_ACAO INT not null,
       constraint FKF8C871125B480EC foreign key (SQ_ACAO) references LEGITIM_DISTRIBUIDORA_ACAO,
       constraint FKF8C871128506D16F foreign key (SQ_PERFIL) references LEGITIM_DISTRIBUIDORA_PERFIL
    );

    create table LEGITIM_DISTRIBUIDORA_ACAO (
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

    create table LEGITIM_DISTRIBUIDORA_USUARIO (
        SQ_USUARIO  integer primary key autoincrement,
       ATIVO TEXT default 'S'  not null,
       NOME TEXT not null,
       PATH TEXT,
       FOLDER_PHOTO TEXT,
       LOGIN TEXT not null,
       EMAIL TEXT not null,
       SENHA TEXT not null,
       PESSOAID TEXT,
       SQ_PERFIL INT not null,
       constraint FK_PERFIL foreign key (SQ_PERFIL) references LEGITIM_DISTRIBUIDORA_PERFIL
    );

    create table LEGITIM_DISTRIBUIDORA_ALUNO (
        SQ_ALUNO  integer primary key autoincrement,
       ATIVO TEXT default 'S'  not null,
       NOME TEXT not null
    );
