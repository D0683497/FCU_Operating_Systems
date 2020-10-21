ECHO OFF

REM 採用 UTF-8 編碼
chcp 65001

:input_source
set /p source="請輸入來源檔案: "
if exist %source% (
    REM 來源檔案存在
    goto input_dest
) else (
    REM 來源檔案不存在
    goto end
)

:input_dest
set /p dest="請輸入目的檔案: "
if exist %dest% (
    REM 目的檔案存在
    goto copy_content
) else (
    REM 目的檔案不存在
    goto end
)

:copy_content
REM 兩個檔案的內容會合併
type %source% >> %dest%

:end
echo "程式結束"
