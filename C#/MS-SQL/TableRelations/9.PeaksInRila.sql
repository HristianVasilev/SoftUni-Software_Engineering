USE Geography
GO

SELECT
	[Mountains].[MountainRange],
	[Peaks].[PeakName],
	[Peaks].[Elevation]
FROM [Peaks]
JOIN [Mountains] ON [Mountains].[Id] = [Peaks].[MountainId]
WHERE [MountainRange] = 'Rila'
ORDER BY [Elevation] DESC