SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Jeyson>
-- Create date: <28/07/2017>
-- Description:	<Trigger que irá inserir as alterações na tb POSControleEstoqueLog>
-- =============================================
CREATE TRIGGER tg_inserirLogPosEstoque 
   ON  [dbo].[POSControleEstoque]
   
   --SERÁ EXECUTADO APENAS QUANDO REALIZAREM INSERT OU UPDATE NA TABELA POSControleEstoque
   FOR INSERT, UPDATE
   
AS 

--INICIO BLOCO PRINCIPAL
BEGIN
	
	--BLOCO DE VARIAVEIS
	DECLARE
		@POSSerie		CHAR(30),
		@POSStatus		CHAR(1),
		@ContaMod		CHAR(15),
		@EstabAntigo	VARCHAR(50),
		@EstabNovo		VARCHAR(50),
		@NrAtendimento	VARCHAR(50),
		@Observacao		VARCHAR(500)
		
		PRINT 'INICIANDO TRIGGER...'
		
		--AÇÃO DE INSERIR
		IF EXISTS (SELECT * FROM INSERTED) AND NOT EXISTS (SELECT * FROM DELETED)
			BEGIN
			
				PRINT 'AÇÃO: INSERT.'
				
				BEGIN TRY
				
					SELECT
						@POSSerie		= POSSerieEst,
						@POSStatus		= POSStatusEst,
						@EstabAntigo	= 'ADM',
						@EstabNovo		= POSUsrEstab,
						@ContaMod		= POSUsrIncEst,
						@NrAtendimento	= POSNrAtendimento,
						@Observacao		= POSObs
						
					FROM 
						--DADOS NOVOS
						INSERTED
					
					--SE O NR ATENDIMENTO FOR VAZIO OU NULO, INSIRO 0(ZERO) NO LOG	
					IF @NrAtendimento = '' OR @NrAtendimento IS NULL
					
						BEGIN
							SET @NrAtendimento = '0'
						END
				
				END TRY
				
				BEGIN CATCH
				
					PRINT ERROR_MESSAGE() + CAST(ERROR_SEVERITY() AS NVARCHAR)+ CAST(ERROR_STATE() AS NVARCHAR) + CHAR(13);
					
				END CATCH
			
			END
			--FIM DO SUB BLOCO DE INSERT
			
		--VERIFICA SE A AÇÃO É DE UPDATE
		ELSE IF EXISTS (SELECT * FROM INSERTED) AND EXISTS (SELECT * FROM DELETED)
		
			--INICIO DO SUB BLOCO (1) DE UPDATE
			BEGIN 
			
				PRINT 'AÇÃO: UPDATE.'
				
				BEGIN TRY
				
					SELECT
						@POSSerie		= POSSerieEst,
						@EstabAntigo	= POSUsrEstab
					
					FROM
						--DADOS ANTIGOS
						DELETED
				
				END TRY
				
				BEGIN CATCH
				
					PRINT ERROR_MESSAGE() + CAST(ERROR_SEVERITY() AS NVARCHAR)+ CAST(ERROR_STATE() AS NVARCHAR) + CHAR(13);
				
				END CATCH
				
				--INICIO DO SUB BLOCO (2) DE UPDATE
				BEGIN
				
					BEGIN TRY
					
						SELECT
							@POSStatus		= POSStatusEst,
							@EstabNovo		= POSUsrEstab,
							@ContaMod		= POSUsrModEst,
							@NrAtendimento	= POSNrAtendimento,
							@Observacao		= POSObs
							
						FROM 
							--DADOS ATUALIZADOS
							INSERTED
							
						--SE O NR ATENDIMENTO FOR VAZIO OU NULO, INSIRO 0(ZERO) NO LOG	
						IF @NrAtendimento = '' OR @NrAtendimento IS NULL
						
							BEGIN
								SET @NrAtendimento = '0'
							END
					
					END TRY
					
					BEGIN CATCH
					
						PRINT ERROR_MESSAGE() + CAST(ERROR_SEVERITY() AS NVARCHAR)+ CAST(ERROR_STATE() AS NVARCHAR) + CHAR(13);
					
					END CATCH
				
				END
				--FIM DO SUB BLOCO (2) DE UDPATE
			
			END
			--FIM DO SUB BLOCO (1) DE UDPATE
			
			BEGIN TRANSACTION
			INSERT INTO POSControleEstoqueLog(POSSerieLog, POSStatusLog, POSUsrEstabAntigoLog, POSUsrEstabNovoLog,
											  POSDataOperacaoLog, POSUsrModLog, POSAtendNrProtocol, POSObsLog)
											  
			VALUES(@POSSerie, @POSStatus, @EstabAntigo, @EstabNovo, GETDATE(), @ContaMod, @NrAtendimento, @Observacao)
			
			--VERIFICA SE O INSERT FOI REALIZADO COM SUCESSO
			--ERROR = 0 (ZERO), O INSERT FOI FEITO COM SUCESSO, ERROR DIFERENTE DE 0 (ZERO) FAZ COMMIT
			IF @@ERROR <> 0
				BEGIN
					
					PRINT 'OCORREU UM ERRO, FAZENDO ROLLBACK.'
					
					ROLLBACK
				END
				
			ELSE
				BEGIN
					PRINT 'DADOS INSERIDOS COM SECUESSO, FAZENDO COMMIT.'
				
					COMMIT
				END
				
		PRINT 'FINALIZANDO TRIGGER.'
END
--FIM DO BLOCO PRINCIPAL
GO
