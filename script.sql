USE [PrevisaoClimaticaDB]
GO

CREATE TABLE [dbo].[AeroportoPrevisao](
	[Id] [uniqueidentifier] NOT NULL,
	[CodigoIcao] [varchar](10) NOT NULL,
	[UltimaAtualizacao] [datetime2](7) NOT NULL,
	[PressaoAtmosferica] [int] NOT NULL,
	[Visibilidade] [varchar](200) NOT NULL,
	[Vento] [int] NOT NULL,
	[DirecaoVento] [int] NOT NULL,
	[Umidade] [int] NOT NULL,
	[Condicao] [varchar](100) NOT NULL,
	[DescricaoClima] [varchar](200) NOT NULL,
	[Tempo] [int] NOT NULL,
 CONSTRAINT [PK_AeroportoPrevisao] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

CREATE TABLE [dbo].[CidadePrevisao](
	[Id] [uniqueidentifier] NOT NULL,
	[Cidade] [varchar](150) NOT NULL,
	[Estado] [varchar](150) NOT NULL,
	[UltimaAtualizacao] [datetime2](7) NOT NULL,
	[Data] [datetime2](7) NOT NULL,
	[Condicao] [varchar](100) NOT NULL,
	[Min] [int] NOT NULL,
	[Max] [int] NOT NULL,
	[IndiceUV] [int] NOT NULL,
	[DescricaoClima] [varchar](200) NOT NULL,
 CONSTRAINT [PK_CidadePrevisao] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

CREATE TABLE [dbo].[Logs](
	[Id] [uniqueidentifier] NOT NULL,
	[Mensagem] [nvarchar](max) NOT NULL,
	[Data] [datetime2](7) NOT NULL,
 CONSTRAINT [PK_Logs] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
