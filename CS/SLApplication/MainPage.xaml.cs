using System;
using System.Net;
using System.Windows.Controls;
using DevExpress.XtraRichEdit;

namespace SLApplication {
    public partial class MainPage : UserControl {
        public MainPage() {
            InitializeComponent();

            WebClient webClient = new WebClient();

            webClient.OpenReadCompleted += new OpenReadCompletedEventHandler(webClient_OpenReadCompleted);
            webClient.OpenReadAsync(new Uri("http://localhost:1046/SLApplication.Web/TestPage.html", UriKind.Absolute));
        }

        void webClient_OpenReadCompleted(object sender, OpenReadCompletedEventArgs e) {
            if (e.Error == null) {
                richEditControl1.ApplyTemplate();
                richEditControl1.LoadDocument(e.Result, DocumentFormat.Html);
            }
        }
    }
}
