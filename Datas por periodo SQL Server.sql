DECLARE @Data1 DATE, @Data2 DATE
SET @Data1 = '20151231'
SET @Data2 = '20161231'

SELECT DATEADD(DAY, number + 1, @Data1) [Data], 'COL 1' [COLUNA 1], 'COL 2' [COLUNA 2], 'COL 3' [COLUNA 3]
FROM master..spt_values
WHERE type = 'P'
AND DATEADD(DAY, number + 1, @Data1) <= @Data2
ORDER BY [Data] ASC