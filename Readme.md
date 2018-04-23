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


