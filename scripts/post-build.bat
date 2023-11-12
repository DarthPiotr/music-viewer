@echo off
echo === Post Build Script ===

SET solutionDir=%~1
SET outDir=%~2
SET result=Succeeded

set list=DAOMock DAOSQL DAOFile

(for %%i in (%list%) do call :ProcessFile %%i)
goto :End

:ProcessFile
SET item=%1
SET filePath="%solutionDir%MusicViewer.%item%\bin\Debug\net7.0\MusicViewer.%item%.dll"
if exist %filePath% (
	xcopy /Y /D %filePath% %outDir% && echo %item% copied to output. || (
		echo [ERROR] Error while copying %item%
		SET result=Failed
	)
) else (
	echo %item% does not exist.
)
goto :eof

:End
echo === Post Build Script: %result% ===