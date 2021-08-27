<!-- default badges list -->
![](https://img.shields.io/endpoint?url=https://codecentral.devexpress.com/api/v1/VersionRange/128606366/10.2.5%2B)
[![](https://img.shields.io/badge/Open_in_DevExpress_Support_Center-FF7200?style=flat-square&logo=DevExpress&logoColor=white)](https://supportcenter.devexpress.com/ticket/details/E3484)
[![](https://img.shields.io/badge/📖_How_to_use_DevExpress_Examples-e9f6fc?style=flat-square)](https://docs.devexpress.com/GeneralInformation/403183)
<!-- default badges end -->
<!-- default file list -->
*Files to look at*:

* [Default.aspx](./CS/ExternalWebSite/Default.aspx) (VB: [Default.aspx](./VB/ExternalWebSite/Default.aspx))
* [Default.aspx.cs](./CS/ExternalWebSite/Default.aspx.cs) (VB: [Default.aspx.vb](./VB/ExternalWebSite/Default.aspx.vb))
* [Silverlight.js](./CS/SLApplication.Web/Silverlight.js) (VB: [Silverlight.js](./VB/SLApplication.Web/Silverlight.js))
* [SLApplicationTestPage.aspx](./CS/SLApplication.Web/SLApplicationTestPage.aspx) (VB: [SLApplicationTestPage.aspx](./VB/SLApplication.Web/SLApplicationTestPage.aspx))
* [MainPage.xaml](./CS/SLApplication/MainPage.xaml) (VB: [MainPage.xaml](./VB/SLApplication/MainPage.xaml))
* [MainPage.xaml.cs](./CS/SLApplication/MainPage.xaml.cs) (VB: [MainPage.xaml.vb](./VB/SLApplication/MainPage.xaml.vb))
<!-- default file list end -->
# DXRichEdit - How to force images from external hosts to be loaded into RichEditControl


<p>By default, Silverlight application connectivity is limited to the host or site of origin. This means that a web application can only communicate back to its deploying server, so network applications ere allowed to connect to the host from which they were downloaded. This nuance is specific to the Silverlight platform and can be resolved by adding an appropriate "clientaccesspolicy.xml" file to the root of the requested target domain (see <a href="http://msdn.microsoft.com/en-us/library/cc645032(v=vs.95).aspx"><u>Network Security Access Restrictions in Silverlight</u></a>). We are using this solution (which appears to be the simplest one) in our scenario. </p><br />
<p>Here is the projects structure of our example:</p><br />
<p><strong>SLApplication</strong> - Silverlight application</p><p><strong>SLApplication.Web</strong> - ASP.NET Web Site where the Silverlight application is hosted.</p><p><strong>ExternalWebSite </strong>- This ASP.NET Web Site simulates a remote host where the image (\Images\devexpresslogo.png) requested by the Silverlight application is placed</p><br />
<p>Note that the "clientaccesspolicy.xml" file is located at the root of the ExternalWebSite. </p><br />
<p>The HTML file from which the remote image is referenced is placed in the host of origin (SLApplication.Web). Here is how it is loaded into the RichEditControl:</p><br />


```cs
    WebClient webClient = new WebClient();

    webClient.OpenReadCompleted += new OpenReadCompletedEventHandler(webClient_OpenReadCompleted);
    webClient.OpenReadAsync(new Uri("http://localhost:1046/SLApplication.Web/TestPage.html", UriKind.Absolute));

    ...

    void webClient_OpenReadCompleted(object sender, OpenReadCompletedEventArgs e) {
        if (e.Error == null) {
            richEditControl1.ApplyTemplate();
            richEditControl1.LoadDocument(e.Result, DocumentFormat.Html);
        }
    }

```

<p> </p><p><strong>Note:</strong></p><p>This approach can be used only when you have access to the remote host or can ask its administrator to configure it to allow cross-domain access.</p><br />
<p><strong>See Also:</strong></p><p><a href="http://msdn.microsoft.com/en-us/library/system.net.webclient(v=vs.95).aspx"><u>WebClient Class</u></a></p>

<br/>


