# Windows SSO API Sample

.NET 8 純 Web API，使用 Windows Authentication / Negotiate 做 Single Sign-On，可直接部署到 IIS。

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
- Swashbuckle.AspNetCore

## 本機執行
優先建議使用 Visual Studio + IIS Express。

也可以用 CLI：

```bash
dotnet restore
dotnet build
dotnet run
```

## IIS 部署
### 1. 伺服器需求
- IIS
- Windows Authentication 功能
- .NET 8 Hosting Bundle

### 2. 發佈
```bash
dotnet publish -c Release -o ./publish
```

### 3. IIS 站台設定
- Application Pool：No Managed Code
- Anonymous Authentication：Disabled
- Windows Authentication：Enabled

### 4. 部署資料夾
把 `publish` 目錄內容複製到 IIS 站台實體路徑。

### 5. 測試
瀏覽器直接開啟：
- `/api/auth/ping`
- `/api/auth/me`

## 注意
- Swagger / Postman 不一定能正確模擬 Windows 驗證，請優先用瀏覽器或 .NET 用戶端測試。
- `web.config` 已包含 IIS Windows Authentication 設定。
