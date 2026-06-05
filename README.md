# Windows SSO API Sample

.NET 8 純 Web API，使用 Windows Authentication / Negotiate 做 Single Sign-On。

## 功能
- `/api/auth/ping`：匿名測試
- `/api/auth/me`：取得目前 Windows 使用者
- `/api/auth/groups`：檢視群組 claims

## 開發建議
- Visual Studio
- IIS Express
- Windows 網域環境

## 套件
- Microsoft.AspNetCore.Authentication.Negotiate

## 注意
Swagger / Postman 不一定能正確模擬 Windows 驗證，請優先用瀏覽器或 .NET 用戶端測試。
