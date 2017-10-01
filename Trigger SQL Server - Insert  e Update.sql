USE [DIRECTFACIL]
GO
/****** Object:  Trigger [dbo].[tg_insertAntCanaisLog]    Script Date: 01/16/2017 16:34:45 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Jeyson>
-- Create date: <12/01/2017>
-- Description:	<trigger que irá realizar insert na tabela AntecipacaoCanaisLog>
-- =============================================
ALTER TRIGGER [dbo].[tg_insertAntCanaisLog] 
   
  ON  [dbo].[AntecipacaoCanais] 
  
  --SERÁ EXECUTADO APENAS QUANDO REALIZAREM INSERT OU UPDATE NA TABELA AntecipacaoCanais
  FOR INSERT, UPDATE
  
AS 
	--INICIO BLOCO PRINCIPAL
	BEGIN
	
		--BLOCO DE VARIAVEIS
		DECLARE
			@idAnt		   int,
			@usrCodAnt     char(15),
			@dataInicioAnt date,
			@dataFinalAnt  date,
			@filtroData	   char(1),
			@valorBruto    money,
			@valorLiquido  money,
			@valorRepasse  money,
			@dataSolicAnt  datetime,
			@usrCodGrava   char(15),
			@dataGravaAnt  datetime,
			@statusAnt     bit,
			@nrRepasseAnt  int,
			@obsAnt		   varchar(500),
			@canalAnt      char(1)

		--INSERE O LOG DO INSERT
		IF EXISTS (SELECT * FROM INSERTED) AND NOT EXISTS (SELECT * FROM DELETED)--VERIFICA SE A MANIPULAÇÃO É DE INSERT
			
			--INICIO DO SUB BLOCO DO INSERT
			BEGIN
			
				PRINT 'Iniciando a Trigger.';
			
				PRINT 'Acao de INSERT';
	
				--FAZER UM TRY CATCH PARA A VALIDAÇÃO
				BEGIN TRY
				
					--REALIZA O SELECT DOS DADOS QUE ESTÃO ENTRANDO NA TABELA
					SELECT
						@idAnt			= IdAnt,
						@usrCodAnt		= UsrCodAnt,
						@dataInicioAnt  = DataInicioAnt,
						@dataFinalAnt	= DataFinalAnt,
						@filtroData		= FiltroDataAnt,
						@valorBruto		= ValorBrutoAnt,
						@valorLiquido	= ValorLiquidoAnt,
						@valorRepasse	= ValorRepasseAnt,
						@dataSolicAnt	= DataSolicAnt,
						@usrCodGrava	= UsrCodGravaAnt,
						@dataGravaAnt	= DataGravaAnt,
						@statusAnt		= StatusAnt,
						@nrRepasseAnt   = NrRepasseAnt,
						@canalAnt		= CanalAnt,
						@obsAnt			= ObsAnt
						
					FROM
						--DADOS NOVOS
						INSERTED
				END TRY
				
				BEGIN CATCH
					--ESCREVENDO MSG DE ERRO SE CAIR NO CATCH
					 PRINT ERROR_MESSAGE() + CAST(ERROR_SEVERITY() AS NVARCHAR)+ CAST(ERROR_STATE() AS NVARCHAR) + CHAR(13) ;
					 
				END CATCH
				
			END
			--FIM DO SUB BLOCO DE INSERT
	
		--VERIFICA SE A AÇÃO É DE UPDATE	
		ELSE IF EXISTS (SELECT * FROM INSERTED) AND EXISTS (SELECT * FROM DELETED)
			
			--INICIO DO SUB BLOCO (1) DE UPDATE, CAPTURANDO OS DADOS ANTIGOS
			BEGIN
			
				PRINT 'Acao de UPDATE';

				--FAZER UM TRY CATCH PARA A VALIDAÇÃO
				BEGIN TRY
				
					--REALIZA O SELECT CAPTURANDO AS NOVAS INFORMAÇÕES PARA INSERIR NA TRIGGER
					SELECT
						@idAnt			= IdAnt,
						@usrCodAnt		= UsrCodAnt,
						@dataInicioAnt  = DataInicioAnt,
						@dataFinalAnt	= DataFinalAnt,
						@filtroData		= FiltroDataAnt,
						@valorBruto		= ValorBrutoAnt,
						@valorLiquido	= ValorLiquidoAnt,
						@valorRepasse	= ValorRepasseAnt,
						@dataSolicAnt	= DataSolicAnt,
						@canalAnt		= CanalAnt
					
					FROM
						--DADOS ANTIGOS
						DELETED
				END TRY
				
				BEGIN CATCH
					--ESCREVENDO MSG DE ERRO SE CAIR NO CATCH
					 PRINT ERROR_MESSAGE() + CAST(ERROR_SEVERITY() AS NVARCHAR)+ CAST(ERROR_STATE() AS NVARCHAR) + CHAR(13) ;
				END CATCH
			
				--INICIO DO SUB BLOCO (2) DE UPDATE
				BEGIN
				
					--FAZER UM TRY CATCH PARA A VALIDAÇÃO
					BEGIN TRY
				
						--REALIZA O SELECT CAPTURANDO AS NOVAS INFORMAÇÕES PARA INSERIR NA TRIGGER
						SELECT
							@usrCodGrava	= UsrCodGravaAnt,
							@dataGravaAnt	= DataGravaAnt,
							@statusAnt		= StatusAnt,
							@nrRepasseAnt   = NrRepasseAnt,
							@obsAnt			= ObsAnt
						
						FROM
							--DADOS NOVOS
							INSERTED
					END TRY
					
					BEGIN CATCH
						--ESCREVENDO MSG DE ERRO SE CAIR NO CATCH
						 PRINT ERROR_MESSAGE() + CAST(ERROR_SEVERITY() AS NVARCHAR)+ CAST(ERROR_STATE() AS NVARCHAR) + CHAR(13) ;
					END CATCH
			
				END
				--FIM DO SUB BLOCO (2) DE UDPATE
			END
			--FIM DO SUB BLOCO (1) DE UPDATE
			
			
		--APOS CAPTURAR TODAS AS INFORMAÇÕES, AGORA SERÁ REALIZADO O INSERT NA TABELA AntecipacaoCanaisLog
		BEGIN TRANSACTION
		INSERT INTO AntecipacaoCanaisLog(UsrCodAntLog, DataInicioAntLog, DataFinalAntLog, FiltroDataAntLog, ValorBrutoAntLog,
									     ValorLiquidoAntLog, ValorRepasseAntLog, DataSolicAntLog, UsrCodGravaAntLog,
									     DataGravaAntLog, StatusAntLog, NrRepasseAntLog, CanalAntLog, ObsAntLog, IdAnt)
									   
		VALUES(@usrCodAnt, @dataInicioAnt, @dataFinalAnt, @filtroData, @valorBruto, @valorLiquido, @valorRepasse,
			   @dataSolicAnt, @usrCodGrava, @dataGravaAnt, @statusAnt, @nrRepasseAnt, @canalAnt, @obsAnt, @idAnt)
			   
		PRINT 'Finalizando Trigger.';
			   
		--VERIFICA SE O INSERT FOI REALIZADO COM SUCESSO
		--ERROR = 0 (ZERO), O INSERT FOI FEITO COM SUCESSO, ERROR DIFERENTE DE 0 (ZERO) FAZ COMMIT
		IF @@ERROR <> 0

			ROLLBACK
			
		ELSE
		
			COMMIT
		
		
	END
	--FIM DO BLOCO PRINCIPAL