# Microsoft Azure Translator 翻譯工具

**Microsoft Translator 允許您翻譯多種語言的文本**


![Microsoft Translator](https://connectoricons-prod.azureedge.net/releases/v1.0.1481/1.0.1481.2460/translatorv2/icon.png "Microsoft Translator")


運用機器翻譯的最新創新技術，即時或分批次將文字翻譯為 [超過 100 種語言](https://go.microsoft.com/fwlink/?linkid=2216841)。支援廣泛的使用案例，例如話務中心、多語系交談專員或應用程式內通訊的翻譯。
個人使用的話幾乎是免費使用[(每月 200 萬個字元免費)](https://azure.microsoft.com/zh-tw/pricing/details/cognitive-services/translator/)

![](https://cdn-dynmedia-1.microsoft.com/is/image/microsoftcorp/cognitive-services_translator_diagram?resMode=sharp2&op_usm=1.5,0.65,15,0&wid=1920&hei=600&qlt=100&fit=constrain)

----

## 前置作業

- 註冊Azure帳號(自行註冊)
- 新增資源群組
- 建立翻譯工具

----

####新增資源群組
<br />

Azure帳號註冊完成後進入[Azure首頁](https://portal.azure.com/#home)
![Azure首頁](https://raw.githubusercontent.com/howwmingnew/MSTranslator/master/ReadMe/Images/01.png "Azure首頁")
<br />

上方搜尋列輸入 `資源群組`點擊第一個搜尋結果進入網頁，或是[點此連結](https://portal.azure.com/#view/HubsExtension/BrowseResourceGroups)
![](https://raw.githubusercontent.com/howwmingnew/MSTranslator/master/ReadMe/Images/02.png)
<br />

點擊中間`建立資源群組`按鈕或是左上角`+ 建立`按鈕
![](https://raw.githubusercontent.com/howwmingnew/MSTranslator/master/ReadMe/Images/03.png)
<br />

自訂`訂用帳戶`及`資源群組名稱`，區域選擇你所在地區
![](https://raw.githubusercontent.com/howwmingnew/MSTranslator/master/ReadMe/Images/04.png)
<br />

完成後點擊下方`下一步`按鈕2次，到`檢閱 + 建立`頁面，如果沒問題上方會顯示`驗證成功。`，好了就按左下角建立按鈕，這樣資源群組就新增完成了<br />
![](https://raw.githubusercontent.com/howwmingnew/MSTranslator/master/ReadMe/Images/05.png)
<br />

過程中頁面可能會轉跳到訂用帳戶，沒特殊用途的話選最左邊`從Azure免費試用開始`就好，之後就照著頁面的問題回答即可
![](https://raw.githubusercontent.com/howwmingnew/MSTranslator/master/ReadMe/Images/06.png)
<br /> <br />

####建立翻譯工具
<br />

資源群組完成後就在Azure網頁上方搜尋列輸入 `翻譯工具`點擊第一個搜尋結果進入網頁，或是[點此連結](https://portal.azure.com/#view/Microsoft_Azure_ProjectOxford/CognitiveServicesHub/~/TextTranslation)
![](https://raw.githubusercontent.com/howwmingnew/MSTranslator/master/ReadMe/Images/07.png)
<br />

和資源群組一樣點擊中間`建立翻譯工具`按鈕或是左上角`+ 建立`按鈕
![](https://raw.githubusercontent.com/howwmingnew/MSTranslator/master/ReadMe/Images/08.png)
<br />

上方`訂用帳戶`及`資源群組`選擇剛建立好的資源群組，下方區域選擇`Global`，名稱自訂(不能跟其它人有相同的名稱)，定價層選擇`Free F0(Up to 2M characters translated per month)`
![](https://raw.githubusercontent.com/howwmingnew/MSTranslator/master/ReadMe/Images/09.png)
<br />

完成後點擊下方`下一步`按鈕4次，到`檢閱 + 建立`頁面，如果沒問題上方會顯示`驗證成功。`，好了就按左下角建立按鈕
![](https://raw.githubusercontent.com/howwmingnew/MSTranslator/master/ReadMe/Images/10.png)
<br />

翻譯工具會花上幾秒鐘的時間進行部署，部署完成後就算是告一個段落了，點擊下方`前往資源`按鈕
![](https://raw.githubusercontent.com/howwmingnew/MSTranslator/master/ReadMe/Images/11.png)
<br />

在概觀頁面下就可以試用翻譯功能，在格子內輸入你想翻譯的文字或句子，有結果的話就會出現在右邊格子內，在更下面是API實際Request和Response內容
![](https://raw.githubusercontent.com/howwmingnew/MSTranslator/master/ReadMe/Images/12.png)
<br />

成功的回應是輸入陣列的每個字串各有一個結果的 JSON 陣列。 結果物件包含下列屬性：

+ `detectedLanguage`：物件，透過下列屬性描述偵測到的語言：
	+ `language`：字串，代表偵測到語言的代碼
	+ `score`：浮點值，表示結果的信賴度。 分數介於 0 與 1 之間，分數低表示信賴度偏低
	只有在要求自動偵測語言時，`detectedLanguage` 屬性才會存在於結果物件中
+ `translations`：翻譯結果的陣列。 陣列大小符合透過 to 查詢參數指定的目標語言數。 陣列中的每個項目都包括：
	+ `to`：字串，代表目標語言的語言代碼
	+ `text`：字串，提供翻譯文字<br />
![](https://raw.githubusercontent.com/howwmingnew/MSTranslator/master/ReadMe/Images/13.png)
<br />

####取得金鑰(Access token)

最後最重要的，如果要使用翻譯工具API就需要拿到它的金鑰，在概觀頁面點擊`按一下這裡以檢視端點`或是`按一下這裡以管理金鑰`
![](https://raw.githubusercontent.com/howwmingnew/MSTranslator/master/ReadMe/Images/14.png)
<br />

Azure會產生2把金鑰，選擇其中一把金鑰複製並貼到你會用到API的程式或程式碼內即可使用，之後如果有問題也可以直接按上方`重新產生Key`按鈕重新產生一組金鑰
![](https://raw.githubusercontent.com/howwmingnew/MSTranslator/master/ReadMe/Images/15.png)
<br />

以本專案為例，在`TranslatorAPI.cs`的API Request程式碼，修改`Ocp-Apim-Subscription-Key`數值成你自己的金鑰即可
![](https://raw.githubusercontent.com/howwmingnew/MSTranslator/master/ReadMe/Images/16.png)
<br />
實際成果:<br />
![](https://raw.githubusercontent.com/howwmingnew/MSTranslator/master/ReadMe/Images/18.png)
<br />

以ResX Resource Manager為例，在`Translate分頁`Key貼上你自己的金鑰，Region設為global即可
![](https://raw.githubusercontent.com/howwmingnew/MSTranslator/master/ReadMe/Images/17.png)
<br />

----

[Microsoft Learn: 文字翻譯](https://learn.microsoft.com/zh-tw/azure/cognitive-services/translator/text-translation-overview)
[Microsoft Azure首頁](https://portal.azure.com/#home)
