請參考以下網址:

[https://hackmd.io/@EdwardHsu/ASP_NET_Core_Learning](https://hackmd.io/@EdwardHsu/ASP_NET_Core_Learning)


-----


# 1. GIT的基礎使用
使用Source Tree操作。

---

## 1.1. SourceTree安裝

至[SourceTree](https://www.sourcetreeapp.com/)官網下載。
SourceTree安裝檔附帶Git安裝，所以不用額外下載。

----

### 1.1.1. 步驟一
安裝第一步驟可以直接點選**Skip**略過登入Bitbucket服務。
![](https://i.imgur.com/3ImvK6P.png)

----

### 1.1.2. 步驟二
在選擇安裝項目中必定將**Git**項目勾選。
![](https://i.imgur.com/Hf0XCEp.png)

----

### 1.1.3. 步驟三
安裝完成。
![](https://i.imgur.com/gzO1VKo.png)

----

### 1.1.4. 步驟四
設定Git使用者資訊。
![](https://i.imgur.com/VoD6dMC.png)

----

### 1.1.5. 步驟五
接下來選擇是否匯入SSH Key，這個範例中先選擇No略過。
![](https://i.imgur.com/32qG6Wd.png)

----

## 1.2. SourceTree與Git的使用

----

### 1.2.1. 建立Repository
點選工具列的**Create**，依照表單要求資訊輸入後點選**Create**按鈕。
![](https://i.imgur.com/RVMq5nE.png)

----

### 1.2.2. 設定.gitignore
專案有許多無須加入版控的檔案，如`dll`檔案或`node_module`目錄，可透過`.gitignore`在git略過這些檔案。
在GitHub中的[github/gitignore](https://github.com/github/gitignore)，其中包含了大多數常用的.gitignore設定檔。

![](https://i.imgur.com/pWFQ9vH.png)

----

### 1.2.3. 手動將檔案加入.gitignore
在SourceTree中切換至`WORKSPACE/File Status`，在要略過的項目點右鍵選擇`Ignore`。
![](https://i.imgur.com/qZOmk76.png)

----

在`Ignore`設定視窗中選擇`Ignore exact filename(s)`，或依自己需求調整。
![](https://i.imgur.com/b09B80L.png)

----

### 1.2.4. 加入Origin
首先選擇`Settings`後選擇`Remotes`標籤，最後點選`Add`。
![](https://i.imgur.com/PUDAx5C.png)

----

取得Git Server的Repository URL。
![](https://i.imgur.com/gwLur51.png)

----

在`Required Information`選項中點選Default remote並設定URL。點選OK。
![](https://i.imgur.com/Tl4nzI6.png)

----

完成。
![](https://i.imgur.com/Avlio17.png)

----

### 1.2.5. 初始化Git Flow

由於剛建立的Repository沒有第一個commit起始點，所以執行以下指令建立起使commit。
```bash
git commit -m "init" --allow-empty
```

----

點選`Git-flow`按鈕，之後直接點選OK。
![](https://i.imgur.com/zhc9ZsX.png)

----

完成。
![](https://i.imgur.com/Ar1hTnF.png)

### 1.2.6. 建立Commit

在File Status標籤中將Unstaged的項目移動至Staged中，並在Commit message輸入本次修改的意圖，選擇Commit。
![](https://i.imgur.com/6GgfyO0.png)

----

### 1.2.7. Pull & Push

點選Push按鈕，勾選要推至Git Server的分支。
![](https://i.imgur.com/1K5ET32.png)

----

## 1.3. Git Flow

![](https://i.imgur.com/C9aTf0S.png)

---

# 2. HTTP Methods

## 2.1. GET

最常見的行為，如瀏覽器輸入網址後瀏覽的行為。

幂等，每次請求客戶端接收結果應該一樣。

----

## 2.2. POST

可以用於建立與上傳行為。

非幂等，每次請求狀態不一。

----

## 2.3. PUT

用於更新資料與上傳行為。

幂等，每次請求客戶端接收結果應該一樣。

----

## 2.4. DELETE

常用於刪除資源。

非幂等，每次請求狀態不一。

----

## 2.5. RESTful

REST 介面有三要素：
1. 名詞(Noun): 操作資源，像是https://xxx/api/User/user1。
2. 動詞(Verb): 操作指令，包含GET、POST、PUT、DELETE。
3. 表徵(Content Type):內容格式，像HTML。

> 參考自: https://medium.com/@jinghua.shih/%E7%AD%86%E8%A8%98-rest-%E5%88%B0%E5%BA%95%E6%98%AF%E4%BB%80%E9%BA%BC-170ad2b45836

---

# 3. ASP.NET Core

![](https://i.imgur.com/Di6fb80.png)

----

## 3.1. Dependencty Injection

在ASP.NET Core專案中的Startup Class中的`ConfigureServices`區塊為定義DI項目用途。

```csharp
public void ConfigureServices(IServiceCollection services)
{
    services.AddTransient<ClassA>();
    services.AddScoped<ClassB>();
    services.AddSingleton<ClassC>();

    services.AddMvc();
}
```

----

在ASP.NET Core中的DI容器提供以下三種注入項目的生命週期

1. Transient: 瞬態，每次向DI提供者取得都會重新產生。
2. Scoped: 範圍，在ASP.NET Core中表示為一個Request至Response週期。
3. Singletion: 單例，整個應用程式中都共用同一個物件實例。

----

![](https://i.imgur.com/9X4Pwp4.png)

參考自: https://blog.johnwu.cc/article/ironman-day04-asp-net-core-dependency-injection.html

----

## 3.2. Pipeline & Middleware

![](https://i.imgur.com/1oscNTG.png)

----

在Startup Class的Configure方法定義Http Request至Http Response的整個流程。先進後出。

![](https://i.imgur.com/8KHmzCA.png)

----

常見的幾個Pipeline定義有以下幾個:

1. Use: pipeline的過程
3. Run: pipeline的終點
4. Map: 使用路由作為pipeline分岔依據
5. MapWhen: 使用條件作為pipeline分岔依據

----

## 3.3. Static Files

```csharp
public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
{
    // 使用狀態碼導引，如發生404則導引到/404.html
    app.UseStatusCodePagesWithRedirects("/{0}.html");
    
    // 若未指定檔案名稱則預設使用index.html
    app.UseDefaultFiles();
    
    // 讀取wwwroot目錄內的檔案
    app.UseStaticFiles();
}
```

----

## 3.4. Configuration

在Startup中若需要讀取appsettings.json的設定，則可以在Startup建構式中加入`IConfiguration`類型的參數，並將其儲存至屬性如下:

```csharp
public class Startup
{
    public IConfiguration Configuration{get;private set;}
    public Startup(IConfiguration config){
        Configuration = config;
    }
}
```

----

```json
{ "ConnectionStrings":{ "Default": "xxxxx" } }
```

若再設定DI或Pipeline中使用Configuration的參數，如要讀取其中的ConnectionStrings則可以如下兩種方法獲取。

```csharp
Configuration.GetConnectionStrings("Default");
Configuration["ConnectionStrings:Default"];
```

----

## 3.5. SPA Routing

若網站為SPA，路由為ASP.NET Core負責，再對SPA的路由需要將404回應index.html的內容，以便S獲取路由。

```csharp
public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
{
    app.Use(async (context, next) =>
    {
        await next();

        if (context.Response.StatusCode == 404) // 當404時，將原有Request路徑複寫重試
        {
            context.Request.Path = "/";
            await next();
        }
    });

    //app.UseStatusCodePagesWithReExecute("/"); //也可以直接使用這個方式

    app.UseDefaultFiles();
    app.UseStaticFiles();
}
```

----

## 3.6. Cookies & Session

使用Cookies與Session可以用來簡單的儲存使用者狀態或登入狀態等。
在使用Cookies時並不需要額外加入DI項目，直接於Middleware或HttpContext中調用Request或Response的Cookies屬性即可進行讀取與寫入操作。

----

```csharp
app.Run(async (context) =>
{
    if (context.Request.Cookies.TryGetValue("Test", out string testValue))
    {
        context.Response.Cookies.Append("Test", testValue + "x", new CookieOptions()
        {
            HttpOnly = true,
            Expires = DateTimeOffset.Now.AddDays(1)
        });
    }
    else
    {
        context.Response.Cookies.Append("Test", "x", new CookieOptions()
        {
            HttpOnly = true,
            Expires = DateTimeOffset.Now.AddDays(1)
        });
    }
});
```

----

若是要使用Session，則需補充以下兩個DI項目:

```csharp
services.AddDistributedMemoryCache(); // 加入InMemory的分散式快取
services.AddSession(); // 加入Session服務
```

----

加入DI項目後再Pipeline的範例如下:

```csharp
app.UseSession(); // 這個Middleware之後才可用Session服務
app.Use(async (context, next) =>
{
    context.Session.SetString("TEST", "AAAA"); // 寫入Session
    await next();
});
```

---

## 3.7. 站台發佈

首先在要發佈的WEB專案點選右鍵/發佈

![](https://i.imgur.com/ldMulrC.png)

我們先選擇資料夾的形式發行

----

使用預設路徑

![](https://i.imgur.com/FR7oAT4.png)

----

![](https://i.imgur.com/VQHf1Zj.png)

----

### 3.7.1 自封裝

在某些形況下希望可以讓EndUser可以在不附加在IIS運行WEB服務，而不需要另外安裝.NET Core環境，這時候可以將整個WEB封裝獨立運行。

![](https://i.imgur.com/PFnX7nx.png)

----

以上述步驟產生的程式檔案中的dll數量繁多，使用者要在其中找到exe檔案稍嫌麻煩。

而在.NET Core 3中提供選項可以將眾多DLL與EXE封裝在同一個EXE中。

![](https://i.imgur.com/8KbIvvk.png)

----

### 3.7.2 IIS

若要將ASP.NET Core佈署於IIS上，則該SERVER需要安裝IIS的擴充(ASP.NET Core Module)。之後可以將帶有web.config的編譯結果直接放上去。

![](https://i.imgur.com/OPX40g6.png)

----

#### 3.7.2.1 在IIS上的異常排除

----

#### 3.7.2.2 掛載子應用程式

----

## 3.8. EntityFrameworkCore

---

# 4. ASP.NET Core MVC

----

## 4.1. 建立Controller與基本的RESTful API

----

## 4.2. MVC Action路由

----

## 4.3. 建立View與View的載入順序

----

## 4.4. View的Layout

----

## 4.5. 基本的Razor語法

----

## 4.6. 常見的ActionResult類型

----

## 4.7. 搭配EntityFrameworkCore撰寫API

----

## 4.8. 搭配EntityFrameworkCore撰寫View

----

## 4.9. MVC使用Session做登入驗證

----

## 4.10. RESTful API使用JWT做登入驗證

### 4.10.1. 什麼是JWT

### 4.10.2. 簽發JWT

### 4.10.3. 驗證JWT

### 4.10.4. 綁定Action驗證
